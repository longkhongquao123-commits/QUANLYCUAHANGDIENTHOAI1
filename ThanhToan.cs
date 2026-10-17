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
    public partial class ThanhToan : Form
    {
        // SỬA cho đúng chữ trong SQL nếu khác
        private const string TT_HOAN_TAT = "Hoàn tất";
        private const string TT_CHO_DUYET = "Chờ duyệt";
        private const string TT_IMEI_CHUA_BAN = "Chưa bán";
        private const string TT_IMEI_DA_BAN = "Đã bán";

        // Giảm giá vượt 5% tổng tiền thì phiếu phải chờ quản lý duyệt (nhóm chốt thì đổi số này)
        private const decimal NGUONG_GIAM_GIA = 0.05m;

        private readonly CultureInfo vn = new CultureInfo("vi-VN");
        private readonly string connectionString;
        private readonly DataTable dtChiTiet;
        private readonly string maKH;
        private readonly string maNV;
        private readonly decimal tongTien;      // tổng (số lượng x đơn giá), trước giảm giá
        private readonly decimal tongGiamGia;
        private readonly decimal thanhToan;     // tongTien - tongGiamGia
        private string maPX = "";
        private bool daHoanTat = false;
        private Size kichThuocDayDu;            // kích thước form khi đã hiện hóa đơn

        // Form1 đọc thuộc tính này để biết có cần làm trống phiếu hay không
        public bool HoanTat { get { return daHoanTat; } }

        public ThanhToan(string connStr, DataTable chiTiet, string maKH, string tenKH,
                     string phuongThuc, string maNV)
        {
            InitializeComponent();

            this.connectionString = connStr;
            this.dtChiTiet = chiTiet;
            this.maKH = maKH;
            this.maNV = maNV;

            decimal tien = 0, giam = 0;
            foreach (DataRow r in chiTiet.Rows)
            {
                tien += Convert.ToInt32(r["SoLuong"]) * Convert.ToDecimal(r["DonGia"]);
                giam += Convert.ToDecimal(r["GiamGia"]);
            }
            tongTien = tien;
            tongGiamGia = giam;
            thanhToan = tien - giam;

            // Hiển thị thông tin lấy từ Form1
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    maPX = SinhMaPX(conn, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sinh mã phiếu: " + ex.Message);
            }
            txtPhieu.Text = maPX;
            txtKhachHang.Text = tenKH;
            txtCanThanhToan.Text = thanhToan.ToString("N0", vn) + " đ";

            if (cboPhuongThuc.Items.Count == 0)
                cboPhuongThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản" });
            cboPhuongThuc.SelectedItem = phuongThuc;
            if (cboPhuongThuc.SelectedIndex < 0) cboPhuongThuc.SelectedIndex = 0;

            btnIn.Enabled = false;

            // Nối sự kiện bằng code (gỡ trước rồi nối lại để không bị chạy 2 lần)
            cboPhuongThuc.SelectedIndexChanged -= cboPhuongThuc_SelectedIndexChanged;
            cboPhuongThuc.SelectedIndexChanged += cboPhuongThuc_SelectedIndexChanged;
            txtKhachDua.TextChanged -= txtKhachDua_TextChanged;
            txtKhachDua.TextChanged += txtKhachDua_TextChanged;
            btnXacNhan.Click -= btnXacNhan_Click;
            btnXacNhan.Click += btnXacNhan_Click;
            btnIn.Click -= btnIn_Click;
            btnIn.Click += btnIn_Click;
            btnDong.Click -= btnDong_Click;
            btnDong.Click += btnDong_Click;

            CapNhatGiaoDien();

            // Ẩn hóa đơn lúc đầu, thu hẹp form lại cho gọn
            kichThuocDayDu = this.ClientSize;
            pnlHoaDon.Visible = false;
            this.ClientSize = new Size(pnlHoaDon.Left, kichThuocDayDu.Height);
        }

        // Tiền mặt: hiện Khách đưa / Tiền thừa. Chuyển khoản: hiện ô tích "đã nhận đủ tiền"
        private void CapNhatGiaoDien()
        {
            bool chuyenKhoan = cboPhuongThuc.Text == "Chuyển khoản";

            chkDaNhanDu.Visible = chuyenKhoan;
            chkDaNhanDu.Checked = false;
            txtKhachDua.Enabled = !chuyenKhoan;

            if (chuyenKhoan)
                txtKhachDua.Text = thanhToan.ToString("N0", vn);   // khách chuyển đúng số tiền cần trả
            else
                txtKhachDua.Text = "";

            TinhTienThua();
        }

        private void cboPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatGiaoDien();
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            TinhTienThua();
        }

        // Tiền thừa = Khách đưa - Cần thanh toán (không âm)
        private void TinhTienThua()
        {
            decimal khach;
            if (!decimal.TryParse(txtKhachDua.Text.Trim(), NumberStyles.Number, vn, out khach))
                khach = 0;
            decimal thua = khach - thanhToan;
            if (thua < 0) thua = 0;
            txtTienThua.Text = thua.ToString("N0", vn);
        }

        // ================= NÚT XÁC NHẬN & HOÀN TẤT =================
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra theo phương thức thanh toán
            if (cboPhuongThuc.Text == "Chuyển khoản")
            {
                if (!chkDaNhanDu.Checked)
                {
                    MessageBox.Show("Vui lòng tích xác nhận đã nhận đủ tiền chuyển khoản.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                decimal khach;
                if (!decimal.TryParse(txtKhachDua.Text.Trim(), NumberStyles.Number, vn, out khach))
                {
                    MessageBox.Show("Vui lòng nhập số tiền khách đưa.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKhachDua.Focus();
                    return;
                }
                if (khach < thanhToan)
                {
                    MessageBox.Show("Khách đưa chưa đủ tiền. Còn thiếu "
                        + (thanhToan - khach).ToString("N0", vn) + " đ.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKhachDua.Focus();
                    return;
                }
            }

            // 2. Lưu vào SQL
            string trangThai;
            try
            {
                trangThai = LuuPhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lưu được phiếu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Thành công: khóa form, cho phép In nếu đã hoàn tất
            daHoanTat = true;
            txtPhieu.Text = maPX;
            cboPhuongThuc.Enabled = false;
            txtKhachDua.Enabled = false;
            chkDaNhanDu.Enabled = false;
            btnXacNhan.Enabled = false;
            btnIn.Enabled = (trangThai == TT_HOAN_TAT);

            if (trangThai == TT_HOAN_TAT)
                MessageBox.Show("Đã hoàn tất phiếu " + maPX + ".", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Phiếu " + maPX + " có giảm giá vượt ngưỡng nên đã được lưu "
                    + "với trạng thái \"" + TT_CHO_DUYET + "\", chờ quản lý duyệt.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Ghi PhieuXuat, ChiTietPhieuXuat, ChiTietXuat_IMEI và cập nhật ThietBiIMEI, SanPham
        // trong MỘT giao dịch: có lỗi ở bất kỳ bước nào thì hủy hết.
        // Trả về trạng thái phiếu đã lưu.
        private string LuuPhieu()
        {
            bool vuotNguong = tongTien > 0 && tongGiamGia > tongTien * NGUONG_GIAM_GIA;
            string trangThai = vuotNguong ? TT_CHO_DUYET : TT_HOAN_TAT;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Sinh lại mã phiếu ngay trong giao dịch để tránh trùng với máy khác
                        maPX = SinhMaPX(conn, tran);

                        ChayLenh(conn, tran,
                            @"INSERT INTO PhieuXuat
                                (MaPX, MaKH, MaNV, NgayXuat, PhuongThucThanhToan,
                                 TongTien, TongGiamGia, ThanhToan, TrangThai)
                              VALUES (@px, @kh, @nv, @ngay, @pt, @tong, @giam, @tt, @trang)",
                            "@px", maPX, "@kh", maKH, "@nv", maNV, "@ngay", DateTime.Today,
                            "@pt", cboPhuongThuc.Text, "@tong", tongTien, "@giam", tongGiamGia,
                            "@tt", thanhToan, "@trang", trangThai);

                        foreach (DataRow r in dtChiTiet.Rows)
                        {
                            string maSP = r["MaSP"].ToString();
                            string imei = r["IMEI"].ToString().Trim();
                            int sl = Convert.ToInt32(r["SoLuong"]);
                            decimal donGia = Convert.ToDecimal(r["DonGia"]);
                            decimal giamGia = Convert.ToDecimal(r["GiamGia"]);
                            decimal thanhTien = Convert.ToDecimal(r["ThanhTien"]);

                            // Dòng chi tiết (ThueSuat tạm = 0 cho đến khi nhóm chốt cách tính thuế)
                            ChayLenh(conn, tran,
                                @"INSERT INTO ChiTietPhieuXuat
                                    (MaPX, MaSP, SoLuong, DonGia, ThueSuat, GiamGia, ThanhTien)
                                  VALUES (@px, @sp, @sl, @dg, 0, @gg, @tt)",
                                "@px", maPX, "@sp", maSP, "@sl", sl, "@dg", donGia,
                                "@gg", giamGia, "@tt", thanhTien);

                            // IMEI của máy đã bán (chỉ thiết bị có IMEI)
                            if (imei != "")
                            {
                                ChayLenh(conn, tran,
                                    "INSERT INTO ChiTietXuat_IMEI (MaPX, MaSP, IMEI) VALUES (@px, @sp, @imei)",
                                    "@px", maPX, "@sp", maSP, "@imei", imei);
                            }

                            // Phiếu chờ duyệt thì CHƯA trừ kho / đổi trạng thái IMEI
                            if (!vuotNguong)
                            {
                                if (imei != "")
                                {
                                    int n = ChayLenh(conn, tran,
                                        @"UPDATE ThietBiIMEI SET TrangThai = @da
                                          WHERE IMEI = @imei AND MaSP = @sp AND TrangThai = @chua",
                                        "@da", TT_IMEI_DA_BAN, "@imei", imei, "@sp", maSP,
                                        "@chua", TT_IMEI_CHUA_BAN);
                                    if (n != 1)
                                        throw new Exception("IMEI " + imei + " không còn ở trạng thái chưa bán.");
                                }

                                int m = ChayLenh(conn, tran,
                                    @"UPDATE SanPham SET SoLuongTon = SoLuongTon - @sl
                                      WHERE MaSP = @sp AND SoLuongTon >= @sl",
                                    "@sl", sl, "@sp", maSP);
                                if (m != 1)
                                    throw new Exception("Sản phẩm " + maSP + " không đủ tồn kho.");
                            }
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
            return trangThai;
        }

        // Chạy một lệnh SQL; tham số truyền theo cặp: tên, giá trị. Trả về số dòng bị ảnh hưởng.
        private int ChayLenh(SqlConnection conn, SqlTransaction tran, string sql, params object[] thamSo)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                for (int i = 0; i < thamSo.Length; i += 2)
                    cmd.Parameters.AddWithValue((string)thamSo[i], thamSo[i + 1]);
                return cmd.ExecuteNonQuery();
            }
        }

        // Mã phiếu mới = PX + (số lớn nhất hiện có + 1), ví dụ PX006
        private string SinhMaPX(SqlConnection conn, SqlTransaction tran)
        {
            string sql = @"SELECT ISNULL(MAX(TRY_CAST(SUBSTRING(MaPX, 3, 10) AS INT)), 0) + 1
                           FROM PhieuXuat WITH (UPDLOCK, HOLDLOCK)";
            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                int so = Convert.ToInt32(cmd.ExecuteScalar());
                return "PX" + so.ToString("000");
            }
        }

        // ================= NÚT IN =================
        // Điền dữ liệu vào phần hóa đơn rồi hiện nó ra
        private void btnIn_Click(object sender, EventArgs e)
        {
            txtHDMaPhieu.Text = maPX;
            dtpHDNgay.Value = DateTime.Today;
            txtHDTenKhachHang.Text = txtKhachHang.Text;

            dgvHoaDon.Rows.Clear();
            foreach (DataRow r in dtChiTiet.Rows)
            {
                dgvHoaDon.Rows.Add(
                    r["TenSP"].ToString(),
                    Convert.ToInt32(r["SoLuong"]),
                    Convert.ToDecimal(r["DonGia"]).ToString("N0", vn),
                    Convert.ToDecimal(r["GiamGia"]).ToString("N0", vn),
                    Convert.ToDecimal(r["ThanhTien"]).ToString("N0", vn));
            }
            txtHDTongThanhToan.Text = thanhToan.ToString("N0", vn) + " đ";

            // Hiện hóa đơn và mở rộng form ra
            pnlHoaDon.Visible = true;
            this.ClientSize = kichThuocDayDu;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Giữ lại hàm này vì Designer có thể đang nối sự kiện vào nó
        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}