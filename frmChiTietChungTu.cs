using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai
{
    public partial class frmChiTietChungTu : Form
    {
        // >>> CHỈNH Ở ĐÂY: dán đúng chuỗi kết nối đang chạy được ở Form1 (đổi Data Source cho khớp máy bạn)
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

        private string maSP = "";
        private string tenSP = "";
        private DateTime tuNgay;
        private DateTime denNgay;

        public frmChiTietChungTu() : this("", "", DateTime.Today, DateTime.Today)
        {
        }

        public frmChiTietChungTu(string maSP, string tenSP, DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();

            this.maSP = maSP;
            this.tenSP = tenSP;
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;

            btnDong.Click += btnDong_Click;

            // Cấu hình lưới
            dgvChungTu.ReadOnly = true;
            dgvChungTu.AllowUserToAddRows = false;
            dgvChungTu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChungTu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            lblSanPham.Text = "Chứng từ của sản phẩm: " + tenSP + "  (" +
                              tuNgay.ToString("dd/MM/yyyy") + " - " + denNgay.ToString("dd/MM/yyyy") + ")";

            LoadData();
        }

        // =========================================================
        // HÀM DÙNG CHUNG
        // =========================================================
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

        // Tải các giao dịch kho của sản phẩm trong khoảng ngày
        private void LoadData()
        {
            try
            {
                string query = @"
    SELECT NgayGiaoDich, LoaiGiaoDich, MaChungTu, SoLuongThayDoi, SoTonSauGiaoDich
    FROM GiaoDichKho
    WHERE MaSP = @MaSP
      AND NgayGiaoDich >= @TuNgay
      AND NgayGiaoDich < @DenNgayHet
    ORDER BY NgayGiaoDich";

                SqlParameter[] ps = new SqlParameter[]
                {
                    new SqlParameter("@MaSP", maSP),
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgayHet", denNgay.AddDays(1))
                };

                dgvChungTu.DataSource = ExecuteQuery(query, ps);

                dgvChungTu.Columns["NgayGiaoDich"].HeaderText = "Ngày";
                dgvChungTu.Columns["NgayGiaoDich"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvChungTu.Columns["LoaiGiaoDich"].HeaderText = "Loại giao dịch";
                dgvChungTu.Columns["MaChungTu"].HeaderText = "Mã chứng từ";
                dgvChungTu.Columns["SoLuongThayDoi"].HeaderText = "Số lượng thay đổi";
                dgvChungTu.Columns["SoTonSauGiaoDich"].HeaderText = "Tồn sau giao dịch";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}