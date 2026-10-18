using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WindowsFormsQuanLyDienThoai12
{
    public partial class Form2 : Form
    {
        private const string ChuoiKetNoi =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;" +
            "Integrated Security=True;TrustServerCertificate=True";

        private readonly DateTime _thoiDiemDangNhap = DateTime.Now;

        public Form2()
        {
            InitializeComponent();
            GanSuKien();
            CapNhatGiaoDien();
        }

        // Gắn sự kiện trong code. Trừ trước rồi cộng lại để không bị gắn hai lần
        private void GanSuKien()
        {
            this.Load -= Form2_Load;
            this.Load += Form2_Load;

            mnuTaiKhoan.Click -= mnuTaiKhoan_Click;
            mnuTaiKhoan.Click += mnuTaiKhoan_Click;

            mnuDangXuat.Click -= mnuDangXuat_Click;
            mnuDangXuat.Click += mnuDangXuat_Click;

            mnuThoat.Click -= mnuThoat_Click;
            mnuThoat.Click += mnuThoat_Click;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CapNhatGiaoDien();
        }

        // Điền thông tin người dùng và phân quyền menu
        private void CapNhatGiaoDien()
        {
            lblNguoiDung.Text = "Người dùng: " + (Session.HoTen ?? "");
            lblVaiTro.Text = "Vai trò: " + (Session.VaiTro ?? "");
            lblDangNhapLuc.Text = "Đăng nhập lúc: " + _thoiDiemDangNhap.ToString("HH:mm dd/MM/yyyy");

            mnuTaiKhoan.Visible = Session.VaiTro == "Quản lý";
            mnuKho.Visible = Session.VaiTro != "Nhân viên bán hàng";
        }

        private void mnuTaiKhoan_Click(object sender, EventArgs e)
        {
            // Nếu Form3 đã mở thì chỉ đưa lên trước
            Form3 dangMo = MdiChildren.OfType<Form3>().FirstOrDefault();
            if (dangMo != null)
            {
                dangMo.Activate();
                return;
            }

            Form3 f = new Form3();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            GhiDangXuat();
            Session.DangXuat();

            // Retry báo cho Program quay lại form đăng nhập
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            // Cancel báo cho Program kết thúc chương trình
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Giữ lại vì Designer có thể đang gắn sự kiện tới hàm này
        private void mnuDanhMuc_Click(object sender, EventArgs e)
        {
        }

        // Giữ lại vì Designer có thể đang gắn sự kiện tới hàm này
        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void GhiDangXuat()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ChuoiKetNoi))
                {
                    conn.Open();

                    if (!string.IsNullOrEmpty(Session.MaPhien))
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE PhienDangNhap SET TrangThaiPhien = N'Đã đăng xuất', GioDangXuat = GETDATE() " +
                            "WHERE MaPhien = @MaPhien", conn))
                        {
                            cmd.Parameters.AddWithValue("@MaPhien", Session.MaPhien);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("sp_GhiNhatKy", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenDangNhap", Session.TenDangNhap ?? "");
                        cmd.Parameters.AddWithValue("@LoaiHanhDong", "Đăng xuất");
                        cmd.Parameters.AddWithValue("@DoiTuong", "Hệ thống");
                        cmd.Parameters.AddWithValue("@MoTaChiTiet", "Người dùng đăng xuất");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                // Vẫn cho đăng xuất dù không ghi được CSDL
            }
        }
    }
}