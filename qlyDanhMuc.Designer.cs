namespace qlydthoai
{
    partial class Form1
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
            txtMaDanhMuc = new TextBox();
            txtTenDanhMuc = new TextBox();
            txtMoTa = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvDanhMuc = new DataGridView();
            MaDanhMuc = new DataGridViewTextBoxColumn();
            TenDanhMuc = new DataGridViewTextBoxColumn();
            MoTa = new DataGridViewTextBoxColumn();
            btnGhi = new Button();
            btnHuy = new Button();
            btnTimKiem = new Button();
            btnTim = new Button();
            btnLamMoi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDanhMuc).BeginInit();
            SuspendLayout();
            // 
            // txtMaDanhMuc
            // 
            txtMaDanhMuc.Enabled = false;
            txtMaDanhMuc.Location = new Point(143, 22);
            txtMaDanhMuc.Name = "txtMaDanhMuc";
            txtMaDanhMuc.Size = new Size(230, 27);
            txtMaDanhMuc.TabIndex = 0;
            // 
            // txtTenDanhMuc
            // 
            txtTenDanhMuc.Enabled = false;
            txtTenDanhMuc.Location = new Point(143, 66);
            txtTenDanhMuc.Name = "txtTenDanhMuc";
            txtTenDanhMuc.Size = new Size(230, 27);
            txtTenDanhMuc.TabIndex = 1;
            // 
            // txtMoTa
            // 
            txtMoTa.Enabled = false;
            txtMoTa.Location = new Point(143, 119);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(230, 27);
            txtMoTa.TabIndex = 2;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(15, 169);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(63, 39);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(107, 169);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(63, 39);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(198, 169);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(63, 39);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 22);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 7;
            label1.Text = "Mã danh mục";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 69);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 8;
            label2.Text = "Tên danh mục";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 119);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 9;
            label3.Text = "Mô tả";
            // 
            // dgvDanhMuc
            // 
            dgvDanhMuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhMuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhMuc.Columns.AddRange(new DataGridViewColumn[] { MaDanhMuc, TenDanhMuc, MoTa });
            dgvDanhMuc.Location = new Point(72, 214);
            dgvDanhMuc.Name = "dgvDanhMuc";
            dgvDanhMuc.RowHeadersWidth = 51;
            dgvDanhMuc.Size = new Size(716, 235);
            dgvDanhMuc.TabIndex = 10;
            // 
            // MaDanhMuc
            // 
            MaDanhMuc.DataPropertyName = "MaDanhMuc";
            MaDanhMuc.HeaderText = "Mã danh mục";
            MaDanhMuc.MinimumWidth = 6;
            MaDanhMuc.Name = "MaDanhMuc";
            // 
            // TenDanhMuc
            // 
            TenDanhMuc.DataPropertyName = "TenDanhMuc";
            TenDanhMuc.HeaderText = "Tên danh mục";
            TenDanhMuc.MinimumWidth = 6;
            TenDanhMuc.Name = "TenDanhMuc";
            // 
            // MoTa
            // 
            MoTa.DataPropertyName = "MoTa";
            MoTa.HeaderText = "Mô tả";
            MoTa.MinimumWidth = 6;
            MoTa.Name = "MoTa";
            // 
            // btnGhi
            // 
            btnGhi.Location = new Point(283, 169);
            btnGhi.Name = "btnGhi";
            btnGhi.Size = new Size(90, 39);
            btnGhi.TabIndex = 11;
            btnGhi.Text = "Ghi dữ liệu";
            btnGhi.UseVisualStyleBackColor = true;
            btnGhi.Click += txtGhiDuLieu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(397, 174);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(65, 34);
            btnHuy.TabIndex = 12;
            btnHuy.Text = "Huỷ";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(482, 174);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(598, 174);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 29);
            btnTim.TabIndex = 14;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(714, 174);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 469);
            Controls.Add(btnLamMoi);
            Controls.Add(btnTim);
            Controls.Add(btnTimKiem);
            Controls.Add(btnHuy);
            Controls.Add(btnGhi);
            Controls.Add(dgvDanhMuc);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtMoTa);
            Controls.Add(txtTenDanhMuc);
            Controls.Add(txtMaDanhMuc);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvDanhMuc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaDanhMuc;
        private TextBox txtTenDanhMuc;
        private TextBox txtMoTa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgvDanhMuc;
        private DataGridViewTextBoxColumn MaDanhMuc;
        private DataGridViewTextBoxColumn TenDanhMuc;
        private DataGridViewTextBoxColumn MoTa;
        private Button btnGhi;
        private Button btnHuy;
        private Button btnTimKiem;
        private Button btnTim;
        private Button btnLamMoi;
    }
}
