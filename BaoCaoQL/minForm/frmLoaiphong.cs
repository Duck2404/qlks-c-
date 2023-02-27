using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BaoCaoQL.minForm
{
    public partial class frmLoaiphong : Form
    {
        private bool addLoaiphong;
        public frmLoaiphong(bool addLoaiphong)
        {
            this.addLoaiphong = addLoaiphong;
            InitializeComponent();
        }

        private void frmLoaiphong_Load(object sender, EventArgs e)
        {
            if (addLoaiphong)
            {
                lbTitleXulyloaiphong.Text = "Thêm loại phòng";

            }
            else
                lbTitleXulyloaiphong.Text = "Cập nhật thông tin loại phòng";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void resetTxt()
        {
            txtTenloaiphong.Text = "";
            txtGiaphong.Text = "";
        }
        private void btnThemLoaiphong_Click(object sender, EventArgs e)
        {
            if (txtTenloaiphong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenloaiphong.Focus();
                return;
            }
            if (txtGiaphong.Text == "")
            {
                MessageBox.Show("Bạn cần nhập giá phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sqladd = "insert Into LoaiPhong(tenLoaiPhong,giaphong) values(N'" + txtTenloaiphong.Text + "','" + txtGiaphong.Text + "')";
            ConnectDB.Update_DB(sqladd);
            MessageBox.Show("Cập nhật thành công");
            resetTxt();

        }
    }
}
