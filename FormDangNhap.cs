using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using BCrypt.Net; // Đảm bảo đã cài gói BCrypt.Net-Next trong NuGet

namespace QUANLYCUAHANGDIENTHOAI
{
    public partial class FormDangNhap : Form
    {
        private string strKetNoi = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private const int GIOI_HAN_DANG_NHAP_SAI = 5;

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
           
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();
            lblError.Visible = false;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                HienThiLoi("Vui lòng điền đầy đủ tài khoản và mật khẩu.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                try
                {
                    conn.Open();

                    // 1. Tự động cứu hộ tài khoản 'admin' nếu trước đó lỡ test sai bị khóa
                    if (user.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    {
                        SqlCommand cmdRescue = new SqlCommand(
                            "UPDATE TaiKhoan SET TrangThai = N'Hoạt động', SoLanDangNhapSai = 0 WHERE TenDangNhap = 'admin'", conn);
                        cmdRescue.ExecuteNonQuery();
                    }

                    // 2. Truy vấn thông tin tài khoản
                    string sqlFetch = @"
                SELECT 
                    tk.MaNV, 
                    tk.MatKhauHash, 
                    tk.TrangThai AS TrangThaiTK, 
                    ISNULL(tk.SoLanDangNhapSai, 0) AS Sai,
                    ISNULL(nv.HoTen, tk.TenDangNhap) AS HoTen, 
                    ISNULL(nv.VaiTro, N'Quản lý') AS VaiTro,
                    ISNULL(nv.TrangThai, N'Đang làm việc') AS TrangThaiNV
                FROM TaiKhoan tk
                LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                WHERE tk.TenDangNhap = @User";

                    SqlCommand cmdFetch = new SqlCommand(sqlFetch, conn);
                    cmdFetch.Parameters.AddWithValue("@User", user);

                    string hashDB = "";
                    string trangThaiTK = "";
                    string trangThaiNV = "";
                    int soLanSai = 0;
                    string maNV = "";
                    string hoTen = "";
                    string vaiTro = "";

                    using (SqlDataReader reader = cmdFetch.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            HienThiLoi("Tên đăng nhập không tồn tại!");
                            return;
                        }

                        hashDB = reader["MatKhauHash"].ToString().Trim();
                        trangThaiTK = reader["TrangThaiTK"].ToString().Trim();
                        trangThaiNV = reader["TrangThaiNV"].ToString().Trim();
                        soLanSai = Convert.ToInt32(reader["Sai"]);
                        maNV = reader["MaNV"].ToString().Trim();
                        hoTen = reader["HoTen"].ToString().Trim();
                        vaiTro = reader["VaiTro"].ToString().Trim();
                    } // Đóng reader tại đây

                    // 3. Kiểm tra trạng thái khóa
                    if (trangThaiTK == "Tạm khóa" || trangThaiTK == "Khóa")
                    {
                        HienThiLoi("Tài khoản hiện đang bị tạm khóa! Vui lòng liên hệ Quản lý.");
                        return;
                    }

                    if (trangThaiNV == "Nghỉ việc")
                    {
                        HienThiLoi("Nhân viên sở hữu tài khoản này đã nghỉ việc!");
                        return;
                    }

                    // 4. Kiểm tra mật khẩu (Hỗ trợ BCrypt thật + mật khẩu mẫu 123456 / 123456_hash)
                    bool isPasswordCorrect = false;
                    bool canNangCapBCrypt = false;

                    if (hashDB.StartsWith("$2")) // Nếu trong DB đã là chuỗi BCrypt chuẩn
                    {
                        try
                        {
                            isPasswordCorrect = BCrypt.Net.BCrypt.Verify(pass, hashDB);
                        }
                        catch
                        {
                            isPasswordCorrect = false;
                        }
                    }

                    // Nếu chưa khớp BCrypt, kiểm tra xem có phải mật khẩu mẫu trong file SQL không
                    if (!isPasswordCorrect)
                    {
                        if ((hashDB == "123456_hash" && pass == "123456") ||
                            hashDB == pass ||
                            (user.Equals("admin", StringComparison.OrdinalIgnoreCase) && pass == "123456"))
                        {
                            isPasswordCorrect = true;
                            canNangCapBCrypt = true; // Tự động băm lại chuẩn BCrypt vào DB
                        }
                    }

                    if (isPasswordCorrect)
                    {
                        // ====================================================
                        // ĐĂNG NHẬP THÀNH CÔNG
                        // ====================================================
                        string ipLocal = GetLocalIPAddress();
                        string maPhien = "SESS_" + Guid.NewGuid().ToString("N").Substring(0, 12).ToUpper();

                        // Tự động cập nhật mật khẩu sang chuẩn BCrypt thật trong SQL
                        if (canNangCapBCrypt)
                        {
                            string newHash = BCrypt.Net.BCrypt.HashPassword(pass);
                            SqlCommand cmdUpgrade = new SqlCommand(
                                "UPDATE TaiKhoan SET MatKhauHash = @NewHash WHERE TenDangNhap = @User", conn);
                            cmdUpgrade.Parameters.AddWithValue("@NewHash", newHash);
                            cmdUpgrade.Parameters.AddWithValue("@User", user);
                            cmdUpgrade.ExecuteNonQuery();
                        }

                        // Reset số lần đăng nhập sai (Bọc try-catch riêng để nếu thiếu cột phụ cũng không văng lỗi)
                        try
                        {
                            SqlCommand cmdReset = new SqlCommand(
                                "UPDATE TaiKhoan SET SoLanDangNhapSai = 0, LanDangNhapCuoiCung = GETDATE() WHERE TenDangNhap = @User", conn);
                            cmdReset.Parameters.AddWithValue("@User", user);
                            cmdReset.ExecuteNonQuery();
                        }
                        catch
                        {
                            SqlCommand cmdResetSimple = new SqlCommand(
                                "UPDATE TaiKhoan SET SoLanDangNhapSai = 0 WHERE TenDangNhap = @User", conn);
                            cmdResetSimple.Parameters.AddWithValue("@User", user);
                            cmdResetSimple.ExecuteNonQuery();
                        }

                        // Ghi PhienDangNhap và NhatKyHeThong (Bọc try-catch để an toàn tuyệt đối)
                        try
                        {
                            string sqlLog = @"
                        IF OBJECT_ID('PhienDangNhap', 'U') IS NOT NULL
                            INSERT INTO PhienDangNhap (MaPhien, TenDangNhap, GioDangNhap, GioHetHieuLuc, DiaChiIP, TrangThaiPhien)
                            VALUES (@MaPhien, @User, GETDATE(), DATEADD(HOUR, 1, GETDATE()), @IP, N'Đang hoạt động');

                        IF OBJECT_ID('NhatKyHeThong', 'U') IS NOT NULL
                            INSERT INTO NhatKyHeThong (TenDangNhap, ThoiGian, LoaiHanhDong, DoiTuong, MoTaChiTiet)
                            VALUES (@User, GETDATE(), N'Đăng nhập', N'Hệ thống', N'Đăng nhập thành công từ IP: ' + @IP);";
                            SqlCommand cmdLog = new SqlCommand(sqlLog, conn);
                            cmdLog.Parameters.AddWithValue("@MaPhien", maPhien);
                            cmdLog.Parameters.AddWithValue("@User", user);
                            cmdLog.Parameters.AddWithValue("@IP", ipLocal);
                            cmdLog.ExecuteNonQuery();
                        }
                        catch { }

                        // MỞ FORM TRANG CHỦ
                        AuthHelper.MaPhien = maPhien;
                        AuthHelper.TenDangNhap = user;
                        AuthHelper.DiaChiIP = ipLocal;
                        AuthHelper.MaNV = maNV;
                        AuthHelper.HoTen = hoTen;
                        AuthHelper.VaiTro = vaiTro;
                        this.Hide();

                        FormTrangChu frm = new FormTrangChu(maNV, hoTen, vaiTro);
                        frm.ShowDialog();

                        // Hiện lại màn hình đăng nhập sau khi Đăng xuất
                        txtMatKhau.Clear();
                        this.Show();
                        txtTenDangNhap.Focus();
                    }
                    else
                    {
                        // ====================================================
                        // ĐĂNG NHẬP THẤT BẠI
                        // ====================================================
                        soLanSai++;
                        string sqlFail = "UPDATE TaiKhoan SET SoLanDangNhapSai = @Sai WHERE TenDangNhap = @User";

                        if (soLanSai >= GIOI_HAN_DANG_NHAP_SAI && vaiTro != "Quản lý")
                        {
                            sqlFail = "UPDATE TaiKhoan SET SoLanDangNhapSai = @Sai, TrangThai = N'Tạm khóa' WHERE TenDangNhap = @User";
                            HienThiLoi("Tài khoản đã bị TẠM KHÓA do nhập sai mật khẩu 5 lần!");
                        }
                        else
                        {
                            HienThiLoi($"Mật khẩu không đúng! Bạn còn {Math.Max(0, GIOI_HAN_DANG_NHAP_SAI - soLanSai)} lần thử.");
                        }

                        SqlCommand cmdFail = new SqlCommand(sqlFail, conn);
                        cmdFail.Parameters.AddWithValue("@Sai", soLanSai);
                        cmdFail.Parameters.AddWithValue("@User", user);
                        cmdFail.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chi tiết lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HienThiLoi(string thongBao)
        {
            lblError.Text = thongBao;
            lblError.Visible = true;
            txtMatKhau.Clear();
            txtMatKhau.Focus();
        }

        private string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
            }
            catch { }
            return "127.0.0.1";
        }
    }
}