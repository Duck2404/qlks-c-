
namespace BaoCaoQL.minForm
{
    partial class frmDoanhthuDichvu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dtgrDichvu = new System.Windows.Forms.DataGridView();
            this.btnReportHoaDon = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrDichvu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTong
            // 
            this.txtTong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTong.Location = new System.Drawing.Point(849, 337);
            this.txtTong.Margin = new System.Windows.Forms.Padding(4);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(197, 22);
            this.txtTong.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(820, 176);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Xuất Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtgrDichvu
            // 
            this.dtgrDichvu.AllowUserToAddRows = false;
            this.dtgrDichvu.AllowUserToDeleteRows = false;
            this.dtgrDichvu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgrDichvu.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dtgrDichvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrDichvu.Location = new System.Drawing.Point(64, 388);
            this.dtgrDichvu.Margin = new System.Windows.Forms.Padding(4);
            this.dtgrDichvu.Name = "dtgrDichvu";
            this.dtgrDichvu.ReadOnly = true;
            this.dtgrDichvu.RowHeadersVisible = false;
            this.dtgrDichvu.RowHeadersWidth = 51;
            this.dtgrDichvu.Size = new System.Drawing.Size(1035, 233);
            this.dtgrDichvu.TabIndex = 3;
            // 
            // btnReportHoaDon
            // 
            this.btnReportHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReportHoaDon.Location = new System.Drawing.Point(948, 176);
            this.btnReportHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.btnReportHoaDon.Name = "btnReportHoaDon";
            this.btnReportHoaDon.Size = new System.Drawing.Size(100, 28);
            this.btnReportHoaDon.TabIndex = 4;
            this.btnReportHoaDon.Text = "In Hóa Đơn";
            this.btnReportHoaDon.UseVisualStyleBackColor = true;
            this.btnReportHoaDon.Click += new System.EventHandler(this.btnReportHoaDon_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(101, 90);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "S1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(423, 267);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(776, 341);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tổng:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(464, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 44);
            this.label2.TabIndex = 71;
            this.label2.Text = "Doanh thu dịch vụ";
            // 
            // frmDoanhthuDichvu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1163, 635);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnReportHoaDon);
            this.Controls.Add(this.dtgrDichvu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTong);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDoanhthuDichvu";
            this.Text = "Thông kê dịch vụ";
            this.Load += new System.EventHandler(this.frmDoanhthuDichvu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrDichvu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dtgrDichvu;
        private System.Windows.Forms.Button btnReportHoaDon;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}