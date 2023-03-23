using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Exp10b
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=LAPTOP-I8PC1POG; Initial Catalog = studentinfo; Integrated Security = True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("insert into studata values(@name,@regno,@year,@branch)", sqlCon);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@regno", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@year", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@branch", textBox4.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select * from studata", sqlCon);
            DataTable dtb1 = new DataTable();
            sqlDa.Fill(dtb1);
            dgv1.DataSource = dtb1;
            sqlCon.Close();
            MessageBox.Show("Successfully Registered");
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("delete studata where regno=@regno", sqlCon);
            cmd.Parameters.AddWithValue("@regno", int.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select * from studata", sqlCon);
            DataTable dtb1 = new DataTable();
            sqlDa.Fill(dtb1);
            dgv1.DataSource = dtb1;
            sqlCon.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("update studata set name=@name,year=@year,branch=@branch where regno=@regno", sqlCon);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@regno", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@year", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@branch", textBox4.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select * from studata", sqlCon);
            DataTable dtb1 = new DataTable();
            sqlDa.Fill(dtb1);
            dgv1.DataSource = dtb1;
            sqlCon.Close();
            MessageBox.Show("Successfully Updated");

        }

        private void selectbtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from studata", sqlCon);
                DataTable dtb1 = new DataTable();
                sqlDa.Fill(dtb1);
                dgv1.DataSource = dtb1;

            }
        }
    }
}
