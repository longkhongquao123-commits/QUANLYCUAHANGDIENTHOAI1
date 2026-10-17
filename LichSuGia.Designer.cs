namespace qlyLichSuGia
{
    partial class LichSuGia
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
            txtMaLichSuGia = new TextBox();
            txtGiaBan = new TextBox();
            txtMaSP = new TextBox();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnGhi = new Button();
            btnLamMoi = new Button();
            btnTimKiem = new Button();
            btnTim = new Button();
            dgvLichSuGia = new DataGridView();
            MaLichSuGia = new DataGridViewTextBoxColumn();
            MaSP = new DataGridViewTextBoxColumn();
            GiaBan = new DataGridViewTextBoxColumn();
            TuNgay = new DataGridViewTextBoxColumn();
            DenNgay = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuGia).BeginInit();
            SuspendLayout();
            // 
            // txtMaLichSuGia
            // 
            txtMaLichSuGia.Enabled = false;
            txtMaLichSuGia.Location = new Point(166, 12);
            txtMaLichSuGia.Name = "txtMaLichSuGia";
            txtMaLichSuGia.Size = new Size(125, 27);
            txtMaLichSuGia.TabIndex = 0;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Enabled = false;
            txtGiaBan.Location = new Point(166, 78);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(125, 27);
            txtGiaBan.TabIndex = 1;
            // 
            // txtMaSP
            // 
            txtMaSP.Enabled = false;
            txtMaSP.Location = new Point(166, 45);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(125, 27);
            txtMaSP.TabIndex = 2;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Enabled = false;
            dtpDenNgay.Location = new Point(515, 45);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(250, 27);
            dtpDenNgay.TabIndex = 3;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Enabled = false;
            dtpTuNgay.Location = new Point(515, 12);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(250, 27);
            dtpTuNgay.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 15);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 5;
            label1.Text = "Mã lịch sử giá";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 45);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 6;
            label2.Text = "Mã sản phẩm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 81);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 7;
            label3.Text = "Giá bán";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(422, 12);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 8;
            label4.Text = "Từ ngày";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(422, 48);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 9;
            label5.Text = "Đến ngày";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(3, 110);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(96, 33);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(115, 111);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(95, 33);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(226, 111);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(99, 32);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnGhi
            // 
            btnGhi.Enabled = false;
            btnGhi.Location = new Point(345, 111);
            btnGhi.Name = "btnGhi";
            btnGhi.Size = new Size(98, 32);
            btnGhi.TabIndex = 13;
            btnGhi.Text = "Ghi dữ liệu";
            btnGhi.UseVisualStyleBackColor = true;
            btnGhi.Click += btnGhi_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(481, 112);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 32);
            btnLamMoi.TabIndex = 14;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(600, 112);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(102, 31);
            btnTimKiem.TabIndex = 15;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(728, 113);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(92, 31);
            btnTim.TabIndex = 16;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // dgvLichSuGia
            // 
            dgvLichSuGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSuGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSuGia.Columns.AddRange(new DataGridViewColumn[] { MaLichSuGia, MaSP, GiaBan, TuNgay, DenNgay });
            dgvLichSuGia.Location = new Point(12, 149);
            dgvLichSuGia.Name = "dgvLichSuGia";
            dgvLichSuGia.RowHeadersWidth = 51;
            dgvLichSuGia.Size = new Size(837, 289);
            dgvLichSuGia.TabIndex = 17;
            // 
            // MaLichSuGia
            // 
            MaLichSuGia.DataPropertyName = "MaLichSuGia";
            MaLichSuGia.HeaderText = "Mã lịch sử giá";
            MaLichSuGia.MinimumWidth = 6;
            MaLichSuGia.Name = "MaLichSuGia";
            // 
            // MaSP
            // 
            MaSP.DataPropertyName = "MaSP";
            MaSP.HeaderText = "Mã sản phẩm";
            MaSP.MinimumWidth = 6;
            MaSP.Name = "MaSP";
            // 
            // GiaBan
            // 
            GiaBan.DataPropertyName = "GiaBan";
            GiaBan.HeaderText = "Giá bán";
            GiaBan.MinimumWidth = 6;
            GiaBan.Name = "GiaBan";
            // 
            // TuNgay
            // 
            TuNgay.DataPropertyName = "TuNgay";
            TuNgay.HeaderText = "Từ Ngày ";
            TuNgay.MinimumWidth = 6;
            TuNgay.Name = "TuNgay";
            // 
            // DenNgay
            // 
            DenNgay.DataPropertyName = "DenNgay";
            DenNgay.HeaderText = "Đến ngày";
            DenNgay.MinimumWidth = 6;
            DenNgay.Name = "DenNgay";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 450);
            Controls.Add(dgvLichSuGia);
            Controls.Add(btnTim);
            Controls.Add(btnTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnGhi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpTuNgay);
            Controls.Add(dtpDenNgay);
            Controls.Add(txtMaSP);
            Controls.Add(txtGiaBan);
            Controls.Add(txtMaLichSuGia);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvLichSuGia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaLichSuGia;
        private TextBox txtGiaBan;
        private TextBox txtMaSP;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnGhi;
        private Button btnLamMoi;
        private Button btnTimKiem;
        private Button btnTim;
        private DataGridView dgvLichSuGia;
        private DataGridViewTextBoxColumn MaLichSuGia;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn GiaBan;
        private DataGridViewTextBoxColumn TuNgay;
        private DataGridViewTextBoxColumn DenNgay;
    }
}
