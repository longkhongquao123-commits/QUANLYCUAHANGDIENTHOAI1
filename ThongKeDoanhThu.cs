using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Quanlybanhang
{
    public partial class ThongKeDoanhThu : Form
    {
        private readonly string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True";
        private readonly CultureInfo vn = new CultureInfo("vi-VN");

        // Điều kiện lọc dùng chung: phiếu hoàn tất, nằm trong khoảng ngày đã chọn
        private const string DIEU_KIEN =
            @"WHERE px.TrangThai = N'Hoàn tất'
                AND px.NgayXuat >= @TuNgay
                AND px.NgayXuat < DATEADD(DAY, 1, @DenNgay)";

        private int kieuDangXem = 0;   // 0 = theo ngày, 1 = theo tháng, 2 = theo nhân viên

        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cboKieuXem.Items.Clear();
            cboKieuXem.Items.AddRange(new object[] { "Theo ngày", "Theo tháng", "Theo nhân viên" });
            cboKieuXem.SelectedIndex = 0;

            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpDenNgay.Value = DateTime.Today;

            btnXem.Click -= btnXem_Click;
            btnXem.Click += btnXem_Click;
            btnXuat.Click -= btnXuat_Click;
            btnXuat.Click += btnXuat_Click;
            dgvThongKe.SelectionChanged -= dgvThongKe_SelectionChanged;
            dgvThongKe.SelectionChanged += dgvThongKe_SelectionChanged;
            dgvPhieu.CellDoubleClick -= dgvPhieu_CellDoubleClick;
            dgvPhieu.CellDoubleClick += dgvPhieu_CellDoubleClick;
        }

        // ================= NÚT XEM =================
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không được lớn hơn Đến ngày.");
                return;
            }

            string sql;
            if (cboKieuXem.SelectedIndex == 0)          // Theo ngày
            {
                sql = @"SELECT CAST(px.NgayXuat AS DATE) AS Ngay, COUNT(*) AS SoPhieu,
                               SUM(px.TongTien) AS TongTien, SUM(px.TongGiamGia) AS TongGiamGia,
                               SUM(px.ThanhToan) AS DoanhThu
                        FROM PhieuXuat px " + DIEU_KIEN + @"
                        GROUP BY CAST(px.NgayXuat AS DATE)
                        ORDER BY Ngay";
            }
            else if (cboKieuXem.SelectedIndex == 1)     // Theo tháng
            {
                sql = @"SELECT YEAR(px.NgayXuat) AS Nam, MONTH(px.NgayXuat) AS Thang, COUNT(*) AS SoPhieu,
                               SUM(px.TongTien) AS TongTien, SUM(px.TongGiamGia) AS TongGiamGia,
                               SUM(px.ThanhToan) AS DoanhThu
                        FROM PhieuXuat px " + DIEU_KIEN + @"
                        GROUP BY YEAR(px.NgayXuat), MONTH(px.NgayXuat)
                        ORDER BY Nam, Thang";
            }
            else                                        // Theo nhân viên
            {
                sql = @"SELECT px.MaNV, nv.HoTen, COUNT(*) AS SoPhieu,
                               SUM(px.TongTien) AS TongTien, SUM(px.TongGiamGia) AS TongGiamGia,
                               SUM(px.ThanhToan) AS DoanhThu
                        FROM PhieuXuat px
                        INNER JOIN NhanVien nv ON nv.MaNV = px.MaNV " + DIEU_KIEN + @"
                        GROUP BY px.MaNV, nv.HoTen
                        ORDER BY DoanhThu DESC";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    da.SelectCommand.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Gỡ sạch dữ liệu và cột của kiểu xem cũ TRƯỚC khi đổi kiểu xem
                    dgvPhieu.DataSource = null;
                    dgvPhieu.Columns.Clear();
                    dgvThongKe.DataSource = null;
                    dgvThongKe.Columns.Clear();

                    kieuDangXem = cboKieuXem.SelectedIndex;   // đổi kiểu xem khi bảng đã trống
                    dgvThongKe.DataSource = dt;               // gán dữ liệu mới, SelectionChanged chạy đúng

                    decimal tong = 0;
                    foreach (DataRow r in dt.Rows)
                        tong += Convert.ToDecimal(r["DoanhThu"]);
                    txtTongDoanhThu.Text = tong.ToString("N0", vn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }
        }

        // ================= XEM PHIẾU NGUỒN =================
        // Chọn 1 dòng thống kê -> liệt kê các phiếu tạo nên dòng đó
        private void dgvThongKe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThongKe.CurrentRow == null) return;
            DataRowView dong = dgvThongKe.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null) return;

            // Mỗi kiểu xem có thêm 1 điều kiện riêng để lọc đúng nhóm của dòng
            string them;
            if (kieuDangXem == 0) them = " AND CAST(px.NgayXuat AS DATE) = @Ngay";
            else if (kieuDangXem == 1) them = " AND YEAR(px.NgayXuat) = @Nam AND MONTH(px.NgayXuat) = @Thang";
            else them = " AND px.MaNV = @MaNV";

            string sql = @"SELECT px.MaPX, px.NgayXuat, px.MaKH, px.MaNV, px.PhuongThucThanhToan,
                                  px.TongGiamGia, px.ThanhToan
                           FROM PhieuXuat px " + DIEU_KIEN + them + @"
                           ORDER BY px.NgayXuat, px.MaPX";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    da.SelectCommand.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date);

                    if (kieuDangXem == 0)
                        da.SelectCommand.Parameters.AddWithValue("@Ngay", Convert.ToDateTime(dong["Ngay"]).Date);
                    else if (kieuDangXem == 1)
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Nam", Convert.ToInt32(dong["Nam"]));
                        da.SelectCommand.Parameters.AddWithValue("@Thang", Convert.ToInt32(dong["Thang"]));
                    }
                    else
                        da.SelectCommand.Parameters.AddWithValue("@MaNV", dong["MaNV"].ToString());

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPhieu.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phiếu nguồn: " + ex.Message);
            }
        }

        // Bấm đúp 1 phiếu -> hiện chi tiết sản phẩm của phiếu đó
        private void dgvPhieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string maPX = dgvPhieu.Rows[e.RowIndex].Cells["MaPX"].Value.ToString();

            string sql = @"SELECT sp.TenSP, ct.SoLuong, ct.DonGia, ct.GiamGia, ct.ThanhTien
                           FROM ChiTietPhieuXuat ct
                           INNER JOIN SanPham sp ON sp.MaSP = ct.MaSP
                           WHERE ct.MaPX = @ma
                           ORDER BY ct.MaSP";
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Phiếu " + maPX);
                sb.AppendLine("------------------------------------");

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maPX);
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            sb.AppendLine(rd["TenSP"] + "  |  SL: " + rd["SoLuong"]
                                + "  |  Đơn giá: " + Convert.ToDecimal(rd["DonGia"]).ToString("N0", vn)
                                + "  |  Giảm: " + Convert.ToDecimal(rd["GiamGia"]).ToString("N0", vn)
                                + "  |  Thành tiền: " + Convert.ToDecimal(rd["ThanhTien"]).ToString("N0", vn));
                        }
                    }
                }
                MessageBox.Show(sb.ToString(), "Chi tiết phiếu " + maPX,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết phiếu: " + ex.Message);
            }
        }

        // ================= XUẤT TỆP CSV =================
        private void btnXuat_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvThongKe.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để xuất. Hãy bấm Xem trước.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "File CSV (*.csv)|*.csv";
                sfd.FileName = "ThongKeDoanhThu.csv";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // UTF8 có BOM để Excel đọc đúng tiếng Việt
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        sw.WriteLine("sep=,");   // báo cho Excel biết dấu ngăn cách là dấu phẩy

                        // Dòng tiêu đề
                        string[] tieuDe = new string[dt.Columns.Count];
                        for (int i = 0; i < dt.Columns.Count; i++)
                            tieuDe[i] = Esc(dt.Columns[i].ColumnName);
                        sw.WriteLine(string.Join(",", tieuDe));

                        // Từng dòng dữ liệu
                        foreach (DataRow r in dt.Rows)
                        {
                            string[] o = new string[dt.Columns.Count];
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                object v = r[i];
                                if (v is DateTime) o[i] = Esc(((DateTime)v).ToString("dd/MM/yyyy"));
                                else if (v is decimal) o[i] = Esc(((decimal)v).ToString("0", CultureInfo.InvariantCulture));
                                else o[i] = Esc(Convert.ToString(v, CultureInfo.InvariantCulture));
                            }
                            sw.WriteLine(string.Join(",", o));
                        }
                    }
                    MessageBox.Show("Đã xuất file:\n" + sfd.FileName, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message);
                }
            }
        }

        // Bọc giá trị trong dấu ngoặc kép, phòng khi dữ liệu có dấu phẩy
        private string Esc(string s)
        {
            if (s == null) s = "";
            return "\"" + s.Replace("\"", "\"\"") + "\"";
        }
    }
}