using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
         
                var service = new SaleService();
         
                var data = service.GetSales(dtStart.Value, dtEnd.Value);

             
                if (data.Count == 0)
                {
                    MessageBox.Show("No records found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var report = new SalesReport();
                report.DataSource = data;

             
                report.Parameters["StartDate"].Value = dtStart.Value;
                report.Parameters["EndDate"].Value = dtEnd.Value;
                report.Parameters["StartDate"].Visible = false;
                report.Parameters["EndDate"].Visible = false;

            
                report.CreateDocument();

          
                new ReportPrintTool(report).ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
