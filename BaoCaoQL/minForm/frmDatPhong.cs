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
    public partial class frmDatPhong : Form
    {
        private static int maKhachHang;
        private static string maPhongTrong;
        public frmDatPhong()
        {
            InitializeComponent();
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            loadDataKhachHangCho();
            loadDataPhongTrong();
            loadDataPhongDat();
        }
        public void loadDataKhachHangCho()
        {
            string sql = "Select * from khachhang where MaKH not in (select MaKH from DatPhong) order by MaKH desc";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridKhacHangCho.DataSource = mytable;
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

        private void dtgridKhacHangCho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maKhachHang = int.Parse(dtgridKhacHangCho.CurrentRow.Cells["MaKH"].Value.ToString());
            txtTenkhach.Text = dtgridKhacHangCho.CurrentRow.Cells["TenKH"].Value.ToString();
            setRdbGioiTinh(dtgridKhacHangCho.CurrentRow.Cells["GioiTinh"].Value.ToString());
            txtSDT.Text = dtgridKhacHangCho.CurrentRow.Cells["SDT"].Value.ToString();
            txtCMND.Text = dtgridKhacHangCho.CurrentRow.Cells["CMND"].Value.ToString();
            txtDiachi.Text = dtgridKhacHangCho.CurrentRow.Cells["DiaChi"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string gioitinh = getGioiTinh();
            string sqladd = "insert Into KhachHang(TenKH,GioiTinh,SDT,CMND,DiaChi)" +
                            "values(N'" + txtTenkhach.Text + "', N'" + gioitinh + "', '" + txtSDT.Text + "', " + txtCMND.Text + ", N'" + txtDiachi.Text + "') ";
            ConnectDB.Update_DB(sqladd);
            MessageBox.Show("Thêm thành công");
            loadDataKhachHangCho();
        }
        public void resetText()
        {
            txtTenkhach.Text = "";
            txtSDT.Text = "";
            txtCMND.Text = "";
            txtDiachi.Text = "";
            rdbNam.Checked = false;
            rdbNu.Checked = false;
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            resetText();
        }
        public void loadDataPhongTrong()
        {
            string sql = "Select * from Phong where TrangThai = N'Trống'";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridPhongTrong.DataSource = mytable;
        }
        private void dtgridPhongTrong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maPhongTrong = dtgridPhongTrong.CurrentRow.Cells["MaPhong"].Value.ToString();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            if (maPhongTrong == null)
            {
                MessageBox.Show("Vui Lòng chọn phòng");
            }
            else
            {
                DateTime currentDate = DateTime.Now;
                string sqladd = "insert into DatPhong(MaKH,MaPhong,NgayDat,NgayTra) " +
                                "values( " + maKhachHang + ", '" + maPhongTrong + "', '" + currentDate.ToString("MM/dd/yyyy") + "', NULL) ";
                ConnectDB.Update_DB(sqladd);
                MessageBox.Show("Đặt phòng thành công");
                loadDataKhachHangCho();
                loadDataPhongTrong();
                loadDataPhongDat();
                resetText();

                //// lấy mã phòng vừa đặt
                //string sql = "select top 1 MaPhieuDat from datphong order by MaPhieuDat desc";
                //DataTable mytable = ConnectDB.Select_DB(sql);
                //int maHDDV = (int)mytable.Rows[0]["MaPhieuDat"];

                //// mã dịch vụ = mã phòng
                //string sqledit = "update DatPhong set MaHDDV = "+ maHDDV + " where MaPhieuDat = " + maHDDV + "";
                //ConnectDB.Update_DB(sqledit);
            }
            
        }
        public void loadDataPhongDat()
        {
            string sql = "select TenPhong,TenKH,NgayDat,Gia,SDT,LoaiPhong from DatPhong,Phong,KhachHang " +
                         "where Phong.MaPhong = DatPhong.MaPhong and KhachHang.MaKH = DatPhong.MaKH;";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridPhongDat.DataSource = mytable;
        }
    }
}
