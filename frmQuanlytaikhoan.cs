using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WindowsFormsQuanLyDienThoai12
{
    public partial class Form3 : Form
    {
        private const string ChuoiKetNoi =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;" +
            "Integrated Security=True;TrustServerCertificate=True";

        private const string HoatDong = "Hoạt động";
        private const string TamKhoa = "Tạm khóa";

        // true khi đang nhập tài khoản mới
        private bool _dangThem = false;

        public Form3()
        {
            InitializeComponent();
            GanSuKien();
        }

        private void GanSuKien()
        {
            Load -= Form3_Load;
            Load += Form3_Load;

            dgvTaiKhoan.SelectionChanged -= dgvTaiKhoan_SelectionChanged;
            dgvTaiKhoan.SelectionChanged += dgvTaiKhoan_SelectionChanged;

            btnThem.Click -= btnThem_Click;
            btnThem.Click += btnThem_Click;

            btnLuu.Click -= btnLuu_Click;
            btnLuu.Click += btnLuu_Click;

            btnXoa.Click -= btnXoa_Click;
            btnXoa.Click += btnXoa_Click;

            btnKhoaMo.Click -= btnKhoaMo_Click;
            btnKhoaMo.Click += btnKhoaMo_Click;

            btnLamMoi.Click -= btnLamMoi_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            btnDoiMatKhau.Click -= btnDoiMatKhau_Click;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;

            btnDong.Click -= btnDong_Click;
            btnDong.Click += btnDong_Click;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txtSoLanSai.ReadOnly = true;
            txtTrangThai.ReadOnly = true;

            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            TaiDanhSach(null);
        }

        // ================== TẢI DỮ LIỆU ==================

        private void TaiDanhSach(string chon)
        {
            const string sql = @"
                SELECT tk.TenDangNhap, tk.MaNV, nv.HoTen, nv.VaiTro, tk.TrangThai,
                       tk.SoLanDangNhapSai, tk.LanDangNhapCuoiCung
                FROM TaiKhoan tk
                INNER JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                ORDER BY tk.TenDangNhap";

            dgvTaiKhoan.DataSource = LayBang(sql);
            DatTieuDeCot();
            ChonDong(chon);
        }

        private void DatTieuDeCot()
        {
            DatTieuDe("TenDangNhap", "Tên đăng nhập");
            DatTieuDe("MaNV", "Mã NV");
            DatTieuDe("HoTen", "Họ tên");
            DatTieuDe("VaiTro", "Vai trò");
            DatTieuDe("TrangThai", "Trạng thái");
            DatTieuDe("SoLanDangNhapSai", "Số lần sai");
            DatTieuDe("LanDangNhapCuoiCung", "Đăng nhập cuối");
        }

        private void DatTieuDe(string tenCot, string tieuDe)
        {
            if (dgvTaiKhoan.Columns.Contains(tenCot))
                dgvTaiKhoan.Columns[tenCot].HeaderText = tieuDe;
        }

        // Chọn lại dòng vừa thao tác, nếu không có thì chọn dòng đầu
        private void ChonDong(string ten)
        {
            if (dgvTaiKhoan.Rows.Count == 0)
            {
                XoaO();
                return;
            }

            foreach (DataGridViewRow row in dgvTaiKhoan.Rows)
            {
                if (ten != null && Str(row.Cells["TenDangNhap"].Value) == ten)
                {
                    dgvTaiKhoan.CurrentCell = row.Cells["TenDangNhap"];
                    return;
                }
            }

            dgvTaiKhoan.CurrentCell = dgvTaiKhoan.Rows[0].Cells["TenDangNhap"];
        }

        // ================== CHỌN DÒNG ==================

        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;

            DataGridViewRow r = dgvTaiKhoan.CurrentRow;
            _dangThem = false;

            txtTenDangNhap.Text = Str(r.Cells["TenDangNhap"].Value);
            txtTenDangNhap.ReadOnly = true;
            txtMatKhau.Clear();
            txtNhanVien.Text = Str(r.Cells["MaNV"].Value);
            txtTrangThai.Text = Str(r.Cells["TrangThai"].Value);
            txtSoLanSai.Text = Str(r.Cells["SoLanDangNhapSai"].Value);
        }

        private string TenDangChon()
        {
            if (dgvTaiKhoan.CurrentRow == null) return null;
            return Str(dgvTaiKhoan.CurrentRow.Cells["TenDangNhap"].Value);
        }

        // ================== THÊM ==================

        private void btnThem_Click(object sender, EventArgs e)
        {
            _dangThem = true;
            XoaO();
            txtTenDangNhap.ReadOnly = false;
            txtTenDangNhap.Focus();
        }

        private void ThemTaiKhoan()
        {
            string ten = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string maNV = txtNhanVien.Text.Trim();

            if (ten == "" || matKhau == "")
            {
                Thong("Nhập tên đăng nhập và mật khẩu.", MessageBoxIcon.Warning);
                return;
            }
            if (maNV == "")
            {
                Thong("Nhập mã nhân viên.", MessageBoxIcon.Warning);
                return;
            }
            if (!KiemTraNhanVien(maNV))
            {
                Thong("Mã nhân viên " + maNV + " không tồn tại.", MessageBoxIcon.Warning);
                return;
            }

            string hash = BCrypt.Net.BCrypt.HashPassword(matKhau);

            try
            {
                ChayLenh(@"INSERT INTO TaiKhoan (TenDangNhap, MatKhauHash, MaNV, SoLanDangNhapSai, TrangThai)
                           VALUES (@Ten, @Hash, @MaNV, 0, N'Hoạt động')",
                         P("@Ten", ten), P("@Hash", hash), P("@MaNV", maNV));
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Thong("Tên đăng nhập này đã tồn tại.", MessageBoxIcon.Warning);
                return;
            }
            catch (SqlException ex)
            {
                Thong("Không thêm được tài khoản: " + ex.Message, MessageBoxIcon.Error);
                return;
            }

            _dangThem = false;
            txtTenDangNhap.ReadOnly = true;
            TaiDanhSach(ten);
            Thong("Đã thêm tài khoản " + ten + ".", MessageBoxIcon.Information);
        }

        // ================== LƯU ==================

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_dangThem)
            {
                ThemTaiKhoan();
                return;
            }

            string ten = TenDangChon();
            if (ten == null)
            {
                Thong("Chọn một tài khoản trong bảng trước.", MessageBoxIcon.Warning);
                return;
            }

            string maNV = txtNhanVien.Text.Trim();
            if (maNV == "")
            {
                Thong("Nhập mã nhân viên.", MessageBoxIcon.Warning);
                return;
            }
            if (!KiemTraNhanVien(maNV))
            {
                Thong("Mã nhân viên " + maNV + " không tồn tại.", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ChayLenh("UPDATE TaiKhoan SET MaNV = @MaNV WHERE TenDangNhap = @Ten",
                         P("@MaNV", maNV), P("@Ten", ten));
            }
            catch (SqlException ex)
            {
                Thong("Không lưu được: " + ex.Message, MessageBoxIcon.Error);
                return;
            }

            TaiDanhSach(ten);
            Thong("Đã lưu thay đổi cho " + ten + ".", MessageBoxIcon.Information);
        }

        // ================== XÓA ==================

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ten = TenDangChon();
            if (ten == null)
            {
                Thong("Chọn một tài khoản trong bảng trước.", MessageBoxIcon.Warning);
                return;
            }
            if (ten == Session.TenDangNhap)
            {
                Thong("Không thể xóa tài khoản đang đăng nhập.", MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(this, "Xóa tài khoản " + ten + "?", "Xác nhận",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                ChayLenh("DELETE FROM TaiKhoan WHERE TenDangNhap = @Ten", P("@Ten", ten));
            }
            catch (SqlException)
            {
                Thong("Không xóa được tài khoản này vì đã có dữ liệu liên quan. " +
                      "Hãy dùng nút Khóa/Mở khóa.", MessageBoxIcon.Warning);
                return;
            }

            TaiDanhSach(null);
            Thong("Đã xóa tài khoản " + ten + ".", MessageBoxIcon.Information);
        }

        // ================== KHÓA / MỞ KHÓA ==================

        private void btnKhoaMo_Click(object sender, EventArgs e)
        {
            string ten = TenDangChon();
            if (ten == null)
            {
                Thong("Chọn một tài khoản trong bảng trước.", MessageBoxIcon.Warning);
                return;
            }

            string hienTai = Str(dgvTaiKhoan.CurrentRow.Cells["TrangThai"].Value);
            string moi = hienTai == HoatDong ? TamKhoa : HoatDong;

            if (ten == Session.TenDangNhap && moi == TamKhoa)
            {
                Thong("Không thể khóa tài khoản đang đăng nhập.", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Mở khóa thì đặt lại số lần sai về 0
                ChayLenh(@"UPDATE TaiKhoan
                           SET TrangThai = @TrangThai,
                               SoLanDangNhapSai = CASE WHEN @TrangThai = N'Hoạt động' THEN 0 ELSE SoLanDangNhapSai END
                           WHERE TenDangNhap = @Ten",
                         P("@TrangThai", moi), P("@Ten", ten));
            }
            catch (SqlException ex)
            {
                // Trigger không cho khóa quản lý hoạt động cuối cùng sẽ báo lỗi ở đây
                Thong("Không đổi được trạng thái: " + ex.Message, MessageBoxIcon.Error);
                return;
            }

            TaiDanhSach(ten);
        }

        // ================== LÀM MỚI ==================

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _dangThem = false;
            txtTenDangNhap.ReadOnly = true;
            TaiDanhSach(TenDangChon());
        }

        // ================== ĐỔI MẬT KHẨU ==================

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string ten = TenDangChon();
            if (ten == null)
            {
                Thong("Chọn một tài khoản trong bảng trước.", MessageBoxIcon.Warning);
                return;
            }

            string cu = txtMatKhauCu.Text;
            string moi = txtMatKhauMoi.Text;
            string nhapLai = txtNhapLai.Text;

            if (cu == "" || moi == "" || nhapLai == "")
            {
                Thong("Nhập đủ mật khẩu cũ, mật khẩu mới và nhập lại.", MessageBoxIcon.Warning);
                return;
            }
            if (moi != nhapLai)
            {
                Thong("Mật khẩu nhập lại không khớp.", MessageBoxIcon.Warning);
                return;
            }
            if (moi.Length < 6)
            {
                Thong("Mật khẩu mới phải có ít nhất 6 ký tự.", MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = LayBang("SELECT MatKhauHash FROM TaiKhoan WHERE TenDangNhap = @Ten", P("@Ten", ten));
            if (dt.Rows.Count == 0) return;

            string hashCu = Str(dt.Rows[0]["MatKhauHash"]);
            if (!KiemTraMatKhauCu(cu, hashCu))
            {
                Thong("Mật khẩu cũ không đúng.", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ChayLenh("UPDATE TaiKhoan SET MatKhauHash = @Hash WHERE TenDangNhap = @Ten",
                         P("@Hash", BCrypt.Net.BCrypt.HashPassword(moi)), P("@Ten", ten));
            }
            catch (SqlException ex)
            {
                Thong("Không đổi được mật khẩu: " + ex.Message, MessageBoxIcon.Error);
                return;
            }

            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtNhapLai.Clear();
            Thong("Đã đổi mật khẩu cho " + ten + ".", MessageBoxIcon.Information);
        }

        private bool KiemTraMatKhauCu(string nhap, string hash)
        {
            // Hash BCrypt bắt đầu bằng "$2"; dữ liệu mẫu có thể còn lưu chữ thường
            if (hash.StartsWith("$2"))
                return BCrypt.Net.BCrypt.Verify(nhap, hash);
            return nhap == hash;
        }

        // ================== ĐÓNG ==================

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ================== TIỆN ÍCH ==================

        private void XoaO()
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtSoLanSai.Clear();
            txtNhanVien.Clear();
            txtTrangThai.Text = HoatDong;
            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtNhapLai.Clear();
        }

        private bool KiemTraNhanVien(string maNV)
        {
            DataTable dt = LayBang("SELECT COUNT(*) FROM NhanVien WHERE MaNV = @Ma", P("@Ma", maNV));
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Chuyển giá trị bất kỳ thành chuỗi, null hoặc DBNull thành chuỗi rỗng
        private static string Str(object giaTri)
        {
            if (giaTri == null || giaTri == DBNull.Value) return "";
            return giaTri.ToString();
        }

        private static SqlParameter P(string ten, object giaTri)
        {
            return new SqlParameter(ten, giaTri ?? DBNull.Value);
        }

        private DataTable LayBang(string sql, params SqlParameter[] thamSo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ChuoiKetNoi))
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                if (thamSo != null && thamSo.Length > 0)
                    da.SelectCommand.Parameters.AddRange(thamSo);
                da.Fill(dt);
            }
            return dt;
        }

        private void ChayLenh(string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = new SqlConnection(ChuoiKetNoi))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (thamSo != null && thamSo.Length > 0)
                    cmd.Parameters.AddRange(thamSo);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void Thong(string noiDung, MessageBoxIcon icon)
        {
            MessageBox.Show(this, noiDung, "Quản lý tài khoản", MessageBoxButtons.OK, icon);
        }
    }
}