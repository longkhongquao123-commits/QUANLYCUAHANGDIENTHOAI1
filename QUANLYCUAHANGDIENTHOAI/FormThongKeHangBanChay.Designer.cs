namespace QUANLYCUAHANGDIENTHOAI
{
    partial class FormThongKeHangBanChay
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
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
            label1 = new Label();
            grpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTopN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNam).BeginInit();
            grpBangSoLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBanChay).BeginInit();
            grpBieuDo.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoLoc
            // 
            grpBoLoc.Controls.Add(btnXuatExcel);
            grpBoLoc.Controls.Add(btnThongKe);
            grpBoLoc.Controls.Add(numTopN);
            grpBoLoc.Controls.Add(numNam);
            grpBoLoc.Controls.Add(cboThang);
            grpBoLoc.Controls.Add(lblTopN);
            grpBoLoc.Controls.Add(lblNam);
            grpBoLoc.Controls.Add(lblThang);
            grpBoLoc.Location = new Point(12, 51);
            grpBoLoc.Name = "grpBoLoc";
            grpBoLoc.Size = new Size(950, 167);
            grpBoLoc.TabIndex = 0;
            grpBoLoc.TabStop = false;
            grpBoLoc.Text = "Bộ Lọc Thống Kê";
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.DialogResult = DialogResult.Ignore;
            btnXuatExcel.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnXuatExcel.Location = new Point(430, 96);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(125, 29);
            btnXuatExcel.TabIndex = 7;
            btnXuatExcel.Text = "Xuất file Excel";
            btnXuatExcel.UseMnemonic = false;
            btnXuatExcel.UseVisualStyleBackColor = true;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnThongKe.Location = new Point(303, 96);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(94, 29);
            btnThongKe.TabIndex = 6;
            btnThongKe.Text = "Thống Kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // numTopN
            // 
            numTopN.Location = new Point(609, 47);
            numTopN.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numTopN.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTopN.Name = "numTopN";
            numTopN.Size = new Size(150, 27);
            numTopN.TabIndex = 5;
            numTopN.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // numNam
            // 
            numNam.InterceptArrowKeys = false;
            numNam.Location = new Point(357, 47);
            numNam.Maximum = new decimal(new int[] { 2030, 0, 0, 0 });
            numNam.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            numNam.Name = "numNam";
            numNam.Size = new Size(150, 27);
            numNam.TabIndex = 4;
            numNam.UseWaitCursor = true;
            numNam.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // cboThang
            // 
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.FormattingEnabled = true;
            cboThang.Location = new Point(126, 47);
            cboThang.Name = "cboThang";
            cboThang.Size = new Size(151, 28);
            cboThang.TabIndex = 3;
            // 
            // lblTopN
            // 
            lblTopN.AutoSize = true;
            lblTopN.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblTopN.Location = new Point(521, 50);
            lblTopN.Name = "lblTopN";
            lblTopN.Size = new Size(82, 20);
            lblTopN.TabIndex = 2;
            lblTopN.Text = "Lấy TOP:";
            // 
            // lblNam
            // 
            lblNam.AutoSize = true;
            lblNam.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblNam.Location = new Point(303, 50);
            lblNam.Name = "lblNam";
            lblNam.Size = new Size(48, 20);
            lblNam.TabIndex = 1;
            lblNam.Text = "Năm:";
            // 
            // lblThang
            // 
            lblThang.AutoSize = true;
            lblThang.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblThang.Location = new Point(6, 47);
            lblThang.Name = "lblThang";
            lblThang.Size = new Size(96, 20);
            lblThang.TabIndex = 0;
            lblThang.Text = "Chọn tháng:";
            // 
            // grpBangSoLieu
            // 
            grpBangSoLieu.Controls.Add(dgvBanChay);
            grpBangSoLieu.Location = new Point(12, 224);
            grpBangSoLieu.Name = "grpBangSoLieu";
            grpBangSoLieu.Size = new Size(506, 214);
            grpBangSoLieu.TabIndex = 1;
            grpBangSoLieu.TabStop = false;
            grpBangSoLieu.Text = "Bảng Số Liệu";
            // 
            // dgvBanChay
            // 
            dgvBanChay.AllowUserToAddRows = false;
            dgvBanChay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBanChay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBanChay.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dgvBanChay.Location = new Point(-3, 26);
            dgvBanChay.Name = "dgvBanChay";
            dgvBanChay.RowHeadersWidth = 51;
            dgvBanChay.Size = new Size(503, 185);
            dgvBanChay.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "MaSP";
            Column1.HeaderText = "Mã SP";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.DataPropertyName = "TenSP";
            Column2.HeaderText = "Tên Sản Phẩm";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.DataPropertyName = "TongSoLuongBan";
            Column3.HeaderText = "SL Bán";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.DataPropertyName = "TongDoanhThu";
            Column4.HeaderText = "Tổng Tiền";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // grpBieuDo
            // 
            grpBieuDo.Controls.Add(pnlBieuDo);
            grpBieuDo.Location = new Point(524, 224);
            grpBieuDo.Name = "grpBieuDo";
            grpBieuDo.Size = new Size(445, 211);
            grpBieuDo.TabIndex = 2;
            grpBieuDo.TabStop = false;
            grpBieuDo.Text = "Biểu Đồ";
            // 
            // pnlBieuDo
            // 
            pnlBieuDo.Location = new Point(9, 26);
            pnlBieuDo.Name = "pnlBieuDo";
            pnlBieuDo.Size = new Size(438, 179);
            pnlBieuDo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(262, 26);
            label1.Name = "label1";
            label1.Size = new Size(276, 22);
            label1.TabIndex = 3;
            label1.Text = "THỐNG KÊ HÀNG BÁN CHẠY";
            // 
            // FormThongKeHangBanChay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 450);
            Controls.Add(label1);
            Controls.Add(grpBieuDo);
            Controls.Add(grpBangSoLieu);
            Controls.Add(grpBoLoc);
            Name = "FormThongKeHangBanChay";
            Text = "FormThongKeHangBanChay";
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
        private GroupBox grpBoLoc;
        private GroupBox grpBangSoLieu;
        private GroupBox grpBieuDo;
        private ComboBox cboThang;
        private Label lblTopN;
        private Label lblNam;
        private Label lblThang;
        private NumericUpDown numTopN;
        private NumericUpDown numNam;
        private DataGridView dgvBanChay;
        private Panel pnlBieuDo;
        private Button btnXuatExcel;
        private Button btnThongKe;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Label label1;
    }
}
