using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseMappingSystem1
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox5.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox5.UseSystemPasswordChar = true; }
            else { textBox5.UseSystemPasswordChar = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jutsh\OneDrive\Desktop\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True");
            string qr = "SELECT * FROM Student WHERE id='" + textBox2.Text + "' AND password='" + textBox5.Text + "'";
            SqlCommand comm = new SqlCommand(qr, con);
            SqlDataAdapter sda = new SqlDataAdapter(qr, con);
            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                SqlDataReader rdr = comm.ExecuteReader();

                while (rdr.Read())
                {
                    string col1Value5 = rdr[5].ToString();
                   
                    if (col1Value5 == "True") {
                        this.Hide();
                        AdminDashboard adminDashboard = new AdminDashboard();
                        adminDashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Not an Admin");
                    }
                   
                }

              


              
            }
            else
            {
                MessageBox.Show("Id password Mismatch");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
