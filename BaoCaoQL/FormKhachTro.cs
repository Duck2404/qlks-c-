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
    public partial class FormKhachTro : Form
    {
        public FormKhachTro()
        {
            InitializeComponent();
        }
        private DataTable tbKhachThueTro;
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void ResetTextbox()
        {
            txtMakhach.Text = "";
            txtTenkhach.Text = "";
            txtGioitinh.Text = "";
            txtCMND.Text = "";
            txtSDT.Text = "";
            txtDiachi.Text = "";
            txtSokhach.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sqladd = "insert Into KhachThueTro(tenKhachThue,gioitinh,CMND,SDT,diachi,nghenghiep) " +
                "values (N'"+txtTenkhach.Text+"',N'"+txtGioitinh.Text+"','"+txtCMND.Text+"','"+txtSDT.Text+"',N'"+txtDiachi.Text+"','"+txtSokhach.Text+"') ";
            ConnectDB.Update_DB(sqladd);
            LoadDataGridview();
            MessageBox.Show("Cập nhật thành công");
            ResetTextbox();
        }


        private void LoadDataGridview()
        {
            string sql = "Select * from dbo.KhachThueTro";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridKhach.DataSource = mytable;

            // string sql;
            // sql = "SELECT MaNhanVien,TenNhanVien,GioiTinh,DiaChi,DienThoai,NgaySinh FROm tblNhanVien";
            //tbKhachThueTro = Functions.GetDataToTable(sql); //lấy dữ liệu
            //dgvNhanVien.DataSource = tblNV;
            //dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            //dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            //dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            //dgvNhanVien.Columns[3].HeaderText = "Địa chỉ";
            //dgvNhanVien.Columns[4].HeaderText = "Điện thoại";
            //dgvNhanVien.Columns[5].HeaderText = "Ngày sinh";
            dtgridKhach.Columns[0].Width = 30;
            dtgridKhach.Columns[1].Width = 130;
            dtgridKhach.Columns[2].Width = 70;
            dtgridKhach.Columns[3].Width = 100;
            dtgridKhach.Columns[4].Width = 100;
            dtgridKhach.Columns[5].Width = 170;
            dtgridKhach.Columns[6].Width = 150;
            dtgridKhach.AllowUserToAddRows = false;
            dtgridKhach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void FormKhachTro_Load(object sender, EventArgs e)
        {
            LoadDataGridview();
        }

        private void dtgridKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtMakhach.Text = dtgridKhach.CurrentRow.Cells["maKhachThue"].Value.ToString();
            txtTenkhach.Text = dtgridKhach.CurrentRow.Cells["tenKhachThue"].Value.ToString();
            txtGioitinh.Text = dtgridKhach.CurrentRow.Cells["gioitinh"].Value.ToString();
            txtCMND.Text = dtgridKhach.CurrentRow.Cells["CMND"].Value.ToString();
            txtSDT.Text = dtgridKhach.CurrentRow.Cells["SDT"].Value.ToString();
            txtDiachi.Text = dtgridKhach.CurrentRow.Cells["diachi"].Value.ToString();
            txtSokhach.Text = dtgridKhach.CurrentRow.Cells["nghenghiep"].Value.ToString();
            //if (dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam") chkGioiTinh.Checked = true;
            //else chkGioiTinh.Checked = false;
          
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (txtSDT.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            string sqlEdit = "UPDATE KhachThueTro SET  tenKhachThue=N'"+txtTenkhach.Text.ToString()+
                    "',gioitinh=N'"+txtGioitinh.Text.Trim().ToString()+
                    "',CMND='"+txtCMND.Text.ToString()+"',SDT=N'"+txtSDT.Text.ToString()+
                    "',diachi=N'"+txtDiachi.Text.ToString()+
                    "',nghenghiep=N'" + txtSokhach.Text.ToString() +
                    "' WHERE maKhachThue=N'"+txtMakhach.Text+"'";
            ConnectDB.Update_DB(sqlEdit);
            LoadDataGridview();
            MessageBox.Show("Sửa thành công");
            ResetTextbox();
            
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
                string sql = "DELETE KhachThueTro WHERE maKhachThue=N'" + txtMakhach.Text +"'";
                ConnectDB.Update_DB(sql);
                LoadDataGridview();
                MessageBox.Show("Xóa thành công");
                ResetTextbox();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {

        }
    }
}
