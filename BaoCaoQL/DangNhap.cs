using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BaoCaoQL
{
    public partial class DangNhap : Form
    {

        
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-07LCPQ4\SQLEXPRESS;Initial Catalog=QLNN;Persist Security Info=True;User ID=sa;Password=123456");
            try
            {
                //Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QuanlyPhongtro;Persist Security Info=True;User ID=sa
                conn.Open();
                
                string taikhoann = txtTaiKhoan.Text;
                string matkhau = txtMatKhau.Text.Trim();
                string sql = "select * from Taikhoan where tennguoidung ='" +taikhoann + "' and matkhau ='" + matkhau + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();

                if (dta.Read() == true)
                {                    
                    MessageBox.Show("Kết nối thành công");
                    HeThong hethong = new HeThong();
                    HeThong.taikhoan =txtTaiKhoan.Text;
                    this.Hide();
                    hethong.Show();                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
            }

        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click_1(sender,  e);
                }
        }

        private void btnNhaplai_Click(object sender, EventArgs e)
        {
            txtMatKhau.Text = "";
            txtTaiKhoan.Text = "";
            txtTaiKhoan.Focus();
        }
    }
}
