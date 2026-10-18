using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyCuaHangDT
{
    /// <summary>
    /// Form quản lý khách hàng. TOÀN BỘ nằm trong 1 file này: chuỗi kết nối, câu lệnh SQL, xử lý giao diện.
    /// Các control (txtMaKH, btnThem, dgvKhachHang...) nằm trong FormKhachHang.Designer.cs, KHÔNG khai báo lại.
    /// </summary>
    public partial class FormKhachHang : Form
    {
        // Chuỗi kết nối: đổi Server/Database cho đúng máy mày
        private readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=QuanLyCuaHangDienThoai;Trusted_Connection=True;TrustServerCertificate=True;";

        private bool dangNap; // true khi đang nạp bảng, để bỏ qua sự kiện chọn dòng

        // Các hàm rỗng để Designer không báo lỗi (do trước đó lỡ double-click vào label hoặc form).
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }

        public FormKhachHang()
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
                P("@ma", txtMaKH.Text.Trim()),
                P("@ten", txtHoTen.Text.Trim()),
                P("@sdt", txtSDT.Text.Trim()),
                P("@email", ToDb(txtEmail.Text)),
                P("@diachi", ToDb(txtDiaChi.Text)),
                P("@tt", cboTrangThai.Text)
            };
        }

        /// <summary>Gợi ý mã mới: KH + (số lớn nhất hiện có + 1), ví dụ KH04.</summary>
        private string TaoMaMoi()
        {
            int max = 0;
            foreach (DataRow r in LayBang("SELECT MaKH FROM KhachHang").Rows)
            {
                string ma = r["MaKH"].ToString();
                int so;
                if (ma.StartsWith("KH", StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(ma.Substring(2), out so) && so > max)
                {
                    max = so;
                }
            }
            return "KH" + (max + 1).ToString("00");
        }

        // =====================================================================
        // CẤU HÌNH BAN ĐẦU
        // =====================================================================
        private void CauHinhBang()
        {
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Nối 6 cột đã add trong Designer với 6 cột của câu SELECT (theo thứ tự từ trái sang phải)
            string[] cot = { "MaKH", "HoTen", "SoDienThoai", "Email", "DiaChi", "TrangThai" };
            if (dgvKhachHang.Columns.Count == 0)
            {
                dgvKhachHang.AutoGenerateColumns = true; // chưa add cột nào thì để bảng tự sinh
            }
            else
            {
                dgvKhachHang.AutoGenerateColumns = false;
                for (int i = 0; i < cot.Length && i < dgvKhachHang.Columns.Count; i++)
                    dgvKhachHang.Columns[i].DataPropertyName = cot[i];
            }
        }

        // "-=" trước "+=" để dù đã double-click nút trong Designer thì sự kiện vẫn chỉ chạy 1 lần.
        private void GanSuKien()
        {
            Load -= FormKhachHang_Load; Load += FormKhachHang_Load;
            btnThem.Click -= btnThem_Click; btnThem.Click += btnThem_Click;
            btnSua.Click -= btnSua_Click; btnSua.Click += btnSua_Click;
            btnXoa.Click -= btnXoa_Click; btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click -= btnLamMoi_Click; btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click -= btnTim_Click; btnTim.Click += btnTim_Click;
            txtTimKiem.KeyDown -= txtTimKiem_KeyDown; txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            txtSDT.Leave -= txtSDT_Leave; txtSDT.Leave += txtSDT_Leave;
            dgvKhachHang.SelectionChanged -= dgvKhachHang_SelectionChanged;
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
        }

        // =====================================================================
        // NẠP DỮ LIỆU
        // =====================================================================
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            if (cboTrangThai.Items.Count == 0)
                cboTrangThai.Items.AddRange(new object[] { "Hoạt động", "Ngừng hoạt động" });
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            TaiLaiBang();
            LamMoiForm();
        }

        private void TaiLaiBang()
        {
            try
            {
                dangNap = true;
                dgvKhachHang.DataSource = LayBang(
                    @"SELECT MaKH, HoTen, SoDienThoai, Email, DiaChi, TrangThai
                      FROM KhachHang
                      WHERE MaKH LIKE @tk OR HoTen LIKE @tk OR SoDienThoai LIKE @tk OR Email LIKE @tk
                      ORDER BY MaKH",
                    P("@tk", "%" + txtTimKiem.Text.Trim() + "%"));
                dgvKhachHang.ClearSelection();
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

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dangNap || dgvKhachHang.SelectedRows.Count == 0) return;

            DataRowView dong = dgvKhachHang.SelectedRows[0].DataBoundItem as DataRowView;
            if (dong == null) return;

            txtMaKH.Text = Chuoi(dong["MaKH"]);
            txtHoTen.Text = Chuoi(dong["HoTen"]);
            txtSDT.Text = Chuoi(dong["SoDienThoai"]);
            txtEmail.Text = Chuoi(dong["Email"]);
            txtDiaChi.Text = Chuoi(dong["DiaChi"]);
            cboTrangThai.Text = Chuoi(dong["TrangThai"]);
            lblCanhBao.Text = "";
            txtMaKH.ReadOnly = true; // đang sửa: không cho đổi mã (khóa chính)
        }

        /// <summary>Đưa form về trạng thái nhập khách hàng mới.</summary>
        private void LamMoiForm()
        {
            try { txtMaKH.Text = TaoMaMoi(); }
            catch (SqlException) { txtMaKH.Text = ""; }

            txtMaKH.ReadOnly = false;
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            lblCanhBao.Text = "";
            dgvKhachHang.ClearSelection();
            txtHoTen.Focus();
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
            string ma = txtMaKH.Text.Trim();
            string ten = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (ma == "") return Loi("Vui lòng nhập mã khách hàng.", txtMaKH);
            if (ma.Contains(" ")) return Loi("Mã khách hàng không được chứa khoảng trắng.", txtMaKH);
            if (ten == "") return Loi("Vui lòng nhập họ tên.", txtHoTen);
            if (!Regex.IsMatch(sdt, @"^0\d{9}$"))
                return Loi("Số điện thoại phải gồm đúng 10 chữ số và bắt đầu bằng số 0.", txtSDT);
            if (email != "" && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return Loi("Email không đúng định dạng (ví dụ: ten@email.com).", txtEmail);
            return true;
        }

        /// <summary>Kiểm tra SĐT đã thuộc khách hàng khác chưa, đồng thời bật/tắt dòng cảnh báo đỏ.</summary>
        private bool TrungSDT()
        {
            lblCanhBao.Text = "";
            string sdt = txtSDT.Text.Trim();
            if (sdt == "") return false;

            try
            {
                object ten = LayGiaTri(
                    "SELECT TOP 1 HoTen FROM KhachHang WHERE SoDienThoai = @sdt AND MaKH <> @ma",
                    P("@sdt", sdt), P("@ma", txtMaKH.Text.Trim()));
                if (ten == null) return false;
                lblCanhBao.Text = "Số điện thoại đã tồn tại (khách hàng: " + ten + ")";
                return true;
            }
            catch (SqlException)
            {
                return false; // lỗi kết nối sẽ được báo ở bước lưu
            }
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            TrungSDT(); // cảnh báo ngay khi người dùng nhập xong ô SĐT
        }

        private void BaoLoiSql(SqlException ex)
        {
            string noiDung = (ex.Number == 2627 || ex.Number == 2601)
                ? "Dữ liệu bị trùng (mã khách hàng hoặc số điện thoại đã tồn tại)."
                : ex.Message;
            MessageBox.Show(noiDung, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // =====================================================================
        // CÁC NÚT
        // =====================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKH.ReadOnly)
            {
                MessageBox.Show("Bạn đang chọn một khách hàng có sẵn.\nBấm \"Làm mới\" để nhập khách hàng mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!HopLe()) return;

            try
            {
                int daCo = (int)LayGiaTri("SELECT COUNT(*) FROM KhachHang WHERE MaKH = @ma",
                    P("@ma", txtMaKH.Text.Trim()));
                if (daCo > 0)
                {
                    Loi("Mã khách hàng này đã tồn tại.", txtMaKH);
                    return;
                }
                if (TrungSDT())
                {
                    Loi("Số điện thoại này đã thuộc về khách hàng khác.", txtSDT);
                    return;
                }

                ChayLenh(
                    @"INSERT INTO KhachHang (MaKH, HoTen, SoDienThoai, Email, DiaChi, TrangThai)
                      VALUES (@ma, @ten, @sdt, @email, @diachi, @tt)",
                    ThamSoForm());

                MessageBox.Show("Thêm khách hàng thành công.", "Thông báo",
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
            if (!txtMaKH.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một khách hàng trong bảng trước khi sửa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!HopLe()) return;

            try
            {
                if (TrungSDT())
                {
                    Loi("Số điện thoại này đã thuộc về khách hàng khác.", txtSDT);
                    return;
                }

                ChayLenh(
                    @"UPDATE KhachHang
                      SET HoTen = @ten, SoDienThoai = @sdt, Email = @email, DiaChi = @diachi, TrangThai = @tt
                      WHERE MaKH = @ma",
                    ThamSoForm());

                MessageBox.Show("Cập nhật khách hàng thành công.", "Thông báo",
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
            if (!txtMaKH.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một khách hàng trong bảng trước khi xóa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult hoi = MessageBox.Show(
                "Bạn có chắc muốn xóa khách hàng \"" + txtHoTen.Text + "\" (" + txtMaKH.Text + ")?\n\n" +
                "Nếu khách hàng đã có phiếu xuất, hệ thống sẽ chuyển sang \"Ngừng hoạt động\" thay vì xóa hẳn.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            try
            {
                // Gọi stored procedure sp_XoaKhachHang, SP trả về câu thông báo kết quả
                string thongBao;
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_XoaKhachHang", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text.Trim());
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