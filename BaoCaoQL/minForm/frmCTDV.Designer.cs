
namespace BaoCaoQL.minForm
{
    partial class frmCTDV
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgridChiTietDV = new System.Windows.Forms.DataGridView();
            this.MaCTPhieuDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDVDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDatDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridChiTietDV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtgridChiTietDV);
            this.groupBox3.Location = new System.Drawing.Point(31, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(753, 321);
            this.groupBox3.TabIndex = 95;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dịch vụ đã đặt";
            // 
            // dtgridChiTietDV
            // 
            this.dtgridChiTietDV.AllowUserToAddRows = false;
            this.dtgridChiTietDV.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dtgridChiTietDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridChiTietDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTPhieuDichVu,
            this.TenDVDat,
            this.SoLuongDat,
            this.NgayDatDichVu,
            this.GioDat,
            this.ThanhTien});
            this.dtgridChiTietDV.EnableHeadersVisualStyles = false;
            this.dtgridChiTietDV.Location = new System.Drawing.Point(19, 21);
            this.dtgridChiTietDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgridChiTietDV.Name = "dtgridChiTietDV";
            this.dtgridChiTietDV.ReadOnly = true;
            this.dtgridChiTietDV.RowHeadersVisible = false;
            this.dtgridChiTietDV.RowHeadersWidth = 51;
            this.dtgridChiTietDV.RowTemplate.Height = 24;
            this.dtgridChiTietDV.Size = new System.Drawing.Size(717, 282);
            this.dtgridChiTietDV.TabIndex = 0;
            // 
            // MaCTPhieuDichVu
            // 
            this.MaCTPhieuDichVu.DataPropertyName = "MaCTPhieuDichVu";
            this.MaCTPhieuDichVu.HeaderText = "Mã Dịch vụ";
            this.MaCTPhieuDichVu.MinimumWidth = 6;
            this.MaCTPhieuDichVu.Name = "MaCTPhieuDichVu";
            this.MaCTPhieuDichVu.ReadOnly = true;
            this.MaCTPhieuDichVu.Visible = false;
            this.MaCTPhieuDichVu.Width = 125;
            // 
            // TenDVDat
            // 
            this.TenDVDat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenDVDat.DataPropertyName = "TenDV";
            this.TenDVDat.HeaderText = "Tên dịch vụ";
            this.TenDVDat.MinimumWidth = 6;
            this.TenDVDat.Name = "TenDVDat";
            this.TenDVDat.ReadOnly = true;
            // 
            // SoLuongDat
            // 
            this.SoLuongDat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoLuongDat.DataPropertyName = "SoLuong";
            this.SoLuongDat.HeaderText = "Số Lượng";
            this.SoLuongDat.MinimumWidth = 6;
            this.SoLuongDat.Name = "SoLuongDat";
            this.SoLuongDat.ReadOnly = true;
            // 
            // NgayDatDichVu
            // 
            this.NgayDatDichVu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayDatDichVu.DataPropertyName = "NgayDat";
            this.NgayDatDichVu.HeaderText = "Ngày Đặt ";
            this.NgayDatDichVu.MinimumWidth = 6;
            this.NgayDatDichVu.Name = "NgayDatDichVu";
            this.NgayDatDichVu.ReadOnly = true;
            // 
            // GioDat
            // 
            this.GioDat.DataPropertyName = "GioDat";
            this.GioDat.HeaderText = "Giờ đặt";
            this.GioDat.MinimumWidth = 6;
            this.GioDat.Name = "GioDat";
            this.GioDat.ReadOnly = true;
            this.GioDat.Width = 130;
            // 
            // ThanhTien
            // 
            this.ThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.MinimumWidth = 6;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // frmCTDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(811, 352);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmCTDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết dịch vụ";
            this.Load += new System.EventHandler(this.frmCTDV_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgridChiTietDV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgridChiTietDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTPhieuDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDVDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDatDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
    }
}