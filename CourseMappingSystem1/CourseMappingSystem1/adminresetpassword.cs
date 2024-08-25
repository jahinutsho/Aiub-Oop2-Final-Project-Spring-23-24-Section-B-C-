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
    public partial class adminresetpassword : Form
    {
        public adminresetpassword()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox5.UseSystemPasswordChar = true;
                textBox6.UseSystemPasswordChar = true;
                textBox1.UseSystemPasswordChar = true;
            }
            else
            {
                textBox5.UseSystemPasswordChar = false;
                textBox1.UseSystemPasswordChar = false;
                textBox6.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\Mahin\C#\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True");
            string qr = "SELECT * FROM Student WHERE id='" + textBox2.Text + "' AND password='" + textBox5.Text + "'";
            SqlCommand comm = new SqlCommand(qr, con);
            SqlDataAdapter sda = new SqlDataAdapter(qr, con);
            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                if (textBox6.Text.Equals(textBox1.Text))
                {
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Student SET password =@password WHERE id =@id", con);
                    sqlCommand.Parameters.AddWithValue("@password", textBox6.Text);
                    sqlCommand.Parameters.AddWithValue("@id", textBox2.Text);
                    try
                    {

                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Success");
                        con.Close();
                        this.Hide();
                        AdminLogin login = new AdminLogin();
                        login.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Both password need to same");
                }







            }
            else
            {
                MessageBox.Show("Id password Mismatch");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
