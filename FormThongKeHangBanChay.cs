using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QUANLYCUAHANGDIENTHOAI
{
    public partial class FormThongKeHangBanChay : Form
    {
        // Chuỗi kết nối CSDL SQL Server
        string strKetNoi = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDienThoai;Integrated Security=True";

        public FormThongKeHangBanChay()
        {
            InitializeComponent();
            this.Load += FormThongKeHangBanChay_Load;
        }

        private void FormThongKeHangBanChay_Load(object sender, EventArgs e)
        {
            if (cboThang == null) return;
            cboThang.Items.Clear();
            cboThang.Items.Add("0 - Tất cả các tháng");
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add("Tháng " + i);
            }
            cboThang.SelectedIndex = 9; // Mặc định chọn Tháng 9
            numNam.Value = 2026;
            numTopN.Value = 5;

            TaiDuLieuThongKe();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            TaiDuLieuThongKe();
        }

        private void TaiDuLieuThongKe()
        {
            if (cboThang == null) return;
            int thang = cboThang.SelectedIndex;
            int nam = (int)numNam.Value;
            int topN = (int)numTopN.Value;

            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ThongKeHangBanChay", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    cmd.Parameters.AddWithValue("@TopN", topN);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 1. Đổ dữ liệu lên bảng DataGridView
                    dgvBanChay.DataSource = dt;

                    // 2. Vẽ biểu đồ cột trực tiếp lên pnlBieuDo
                    VeBieuDoTrenPanel(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu bán hàng trong thời gian này!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải thống kê: " + ex.Message);
                }
            }
        }

        // Hàm tự động dựng biểu đồ cột lên Panel
        private void VeBieuDoTrenPanel(DataTable dt)
        {
            pnlBieuDo.Controls.Clear();

            if (dt.Rows.Count == 0) return;

            // Tìm số lượng bán lớn nhất để tính tỷ lệ chiều cao cột
            int maxSoLuong = 1;
            foreach (DataRow r in dt.Rows)
            {
                int sl = Convert.ToInt32(r["TongSoLuongBan"]);
                if (sl > maxSoLuong) maxSoLuong = sl;
            }

            int chieuRongPanel = pnlBieuDo.Width;
            int chieuCaoPanel = pnlBieuDo.Height;
            int chieuCaoToiDaCot = chieuCaoPanel - 90; // Đã thêm dấu trừ (-)
            int soCot = dt.Rows.Count;
            int khoangCach = 20;
            int doRongCot = Math.Min(70, (chieuRongPanel - (soCot + 1) * khoangCach) / soCot); // Đã sửa biểu thức toán học

            Color[] bangMau = { Color.DodgerBlue, Color.ForestGreen, Color.DarkOrange, Color.Crimson, Color.MediumPurple };

            for (int i = 0; i < soCot; i++)
            {
                string maSP = dt.Rows[i]["MaSP"].ToString();
                int soLuong = Convert.ToInt32(dt.Rows[i]["TongSoLuongBan"]);

                // Tính chiều cao cột theo tỷ lệ
                int chieuCaoCot = (int)((double)soLuong / maxSoLuong * chieuCaoToiDaCot); // Đã thêm dấu nhân (*)
                if (chieuCaoCot < 5 && soLuong > 0) chieuCaoCot = 5;

                int viTriX = khoangCach + i * (doRongCot + khoangCach); // Đã thêm dấu nhân (*)
                int viTriY = chieuCaoPanel - chieuCaoCot - 40; // Đã thêm dấu trừ (-)

                // 1. Tạo khối cột biểu đồ
                Panel cot = new Panel();
                cot.Size = new Size(doRongCot, chieuCaoCot);
                cot.Location = new Point(viTriX, viTriY);
                cot.BackColor = bangMau[i % bangMau.Length];
                pnlBieuDo.Controls.Add(cot);

                // 2. Tạo nhãn hiển thị số lượng trên đỉnh cột
                Label lblSoLuong = new Label();
                lblSoLuong.Text = soLuong.ToString();
                lblSoLuong.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lblSoLuong.AutoSize = false;
                lblSoLuong.Size = new Size(doRongCot + 10, 20);
                lblSoLuong.TextAlign = ContentAlignment.MiddleCenter;
                lblSoLuong.Location = new Point(viTriX - 5, viTriY - 22); // Đã thêm dấu trừ (-)
                pnlBieuDo.Controls.Add(lblSoLuong);

                // 3. Tạo nhãn hiển thị Mã SP dưới chân cột
                Label lblMaSP = new Label();
                lblMaSP.Text = maSP;
                lblMaSP.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lblMaSP.AutoSize = false;
                lblMaSP.Size = new Size(doRongCot + 10, 25);
                lblMaSP.TextAlign = ContentAlignment.MiddleCenter;
                lblMaSP.Location = new Point(viTriX - 5, chieuCaoPanel - 35); // Đã thêm dấu trừ (-)
                pnlBieuDo.Controls.Add(lblMaSP);
            }
        }

        // Chức năng Xuất ra file CSV/Excel
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvBanChay.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File (*.csv)|*.csv";
            sfd.FileName = "ThongKeHangBanChay_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Mã SP,Tên Sản Phẩm,Tổng Số Lượng Bán,Tổng Doanh Thu");

                foreach (DataGridViewRow row in dgvBanChay.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        sb.AppendLine($"{row.Cells["MaSP"].Value},\"{row.Cells["TenSP"].Value}\",{row.Cells["TongSoLuongBan"].Value},{row.Cells["TongDoanhThu"].Value}");
                    }
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Xuất báo cáo thành công!", "Thông báo");
            }
        }

       
        }
    }
