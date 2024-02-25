using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginGui
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        public Home(string value, string date)
        {
            InitializeComponent();
            this.value = value;
            this.date = date;
        }
        public string value { get; set; }
        public string date { get; set; }

        private void Home_Load(object sender, EventArgs e)
        {
            lblusername.Text = value;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblcurrenttime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
