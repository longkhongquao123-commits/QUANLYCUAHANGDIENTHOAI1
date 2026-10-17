using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai
{
    public partial class frmLapPhieuDieuChinh : Form
    {
        // >>> CHỈNH Ở ĐÂY: dán đúng chuỗi kết nối đang chạy được ở Form1 (đổi Data Source cho khớp máy bạn)
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

        private string cheDo = "";          // "them", "sua", "xem" hoặc "duyet"
        private string maPhieu = "";        // mã phiếu đang làm việc
        private string maNV = "";           // mã nhân viên đang đăng nhập (do form danh sách truyền sang)
        private string vaiTro = "";         // vai trò của người đăng nhập
        private bool khongTimThay = false;  // true nếu mở phiếu mà không tìm thấy

        public frmLapPhieuDieuChinh() : this("", "them", "NV03", "Nhân viên kho/kỹ thuật")
        {
        }

        public frmLapPhieuDieuChinh(string maPhieu, string cheDo, string maNV, string vaiTro)
        {
            InitializeComponent();

            this.maPhieu = maPhieu;
            this.cheDo = cheDo;
            this.maNV = maNV;
            this.vaiTro = vaiTro;

            // Gắn sự kiện cho các nút
            Load += frmLapPhieuDieuChinh_Load;
            btnThemDong.Click += btnThemDong_Click;
            btnSuaDong.Click += btnSuaDong_Click;
            btnXoaDong.Click += btnXoaDong_Click;
            btnLuuNhap.Click += btnLuuNhap_Click;
            btnGuiDuyet.Click += btnGuiDuyet_Click;
            btnDuyet.Click += btnDuyet_Click;
            btnTuChoi.Click += btnTuChoi_Click;
            btnDong.Click += btnDong_Click;
            numTonTT.ValueChanged += numTonTT_ValueChanged;
            dgvChiTiet.CellClick += dgvChiTiet_CellClick;

            // Cấu hình lưới
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Các ô chỉ để xem, không cho gõ
            txtMaPhieu.ReadOnly = true;
            txtNguoiLap.ReadOnly = true;
            txtTrangThai.ReadOnly = true;
            txtTonHT.ReadOnly = true;
            txtChenhLech.ReadOnly = true;
            dtpNgayLap.Format = DateTimePickerFormat.Short;
            dtpNgayLap.Enabled = false;

            numTonTT.Minimum = 0;
            numTonTT.Maximum = 1000000;
            numTonTT.DecimalPlaces = 0;

            LoadSanPham();

            // Gắn sự kiện chọn sản phẩm SAU khi đã nạp danh sách xong
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;

            if (cheDo == "them")
            {
                txtMaPhieu.Text = "(tự tạo khi lưu nháp)";
                txtTrangThai.Text = "Nháp";
                dtpNgayLap.Value = DateTime.Now;
                txtNguoiLap.Text = LayTenNhanVien(maNV);
            }
            else
            {
                LoadPhieu();
                LoadChiTiet();
            }

            ApDungCheDo();
        }

        private void frmLapPhieuDieuChinh_Load(object sender, EventArgs e)
        {
            if (khongTimThay)
            {
                Close();
            }
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

        // Lấy họ tên nhân viên theo mã
        private string LayTenNhanVien(string ma)
        {
            try
            {
                SqlParameter[] ps = new SqlParameter[] { new SqlParameter("@MaNV", ma) };
                DataTable dt = ExecuteQuery("SELECT HoTen FROM NhanVien WHERE MaNV = @MaNV", ps);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["HoTen"].ToString();
                }
            }
            catch (SqlException)
            {
            }
            return ma;
        }

        // Nạp danh sách sản phẩm vào combobox
        private void LoadSanPham()
        {
            try
            {
                cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
                cboSanPham.DataSource = ExecuteQuery("SELECT MaSP, TenSP FROM SanPham ORDER BY TenSP");
                cboSanPham.DisplayMember = "TenSP";
                cboSanPham.ValueMember = "MaSP";
                cboSanPham.SelectedIndex = -1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nạp thông tin chung của phiếu (khi sửa, xem, duyệt)
        private void LoadPhieu()
        {
            try
            {
                string query = @"
    SELECT p.MaPhieuDC, p.NgayDieuChinh, p.LyDo, p.TrangThaiDuyet, nv.HoTen
    FROM PhieuDieuChinhTon p
    JOIN NhanVien nv ON nv.MaNV = p.MaNVLap
    WHERE p.MaPhieuDC = @MaPhieuDC";

                SqlParameter[] ps = new SqlParameter[] { new SqlParameter("@MaPhieuDC", maPhieu) };
                DataTable dt = ExecuteQuery(query, ps);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu " + maPhieu);
                    khongTimThay = true;
                    return;
                }

                DataRow row = dt.Rows[0];
                txtMaPhieu.Text = row["MaPhieuDC"].ToString();
                dtpNgayLap.Value = Convert.ToDateTime(row["NgayDieuChinh"]);
                txtNguoiLap.Text = row["HoTen"].ToString();
                txtTrangThai.Text = row["TrangThaiDuyet"].ToString();
                txtLyDo.Text = row["LyDo"].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải phiếu: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                khongTimThay = true;
            }
        }

        // Nạp các dòng kiểm kê của phiếu lên lưới
        private void LoadChiTiet()
        {
            try
            {
                string query = @"
    SELECT c.MaSP, s.TenSP, c.SoTonHeThong, c.SoTonThucTe, c.ChenhLech
    FROM ChiTietDieuChinh c
    JOIN SanPham s ON s.MaSP = c.MaSP
    WHERE c.MaPhieuDC = @MaPhieuDC
    ORDER BY c.MaSP";

                SqlParameter[] ps = new SqlParameter[] { new SqlParameter("@MaPhieuDC", maPhieu) };
                DataTable dt = ExecuteQuery(query, ps);
                dgvChiTiet.DataSource = dt;

                dgvChiTiet.Columns["MaSP"].HeaderText = "Mã SP";
                dgvChiTiet.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                dgvChiTiet.Columns["SoTonHeThong"].HeaderText = "Tồn hệ thống";
                dgvChiTiet.Columns["SoTonThucTe"].HeaderText = "Tồn thực tế";
                dgvChiTiet.Columns["ChenhLech"].HeaderText = "Chênh lệch";

                // Tính tổng thừa, tổng thiếu
                int tongThua = 0;
                int tongThieu = 0;
                foreach (DataRow row in dt.Rows)
                {
                    int chenhLech = Convert.ToInt32(row["ChenhLech"]);
                    if (chenhLech > 0)
                    {
                        tongThua = tongThua + chenhLech;
                    }
                    else if (chenhLech < 0)
                    {
                        tongThieu = tongThieu - chenhLech;
                    }
                }
                lblThua.Text = "Tổng thừa: " + tongThua;
                lblThieu.Text = "Tổng thiếu: " + tongThieu;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bật tắt ô nhập và nút theo chế độ
        private void ApDungCheDo()
        {
            bool choNhapPhieu = (cheDo == "them" || cheDo == "sua");
            bool choNhapDong = (cheDo == "sua");   // phải lưu nháp (có mã phiếu) mới thêm được dòng

            txtLyDo.ReadOnly = !choNhapPhieu;

            cboSanPham.Enabled = choNhapDong;
            numTonTT.Enabled = choNhapDong;
            btnThemDong.Enabled = choNhapDong;
            btnSuaDong.Enabled = choNhapDong;
            btnXoaDong.Enabled = choNhapDong;

            btnLuuNhap.Visible = choNhapPhieu;
            btnGuiDuyet.Visible = (cheDo == "sua");
            btnDuyet.Visible = (cheDo == "duyet");
            btnTuChoi.Visible = (cheDo == "duyet");

            if (cheDo == "them")
            {
                Text = "Lập phiếu điều chỉnh tồn";
            }
            else if (cheDo == "sua")
            {
                Text = "Sửa phiếu điều chỉnh tồn";
            }
            else if (cheDo == "duyet")
            {
                Text = "Duyệt phiếu điều chỉnh tồn";
            }
            else
            {
                Text = "Chi tiết phiếu điều chỉnh tồn";
            }
        }

        // Sinh mã phiếu mới: PDC01, PDC02, ...
        private string TaoMaPhieu()
        {
            string query = @"
    SELECT ISNULL(MAX(CAST(SUBSTRING(MaPhieuDC, 4, 10) AS INT)), 0) + 1 AS SoMoi
    FROM PhieuDieuChinhTon
    WHERE MaPhieuDC LIKE 'PDC[0-9]%'
      AND SUBSTRING(MaPhieuDC, 4, 10) NOT LIKE '%[^0-9]%'";

            DataTable dt = ExecuteQuery(query);
            int so = Convert.ToInt32(dt.Rows[0]["SoMoi"]);
            return "PDC" + so.ToString("D2");
        }

        // =========================================================
        // CHỌN SẢN PHẨM VÀ TÍNH CHÊNH LỆCH
        // =========================================================
        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex < 0)
            {
                txtTonHT.Clear();
                txtChenhLech.Clear();
                return;
            }

            try
            {
                SqlParameter[] ps = new SqlParameter[]
                {
                    new SqlParameter("@MaSP", cboSanPham.SelectedValue.ToString())
                };
                DataTable dt = ExecuteQuery("SELECT SoLuongTon FROM SanPham WHERE MaSP = @MaSP", ps);

                int ton = 0;
                if (dt.Rows.Count > 0)
                {
                    ton = Convert.ToInt32(dt.Rows[0]["SoLuongTon"]);
                }

                txtTonHT.Text = ton.ToString();
                numTonTT.Value = Math.Min(ton, (int)numTonTT.Maximum);
                TinhChenhLech();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi lấy tồn kho: " + ex.Message);
            }
        }

        private void numTonTT_ValueChanged(object sender, EventArgs e)
        {
            TinhChenhLech();
        }

        // Chênh lệch = tồn thực tế - tồn hệ thống (dương là thừa, âm là thiếu)
        private void TinhChenhLech()
        {
            int tonHeThong;
            if (!int.TryParse(txtTonHT.Text, out tonHeThong))
            {
                txtChenhLech.Clear();
                return;
            }

            int chenhLech = (int)numTonTT.Value - tonHeThong;
            txtChenhLech.Text = chenhLech.ToString();

            if (chenhLech < 0)
            {
                txtChenhLech.ForeColor = Color.Red;
            }
            else if (chenhLech > 0)
            {
                txtChenhLech.ForeColor = Color.Green;
            }
            else
            {
                txtChenhLech.ForeColor = Color.Black;
            }
        }

        // Bấm vào một dòng trong lưới thì đổ lên các ô để sửa
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvChiTiet.Rows[e.RowIndex];

            cboSanPham.SelectedValue = row.Cells["MaSP"].Value;
            txtTonHT.Text = row.Cells["SoTonHeThong"].Value.ToString();
            numTonTT.Value = Convert.ToInt32(row.Cells["SoTonThucTe"].Value);
            TinhChenhLech();
        }

        // =========================================================
        // THÊM / SỬA / XÓA DÒNG KIỂM KÊ (ghi thẳng vào CSDL)
        // =========================================================
        private void btnThemDong_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboSanPham.Focus();
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = @"
        INSERT INTO ChiTietDieuChinh (MaPhieuDC, MaSP, SoTonHeThong, SoTonThucTe)
        VALUES (@MaPhieuDC, @MaSP, @SoTonHeThong, @SoTonThucTe)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaPhieuDC", maPhieu);
                cmd.Parameters.AddWithValue("@MaSP", cboSanPham.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@SoTonHeThong", Convert.ToInt32(txtTonHT.Text));
                cmd.Parameters.AddWithValue("@SoTonThucTe", (int)numTonTT.Value);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm dòng kiểm kê thành công");
                    LoadChiTiet();
                    cboSanPham.SelectedIndex = -1;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Sản phẩm này đã có trong phiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSuaDong_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa trong bảng");
                return;
            }

            // Chỉ cho sửa Tồn thực tế của đúng dòng đang chọn
            string maSPDong = dgvChiTiet.CurrentRow.Cells["MaSP"].Value.ToString();
            if (cboSanPham.SelectedIndex < 0 || cboSanPham.SelectedValue.ToString() != maSPDong)
            {
                MessageBox.Show("Hãy bấm vào dòng cần sửa trong bảng, rồi sửa Tồn thực tế.\n" +
                                "Muốn đổi sản phẩm thì xóa dòng đó và thêm lại.");
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = @"
        UPDATE ChiTietDieuChinh
        SET SoTonThucTe = @SoTonThucTe
        WHERE MaPhieuDC = @MaPhieuDC AND MaSP = @MaSP";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaPhieuDC", maPhieu);
                cmd.Parameters.AddWithValue("@MaSP", maSPDong);
                cmd.Parameters.AddWithValue("@SoTonThucTe", (int)numTonTT.Value);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Sửa dòng kiểm kê thành công");
                    LoadChiTiet();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dòng để sửa");
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

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa dòng này không?",
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

                    string maSPDong = dgvChiTiet.CurrentRow.Cells["MaSP"].Value.ToString();

                    string query = "DELETE FROM ChiTietDieuChinh WHERE MaPhieuDC = @MaPhieuDC AND MaSP = @MaSP";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhieuDC", maPhieu);
                    cmd.Parameters.AddWithValue("@MaSP", maSPDong);

                    int resultDelete = cmd.ExecuteNonQuery();

                    if (resultDelete > 0)
                    {
                        MessageBox.Show("Xóa dòng kiểm kê thành công");
                        LoadChiTiet();
                        cboSanPham.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Xóa dòng không thành công");
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

        // =========================================================
        // LƯU NHÁP / GỬI DUYỆT
        // =========================================================
        private void btnLuuNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // =========================
                // TRƯỜNG HỢP THÊM (tạo phiếu mới)
                // =========================
                if (cheDo == "them")
                {
                    string maMoi = TaoMaPhieu();

                    string query = @"
        INSERT INTO PhieuDieuChinhTon (MaPhieuDC, NgayDieuChinh, MaNVLap, LyDo, TrangThaiDuyet)
        VALUES (@MaPhieuDC, GETDATE(), @MaNVLap, @LyDo, N'Nháp')";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaPhieuDC", maMoi);
                    cmd.Parameters.AddWithValue("@MaNVLap", maNV);
                    cmd.Parameters.AddWithValue("@LyDo", txtLyDo.Text.Trim());

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // Phiếu đã có mã, chuyển sang chế độ sửa để thêm các dòng kiểm kê
                        maPhieu = maMoi;
                        txtMaPhieu.Text = maMoi;
                        cheDo = "sua";
                        ApDungCheDo();
                        MessageBox.Show("Đã tạo phiếu " + maMoi + ".\nBây giờ bạn có thể thêm các dòng kiểm kê.");
                    }
                }

                // =========================
                // TRƯỜNG HỢP SỬA (lưu lại lý do)
                // =========================
                else if (cheDo == "sua")
                {
                    string query = @"
        UPDATE PhieuDieuChinhTon
        SET LyDo = @LyDo
        WHERE MaPhieuDC = @MaPhieuDC AND TrangThaiDuyet = N'Nháp'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaPhieuDC", maPhieu);
                    cmd.Parameters.AddWithValue("@LyDo", txtLyDo.Text.Trim());

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Lưu nháp thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu Nháp để lưu");
                    }
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

        private void btnGuiDuyet_Click(object sender, EventArgs e)
        {
            // Phiếu phải có ít nhất 1 dòng kiểm kê
            SqlParameter[] ps = new SqlParameter[] { new SqlParameter("@MaPhieuDC", maPhieu) };
            DataTable dt = ExecuteQuery(
                "SELECT COUNT(*) AS SoDong FROM ChiTietDieuChinh WHERE MaPhieuDC = @MaPhieuDC", ps);

            if (Convert.ToInt32(dt.Rows[0]["SoDong"]) == 0)
            {
                MessageBox.Show("Phiếu chưa có dòng kiểm kê nào", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtLyDo.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập lý do điều chỉnh trước khi gửi duyệt", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLyDo.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Sau khi gửi duyệt sẽ không sửa được phiếu nữa. Tiếp tục?",
                "Xác nhận gửi duyệt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Bước 1: cập nhật lại tồn hệ thống theo thời điểm gửi
                // Bước 2: đổi trạng thái phiếu sang Chờ duyệt
                string query = @"
        UPDATE c
        SET c.SoTonHeThong = s.SoLuongTon
        FROM ChiTietDieuChinh c
        JOIN SanPham s ON s.MaSP = c.MaSP
        WHERE c.MaPhieuDC = @MaPhieuDC;

        UPDATE PhieuDieuChinhTon
        SET LyDo = @LyDo, TrangThaiDuyet = N'Chờ duyệt'
        WHERE MaPhieuDC = @MaPhieuDC AND TrangThaiDuyet = N'Nháp'";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaPhieuDC", maPhieu);
                cmd.Parameters.AddWithValue("@LyDo", txtLyDo.Text.Trim());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Đã gửi duyệt phiếu " + maPhieu);
                Close();
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

        // =========================================================
        // DUYỆT / TỪ CHỐI (chỉ Quản lý)
        // =========================================================
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (vaiTro != "Quản lý")
            {
                MessageBox.Show("Chỉ Quản lý mới được duyệt phiếu", "Không đủ quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Duyệt phiếu sẽ cập nhật tồn kho theo số thực tế. Tiếp tục?",
                "Xác nhận duyệt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Gọi stored procedure có sẵn trong CSDL của nhóm
                SqlCommand cmd = new SqlCommand("sp_DuyetPhieuDieuChinhTon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaPhieuDC", maPhieu);
                cmd.Parameters.AddWithValue("@MaNVDuyet", maNV);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Duyệt phiếu thành công, tồn kho đã được cập nhật");
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Không thể duyệt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (vaiTro != "Quản lý")
            {
                MessageBox.Show("Chỉ Quản lý mới được từ chối phiếu", "Không đủ quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Từ chối phiếu này? Tồn kho sẽ không thay đổi.",
                "Xác nhận từ chối",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = @"
        UPDATE PhieuDieuChinhTon
        SET TrangThaiDuyet = N'Hủy', MaNVDuyet = @MaNVDuyet
        WHERE MaPhieuDC = @MaPhieuDC AND TrangThaiDuyet = N'Chờ duyệt'";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaPhieuDC", maPhieu);
                cmd.Parameters.AddWithValue("@MaNVDuyet", maNV);

                int resultUpdate = cmd.ExecuteNonQuery();

                if (resultUpdate > 0)
                {
                    MessageBox.Show("Đã từ chối phiếu " + maPhieu);
                    Close();
                }
                else
                {
                    MessageBox.Show("Phiếu không còn ở trạng thái Chờ duyệt");
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}