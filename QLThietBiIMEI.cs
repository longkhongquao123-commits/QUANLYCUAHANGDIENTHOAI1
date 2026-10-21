using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai
{
    public partial class QLThietBiIMEI : Form
    {
        // >>> CHỈNH Ở ĐÂY: thay Data Source bằng tên server trong SSMS của bạn (ô Server name)
        // Ví dụ: .\SQLEXPRESS  |  localhost  |  TEN-MAY\SQLEXPRESS
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

        private string trangThai = "";      // "them" hoặc "sua" (rỗng = đang xem)

        public QLThietBiIMEI()
        {
            InitializeComponent();

            // Cấu hình lưới (các cột đã tạo sẵn trong Designer)
            dgvThietBi.AutoGenerateColumns = false;
            dgvThietBi.ReadOnly = true;
            dgvThietBi.AllowUserToAddRows = false;
            dgvThietBi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThietBi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThietBi.Columns["NgayBaoHanhDen"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvThietBi.CellClick += dgvThietBi_CellClick;

            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker1.Format = DateTimePickerFormat.Short;

            // Combobox trạng thái (dùng cho nhập liệu)
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "Chưa bán", "Đã giữ", "Đã bán", "Lỗi", "Chờ trả" });

            // Combobox lọc trạng thái
            cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Chưa bán", "Đã giữ", "Đã bán", "Lỗi", "Chờ trả" });
            cboLocTrangThai.SelectedIndex = 0;

            // Combobox sản phẩm
            cboTenSP.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadSanPham();

            LoadData();
            TrangThaiBinhThuong();
            HienThongTinDongDangChon();
        }

        // =========================================================
        // HÀM DÙNG CHUNG
        // =========================================================
        public DataTable ExecuteQuery(string query, SqlParameter[] sqlParameters = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnect = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnect))
                {
                    if (sqlParameters != null)
                    {
                        cmd.Parameters.AddRange(sqlParameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        private void LoadSanPham()
        {
            try
            {
                // Phụ kiện (củ sạc...) không có IMEI nên không đưa vào danh sách
                DataTable dt = ExecuteQuery(
                    @"SELECT s.MaSP, s.TenSP
                      FROM SanPham s
                      JOIN DanhMuc d ON d.MaDanhMuc = s.MaDanhMuc
                      WHERE d.TenDanhMuc NOT LIKE N'Phụ kiện%'
                      ORDER BY s.TenSP");
                cboTenSP.DataSource = dt;
                cboTenSP.DisplayMember = "TenSP";
                cboTenSP.ValueMember = "MaSP";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                string query = @"SELECT t.IMEI, t.MaSP, s.TenSP, t.MauSac, t.DungLuong,
                                        t.TrangThai, t.NgayBaoHanhDen, t.MaPN
                                 FROM ThietBiIMEI t
                                 JOIN SanPham s ON s.MaSP = t.MaSP
                                 ORDER BY t.IMEI";

                DataTable dt = ExecuteQuery(query);
                dgvThietBi.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khóa các ô nhập liệu, đưa nút về trạng thái ban đầu
        private void TrangThaiBinhThuong()
        {
            txtIMEI.Enabled = false;
            cboTenSP.Enabled = false;
            cboTrangThai.Enabled = false;
            txtMauSac.Enabled = false;
            txtDungLuong.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtMaPN.Enabled = false;            // chỉ mở khi bấm Thêm

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
        }

        // Đổ dữ liệu 1 dòng của lưới lên các ô nhập
        private void HienThongTin(DataGridViewRow r)
        {
            txtIMEI.Text = Convert.ToString(r.Cells["IMEI"].Value);
            cboTenSP.SelectedValue = r.Cells["MaSP"].Value;
            txtMauSac.Text = Convert.ToString(r.Cells["MauSac"].Value);
            txtDungLuong.Text = Convert.ToString(r.Cells["DungLuong"].Value);
            cboTrangThai.SelectedItem = Convert.ToString(r.Cells["TrangThai"].Value);
            txtMaPN.Text = Convert.ToString(r.Cells["MaPN"].Value);

            object bh = r.Cells["NgayBaoHanhDen"].Value;
            if (bh == null || bh == DBNull.Value)
            {
                dateTimePicker1.Checked = false;
            }
            else
            {
                dateTimePicker1.Value = Convert.ToDateTime(bh);
                dateTimePicker1.Checked = true;
            }
        }

        private void HienThongTinDongDangChon()
        {
            if (dgvThietBi.CurrentRow != null)
            {
                HienThongTin(dgvThietBi.CurrentRow);
            }
        }

        private void dgvThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (trangThai != "") return;     // đang thêm/sửa thì không đổ đè dữ liệu
            if (e.RowIndex < 0) return;
            HienThongTin(dgvThietBi.Rows[e.RowIndex]);
        }

        // =========================================================
        // CÁC NÚT
        // =========================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            trangThai = "them";

            // Xóa trắng để nhập mới
            txtIMEI.Clear();
            txtMauSac.Clear();
            txtDungLuong.Clear();
            txtMaPN.Clear();
            cboTenSP.SelectedIndex = -1;
            cboTrangThai.SelectedItem = "Chưa bán";
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Checked = false;

            txtIMEI.Enabled = true;
            txtMaPN.Enabled = true;             // cho nhập mã phiếu nhập khi thêm
            cboTenSP.Enabled = true;
            cboTrangThai.Enabled = true;
            txtMauSac.Enabled = true;
            txtDungLuong.Enabled = true;
            dateTimePicker1.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnGhi.Enabled = true;
            btnHuy.Enabled = true;

            txtIMEI.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThietBi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần sửa");
                return;
            }

            trangThai = "sua";

            txtIMEI.Enabled = false;            // IMEI là khóa chính, không cho sửa
            cboTenSP.Enabled = true;
            cboTrangThai.Enabled = true;
            txtMauSac.Enabled = true;
            txtDungLuong.Enabled = true;
            dateTimePicker1.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            // ----- Kiểm tra dữ liệu -----
            string imei = txtIMEI.Text.Trim();

            // Kiểm tra IMEI hợp lệ: đúng 15 chữ số
            if (!Regex.IsMatch(imei, @"^\d{15}$"))
            {
                MessageBox.Show(
                    "IMEI không hợp lệ!\nIMEI phải gồm đúng 15 chữ số.",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIMEI.Focus();
                return;
            }

            if (cboTenSP.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTenSP.Focus();
                return;
            }

            if (cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTrangThai.Focus();
                return;
            }

            string tt = cboTrangThai.SelectedItem.ToString();

            // Ô để trống thì lưu NULL
            object mauSac = txtMauSac.Text.Trim() == "" ? (object)DBNull.Value : txtMauSac.Text.Trim();
            object dungLuong = txtDungLuong.Text.Trim() == "" ? (object)DBNull.Value : txtDungLuong.Text.Trim();
            object hanBH = dateTimePicker1.Checked ? (object)dateTimePicker1.Value.Date : DBNull.Value;
            object maPN = txtMaPN.Text.Trim() == "" ? (object)DBNull.Value : txtMaPN.Text.Trim();

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // =========================
                // TRƯỜNG HỢP THÊM
                // =========================
                if (trangThai == "them")
                {
                    string query = @"
        INSERT INTO ThietBiIMEI (IMEI, MaSP, MauSac, DungLuong, NgayBaoHanhDen, TrangThai, MaPN)
        VALUES (@IMEI, @MaSP, @MauSac, @DungLuong, @NgayBaoHanhDen, @TrangThai, @MaPN)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@IMEI", imei);
                    cmd.Parameters.AddWithValue("@MaSP", cboTenSP.SelectedValue);
                    cmd.Parameters.AddWithValue("@MauSac", mauSac);
                    cmd.Parameters.AddWithValue("@DungLuong", dungLuong);
                    cmd.Parameters.AddWithValue("@NgayBaoHanhDen", hanBH);
                    cmd.Parameters.AddWithValue("@TrangThai", tt);
                    cmd.Parameters.AddWithValue("@MaPN", maPN);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công");
                    }
                }

                // =========================
                // TRƯỜNG HỢP SỬA
                // =========================
                else if (trangThai == "sua")
                {
                    string query = @"
        UPDATE ThietBiIMEI
        SET MaSP = @MaSP,
            MauSac = @MauSac,
            DungLuong = @DungLuong,
            NgayBaoHanhDen = @NgayBaoHanhDen,
            TrangThai = @TrangThai
        WHERE IMEI = @IMEI";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@IMEI", imei);
                    cmd.Parameters.AddWithValue("@MaSP", cboTenSP.SelectedValue);
                    cmd.Parameters.AddWithValue("@MauSac", mauSac);
                    cmd.Parameters.AddWithValue("@DungLuong", dungLuong);
                    cmd.Parameters.AddWithValue("@NgayBaoHanhDen", hanBH);
                    cmd.Parameters.AddWithValue("@TrangThai", tt);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Sửa dữ liệu thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thiết bị để sửa");
                    }
                }

                // Tải lại DataGridView
                LoadData();

                // Trở về trạng thái bình thường
                trangThai = "";
                TrangThaiBinhThuong();
                HienThongTinDongDangChon();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    // Kiểm tra IMEI trùng
                    MessageBox.Show("IMEI này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 547)
                {
                    if (ex.Message.Contains("FOREIGN KEY"))
                        MessageBox.Show("Mã phiếu nhập hoặc sản phẩm không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Dữ liệu không hợp lệ (trạng thái sai quy định).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Trả về lý do không được xóa, hoặc "" nếu được xóa
        // Quy tắc giống trigger trg_ChanXoaIMEI: đã bán / đang giữ / thuộc phiếu nhập đã hoàn tất
        private string LyDoKhongXoa(string imei)
        {
            DataTable dt = ExecuteQuery(
                @"SELECT t.TrangThai, t.MaPN, pn.TrangThai AS TrangThaiPN,
                         (SELECT COUNT(*) FROM ChiTietXuat_IMEI x WHERE x.IMEI = t.IMEI) AS SoLanBan
                  FROM ThietBiIMEI t
                  LEFT JOIN PhieuNhap pn ON pn.MaPN = t.MaPN
                  WHERE t.IMEI = @imei",
                new SqlParameter[] { new SqlParameter("@imei", imei) });

            if (dt.Rows.Count == 0) return "Không tìm thấy thiết bị.";

            DataRow r = dt.Rows[0];
            string tt = Convert.ToString(r["TrangThai"]);
            string maPN = Convert.ToString(r["MaPN"]);
            string ttPN = Convert.ToString(r["TrangThaiPN"]);

            if (Convert.ToInt32(r["SoLanBan"]) > 0 || tt == "Đã bán")
                return "Thiết bị đã bán (có trong hóa đơn), không được xóa.";
            if (tt == "Đã giữ")
                return "Thiết bị đang được giữ cho đơn hàng, không được xóa.";
            if (ttPN == "Hoàn tất")
                return "Thiết bị thuộc phiếu nhập " + maPN + " đã hoàn tất (đã tính vào tồn kho) nên không được xóa.";
            return "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThietBi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần xóa");
                return;
            }

            string id = dgvThietBi.CurrentRow.Cells["IMEI"].Value.ToString();

            // Chặn xóa khi đã nhập hoặc đã bán
            string lyDo = LyDoKhongXoa(id);
            if (lyDo != "")
            {
                MessageBox.Show(lyDo, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa thiết bị này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    string query = "DELETE FROM ThietBiIMEI WHERE IMEI = @IMEI";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IMEI", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa dữ liệu thành công");
                    LoadData();
                    HienThongTinDongDangChon();
                }
                catch (SqlException ex)
                {
                    // Trigger trg_ChanXoaIMEI là lớp bảo vệ cuối cùng nếu form bỏ sót trường hợp nào
                    MessageBox.Show(ex.Message, "Không thể xóa",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            trangThai = "";
            TrangThaiBinhThuong();
            HienThongTinDongDangChon();     // trả các ô về dữ liệu dòng đang chọn
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = @"
    SELECT t.IMEI, t.MaSP, s.TenSP, t.MauSac, t.DungLuong,
           t.TrangThai, t.NgayBaoHanhDen, t.MaPN
    FROM ThietBiIMEI t
    JOIN SanPham s ON s.MaSP = t.MaSP
    WHERE (@IMEI = '' OR t.IMEI LIKE '%' + @IMEI + '%')
      AND (@TrangThai = N'' OR t.TrangThai = @TrangThai)
    ORDER BY t.IMEI";

            string imeiInput = txtTimIMEI.Text.Trim();
            string ttLoc = cboLocTrangThai.SelectedIndex > 0 ? cboLocTrangThai.Text : "";

            try
            {
                SqlParameter[] ps = new SqlParameter[]
                {
                    new SqlParameter("@IMEI", imeiInput),
                    new SqlParameter("@TrangThai", ttLoc)
                };

                DataTable dt = ExecuteQuery(query, ps);
                dgvThietBi.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thiết bị nào phù hợp!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                HienThongTinDongDangChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // 1. Xóa nội dung tìm kiếm và bộ lọc
            txtTimIMEI.Clear();
            cboLocTrangThai.SelectedIndex = 0;

            // 2. Tải lại danh sách sản phẩm và toàn bộ dữ liệu
            LoadSanPham();
            LoadData();

            // 3. Đưa form về trạng thái ban đầu
            trangThai = "";
            TrangThaiBinhThuong();
            HienThongTinDongDangChon();
        }

        // =========================================================
        // CÁC HÀM RỖNG (Designer đang gắn sẵn, xóa sẽ báo lỗi biên dịch)
        // =========================================================
        private void txtDungLuong_TextChanged(object sender, EventArgs e) { }
        private void txtMauSac_TextChanged(object sender, EventArgs e) { }
        private void txtMaPN_TextChanged(object sender, EventArgs e) { }
        private void txtIMEI_TextChanged(object sender, EventArgs e) { }
        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboTenSP_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void lbLoc_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}