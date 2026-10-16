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
namespace qlyLichSuGia
{
    public partial class LichSuGia : Form
    {
        private bool KiemTraMaSPTonTai(string maSP, SqlConnection conn)
        {
            string query = @"
        SELECT COUNT(*)
        FROM dbo.SanPham
        WHERE MaSP = @MaSP";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@MaSP", SqlDbType.VarChar).Value = maSP;

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }
        private readonly string connectionString = @"Data Source=LAPTOP-0GD0PC0B;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";
        private string trangThai = "";
        public LichSuGia()
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
                string query = @"SELECT MaLichSuGia, MaSP, GiaBan, TuNgay, DenNgay
                         FROM dbo.LichSuGia";

                DataTable dt = ExecuteQuery(query);
                dgvLichSuGia.DataSource = dt;
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

            txtMaSP.Enabled = true;
            txtGiaBan.Enabled = true;
            dtpTuNgay.Enabled = true;
            dtpDenNgay.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnGhi.Enabled = true;
            btnLamMoi.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLichSuGia.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa");
                return;
            }

            trangThai = "sua";
            txtMaLichSuGia.Enabled = true;
            txtMaSP.Enabled = true;
            txtGiaBan.Enabled = true;
            dtpTuNgay.Enabled = true;
            dtpDenNgay.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;


            btnGhi.Enabled = true;
            btnLamMoi.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaLichSuGia.Enabled = false;
            txtMaSP.Enabled = false;
            txtGiaBan.Enabled = false;
            dtpTuNgay.Enabled = true;
            dtpDenNgay.Enabled = true;


            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnGhi.Enabled = false;
            btnLamMoi.Enabled = false;
            if (dgvLichSuGia.CurrentRow == null)
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

                    string id = dgvLichSuGia.CurrentRow.Cells["MaLichSuGia"].Value.ToString();

                    string query = "DELETE FROM LichSuGia WHERE MaLichSuGia = @MaLichSuGia";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLichSuGia", id);

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


                    // Kiểm tra mã có đúng định dạng SP + số hay không
                    if (!Regex.IsMatch(txtMaSP.Text.Trim(), @"^SP\d+$"))
                    {
                        MessageBox.Show(
                            "Mã danh mục không hợp lệ!\n" +
                            "Vui lòng nhập theo định dạng SP + số, ví dụ: SP01.",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        txtMaLichSuGia.Focus();
                        return;
                    }
                    MessageBox.Show(
        "Mã sản phẩm '" + txtMaSP.Text.Trim() + "' không tồn tại trong bảng SanPham!\n" +
        "Vui lòng kiểm tra mã sản phẩm trong danh sách.",
        "Mã sản phẩm không hợp lệ",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning
    );

                    txtMaSP.Focus();
                    return;
                    string query = @"
        INSERT INTO LichSuGia ( MaSP, GiaBan, TuNgay, DenNgay)
        VALUES ( @MaSP, @GiaBan, @TuNgay, @DenNgay)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@GiaBan", txtGiaBan.Text.Trim());
                    cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value);
                    cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value);




                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công");
                    }
                }
                string maSP = txtMaSP.Text.Trim();

                if (!KiemTraMaSPTonTai(maSP, conn))
                {
                    MessageBox.Show(
                        "Mã sản phẩm không tồn tại trong bảng SanPham!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtMaSP.Focus();
                    return;
                }
                else if (trangThai == "sua")
                {
                    string query = @"
    UPDATE LichSuGia
    SET 
        MaSP = @MaSP,
        GiaBan = @GiaBan,
        TuNgay = @TuNgay,
        DenNgay = @DenNgay
    WHERE MaLichSuGia = @MaLichSuGia";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaLichSuGia", txtMaLichSuGia.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@GiaBan", txtGiaBan.Text.Trim());
                    cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value);
                    cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Sửa dữ liệu thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lịch sử để sửa");
                    }
                }

                // Tải lại DataGridView
                LoadData();

                // Trở về trạng thái bình thường
                trangThai = "";

                txtMaLichSuGia.Enabled = false;
                txtMaSP.Enabled = false;
                txtGiaBan.Enabled = false;
                dtpTuNgay.Enabled = true;
                dtpDenNgay.Enabled = true;

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
            txtMaSP.Clear();

            // 2. Tải lại toàn bộ dữ liệu từ SQL Server
            LoadData();

            // 3. Đưa DataGridView về trạng thái ban đầu
            dgvLichSuGia.ClearSelection();

            // 4. Xóa nội dung các ô nhập liệu
            txtMaLichSuGia.Clear();
            txtMaSP.Clear();
            txtGiaBan.Clear();

            // 5. Khóa các ô nhập liệu
            txtMaLichSuGia.Enabled = false;
            txtMaSP.Enabled = false;
            txtGiaBan.Enabled = false;
            dtpTuNgay.Enabled = false;
            dtpDenNgay.Enabled = false;

            // 6. Đưa các nút về trạng thái ban đầu
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnGhi.Enabled = false;
            btnLamMoi.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtMaSP.Enabled = true;
            btnLamMoi.Enabled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = @"
    SELECT 
        MaLichSuGia,
        MaSP,
        GiaBan,
        TuNgay,
        DenNgay
    FROM LichSuGia
    WHERE (@MaSP = '' OR MaSP LIKE N'%' + @MaSP + '%')";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 2. Lấy tên nhập vào (nửa tên vẫn tìm được)
                    string MaSPInput = txtMaSP.Text.Trim();


                    // 4. Truyền tham số
                    cmd.Parameters.AddWithValue("@MaSP", MaSPInput);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    try
                    {
                        conn.Open();
                        da.Fill(dt);

                        // 5. Đưa dữ liệu lên DataGridView
                        dgvLichSuGia.DataSource = dt;

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
