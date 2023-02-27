using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using BaoCaoQL.minForm;

namespace BaoCaoQL
{
    public partial class Report : Form
    {
        string ConnectString = @"Data Source=DUYDAT;Initial Catalog=QLNN;Persist Security Info=True;User ID=sa;Password=352001";
        SqlConnection sqlCon = null;
        public Report()
        {
            InitializeComponent();
        }
        //Modify modify = new Modify();
        private void Report_Load(object sender, EventArgs e)
        {
            if(sqlCon == null)
            {
                sqlCon = new SqlConnection(ConnectString);
            }
            string sql = "Select * from DichVu";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlCon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "srcTable");


                this.reportViewer1.LocalReport.ReportEmbeddedResource = "BaoCaoQL.Report1.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "tbDichVu";
                reportDataSource.Value = ds.Tables["srcTable"];

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);


            this.reportViewer1.RefreshReport();
            
        }
    }
}
