using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QUANLYCUAHANGDIENTHOAI
{
    public partial class FormTrangChu : Form
    {
        string strKetNoi = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private Form currentChildForm = null;
        private Button currentActiveButton = null;

        // Bộ đếm kiểm tra thời hạn phiên đăng nhập tự động
        private System.Windows.Forms.Timer timerKiemTraPhien;
        private bool daHuyPhien = false;

        // Thông tin tài khoản đang đăng nhập
        public string MaNVDangNhap = "NV01";
        public string HoTenDangNhap = "Nguyễn Đức Huy";
        public string VaiTroDangNhap = "Quản lý";

        public FormTrangChu()
        {
            InitializeComponent();
            GanSuKienMenu();
            KhoiTaoBoDemPhien();

            // Đảm bảo sự kiện Load, Đóng Form và đổi quyền luôn được kích hoạt
            this.Load -= FormTrangChu_Load;
            this.Load += FormTrangChu_Load;

            this.FormClosing -= FormTrangChu_FormClosing;
            this.FormClosing += FormTrangChu_FormClosing;

            if (cboGiaLapQuyen != null)
            {
                cboGiaLapQuyen.SelectedIndexChanged -= cboGiaLapQuyen_SelectedIndexChanged;
                cboGiaLapQuyen.SelectedIndexChanged += cboGiaLapQuyen_SelectedIndexChanged;
            }
        }

        // Constructor nhận thông tin từ FormDangNhap truyền sang
        public FormTrangChu(string maNV, string hoTen, string vaiTro) : this()
        {
            this.MaNVDangNhap = maNV;
            this.HoTenDangNhap = hoTen;
            this.VaiTroDangNhap = ChuanHoaTenVaiTro(vaiTro);

            // Lưu đồng bộ vào AuthHelper
            AuthHelper.MaNV = this.MaNVDangNhap;
            AuthHelper.HoTen = this.HoTenDangNhap;
            AuthHelper.VaiTro = this.VaiTroDangNhap;
        }

        // =========================================================================
        // 0. QUẢN LÝ PHIÊN: KIỂM TRA HẾT HẠN TỰ ĐỘNG & HỦY PHIÊN KHI ĐĂNG XUẤT
        // =========================================================================
        private void KhoiTaoBoDemPhien()
        {
            timerKiemTraPhien = new System.Windows.Forms.Timer(); timerKiemTraPhien.Interval = 10000; // Kiểm tra mỗi 10 giây (10.000 ms)
            timerKiemTraPhien.Tick += TimerKiemTraPhien_Tick;
            timerKiemTraPhien.Start();
        }

        private void TimerKiemTraPhien_Tick(object sender, EventArgs e)
        {
            // Nếu không có mã phiên (chạy test trực tiếp FormTrangChu) thì bỏ qua
            if (string.IsNullOrEmpty(AuthHelper.MaPhien) || daHuyPhien) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(strKetNoi))
                {
                    conn.Open();

                    // Kiểm tra xem phiên có bị quá giờ GioHetHieuLuc hoặc tài khoản bị khóa đột xuất không
                    string sqlCheck = @"
                        SELECT p.GioHetHieuLuc, p.TrangThaiPhien, tk.TrangThai AS TrangThaiTK
                        FROM PhienDangNhap p
                        INNER JOIN TaiKhoan tk ON p.TenDangNhap = tk.TenDangNhap
                        WHERE p.MaPhien = @MaPhien";

                    SqlCommand cmd = new SqlCommand(sqlCheck, conn);
                    cmd.Parameters.AddWithValue("@MaPhien", AuthHelper.MaPhien);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            DateTime gioHetHan = Convert.ToDateTime(r["GioHetHieuLuc"]);
                            string trangThaiPhien = r["TrangThaiPhien"].ToString();
                            string trangThaiTK = r["TrangThaiTK"].ToString();
                            r.Close();

                            // 1. Trường hợp quá thời gian hiệu lực của phiên
                            if (DateTime.Now >= gioHetHan || trangThaiPhien == "Hết hạn")
                            {
                                timerKiemTraPhien.Stop();
                                HuyPhienTrongSQL("Hết hạn", "Phiên làm việc tự động kết thúc do hết thời gian hiệu lực");
                                MessageBox.Show("Phiên đăng nhập của bạn đã hết hạn!\nVui lòng đăng nhập lại để tiếp tục làm việc.", "Hết hạn phiên làm việc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close();
                            }
                            // 2. Trường hợp tài khoản bị Quản lý khóa ngay khi đang đăng nhập
                            else if (trangThaiTK == "Tạm khóa" || trangThaiTK == "Khóa")
                            {
                                timerKiemTraPhien.Stop();
                                HuyPhienTrongSQL("Đã đăng xuất", "Bị cưỡng chế đăng xuất do tài khoản bị khóa");
                                MessageBox.Show("Tài khoản của bạn vừa bị Quản trị viên tạm khóa!", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch
            {
                // Bỏ qua nếu kết nối SQL chập chờn tạm thời
            }
        }

        // Hàm Hủy phiên trong SQL + Ghi Nhật ký hệ thống + Xóa RAM
        private void HuyPhienTrongSQL(string trangThaiKetThuc, string lyDoChiTiet)
        {
            if (daHuyPhien) return;
            daHuyPhien = true;

            if (timerKiemTraPhien != null) timerKiemTraPhien.Stop();

            try
            {
                using (SqlConnection conn = new SqlConnection(strKetNoi))
                {
                    conn.Open();

                    // Lấy tên đăng nhập từ AuthHelper (nếu rỗng thì truy xuất theo MaNV)
                    string tenDN = AuthHelper.TenDangNhap;
                    if (string.IsNullOrEmpty(tenDN))
                    {
                        SqlCommand cmdGetUser = new SqlCommand("SELECT TOP 1 TenDangNhap FROM TaiKhoan WHERE MaNV = @MaNV", conn);
                        cmdGetUser.Parameters.AddWithValue("@MaNV", MaNVDangNhap);
                        object res = cmdGetUser.ExecuteScalar();
                        if (res != null) tenDN = res.ToString();
                    }

                    // 1. Cập nhật bảng PhienDangNhap (Nếu có MaPhien thì đóng theo MaPhien, không thì đóng các phiên đang mở của User đó)
                    if (!string.IsNullOrEmpty(AuthHelper.MaPhien))
                    {
                        string sqlUpdatePhien = @"
                            UPDATE PhienDangNhap 
                            SET GioDangXuat = GETDATE(), TrangThaiPhien = @TrangThai 
                            WHERE MaPhien = @MaPhien";
                        SqlCommand cmdPhien = new SqlCommand(sqlUpdatePhien, conn);
                        cmdPhien.Parameters.AddWithValue("@TrangThai", trangThaiKetThuc);
                        cmdPhien.Parameters.AddWithValue("@MaPhien", AuthHelper.MaPhien);
                        cmdPhien.ExecuteNonQuery();
                    }
                    else if (!string.IsNullOrEmpty(tenDN))
                    {
                        string sqlUpdateAll = @"
                            UPDATE PhienDangNhap 
                            SET GioDangXuat = GETDATE(), TrangThaiPhien = @TrangThai 
                            WHERE TenDangNhap = @User AND TrangThaiPhien = N'Đang hoạt động'";
                        SqlCommand cmdAll = new SqlCommand(sqlUpdateAll, conn);
                        cmdAll.Parameters.AddWithValue("@TrangThai", trangThaiKetThuc);
                        cmdAll.Parameters.AddWithValue("@User", tenDN);
                        cmdAll.ExecuteNonQuery();
                    }

                    // 2. Ghi nhận vào bảng NhatKyHeThong
                    if (!string.IsNullOrEmpty(tenDN))
                    {
                        string sqlLog = @"
                            INSERT INTO NhatKyHeThong (TenDangNhap, ThoiGian, LoaiHanhDong, DoiTuong, MoTaChiTiet)
                            VALUES (@User, GETDATE(), N'Đăng xuất', N'Hệ thống', @MoTa)";
                        SqlCommand cmdLog = new SqlCommand(sqlLog, conn);
                        cmdLog.Parameters.AddWithValue("@User", tenDN);
                        cmdLog.Parameters.AddWithValue("@MoTa", $"{lyDoChiTiet} (IP: {AuthHelper.DiaChiIP})");
                        cmdLog.ExecuteNonQuery();
                    }
                }
            }
            catch { }
            finally
            {
                // 3. Xóa sạch thông tin phiên trên RAM
                AuthHelper.XoaPhien();
            }
        }

        // Xử lý nút Đăng xuất
        private void ThucHienDangXuat()
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất và kết thúc phiên làm việc hiện tại?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                HuyPhienTrongSQL("Đã đăng xuất", "Người dùng chủ động đăng xuất khỏi hệ thống");
                this.Close(); // Đóng FormTrangChu để quay về FormDangNhap
            }
        }

        // Đảm bảo nếu người dùng bấm nút X góc phải cửa sổ thì phiên trong SQL vẫn được hủy sạch sẽ
        private void FormTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!daHuyPhien)
            {
                HuyPhienTrongSQL("Đã đăng xuất", "Đóng cửa sổ ứng dụng");
            }
        }

        // Chuẩn hóa tên vai trò từ SQL về đúng 3 vai trò chuẩn
        private string ChuanHoaTenVaiTro(string rawRole)
        {
            if (string.IsNullOrWhiteSpace(rawRole)) return "Nhân viên bán hàng";
            string r = rawRole.Trim().ToLower();

            if (r.Contains("quản lý") || r.Contains("quan ly") || r.Contains("admin"))
                return "Quản lý";
            if (r.Contains("bán hàng") || r.Contains("ban hang"))
                return "Nhân viên bán hàng";
            if (r.Contains("kho") || r.Contains("kỹ thuật") || r.Contains("ky thuat"))
                return "Nhân viên kho/kỹ thuật";

            return rawRole.Trim();
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            cboGiaLapQuyen.SelectedIndexChanged -= cboGiaLapQuyen_SelectedIndexChanged;
            cboGiaLapQuyen.Items.Clear();
            cboGiaLapQuyen.Items.Add("Quản lý");
            cboGiaLapQuyen.Items.Add("Nhân viên bán hàng");
            cboGiaLapQuyen.Items.Add("Nhân viên kho/kỹ thuật");
            cboGiaLapQuyen.SelectedItem = VaiTroDangNhap;
            cboGiaLapQuyen.SelectedIndexChanged += cboGiaLapQuyen_SelectedIndexChanged;

            if (VaiTroDangNhap != "Quản lý")
            {
                cboGiaLapQuyen.Visible = false;
            }

            ApDungPhanQuyen(VaiTroDangNhap);
            TaiDuLieuDashboardTuSQL();
            DoiMauNutDangChon(btnDashboard);
        }

        // =========================================================================
        // 1. TẢI SỐ LIỆU THỰC TẾ TỪ SQL LÊN DASHBOARD
        // =========================================================================
        private void TaiDuLieuDashboardTuSQL()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKetNoi))
                {
                    conn.Open();

                    SqlCommand cmdSP = new SqlCommand("SELECT COUNT(*) FROM SanPham WHERE TrangThai = N'Đang kinh doanh'", conn);
                    lblSoSanPham.Text = cmdSP.ExecuteScalar().ToString() + " mặt hàng";

                    SqlCommand cmdCB = new SqlCommand("SELECT COUNT(*) FROM SanPham WHERE SoLuongTon <= ISNULL(NguongTonToiThieu, 5)", conn);
                    lblSoCanhBao.Text = cmdCB.ExecuteScalar().ToString() + " sắp hết";

                    SqlCommand cmdDT = new SqlCommand("SELECT ISNULL(SUM(ThanhToan), 0) FROM PhieuXuat WHERE TrangThai = N'Hoàn tất'", conn);
                    decimal doanhThu = Convert.ToDecimal(cmdDT.ExecuteScalar());
                    lblTongDoanhThu.Text = doanhThu.ToString("N0") + " đ";

                    SqlCommand cmdKH = new SqlCommand("SELECT COUNT(*) FROM KhachHang WHERE TrangThai = N'Hoạt động'", conn);
                    lblSoKhachHang.Text = cmdKH.ExecuteScalar().ToString() + " khách";

                    string sqlGrid = @"
                        SELECT 
                            sp.MaSP AS [Mã SP],
                            sp.TenSP AS [Tên Sản Phẩm],
                            dm.TenDanhMuc AS [Danh Mục],
                            sp.GiaBanHienTai AS [Giá Bán Hiện Hành],
                            sp.SoLuongTon AS [Tồn Kho],
                            ISNULL(sp.NguongTonToiThieu, 5) AS [Ngưỡng Tối Thiểu],
                            CASE 
                                WHEN sp.SoLuongTon <= ISNULL(sp.NguongTonToiThieu, 5) THEN N'⚠️ Sắp hết hàng (Cần nhập thêm)'
                                ELSE N'✅ Đủ tồn kho'
                            END AS [Tình Trạng Kho]
                        FROM SanPham sp
                        LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                        ORDER BY sp.SoLuongTon ASC";

                    SqlDataAdapter da = new SqlDataAdapter(sqlGrid, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCanhBaoTon.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải số liệu tổng quan từ CSDL: " + ex.Message, "Thông báo SQL");
            }
        }

        // =========================================================================
        // 2. PHÂN QUYỀN ẨN/HIỆN NÚT (VISIBLE) THEO ĐÚNG BẢNG A, B, C, D
        // =========================================================================
        private void cboGiaLapQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGiaLapQuyen.SelectedItem == null) return;
            string vaiTroChon = cboGiaLapQuyen.SelectedItem.ToString();
            ApDungPhanQuyen(vaiTroChon);
        }

        private void ApDungPhanQuyen(string vaiTro)
        {
            VaiTroDangNhap = ChuanHoaTenVaiTro(vaiTro);
            AuthHelper.VaiTro = VaiTroDangNhap;

            bool laQuanLy = (VaiTroDangNhap == "Quản lý");
            bool laBanHang = (VaiTroDangNhap == "Nhân viên bán hàng");
            bool laKho = (VaiTroDangNhap == "Nhân viên kho/kỹ thuật");

            // NHÓM A: CHỈ QUẢN LÝ
            CaiDatQuyenNut(btnTaiKhoan, laQuanLy);
            CaiDatQuyenNut(btnNhatKy, laQuanLy);
            CaiDatQuyenNut(btnLichSuGia, laQuanLy);
            CaiDatQuyenNut(btnNhanVien, laQuanLy);
            CaiDatQuyenNut(btnTKDoanhThu, laQuanLy);
            CaiDatQuyenNut(btnTKTopBanChay, laQuanLy);

            // NHÓM B: NHÂN VIÊN BÁN HÀNG + QUẢN LÝ
            CaiDatQuyenNut(btnKhachHang, laQuanLy || laBanHang);
            CaiDatQuyenNut(btnPhieuXuat, laQuanLy || laBanHang);

            // NHÓM C: NHÂN VIÊN KHO/KỸ THUẬT + QUẢN LÝ
            CaiDatQuyenNut(btnDanhMuc, laQuanLy || laKho);
            CaiDatQuyenNut(btnSanPham, laQuanLy || laKho);
            CaiDatQuyenNut(btnNhaCungCap, laQuanLy || laKho);
            CaiDatQuyenNut(btnThietBiIMEI, laQuanLy || laKho);
            CaiDatQuyenNut(btnKiemKeKho, laQuanLy || laKho);
            CaiDatQuyenNut(btnTKNhapXuatTon, laQuanLy || laKho);
            CaiDatQuyenNut(btnPhieuNhap, laQuanLy || laKho);

            // NHÓM D: CẢ 3 VAI TRÒ ĐỀU DÙNG ĐƯỢC
            CaiDatQuyenNut(btnDashboard, true);
            CaiDatQuyenNut(btnDangXuat, true);

            if (laQuanLy)
                lblUserInfo.Text = $"👤 {HoTenDangNhap} - Quản lý ";
            else if (laBanHang)
                lblUserInfo.Text = $"👤 {HoTenDangNhap} - Nhân viên bán hàng ";
            else if (laKho)
                lblUserInfo.Text = $"👤 {HoTenDangNhap} - Nhân viên kho/kỹ thuật ";

            QuayVeDashboard();
        }

        private void CaiDatQuyenNut(Button btn, bool duocPhep)
        {
            if (btn != null)
            {
                btn.Visible = duocPhep;
                btn.Enabled = duocPhep;
            }
        }

        // =========================================================================
        // 3. HÀM NHÚNG FORM CON VÀO KHUNG GIỮA
        // =========================================================================
        private void MoFormCon(Form childForm, Button btnClicked, string tieuDe)
        {
            DoiMauNutDangChon(btnClicked);
            lblTieuDeTrang.Text = tieuDe.ToUpper();

            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm = null;
            }

            flpCards.Visible = false;
            grpTruyCapNhanh.Visible = false;

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMainContent.Controls.Add(childForm);
            pnlMainContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void QuayVeDashboard()
        {
            DoiMauNutDangChon(btnDashboard);
            lblTieuDeTrang.Text = "TRANG CHỦ TỔNG QUAN";

            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm = null;
            }

            flpCards.Visible = true;
            grpTruyCapNhanh.Visible = true;
            TaiDuLieuDashboardTuSQL();
        }

        private void DoiMauNutDangChon(Button btn)
        {
            if (btn == null) return;

            if (currentActiveButton != null)
            {
                currentActiveButton.BackColor = Color.FromArgb(24, 30, 54);
                currentActiveButton.ForeColor = Color.Gainsboro;
                currentActiveButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            }

            currentActiveButton = btn;
            currentActiveButton.BackColor = Color.FromArgb(0, 122, 204);
            currentActiveButton.ForeColor = Color.White;
            currentActiveButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }

        // =========================================================================
        // 4. GẮN SỰ KIỆN CHO TẤT CẢ CÁC NÚT CHỨC NĂNG
        // =========================================================================
        private void GanSuKienMenu()
        {
            btnDashboard.Click += (s, e) => QuayVeDashboard();

            // NHÓM A: CHỈ QUẢN LÝ
            btnTaiKhoan.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.QUAN_LY))
                    MoFormCon(new FormQuanLyTaiKhoan(), btnTaiKhoan, "Quản lý Tài Khoản & Phân Quyền");
            };
            btnTKTopBanChay.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.QUAN_LY))
                    MoFormCon(new FormThongKeHangBanChay(), btnTKTopBanChay, "Thống Kê Top Hàng Bán Chạy Nhất");
            };
            btnNhatKy.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.QUAN_LY))
                    ThongBaoMoDun(btnNhatKy, "Nhật Ký Hệ Thống & Phiên Đăng Nhập");
            };
            btnLichSuGia.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.QUAN_LY))
                    ThongBaoMoDun(btnLichSuGia, "Đổi Giá Bán & Lịch Sử Giá");
            };
            btnNhanVien.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.QUAN_LY))
                    ThongBaoMoDun(btnNhanVien, "Quản lý Nhân Viên");
            };
            btnTKDoanhThu.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.QUAN_LY))
                    ThongBaoMoDun(btnTKDoanhThu, "Thống Kê Doanh Thu");
            };

            // NHÓM B: NHÂN VIÊN BÁN HÀNG + QUẢN LÝ
            btnKhachHang.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.BAN_HANG))
                    ThongBaoMoDun(btnKhachHang, "Quản lý Khách Hàng");
            };
            btnPhieuXuat.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.BAN_HANG))
                    ThongBaoMoDun(btnPhieuXuat, "Lập & Hoàn Tất Phiếu Xuất");
            };

            // NHÓM C: NHÂN VIÊN KHO / KỸ THUẬT + QUẢN LÝ
            btnPhieuNhap.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.KHO_KY_THUAT))
                    MoFormCon(new FormPhieuNhap(), btnPhieuNhap, "Quản lý Nhập Hàng & Kiểm Định");
            };
            btnThietBiIMEI.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.KHO_KY_THUAT))
                    MoFormCon(new FormQuanLyIMEI(), btnThietBiIMEI, "Quản lý Thiết Bị / IMEI");
            };
            btnDanhMuc.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.KHO_KY_THUAT))
                    ThongBaoMoDun(btnDanhMuc, "Quản lý Danh Mục & Thương Hiệu");
            };
            btnSanPham.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.KHO_KY_THUAT))
                    ThongBaoMoDun(btnSanPham, "Quản lý Hàng Hóa / Sản Phẩm");
            };
            btnNhaCungCap.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.KHO_KY_THUAT))
                    ThongBaoMoDun(btnNhaCungCap, "Quản lý Nhà Cung Cấp");
            };
            btnKiemKeKho.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.KHO_KY_THUAT))
                    ThongBaoMoDun(btnKiemKeKho, "Lập Phiếu Điều Chỉnh Tồn Kho");
            };
            btnTKNhapXuatTon.Click += (s, e) => {
                if (AuthHelper.CheckRole(AuthHelper.KHO_KY_THUAT))
                    ThongBaoMoDun(btnTKNhapXuatTon, "Thống kê Nhập - Xuất - Tồn");
            };

            // NHÓM D: NÚT ĐĂNG XUẤT & HỦY PHIÊN
            btnDangXuat.Click += (s, e) => ThucHienDangXuat();
        }

        private void ThongBaoMoDun(Button btn, string tenChucNang)
        {
            DoiMauNutDangChon(btn);
            MessageBox.Show($"Mô-đun [{tenChucNang}] đang chờ ghép file Form từ thành viên phụ trách trên GitHub.", "Chờ ghép nối mô-đun nhóm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}