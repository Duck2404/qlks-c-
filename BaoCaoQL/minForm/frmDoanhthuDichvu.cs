using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace BaoCaoQL.minForm
{
    public partial class frmDoanhthuDichvu : Form
    {
        public float tongtien1, tongtien2, tongtien3, tongtien4, tongtien5, tongtien6, tongtien7,rowDV;
        public frmDoanhthuDichvu()
        {
            InitializeComponent();
        }
        private void Load_dtgrDichVu()
        {
            string sql = " SELECT  ChiTietDatDV.MaDV,TenDV,Sum(ChiTietDatDV.SoLuong)as 'Số lượng',sum(ThanhTien) as 'Tổng tiền' " +
                "FROM ChiTietDatDV, DichVu   " +
                "where DichVu.MaDV = ChiTietDatDV.MaDV" +
                " group by ChiTietDatDV.MaDV,TenDV " +
                "ORDER BY ChiTietDatDV.MaDV ASC  ";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgrDichvu.DataSource = mytable;
            dtgrDichvu.Columns[0].Width = 100;
            dtgrDichvu.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDichvu.Columns[0].HeaderText = "Mã dịch vụ";
            dtgrDichvu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgrDichvu.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDichvu.Columns[1].HeaderText = "Tên dịch vụ";
            dtgrDichvu.Columns[2].Width = 160;
            dtgrDichvu.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDichvu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgrDichvu.AllowUserToAddRows = false;
            dtgrDichvu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Tinhtong()
        {
            string sql = " SELECT SUM(ThanhTien) as Tong  FROM ChiTietDatDV";
            DataTable mytable = ConnectDB.Select_DB(sql);
            txtTong.Text = Convert.ToString(mytable.Rows[0]["Tong"]);
        }
        private void frmDoanhthuDichvu_Load(object sender, EventArgs e)
        {
            Load_dtgrDichVu();
            Tinhtong();

            string sql = "SELECT ChiTietDatDV.MaDV, SUM(ThanhTien) as Tong FROM ChiTietDatDV GROUP BY ChiTietDatDV.MaDV ORDER BY MaDV ASC  ";
            DataTable mytable = ConnectDB.Select_DB(sql);
            rowDV = mytable.Rows.Count;
            //int dem = 0;
            string tenDV;
            float tien;
            //textBox2.Text = Convert.ToString(mytable.Rows.Count);
            //textBox2.Text = Convert.ToString(mytable.Rows[0]["Tong"]);

            //Get Ten DV
            string sql2 = "SELECT distinct ChiTietDatDV.MaDV, DichVu.TenDV FROM DichVu, ChiTietDatDV where DichVu.MaDV=ChiTietDatDV.MaDV ORDER BY MaDV ASC  ";
            DataTable mytable2 = ConnectDB.Select_DB(sql2);
            

            //Chart
            chart1.Titles.Add("Biểu đồ dịch vụ");
            for (int i=0; i< rowDV; i++)
            {
                tien = Convert.ToInt32(mytable.Rows[i]["Tong"]);
                tenDV = Convert.ToString(mytable2.Rows[i]["TenDV"]);
                chart1.Series["S1"].Points.AddXY(tenDV, tien);
                tien = 0;
            }
            
        }
        //Xuát EXcel
        private void exportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for(int i = 0; i < dtgrDichvu.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dtgrDichvu.Columns[i].HeaderText;
            }
            for (int i = 0; i < dtgrDichvu.Rows.Count; i++)
            {
                for (int j = 0; j < dtgrDichvu.Columns.Count; j++)
                {
                    application.Cells[i + 2, j+1] = dtgrDichvu.Rows[i].Cells[j].Value;

                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();// tạo dialog xuất file
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2016 (*.xlsx)|*.xlsx";//lưu đuôi file
            if(saveFileDialog.ShowDialog()== DialogResult.OK)
            {
                try
                {
                    exportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file Excel thành công !");

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Xuất file Excel thành công !\n"+ex.Message);
                }
            }

        }

        private void btnReportHoaDon_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
            this.Hide();
        }
    }
}
