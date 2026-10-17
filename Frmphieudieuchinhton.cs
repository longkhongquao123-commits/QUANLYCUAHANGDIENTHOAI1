using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai
{
    public partial class Frmphieudieuchinhton : Form
    {
        // >>> CHỈNH Ở ĐÂY: dán đúng chuỗi kết nối đang chạy được ở Form1 (đổi Data Source cho khớp máy bạn)
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

        // >>> TẠM THỜI: người đang đăng nhập (khi TV1 làm xong form đăng nhập thì gán lại 2 biến này)
        // Muốn thử chức năng Duyệt: đổi thành "NV01" và "Quản lý" rồi chạy lại
        private string maNVDangNhap = "NV03";
        private string vaiTroDangNhap = "Nhân viên kho/kỹ thuật";

        public Frmphieudieuchinhton()
        {
            InitializeComponent();

            // Gắn sự kiện cho các nút
            btnTim.Click += btnTim_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnLapMoi.Click += btnLapMoi_Click;
            btnXem.Click += btnXem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnDong.Click += btnDong_Click;
            dgvPhieu.CellDoubleClick += dgvPhieu_CellDoubleClick;

            // Cấu hình lưới
            dgvPhieu.ReadOnly = true;
            dgvPhieu.AllowUserToAddRows = false;
            dgvPhieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Bộ lọc
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Value = DateTime.Today.AddMonths(-3);
            dtpDenNgay.Value = DateTime.Today;

            cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Nháp", "Chờ duyệt", "Đã duyệt", "Hủy" });
            cboLocTrangThai.SelectedIndex = 0;

            lblNguoiDung.Text = "Đăng nhập: " + maNVDangNhap + " (" + vaiTroDangNhap + ")";

            LoadData();
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

        // Tải danh sách phiếu (có lọc theo ngày, trạng thái, mã phiếu)
        private void LoadData()
        {
            try
            {
                string query = @"
    SELECT p.MaPhieuDC, p.NgayDieuChinh, nl.HoTen AS NguoiLap,
           p.TrangThaiDuyet, nd.HoTen AS NguoiDuyet, p.LyDo
    FROM PhieuDieuChinhTon p
    JOIN NhanVien nl ON nl.MaNV = p.MaNVLap
    LEFT JOIN NhanVien nd ON nd.MaNV = p.MaNVDuyet
    WHERE CAST(p.NgayDieuChinh AS date) BETWEEN @Tu AND @Den
      AND (@TrangThai = N'' OR p.TrangThaiDuyet = @TrangThai)
      AND (@Ma = '' OR p.MaPhieuDC LIKE '%' + @Ma + '%')
    ORDER BY p.NgayDieuChinh DESC";

                string ttLoc = cboLocTrangThai.SelectedIndex > 0 ? cboLocTrangThai.Text : "";

                SqlParameter[] ps = new SqlParameter[]
                {
                    new SqlParameter("@Tu", dtpTuNgay.Value.Date),
                    new SqlParameter("@Den", dtpDenNgay.Value.Date),
                    new SqlParameter("@TrangThai", ttLoc),
                    new SqlParameter("@Ma", txtTimMa.Text.Trim())
                };

                dgvPhieu.DataSource = ExecuteQuery(query, ps);
                dgvPhieu.Columns["NgayDieuChinh"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lấy mã phiếu của dòng đang chọn (không chọn thì trả về rỗng)
        private string LayMaPhieuDangChon()
        {
            if (dgvPhieu.CurrentRow == null)
            {
                return "";
            }
            return dgvPhieu.CurrentRow.Cells["MaPhieuDC"].Value.ToString();
        }

        // Lấy trạng thái của dòng đang chọn
        private string LayTrangThaiDangChon()
        {
            if (dgvPhieu.CurrentRow == null)
            {
                return "";
            }
            return dgvPhieu.CurrentRow.Cells["TrangThaiDuyet"].Value.ToString();
        }

        // =========================================================
        // CÁC NÚT
        // =========================================================
        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today.AddMonths(-3);
            dtpDenNgay.Value = DateTime.Today;
            cboLocTrangThai.SelectedIndex = 0;
            txtTimMa.Clear();
            LoadData();
        }

        private void btnLapMoi_Click(object sender, EventArgs e)
        {
            frmLapPhieuDieuChinh f = new frmLapPhieuDieuChinh("", "them", maNVDangNhap, vaiTroDangNhap);
            f.ShowDialog();
            LoadData();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string ma = LayMaPhieuDangChon();
            if (ma == "")
            {
                MessageBox.Show("Vui lòng chọn phiếu cần xem");
                return;
            }

            // Quản lý mở phiếu "Chờ duyệt" thì vào chế độ duyệt, còn lại chỉ xem
            string cheDo = "xem";
            if (LayTrangThaiDangChon() == "Chờ duyệt" && vaiTroDangNhap == "Quản lý")
            {
                cheDo = "duyet";
            }

            frmLapPhieuDieuChinh f = new frmLapPhieuDieuChinh(ma, cheDo, maNVDangNhap, vaiTroDangNhap);
            f.ShowDialog();
            LoadData();
        }

        private void dgvPhieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnXem_Click(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = LayMaPhieuDangChon();
            if (ma == "")
            {
                MessageBox.Show("Vui lòng chọn phiếu cần sửa");
                return;
            }

            if (LayTrangThaiDangChon() != "Nháp")
            {
                MessageBox.Show("Chỉ được sửa phiếu đang ở trạng thái Nháp");
                return;
            }

            frmLapPhieuDieuChinh f = new frmLapPhieuDieuChinh(ma, "sua", maNVDangNhap, vaiTroDangNhap);
            f.ShowDialog();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = LayMaPhieuDangChon();
            if (ma == "")
            {
                MessageBox.Show("Vui lòng chọn phiếu cần xóa");
                return;
            }

            if (LayTrangThaiDangChon() != "Nháp")
            {
                MessageBox.Show("Chỉ được xóa phiếu đang ở trạng thái Nháp");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phiếu này không?",
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

                    // Xóa các dòng chi tiết trước, rồi xóa phiếu (chỉ khi phiếu còn là Nháp)
                    string query = @"
        IF EXISTS (SELECT 1 FROM PhieuDieuChinhTon WHERE MaPhieuDC = @MaPhieuDC AND TrangThaiDuyet = N'Nháp')
        BEGIN
            DELETE FROM ChiTietDieuChinh WHERE MaPhieuDC = @MaPhieuDC;
            DELETE FROM PhieuDieuChinhTon WHERE MaPhieuDC = @MaPhieuDC;
        END";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhieuDC", ma);

                    int resultDelete = cmd.ExecuteNonQuery();

                    if (resultDelete > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu không thành công (phiếu không còn là Nháp)");
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
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}