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
    public partial class frmDichvu : Form
    {
        public frmDichvu()
        {
            InitializeComponent();
            
        }
       
        private void Load_dtgrDichVu()
        {
            txtMadichvu.Enabled = false;

            string sql_phong = "Select * from dbo.DichVu";
            DataTable mytable = ConnectDB.Select_DB(sql_phong);
            dtgrDichvu.DataSource = mytable;
            dtgrDichvu.Columns[0].Width = 150;
            dtgrDichvu.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDichvu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgrDichvu.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDichvu.Columns[2].Width = 200;
            dtgrDichvu.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDichvu.Columns[3].Width = 200;
            dtgrDichvu.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgrDichvu.Columns[4].Width = 200;
            dtgrDichvu.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgrDichvu.AllowUserToAddRows = false;
            dtgrDichvu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetTextbox()
        {
            txtMadichvu.Text = "";
            txtMadichvu.Enabled = false;
            txtTendichvu.Text = "";
            cbDonvitinh.Text = "";
            txtGiadichvu.Text = "";
            txtSoluong.Text = "";
        }
        
        private void frmDichvu_Load(object sender, EventArgs e)
        {
            Load_dtgrDichVu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTendichvu.Text == "")
            {
                MessageBox.Show("Nhập tên dịch vụ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbDonvitinh.SelectedIndex < 0)
            {
                MessageBox.Show("Nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtGiadichvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập giá dịch vụ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendichvu.Focus();
                return;
            }
            string donvitinh = cbDonvitinh.SelectedItem.ToString();

            string sqladd = "insert Into DichVu(tenDichvu,donvitinh,giaDichvu,soluong) " +
                "values (N'" + txtTendichvu.Text + "','" +donvitinh + "','" + txtGiadichvu.Text + "'" +
                ",'" + txtSoluong.Text.Trim() + "') ";
           ConnectDB.Update_DB(sqladd);
           Load_dtgrDichVu();
           MessageBox.Show("Cập nhật thành công");
           ResetTextbox();
        }

        private void dtgrDichvu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void SuaDichvu()
        {
            if (txtTendichvu.Text == "")
            {
                MessageBox.Show("Nhập tên dịch vụ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbDonvitinh.Text ==null)
            {
                MessageBox.Show("Nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtGiadichvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập giá dịch vụ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendichvu.Focus();
                return;
            }

            //string donvitinh = cbDonvitinh.SelectedItem.ToString();
            string sqlEdit = "update DichVu set TenDV=N'" + txtTendichvu.Text + "',donvitinh=N'" +cbDonvitinh.Text+ "'," +
                " GiaDV='"+txtGiadichvu.Text+ "', soluong='" + txtSoluong.Text.Trim() + "'  WHERE MaDV='" + txtMadichvu.Text + "' ";
            ConnectDB.Update_DB(sqlEdit);
            Load_dtgrDichVu();
            MessageBox.Show("Sửa thành công");
            ResetTextbox();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            //SuaDichvu();
        }
        private void XoaDichvu()
        {
            if (txtMadichvu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "DELETE DichVu WHERE MaDV=N'" + txtMadichvu.Text + "'";
                ConnectDB.Update_DB(sql);
                Load_dtgrDichVu();
                MessageBox.Show("Xóa thành công");
                ResetTextbox();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //XoaDichvu();
        }

        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetTextbox();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            Load_dtgrDichVu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ResetText();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            Load_dtgrDichVu();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dtgrDichvu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMadichvu.Text = dtgrDichvu.CurrentRow.Cells["MaDV"].Value.ToString();
            txtTendichvu.Text = dtgrDichvu.CurrentRow.Cells["TenDV"].Value.ToString();
            cbDonvitinh.Text = dtgrDichvu.CurrentRow.Cells["donvitinh"].Value.ToString();
            txtGiadichvu.Text = dtgrDichvu.CurrentRow.Cells["GiaDV"].Value.ToString();
            txtSoluong.Text = dtgrDichvu.CurrentRow.Cells["soluong"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void txtTimkiem_TextChanged_1(object sender, EventArgs e)
        {
            string sql = "Select * from dbo.DichVu where MaDV like  '%" + txtTimkiem.Text + "%' " +
                "or tenDV like '%" + txtTimkiem.Text + "%' or " +
                "GiaDV like '%" + txtTimkiem.Text + "%' or " +
                "donvitinh like '%" + txtTimkiem.Text + "%' ";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgrDichvu.DataSource = mytable;
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            SuaDichvu();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            XoaDichvu();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            ResetTextbox();
            Load_dtgrDichVu();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemm_Click(object sender, EventArgs e)
        {
            if (txtTendichvu.Text == "")
            {
                MessageBox.Show("Nhập tên dịch vụ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbDonvitinh.SelectedIndex < 0)
            {
                MessageBox.Show("Nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtGiadichvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập giá dịch vụ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendichvu.Focus();
                return;
            }
            string donvitinh = cbDonvitinh.SelectedItem.ToString();

            string sqladd = "insert Into DichVu(TenDV,donvitinh,GiaDV,soluong) " +
                "values (N'" + txtTendichvu.Text + "','" + donvitinh + "','" + txtGiadichvu.Text + "'" +
                ",'" + txtSoluong.Text.Trim() + "') ";
            ConnectDB.Update_DB(sqladd);
            Load_dtgrDichVu();
            MessageBox.Show("Cập nhật thành công");
            ResetTextbox();
        }
    }
}
