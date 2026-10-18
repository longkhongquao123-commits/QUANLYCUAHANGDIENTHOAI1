namespace QuanLyCuaHangDienThoai
{
    partial class frmBaoCaoNXT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpLoc = new System.Windows.Forms.GroupBox();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.chkDuoiNguong = new System.Windows.Forms.CheckBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dgvNXT = new System.Windows.Forms.DataGridView();
            this.pnlBieuDo = new System.Windows.Forms.Panel();
            this.lblChuThich = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlTieuDe.SuspendLayout();
            this.grpLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXT)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTieuDe
            // 
            this.pnlTieuDe.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlTieuDe.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(1100, 56);
            this.pnlTieuDe.TabIndex = 5;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(18, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(420, 41);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THỐNG KÊ NHẬP - XUẤT - TỒN";
            // 
            // grpLoc
            // 
            this.grpLoc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.grpLoc.BackColor = System.Drawing.Color.White;
            this.grpLoc.Controls.Add(this.btnXuatExcel);
            this.grpLoc.Controls.Add(this.btnXem);
            this.grpLoc.Controls.Add(this.chkDuoiNguong);
            this.grpLoc.Controls.Add(this.cboDanhMuc);
            this.grpLoc.Controls.Add(this.lblDanhMuc);
            this.grpLoc.Controls.Add(this.dtpDenNgay);
            this.grpLoc.Controls.Add(this.lblDenNgay);
            this.grpLoc.Controls.Add(this.dtpTuNgay);
            this.grpLoc.Controls.Add(this.lblTuNgay);
            this.grpLoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpLoc.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.grpLoc.Location = new System.Drawing.Point(16, 70);
            this.grpLoc.Name = "grpLoc";
            this.grpLoc.Size = new System.Drawing.Size(1068, 124);
            this.grpLoc.TabIndex = 0;
            this.grpLoc.TabStop = false;
            this.grpLoc.Text = "Bộ lọc";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(793, 70);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(120, 36);
            this.btnXuatExcel.TabIndex = 8;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(0, 120, 212);
            this.btnXem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXem.FlatAppearance.BorderSize = 0;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(683, 70);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 36);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = false;
            // 
            // chkDuoiNguong
            // 
            this.chkDuoiNguong.AutoSize = true;
            this.chkDuoiNguong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDuoiNguong.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkDuoiNguong.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.chkDuoiNguong.Location = new System.Drawing.Point(24, 76);
            this.chkDuoiNguong.Name = "chkDuoiNguong";
            this.chkDuoiNguong.Size = new System.Drawing.Size(327, 29);
            this.chkDuoiNguong.TabIndex = 6;
            this.chkDuoiNguong.Text = "Chỉ hiện sản phẩm dưới ngưỡng tồn";
            this.chkDuoiNguong.UseVisualStyleBackColor = true;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboDanhMuc.ForeColor = System.Drawing.Color.Black;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(683, 30);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(240, 36);
            this.cboDanhMuc.TabIndex = 5;
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDanhMuc.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.lblDanhMuc.Location = new System.Drawing.Point(575, 34);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(96, 28);
            this.lblDanhMuc.TabIndex = 4;
            this.lblDanhMuc.Text = "Danh mục";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpDenNgay.ForeColor = System.Drawing.Color.Black;
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(392, 30);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 33);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.lblDenNgay.Location = new System.Drawing.Point(290, 34);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(92, 28);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpTuNgay.ForeColor = System.Drawing.Color.Black;
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(112, 30);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 33);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.lblTuNgay.Location = new System.Drawing.Point(24, 34);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(80, 28);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // dgvNXT
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(242, 246, 250);
            this.dgvNXT.AllowUserToAddRows = false;
            this.dgvNXT.AllowUserToDeleteRows = false;
            this.dgvNXT.AllowUserToResizeRows = false;
            this.dgvNXT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNXT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvNXT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNXT.BackgroundColor = System.Drawing.Color.White;
            this.dgvNXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNXT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNXT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNXT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNXT.ColumnHeadersHeight = 38;
            this.dgvNXT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(204, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNXT.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNXT.EnableHeadersVisualStyles = false;
            this.dgvNXT.GridColor = System.Drawing.Color.FromArgb(217, 226, 236);
            this.dgvNXT.Location = new System.Drawing.Point(16, 206);
            this.dgvNXT.MultiSelect = false;
            this.dgvNXT.Name = "dgvNXT";
            this.dgvNXT.ReadOnly = true;
            this.dgvNXT.RowHeadersVisible = false;
            this.dgvNXT.RowHeadersWidth = 62;
            this.dgvNXT.RowTemplate.Height = 30;
            this.dgvNXT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNXT.Size = new System.Drawing.Size(1068, 260);
            this.dgvNXT.TabIndex = 1;
            // 
            // pnlBieuDo
            // 
            this.pnlBieuDo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlBieuDo.BackColor = System.Drawing.Color.White;
            this.pnlBieuDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBieuDo.Location = new System.Drawing.Point(16, 478);
            this.pnlBieuDo.Name = "pnlBieuDo";
            this.pnlBieuDo.Size = new System.Drawing.Size(1068, 220);
            this.pnlBieuDo.TabIndex = 2;
            // 
            // lblChuThich
            // 
            this.lblChuThich.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblChuThich.AutoSize = true;
            this.lblChuThich.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblChuThich.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblChuThich.Location = new System.Drawing.Point(16, 716);
            this.lblChuThich.Name = "lblChuThich";
            this.lblChuThich.Size = new System.Drawing.Size(736, 25);
            this.lblChuThich.TabIndex = 3;
            this.lblChuThich.Text = "Dòng màu đỏ là sản phẩm dưới ngưỡng tồn. Bấm đúp một dòng để xem chứng từ nguồn.";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(974, 710);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 38);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // frmBaoCaoNXT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 243, 247);
            this.ClientSize = new System.Drawing.Size(1100, 760);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.lblChuThich);
            this.Controls.Add(this.pnlBieuDo);
            this.Controls.Add(this.dgvNXT);
            this.Controls.Add(this.grpLoc);
            this.Controls.Add(this.pnlTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmBaoCaoNXT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê nhập - xuất - tồn";
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlTieuDe.PerformLayout();
            this.grpLoc.ResumeLayout(false);
            this.grpLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpLoc;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.CheckBox chkDuoiNguong;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DataGridView dgvNXT;
        private System.Windows.Forms.Panel pnlBieuDo;
        private System.Windows.Forms.Label lblChuThich;
        private System.Windows.Forms.Button btnDong;
    }
}