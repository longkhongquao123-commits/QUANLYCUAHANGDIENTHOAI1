namespace QUANLYCUAHANGDIENTHOAI
{
    partial class FormThongKeHangBanChay
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            grpBoLoc = new GroupBox();
            btnXuatExcel = new Button();
            btnThongKe = new Button();
            numTopN = new NumericUpDown();
            numNam = new NumericUpDown();
            cboThang = new ComboBox();
            lblTopN = new Label();
            lblNam = new Label();
            lblThang = new Label();
            grpBangSoLieu = new GroupBox();
            dgvBanChay = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            grpBieuDo = new GroupBox();
            pnlBieuDo = new Panel();
            grpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTopN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNam).BeginInit();
            grpBangSoLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBanChay).BeginInit();
            grpBieuDo.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(24, 30, 54);
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(443, 37);
            label1.TabIndex = 3;
            label1.Text = "THỐNG KÊ TOP HÀNG BÁN CHẠY";
            // 
            // grpBoLoc
            // 
            grpBoLoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBoLoc.BackColor = Color.White;
            grpBoLoc.Controls.Add(btnXuatExcel);
            grpBoLoc.Controls.Add(btnThongKe);
            grpBoLoc.Controls.Add(numTopN);
            grpBoLoc.Controls.Add(numNam);
            grpBoLoc.Controls.Add(cboThang);
            grpBoLoc.Controls.Add(lblTopN);
            grpBoLoc.Controls.Add(lblNam);
            grpBoLoc.Controls.Add(lblThang);
            grpBoLoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpBoLoc.Location = new Point(20, 65);
            grpBoLoc.Name = "grpBoLoc";
            grpBoLoc.Size = new Size(1000, 90);
            grpBoLoc.TabIndex = 0;
            grpBoLoc.TabStop = false;
            grpBoLoc.Text = "Bộ Lọc Thống Kê";
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.MediumSeaGreen;
            btnXuatExcel.Cursor = Cursors.Hand;
            btnXuatExcel.FlatAppearance.BorderSize = 0;
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(805, 34);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(140, 38);
            btnXuatExcel.TabIndex = 7;
            btnXuatExcel.Text = "📗 Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.DodgerBlue;
            btnThongKe.Cursor = Cursors.Hand;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.Location = new Point(650, 34);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(140, 38);
            btnThongKe.TabIndex = 6;
            btnThongKe.Text = "📊 Thống Kê";
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // numTopN
            // 
            numTopN.Font = new Font("Segoe UI", 10F);
            numTopN.Location = new Point(535, 39);
            numTopN.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numTopN.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTopN.Name = "numTopN";
            numTopN.Size = new Size(80, 30);
            numTopN.TabIndex = 5;
            numTopN.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // numNam
            // 
            numNam.Font = new Font("Segoe UI", 10F);
            numNam.Location = new Point(320, 39);
            numNam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numNam.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            numNam.Name = "numNam";
            numNam.Size = new Size(100, 30);
            numNam.TabIndex = 4;
            numNam.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // cboThang
            // 
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.Font = new Font("Segoe UI", 10F);
            cboThang.FormattingEnabled = true;
            cboThang.Location = new Point(120, 38);
            cboThang.Name = "cboThang";
            cboThang.Size = new Size(120, 31);
            cboThang.TabIndex = 3;
            // 
            // lblTopN
            // 
            lblTopN.AutoSize = true;
            lblTopN.Font = new Font("Segoe UI", 10F);
            lblTopN.Location = new Point(445, 42);
            lblTopN.Name = "lblTopN";
            lblTopN.Size = new Size(75, 23);
            lblTopN.TabIndex = 2;
            lblTopN.Text = "Lấy TOP:";
            // 
            // lblNam
            // 
            lblNam.AutoSize = true;
            lblNam.Font = new Font("Segoe UI", 10F);
            lblNam.Location = new Point(265, 42);
            lblNam.Name = "lblNam";
            lblNam.Size = new Size(51, 23);
            lblNam.TabIndex = 1;
            lblNam.Text = "Năm:";
            // 
            // lblThang
            // 
            lblThang.AutoSize = true;
            lblThang.Font = new Font("Segoe UI", 10F);
            lblThang.Location = new Point(15, 42);
            lblThang.Name = "lblThang";
            lblThang.Size = new Size(105, 23);
            lblThang.TabIndex = 0;
            lblThang.Text = "Chọn tháng:";
            // 
            // grpBangSoLieu
            // 
            grpBangSoLieu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpBangSoLieu.Controls.Add(dgvBanChay);
            grpBangSoLieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpBangSoLieu.Location = new Point(20, 170);
            grpBangSoLieu.Name = "grpBangSoLieu";
            grpBangSoLieu.Size = new Size(550, 450);
            grpBangSoLieu.TabIndex = 1;
            grpBangSoLieu.TabStop = false;
            grpBangSoLieu.Text = "Chi tiết Số liệu Bán hàng";
            // 
            // dgvBanChay
            // 
            dgvBanChay.AllowUserToAddRows = false;
            dgvBanChay.AllowUserToDeleteRows = false;
            dgvBanChay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBanChay.BackgroundColor = Color.White;
            dgvBanChay.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(242, 245, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBanChay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBanChay.ColumnHeadersHeight = 40;
            dgvBanChay.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBanChay.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBanChay.Dock = DockStyle.Fill;
            dgvBanChay.EnableHeadersVisualStyles = false;
            dgvBanChay.Location = new Point(3, 26);
            dgvBanChay.Name = "dgvBanChay";
            dgvBanChay.ReadOnly = true;
            dgvBanChay.RowHeadersVisible = false;
            dgvBanChay.RowHeadersWidth = 51;
            dgvBanChay.RowTemplate.Height = 35;
            dgvBanChay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBanChay.Size = new Size(544, 421);
            dgvBanChay.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "MaSP";
            Column1.HeaderText = "Mã SP";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "TenSP";
            Column2.HeaderText = "Tên Sản Phẩm";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "TongSoLuongBan";
            Column3.HeaderText = "SL Bán";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "TongDoanhThu";
            Column4.HeaderText = "Tổng Tiền";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // grpBieuDo
            // 
            grpBieuDo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpBieuDo.Controls.Add(pnlBieuDo);
            grpBieuDo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpBieuDo.Location = new Point(590, 170);
            grpBieuDo.Name = "grpBieuDo";
            grpBieuDo.Size = new Size(430, 450);
            grpBieuDo.TabIndex = 2;
            grpBieuDo.TabStop = false;
            grpBieuDo.Text = "Biểu Đồ Trực Quan";
            // 
            // pnlBieuDo
            // 
            pnlBieuDo.BackColor = Color.White;
            pnlBieuDo.Dock = DockStyle.Fill;
            pnlBieuDo.Location = new Point(3, 26);
            pnlBieuDo.Name = "pnlBieuDo";
            pnlBieuDo.Padding = new Padding(10);
            pnlBieuDo.Size = new Size(424, 421);
            pnlBieuDo.TabIndex = 0;
            // 
            // FormThongKeHangBanChay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 250);
            ClientSize = new Size(1040, 640);
            Controls.Add(label1);
            Controls.Add(grpBieuDo);
            Controls.Add(grpBangSoLieu);
            Controls.Add(grpBoLoc);
            Name = "FormThongKeHangBanChay";
            Text = "Thống Kê Top Hàng Bán Chạy";
            grpBoLoc.ResumeLayout(false);
            grpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTopN).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNam).EndInit();
            grpBangSoLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBanChay).EndInit();
            grpBieuDo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.NumericUpDown numTopN;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Label lblTopN;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.GroupBox grpBangSoLieu;
        private System.Windows.Forms.DataGridView dgvBanChay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.GroupBox grpBieuDo;
        private System.Windows.Forms.Panel pnlBieuDo;
    }
}