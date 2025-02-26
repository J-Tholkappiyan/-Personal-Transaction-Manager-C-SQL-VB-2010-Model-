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
    public partial class Transaction : Form
    {
        string query = ""; string temp = "0";
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    
        public Transaction()
        {
            InitializeComponent();
        }
        public void idcheck()
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select count(*) from c_reg where cid='" + textBox1.Text + "' and status='a'";
            temp = cmd.ExecuteScalar().ToString();
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
            cmd.Connection = con;
            cmd.CommandText = "select max(eid) from payment";
            temp = cmd.ExecuteScalar().ToString();
            try
            {
                textBox1.Text = (Convert.ToInt32(temp) + 1).ToString();
            }
            catch (Exception ex) { textBox1.Text = "1"; }
            con.Close();

        }
        public void clear()
        {
            textBox1.Text = textBox5.Text=textBox6.Text =textBox7.Text = comboBox1.Text =  comboBox2.Text= comboBox3.Text = "";
        }

        public void submit_data()
        {
            if (textBox1.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && comboBox1.Text!="" && comboBox2.Text!="" && comboBox3.Text!="")
            {

                try
                {
                    d1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    idcheck();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into payment (fdt,status,username,t_mode,c_id,c_name,amt,p_mode,ack_no,remark,t_id,c_date) values('" + DateTime.Now.ToString() + "','a','admin','" + comboBox1.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "','" + textBox7.Text + "','" + comboBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox1.Text + "','" + d1.ToString("yyyy-MM-dd") + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("data saved");
                    clear();
                    loadid();
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
        public void d_view()
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select t_id as Entry_No,DATE_FORMAT(c_date,'%d/%m/%Y') as Date,c_name as Name,c_id as ID,t_mode as Transaction_Type,amt as Amount from payment where status='a'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[1].DisplayIndex = 8;
            dataGridView1.Columns[2].DisplayIndex = 8;
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
public void loadexdata()
{
    con.Open();
    cmd.Connection = con;
    cmd.CommandText = "select c_name,cid from c_reg where status='a'";
    dr = cmd.ExecuteReader();
    while(dr.Read())
    {
        comboBox2.Items.Add(dr.GetString(0));
        comboBox3.Items.Add(dr.GetString(1));
    }
    con.Close();

}
        private void Transaction_Load(object sender, EventArgs e)
        {
            loadid();
            loadexdata();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Focus();
            else
            {
                idcheck();


            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select cid from c_reg where status='a' and c_name='"+comboBox2.Text+"'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                comboBox3.Text = dr.GetString(0);
               
            }
            con.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select c_name from c_reg where status='a' and cid='" + comboBox3.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                comboBox2.Text = dr.GetString(0);

            }
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select emailid,cno from c_reg where status='a'and c_name='"+comboBox2.Text+"' and cid='"+comboBox3.Text+"'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               // comboBox2.Items.Add(dr.GetString(0));
                //comboBox3.Items.Add(dr.GetString(1));
                label11.Text = "Contact.No: " + dr.GetString(0);
                label10.Text = "E-mail id: " + dr.GetString(1);

            }
            con.Close();
        }


        public int idmatch()
        {
            int a = 0;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select count(*) from c_reg where c_name='"+comboBox2.Text+"' and cid='"+comboBox3.Text+"' and status='a'";
            a=Convert.ToInt32(cmd.ExecuteScalar().ToString()); 
            con.Close();
            return a;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //d1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (idmatch() == 1)
                submit_data();
            else
                MessageBox.Show("id & name not match");
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || Convert.ToInt32(e.KeyChar) == 08)
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            d_view();
        }
    }
}
