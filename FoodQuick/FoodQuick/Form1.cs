using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FoodQuick
{
    public partial class Form1 : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index;
        public Form1()
        {
            InitializeComponent();
            BindGrid();
            BindGrid2();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel[index].BringToFront();
        }

        private void BindGrid()
        {
            string constring = "workstation id=FoodQuick.mssql.somee.com;packet size=4096;user id=Sherlon5099_SQLLogin_1;pwd=x7pepdrrje;data source=FoodQuick.mssql.somee.com;persist security info=False;initial catalog=FoodQuick";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FoodTable", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void BindGrid2()
        {
            string constring = "workstation id=FoodQuick.mssql.somee.com;packet size=4096;user id=Sherlon5099_SQLLogin_1;pwd=x7pepdrrje;data source=FoodQuick.mssql.somee.com;persist security info=False;initial catalog=FoodQuick";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Restaurant", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView2.DataSource = dt;
                        }
                    }
                }
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("workstation id=FoodQuick.mssql.somee.com;packet size=4096;user id=Sherlon5099_SQLLogin_1;pwd=x7pepdrrje;data source=FoodQuick.mssql.somee.com;persist security info=False;initial catalog=FoodQuick");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO [FoodTable]([FoodID],Name,Ingredients, Calories) VALUES (@FoodID,@Name,@Ingredients,@Calories)", con);
            cmd.Parameters.AddWithValue("@FoodID", int.Parse(txtFoodID.Text));
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Ingredients", txtIngredients.Text);
            cmd.Parameters.AddWithValue("@Calories",int.Parse (txtCalories.Text));
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM [FoodTable]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            txtFoodID.Text = "";
            txtName.Text = "";
            txtIngredients.Text = "";
            txtCalories.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("workstation id=FoodQuick.mssql.somee.com;packet size=4096;user id=Sherlon5099_SQLLogin_1;pwd=x7pepdrrje;data source=FoodQuick.mssql.somee.com;persist security info=False;initial catalog=FoodQuick");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE [FoodTable] WHERE [FoodID] = @FoodID", con);
            cmd.Parameters.AddWithValue("@FoodID", int.Parse(txtFoodID.Text));
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Ingredients", txtIngredients.Text);
            cmd.Parameters.AddWithValue("@Calories", txtCalories.Text);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM [FoodTable]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            txtFoodID.Text = "";
            txtName.Text = "";
            txtIngredients.Text = "";
            txtCalories.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRestaurantDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("workstation id=FoodQuick.mssql.somee.com;packet size=4096;user id=Sherlon5099_SQLLogin_1;pwd=x7pepdrrje;data source=FoodQuick.mssql.somee.com;persist security info=False;initial catalog=FoodQuick");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE [Restaurant] WHERE [RestaurantID] = @RestaurantID", con);
            cmd.Parameters.AddWithValue("@RestaurantID", int.Parse(txtRestaurantID.Text));
            cmd.Parameters.AddWithValue("@Name", txtRestName.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Rating", txtRating.Text);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM [Restaurant]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

            txtRestaurantID.Text = "";
            txtRestName.Text = "";
            txtAddress.Text = "";
            txtRating.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("workstation id=FoodQuick.mssql.somee.com;packet size=4096;user id=Sherlon5099_SQLLogin_1;pwd=x7pepdrrje;data source=FoodQuick.mssql.somee.com;persist security info=False;initial catalog=FoodQuick");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM [FoodTable] order by newid()", con);
            //cmd.Parameters.AddWithValue("FoodID", int.Parse(txtFoodID.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnrestaurantinsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("workstation id=FoodQuick.mssql.somee.com;packet size=4096;user id=Sherlon5099_SQLLogin_1;pwd=x7pepdrrje;data source=FoodQuick.mssql.somee.com;persist security info=False;initial catalog=FoodQuick");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO [Restaurant]([RestaurantID],Name,Address,Rating) VALUES (@RestaurantID,@Name,@Address,@Rating)", con);
            cmd.Parameters.AddWithValue("@RestaurantID", int.Parse(txtRestaurantID.Text));
            cmd.Parameters.AddWithValue("@Name", txtRestName.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Rating", int.Parse(txtRating.Text));
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM [Restaurant]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

            txtRestaurantID.Text = "";
            txtRestName.Text = "";
            txtAddress.Text = "";
            txtRating.Text = "";
        }

        private void btnGenerateRestaurant_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("workstation id=FoodQuick.mssql.somee.com;packet size=4096;user id=Sherlon5099_SQLLogin_1;pwd=x7pepdrrje;data source=FoodQuick.mssql.somee.com;persist security info=False;initial catalog=FoodQuick");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM [Restaurant] order by newid()", con);
            //cmd.Parameters.AddWithValue("FoodID", int.Parse(txtFoodID.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btntorestaurant_Click(object sender, EventArgs e)
        {
           if (index > 0)
                listPanel[--index].BringToFront();
        }

        private void btntofoods_Click(object sender, EventArgs e)
        {
            if (index < listPanel.Count - 1)
                listPanel[++index].BringToFront();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
     
}
