using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Text.RegularExpressions;
namespace qlySanPham
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = @"Data Source=LAPTOP-0GD0PC0B;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";
        private string trangThai = "";
        public Form1()
        {
            InitializeComponent();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("ketnoithanhcong");
                    LoadData();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                $"loiketnoi:\n{ex.Message}\n" + MessageBoxButtons.OK
                    );
            }
        }
        private void LoadData()
        {
            try
            {
                string query = @"
            SELECT MaSP, TenSP, MaDanhMuc, ThongTinBaoHanh,
                   MoTa, SoLuongTon, GiaBanHienTai, TrangThai,
                   MaThuongHieu, NguongTonToiThieu
            FROM dbo.SanPham";

                DataTable dt = ExecuteQuery(query);

                // Cho phép DataGridView tự tạo cột theo dữ liệu SQL
                dgvSanPham.AutoGenerateColumns = true;
                dgvSanPham.DataSource = null;
                dgvSanPham.Columns.Clear();
                dgvSanPham.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            trangThai = "them";
            txtMaDanhMuc.Enabled = true;
            txtTenSP.Enabled = true;
            txtMaDanhMuc.Enabled = true;
            txtMaSanPham.Enabled = true;
            txtMoTa.Enabled = true;
            txtGiaBanHienTai.Enabled = true;
            txtSoLuongTon.Enabled = true;
            cboTrangThai.Enabled = true;
            dtpThongTinBaoHanh.Enabled = true;
            txtMaThuongHieu.Enabled = true;
            txtNguongTonToiThieu.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnGhi.Enabled = true;
            btnLamMoi.Enabled = true;
            btnTimKiem.Enabled = false;
            btnTim.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra hàng được chọn
            if (dgvSanPham.CurrentRow == null ||
                dgvSanPham.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Lấy hàng đang chọn
            DataGridViewRow row = dgvSanPham.CurrentRow;

            // Đưa dữ liệu từ DataGridView vào các ô nhập liệu
            txtMaSanPham.Text =
                Convert.ToString(row.Cells["MaSP"].Value);

            txtTenSP.Text =
                Convert.ToString(row.Cells["TenSP"].Value);

            txtMaDanhMuc.Text =
                Convert.ToString(row.Cells["MaDanhMuc"].Value);

            txtMoTa.Text =
                Convert.ToString(row.Cells["MoTa"].Value);

            txtSoLuongTon.Text =
                Convert.ToString(row.Cells["SoLuongTon"].Value);

            txtGiaBanHienTai.Text =
                Convert.ToString(row.Cells["GiaBanHienTai"].Value);

            txtMaThuongHieu.Text =
                Convert.ToString(row.Cells["MaThuongHieu"].Value);

            txtNguongTonToiThieu.Text =
                Convert.ToString(row.Cells["NguongTonToiThieu"].Value);

            cboTrangThai.Text =
                Convert.ToString(row.Cells["TrangThai"].Value);

            // Hiển thị thông tin bảo hành trên DateTimePicker
            object thongTinBaoHanh =
                row.Cells["ThongTinBaoHanh"].Value;

            DateTime ngayBaoHanh;

            if (thongTinBaoHanh != null &&
                thongTinBaoHanh != DBNull.Value &&
                DateTime.TryParse(
                    thongTinBaoHanh.ToString(),
                    out ngayBaoHanh))
            {
                // Đảm bảo ngày nằm trong phạm vi DateTimePicker
                if (ngayBaoHanh < dtpThongTinBaoHanh.MinDate)
                    ngayBaoHanh = dtpThongTinBaoHanh.MinDate;

                if (ngayBaoHanh > dtpThongTinBaoHanh.MaxDate)
                    ngayBaoHanh = dtpThongTinBaoHanh.MaxDate;

                dtpThongTinBaoHanh.Value = ngayBaoHanh;
            }

            // Chuyển sang trạng thái sửa
            trangThai = "sua";

            // Hiển thị mã sản phẩm nhưng không cho sửa khóa chính
            txtMaSanPham.Enabled = false;

            // Cho phép chỉnh sửa những thông tin còn lại
            txtTenSP.Enabled = true;
            txtMaDanhMuc.Enabled = true;
            txtMoTa.Enabled = true;
            txtGiaBanHienTai.Enabled = true;
            txtSoLuongTon.Enabled = true;
            cboTrangThai.Enabled = true;
            dtpThongTinBaoHanh.Enabled = true;
            txtMaThuongHieu.Enabled = true;
            txtNguongTonToiThieu.Enabled = true;

            // Khóa các nút chức năng khác
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTimKiem.Enabled = false;
            btnTim.Enabled = false;

            // Mở nút Ghi và và Làm mới
            btnGhi.Enabled = true;
            btnLamMoi.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtTenSP.Enabled = false;
            txtMaDanhMuc.Enabled = false;
            txtMaSanPham.Enabled = false;
            txtMoTa.Enabled = false;
            txtGiaBanHienTai.Enabled = false;
            txtSoLuongTon.Enabled = false;
            cboTrangThai.Enabled = false;
            dtpThongTinBaoHanh.Enabled = false;
            txtMaThuongHieu.Enabled = false;
            txtNguongTonToiThieu.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;


            btnGhi.Enabled = false;
            btnLamMoi.Enabled = false;
            btnTimKiem.Enabled = false;
            btnTim.Enabled = false;
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sản phẩm này không?",
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

                    string id = dgvSanPham.CurrentRow.Cells["MaSP"].Value.ToString();

                    string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSP", id);

                    int resultDelete = cmd.ExecuteNonQuery();

                    if (resultDelete > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu không thành công");
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

        private void btnGhi_Click(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái thao tác
            if (trangThai != "them" && trangThai != "sua")
            {
                MessageBox.Show("Vui lòng chọn Thêm hoặc Sửa trước khi ghi!");
                return;
            }

            // Lấy dữ liệu từ các ô nhập liệu
            string maSP = txtMaSanPham.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();
            string maDanhMuc = txtMaDanhMuc.Text.Trim();
            string moTa = txtMoTa.Text.Trim();
            string trangThaiSP = cboTrangThai.Text.Trim();
            string maThuongHieu = txtMaThuongHieu.Text.Trim();

            // Kiểm tra mã sản phẩm
            if (string.IsNullOrWhiteSpace(maSP))
            {
                MessageBox.Show("Mã sản phẩm không được để trống!");
                txtMaSanPham.Focus();
                return;
            }

            if (trangThai == "them" &&
                !Regex.IsMatch(maSP, @"^SP\d+$"))
            {
                MessageBox.Show(
                    "Mã sản phẩm không hợp lệ! Ví dụ: SP01, SP04.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtMaSanPham.Focus();
                return;
            }

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(tenSP))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!");
                txtTenSP.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(maDanhMuc))
            {
                MessageBox.Show("Vui lòng nhập mã danh mục!");
                txtMaDanhMuc.Focus();
                return;
            }

            // Kiểm tra số lượng tồn
            int soLuongTon;

            if (!int.TryParse(txtSoLuongTon.Text.Trim(), out soLuongTon)
                || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn phải là số nguyên không âm!");
                txtSoLuongTon.Focus();
                return;
            }

            // Kiểm tra giá bán
            decimal giaBanHienTai;

            if (!decimal.TryParse(
                    txtGiaBanHienTai.Text.Trim(),
                    out giaBanHienTai)
                || giaBanHienTai < 0)
            {
                MessageBox.Show("Giá bán phải là số hợp lệ, không âm!");
                txtGiaBanHienTai.Focus();
                return;
            }

            // Kiểm tra ngưỡng tồn tối thiểu
            int nguongTonToiThieu;

            if (!int.TryParse(
                    txtNguongTonToiThieu.Text.Trim(),
                    out nguongTonToiThieu)
                || nguongTonToiThieu < 0)
            {
                MessageBox.Show(
                    "Ngưỡng tồn tối thiểu phải là số nguyên không âm!"
                );
                txtNguongTonToiThieu.Focus();
                return;
            }

            string query = "";

            // Xác định câu lệnh SQL
            if (trangThai == "them")
            {
                query = @"
            INSERT INTO dbo.SanPham
            (
                MaSP,
                TenSP,
                MaDanhMuc,
                ThongTinBaoHanh,
                MoTa,
                SoLuongTon,
                GiaBanHienTai,
                TrangThai,
                MaThuongHieu,
                NguongTonToiThieu
            )
            VALUES
            (
                @MaSP,
                @TenSP,
                @MaDanhMuc,
                @ThongTinBaoHanh,
                @MoTa,
                @SoLuongTon,
                @GiaBanHienTai,
                @TrangThai,
                @MaThuongHieu,
                @NguongTonToiThieu
            )";
            }
            else if (trangThai == "sua")
            {
                query = @"
            UPDATE dbo.SanPham
            SET
                TenSP = @TenSP,
                MaDanhMuc = @MaDanhMuc,
                ThongTinBaoHanh = @ThongTinBaoHanh,
                MoTa = @MoTa,
                SoLuongTon = @SoLuongTon,
                GiaBanHienTai = @GiaBanHienTai,
                TrangThai = @TrangThai,
                MaThuongHieu = @MaThuongHieu,
                NguongTonToiThieu = @NguongTonToiThieu
            WHERE MaSP = @MaSP";
            }

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Truyền các tham số vào câu lệnh SQL
                        cmd.Parameters.AddWithValue("@MaSP", maSP);
                        cmd.Parameters.AddWithValue("@TenSP", tenSP);
                        cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);

                        cmd.Parameters.AddWithValue(
                            "@ThongTinBaoHanh",
                            dtpThongTinBaoHanh.Value
                        );

                        cmd.Parameters.AddWithValue("@MoTa", moTa);
                        cmd.Parameters.AddWithValue("@SoLuongTon", soLuongTon);
                        cmd.Parameters.AddWithValue(
                            "@GiaBanHienTai",
                            giaBanHienTai
                        );

                        cmd.Parameters.AddWithValue(
                            "@TrangThai",
                            trangThaiSP
                        );

                        cmd.Parameters.AddWithValue(
                            "@MaThuongHieu",
                            maThuongHieu
                        );

                        cmd.Parameters.AddWithValue(
                            "@NguongTonToiThieu",
                            nguongTonToiThieu
                        );

                        // Thực hiện thêm hoặc sửa
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            if (trangThai == "them")
                            {
                                MessageBox.Show("Thêm sản phẩm thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Sửa sản phẩm thành công!");
                            }

                            // Tải lại bảng dữ liệu
                            LoadData();

                            // Đặt lại trạng thái
                            trangThai = "";

                            // Khóa các ô nhập liệu
                            txtMaSanPham.Enabled = false;
                            txtTenSP.Enabled = false;
                            txtMaDanhMuc.Enabled = false;
                            txtMoTa.Enabled = false;
                            txtGiaBanHienTai.Enabled = false;
                            txtSoLuongTon.Enabled = false;
                            cboTrangThai.Enabled = false;
                            dtpThongTinBaoHanh.Enabled = false;
                            txtMaThuongHieu.Enabled = false;
                            txtNguongTonToiThieu.Enabled = false;

                            // Khôi phục các nút chức năng
                            btnThem.Enabled = true;
                            btnSua.Enabled = true;
                            btnXoa.Enabled = true;

                            btnGhi.Enabled = false;
                            btnLamMoi.Enabled = false;
                            btnTimKiem.Enabled = true;
                            btnTim.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không có dữ liệu nào được thay đổi!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Lỗi SQL Server: " + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // 1. Xóa nội dung tìm kiếm
            txtTenSP.Clear();

            // 2. Tải lại toàn bộ dữ liệu từ SQL Server
            LoadData();

            // 3. Đưa DataGridView về trạng thái ban đầu
            dgvSanPham.ClearSelection();

            // 4. Xóa nội dung các ô nhập liệu
            txtTenSP.Clear();
            txtMaDanhMuc.Clear();
            txtMaSanPham.Clear();
            txtMoTa.Clear();
            txtGiaBanHienTai.Clear();
            txtSoLuongTon.Clear();
            txtMaThuongHieu.Clear();
            txtNguongTonToiThieu.Clear();

            // 5. Khóa các ô nhập liệu
            txtTenSP.Enabled = false;
            txtMaDanhMuc.Enabled = false;
            txtMaSanPham.Enabled = false;
            txtMoTa.Enabled = false;
            txtGiaBanHienTai.Enabled = false;
            txtSoLuongTon.Enabled = false;
            cboTrangThai.Enabled = false;
            dtpThongTinBaoHanh.Enabled = false;
            txtMaThuongHieu.Enabled = false;
            txtNguongTonToiThieu.Enabled = false;

            // 6. Đưa các nút về trạng thái ban đầu
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnGhi.Enabled = false;
            btnLamMoi.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtTenSP.Enabled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = @"
    SELECT 
        MaSP,
        TenSP,
        MaDanhMuc,
        ThongTinBaoHanh,
        MoTa,
        SoLuongTon,
        GiaBanHienTai,
        TrangThai,
        MaThuongHieu,
        NguongTonToiThieu
    FROM SanPham
    WHERE (@TenSP = '' OR TenSP LIKE N'%' + @TenSP + '%')";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 2. Lấy tên nhập vào (nửa tên vẫn tìm được)
                    string TenSPInput = txtTenSP.Text.Trim();


                    // 4. Truyền tham số
                    cmd.Parameters.AddWithValue("@TenSP", TenSPInput);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    try
                    {
                        conn.Open();
                        da.Fill(dt);

                        // 5. Đưa dữ liệu lên DataGridView
                        dgvSanPham.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                btnLamMoi.Enabled = true;
            }
        }
    }
}
