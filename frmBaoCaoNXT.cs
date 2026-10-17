using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCuaHangDienThoai
{
    public partial class frmBaoCaoNXT : Form
    {
        // >>> CHỈNH Ở ĐÂY: dán đúng chuỗi kết nối đang chạy được ở Form1 (đổi Data Source cho khớp máy bạn)
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

        private Chart chartNXT = new Chart();       // biểu đồ cột, tạo bằng code và đặt vào pnlBieuDo
        private DateTime tuNgayDaXem;               // khoảng ngày của lần bấm Xem gần nhất
        private DateTime denNgayDaXem;

        public frmBaoCaoNXT()
        {
            InitializeComponent();

            // Gắn sự kiện
            btnXem.Click += btnXem_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;
            btnDong.Click += btnDong_Click;
            dgvNXT.CellDoubleClick += dgvNXT_CellDoubleClick;
            dgvNXT.DataBindingComplete += dgvNXT_DataBindingComplete;

            // Cấu hình lưới
            dgvNXT.ReadOnly = true;
            dgvNXT.AllowUserToAddRows = false;
            dgvNXT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNXT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Khoảng ngày mặc định: từ đầu tháng trước đến hôm nay
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
            dtpDenNgay.Value = DateTime.Today;

            cboDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadDanhMuc();

            CauHinhBieuDo();
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

        // Nạp danh mục vào combobox, thêm dòng "Tất cả" ở đầu
        private void LoadDanhMuc()
        {
            try
            {
                DataTable dt = ExecuteQuery("SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc");

                DataRow dongTatCa = dt.NewRow();
                dongTatCa["MaDanhMuc"] = "";
                dongTatCa["TenDanhMuc"] = "Tất cả";
                dt.Rows.InsertAt(dongTatCa, 0);

                cboDanhMuc.DataSource = dt;
                cboDanhMuc.DisplayMember = "TenDanhMuc";
                cboDanhMuc.ValueMember = "MaDanhMuc";
                cboDanhMuc.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tạo biểu đồ cột với 3 nhóm: Nhập, Xuất, Tồn cuối
        private void CauHinhBieuDo()
        {
            chartNXT.Dock = DockStyle.Fill;

            ChartArea vung = new ChartArea("vung1");
            vung.AxisX.Interval = 1;
            vung.AxisX.MajorGrid.Enabled = false;
            vung.AxisX.LabelStyle.Angle = -20;
            chartNXT.ChartAreas.Add(vung);

            Legend chuThich = new Legend("chuthich1");
            chuThich.Docking = Docking.Top;
            chartNXT.Legends.Add(chuThich);

            Series sNhap = new Series("Nhập");
            sNhap.ChartType = SeriesChartType.Column;
            sNhap.Color = Color.FromArgb(31, 119, 180);
            chartNXT.Series.Add(sNhap);

            Series sXuat = new Series("Xuất");
            sXuat.ChartType = SeriesChartType.Column;
            sXuat.Color = Color.FromArgb(255, 127, 14);
            chartNXT.Series.Add(sXuat);

            Series sTon = new Series("Tồn cuối");
            sTon.ChartType = SeriesChartType.Column;
            sTon.Color = Color.FromArgb(44, 160, 44);
            chartNXT.Series.Add(sTon);

            pnlBieuDo.Controls.Add(chartNXT);
        }

        // Vẽ biểu đồ từ bảng kết quả (lấy tối đa 10 sản phẩm đầu)
        private void VeBieuDo(DataTable dt)
        {
            chartNXT.Series["Nhập"].Points.Clear();
            chartNXT.Series["Xuất"].Points.Clear();
            chartNXT.Series["Tồn cuối"].Points.Clear();

            int soDong = Math.Min(10, dt.Rows.Count);
            for (int i = 0; i < soDong; i++)
            {
                string ten = dt.Rows[i]["TenSP"].ToString();
                chartNXT.Series["Nhập"].Points.AddXY(ten, Convert.ToInt32(dt.Rows[i]["Nhap"]));
                chartNXT.Series["Xuất"].Points.AddXY(ten, Convert.ToInt32(dt.Rows[i]["Xuat"]));
                chartNXT.Series["Tồn cuối"].Points.AddXY(ten, Convert.ToInt32(dt.Rows[i]["TonCuoi"]));
            }
        }

        // Tải báo cáo theo khoảng ngày, danh mục và ô "chỉ hiện dưới ngưỡng"
        private void LoadData()
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không được lớn hơn Đến ngày", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nhập = nhập kho + điều chỉnh tăng, Xuất = xuất bán + điều chỉnh giảm
            // Tồn đầu = tổng thay đổi trước Từ ngày, Tồn cuối = Tồn đầu + Nhập - Xuất
            // Cảnh báo khi Tồn cuối <= ngưỡng tồn tối thiểu (giống stored procedure của nhóm)
            string query = @"
    WITH t AS (
        SELECT s.MaSP, s.TenSP, dm.TenDanhMuc, s.NguongTonToiThieu,
               ISNULL(SUM(CASE WHEN g.NgayGiaoDich < @TuNgay THEN g.SoLuongThayDoi END), 0) AS TonDau,
               ISNULL(SUM(CASE WHEN g.NgayGiaoDich >= @TuNgay AND g.NgayGiaoDich < @DenNgayHet
                                AND g.SoLuongThayDoi > 0 THEN g.SoLuongThayDoi END), 0) AS Nhap,
               ISNULL(-SUM(CASE WHEN g.NgayGiaoDich >= @TuNgay AND g.NgayGiaoDich < @DenNgayHet
                                 AND g.SoLuongThayDoi < 0 THEN g.SoLuongThayDoi END), 0) AS Xuat
        FROM SanPham s
        LEFT JOIN DanhMuc dm ON dm.MaDanhMuc = s.MaDanhMuc
        LEFT JOIN GiaoDichKho g ON g.MaSP = s.MaSP
        WHERE (@MaDanhMuc = '' OR s.MaDanhMuc = @MaDanhMuc)
        GROUP BY s.MaSP, s.TenSP, dm.TenDanhMuc, s.NguongTonToiThieu
    )
    SELECT MaSP, TenSP, TenDanhMuc, TonDau, Nhap, Xuat,
           TonDau + Nhap - Xuat AS TonCuoi,
           NguongTonToiThieu AS Nguong,
           CASE WHEN TonDau + Nhap - Xuat <= NguongTonToiThieu THEN N'Dưới ngưỡng' ELSE N'Đủ hàng' END AS CanhBao
    FROM t
    WHERE (@ChiDuoiNguong = 0 OR TonDau + Nhap - Xuat <= NguongTonToiThieu)
    ORDER BY MaSP";

            try
            {
                string maDanhMuc = "";
                if (cboDanhMuc.SelectedValue != null)
                {
                    maDanhMuc = cboDanhMuc.SelectedValue.ToString();
                }

                tuNgayDaXem = dtpTuNgay.Value.Date;
                denNgayDaXem = dtpDenNgay.Value.Date;

                SqlParameter[] ps = new SqlParameter[]
                {
                    new SqlParameter("@TuNgay", tuNgayDaXem),
                    new SqlParameter("@DenNgayHet", denNgayDaXem.AddDays(1)),
                    new SqlParameter("@MaDanhMuc", maDanhMuc),
                    new SqlParameter("@ChiDuoiNguong", chkDuoiNguong.Checked)
                };

                DataTable dt = ExecuteQuery(query, ps);
                dgvNXT.DataSource = dt;

                dgvNXT.Columns["MaSP"].HeaderText = "Mã SP";
                dgvNXT.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                dgvNXT.Columns["TenDanhMuc"].HeaderText = "Danh mục";
                dgvNXT.Columns["TonDau"].HeaderText = "Tồn đầu";
                dgvNXT.Columns["Nhap"].HeaderText = "Nhập";
                dgvNXT.Columns["Xuat"].HeaderText = "Xuất";
                dgvNXT.Columns["TonCuoi"].HeaderText = "Tồn cuối";
                dgvNXT.Columns["Nguong"].HeaderText = "Ngưỡng tồn";
                dgvNXT.Columns["CanhBao"].HeaderText = "Cảnh báo";

                VeBieuDo(dt);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tô đỏ các dòng dưới ngưỡng tồn (chạy mỗi khi lưới nạp xong dữ liệu)
        private void dgvNXT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvNXT.Rows)
            {
                object canhBao = row.Cells["CanhBao"].Value;
                if (canhBao != null && canhBao.ToString() == "Dưới ngưỡng")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 199, 206);
                }
            }
        }

        // =========================================================
        // CÁC NÚT
        // =========================================================
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadData();

            DataTable dt = dgvNXT.DataSource as DataTable;
            if (dt != null && dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Bấm đúp một dòng để xem chứng từ nguồn của sản phẩm đó
        private void dgvNXT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string maSP = dgvNXT.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
            string tenSP = dgvNXT.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();

            frmChiTietChungTu f = new frmChiTietChungTu(maSP, tenSP, tuNgayDaXem, denNgayDaXem);
            f.ShowDialog();
        }

        // Xuất ra file CSV (Excel mở được), không cần cài thư viện nào
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvNXT.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để xuất. Hãy bấm Xem trước.");
                return;
            }

            SaveFileDialog hopLuu = new SaveFileDialog();
            hopLuu.Filter = "File CSV (mở bằng Excel) (*.csv)|*.csv";
            hopLuu.FileName = "ThongKeNhapXuatTon_" + tuNgayDaXem.ToString("ddMMyyyy") + "_" + denNgayDaXem.ToString("ddMMyyyy") + ".csv";

            if (hopLuu.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                // Dấu phân cách cột lấy theo cài đặt vùng của máy (Excel dùng đúng dấu này để tách cột)
                string sep = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("THỐNG KÊ NHẬP - XUẤT - TỒN từ " + tuNgayDaXem.ToString("dd/MM/yyyy") + " đến " + denNgayDaXem.ToString("dd/MM/yyyy"));
                sb.AppendLine();
                sb.AppendLine(string.Join(sep, new string[] {
                    "Mã SP", "Tên sản phẩm", "Danh mục", "Tồn đầu", "Nhập", "Xuất", "Tồn cuối", "Ngưỡng tồn", "Cảnh báo" }));

                foreach (DataRow row in dt.Rows)
                {
                    sb.AppendLine(string.Join(sep, new string[] {
                        CsvChuoi(row["MaSP"], sep),
                        CsvChuoi(row["TenSP"], sep),
                        CsvChuoi(row["TenDanhMuc"], sep),
                        row["TonDau"].ToString(),
                        row["Nhap"].ToString(),
                        row["Xuat"].ToString(),
                        row["TonCuoi"].ToString(),
                        row["Nguong"].ToString(),
                        CsvChuoi(row["CanhBao"], sep) }));
                }

                // UTF8 có BOM để Excel đọc đúng tiếng Việt có dấu
                File.WriteAllText(hopLuu.FileName, sb.ToString(), new UTF8Encoding(true));

                MessageBox.Show("Xuất file thành công, bạn mở bằng Excel nhé");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bọc chuỗi trong dấu nháy kép nếu có dấu phân cách hoặc dấu nháy
        private string CsvChuoi(object giaTri, string sep)
        {
            string chuoi = Convert.ToString(giaTri);
            if (chuoi.Contains(sep) || chuoi.Contains("\""))
            {
                chuoi = "\"" + chuoi.Replace("\"", "\"\"") + "\"";
            }
            return chuoi;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}