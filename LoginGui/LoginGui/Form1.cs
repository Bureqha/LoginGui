using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginGui
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=ENGMOBASE\\SQLEXPRESS;Initial Catalog=logindb;User ID=sa;Password=4617830");
        //SqlConnection conn = new SqlConnection("Data Source=ENGMOBASE\\SQLEXPRESS;Initial Catalog=logindb;User ID=sa;Password=4617830");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "")
            {
                MessageBox.Show("username can not be empty");

            }
            if (txtpassword.Text == "")
            {
                MessageBox.Show("password can not be empty");

            }
            login(); 
        }

        private void login()
        {
            if(conn.State== ConnectionState.Open)
            {
                conn.Close();
            }
            string username = txtusername.Text;
            string password = txtpassword.Text;

            string qry = "select * from users where username='"+username+"' and userpassword='"+password+"'";
            SqlCommand sc = new SqlCommand(qry,conn);
            SqlDataReader myReader;
            conn.Open();
            myReader = sc.ExecuteReader();
            int count = 0;
            while (myReader.Read())
            {
                count += 1;
            }
            if(count == 1)
            {
                Home hm = new Home();
                hm.value = txtusername.Text;
                hm.ShowDialog();
                this.Hide();

            }
            else
            {
                MessageBox.Show("username or password is incorrect");
            }
            conn.Close();


        }
    }
}
