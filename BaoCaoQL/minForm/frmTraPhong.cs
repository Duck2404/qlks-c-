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
    public partial class frmTraPhong : Form
    {
        private static int maPhieuDat = 0, maKhachHang = 0;
        public static int  maPhieuDichVu = 0;
        private static string maPhong = "";
        private static float tiendichvu = 0, tienphong = 0, tongtien = 0, giaphong = 0;

        public frmTraPhong()
        {
            InitializeComponent();
        }

        private void TraPhong_Load(object sender, EventArgs e)
        {
            loadDataDatPhong();
            loadGiaPhong();
        }
        public void loadDataDatPhong()
        {
            string sql = "Select DatPhong.MaPhieuDat,TenPhong,LoaiPhong,TenKH,NgayDat,NgayTra,Gia,DatPhong.MaKH,DatPhong.MaPhong " +
                         "from DatPhong,KhachHang,Phong where DatPhong.MaPhong = " +
                         "Phong.MaPhong and KhachHang.MaKH = DatPhong.MaKH ";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridDatPhong.DataSource = mytable;
        }

        public void loadGiaPhong()
        {
            string sql = "select distinct loaiphong,gia from phong";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgirdGiaPhong.DataSource = mytable;
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            addTraPhong();
            deleteDatPhong();
            loadDataDatPhong();
            resetText();
        }

        public void addTraPhong()
        {
            DateTime currentDate = DateTime.Now;
            string sqladd = "insert into TraPhong(MaPhong,MaKH,TongTienDV,TongTienPhong,TongTien,NgayLapPhieu) " +
                            "values ('" + maPhong + "'," + maKhachHang + "," + tiendichvu + "," + tienphong + "," + tongtien + ",'"+ currentDate.ToString()+ "') ";
            ConnectDB.Update_DB(sqladd);
        }

        public void deleteDatPhong()
        {
            string sqldelete = "delete ChiTietDatDV where MaPhieuDichVu = " + maPhieuDichVu + " " +
                               "delete DatDV where MaPhieuDat = " + maPhieuDat + " " +
                               "delete DatPhong where MaPhieuDat = " + maPhieuDat + "";
            ConnectDB.Update_DB(sqldelete);
            MessageBox.Show("Trả phòng thành công");
        }

        private void txtTenPhongTimKiem_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select DatPhong.MaPhieuDat,TenPhong,LoaiPhong,TenKH,NgayDat,NgayTra,Gia,DatPhong.MaKH,DatPhong.MaPhong " +
                        "from DatPhong,KhachHang,Phong where DatPhong.MaPhong = " +
                        "Phong.MaPhong and KhachHang.MaKH = DatPhong.MaKH " +
                        "and TenPhong like N'%" + txtTenPhongTimKiem.Text + "%'";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridDatPhong.DataSource = mytable;
        }

        private void txtTenKhachTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTenKhachTimKiem.Text == "")
                loadDataDatPhong();
            else
            {
                string sql = "Select DatPhong.MaPhieuDat,TenPhong,LoaiPhong,TenKH,NgayDat,NgayTra,Gia,DatPhong.MaKH,DatPhong.MaPhong " +
                         "from DatPhong,KhachHang,Phong where DatPhong.MaPhong = " +
                         "Phong.MaPhong and KhachHang.MaKH = DatPhong.MaKH " +
                         "and TenKH like N'%" + txtTenKhachTimKiem.Text + "%'";
                DataTable mytable = ConnectDB.Select_DB(sql);
                dtgridDatPhong.DataSource = mytable;
            }
        }

        private void btnChiTietDV_Click(object sender, EventArgs e)
        {
            if(maPhieuDichVu!=0)
            {
                frmCTDV frmChiTietDV = new frmCTDV(maPhieuDichVu);
                frmChiTietDV.Show();
            }
            else
            {
                MessageBox.Show("Không có dịch vụ");
            }
            
        }

        public void resetText()
        {
            txtTenPhong.Text = "";
            txtTenKhach.Text = "";
            txtLoaiPhong.Text = "";
            txtSoNgayO.Text = "";
            txtTienPhong.Text = "";
            txtTienDichVu.Text = "";
            txtTongTien.Text = "";
            dtpNgayTra.Enabled = false;
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (txtTenPhong.Text != "")
                btnTraPhong.Enabled = true;
            else
                MessageBox.Show("Vui chọn phòng cần trả");
        }

        private void dtgridDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtpNgayTra.Enabled = true;
            btnChiTietDV.Enabled = true;
            DateTime currentDate = DateTime.Now;
            maPhieuDat = int.Parse(dtgridDatPhong.CurrentRow.Cells["MaPhieuDat1"].Value.ToString());

            string sqledit = "update DatPhong set NgayTra = '" + currentDate.ToString("MM/dd/yyyy") + "' where MaPhieuDat = " + maPhieuDat + "";
            ConnectDB.Update_DB(sqledit);

            string sql = "select MaPhieuDichVu,TongTien from DatDV where MaPhieuDat = " + maPhieuDat + "";
            DataTable mytable = ConnectDB.Select_DB(sql);
            if (mytable.Rows.Count > 0)
            {
                maPhieuDichVu = int.Parse(mytable.Rows[0]["MaPhieuDichVu"].ToString());
                tiendichvu = float.Parse(mytable.Rows[0]["TongTien"].ToString());
            }
            else
            {
                maPhieuDichVu = 0;
                tiendichvu = 0;
            }
            // gán giá trị

            maPhong = dtgridDatPhong.CurrentRow.Cells["MaPhongDat"].Value.ToString();
            maKhachHang = int.Parse(dtgridDatPhong.CurrentRow.Cells["MaKHDat"].Value.ToString());

            dtpNgayDat.Text = dtgridDatPhong.CurrentRow.Cells["NgayDat"].Value.ToString();
            dtpNgayTra.Text = dtgridDatPhong.CurrentRow.Cells["NgayTra"].Value.ToString();

            txtSoNgayO.Text = TinhSoNgayO().ToString();

            giaphong = float.Parse(dtgridDatPhong.CurrentRow.Cells["Gia"].Value.ToString());
            tienphong = float.Parse(txtSoNgayO.Text) * giaphong;
            tongtien = tienphong + tiendichvu;

            txtTenPhong.Text = dtgridDatPhong.CurrentRow.Cells["TenPhong"].Value.ToString();
            txtTenKhach.Text = dtgridDatPhong.CurrentRow.Cells["TenKH"].Value.ToString();
            txtLoaiPhong.Text = dtgridDatPhong.CurrentRow.Cells["LoaiPhong"].Value.ToString();
            txtTienDichVu.Text = tiendichvu.ToString("N0");
            txtTienPhong.Text = tienphong.ToString("N0");
            txtTongTien.Text = tongtien.ToString("N0");
        }

        public int TinhSoNgayO()
        {
            int soNgay = 0;
            // CẮT NGÀY THÁNG ĐẾN
            int namDen = int.Parse(dtpNgayDat.Value.Year.ToString());
            int thangDen = int.Parse(dtpNgayDat.Value.Month.ToString());
            int ngayDen = int.Parse(dtpNgayDat.Value.Day.ToString());
            // CẮT NGÀY THÁNG TRẢ
            int namTra = int.Parse(dtpNgayTra.Value.Year.ToString());
            int thangTra = int.Parse(dtpNgayTra.Value.Month.ToString());
            int ngayTra = int.Parse(dtpNgayTra.Value.Day.ToString());

            if (namDen == namTra)
            {
                if (thangDen == thangTra)
                {
                    if (ngayDen < ngayTra)
                    {
                        soNgay = ngayTra - ngayDen;
                    }
                    else if (ngayDen == ngayTra)
                    {
                        MessageBox.Show("Ở trong một ngày");
                        soNgay = 1;
                    }
                    else
                    {
                        MessageBox.Show(" Ngày trả trước ngày đến.Vui lòng kiểm tra lại!!!");
                    }
                }
                else if (thangDen < thangTra)
                {
                    if (thangDen == 1 || thangDen == 3 || thangDen == 5 || thangDen == 7 || thangDen == 8 || thangDen == 10 || thangDen == 12)
                    {

                        soNgay = (ngayTra - ngayDen) + (31 * (thangTra - thangDen));
                    }
                    else if (thangDen == 2)
                        soNgay = (ngayTra - ngayDen) + (29 * (thangTra - thangDen));
                    else
                        soNgay = (ngayTra - ngayDen) + (30 * (thangTra - thangDen));
                }
                else
                {
                    MessageBox.Show("Tháng trả trước tháng đến. Vui lòng kiểm tra lại!!!");
                }
            }
            else if (namDen < namTra)
            {
                if (thangDen == 1 || thangDen == 3 || thangDen == 5 || thangDen == 7 || thangDen == 8 || thangDen == 10 || thangDen == 12)
                {
                    if (thangTra < thangDen)
                    {
                        soNgay = (ngayTra - ngayDen) + (31 * (thangTra + 12 - thangDen));
                    }
                    else
                    {
                        soNgay = (ngayTra - ngayDen) + (31 * (thangTra - thangDen)) + (365 * (namTra - namDen));
                    }
                }
                else if (thangDen == 2)
                {
                    if (thangTra < thangDen)
                    {
                        soNgay = (ngayTra - ngayDen) + (29 * (thangTra + 12 - thangDen));
                    }
                    else
                    {
                        soNgay = (ngayTra - ngayDen) + (29 * (thangTra - thangDen)) + (365 * (namTra - namDen));
                    }
                }
                else
                {
                    if (thangTra < thangDen)
                    {
                        soNgay = (ngayTra - ngayDen) + (30 * (thangTra + 12 - thangDen));
                    }
                    else
                    {
                        soNgay = (ngayTra - ngayDen) + (30 * (thangTra - thangDen)) + (365 * (namTra - namDen));
                    }
                }
            }
            else
            {
                MessageBox.Show("Năm trả trước năm đến. Vui lòng kiểm tra lại!!!");
            }
            return soNgay;
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            if (txtLoaiPhong.Text != "")
            {
                txtSoNgayO.Text = TinhSoNgayO().ToString();
                tienphong = float.Parse(txtSoNgayO.Text) * giaphong;
                tongtien = tienphong + tiendichvu;
                txtTienPhong.Text = tienphong.ToString("N0");
                txtTongTien.Text = tongtien.ToString("N0");
            }
        }
    }
}
