using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QUANLYCUAHANGDIENTHOAI
{
    public partial class FormPhieuNhap : Form
    {
        // Chuỗi kết nối dùng chung của nhóm
        private readonly string strKetNoi = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // Biến lưu trạng thái hành động trước khi bấm nút "Ghi dữ liệu": "" (đang xem), "THEM", hoặc "SUA"
        private string hanhDong = "";

        public FormPhieuNhap()
        {
            InitializeComponent();
            CaiDatGiaoDienLuoi();
        }

        private void CaiDatGiaoDienLuoi()
        {
            dgvChiTietNhap.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvChiTietNhap.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChiTietNhap.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvChiTietNhap.DefaultCellStyle.SelectionBackColor = Color.FromArgb(14, 165, 233);
            dgvChiTietNhap.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvChiTietNhap.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        }

        // =========================================================================
        // TIÊU CHÍ 2 (ĐỀ THI): KHI MỞ FORM -> CÀI ĐẶT TRẠNG THÁI BAN ĐẦU & LOAD DỮ LIỆU
        // =========================================================================
        private void FormPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadDanhMucCombobox();
            LoadTatCaChiTiet();
            DatTrangThaiXem();

            // Nếu lưới có dữ liệu -> mặc định chọn dòng đầu tiên và hiển thị lên các ô
            if (dgvChiTietNhap.Rows.Count > 0)
            {
                dgvChiTietNhap.CurrentCell = dgvChiTietNhap.Rows[0].Cells[0];
                HienThiDongDangChon(0);
            }
        }

        private void LoadDanhMucCombobox()
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                try
                {
                    conn.Open();

                    // 1. Nhà cung cấp (chỉ lấy NCC đang hợp tác)
                    SqlDataAdapter daNCC = new SqlDataAdapter("SELECT MaNCC, TenNCC FROM NhaCungCap WHERE TrangThai = N'Đang hợp tác'", conn);
                    DataTable dtNCC = new DataTable();
                    daNCC.Fill(dtNCC);
                    cboNhaCungCap.DataSource = dtNCC;
                    cboNhaCungCap.DisplayMember = "TenNCC";
                    cboNhaCungCap.ValueMember = "MaNCC";

                    // 2. Nhân viên
                    SqlDataAdapter daNV = new SqlDataAdapter("SELECT MaNV, HoTen FROM NhanVien WHERE TrangThai = N'Đang làm việc'", conn);
                    DataTable dtNV = new DataTable();
                    daNV.Fill(dtNV);
                    cboNhanVien.DataSource = dtNV;
                    cboNhanVien.DisplayMember = "HoTen";
                    cboNhanVien.ValueMember = "MaNV";

                    // 3. Sản phẩm (Đang kinh doanh)
                    SqlDataAdapter daSP = new SqlDataAdapter("SELECT MaSP, TenSP, GiaBanHienTai FROM SanPham WHERE TrangThai = N'Đang kinh doanh'", conn);
                    DataTable dtSP = new DataTable();
                    daSP.Fill(dtSP);
                    cboSanPham.DataSource = dtSP;
                    cboSanPham.DisplayMember = "TenSP";
                    cboSanPham.ValueMember = "MaSP";

                    // 4. Kết quả kiểm tra chất lượng (Mục 17)
                    cboKetQuaKiemTra.Items.Clear();
                    cboKetQuaKiemTra.Items.AddRange(new object[] { "Đạt yêu cầu", "Lỗi - Chờ trả" });
                    cboKetQuaKiemTra.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================================
        // HÀM KIỂM SOÁT TRẠNG THÁI NÚT BẤM & Ô NHẬP (ĐÚNG CHUẨN ĐỀ THI MỤC 2, 3, 5)
        // =========================================================================
        private void DatTrangThaiXem()
        {
            hanhDong = "";

            // Nút Thêm, Sửa, Xóa: Enable | Nút Ghi, Hủy bỏ: Disable
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;

            // Các ô nhập chi tiết đặt trạng thái Disable khi đang xem
            cboSanPham.Enabled = false;
            numSoLuong.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            cboKetQuaKiemTra.Enabled = false;
            txtGhiChu.Enabled = false;

            // Khung thông tin phiếu
            txtMaPN.Enabled = true;
            cboNhaCungCap.Enabled = false;
            cboNhanVien.Enabled = false;
            txtSoChungTu.Enabled = false;
            dtpNgayNhap.Enabled = false;
        }

        private void DatTrangThaiThemHoacSua(bool laThemMoi)
        {
            // Nút Thêm, Sửa, Xóa: Disable | Nút Ghi, Hủy bỏ: Enable
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnGhi.Enabled = true;
            btnHuy.Enabled = true;

            // Mở khóa các ô nhập liệu
            numSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            cboKetQuaKiemTra.Enabled = true;
            txtGhiChu.Enabled = true;

            // Nếu là Thêm mới thì cho phép chọn Sản phẩm & sửa thông tin Phiếu (nếu phiếu mới)
            // Nếu là Sửa thì KHÓA trường khóa chính (MaPN, MaSP) theo đúng Mục 5 đề thi
            cboSanPham.Enabled = laThemMoi;
            txtMaPN.Enabled = laThemMoi;
            cboNhaCungCap.Enabled = laThemMoi;
            cboNhanVien.Enabled = laThemMoi;
            txtSoChungTu.Enabled = laThemMoi;
            dtpNgayNhap.Enabled = laThemMoi;
        }

        // =========================================================================
        // TẢI TOÀN BỘ DỮ LIỆU LÊN BẢNG (KHÔNG BỊ MẤT BẢNG KHI ĐỔI MÃ PHIẾU)
        // =========================================================================
        private void LoadTatCaChiTiet(string tuKhoa = "", decimal? thanhTienToiThieu = null)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            ct.MaPN, 
                            ct.MaSP, 
                            sp.TenSP, 
                            ct.SoLuongNhap, 
                            ct.DonGiaNhap, 
                            ct.ThanhTien, 
                            ct.KetQuaKiemTra, 
                            ct.GhiChu
                        FROM ChiTietPhieuNhap ct
                        INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                        WHERE (@TuKhoa = '' OR sp.TenSP LIKE N'%' + @TuKhoa + '%' OR ct.MaPN LIKE '%' + @TuKhoa + '%')
                          AND (@ThanhTienMin IS NULL OR ct.ThanhTien >= @ThanhTienMin)
                        ORDER BY ct.MaPN DESC, ct.MaSP ASC";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);
                    cmd.Parameters.AddWithValue("@ThanhTienMin", (object)thanhTienToiThieu ?? DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvChiTietNhap.DataSource = dt;

                    // Định dạng tiền tệ và dãn cột để không bị che chữ
                    if (dgvChiTietNhap.Columns.Count > 0)
                    {
                        dgvChiTietNhap.Columns["Column4"].DefaultCellStyle.Format = "N0";
                        dgvChiTietNhap.Columns["Column5"].DefaultCellStyle.Format = "N0";
                        dgvChiTietNhap.Columns["Column3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvChiTietNhap.Columns["Column4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvChiTietNhap.Columns["Column5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvChiTietNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        dgvChiTietNhap.Columns["Column2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvChiTietNhap.Columns["Column7"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
                }
            }
        }

        // =========================================================================
        // CLICK CHỌN DÒNG TRÊN LƯỚI -> ĐẨY THÔNG TIN LÊN CÁC Ô & TÍNH TỔNG TIỀN PHIẾU
        // =========================================================================
       
        

        private void HienThiDongDangChon(int rowIndex)
        {
            
            if (rowIndex < 0 || rowIndex >= dgvChiTietNhap.Rows.Count) return;

            DataGridViewRow row = dgvChiTietNhap.Rows[rowIndex];
            if (row.Cells["MaPN"].Value == null || row.Cells["MaPN"].Value == DBNull.Value) return;

            string maPN = row.Cells["MaPN"].Value.ToString();
            txtMaPN.Text = maPN;

            // Cập nhật tiêu đề (tổng tiền, trạng thái) và thông tin chung của phiếu TRƯỚC
            TaiThongTinMasterPhieuNhap(maPN);

            // Đổ dữ liệu dòng mặt hàng lên các ô
            cboSanPham.SelectedValue = row.Cells["Column1"].Value.ToString();

            decimal soLuong = Convert.ToDecimal(row.Cells["Column3"].Value);
            numSoLuong.Value = Math.Min(numSoLuong.Maximum, Math.Max(numSoLuong.Minimum, soLuong));

            txtDonGiaNhap.Text = Convert.ToDecimal(row.Cells["Column4"].Value).ToString("N0");
            cboKetQuaKiemTra.Text = row.Cells["Column6"].Value?.ToString() ?? "";
            txtGhiChu.Text = row.Cells["Column7"].Value?.ToString() ?? "";
        }
        

        private void TaiThongTinMasterPhieuNhap(string maPN)
        {
            
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                SELECT pn.MaNCC, pn.MaNV, pn.NgayNhap, pn.SoChungTu, pn.TrangThai,
                       ISNULL((SELECT SUM(ThanhTien) FROM ChiTietPhieuNhap WHERE MaPN = pn.MaPN), 0) AS TongTienTinhToan
                FROM PhieuNhap pn
                WHERE pn.MaPN = @MaPN";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaPN", maPN);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return;

                        // 1. Tiêu đề: đặt trước để dù các ô bên dưới có lỗi thì tổng tiền vẫn đúng
                        decimal tongTien = Convert.ToDecimal(r["TongTienTinhToan"]);
                        lblTongTienPhieu.Text = $"Tổng tiền phiếu ({maPN}): {tongTien:N0} VNĐ";

                        string trangThai = r["TrangThai"].ToString();
                        lblNhap.Text = trangThai;
                        lblNhap.BackColor = (trangThai == "Hoàn tất")
                            ? Color.FromArgb(22, 163, 74)
                            : Color.FromArgb(245, 158, 11);

                        // 2. Các ô thông tin chung của phiếu
                        cboNhaCungCap.SelectedValue = r["MaNCC"].ToString();
                        cboNhanVien.SelectedValue = r["MaNV"].ToString();
                        if (!(r["NgayNhap"] is DBNull))
                            dtpNgayNhap.Value = Convert.ToDateTime(r["NgayNhap"]);
                        txtSoChungTu.Text = r["SoChungTu"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải thông tin phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        // Tự động tính Thành tiền = Số lượng * Đơn giá ngay khi người dùng gõ (Mục 2 & 10 đề thi)
        private void TinhThanhTienPreview(object sender, EventArgs e)
        {
            string giaRaw = txtDonGiaNhap.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(giaRaw, out decimal donGia) && donGia >= 0)
            {
                decimal thanhTien = numSoLuong.Value * donGia;
                lblThanhTienPreview.Text = $"Thành tiền: {thanhTien:N0} VNĐ";
            }
            else
            {
                lblThanhTienPreview.Text = "Thành tiền: 0 VNĐ";
            }
        }

        // Tiện ích: Nút tự sinh mã Phiếu Nhập mới (PN003, PN004...) để tạo phiếu nháp nhanh
        private void btnTaoPhieuMoi_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) + 1 FROM PhieuNhap", conn);
                int nextId = Convert.ToInt32(cmd.ExecuteScalar());
                string maMoi = "PN" + nextId.ToString("D3");

                txtMaPN.Text = maMoi;
                txtSoChungTu.Text = "HD_" + DateTime.Now.ToString("ddMMyy_HHmm");
                dtpNgayNhap.Value = DateTime.Now;
                lblNhap.Text = "Nháp";
                lblNhap.BackColor = Color.FromArgb(245, 158, 11);
                lblTongTienPhieu.Text = $"Tổng tiền phiếu ({maMoi}): 0 VNĐ";

                // Kích hoạt luôn chế độ Thêm dòng cho phiếu mới này
                btnThem.PerformClick();
                txtSoChungTu.Focus();
            }
        }

        // =========================================================================
        // TIÊU CHÍ 3 & 10 (ĐỀ THI): NÚT THÊM -> KHÓA NÚT, GÁN MẶC ĐỊNH, ĐẶT CON TRỎ CHUỘT
        // =========================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Nếu phiếu hiện tại trên ô txtMaPN đã "Hoàn tất", gợi ý người dùng tạo phiếu mới hoặc tự đổi sang phiếu nháp
            if (lblNhap.Text == "Hoàn tất")
            {
                DialogResult dr = MessageBox.Show(
                    $"Phiếu '{txtMaPN.Text}' đã Hoàn tất và bị khóa!\nBạn có muốn hệ thống tự động sinh một Mã Phiếu Nhập Nháp mới để thêm hàng không?",
                    "Tiện ích tạo phiếu mới", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    btnTaoPhieuMoi_Click(null, null);
                    return;
                }
                else return;
            }

            hanhDong = "THEM";
            DatTrangThaiThemHoacSua(true);

            // Trả các ô nhập về trạng thái mặc định hợp lý (Tiêu chí 3 & 10)
            if (cboSanPham.Items.Count > 0) cboSanPham.SelectedIndex = 0;
            numSoLuong.Value = 1;
            txtDonGiaNhap.Text = "1000000";
            cboKetQuaKiemTra.SelectedIndex = 0; // Mặc định: "Đạt yêu cầu"
            txtGhiChu.Text = "Hàng nguyên seal"; // Mặc định tiện ích

            // Đặt con trỏ chuột vào ô nhập đầu tiên
            cboSanPham.Focus();
        }

        // =========================================================================
        // TIÊU CHÍ 5 (ĐỀ THI): NÚT SỬA -> KHÓA NÚT, MỞ Ô NHẬP TRỪ KHÓA CHÍNH, FOCUS
        // =========================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng mặt hàng trên lưới để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblNhap.Text == "Hoàn tất")
            {
                MessageBox.Show("Phiếu nhập này đã Hoàn tất! Không thể sửa đổi dữ liệu.", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            hanhDong = "SUA";
            DatTrangThaiThemHoacSua(false); // false = khóa trường khóa (MaPN, MaSP)

            // Đặt con trỏ chuột vào ô dữ liệu nhập đầu tiên được phép sửa
            numSoLuong.Focus();
        }

        // =========================================================================
        // TIÊU CHÍ 4 & 6 & 9 (ĐỀ THI): NÚT GHI DỮ LIỆU (KIỂM TRA RỖNG, ĐỊNH DẠNG, GHI/CẬP NHẬT)
        // =========================================================================
        private void btnGhi_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra các trường bắt buộc phải nhập (Tiêu chí 9: thông báo cụ thể từng trường)
            string maPN = txtMaPN.Text.Trim();
            if (string.IsNullOrEmpty(maPN))
            {
                MessageBox.Show("Không được để trống [Mã phiếu nhập]!", "Cảnh báo thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPN.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoChungTu.Text))
            {
                MessageBox.Show("Không được để trống [Số chứng từ] hóa đơn gốc!", "Cảnh báo thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoChungTu.Focus();
                return;
            }

            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn [Sản phẩm] cần nhập!", "Cảnh báo thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSanPham.Focus();
                return;
            }

            // 2. Kiểm tra định dạng dữ liệu số (Đơn giá nhập > 0)
            string giaRaw = txtDonGiaNhap.Text.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(giaRaw, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("[Đơn giá nhập] không đúng định dạng số hoặc nhỏ hơn/bằng 0!\nVui lòng nhập số tiền hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDonGiaNhap.Focus();
                return;
            }

            int soLuong = (int)numSoLuong.Value;
            decimal thanhTien = soLuong * donGia;
            string maSP = cboSanPham.SelectedValue.ToString();
            string ketQuaKT = cboKetQuaKiemTra.Text;
            string ghiChu = txtGhiChu.Text.Trim();

            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                try
                {
                    conn.Open();

                    // Nếu là hành động THÊM MỚI
                    if (hanhDong == "THEM")
                    {
                        // BƯỚC A: Kiểm tra xem Mã Phiếu Nhập đã có trong bảng PhieuNhap chưa. Nếu chưa có -> Tự động tạo Phiếu Nháp (Mục 16)
                        SqlCommand cmdCheckPN = new SqlCommand("SELECT COUNT(*) FROM PhieuNhap WHERE MaPN = @MaPN", conn);
                        cmdCheckPN.Parameters.AddWithValue("@MaPN", maPN);
                        int tonTaiPN = Convert.ToInt32(cmdCheckPN.ExecuteScalar());

                        if (tonTaiPN == 0)
                        {
                            string sqlInsertMaster = @"
                                INSERT INTO PhieuNhap (MaPN, MaNCC, MaNV, NgayNhap, SoChungTu, TongTienNhap, TrangThai)
                                VALUES (@MaPN, @MaNCC, @MaNV, @NgayNhap, @SoChungTu, 0, N'Nháp')";
                            SqlCommand cmdMaster = new SqlCommand(sqlInsertMaster, conn);
                            cmdMaster.Parameters.AddWithValue("@MaPN", maPN);
                            cmdMaster.Parameters.AddWithValue("@MaNCC", cboNhaCungCap.SelectedValue.ToString());
                            cmdMaster.Parameters.AddWithValue("@MaNV", cboNhanVien.SelectedValue.ToString());
                            cmdMaster.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                            cmdMaster.Parameters.AddWithValue("@SoChungTu", txtSoChungTu.Text.Trim());
                            cmdMaster.ExecuteNonQuery();
                        }

                        // BƯỚC B: Kiểm tra xem Sản phẩm này đã có trong Phiếu Nhập này chưa (Tránh trùng khóa chính MaPN + MaSP)
                        SqlCommand cmdCheckSP = new SqlCommand("SELECT COUNT(*) FROM ChiTietPhieuNhap WHERE MaPN = @MaPN AND MaSP = @MaSP", conn);
                        cmdCheckSP.Parameters.AddWithValue("@MaPN", maPN);
                        cmdCheckSP.Parameters.AddWithValue("@MaSP", maSP);
                        if (Convert.ToInt32(cmdCheckSP.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show($"Sản phẩm [{cboSanPham.Text}] đã có trong phiếu [{maPN}]!\nVui lòng chọn dòng đó và ấn 'Sửa dòng' để cập nhật số lượng.", "Trùng sản phẩm trong phiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // BƯỚC C: Thêm dòng chi tiết mới
                        string sqlInsertDetail = @"
                            INSERT INTO ChiTietPhieuNhap (MaPN, MaSP, SoLuongNhap, DonGiaNhap, ThanhTien, KetQuaKiemTra, GhiChu)
                            VALUES (@MaPN, @MaSP, @SL, @Gia, @ThanhTien, @KetQua, @GhiChu)";
                        SqlCommand cmdDetail = new SqlCommand(sqlInsertDetail, conn);
                        cmdDetail.Parameters.AddWithValue("@MaPN", maPN);
                        cmdDetail.Parameters.AddWithValue("@MaSP", maSP);
                        cmdDetail.Parameters.AddWithValue("@SL", soLuong);
                        cmdDetail.Parameters.AddWithValue("@Gia", donGia);
                        cmdDetail.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        cmdDetail.Parameters.AddWithValue("@KetQua", ketQuaKT);
                        cmdDetail.Parameters.AddWithValue("@GhiChu", ghiChu);
                        cmdDetail.ExecuteNonQuery();

                        MessageBox.Show("Thêm mặt hàng vào phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    // Nếu là hành động CẬP NHẬT (SỬA)
                    else if (hanhDong == "SUA")
                    {
                        string sqlUpdateDetail = @"
                            UPDATE ChiTietPhieuNhap
                            SET SoLuongNhap = @SL, DonGiaNhap = @Gia, ThanhTien = @ThanhTien, KetQuaKiemTra = @KetQua, GhiChu = @GhiChu
                            WHERE MaPN = @MaPN AND MaSP = @MaSP";
                        SqlCommand cmdUpdate = new SqlCommand(sqlUpdateDetail, conn);
                        cmdUpdate.Parameters.AddWithValue("@SL", soLuong);
                        cmdUpdate.Parameters.AddWithValue("@Gia", donGia);
                        cmdUpdate.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        cmdUpdate.Parameters.AddWithValue("@KetQua", ketQuaKT);
                        cmdUpdate.Parameters.AddWithValue("@GhiChu", ghiChu);
                        cmdUpdate.Parameters.AddWithValue("@MaPN", maPN);
                        cmdUpdate.Parameters.AddWithValue("@MaSP", maSP);
                        cmdUpdate.ExecuteNonQuery();

                        MessageBox.Show("Cập nhật thông tin dòng mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Cập nhật lại Tổng tiền của Phiếu Nhập
                    SqlCommand cmdUpdateTotal = new SqlCommand("UPDATE PhieuNhap SET TongTienNhap = ISNULL((SELECT SUM(ThanhTien) FROM ChiTietPhieuNhap WHERE MaPN = @MaPN), 0) WHERE MaPN = @MaPN", conn);
                    cmdUpdateTotal.Parameters.AddWithValue("@MaPN", maPN);
                    cmdUpdateTotal.ExecuteNonQuery();

                    // Đưa về trạng thái Xem và tải lại lưới
                    DatTrangThaiXem();
                    LoadTatCaChiTiet();
                    TaiThongTinMasterPhieuNhap(maPN);
                }
                catch (SqlException sqlEx)
                {
                    // Bắt lỗi trùng Số chứng từ (UQ_PhieuNhap_SoChungTu) ở Mục 16
                    if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                        MessageBox.Show("Số chứng từ này đã tồn tại ở một phiếu nhập khác! Vui lòng kiểm tra lại.", "Lỗi trùng Số chứng từ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Lỗi cơ sở dữ liệu: " + sqlEx.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống khi ghi dữ liệu: " + ex.Message, "Lỗi ngoại lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================================
        // NÚT HỦY BỎ: TRẢ VỀ TRẠNG THÁI XEM & HIỂN THỊ LẠI DÒNG ĐANG CHỌN
        // =========================================================================
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DatTrangThaiXem();
            if (dgvChiTietNhap.CurrentRow != null)
            {
                HienThiDongDangChon(dgvChiTietNhap.CurrentRow.Index);
            }
        }

        // =========================================================================
        // TIÊU CHÍ 7 (ĐỀ THI): NÚT XÓA -> XÓA DỮ LIỆU, BÁO THÀNH CÔNG & TẢI LẠI LƯỚI
        // =========================================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng mặt hàng trên lưới để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblNhap.Text == "Hoàn tất")
            {
                MessageBox.Show("Phiếu nhập này đã Hoàn tất! Không được phép xóa mặt hàng.", "Từ chối xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string maPN = txtMaPN.Text.Trim();
            string maSP = cboSanPham.SelectedValue.ToString();

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm [{cboSanPham.Text}] khỏi phiếu [{maPN}] không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(strKetNoi))
                {
                    try
                    {
                        conn.Open();
                        // Xóa các IMEI nháp đã quét của mặt hàng này (nếu có) trước khi xóa dòng chi tiết
                        SqlCommand cmdDelIMEI = new SqlCommand("DELETE FROM ThietBiIMEI WHERE MaPN = @MaPN AND MaSP = @MaSP", conn);
                        cmdDelIMEI.Parameters.AddWithValue("@MaPN", maPN);
                        cmdDelIMEI.Parameters.AddWithValue("@MaSP", maSP);
                        cmdDelIMEI.ExecuteNonQuery();

                        // Xóa dòng chi tiết
                        SqlCommand cmdDel = new SqlCommand("DELETE FROM ChiTietPhieuNhap WHERE MaPN = @MaPN AND MaSP = @MaSP", conn);
                        cmdDel.Parameters.AddWithValue("@MaPN", maPN);
                        cmdDel.Parameters.AddWithValue("@MaSP", maSP);
                        int kq = cmdDel.ExecuteNonQuery();

                        if (kq > 0)
                        {
                            MessageBox.Show("Xóa dòng mặt hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadTatCaChiTiet();
                            TaiThongTinMasterPhieuNhap(maPN);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu để xóa!", "Lỗi xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Báo lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =========================================================================
        // TIÊU CHÍ 8 (ĐỀ THI): TÌM KIẾM THEO TÊN SP / MÃ PN HOẶC SO SÁNH THÀNH TIỀN
        // =========================================================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemTen.Text.Trim();
            decimal? tienMin = null;

            if (!string.IsNullOrWhiteSpace(txtTimThanhTien.Text))
            {
                string tienRaw = txtTimThanhTien.Text.Replace(",", "").Replace(".", "").Trim();
                if (decimal.TryParse(tienRaw, out decimal val))
                {
                    tienMin = val;
                }
                else
                {
                    MessageBox.Show("Mức Thành tiền tìm kiếm phải là một số hợp lệ!", "Lỗi định dạng tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTimThanhTien.Focus();
                    return;
                }
            }

            LoadTatCaChiTiet(tuKhoa, tienMin);
        }

        private void btnLamMoiTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiemTen.Clear();
            txtTimThanhTien.Clear();
            LoadTatCaChiTiet();
        }

        // =========================================================================
        // KẾT NỐI SANG FORM QUẢN LÝ IMEI (MỤC 16)
        // =========================================================================
        private void btnNhapIMEI_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn dòng nào trên bảng chưa
            if (dgvChiTietNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 mặt hàng trên bảng trước khi nhập IMEI!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Lấy 3 thông tin từ dòng đang chọn trên DataGridView
            // (Lưu ý: "Column1" và "Column3" là tên cột Mã SP và Số lượng trong bảng của bạn, hãy sửa lại cho khớp nếu bạn đặt tên khác)
            string maPN = txtMaPN.Text.Trim();
            string maSP = dgvChiTietNhap.CurrentRow.Cells["Column1"].Value.ToString();
            int soLuongCanNhap = Convert.ToInt32(dgvChiTietNhap.CurrentRow.Cells["Column3"].Value);

            // 2. Truyền đúng 3 thông tin này sang Form QuanLyIMEI
            FormQuanLyIMEI frm = new FormQuanLyIMEI(maPN, maSP, soLuongCanNhap);
            frm.ShowDialog();
        }

        // =========================================================================
        // MỤC 17: ĐÁNH GIÁ CHẤT LƯỢNG, KIỂM TRA SAI LỆCH IMEI & GỌI SP HOÀN TẤT
        // =========================================================================
        private void btnHoanTatNhap_Click(object sender, EventArgs e)
        {
            string maPN = txtMaPN.Text.Trim();
            if (string.IsNullOrEmpty(maPN))
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để hoàn tất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblNhap.Text == "Hoàn tất")
            {
                MessageBox.Show($"Phiếu nhập [{maPN}] đã hoàn tất trước đó, không thể thực hiện lại!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                try
                {
                    conn.Open();

                    // 1. Kiểm tra sai lệch số lượng IMEI (Chỉ áp dụng cho Điện thoại - DM01, DM02; Phụ kiện DM03 không bắt buộc IMEI)
                    string sqlCheck = @"
                        SELECT ct.MaSP, sp.TenSP, ct.SoLuongNhap, 
                               ISNULL(COUNT(tb.IMEI), 0) AS SoLuongDaQuet
                        FROM ChiTietPhieuNhap ct
                        INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                        LEFT JOIN ThietBiIMEI tb ON ct.MaPN = tb.MaPN AND ct.MaSP = tb.MaSP
                        WHERE ct.MaPN = @MaPN AND sp.MaDanhMuc <> 'DM03'
                        GROUP BY ct.MaSP, sp.TenSP, ct.SoLuongNhap
                        HAVING ct.SoLuongNhap <> ISNULL(COUNT(tb.IMEI), 0)";

                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@MaPN", maPN);
                    SqlDataReader reader = cmdCheck.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string msg = $"PHÁT HIỆN SAI LỆCH SỐ LƯỢNG IMEI TRONG PHIẾU [{maPN}]:\n\n";
                        while (reader.Read())
                        {
                            msg += $"- {reader["TenSP"]}: Nhập {reader["SoLuongNhap"]} máy, nhưng mới quét {reader["SoLuongDaQuet"]} IMEI.\n";
                        }
                        reader.Close();

                        msg += "\nBạn muốn:\n" +
                               "• Ấn [Yes]: Tự động điều chỉnh Số lượng nhập trên phiếu khớp với số IMEI thực tế đã quét.\n" +
                               "• Ấn [No]: Dừng lại để bấm 'Nhập IMEI từng dòng' quét bổ sung cho đủ.";

                        DialogResult XuLySaiLech = MessageBox.Show(msg, "Quản lý sai lệch khi kiểm nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (XuLySaiLech == DialogResult.Yes)
                        {
                            // Tự động cập nhật lại số lượng theo thực tế IMEI đã quét (nếu > 0)
                            string sqlAutoFix = @"
                                UPDATE ct
                                SET ct.SoLuongNhap = (SELECT COUNT(*) FROM ThietBiIMEI tb WHERE tb.MaPN = ct.MaPN AND tb.MaSP = ct.MaSP),
                                    ct.ThanhTien = ct.DonGiaNhap * (SELECT COUNT(*) FROM ThietBiIMEI tb WHERE tb.MaPN = ct.MaPN AND tb.MaSP = ct.MaSP)
                                FROM ChiTietPhieuNhap ct
                                INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                                WHERE ct.MaPN = @MaPN AND sp.MaDanhMuc <> 'DM03'
                                  AND (SELECT COUNT(*) FROM ThietBiIMEI tb WHERE tb.MaPN = ct.MaPN AND tb.MaSP = ct.MaSP) > 0";

                            SqlCommand cmdFix = new SqlCommand(sqlAutoFix, conn);
                            cmdFix.Parameters.AddWithValue("@MaPN", maPN);
                            int fixedRows = cmdFix.ExecuteNonQuery();

                            if (fixedRows == 0)
                            {
                                MessageBox.Show("Bạn chưa quét bất kỳ mã IMEI nào (Số lượng = 0)! Vui lòng bấm 'Nhập IMEI từng dòng' trước.", "Chưa có IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            LoadTatCaChiTiet();
                        }
                        else
                        {
                            return; // Dừng lại để người dùng đi quét thêm IMEI
                        }
                    }
                    else
                    {
                        reader.Close();
                    }

                    // 2. Xác nhận gọi Stored Procedure sp_HoanTatPhieuNhap (Có sẵn trong file SQL dùng chung)
                    if (MessageBox.Show($"Xác nhận HOÀN TẤT phiếu nhập [{maPN}]?\n\n" +
                                        "✔ Hàng 'Đạt yêu cầu' sẽ cộng vào Tồn kho và chuyển IMEI sang 'Chưa bán'.\n" +
                                        "✔ Hàng 'Lỗi' sẽ chuyển IMEI sang 'Chờ trả' (không cộng tồn).\n" +
                                        "✔ Tự động ghi vết vào bảng GiaoDichKho.",
                                        "Xác nhận chốt phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cmdSP = new SqlCommand("sp_HoanTatPhieuNhap", conn);
                        cmdSP.CommandType = CommandType.StoredProcedure;
                        cmdSP.Parameters.AddWithValue("@MaPN", maPN);
                        cmdSP.ExecuteNonQuery();

                        MessageBox.Show($"Đã hoàn tất phiếu nhập [{maPN}] thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTatCaChiTiet();
                        TaiThongTinMasterPhieuNhap(maPN);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hoàn tất phiếu nhập: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvChiTietNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;               // bấm vào tiêu đề cột thì bỏ qua

            // Đang dở Thêm/Sửa mà bấm sang dòng khác -> quay về chế độ Xem
            if (hanhDong != "") DatTrangThaiXem();

            HienThiDongDangChon(e.RowIndex);          // đổ dữ liệu lên ô nhập + cập nhật tổng tiền ở tiêu đề
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
