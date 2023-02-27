
namespace BaoCaoQL.minForm
{
    partial class frmLoaiphong
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
            this.lbTitleXulyloaiphong = new System.Windows.Forms.Label();
            this.grbShowAll = new System.Windows.Forms.GroupBox();
            this.btnThemLoaiphong = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtGiaphong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenloaiphong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grbShowAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitleXulyloaiphong
            // 
            this.lbTitleXulyloaiphong.AutoSize = true;
            this.lbTitleXulyloaiphong.Location = new System.Drawing.Point(59, 23);
            this.lbTitleXulyloaiphong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitleXulyloaiphong.Name = "lbTitleXulyloaiphong";
            this.lbTitleXulyloaiphong.Size = new System.Drawing.Size(114, 17);
            this.lbTitleXulyloaiphong.TabIndex = 49;
            this.lbTitleXulyloaiphong.Text = "Thêm loại phòng";
            // 
            // grbShowAll
            // 
            this.grbShowAll.Controls.Add(this.btnThemLoaiphong);
            this.grbShowAll.Controls.Add(this.btnHuy);
            this.grbShowAll.Controls.Add(this.txtGiaphong);
            this.grbShowAll.Controls.Add(this.label1);
            this.grbShowAll.Controls.Add(this.txtTenloaiphong);
            this.grbShowAll.Controls.Add(this.label6);
            this.grbShowAll.Location = new System.Drawing.Point(44, 66);
            this.grbShowAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbShowAll.Name = "grbShowAll";
            this.grbShowAll.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbShowAll.Size = new System.Drawing.Size(667, 331);
            this.grbShowAll.TabIndex = 50;
            this.grbShowAll.TabStop = false;
            // 
            // btnThemLoaiphong
            // 
            this.btnThemLoaiphong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLoaiphong.Location = new System.Drawing.Point(305, 208);
            this.btnThemLoaiphong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThemLoaiphong.Name = "btnThemLoaiphong";
            this.btnThemLoaiphong.Size = new System.Drawing.Size(127, 30);
            this.btnThemLoaiphong.TabIndex = 53;
            this.btnThemLoaiphong.Text = "Thêm";
            this.btnThemLoaiphong.UseVisualStyleBackColor = true;
            this.btnThemLoaiphong.Click += new System.EventHandler(this.btnThemLoaiphong_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(493, 209);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 28);
            this.btnHuy.TabIndex = 51;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtGiaphong
            // 
            this.txtGiaphong.Location = new System.Drawing.Point(479, 62);
            this.txtGiaphong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGiaphong.Name = "txtGiaphong";
            this.txtGiaphong.Size = new System.Drawing.Size(113, 22);
            this.txtGiaphong.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 51;
            this.label1.Text = "Giá phòng:";
            // 
            // txtTenloaiphong
            // 
            this.txtTenloaiphong.Location = new System.Drawing.Point(225, 62);
            this.txtTenloaiphong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenloaiphong.Name = "txtTenloaiphong";
            this.txtTenloaiphong.Size = new System.Drawing.Size(113, 22);
            this.txtTenloaiphong.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 47;
            this.label6.Text = "Tên phòng:";
            // 
            // frmLoaiphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 445);
            this.Controls.Add(this.grbShowAll);
            this.Controls.Add(this.lbTitleXulyloaiphong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmLoaiphong";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmLoaiphong";
            this.Load += new System.EventHandler(this.frmLoaiphong_Load);
            this.grbShowAll.ResumeLayout(false);
            this.grbShowAll.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTitleXulyloaiphong;
        private System.Windows.Forms.GroupBox grbShowAll;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox txtTenloaiphong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGiaphong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemLoaiphong;
    }
}