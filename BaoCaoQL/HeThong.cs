using BaoCaoQL.minForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BaoCaoQL
{
    public partial class HeThong : Form
    {
        public static string taikhoan = string.Empty;
        public string mataikhoan;
        public HeThong()
        {
            InitializeComponent();

        }
        
    private void HeThong_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(taikhoan))
            {
                this.mataikhoan = taikhoan;
                string sql = "select hoten from Taikhoan where tennguoidung ='" + mataikhoan + "' ";
                DataTable mytable = ConnectDB.Select_DB(sql);
                lbHovaten.Text = (string)mytable.Rows[0]["hoten"];
            }
            
            var frmshow = new Welcome();
            Add_form(frmshow);
            
        }
        private void Add_form(Form frmshow)
        {
            this.grbShowAll.Controls.Clear();
            frmshow.TopLevel = false;
            frmshow.AutoScroll = true;
            frmshow.FormBorderStyle = FormBorderStyle.None;
            frmshow.Dock = DockStyle.Fill;
            this.Text = frmshow.Text;
            this.grbShowAll.Controls.Add(frmshow);
            frmshow.Show();
        }

        private void loạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmshow = new frmKhachHang();
            Add_form(frmshow);

        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmshow = new frmPhongg();
            Add_form(frmshow);
        }

        private void thuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmshow = new frmDatPhong();
            Add_form(frmshow);
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmshow = new frmDichvu();
            Add_form(frmshow);
        }

        private void doanhThuDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmshow = new frmDoanhthuDichvu();
            Add_form(frmshow);
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmshow = new ThongKe();
            Add_form(frmshow);
        }

        private void trảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmshow = new frmDatDichvu();
            Add_form(frmshow);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            this.Hide();
            dn.Show();
        }

        private void trảPhòngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmtraphong = new frmTraPhong();
            Add_form(frmtraphong);
        }
    }
}
