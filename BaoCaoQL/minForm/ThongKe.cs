using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BaoCaoQL.minForm
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        private void Load_dtgrDichVu()
        {
            string sql_phong = "select Phong.TenPhong,Phong.LoaiPhong, TraPhong.TongTienDV, TraPhong.TongTienPhong, TraPhong.TongTien,NgayLapPhieu " +
                "from Phong,TraPhong " +
                "where TraPhong.MaPhong = Phong.MaPhong " +
                "order by ngaylapphieu desc";
            DataTable mytable = ConnectDB.Select_DB(sql_phong);
            dtgrDoanhthu.DataSource = mytable;
            dtgrDoanhthu.Columns[0].Width = 150;
            dtgrDoanhthu.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDoanhthu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgrDoanhthu.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDoanhthu.Columns[2].Width = 200;
            dtgrDoanhthu.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDoanhthu.Columns[3].Width = 200;
            dtgrDoanhthu.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDoanhthu.Columns[4].Width = 200;
            dtgrDoanhthu.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDoanhthu.Columns[5].Width = 200;
            dtgrDoanhthu.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgrDoanhthu.AllowUserToAddRows = false;
            dtgrDoanhthu.EditMode = DataGridViewEditMode.EditProgrammatically;

            string sql = "select  SUM(TongTien) AS tong from Phong, TraPhong " +
                "where TraPhong.MaPhong = Phong.MaPhong ";
            DataTable mytable2 = ConnectDB.Select_DB(sql);
            int tongtien = Convert.ToInt32(mytable2.Rows[0]["tong"]);
            txtTong.Text = tongtien.ToString("N0");
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            Load_dtgrDichVu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql_phong = "select Phong.TenPhong,Phong.LoaiPhong, TraPhong.TongTienDV,TraPhong.TongTienPhong,TraPhong.TongTien,NgayLapPhieu " +
                "from Phong,TraPhong " +
                "where TraPhong.MaPhong = Phong.MaPhong " +
                "and NgayLapPhieu BETWEEN '"+dtpkTuNgay.Value.ToString() + "' AND '" + dtpkDenNgay.Value.ToString() + "'" +
                "order by ngaylapphieu desc";
            DataTable mytable = ConnectDB.Select_DB(sql_phong);
            dtgrDoanhthu.DataSource = mytable;
            dtgrDoanhthu.Columns[0].Width = 150;
            dtgrDoanhthu.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDoanhthu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgrDoanhthu.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDoanhthu.Columns[2].Width = 200;
            dtgrDoanhthu.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDoanhthu.Columns[3].Width = 200;
            dtgrDoanhthu.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDoanhthu.Columns[4].Width = 200;
            dtgrDoanhthu.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDoanhthu.Columns[5].Width = 200;
            dtgrDoanhthu.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            string sql = "select  SUM(TongTien) AS tong from Phong, TraPhong " +
                "where TraPhong.MaPhong = Phong.MaPhong " +
                " and NgayLapPhieu BETWEEN '" + dtpkTuNgay.Value.ToString() + "' AND '" + dtpkDenNgay.Value.ToString() + "' ";
            DataTable mytable2 = ConnectDB.Select_DB(sql);
            int tongtien = Convert.ToInt32(mytable2.Rows[0]["tong"]);
            txtTong.Text = tongtien.ToString("N0");

        }

        private void exportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dtgrDoanhthu.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dtgrDoanhthu.Columns[i].HeaderText;
            }
            for (int i = 0; i < dtgrDoanhthu.Rows.Count; i++)
            {
                for (int j = 0; j < dtgrDoanhthu.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dtgrDoanhthu.Rows[i].Cells[j].Value;

                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();// tạo dialog xuất file
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2016 (*.xlsx)|*.xlsx";//lưu đuôi file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    exportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file Excel thành công !");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất file Excel thành công !\n" + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Load_dtgrDichVu();
        }
    }
}
