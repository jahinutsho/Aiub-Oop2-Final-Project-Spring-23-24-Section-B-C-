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
    public partial class Login : Form
    {
        public static string sid="";
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Regisration regisration = new Regisration();
            regisration.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jutsh\OneDrive\Desktop\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True");
            string qr = "SELECT * FROM Student WHERE id='" + textBox2.Text + "' AND password='"+textBox5.Text+"'";
            SqlCommand comm = new SqlCommand(qr, con);
            SqlDataAdapter sda = new SqlDataAdapter(qr, con);  
            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int a = 0;
            if (dt.Rows.Count > 0) {
                
                SqlDataReader rdr = comm.ExecuteReader();
             
       
                    while (rdr.Read())
                    {
                    string col1Value0 = rdr[0].ToString();
                 
                    string col1Value1 = rdr[1].ToString();
                   
                    string col1Value2 = rdr[2].ToString();
                  
                    string col1Value3 = rdr[3].ToString();
                   
                    string col1Value4 = rdr[4].ToString();
                   
                    a++;



                }


                sid = textBox2.Text;
                CompletedCourses completedCourses = new CompletedCourses();
                completedCourses.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Id password Mismatch");
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox5.UseSystemPasswordChar = true; }
            else {  textBox5.UseSystemPasswordChar = false;}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Show();
        }
    }
}
