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
    public partial class frmCTDV : Form
    {
        private static int maPhieuDichVu = 0;
        public frmCTDV()
        {
            InitializeComponent();
        }

        public frmCTDV(int maphieudichvu)
        {
            InitializeComponent();
            maPhieuDichVu = maphieudichvu;

        }

        private void frmCTDV_Load(object sender, EventArgs e)
        {
            loadDataCTDV();
        }
        
        public void loadDataCTDV()
        {
            string sql = "select  TenDV,chitietdatdv.soluong,ngaydat,giodat,thanhtien,MaCTPhieuDichVu from chitietdatdv,DichVu" +
               " where chitietdatdv.MaDV = DichVu.MaDV and maphieudichvu = " + maPhieuDichVu + "  order by MaCTPhieuDichVu desc";
            DataTable mytable = ConnectDB.Select_DB(sql);
            dtgridChiTietDV.DataSource = mytable;
        }

    }
}
