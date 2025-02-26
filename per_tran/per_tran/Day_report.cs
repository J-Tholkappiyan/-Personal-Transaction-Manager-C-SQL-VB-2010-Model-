using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace per_tran
{
    public partial class Day_report : Form
    {
        public Day_report()
        {
            InitializeComponent();
        }

        private void Day_report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        MySqlCommand sd = new MySqlCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            loadReport();
        }
        void loadReport()
        {

            DataSet1 d = GetData();
            ReportDataSource ds = new ReportDataSource("DataSet1", d.Tables[0]);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("fdate", dateTimePicker1.Text));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("todate", dateTimePicker2.Text));

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.RefreshReport();

        }
      
        private DataSet1 GetData()
        {
            DataSet1 d = new DataSet1();
            con.Close();
            con.Open();
            sd.Connection = con;
            double cr = 0, dr = 0;
            sd.CommandText = "select DATE_FORMAT(c_date,'%d/%m/%Y') as date,CONCAT(c_name,'',c_id) as details,amt,t_mode from payment  where status='a' and c_date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'order by eid";
            MySqlDataReader sd1 = sd.ExecuteReader();
            while (sd1.Read())
            {

                if (sd1.GetString(3) == "CREDIT")
                {
                    cr = Convert.ToDouble(sd1.GetString(2));

                }
                if (sd1.GetString(3) == "DEBIT")
                {
                    dr = Convert.ToDouble(sd1.GetString(2));
                }

                        d.Tables[0].Rows.Add(sd1.GetString(0), sd1.GetString(1), cr, dr);
                        cr = dr = 0;
                
            }

            con.Close();
         
            return d;
        }

    }
}
