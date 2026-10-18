using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyCuaHangDT
{
    /// <summary>
    /// Form quản lý nhà cung cấp. TOÀN BỘ nằm trong 1 file này: chuỗi kết nối, câu lệnh SQL, xử lý giao diện.
    /// Các control (txtMaNCC, btnThem, dgvNhaCungCap...) nằm trong FormNhaCungCap.Designer.cs, KHÔNG khai báo lại.
    /// </summary>
    public partial class FormNhaCungCap : Form
    {
        // Chuỗi kết nối: đổi Server/Database cho đúng máy mày
        private readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=QuanLyCuaHangDienThoai;Trusted_Connection=True;TrustServerCertificate=True;";

        private bool dangNap; // true khi đang nạp bảng, để bỏ qua sự kiện chọn dòng

        public FormNhaCungCap()
        {
            InitializeComponent();
            CauHinhBang();
            GanSuKien();
        }

        // =====================================================================
        // TRUY VẤN CƠ SỞ DỮ LIỆU (3 hàm dùng chung + 2 hàm hỗ trợ)
        // =====================================================================
        /// <summary>Chạy SELECT, trả về bảng dữ liệu.</summary>
        private DataTable LayBang(string sql, params SqlParameter[] thamSo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddRange(thamSo);
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>Chạy SELECT lấy 1 giá trị (ô đầu tiên). Không có dòng nào thì trả null.</summary>
        private object LayGiaTri(string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(thamSo);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>Chạy INSERT / UPDATE / DELETE.</summary>
        private void ChayLenh(string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(thamSo);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static SqlParameter P(string ten, object giaTri)
        {
            return new SqlParameter(ten, giaTri ?? DBNull.Value);
        }

        /// <summary>Chuỗi rỗng thì lưu NULL vào DB.</summary>
        private static object ToDb(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? (object)DBNull.Value : s.Trim();
        }

        /// <summary>Tham số lấy từ các ô nhập, dùng chung cho INSERT và UPDATE.</summary>
        private SqlParameter[] ThamSoForm()
        {
            return new SqlParameter[]
            {
                P("@ma", txtMaNCC.Text.Trim()),
                P("@ten", txtTenNCC.Text.Trim()),
                P("@sdt", ToDb(txtSDT.Text)),
                P("@email", ToDb(txtEmail.Text)),
                P("@diachi", ToDb(txtDiaChi.Text)),
                P("@tt", cboTrangThai.Text)
            };
        }

        /// <summary>Gợi ý mã mới: NCC + (số lớn nhất hiện có + 1), ví dụ NCC03.</summary>
        private string TaoMaMoi()
        {
            int max = 0;
            foreach (DataRow r in LayBang("SELECT MaNCC FROM NhaCungCap").Rows)
            {
                string ma = r["MaNCC"].ToString();
                int so;
                if (ma.StartsWith("NCC", StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(ma.Substring(3), out so) && so > max)
                {
                    max = so;
                }
            }
            return "NCC" + (max + 1).ToString("00");
        }

        // =====================================================================
        // CẤU HÌNH BAN ĐẦU
        // =====================================================================
        private void CauHinhBang()
        {
            txtMaNCC.MaxLength = 20;
            txtTenNCC.MaxLength = 150;
            txtSDT.MaxLength = 15;
            txtEmail.MaxLength = 100;
            txtDiaChi.MaxLength = 255;

            dgvNhaCungCap.ReadOnly = true;
            dgvNhaCungCap.AllowUserToAddRows = false;
            dgvNhaCungCap.AllowUserToDeleteRows = false;
            dgvNhaCungCap.MultiSelect = false;
            dgvNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhaCungCap.RowHeadersVisible = false;
            dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Nối 6 cột đã add trong Designer với 6 cột của câu SELECT (theo thứ tự từ trái sang phải)
            string[] cot = { "MaNCC", "TenNCC", "SoDienThoai", "Email", "DiaChi", "TrangThai" };
            if (dgvNhaCungCap.Columns.Count == 0)
            {
                dgvNhaCungCap.AutoGenerateColumns = true;
            }
            else
            {
                dgvNhaCungCap.AutoGenerateColumns = false;
                for (int i = 0; i < cot.Length && i < dgvNhaCungCap.Columns.Count; i++)
                    dgvNhaCungCap.Columns[i].DataPropertyName = cot[i];
            }
        }

        // "-=" trước "+=" để dù đã double-click nút trong Designer thì sự kiện vẫn chỉ chạy 1 lần.
        private void GanSuKien()
        {
            Load -= FormNhaCungCap_Load; Load += FormNhaCungCap_Load;
            btnThem.Click -= btnThem_Click; btnThem.Click += btnThem_Click;
            btnSua.Click -= btnSua_Click; btnSua.Click += btnSua_Click;
            btnXoa.Click -= btnXoa_Click; btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click -= btnLamMoi_Click; btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click -= btnTim_Click; btnTim.Click += btnTim_Click;
            txtTimKiem.KeyDown -= txtTimKiem_KeyDown; txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            txtSDT.Leave -= txtSDT_Leave; txtSDT.Leave += txtSDT_Leave;
            dgvNhaCungCap.SelectionChanged -= dgvNhaCungCap_SelectionChanged;
            dgvNhaCungCap.SelectionChanged += dgvNhaCungCap_SelectionChanged;
        }

        // =====================================================================
        // NẠP DỮ LIỆU
        // =====================================================================
        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            if (cboTrangThai.Items.Count == 0)
                cboTrangThai.Items.AddRange(new object[] { "Đang hợp tác", "Ngừng hợp tác" });
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            TaiLaiBang();
            LamMoiForm();
        }

        private void TaiLaiBang()
        {
            try
            {
                dangNap = true;
                dgvNhaCungCap.DataSource = LayBang(
                    @"SELECT MaNCC, TenNCC, SoDienThoai, Email, DiaChi, TrangThai
                      FROM NhaCungCap
                      WHERE MaNCC LIKE @tk OR TenNCC LIKE @tk OR SoDienThoai LIKE @tk OR Email LIKE @tk
                      ORDER BY MaNCC",
                    P("@tk", "%" + txtTimKiem.Text.Trim() + "%"));
                dgvNhaCungCap.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không tải được dữ liệu:\n" + ex.Message, "Lỗi kết nối",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangNap = false;
            }
        }

        private static string Chuoi(object v)
        {
            return (v == null || v == DBNull.Value) ? "" : v.ToString();
        }

        private void dgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dangNap || dgvNhaCungCap.SelectedRows.Count == 0) return;

            DataRowView dong = dgvNhaCungCap.SelectedRows[0].DataBoundItem as DataRowView;
            if (dong == null) return;

            txtMaNCC.Text = Chuoi(dong["MaNCC"]);
            txtTenNCC.Text = Chuoi(dong["TenNCC"]);
            txtSDT.Text = Chuoi(dong["SoDienThoai"]);
            txtEmail.Text = Chuoi(dong["Email"]);
            txtDiaChi.Text = Chuoi(dong["DiaChi"]);
            cboTrangThai.Text = Chuoi(dong["TrangThai"]);
            lblCanhBao.Text = "";
            txtMaNCC.ReadOnly = true; // đang sửa: không cho đổi mã (khóa chính)
        }

        /// <summary>Đưa form về trạng thái nhập nhà cung cấp mới.</summary>
        private void LamMoiForm()
        {
            try { txtMaNCC.Text = TaoMaMoi(); }
            catch (SqlException) { txtMaNCC.Text = ""; }

            txtMaNCC.ReadOnly = false;
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            lblCanhBao.Text = "";
            dgvNhaCungCap.ClearSelection();
            txtTenNCC.Focus();
        }

        // =====================================================================
        // KIỂM TRA DỮ LIỆU
        // =====================================================================
        private bool Loi(string noiDung, Control oLoi)
        {
            MessageBox.Show(noiDung, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            oLoi.Focus();
            return false;
        }

        private bool HopLe()
        {
            string ma = txtMaNCC.Text.Trim();
            string ten = txtTenNCC.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (ma == "") return Loi("Vui lòng nhập mã nhà cung cấp.", txtMaNCC);
            if (ma.Contains(" ")) return Loi("Mã nhà cung cấp không được chứa khoảng trắng.", txtMaNCC);
            if (ten == "") return Loi("Vui lòng nhập tên nhà cung cấp.", txtTenNCC);

            // SĐT không bắt buộc, nhưng nếu nhập thì phải đúng: số 10 chữ số bắt đầu bằng 0,
            // hoặc tổng đài dạng 1800xxxx / 1900xxxx (nhà cung cấp thường dùng).
            if (sdt != "" && !Regex.IsMatch(sdt, @"^(0\d{9}|1[89]00\d{4,6})$"))
                return Loi("Số điện thoại không đúng: nhập 10 số bắt đầu bằng 0, hoặc tổng đài 1800xxxx / 1900xxxx.", txtSDT);

            if (email != "" && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return Loi("Email không đúng định dạng (ví dụ: contact@congty.com).", txtEmail);
            return true;
        }

        /// <summary>Cảnh báo (không chặn) nếu SĐT đang trùng với nhà cung cấp khác.</summary>
        private void CanhBaoTrungSDT()
        {
            lblCanhBao.Text = "";
            string sdt = txtSDT.Text.Trim();
            if (sdt == "") return;

            try
            {
                object ten = LayGiaTri(
                    "SELECT TOP 1 TenNCC FROM NhaCungCap WHERE SoDienThoai = @sdt AND MaNCC <> @ma",
                    P("@sdt", sdt), P("@ma", txtMaNCC.Text.Trim()));
                if (ten != null)
                    lblCanhBao.Text = "Lưu ý: số điện thoại này cũng đang dùng ở nhà cung cấp \"" + ten + "\"";
            }
            catch (SqlException)
            {
                // lỗi kết nối sẽ được báo ở bước lưu
            }
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            CanhBaoTrungSDT();
        }

        private void BaoLoiSql(SqlException ex)
        {
            string noiDung = (ex.Number == 2627 || ex.Number == 2601)
                ? "Dữ liệu bị trùng (mã nhà cung cấp đã tồn tại)."
                : ex.Message;
            MessageBox.Show(noiDung, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // =====================================================================
        // CÁC NÚT
        // =====================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.ReadOnly)
            {
                MessageBox.Show("Bạn đang chọn một nhà cung cấp có sẵn.\nBấm \"Làm mới\" để nhập nhà cung cấp mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!HopLe()) return;

            try
            {
                int daCo = (int)LayGiaTri("SELECT COUNT(*) FROM NhaCungCap WHERE MaNCC = @ma",
                    P("@ma", txtMaNCC.Text.Trim()));
                if (daCo > 0)
                {
                    Loi("Mã nhà cung cấp này đã tồn tại.", txtMaNCC);
                    return;
                }

                ChayLenh(
                    @"INSERT INTO NhaCungCap (MaNCC, TenNCC, SoDienThoai, Email, DiaChi, TrangThai)
                      VALUES (@ma, @ten, @sdt, @email, @diachi, @tt)",
                    ThamSoForm());

                MessageBox.Show("Thêm nhà cung cấp thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiLaiBang();
                LamMoiForm();
            }
            catch (SqlException ex)
            {
                BaoLoiSql(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!txtMaNCC.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một nhà cung cấp trong bảng trước khi sửa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!HopLe()) return;

            try
            {
                ChayLenh(
                    @"UPDATE NhaCungCap
                      SET TenNCC = @ten, SoDienThoai = @sdt, Email = @email, DiaChi = @diachi, TrangThai = @tt
                      WHERE MaNCC = @ma",
                    ThamSoForm());

                MessageBox.Show("Cập nhật nhà cung cấp thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiLaiBang();
                LamMoiForm();
            }
            catch (SqlException ex)
            {
                BaoLoiSql(ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!txtMaNCC.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một nhà cung cấp trong bảng trước khi xóa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult hoi = MessageBox.Show(
                "Bạn có chắc muốn xóa nhà cung cấp \"" + txtTenNCC.Text + "\" (" + txtMaNCC.Text + ")?\n\n" +
                "Nếu đã có phiếu nhập, hệ thống sẽ chuyển sang \"Ngừng hợp tác\" thay vì xóa hẳn.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            try
            {
                // Gọi stored procedure sp_XoaNhaCungCap, SP trả về câu thông báo kết quả
                string thongBao;
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_XoaNhaCungCap", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text.Trim());
                    conn.Open();
                    object kq = cmd.ExecuteScalar();
                    thongBao = kq == null ? "" : kq.ToString();
                }

                MessageBox.Show(thongBao, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiLaiBang();
                LamMoiForm();
            }
            catch (SqlException ex)
            {
                BaoLoiSql(ex);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            TaiLaiBang();
            LamMoiForm();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TaiLaiBang();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // tránh tiếng "bíp"
                TaiLaiBang();
            }
        }
    }
}