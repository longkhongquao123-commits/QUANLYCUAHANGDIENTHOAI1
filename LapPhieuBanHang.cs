using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quanlybanhang
{
    public partial class LapPhieuBanHang : Form
    {
        // SỬA cho đúng máy của bạn (chạy SELECT @@SERVERNAME; trong SSMS để lấy)
        private readonly string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True";

        // SỬA cho đúng giá trị thật trong SQL (chạy SELECT DISTINCT TrangThai FROM SanPham; để xem)
        private const string TT_SP_KINH_DOANH = "Đang kinh doanh";
        private const string TT_IMEI_CHUA_BAN = "Chưa bán";

        // Nhân viên lập phiếu (tạm cố định; lấy từ phiếu mẫu PX001)
        private const string MA_NV_MAC_DINH = "NV02";

        private bool spCoIMEI = false;   // sản phẩm đang chọn có quản lý IMEI không
        private readonly CultureInfo vn = new CultureInfo("vi-VN");

        public LapPhieuBanHang()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Nối sự kiện bằng code (gỡ trước rồi nối lại để chắc chắn chỉ chạy 1 lần,
            // dù trong Designer bạn đã nối hay chưa)
            cboSanPham.SelectedIndexChanged -= cboSanPham_SelectedIndexChanged;
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;
            cboKhachHang.SelectedIndexChanged -= cboKhachHang_SelectedIndexChanged;
            cboKhachHang.SelectedIndexChanged += cboKhachHang_SelectedIndexChanged;
            dgvChiTiet.CellClick -= dgvChiTiet_CellClick;
            dgvChiTiet.CellClick += dgvChiTiet_CellClick;

            // Phiếu mới: truyền mã rỗng -> bảng TRỐNG nhưng vẫn đủ cột
            LoadChiTietPhieu("");

            NapComboBox(cboKhachHang, "SELECT MaKH, HoTen FROM KhachHang", "HoTen", "MaKH");
            NapDanhSachSanPham();

            cboPhuongThucThanhToan.Items.Clear();
            cboPhuongThucThanhToan.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản" });

            // Giá trị ban đầu của khu nhập
            nudSoLuong.Minimum = 1;
            nudSoLuong.Maximum = 1000;
            nudSoLuong.Value = 1;
            txtGiamGia.Text = "0";
            cboIMEI.Enabled = false;

            CapNhatTong();
        }

        // Nạp danh sách sản phẩm (gọi lại sau khi thanh toán để tồn kho được cập nhật)
        private void NapDanhSachSanPham()
        {
            NapComboBox(cboSanPham,
                "SELECT MaSP, TenSP, GiaBanHienTai, SoLuongTon, TrangThai FROM SanPham",
                "TenSP", "MaSP");
        }

        // Đổ chi tiết của MỘT phiếu vào bảng dgvChiTiet
        private void LoadChiTietPhieu(string maPX)
        {
            string sql = @"
                SELECT ROW_NUMBER() OVER (ORDER BY ct.MaSP) AS STT,
                       ct.MaSP,
                       sp.TenSP,
                       ISNULL(STUFF((SELECT ', ' + i.IMEI
                                     FROM ChiTietXuat_IMEI i
                                     WHERE i.MaPX = ct.MaPX AND i.MaSP = ct.MaSP
                                     FOR XML PATH('')), 1, 2, ''), '') AS IMEI,
                       ct.SoLuong,
                       ct.DonGia,
                       ct.GiamGia,
                       ct.ThanhTien
                FROM ChiTietPhieuXuat ct
                INNER JOIN SanPham sp ON sp.MaSP = ct.MaSP
                WHERE ct.MaPX = @MaPX
                ORDER BY ct.MaSP";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@MaPX", maPX);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvChiTiet.AutoGenerateColumns = false;   // chỉ hiện các cột bạn đã tạo
                    dgvChiTiet.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Nạp một ComboBox từ SQL: hiển thị tên, giữ mã phía sau
        private void NapComboBox(ComboBox cbo, string sql, string hienThi, string giaTri)
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, connectionString))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cbo.DataSource = dt;
                    cbo.DisplayMember = hienThi;
                    cbo.ValueMember = giaTri;
                    cbo.SelectedIndex = -1;          // ban đầu chưa chọn gì
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách: " + ex.Message);
            }
        }

        // Chọn khách hàng -> tự hiện Mã khách hàng và Mã phiếu xuất (dự kiến)
        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView kh = cboKhachHang.SelectedItem as DataRowView;
            if (kh == null)
            {
                // Chưa chọn khách (hoặc vừa xóa phiếu / thanh toán xong) -> xóa trắng 2 ô
                txtMaKhachHang.Text = "";
                txtMaPhieuXuat.Text = "";
                return;
            }

            txtMaKhachHang.Text = kh["MaKH"].ToString();
            txtMaPhieuXuat.Text = LayMaPXDuKien();
        }

        // Mã phiếu tiếp theo = PX + (số lớn nhất hiện có + 1), ví dụ PX010
        private string LayMaPXDuKien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ISNULL(MAX(TRY_CAST(SUBSTRING(MaPX, 3, 10) AS INT)), 0) + 1 FROM PhieuXuat", conn))
                {
                    conn.Open();
                    int so = Convert.ToInt32(cmd.ExecuteScalar());
                    return "PX" + so.ToString("000");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sinh mã phiếu: " + ex.Message);
                return "";
            }
        }

        // Chọn sản phẩm -> nạp IMEI chưa bán và TỰ ĐIỀN IMEI đầu tiên vào ô IMEI
        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboIMEI.Items.Clear();
            cboIMEI.Text = "";
            spCoIMEI = false;

            DataRowView sp = cboSanPham.SelectedItem as DataRowView;
            if (sp == null)
            {
                cboIMEI.Enabled = false;
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT IMEI, TrangThai FROM ThietBiIMEI WHERE MaSP = @ma ORDER BY IMEI", conn))
                {
                    cmd.Parameters.AddWithValue("@ma", sp["MaSP"].ToString());
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            spCoIMEI = true;                          // có IMEI trong CSDL => là thiết bị
                            if (rd["TrangThai"].ToString().Trim() == TT_IMEI_CHUA_BAN)
                                cboIMEI.Items.Add(rd["IMEI"].ToString().Trim());   // chỉ IMEI chưa bán
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp IMEI: " + ex.Message);
            }

            if (!spCoIMEI)
            {
                // Không có dòng IMEI nào của sản phẩm này trong SQL -> coi là phụ kiện
                cboIMEI.Enabled = false;
                cboIMEI.Text = "Không có IMEI trong SQL";
            }
            else if (cboIMEI.Items.Count == 0)
            {
                // Là thiết bị nhưng đã bán hết
                cboIMEI.Enabled = false;
                cboIMEI.Text = "Hết IMEI chưa bán";
            }
            else
            {
                cboIMEI.Enabled = true;
                cboIMEI.SelectedIndex = 0;     // TỰ ĐIỀN IMEI chưa bán đầu tiên
            }
        }

        // ================= NÚT THÊM DÒNG =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable dtChiTiet = dgvChiTiet.DataSource as DataTable;
            if (dtChiTiet == null)
            {
                BaoLoi("Bảng chi tiết chưa sẵn sàng.", cboSanPham);
                return;
            }

            // 1. Đã chọn sản phẩm chưa?
            DataRowView sp = cboSanPham.SelectedItem as DataRowView;
            if (sp == null)
            {
                BaoLoi("Vui lòng chọn sản phẩm.", cboSanPham);
                return;
            }
            string maSP = sp["MaSP"].ToString();
            string tenSP = sp["TenSP"].ToString();
            decimal donGia = Convert.ToDecimal(sp["GiaBanHienTai"]);
            int soLuong = (int)nudSoLuong.Value;

            // 2. Kiểm tra trạng thái, IMEI / tồn kho
            string imei;
            if (!KiemTraSanPham(sp, soLuong, out imei)) return;

            // 3. Giảm giá
            decimal giamGia;
            if (!LayGiamGia(soLuong * donGia, out giamGia)) return;

            // 4. Sản phẩm đã có trong phiếu chưa? (mỗi sản phẩm chỉ một dòng)
            foreach (DataRow r in dtChiTiet.Rows)
            {
                if (r["MaSP"].ToString() == maSP)
                {
                    BaoLoi("Sản phẩm này đã có trong phiếu. Hãy dùng nút Sửa dòng.", cboSanPham);
                    return;
                }
            }

            // 5. Thêm dòng mới vào cuối bảng
            DataRow dong = dtChiTiet.NewRow();
            dong["STT"] = dtChiTiet.Rows.Count + 1;
            dong["MaSP"] = maSP;
            dong["TenSP"] = tenSP;
            dong["IMEI"] = imei;
            dong["SoLuong"] = soLuong;
            dong["DonGia"] = donGia;
            dong["GiamGia"] = giamGia;
            dong["ThanhTien"] = TinhThanhTien(soLuong, donGia, giamGia);
            dtChiTiet.Rows.Add(dong);

            dgvChiTiet.ClearSelection();
            dgvChiTiet.Rows[dtChiTiet.Rows.Count - 1].Selected = true;

            CapNhatTong();
            XoaTrangKhuNhap();
        }

        // ================= NÚT SỬA DÒNG =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable dtChiTiet = dgvChiTiet.DataSource as DataTable;
            if (dtChiTiet == null) return;

            // 1. Đã bấm chọn dòng chưa?
            if (dgvChiTiet.CurrentRow == null)
            {
                BaoLoi("Vui lòng bấm chọn dòng cần sửa trong bảng.", dgvChiTiet);
                return;
            }
            DataRowView dong = dgvChiTiet.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null)
            {
                BaoLoi("Vui lòng bấm chọn dòng cần sửa trong bảng.", dgvChiTiet);
                return;
            }

            // 2. Sản phẩm trong ô nhập phải trùng sản phẩm của dòng (không đổi sản phẩm khi sửa)
            DataRowView sp = cboSanPham.SelectedItem as DataRowView;
            if (sp == null)
            {
                BaoLoi("Vui lòng chọn sản phẩm.", cboSanPham);
                return;
            }
            if (sp["MaSP"].ToString() != dong["MaSP"].ToString())
            {
                BaoLoi("Không đổi sản phẩm khi sửa. Hãy xóa dòng rồi thêm sản phẩm mới.", cboSanPham);
                return;
            }

            decimal donGia = Convert.ToDecimal(dong["DonGia"]);   // giữ đơn giá của dòng
            int soLuong = (int)nudSoLuong.Value;

            // 3. Kiểm tra IMEI / tồn kho
            string imei;
            if (!KiemTraSanPham(sp, soLuong, out imei)) return;

            // 4. Giảm giá
            decimal giamGia;
            if (!LayGiamGia(soLuong * donGia, out giamGia)) return;

            // 5. Ghi vào dòng
            dong["IMEI"] = imei;
            dong["SoLuong"] = soLuong;
            dong["GiamGia"] = giamGia;
            dong["ThanhTien"] = TinhThanhTien(soLuong, donGia, giamGia);

            CapNhatTong();
            dgvChiTiet.Refresh();
            XoaTrangKhuNhap();
        }

        // ================= NÚT XÓA DÒNG =================
        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            DataTable dtChiTiet = dgvChiTiet.DataSource as DataTable;
            if (dtChiTiet == null) return;

            // 1. Đã chọn dòng nào chưa? (dòng trống có dấu * ở cuối bảng không tính)
            if (dgvChiTiet.CurrentRow == null)
            {
                BaoLoi("Vui lòng bấm chọn dòng cần xóa trong bảng.", dgvChiTiet);
                return;
            }
            DataRowView dong = dgvChiTiet.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null)
            {
                BaoLoi("Vui lòng bấm chọn dòng cần xóa trong bảng.", dgvChiTiet);
                return;
            }

            // 2. Hỏi lại cho chắc
            string tenSP = dong["TenSP"].ToString();
            DialogResult hoi = MessageBox.Show(
                "Bạn có chắc muốn xóa dòng \"" + tenSP + "\" khỏi phiếu?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            // 3. Xóa hẳn dòng khỏi bảng (dùng Remove, không dùng Delete để dòng biến mất ngay)
            dtChiTiet.Rows.Remove(dong.Row);

            // 4. Đánh lại STT cho liền mạch 1, 2, 3...
            int stt = 1;
            foreach (DataRow r in dtChiTiet.Rows)
            {
                r["STT"] = stt;
                stt++;
            }

            // 5. Cập nhật tổng tiền, làm mới bảng và xóa trắng khu nhập
            CapNhatTong();
            dgvChiTiet.Refresh();
            XoaTrangKhuNhap();
        }

        // ================= NÚT XÓA PHIẾU =================
        // Hủy phiếu đang lập: bỏ toàn bộ dòng trong bảng và đưa form về trạng thái trống
        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            DataTable dtChiTiet = dgvChiTiet.DataSource as DataTable;
            if (dtChiTiet == null) return;

            // 1. Phiếu chưa có gì thì không cần xóa
            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu hiện chưa có dòng nào để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Hỏi xác nhận (xóa rồi không lấy lại được)
            DialogResult hoi = MessageBox.Show(
                "Bạn có chắc muốn xóa toàn bộ phiếu đang lập (" + dtChiTiet.Rows.Count + " dòng)?",
                "Xác nhận xóa phiếu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            // 3. Xóa hết các dòng chi tiết
            dtChiTiet.Rows.Clear();

            // 4. Đưa các ô thông tin phiếu về trống (mã khách hàng, mã phiếu tự xóa theo)
            cboKhachHang.SelectedIndex = -1;
            cboPhuongThucThanhToan.SelectedIndex = -1;

            // 5. Xóa trắng khu nhập sản phẩm và tính lại tổng tiền (về 0)
            XoaTrangKhuNhap();
            CapNhatTong();
            dgvChiTiet.Refresh();
        }

        // ================= NÚT THANH TOÁN =================
        // Kiểm tra phiếu rồi mở Form2 để xác nhận và lưu vào SQL
        private void ThanhToanPhieu()
        {
            DataTable dt = dgvChiTiet.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                BaoLoi("Phiếu chưa có sản phẩm nào.", cboSanPham);
                return;
            }
            if (cboKhachHang.SelectedIndex < 0 || cboKhachHang.SelectedValue == null)
            {
                BaoLoi("Vui lòng chọn khách hàng.", cboKhachHang);
                return;
            }
            if (cboPhuongThucThanhToan.SelectedIndex < 0)
            {
                BaoLoi("Vui lòng chọn phương thức thanh toán.", cboPhuongThucThanhToan);
                return;
            }

            string maKH = cboKhachHang.SelectedValue.ToString();
            string tenKH = cboKhachHang.Text;

            using (ThanhToan f = new ThanhToan(connectionString, dt, maKH, tenKH,
                                       cboPhuongThucThanhToan.Text, MA_NV_MAC_DINH))
            {
                f.ShowDialog(this);

                if (f.HoanTat)
                {
                    // Đã lưu xong: làm trống form để lập phiếu mới
                    dt.Rows.Clear();
                    cboKhachHang.SelectedIndex = -1;       // mã khách hàng, mã phiếu tự xóa theo
                    cboPhuongThucThanhToan.SelectedIndex = -1;
                    NapDanhSachSanPham();      // nạp lại để tồn kho mới hiển thị đúng
                    XoaTrangKhuNhap();
                    CapNhatTong();
                    dgvChiTiet.Refresh();
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            ThanhToanPhieu();
        }

        // Bấm vào một dòng trong bảng -> đưa dữ liệu lên khu "Thông tin sản phẩm cần thêm"
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView dong = dgvChiTiet.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (dong == null) return;

            cboSanPham.SelectedValue = dong["MaSP"].ToString();   // sẽ tự nạp lại danh sách IMEI
            if (dong["IMEI"].ToString() != "")
                cboIMEI.Text = dong["IMEI"].ToString();            // đặt IMEI của dòng SAU khi chọn sản phẩm

            int sl = Convert.ToInt32(dong["SoLuong"]);
            if (sl < nudSoLuong.Minimum) sl = (int)nudSoLuong.Minimum;
            if (sl > nudSoLuong.Maximum) sl = (int)nudSoLuong.Maximum;
            nudSoLuong.Value = sl;

            txtGiamGia.Text = Convert.ToDecimal(dong["GiamGia"]).ToString("0", vn);
        }

        // ================= CÁC HÀM PHỤ =================
        private void BaoLoi(string noiDung, Control oCanFocus)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            oCanFocus.Focus();
        }

        // Kiểm tra sản phẩm còn kinh doanh, thiết bị thì IMEI hợp lệ, phụ kiện thì đủ tồn kho.
        // Trả về true nếu hợp lệ, imei là IMEI đang ở ô IMEI ("" nếu là phụ kiện)
        private bool KiemTraSanPham(DataRowView sp, int soLuong, out string imei)
        {
            imei = "";
            string maSP = sp["MaSP"].ToString();
            int tonKho = Convert.ToInt32(sp["SoLuongTon"]);

            if (sp["TrangThai"].ToString() != TT_SP_KINH_DOANH)
            {
                BaoLoi("Sản phẩm này không còn kinh doanh.", cboSanPham);
                return false;
            }

            if (spCoIMEI)
            {
                if (!cboIMEI.Enabled)
                {
                    BaoLoi("Thiết bị này đã hết IMEI chưa bán.", cboSanPham);
                    return false;
                }
                imei = cboIMEI.Text.Trim();
                if (imei == "")
                {
                    BaoLoi("Vui lòng chọn hoặc nhập IMEI cho thiết bị.", cboIMEI);
                    return false;
                }
                if (soLuong != 1)
                {
                    BaoLoi("Thiết bị có IMEI chỉ bán 1 chiếc trên mỗi dòng.", nudSoLuong);
                    return false;
                }
                if (!IMEIConBan(imei, maSP))
                {
                    BaoLoi("IMEI này không tồn tại, không thuộc sản phẩm đã chọn hoặc đã được bán.", cboIMEI);
                    return false;
                }
            }
            else if (soLuong > tonKho)
            {
                BaoLoi("Không đủ hàng. Tồn kho hiện có: " + tonKho + ".", nudSoLuong);
                return false;
            }
            return true;
        }

        // Đọc ô Giảm giá: để trống = 0, phải là số, không âm, không vượt tiền hàng của dòng
        private bool LayGiamGia(decimal tienHang, out decimal giamGia)
        {
            giamGia = 0;
            string ggText = txtGiamGia.Text.Trim();

            if (ggText != "" && !decimal.TryParse(ggText, NumberStyles.Number, vn, out giamGia))
            {
                BaoLoi("Giảm giá phải là số (ví dụ 500000).", txtGiamGia);
                return false;
            }
            if (giamGia < 0)
            {
                BaoLoi("Giảm giá không được âm.", txtGiamGia);
                return false;
            }
            if (giamGia > tienHang)
            {
                BaoLoi("Giảm giá không được lớn hơn tiền hàng của dòng.", txtGiamGia);
                return false;
            }
            return true;
        }

        // Kiểm tra lại IMEI ngay lúc bấm (phòng khi máy khác vừa bán / gõ sai IMEI)
        private bool IMEIConBan(string imei, string maSP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM ThietBiIMEI WHERE IMEI = @imei AND MaSP = @ma AND TrangThai = @tt", conn))
            {
                cmd.Parameters.AddWithValue("@imei", imei);
                cmd.Parameters.AddWithValue("@ma", maSP);
                cmd.Parameters.AddWithValue("@tt", TT_IMEI_CHUA_BAN);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Thành tiền của MỘT dòng = SL x Đơn giá - Giảm giá
        private decimal TinhThanhTien(int soLuong, decimal donGia, decimal giamGia)
        {
            return soLuong * donGia - giamGia;
        }

        // Tổng tiền = tổng THÀNH TIỀN các dòng (đã trừ giảm giá từng dòng, chưa cộng thuế)
        private void CapNhatTong()
        {
            DataTable dt = dgvChiTiet.DataSource as DataTable;
            if (dt == null) return;

            decimal tong = 0;
            foreach (DataRow r in dt.Rows)
                tong += Convert.ToDecimal(r["ThanhTien"]);
            txtTongTien.Text = tong.ToString("N0", vn);
        }

        // Xóa trắng khu vực nhập để làm thao tác tiếp theo
        private void XoaTrangKhuNhap()
        {
            cboSanPham.SelectedIndex = -1;     // tự xóa luôn IMEI qua sự kiện chọn sản phẩm
            cboIMEI.Text = "";
            nudSoLuong.Value = 1;
            txtGiamGia.Text = "0";
            cboSanPham.Focus();
        }

        // ===== Các hàm "cầu nối": nút trên giao diện đang nối vào các hàm tên này,
        // nên cho chúng gọi sang hàm thật ở trên =====
        private void btnThemDong_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void btnSuaDong_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void btnXoaDong_Click_1(object sender, EventArgs e)
        {
            btnXoaDong_Click(sender, e);
        }

        private void btnXoaPhieu_Click_1(object sender, EventArgs e)
        {
            btnXoaPhieu_Click(sender, e);
        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            ThanhToanPhieu();
        }
    }
}