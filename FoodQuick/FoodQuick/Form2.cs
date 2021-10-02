using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace FoodQuick
{
    public partial class Form2 : Form
    {
        string mainconn;
       
        public Form2()
        {
            InitializeComponent();
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

     

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("workstation id=FoodQuick.mssql.somee.com;packet size=4096;user id=Sherlon5099_SQLLogin_1;pwd=x7pepdrrje;data source=FoodQuick.mssql.somee.com;persist security info=False;initial catalog=FoodQuick");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AdminLogin where username ='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form1 mm = new Form1();
                mm.Show();
            }
            else
            {
                MessageBox.Show("please enter correct username and password", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
