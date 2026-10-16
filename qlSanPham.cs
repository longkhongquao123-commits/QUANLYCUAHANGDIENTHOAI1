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
                   MaThuongHieu, NguongTonToiThieu, HinhAnh
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
            txtHinhAnh.Enabled = true;


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
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa");
                return;
            }

            trangThai = "sua";
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
            txtHinhAnh.Enabled = true;


            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;


            btnGhi.Enabled = true;
            btnLamMoi.Enabled = true;
            btnTimKiem.Enabled = false;
            btnTim.Enabled = false;
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
            txtHinhAnh.Enabled = false;


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

                    string MaSP = txtMaSanPham.Text.Trim();

                    // Kiểm tra mã có đúng định dạng DM + số hay không
                    if (!Regex.IsMatch(MaSP, @"^SP\d+$"))
                    {
                        MessageBox.Show(
                            "Mã danh mục không hợp lệ!\n" +
                            "Vui lòng nhập theo định dạng SP + số, ví dụ: SP01.",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        txtMaSanPham.Focus();
                        return;
                    }

                    string query = @"
        INSERT INTO SanPham (MaSP, TenSP, MaDanhMuc, ThongTinBaoHanh, MoTa, SoLuongTon, GiaBanHienTai, TrangThai, MaThuongHieu, NguongTonToiThieu, HinhAnh)
        VALUES (@MaSP, @TenSP, @MaDanhMuc, @ThongTinBaoHanh, @MoTa, @SoLuongTon, @GiaBanHienTai, @TrangThai )";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaSP", MaSP);
                    cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaDanhMuc", txtMaDanhMuc.Text.Trim());
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@ThongTinBaoHanh", dtpThongTinBaoHanh.Text.Trim());
                    cmd.Parameters.AddWithValue("@SoLuongTon", txtSoLuongTon.Text.Trim());
                    cmd.Parameters.AddWithValue("@GiaBanHienTai", txtGiaBanHienTai.Text.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", cboTrangThai.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaThuongHieu", txtMaThuongHieu.Text.Trim());
                    cmd.Parameters.AddWithValue("@NguonTonToiThieu", txtNguongTonToiThieu.Text.Trim());
                    cmd.Parameters.AddWithValue("@HinhAnh", txtHinhAnh.Text.Trim());
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công");
                    }
                }


                else if (trangThai == "sua")
                {
                    string query = @"
    UPDATE SanPham
    SET 
        TenSP = @TenSP,
        MoTa = @MoTa,
    WHERE MaSP = @MaSP";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaSP", MaSP);
                    cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaDanhMuc", txtMaDanhMuc.Text.Trim());
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@ThongTinBaoHanh", dtpThongTinBaoHanh.Text.Trim());
                    cmd.Parameters.AddWithValue("@SoLuongTon", txtSoLuongTon.Text.Trim());
                    cmd.Parameters.AddWithValue("@GiaBanHienTai", txtGiaBanHienTai.Text.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", cboTrangThai.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaThuongHieu", txtMaThuongHieu.Text.Trim());
                    cmd.Parameters.AddWithValue("@NguonTonToiThieu", txtNguongTonToiThieu.Text.Trim());
                    cmd.Parameters.AddWithValue("@HinhAnh", txtHinhAnh.Text.Trim());

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Sửa dữ liệu thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy danh mục để sửa");
                    }
                }

                // Tải lại DataGridView
                LoadData();

                // Trở về trạng thái bình thường
                trangThai = "";

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
                txtHinhAnh.Enabled = false;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                btnGhi.Enabled = false;
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
            txtHinhAnh.Clear();

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
            txtHinhAnh.Enabled = false;

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
        NguongTonToiThieu,
        HinhAnh
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
