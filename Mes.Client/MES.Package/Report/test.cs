using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mes.Package.Report
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("OrderNo", typeof(string));
            table.Columns.Add("CustomName", typeof(string));
            table.Rows.Add("RC1001", "刘先生1");
            table.Rows.Add("RC1002", "刘先生2");
            table.Rows.Add("RC1003", "刘先生3");

            ReportDataSource rptDataSource = new ReportDataSource();
            rptDataSource.Name = "DataSet1_test";
            rptDataSource.Value = table;

            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mes.Package.Report.test.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(rptDataSource);
            this.reportViewer1.RefreshReport();

        }
    }
}
