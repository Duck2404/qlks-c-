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
    public partial class BieudoThongKe : Form
    {
        public BieudoThongKe()
        {
            InitializeComponent();
        }

        private void BieudoThongKe_Load(object sender, EventArgs e)
        {
            chart1.Titles.Add("Biểu đồ dịch vụ");
            chart1.Series["S1"].Points.AddXY("1","33");
            chart1.Series["S1"].Points.AddXY("2", "20");
            chart1.Series["S1"].Points.AddXY("3", "50");
        }
    }
}
