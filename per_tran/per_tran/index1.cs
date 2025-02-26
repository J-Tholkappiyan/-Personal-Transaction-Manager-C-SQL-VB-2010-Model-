using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace per_tran
{
    public partial class index1 : Form
    {
        public index1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Day_report dd = new Day_report();
            dd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var targetWindow = new Form1(); // Replace 'FormDesignWindow' with your form's name
            targetWindow.Show();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var targetWindow = new Transaction(); // Replace 'FormDesignWindow' with your form's name
            targetWindow.Show();
            //this.Close();
        }
    }
}
