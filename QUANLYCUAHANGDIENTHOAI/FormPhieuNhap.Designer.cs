namespace QUANLYCUAHANGDIENTHOAI
{
    partial class FormPhieuNhap
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
            this.grpThongTinPhieu = new GroupBox();
            grpChiTietDong = new GroupBox();
            groupBox3 = new GroupBox();
            grpChiTietDong.SuspendLayout();
            SuspendLayout();
            // 
            // grpThongTinPhieu
            // 
            this.grpThongTinPhieu.Location = new Point(149, 96);
            this.grpThongTinPhieu.Name = "grpThongTinPhieu";
            this.grpThongTinPhieu.RightToLeft = RightToLeft.No;
            this.grpThongTinPhieu.Size = new Size(250, 125);
            this.grpThongTinPhieu.TabIndex = 0;
            this.grpThongTinPhieu.TabStop = false;
            this.grpThongTinPhieu.Text = "Thông tin Phiếu Nhập";
            // 
            // grpChiTietDong
            // 
            grpChiTietDong.Controls.Add(groupBox3);
            grpChiTietDong.Location = new Point(275, 163);
            grpChiTietDong.Name = "grpChiTietDong";
            grpChiTietDong.Size = new Size(250, 125);
            grpChiTietDong.TabIndex = 1;
            grpChiTietDong.TabStop = false;
            grpChiTietDong.Text = "Chi tiết Dòng Hàng và Đánh Giá Chất Lượng";
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(185, 117);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(250, 125);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // FormPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpChiTietDong);
            Controls.Add(this.grpThongTinPhieu);
            Name = "FormPhieuNhap";
            Text = "FormPhieuNhap";
            grpChiTietDong.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox grpChiTietDong;
        private GroupBox groupBox3;
    }
}