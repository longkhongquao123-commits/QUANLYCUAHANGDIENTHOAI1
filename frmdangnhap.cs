using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WindowsFormsQuanLyDienThoai12
{
    public partial class Form1 : Form
    {
        // Sai quá số lần này thì khóa tài khoản
        private const int SoLanSaiToiDa = 3;

        private const string ChuoiKetNoi =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;" +
            "Integrated Security=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (tenDN == "" || matKhau == "")
            {
                Thong("Vui lòng nhập tài khoản và mật khẩu!", MessageBoxIcon.Warning);
                if (tenDN == "") txtTaiKhoan.Focus(); else txtMatKhau.Focus();
                return;
            }

            bool thanhCong = false;
            btnDangNhap.Enabled = false;
            try
            {
                thanhCong = KiemTraDangNhap(tenDN, matKhau);
            }
            catch (SqlException ex)
            {
                Thong("Lỗi cơ sở dữ liệu: " + ex.Message, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Thong("Lỗi: " + ex.Message, MessageBoxIcon.Error);
            }
            finally
            {
                btnDangNhap.Enabled = true;
            }

            if (thanhCong)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // Cầu nối cho Form1.Designer.cs (đang gắn sự kiện theo tên _1)
        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            btnDangNhap_Click(sender, e);
        }

        // Cầu nối cho Form1.Designer.cs (đang gắn sự kiện theo tên _1)
        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            btnHuy_Click(sender, e);
        }

        private bool KiemTraDangNhap(string tenDN, string matKhau)
        {
            using (SqlConnection conn = new SqlConnection(ChuoiKetNoi))
            {
                conn.Open();

                string hash = "", trangThaiTK = "", trangThaiNV = "";
                string maNV = "", hoTen = "", vaiTro = "";
                int soLanSai = 0;

                const string sqlTK = @"
                    SELECT tk.MatKhauHash,
                           ISNULL(tk.SoLanDangNhapSai, 0) AS SoLanSai,
                           tk.TrangThai AS TrangThaiTK,
                           nv.TrangThai AS TrangThaiNV,
                           nv.MaNV, nv.HoTen, nv.VaiTro
                    FROM TaiKhoan tk
                    INNER JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                    WHERE tk.TenDangNhap = @TenDN";

                using (SqlCommand cmd = new SqlCommand(sqlTK, conn))
                {
                    cmd.Parameters.AddWithValue("@TenDN", tenDN);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.Read())
                        {
                            Thong("Tên đăng nhập hoặc mật khẩu không đúng!", MessageBoxIcon.Warning);
                            return false;
                        }

                        hash = dr["MatKhauHash"].ToString();
                        soLanSai = Convert.ToInt32(dr["SoLanSai"]);
                        trangThaiTK = dr["TrangThaiTK"].ToString();
                        trangThaiNV = dr["TrangThaiNV"].ToString();
                        maNV = dr["MaNV"].ToString();
                        hoTen = dr["HoTen"].ToString();
                        vaiTro = dr["VaiTro"].ToString();
                    }
                }

                if (trangThaiNV == "Nghỉ việc")
                {
                    Thong("Nhân viên đã nghỉ việc, không thể đăng nhập!", MessageBoxIcon.Warning);
                    return false;
                }

                if (trangThaiTK == "Tạm khóa")
                {
                    Thong("Tài khoản đã bị khóa do nhập sai quá " + SoLanSaiToiDa +
                          " lần. Vui lòng liên hệ quản lý!", MessageBoxIcon.Warning);
                    return false;
                }

                // Đúng mật khẩu: cho đăng nhập
                if (KiemTraMatKhau(conn, tenDN, matKhau, hash))
                {
                    return DangNhapThanhCong(conn, tenDN, maNV, hoTen, vaiTro);
                }

                // Sai mật khẩu: tăng số lần sai
                soLanSai++;
                CapNhatSoLanSai(conn, tenDN, soLanSai);
                string ip = LayDiaChiIP();

                if (soLanSai >= SoLanSaiToiDa)
                {
                    bool daKhoa = KhoaTaiKhoan(conn, tenDN);
                    GhiNhatKy(conn, tenDN, "Khóa tài khoản", "Hệ thống",
                              $"Sai mật khẩu {soLanSai} lần liên tiếp. IP: {ip}");

                    if (daKhoa)
                    {
                        Thong("Bạn đã nhập sai " + SoLanSaiToiDa + " lần. Tài khoản đã bị khóa!",
                              MessageBoxIcon.Error);
                    }
                    else
                    {
                        Thong("Bạn đã nhập sai " + SoLanSaiToiDa + " lần. Không khóa được tài khoản này " +
                              "vì đây là quản lý hoạt động cuối cùng (ràng buộc CSDL).",
                              MessageBoxIcon.Error);
                    }
                }
                else
                {
                    GhiNhatKy(conn, tenDN, "Đăng nhập thất bại", "Hệ thống", $"Sai mật khẩu. IP: {ip}");
                    Thong($"Tên đăng nhập hoặc mật khẩu không đúng! Bạn còn {SoLanSaiToiDa - soLanSai} lần thử.",
                          MessageBoxIcon.Warning);
                }

                return false;
            }
        }

        private bool KiemTraMatKhau(SqlConnection conn, string tenDN, string matKhau, string hash)
        {
            if (string.IsNullOrEmpty(hash))
                return false;

            // Hash BCrypt luôn bắt đầu bằng "$2"
            if (hash.StartsWith("$2"))
            {
                try
                {
                    return BCrypt.Net.BCrypt.Verify(matKhau, hash);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            // Dữ liệu mẫu đang lưu mật khẩu dạng chữ thường: so sánh trực tiếp,
            // đúng thì nâng cấp sang BCrypt để lần sau không lưu thô nữa
            if (matKhau == hash)
            {
                string hashMoi = BCrypt.Net.BCrypt.HashPassword(matKhau);
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE TaiKhoan SET MatKhauHash = @Hash WHERE TenDangNhap = @TenDN", conn))
                {
                    cmd.Parameters.AddWithValue("@Hash", hashMoi);
                    cmd.Parameters.AddWithValue("@TenDN", tenDN);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }

            return false;
        }

        private bool DangNhapThanhCong(SqlConnection conn, string tenDN, string maNV, string hoTen, string vaiTro)
        {
            // Reset số lần sai và ghi lần đăng nhập cuối
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE TaiKhoan SET SoLanDangNhapSai = 0, LanDangNhapCuoiCung = GETDATE() WHERE TenDangNhap = @TenDN", conn))
            {
                cmd.Parameters.AddWithValue("@TenDN", tenDN);
                cmd.ExecuteNonQuery();
            }

            string maPhien = Guid.NewGuid().ToString();
            string ip = LayDiaChiIP();

            GhiPhien(conn, tenDN, maPhien, ip);
            GhiNhatKy(conn, tenDN, "Đăng nhập", "Hệ thống", $"Đăng nhập thành công. IP: {ip}");

            Session.Luu(tenDN, maNV, hoTen, vaiTro, maPhien);
            return true;
        }

        private void CapNhatSoLanSai(SqlConnection conn, string tenDN, int soLan)
        {
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE TaiKhoan SET SoLanDangNhapSai = @SoLan WHERE TenDangNhap = @TenDN", conn))
            {
                cmd.Parameters.AddWithValue("@SoLan", soLan);
                cmd.Parameters.AddWithValue("@TenDN", tenDN);
                cmd.ExecuteNonQuery();
            }
        }

        // Trả về false nếu CSDL chặn việc khóa (ví dụ trigger không cho khóa quản lý cuối cùng)
        private bool KhoaTaiKhoan(SqlConnection conn, string tenDN)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE TaiKhoan SET TrangThai = N'Tạm khóa' WHERE TenDangNhap = @TenDN", conn))
                {
                    cmd.Parameters.AddWithValue("@TenDN", tenDN);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        // Nếu bảng PhienDangNhap không ghi được thì bỏ qua, đăng nhập vẫn thành công
        private void GhiPhien(SqlConnection conn, string tenDN, string maPhien, string ip)
        {
            try
            {
                const string sql = @"
                    INSERT INTO PhienDangNhap (MaPhien, TenDangNhap, GioDangNhap, GioHetHieuLuc, DiaChiIP, TrangThaiPhien)
                    VALUES (@MaPhien, @TenDN, GETDATE(), DATEADD(HOUR, 8, GETDATE()), @IP, N'Đang hoạt động')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhien", maPhien);
                    cmd.Parameters.AddWithValue("@TenDN", tenDN);
                    cmd.Parameters.AddWithValue("@IP", ip);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                // Bỏ qua: không làm hỏng quá trình đăng nhập
            }
        }

        // Ghi nhật ký qua stored procedure sp_GhiNhatKy có sẵn trong CSDL
        private void GhiNhatKy(SqlConnection conn, string tenDN, string loaiHanhDong, string doiTuong, string moTa)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_GhiNhatKy", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDN);
                    cmd.Parameters.AddWithValue("@LoaiHanhDong", loaiHanhDong);
                    cmd.Parameters.AddWithValue("@DoiTuong", doiTuong);
                    cmd.Parameters.AddWithValue("@MoTaChiTiet", moTa);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                // Bỏ qua lỗi ghi nhật ký
            }
        }

        private static string LayDiaChiIP()
        {
            foreach (IPAddress ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }

        private void Thong(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(this, noiDung, "Đăng nhập", MessageBoxButtons.OK, icon);
        }
    }

    public static class Session
    {
        public static string TenDangNhap { get; private set; }
        public static string MaNV { get; private set; }
        public static string HoTen { get; private set; }
        public static string VaiTro { get; private set; }
        public static string MaPhien { get; private set; }

        public static void Luu(string tenDN, string maNV, string hoTen, string vaiTro, string maPhien)
        {
            TenDangNhap = tenDN;
            MaNV = maNV;
            HoTen = hoTen;
            VaiTro = vaiTro;
            MaPhien = maPhien;
        }

        public static void DangXuat()
        {
            TenDangNhap = null;
            MaNV = null;
            HoTen = null;
            VaiTro = null;
            MaPhien = null;
        }
    }
}