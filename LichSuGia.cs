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
            // 1. Kiểm tra đã chọn hàng cần sửa chưa
            if (dgvLichSuGia.CurrentRow == null ||
                dgvLichSuGia.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Vui lòng chọn lịch sử giá cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 2. Lấy dữ liệu từ hàng đang chọn
            DataGridViewRow row = dgvLichSuGia.CurrentRow;

            txtMaLichSuGia.Text =
                Convert.ToString(row.Cells["MaLichSuGia"].Value);

            txtMaSP.Text =
                Convert.ToString(row.Cells["MaSP"].Value);

            txtGiaBan.Text =
                Convert.ToString(row.Cells["GiaBan"].Value);

            // 3. Hiển thị ngày bắt đầu
            object tuNgay = row.Cells["TuNgay"].Value;

            if (tuNgay != null && tuNgay != DBNull.Value)
            {
                dtpTuNgay.Value = Convert.ToDateTime(tuNgay);
            }

            // 4. Hiển thị ngày kết thúc
            object denNgay = row.Cells["DenNgay"].Value;

            if (denNgay != null && denNgay != DBNull.Value)
            {
                dtpDenNgay.Value = Convert.ToDateTime(denNgay);
            }

            // 5. Chuyển sang trạng thái sửa
            trangThai = "sua";

            // 6. Hiển thị mã lịch sử giá nhưng không cho sửa mã
            txtMaLichSuGia.Enabled = false;

            // 7. Cho phép chỉnh sửa các thông tin còn lại
            txtMaSP.Enabled = true;
            txtGiaBan.Enabled = true;
            dtpTuNgay.Enabled = true;
            dtpDenNgay.Enabled = true;

            // 8. Khóa các nút Thêm, Sửa, Xóa
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // 9. Cho phép Ghi và làm mới/hủy thao tác
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
            // 1. Kiểm tra trạng thái thao tác
            if (trangThai != "them" && trangThai != "sua")
            {
                MessageBox.Show("Vui lòng chọn Thêm hoặc Sửa trước khi ghi!");
                return;
            }

            // 2. Lấy dữ liệu từ các ô nhập liệu
            string maSP = txtMaSP.Text.Trim();
            string giaBanText = txtGiaBan.Text.Trim();

            // 3. Kiểm tra định dạng mã sản phẩm
            if (!Regex.IsMatch(maSP, @"^SP\d+$"))
            {
                MessageBox.Show(
                    "Mã sản phẩm không hợp lệ!\n" +
                    "Vui lòng nhập theo định dạng SP + số, ví dụ: SP04.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtMaSP.Focus();
                return;
            }

            // 4. Kiểm tra giá bán
            decimal giaBan;

            if (!decimal.TryParse(giaBanText, out giaBan) || giaBan <= 0)
            {
                MessageBox.Show(
                    "Giá bán phải là số hợp lệ và lớn hơn 0!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtGiaBan.Focus();
                return;
            }

            // 5. Kiểm tra ngày bắt đầu và ngày kết thúc
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;

            if (denNgay.Date < tuNgay.Date)
            {
                MessageBox.Show(
                    "Ngày kết thúc không được trước ngày bắt đầu!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 6. Kiểm tra mã sản phẩm đã tồn tại trong bảng SanPham
                    if (!KiemTraMaSPTonTai(maSP, conn))
                    {
                        MessageBox.Show(
                            "Mã sản phẩm '" + maSP +
                            "' không tồn tại trong bảng SanPham!\n" +
                            "Vui lòng kiểm tra lại mã sản phẩm.",
                            "Mã sản phẩm không hợp lệ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        txtMaSP.Focus();
                        return;
                    }

                    int result = 0;

                    // =========================================
                    // TRƯỜNG HỢP 1: THÊM LỊCH SỬ GIÁ
                    // =========================================
                    if (trangThai == "them")
                    {
                        string query = @"
                    INSERT INTO dbo.LichSuGia
                        (MaSP, GiaBan, TuNgay, DenNgay)
                    VALUES
                        (@MaSP, @GiaBan, @TuNgay, @DenNgay)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                            cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                            cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                            result = cmd.ExecuteNonQuery();
                        }

                        if (result > 0)
                        {
                            MessageBox.Show(
                                "Thêm lịch sử giá thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }

                    // =========================================
                    // TRƯỜNG HỢP 2: SỬA LỊCH SỬ GIÁ
                    // =========================================
                    else if (trangThai == "sua")
                    {
                        string maLichSuGia = txtMaLichSuGia.Text.Trim();

                        if (string.IsNullOrWhiteSpace(maLichSuGia))
                        {
                            MessageBox.Show("Không tìm thấy mã lịch sử giá cần sửa!");
                            return;
                        }

                        string query = @"
                    UPDATE dbo.LichSuGia
                    SET
                        MaSP = @MaSP,
                        GiaBan = @GiaBan,
                        TuNgay = @TuNgay,
                        DenNgay = @DenNgay
                    WHERE MaLichSuGia = @MaLichSuGia";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue(
                                "@MaLichSuGia", maLichSuGia);

                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                            cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                            cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                            result = cmd.ExecuteNonQuery();
                        }

                        if (result > 0)
                        {
                            MessageBox.Show(
                                "Sửa lịch sử giá thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy lịch sử giá cần sửa!"
                            );
                        }
                    }

                    // 7. Chỉ làm mới trạng thái khi ghi thành công
                    if (result > 0)
                    {
                        LoadData();

                        trangThai = "";

                        // Khóa các ô nhập liệu
                        txtMaLichSuGia.Enabled = false;
                        txtMaSP.Enabled = false;
                        txtGiaBan.Enabled = false;
                        dtpTuNgay.Enabled = false;
                        dtpDenNgay.Enabled = false;

                        // Khôi phục trạng thái các nút
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;

                        btnGhi.Enabled = false;
                        btnLamMoi.Enabled = false;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                        "Lỗi SQL Server: " + ex.Message,
                        "Lỗi",
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
