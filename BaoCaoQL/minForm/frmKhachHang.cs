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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void setRdbGioiTinh(string gt)
        {
            if (gt.Trim() == "Nam")
                rdbNam.Checked = true;
            else
                rdbNu.Checked = true;
        }
        public string getGioiTinh()
        {
            if (rdbNam.Checked == true && rdbNu.Checked == false)
                return "Nam";
            else if (rdbNam.Checked == false && rdbNu.Checked == true)
                return "Nữ";
            else
                return "Nam";
        }
        public string SetGioiTinh()
        {
            if (rdbNam.Checked == true && rdbNu.Checked == false)
                return "Nam";
            else if (rdbNam.Checked == false && rdbNu.Checked == true)
                return "Nữ";
            else
                return "Nam";
        }
        private void LoadDataGridview()
        {
            string sql = "Select * from dbo.KhachHang";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridKhach.DataSource = mytable;

            dtgridKhach.Columns[0].Width = 100;
            dtgridKhach.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgridKhach.Columns[1].Width = 190;
            dtgridKhach.Columns[2].Width = 190;
            dtgridKhach.Columns[3].Width = 190;
            dtgridKhach.Columns[4].Width = 190;
            dtgridKhach.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgridKhach.Columns[6].Width = 100;
            dtgridKhach.AllowUserToAddRows = false;
            dtgridKhach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetTextbox()
        {
            txtMakhach.Text = "";
            txtTenkhach.Text = "";
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            txtCMND.Text = "";
            txtSDT.Text = "";
            txtDiachi.Text = "";    
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string gioitinh = getGioiTinh();
            string sqladd = "insert Into KhachHang(TenKH,GioiTinh,CMND,SDT,DiaChi) " +
               "values (N'" + txtTenkhach.Text + "',N'" +gioitinh+ "','" + txtCMND.Text + "','" + txtSDT.Text + "',N'" + txtDiachi.Text + "') ";
            ConnectDB.Update_DB(sqladd);
            LoadDataGridview();
            MessageBox.Show("Cập nhật thành công");
            ResetTextbox();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataGridview();
        }

        private void dtgridKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var maloaiphong = dtGridPhong.CurrentRow.Cells["maLoaiPhong"].Value.ToString();
            txtMakhach.Enabled = false;
            txtMakhach.Text = dtgridKhach.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenkhach.Text = dtgridKhach.CurrentRow.Cells["TenKH"].Value.ToString();
            string gioitinh = dtgridKhach.CurrentRow.Cells["GioiTinh"].Value.ToString();
            //txtGioitinh.Text = dtgridKhach.CurrentRow.Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = dtgridKhach.CurrentRow.Cells["SDT"].Value.ToString();
            txtCMND.Text = dtgridKhach.CurrentRow.Cells["CMND"].Value.ToString();
            txtDiachi.Text = dtgridKhach.CurrentRow.Cells["DiaChi"].Value.ToString();
            if ( gioitinh.Trim() == "Nữ"){
                rdbNu.Checked = true;
            }
             if (gioitinh.Trim() == "Nam")
            {
                rdbNam.Checked = true;
            }



        }
        private void SuaKH()
        {
            if (txtTenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập tên Khách hàng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenkhach.Focus();
                return;
            }
            string gioitinh = getGioiTinh();
            if (gioitinh == "")
            {
                MessageBox.Show("Chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }
            if (txtSDT.Text == "(   )     -")
            {
                MessageBox.Show("Nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (txtCMND.Text == "(   )     -")
            {
                MessageBox.Show("Nhập Chứng minh nhân dân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCMND.Focus();
                return;
            }
            //Chưa có địa chỉ NULL

            string sqlEdit = "update KhachHang set TenKH=N'" +txtTenkhach.Text+ "',GioiTinh=N'" +gioitinh+ "'," +
                " SDT='" + txtSDT.Text + "',CMND='" + txtCMND.Text + "',DiaChi=N'" + txtDiachi.Text + "' WHERE MaKH='" + txtMakhach.Text + "' ";
            ConnectDB.Update_DB(sqlEdit);
            LoadDataGridview();
            MessageBox.Show("Sửa thành công");
            ResetTextbox();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaKH();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "DELETE KhachHang WHERE MaKH=N'" + txtMakhach.Text + "'";
                ConnectDB.Update_DB(sql);
                LoadDataGridview();
                MessageBox.Show("Xóa thành công");
                ResetTextbox();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadDataGridview();
            ResetTextbox();
            //txtMakhach.Enabled = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
