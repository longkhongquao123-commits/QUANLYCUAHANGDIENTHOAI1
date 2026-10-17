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
namespace qlydthoai
{
    public partial class qlyDanhMuc : Form
    {
        private readonly string connectionString = @"Data Source=LAPTOP-0GD0PC0B;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";
        private string trangThai = "";
        public qlyDanhMuc()
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
                string query = @"SELECT MaDanhMuc, TenDanhMuc, MoTa
                         FROM dbo.DanhMuc";

                DataTable dt = ExecuteQuery(query);
                dgvDanhMuc.DataSource = dt;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            trangThai = "them";
            txtMaDanhMuc.Enabled = true;
            txtTenDanhMuc.Enabled = true;
            txtMoTa.Enabled = true;


            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void txtGhiDuLieu_Click(object sender, EventArgs e)
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

                    string maDanhMuc = txtMaDanhMuc.Text.Trim();

                    // Kiểm tra mã có đúng định dạng DM + số hay không
                    if (!Regex.IsMatch(maDanhMuc, @"^DM\d+$"))
                    {
                        MessageBox.Show(
                            "Mã danh mục không hợp lệ!\n" +
                            "Vui lòng nhập theo định dạng DM + số, ví dụ: DM01.",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        txtMaDanhMuc.Focus();
                        return;
                    }

                    string query = @"
        INSERT INTO DanhMuc (MaDanhMuc, TenDanhMuc, MoTa)
        VALUES (@MaDanhMuc, @TenDanhMuc, @MoTa)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);
                    cmd.Parameters.AddWithValue("@TenDanhMuc", txtTenDanhMuc.Text.Trim());
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text.Trim());

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công");
                    }
                }


                else if (trangThai == "sua")
                {
                    string query = @"
    UPDATE DanhMuc
    SET 
        TenDanhMuc = @TenDanhMuc,
        MoTa = @MoTa,
    WHERE MaDanhMuc = @MaDanhMuc";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaDanhMuc", txtMaDanhMuc.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenDanhMuc", txtTenDanhMuc.Text.Trim());
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text.Trim());

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

                txtMaDanhMuc.Enabled = false;
                txtTenDanhMuc.Enabled = false;
                txtMoTa.Enabled = false;

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhMuc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa");
                return;
            }

            trangThai = "sua";
            txtMaDanhMuc.Enabled = true;
            txtTenDanhMuc.Enabled = true;
            txtMoTa.Enabled = true;


            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;


            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaDanhMuc.Enabled = false;
            txtTenDanhMuc.Enabled = false;
            txtMoTa.Enabled = false;


            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;


            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            if (dgvDanhMuc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa danh mục này không?",
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

                    string id = dgvDanhMuc.CurrentRow.Cells["MaDanhMuc"].Value.ToString();

                    string query = "DELETE FROM DanhMuc WHERE MaDanhMuc = @MaDanhMuc";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDanhMuc", id);

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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaDanhMuc.Enabled = false;
            txtTenDanhMuc.Enabled = false;
            txtMoTa.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;


            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtTenDanhMuc.Enabled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = @"
    SELECT 
        MaDanhMuc,
        TenDanhMuc,
        MoTa
    FROM DanhMuc
    WHERE (@TenDanhMuc = '' OR TenDanhMuc LIKE N'%' + @TenDanhMuc + '%')";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 2. Lấy tên nhập vào (nửa tên vẫn tìm được)
                    string TenDanhMucInput = txtTenDanhMuc.Text.Trim();


                    // 4. Truyền tham số
                    cmd.Parameters.AddWithValue("@TenDanhMuc", TenDanhMucInput);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    try
                    {
                        conn.Open();
                        da.Fill(dt);

                        // 5. Đưa dữ liệu lên DataGridView
                        dgvDanhMuc.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy danh mục nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // 1. Xóa nội dung tìm kiếm
            txtTenDanhMuc.Clear();

            // 2. Tải lại toàn bộ dữ liệu từ SQL Server
            LoadData();

            // 3. Đưa DataGridView về trạng thái ban đầu
            dgvDanhMuc.ClearSelection();

            // 4. Xóa nội dung các ô nhập liệu
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();
            txtMoTa.Clear();

            // 5. Khóa các ô nhập liệu
            txtMaDanhMuc.Enabled = false;
            txtTenDanhMuc.Enabled = false;
            txtMoTa.Enabled = false;

            // 6. Đưa các nút về trạng thái ban đầu
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
        }
    }
}

