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
using System.Collections;
using System.Drawing.Printing;
using System.Globalization;


namespace per_tran
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string query = ""; string temp = "0";
        MySqlCommand cmd=new MySqlCommand();
        MySqlDataReader dr;
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        private void textBox1_Leave(object sender, EventArgs e)
        {
          //  MessageBox.Show("test ok");
            if (textBox1.Text == "")
                textBox1.Focus();
            else
            {
                idcheck();
                

            }

        }
        public void idcheck()
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select count(*) from c_reg where cid='"+textBox1.Text+"' and status='a'";
            temp=cmd.ExecuteScalar().ToString();
            if (Convert.ToInt32(temp) > 0)
            {
                textBox1.Focus();
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
            con.Close();

        }
        public void loadid()
        {
            con.Open();
            cmd.Connection=con;
            cmd.CommandText = "select max(eid) from c_reg";
            temp = cmd.ExecuteScalar().ToString();
            textBox1.Text = (Convert.ToInt32(temp) + 1).ToString();
            con.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadid();
        }
        public void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
        }

        public void submit_data()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {

                try
                {
                    idcheck();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into c_reg (c_name, cid,cno,emailid,r_date,fdt,status,username) values('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + d1.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString() + "','a','admin')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("data saved");
                    clear(); loadid();
                    textBox1.Focus();
                }
                catch (Exception ex) { }
            }
            else
            {
                MessageBox.Show("Enter all required fields.");
            }

        }
        DateTime d1;
        private void button1_Click(object sender, EventArgs e)
        {
          d1   = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
         // MessageBox.Show(d1.ToString("yyyy-MM-dd"));
           submit_data();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            d_view();
        }
        public void d_view()
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select DATE_FORMAT(r_date,'%d/%m/%Y') as Date,c_name as Name,cid as ID,cno,emailid from c_reg where status='a'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[1].DisplayIndex = 7;
            dataGridView1.Columns[2].DisplayIndex = 7;
            con.Close();
            AutoGenerateRowNumber(dataGridView1);
        }
        public void AutoGenerateRowNumber(DataGridView gridView)
        {
         
            if (gridView != null)
            {
                for (int i = 0; (i <= (gridView.Rows.Count - 2)); i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = string.Format((i + 1).ToString(), "0");
                  
                }
               
            }
        }
    }
}
