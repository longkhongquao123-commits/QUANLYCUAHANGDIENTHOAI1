namespace QLKHO
{
    partial class QLThietBiIMEI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lBTimIMEI = new System.Windows.Forms.Label();
            this.txtTimIMEI = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbNgayBaoHanhDen = new System.Windows.Forms.Label();
            this.txtDungLuong = new System.Windows.Forms.TextBox();
            this.lbDungLuong = new System.Windows.Forms.Label();
            this.txtMauSac = new System.Windows.Forms.TextBox();
            this.lbMauSac = new System.Windows.Forms.Label();
            this.txtMaPN = new System.Windows.Forms.TextBox();
            this.lbMaPN = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lbTrangThai = new System.Windows.Forms.Label();
            this.txtIMEI = new System.Windows.Forms.TextBox();
            this.cboTenSP = new System.Windows.Forms.ComboBox();
            this.lbTenSP = new System.Windows.Forms.Label();
            this.lbIMEI = new System.Windows.Forms.Label();
            this.dgvThietBi = new System.Windows.Forms.DataGridView();
            this.IMEI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MauSac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DungLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBaoHanhDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbLoc = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThietBi)).BeginInit();
            this.SuspendLayout();
            // 
            // lBTimIMEI
            // 
            this.lBTimIMEI.AutoSize = true;
            this.lBTimIMEI.Location = new System.Drawing.Point(20, 34);
            this.lBTimIMEI.Name = "lBTimIMEI";
            this.lBTimIMEI.Size = new System.Drawing.Size(72, 20);
            this.lBTimIMEI.TabIndex = 0;
            this.lBTimIMEI.Text = "Tìm IMEI";
            // 
            // txtTimIMEI
            // 
            this.txtTimIMEI.Location = new System.Drawing.Point(116, 31);
            this.txtTimIMEI.Name = "txtTimIMEI";
            this.txtTimIMEI.Size = new System.Drawing.Size(340, 26);
            this.txtTimIMEI.TabIndex = 1;
            this.txtTimIMEI.TextChanged += new System.EventHandler(this.txtDungLuong_TextChanged);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(730, 27);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(97, 35);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Controls.Add(this.btnGhi);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.lbNgayBaoHanhDen);
            this.groupBox1.Controls.Add(this.txtDungLuong);
            this.groupBox1.Controls.Add(this.lbDungLuong);
            this.groupBox1.Controls.Add(this.txtMauSac);
            this.groupBox1.Controls.Add(this.lbMauSac);
            this.groupBox1.Controls.Add(this.txtMaPN);
            this.groupBox1.Controls.Add(this.lbMaPN);
            this.groupBox1.Controls.Add(this.cboTrangThai);
            this.groupBox1.Controls.Add(this.lbTrangThai);
            this.groupBox1.Controls.Add(this.txtIMEI);
            this.groupBox1.Controls.Add(this.cboTenSP);
            this.groupBox1.Controls.Add(this.lbTenSP);
            this.groupBox1.Controls.Add(this.lbIMEI);
            this.groupBox1.Location = new System.Drawing.Point(0, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(949, 290);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thiết bị";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(638, 226);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(95, 34);
            this.btnHuy.TabIndex = 18;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(498, 226);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(95, 34);
            this.btnGhi.TabIndex = 17;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(361, 226);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 34);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(223, 226);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 34);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(87, 226);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 34);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(638, 122);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(293, 26);
            this.dateTimePicker1.TabIndex = 13;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lbNgayBaoHanhDen
            // 
            this.lbNgayBaoHanhDen.AutoSize = true;
            this.lbNgayBaoHanhDen.Location = new System.Drawing.Point(521, 126);
            this.lbNgayBaoHanhDen.Name = "lbNgayBaoHanhDen";
            this.lbNgayBaoHanhDen.Size = new System.Drawing.Size(110, 20);
            this.lbNgayBaoHanhDen.TabIndex = 12;
            this.lbNgayBaoHanhDen.Text = "Hạn bảo hành";
            this.lbNgayBaoHanhDen.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDungLuong
            // 
            this.txtDungLuong.Location = new System.Drawing.Point(638, 81);
            this.txtDungLuong.Name = "txtDungLuong";
            this.txtDungLuong.Size = new System.Drawing.Size(294, 26);
            this.txtDungLuong.TabIndex = 11;
            this.txtDungLuong.TextChanged += new System.EventHandler(this.txtDungLuong_TextChanged);
            // 
            // lbDungLuong
            // 
            this.lbDungLuong.AutoSize = true;
            this.lbDungLuong.Location = new System.Drawing.Point(521, 84);
            this.lbDungLuong.Name = "lbDungLuong";
            this.lbDungLuong.Size = new System.Drawing.Size(97, 20);
            this.lbDungLuong.TabIndex = 10;
            this.lbDungLuong.Text = "Dung Lượng";
            // 
            // txtMauSac
            // 
            this.txtMauSac.Location = new System.Drawing.Point(638, 41);
            this.txtMauSac.Name = "txtMauSac";
            this.txtMauSac.Size = new System.Drawing.Size(294, 26);
            this.txtMauSac.TabIndex = 9;
            this.txtMauSac.TextChanged += new System.EventHandler(this.txtMauSac_TextChanged);
            // 
            // lbMauSac
            // 
            this.lbMauSac.AutoSize = true;
            this.lbMauSac.Location = new System.Drawing.Point(521, 44);
            this.lbMauSac.Name = "lbMauSac";
            this.lbMauSac.Size = new System.Drawing.Size(72, 20);
            this.lbMauSac.TabIndex = 8;
            this.lbMauSac.Text = "Màu Sắc";
            // 
            // txtMaPN
            // 
            this.txtMaPN.Location = new System.Drawing.Point(180, 164);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Size = new System.Drawing.Size(294, 26);
            this.txtMaPN.TabIndex = 7;
            this.txtMaPN.TextChanged += new System.EventHandler(this.txtMaPN_TextChanged);
            // 
            // lbMaPN
            // 
            this.lbMaPN.AutoSize = true;
            this.lbMaPN.Location = new System.Drawing.Point(49, 167);
            this.lbMaPN.Name = "lbMaPN";
            this.lbMaPN.Size = new System.Drawing.Size(114, 20);
            this.lbMaPN.TabIndex = 6;
            this.lbMaPN.Text = "Mã phiếu nhập";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(180, 123);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(295, 28);
            this.cboTrangThai.TabIndex = 5;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);
            // 
            // lbTrangThai
            // 
            this.lbTrangThai.AutoSize = true;
            this.lbTrangThai.Location = new System.Drawing.Point(49, 126);
            this.lbTrangThai.Name = "lbTrangThai";
            this.lbTrangThai.Size = new System.Drawing.Size(80, 20);
            this.lbTrangThai.TabIndex = 4;
            this.lbTrangThai.Text = "Trạng thái";
            // 
            // txtIMEI
            // 
            this.txtIMEI.Location = new System.Drawing.Point(182, 41);
            this.txtIMEI.Name = "txtIMEI";
            this.txtIMEI.Size = new System.Drawing.Size(294, 26);
            this.txtIMEI.TabIndex = 3;
            this.txtIMEI.TextChanged += new System.EventHandler(this.txtIMEI_TextChanged);
            // 
            // cboTenSP
            // 
            this.cboTenSP.FormattingEnabled = true;
            this.cboTenSP.Location = new System.Drawing.Point(181, 81);
            this.cboTenSP.Name = "cboTenSP";
            this.cboTenSP.Size = new System.Drawing.Size(295, 28);
            this.cboTenSP.TabIndex = 2;
            this.cboTenSP.SelectedIndexChanged += new System.EventHandler(this.cboTenSP_SelectedIndexChanged);
            // 
            // lbTenSP
            // 
            this.lbTenSP.AutoSize = true;
            this.lbTenSP.Location = new System.Drawing.Point(49, 84);
            this.lbTenSP.Name = "lbTenSP";
            this.lbTenSP.Size = new System.Drawing.Size(114, 20);
            this.lbTenSP.TabIndex = 1;
            this.lbTenSP.Text = "Tên Sản Phẩm";
            // 
            // lbIMEI
            // 
            this.lbIMEI.AutoSize = true;
            this.lbIMEI.Location = new System.Drawing.Point(49, 44);
            this.lbIMEI.Name = "lbIMEI";
            this.lbIMEI.Size = new System.Drawing.Size(43, 20);
            this.lbIMEI.TabIndex = 0;
            this.lbIMEI.Text = "IMEI";
            // 
            // dgvThietBi
            // 
            this.dgvThietBi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThietBi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IMEI,
            this.MaSP,
            this.TenSP,
            this.MauSac,
            this.DungLuong,
            this.TrangThai,
            this.NgayBaoHanhDen,
            this.MaPN});
            this.dgvThietBi.Location = new System.Drawing.Point(0, 422);
            this.dgvThietBi.Name = "dgvThietBi";
            this.dgvThietBi.RowHeadersWidth = 62;
            this.dgvThietBi.RowTemplate.Height = 28;
            this.dgvThietBi.Size = new System.Drawing.Size(949, 190);
            this.dgvThietBi.TabIndex = 4;
            this.dgvThietBi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // IMEI
            // 
            this.IMEI.DataPropertyName = "IMEI";
            this.IMEI.HeaderText = "IMEI";
            this.IMEI.MinimumWidth = 8;
            this.IMEI.Name = "IMEI";
            this.IMEI.Width = 200;
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "MaSP";
            this.MaSP.MinimumWidth = 8;
            this.MaSP.Name = "MaSP";
            this.MaSP.Width = 150;
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "TenSP";
            this.TenSP.MinimumWidth = 8;
            this.TenSP.Name = "TenSP";
            this.TenSP.Width = 150;
            // 
            // MauSac
            // 
            this.MauSac.DataPropertyName = "MauSac";
            this.MauSac.HeaderText = "MauSac";
            this.MauSac.MinimumWidth = 8;
            this.MauSac.Name = "MauSac";
            this.MauSac.Width = 170;
            // 
            // DungLuong
            // 
            this.DungLuong.DataPropertyName = "DungLuong";
            this.DungLuong.HeaderText = "DungLuong";
            this.DungLuong.MinimumWidth = 8;
            this.DungLuong.Name = "DungLuong";
            this.DungLuong.Width = 150;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "TrangThai";
            this.TrangThai.MinimumWidth = 8;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 150;
            // 
            // NgayBaoHanhDen
            // 
            this.NgayBaoHanhDen.DataPropertyName = "NgayBaoHanhDen";
            this.NgayBaoHanhDen.HeaderText = "NgayBaoHanhDen";
            this.NgayBaoHanhDen.MinimumWidth = 8;
            this.NgayBaoHanhDen.Name = "NgayBaoHanhDen";
            this.NgayBaoHanhDen.Width = 180;
            // 
            // MaPN
            // 
            this.MaPN.DataPropertyName = "MaPN";
            this.MaPN.HeaderText = "MaPN";
            this.MaPN.MinimumWidth = 8;
            this.MaPN.Name = "MaPN";
            this.MaPN.Width = 110;
            // 
            // lbLoc
            // 
            this.lbLoc.AutoSize = true;
            this.lbLoc.Location = new System.Drawing.Point(480, 34);
            this.lbLoc.Name = "lbLoc";
            this.lbLoc.Size = new System.Drawing.Size(35, 20);
            this.lbLoc.TabIndex = 19;
            this.lbLoc.Text = "Lọc";
            this.lbLoc.Click += new System.EventHandler(this.lbLoc_Click);
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Location = new System.Drawing.Point(525, 31);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(178, 28);
            this.cboLocTrangThai.TabIndex = 19;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(835, 27);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(97, 35);
            this.btnLamMoi.TabIndex = 20;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 624);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.cboLocTrangThai);
            this.Controls.Add(this.lbLoc);
            this.Controls.Add(this.dgvThietBi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtTimIMEI);
            this.Controls.Add(this.lBTimIMEI);
            this.Name = "Form1";
            this.Text = "Quản lí thiết bị / IMEI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThietBi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lBTimIMEI;
        private System.Windows.Forms.TextBox txtTimIMEI;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIMEI;
        private System.Windows.Forms.ComboBox cboTenSP;
        private System.Windows.Forms.Label lbTenSP;
        private System.Windows.Forms.Label lbIMEI;
        private System.Windows.Forms.Label lbMaPN;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lbTrangThai;
        private System.Windows.Forms.TextBox txtMauSac;
        private System.Windows.Forms.Label lbMauSac;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.Label lbDungLuong;
        private System.Windows.Forms.Label lbNgayBaoHanhDen;
        private System.Windows.Forms.TextBox txtDungLuong;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgvThietBi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMEI;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MauSac;
        private System.Windows.Forms.DataGridViewTextBoxColumn DungLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBaoHanhDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPN;
        private System.Windows.Forms.Label lbLoc;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnLamMoi;
    }
}

