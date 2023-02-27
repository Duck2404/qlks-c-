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
    public partial class frmPhongg : Form
    {
        public frmPhongg()
        {
            InitializeComponent();
        }

        private void frmPhongg_Load(object sender, EventArgs e)
        {
            LoadDataPhong();
            LoadComboboxLoaiPhong();
            LoadComboboxTrangThai();
        }
        private void LoadDataPhong()
        {
            string sql = "Select * from Phong";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridPhong.DataSource = mytable;
        }

        private void LoadComboboxLoaiPhong()
        {
            string sql = "select LoaiPhong from Phong group by LoaiPhong";
            DataTable mytable = ConnectDB.Select_DB(sql);
            cbLoaiphong.DataSource = mytable;
            cbLoaiphong.DisplayMember = "LoaiPhong";
            cbLoaiphong.ValueMember = "LoaiPhong";
        }

        private void LoadComboboxTrangThai()
        {
            cbTrangThai.Items.Add("Trống");
            cbTrangThai.Items.Add("Đã Đặt");
            cbTrangThai.Items.Add("Sửa chữa");
            cbTrangThai.SelectedItem = "Trống";
        }

        private void ResetTextBox()
        {
            txtMaphong.ReadOnly = false;
            txtMaphong.Text = "";
            txtGiaphong.Text = "";
            txtTenphong.Text = "";
            cbTrangThai.SelectedItem = "Trống";
            cbLoaiphong.SelectedValue = "Phòng Đơn";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sqladd = "insert Into Phong(MaPhong,TenPhong,LoaiPhong,Gia,TrangThai) " +
                            "values('" + txtMaphong.Text + "', N'" + txtTenphong.Text + "', N'" + cbLoaiphong.SelectedValue.ToString() + "', '" + txtGiaphong.Text + "', N'Trống') ";
            ConnectDB.Update_DB(sqladd);
            MessageBox.Show("Thêm thành công");
            ResetTextBox();
            LoadDataPhong();
        }

        private void dtgridPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaphong.Text = dtgridPhong.CurrentRow.Cells["MaPhong"].Value.ToString();
            txtTenphong.Text = dtgridPhong.CurrentRow.Cells["TenPhong"].Value.ToString();
            cbLoaiphong.SelectedValue = dtgridPhong.CurrentRow.Cells["LoaiPhong"].Value.ToString();
            txtGiaphong.Text = dtgridPhong.CurrentRow.Cells["Gia"].Value.ToString();
            cbTrangThai.SelectedItem = dtgridPhong.CurrentRow.Cells["TrangThai"].Value.ToString();
            txtMaphong.ReadOnly = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaphong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phòng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sqledit = "update Phong set TenPhong=N'" + txtTenphong.Text + "',LoaiPhong=N'" + cbLoaiphong.SelectedValue.ToString() + "',Gia=" + txtGiaphong.Text + ", TrangThai=N'" + cbTrangThai.SelectedItem.ToString() + "' " +
                             "WHERE MaPhong = '" + txtMaphong.Text + "' ";
                ConnectDB.Update_DB(sqledit);
                MessageBox.Show("Sửa thành công");
                ResetTextBox();
                LoadDataPhong();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaphong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phòng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sqldelete = "DELETE phong WHERE MaPhong = '" + txtMaphong.Text + "'";
                ConnectDB.Update_DB(sqldelete);
                MessageBox.Show("Xóa thành công");
                ResetTextBox();
                LoadDataPhong();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            ResetTextBox();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "select * from Phong where TenPhong like '%" + txtTenphong.Text + "%'";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridPhong.DataSource = mytable;
        }

        private void txtTenphong_TextChanged(object sender, EventArgs e)
        {
            if (txtTenphong.Text == "")
            {
                LoadDataPhong();
            }
        }
    }
}
