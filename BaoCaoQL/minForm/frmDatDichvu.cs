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
    public partial class frmDatDichvu : Form
    {
        private static int maPhieuDatPhong = -1, maDichVu = 0, maPhieuDichVu = 0, maChiTietDichVu = 0;
        private static bool checkDat = false;
        public frmDatDichvu()
        {
            InitializeComponent();
        }
        public void loadDataPhongDat()
        {
            string sql = "Select MaPhieuDat,TenPhong,TenKH, FORMAT(NgayDat,'dd/MM/yyyy') as 'NgayDat' from DatPhong,Phong,KhachHang " +
                "where DatPhong.MaPhong = Phong.MaPhong " +
                "and DatPhong.MaKH = KhachHang.MaKH";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridPhongDat.DataSource = mytable;
        }
        public void loadDataDichVu()
        {
            string sql = "select * from dichvu";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridDichVu.DataSource = mytable;
        }

        private void txtSoLuongDatDV_TextChanged(object sender, EventArgs e)
        {
            int soLuongDat = txtSoLuongDatDV.Text != "" ? int.Parse(txtSoLuongDatDV.Text) : 0;
            int soLuongCon = txtSoluongCon.Text != "" ? int.Parse(txtSoluongCon.Text) : 0;
            //int soLuongCon = int.Parse(txtSoluongCon.Text);
            if (soLuongDat > soLuongCon)
            {
                MessageBox.Show("Số lượng dịch vụ không đủ! Vui lòng kiểm tra lại");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "select * from DichVu where TenDV like '%" + txtTendichvu.Text + "%'";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridDichVu.DataSource = mytable;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuongDatDV.Text == "")
                MessageBox.Show("Vui lòng nhập số lượng đặt");
            else
            {
                //lấy mã phiếu dịch vụ vừa đặt

                string sql = "select maphieudichvu from datdv where maphieudat = " + maPhieuDatPhong + ";";
                DataTable mytable = ConnectDB.Select_DB(sql);
                maPhieuDichVu = (int)mytable.Rows[0]["maphieudichvu"];


                float tongtien = float.Parse(txtSoLuongDatDV.Text) * float.Parse(txtGiadichvu.Text);

                DateTime currentDate = DateTime.Now;

                string sqladd = "insert into ChiTietDatDV(MaPhieuDichVu,MaDV,NgayDat,GioDat,SoLuong,ThanhTien) values(" + maPhieuDichVu + "," + maDichVu + ",'" + currentDate.ToString("MM/dd/yyyy") + "','" + currentDate.ToString("HH:mm:ss") + "'," + int.Parse(txtSoLuongDatDV.Text) + "," + tongtien + ")";
                ConnectDB.Update_DB(sqladd);
                loadDataChiTietDichVu();
                loadDataDichVu();
                resetText();
                string sqledit = "update DatDV " +
                                 "set TongTien = (Select sum(thanhtien) from ChiTietDatDV where maphieudichvu = " + maPhieuDichVu + ") " +
                                 "where maphieudichvu = " + maPhieuDichVu + "";
                ConnectDB.Update_DB(sqledit);
                loadTongTienDV();
            }
        }
        public void resetText()
        {
            txtDonViTinh.Text = "";
            txtTendichvu.Text = "";
            txtSoluongCon.Text = "";
            txtGiadichvu.Text = "";
            txtSoLuongDatDV.Text = "";
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {

            resetText();
            loadDataDichVu();
        }

        private void dtgridPhongDat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maPhieuDatPhong = int.Parse(dtgridPhongDat.CurrentRow.Cells["MaPhieuDat"].Value.ToString());

            string sql1 = "select * from DatPhong where maphieudat not in (select MaPhieuDat from DatDV) ";
            DataTable mytable1 = ConnectDB.Select_DB(sql1);
            for (int i = 0; i < mytable1.Rows.Count; i++)
            {
                int maPhongChuaDat = (int)mytable1.Rows[i]["MaPhieuDat"];
                if (maPhieuDatPhong == maPhongChuaDat)
                {
                    checkDat = true;
                    break;
                }
                else
                {
                    checkDat = false;
                }
            }
        }

        private void btnDatDichVu_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(maPhieuDatPhong.ToString());
            if (maPhieuDatPhong != -1)
            {
                if (checkDat == false)
                {
                    MessageBox.Show("Phòng đã đặt dịch vụ");
                    // lẫy mã phiếu dịch vụ
                    string sql = "select maphieudichvu from datdv where maphieudat = " + maPhieuDatPhong + ";";
                    DataTable mytable = ConnectDB.Select_DB(sql);
                    maPhieuDichVu = (int)mytable.Rows[0]["maphieudichvu"];
                    loadDataChiTietDichVu();
                    loadTongTienDV();
                }
                else
                {
                    string sqladd = "insert into DatDV(MaPhieuDat,TongTien) values(" + maPhieuDatPhong + ",0)";
                    ConnectDB.Update_DB(sqladd);
                    MessageBox.Show("Đặt dịch vụ thành công");
                    checkDat = false;
                }
            }
            else
                MessageBox.Show("Vui lòng chọn phòng");
        }

        private void btnHuyDV_Click(object sender, EventArgs e)
        {
            if (maChiTietDichVu == 0)
                MessageBox.Show("Vui lòng chọn dịch vụ");
            else
            {
                string sqldelete = "delete ChiTietDatDV where MaCTPhieuDichVu = " + maChiTietDichVu + "";
                ConnectDB.Update_DB(sqldelete);
                MessageBox.Show("Hủy thành công");
                string sqledit = "update DatDV " +
                                 "set TongTien = (Select sum(thanhtien) from ChiTietDatDV where maphieudichvu = " + maPhieuDichVu + ") " +
                                 "where maphieudichvu = " + maPhieuDichVu + "";
                ConnectDB.Update_DB(sqledit);
                loadDataChiTietDichVu();
                loadDataDichVu();
                loadTongTienDV();
            }
        }

        private void dtgridChiTietDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maChiTietDichVu = int.Parse(dtgridChiTietDV.CurrentRow.Cells["MaCTPhieuDichVu"].Value.ToString());
        }

        private void frmDatDichvu_Load(object sender, EventArgs e)
        {
            loadDataPhongDat();
            loadDataDichVu();
        }

        private void txtTenPhong_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select MaPhieuDat,TenPhong,TenKH, FORMAT(NgayDat,'dd/MM/yyyy') as 'NgayDat' from DatPhong,Phong,KhachHang " +
               "where DatPhong.MaPhong = Phong.MaPhong " +
               "and DatPhong.MaKH = KhachHang.MaKH " +
               "and TenPhong like '%" + txtTenPhong.Text + "%'";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridPhongDat.DataSource = mytable;
        }

        private void dtgridDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTendichvu.Text = dtgridDichVu.CurrentRow.Cells["TenDV"].Value.ToString();
            txtSoluongCon.Text = dtgridDichVu.CurrentRow.Cells["soluong"].Value.ToString();
            txtDonViTinh.Text = dtgridDichVu.CurrentRow.Cells["DVT"].Value.ToString();
            txtGiadichvu.Text = dtgridDichVu.CurrentRow.Cells["GiaDV"].Value.ToString();
            txtSoLuongDatDV.Text = "";
            maDichVu = int.Parse(dtgridDichVu.CurrentRow.Cells["MaDV"].Value.ToString());
        }
        public void loadDataChiTietDichVu()
        {
            string sql = "select  TenDV,chitietdatdv.soluong,ngaydat,giodat,thanhtien,MaCTPhieuDichVu from chitietdatdv,DichVu" +
                " where chitietdatdv.MaDV = DichVu.MaDV and maphieudichvu = " + maPhieuDichVu + "  order by MaCTPhieuDichVu desc";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridChiTietDV.DataSource = mytable;
        }

        public void loadTongTienDV()
        {
            string sql = "select TongTien from datdv where maphieudichvu = " + maPhieuDichVu + "";
            DataTable mytable = ConnectDB.Select_DB(sql);
            int tongTienDV = Convert.ToInt32(mytable.Rows[0]["TongTien"]);
            //string sValue1 = String.Format("{0:C}", tongTienDV);
            txtTongTienDV.Text = tongTienDV.ToString("N0");
        }
    }
}
