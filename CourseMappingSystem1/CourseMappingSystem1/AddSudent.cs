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

namespace CourseMappingSystem1
{
    public partial class AddSudent : Form
    {
        public AddSudent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jutsh\OneDrive\Desktop\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Fill in all the fields");
            }
            else
            {
                string qr = "SELECT * FROM Student WHERE id='" + textBox2.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(qr, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("User Already exist");

                }
                else
                {
                    if (textBox5.Text == textBox6.Text)
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO Student values(@id,@name,@email,@number,@password,@admin)", con);
                            cmd.Parameters.AddWithValue("@id", textBox2.Text);
                            cmd.Parameters.AddWithValue("@name", textBox1.Text);
                            cmd.Parameters.AddWithValue("@email", textBox3.Text);
                            cmd.Parameters.AddWithValue("@number", textBox4.Text);
                            cmd.Parameters.AddWithValue("@password", textBox5.Text);
                            cmd.Parameters.AddWithValue("@admin", 0);
                            cmd.ExecuteNonQuery();

                            con.Close(); 
                            this.Hide();
                            AdminDashboard adminDashboard = new AdminDashboard();
                            adminDashboard.Show();
                            
                        }
                        catch (Exception)
                        {



                            throw;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password does not match");
                    }

                }

            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox5.UseSystemPasswordChar = true;
                textBox6.UseSystemPasswordChar = true;
            }
            else { textBox5.UseSystemPasswordChar = false;
                textBox6.UseSystemPasswordChar = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
