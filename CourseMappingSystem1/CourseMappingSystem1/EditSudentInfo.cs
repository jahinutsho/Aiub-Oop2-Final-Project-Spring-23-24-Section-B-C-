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
    public partial class EditSudentInfo : Form
    {
        public string sid;
        public EditSudentInfo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
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
                string qr = "SELECT * FROM Student WHERE id='" + sid + "'";
                SqlDataAdapter sda = new SqlDataAdapter(qr, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                
                    if (textBox5.Text == textBox6.Text)
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE Student SET name=@name, email=@email,number=@number, password =@password WHERE id =@id", con);
                            cmd.Parameters.AddWithValue("@id", textBox2.Text);
                            cmd.Parameters.AddWithValue("@name", textBox1.Text);
                            cmd.Parameters.AddWithValue("@email", textBox3.Text);
                            cmd.Parameters.AddWithValue("@number", textBox4.Text);
                            cmd.Parameters.AddWithValue("@password", textBox5.Text);
                            cmd.Parameters.AddWithValue("@admin", 0);
                            cmd.ExecuteNonQuery();
                            textBox1.ReadOnly = true;
                            con.Close();
                            
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
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox5.UseSystemPasswordChar = true;
                textBox6.UseSystemPasswordChar = true;
            }
            else
            {
                textBox5.UseSystemPasswordChar = false;
                textBox6.UseSystemPasswordChar = false;
            }
        }

        private void EditSudentInfo_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jutsh\OneDrive\Desktop\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string qr = "SELECT * FROM Student where id ='" + sid + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader.GetString(1);
                textBox2.Text = reader.GetString(0);
                textBox3.Text = reader.GetString(2);
                textBox4.Text = reader.GetString(3);
                textBox5.Text = reader.GetString(4);
            }
            Console.WriteLine(sid);
        }
    }
}
