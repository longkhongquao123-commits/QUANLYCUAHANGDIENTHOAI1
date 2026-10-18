using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyCuaHangDT
{
    /// <summary>
    /// Form quản lý nhân viên. TOÀN BỘ nằm trong 1 file này: chuỗi kết nối, câu lệnh SQL, xử lý giao diện.
    /// Các control (txtMaNV, dtpNgaySinh, dgvNhanVien...) nằm trong FormNhanVien.Designer.cs, KHÔNG khai báo lại.
    /// </summary>
    public partial class FormNhanVien : Form
    {
        // Chuỗi kết nối: đổi Server/Database cho đúng máy mày
        private readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=QuanLyCuaHangDienThoai;Trusted_Connection=True;TrustServerCertificate=True;";

        private bool dangNap;                  // true khi đang nạp bảng, để bỏ qua sự kiện chọn dòng
        private string trangThaiDangChon = ""; // trạng thái của nhân viên đang chọn (để biết có vừa đổi sang Nghỉ việc không)

        public FormNhanVien()
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
                P("@ma", txtMaNV.Text.Trim()),
                P("@ten", txtHoTen.Text.Trim()),
                P("@ns", dtpNgaySinh.Checked ? (object)dtpNgaySinh.Value.Date : DBNull.Value),
                P("@diachi", ToDb(txtDiaChi.Text)),
                P("@sdt", ToDb(txtSDT.Text)),
                P("@bophan", ToDb(txtBoPhan.Text)),
                P("@chucdanh", ToDb(txtChucDanh.Text)),
                P("@vaitro", cboVaiTro.Text),
                P("@tt", cboTrangThai.Text)
            };
        }

        /// <summary>Gợi ý mã mới: NV + (số lớn nhất hiện có + 1), ví dụ NV05.</summary>
        private string TaoMaMoi()
        {
            int max = 0;
            foreach (DataRow r in LayBang("SELECT MaNV FROM NhanVien").Rows)
            {
                string ma = r["MaNV"].ToString();
                int so;
                if (ma.StartsWith("NV", StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(ma.Substring(2), out so) && so > max)
                {
                    max = so;
                }
            }
            return "NV" + (max + 1).ToString("00");
        }

        /// <summary>
        /// Cập nhật nhân viên. Nếu trạng thái là "Nghỉ việc" thì khóa luôn tài khoản của nhân viên đó
        /// (cùng một giao dịch). Nếu đó là Quản lý hoạt động cuối cùng, trigger của TV1 sẽ báo lỗi
        /// và mọi thay đổi được hoàn tác.
        /// </summary>
        private void CapNhatNhanVien()
        {
            const string sql =
                @"UPDATE NhanVien
                  SET HoTen = @ten, NgaySinh = @ns, DiaChi = @diachi, SoDienThoai = @sdt,
                      BoPhan = @bophan, ChucDanh = @chucdanh, VaiTro = @vaitro, TrangThai = @tt
                  WHERE MaNV = @ma";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                        {
                            cmd.Parameters.AddRange(ThamSoForm());
                            cmd.ExecuteNonQuery();
                        }

                        if (cboTrangThai.Text == "Nghỉ việc")
                        {
                            using (SqlCommand cmd2 = new SqlCommand(
                                "UPDATE TaiKhoan SET TrangThai = N'Tạm khóa' WHERE MaNV = @ma", conn, tran))
                            {
                                cmd2.Parameters.AddWithValue("@ma", txtMaNV.Text.Trim());
                                cmd2.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        // Trigger đã tự ROLLBACK thì tran.Rollback() sẽ ném lỗi, bỏ qua lỗi đó.
                        try { tran.Rollback(); }
                        catch (InvalidOperationException) { }
                        catch (SqlException) { }
                        throw;
                    }
                }
            }
        }

        // =====================================================================
        // CẤU HÌNH BAN ĐẦU
        // =====================================================================
        private void CauHinhBang()
        {
            txtMaNV.MaxLength = 20;
            txtHoTen.MaxLength = 100;
            txtSDT.MaxLength = 11;
            txtDiaChi.MaxLength = 255;
            txtBoPhan.MaxLength = 50;
            txtChucDanh.MaxLength = 50;

            // DateTimePicker ngày sinh: có ô tích để cho phép "không có ngày sinh" (NULL trong DB)
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.MaxDate = DateTime.Today;
            dtpNgaySinh.ShowCheckBox = true;

            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Bảng hiện đủ 9 cột (trái sang phải), phải đúng thứ tự cột trong Designer
            string[] cot = { "MaNV", "HoTen", "NgaySinh", "SoDienThoai", "DiaChi",
                             "BoPhan", "ChucDanh", "VaiTro", "TrangThai" };
            if (dgvNhanVien.Columns.Count == 0)
            {
                dgvNhanVien.AutoGenerateColumns = true;
            }
            else
            {
                dgvNhanVien.AutoGenerateColumns = false;
                for (int i = 0; i < cot.Length && i < dgvNhanVien.Columns.Count; i++)
                    dgvNhanVien.Columns[i].DataPropertyName = cot[i];

                if (dgvNhanVien.Columns.Count > 2)
                    dgvNhanVien.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        // "-=" trước "+=" để dù đã double-click nút trong Designer thì sự kiện vẫn chỉ chạy 1 lần.
        private void GanSuKien()
        {
            Load -= FormNhanVien_Load; Load += FormNhanVien_Load;
            btnThem.Click -= btnThem_Click; btnThem.Click += btnThem_Click;
            btnSua.Click -= btnSua_Click; btnSua.Click += btnSua_Click;
            btnXoa.Click -= btnXoa_Click; btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click -= btnLamMoi_Click; btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click -= btnTim_Click; btnTim.Click += btnTim_Click;
            txtTimKiem.KeyDown -= txtTimKiem_KeyDown; txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            txtSDT.Leave -= txtSDT_Leave; txtSDT.Leave += txtSDT_Leave;
            cboTrangThai.SelectedIndexChanged -= cboTrangThai_SelectedIndexChanged;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
            dgvNhanVien.SelectionChanged -= dgvNhanVien_SelectionChanged;
            dgvNhanVien.SelectionChanged += dgvNhanVien_SelectionChanged;
        }

        // =====================================================================
        // NẠP DỮ LIỆU
        // =====================================================================
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // Nếu chưa thêm Items trong Designer thì code tự thêm (chữ phải đúng với CHECK trong DB)
            if (cboVaiTro.Items.Count == 0)
                cboVaiTro.Items.AddRange(new object[] { "Quản lý", "Nhân viên bán hàng", "Nhân viên kho/kỹ thuật" });
            if (cboTrangThai.Items.Count == 0)
                cboTrangThai.Items.AddRange(new object[] { "Đang làm việc", "Nghỉ việc" });
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            TaiLaiBang();
            LamMoiForm();
        }

        private void TaiLaiBang()
        {
            try
            {
                dangNap = true;
                dgvNhanVien.DataSource = LayBang(
                    @"SELECT MaNV, HoTen, NgaySinh, SoDienThoai, DiaChi, BoPhan, ChucDanh, VaiTro, TrangThai
                      FROM NhanVien
                      WHERE MaNV LIKE @tk OR HoTen LIKE @tk OR SoDienThoai LIKE @tk
                         OR BoPhan LIKE @tk OR ChucDanh LIKE @tk OR VaiTro LIKE @tk
                      ORDER BY MaNV",
                    P("@tk", "%" + txtTimKiem.Text.Trim() + "%"));
                dgvNhanVien.ClearSelection();
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

        /// <summary>Đặt ngày cho DateTimePicker; null thì bỏ tích ô chọn.</summary>
        private void DatNgay(DateTime? ngay)
        {
            if (!ngay.HasValue)
            {
                dtpNgaySinh.Checked = false;
                return;
            }
            DateTime d = ngay.Value;
            if (d < dtpNgaySinh.MinDate) d = dtpNgaySinh.MinDate;
            if (d > dtpNgaySinh.MaxDate) d = dtpNgaySinh.MaxDate;
            dtpNgaySinh.Value = d;
            dtpNgaySinh.Checked = true;
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dangNap || dgvNhanVien.SelectedRows.Count == 0) return;

            DataRowView dong = dgvNhanVien.SelectedRows[0].DataBoundItem as DataRowView;
            if (dong == null) return;

            txtMaNV.Text = Chuoi(dong["MaNV"]);
            txtHoTen.Text = Chuoi(dong["HoTen"]);
            DatNgay(dong["NgaySinh"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dong["NgaySinh"]));
            txtSDT.Text = Chuoi(dong["SoDienThoai"]);
            txtDiaChi.Text = Chuoi(dong["DiaChi"]);
            txtBoPhan.Text = Chuoi(dong["BoPhan"]);
            txtChucDanh.Text = Chuoi(dong["ChucDanh"]);
            cboVaiTro.Text = Chuoi(dong["VaiTro"]);
            cboTrangThai.Text = Chuoi(dong["TrangThai"]);

            trangThaiDangChon = cboTrangThai.Text;
            CapNhatCanhBao();
            txtMaNV.ReadOnly = true; // đang sửa: không cho đổi mã (khóa chính)
        }

        /// <summary>Đưa form về trạng thái nhập nhân viên mới.</summary>
        private void LamMoiForm()
        {
            try { txtMaNV.Text = TaoMaMoi(); }
            catch (SqlException) { txtMaNV.Text = ""; }

            txtMaNV.ReadOnly = false;
            txtHoTen.Clear();
            DatNgay(new DateTime(2000, 1, 1));
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtBoPhan.Clear();
            txtChucDanh.Clear();
            if (cboVaiTro.Items.Count > 0) cboVaiTro.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            trangThaiDangChon = "";
            CapNhatCanhBao();
            dgvNhanVien.ClearSelection();
            txtHoTen.Focus();
        }

        // =====================================================================
        // CẢNH BÁO & KIỂM TRA DỮ LIỆU
        // =====================================================================
        private void txtSDT_Leave(object sender, EventArgs e)
        {
            CapNhatCanhBao();
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatCanhBao();
        }

        /// <summary>Một nhãn đỏ hiện được cả 2 cảnh báo: trùng SĐT và "Nghỉ việc" sẽ khóa tài khoản (không chặn lưu).</summary>
        private void CapNhatCanhBao()
        {
            string canhBao = "";

            string sdt = txtSDT.Text.Trim();
            if (sdt != "")
            {
                try
                {
                    object ten = LayGiaTri(
                        "SELECT TOP 1 HoTen FROM NhanVien WHERE SoDienThoai = @sdt AND MaNV <> @ma",
                        P("@sdt", sdt), P("@ma", txtMaNV.Text.Trim()));
                    if (ten != null)
                        canhBao = "Số điện thoại đã tồn tại (nhân viên: " + ten + ")";
                }
                catch (SqlException) { }
            }

            if (cboTrangThai.Text == "Nghỉ việc")
            {
                if (canhBao != "") canhBao += "  |  ";
                canhBao += "Chọn \"Nghỉ việc\" sẽ tự khóa tài khoản";
            }
            lblCanhBao.Text = canhBao;
        }

        private bool Loi(string noiDung, Control oLoi)
        {
            MessageBox.Show(noiDung, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            oLoi.Focus();
            return false;
        }

        private bool HopLe()
        {
            string ma = txtMaNV.Text.Trim();
            string ten = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (ma == "") return Loi("Vui lòng nhập mã nhân viên.", txtMaNV);
            if (ma.Contains(" ")) return Loi("Mã nhân viên không được chứa khoảng trắng.", txtMaNV);
            if (ten == "") return Loi("Vui lòng nhập họ tên.", txtHoTen);

            if (dtpNgaySinh.Checked)
            {
                DateTime ns = dtpNgaySinh.Value.Date;
                int tuoi = DateTime.Today.Year - ns.Year;
                if (ns > DateTime.Today.AddYears(-tuoi)) tuoi--;
                if (tuoi < 16) return Loi("Nhân viên phải từ 16 tuổi trở lên.", dtpNgaySinh);
            }

            if (!Regex.IsMatch(sdt, @"^0\d{9}$"))
                return Loi("Số điện thoại phải gồm đúng 10 chữ số và bắt đầu bằng số 0.", txtSDT);
            if (cboVaiTro.SelectedIndex < 0) return Loi("Vui lòng chọn vai trò.", cboVaiTro);
            if (cboTrangThai.SelectedIndex < 0) return Loi("Vui lòng chọn trạng thái.", cboTrangThai);
            return true;
        }

        /// <summary>
        /// Lấy câu báo lỗi từ trigger (RAISERROR mặc định mang mã 50000).
        /// Nếu không phải lỗi của trigger thì dùng thông điệp SQL thông thường.
        /// </summary>
        private static string LayThongDiep(SqlException ex)
        {
            foreach (SqlError loi in ex.Errors)
            {
                if (loi.Number == 50000) return loi.Message;
            }
            return ex.Message;
        }

        private void BaoLoiSql(SqlException ex)
        {
            string noiDung;
            if (ex.Number == 2627 || ex.Number == 2601)
                noiDung = "Dữ liệu bị trùng (mã nhân viên đã tồn tại).";
            else if (ex.Number == 547)
                noiDung = "Không thể xóa: nhân viên này đã có tài khoản kèm lịch sử hoạt động.\n" +
                          "Hãy chọn Sửa và đổi trạng thái sang \"Nghỉ việc\" thay vì xóa.";
            else
                noiDung = LayThongDiep(ex);
            MessageBox.Show(noiDung, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // =====================================================================
        // CÁC NÚT
        // =====================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.ReadOnly)
            {
                MessageBox.Show("Bạn đang chọn một nhân viên có sẵn.\nBấm \"Làm mới\" để nhập nhân viên mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!HopLe()) return;

            try
            {
                int daCo = (int)LayGiaTri("SELECT COUNT(*) FROM NhanVien WHERE MaNV = @ma",
                    P("@ma", txtMaNV.Text.Trim()));
                if (daCo > 0)
                {
                    Loi("Mã nhân viên này đã tồn tại.", txtMaNV);
                    return;
                }

                ChayLenh(
                    @"INSERT INTO NhanVien (MaNV, HoTen, NgaySinh, DiaChi, SoDienThoai, BoPhan, ChucDanh, VaiTro, TrangThai)
                      VALUES (@ma, @ten, @ns, @diachi, @sdt, @bophan, @chucdanh, @vaitro, @tt)",
                    ThamSoForm());

                MessageBox.Show("Thêm nhân viên thành công.", "Thông báo",
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
            if (!txtMaNV.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một nhân viên trong bảng trước khi sửa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!HopLe()) return;

            // Vừa đổi sang "Nghỉ việc" => hỏi lại vì sẽ khóa tài khoản
            if (cboTrangThai.Text == "Nghỉ việc" && trangThaiDangChon != "Nghỉ việc")
            {
                DialogResult hoi = MessageBox.Show(
                    "Chuyển nhân viên \"" + txtHoTen.Text + "\" sang \"Nghỉ việc\" sẽ tự động khóa tài khoản đăng nhập.\n\nTiếp tục?",
                    "Xác nhận nghỉ việc", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hoi != DialogResult.Yes) return;
            }

            try
            {
                CapNhatNhanVien();
                MessageBox.Show("Cập nhật nhân viên thành công.", "Thông báo",
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
            if (!txtMaNV.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một nhân viên trong bảng trước khi xóa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult hoi = MessageBox.Show(
                "Bạn có chắc muốn xóa nhân viên \"" + txtHoTen.Text + "\" (" + txtMaNV.Text + ")?\n\n" +
                "Nếu nhân viên đã có chứng từ hoặc lịch sử hoạt động, hệ thống sẽ chuyển sang \"Nghỉ việc\" " +
                "và khóa tài khoản thay vì xóa hẳn.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            try
            {
                // Gọi stored procedure sp_XoaNhanVien, SP trả về câu thông báo kết quả
                string thongBao;
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text.Trim());
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