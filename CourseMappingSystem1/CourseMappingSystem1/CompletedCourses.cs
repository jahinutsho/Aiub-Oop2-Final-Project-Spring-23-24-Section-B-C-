using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CourseMappingSystem1
{
    public partial class CompletedCourses : Form
    {
        private object yourControl;
        public string stid;
        public List<string> list = new List<string>();
        public CompletedCourses()
        {
            InitializeComponent();
           
            Console.WriteLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {

               
            
        }

        

        private void CompletedCourses_Load(object sender, EventArgs e)
        {
            int a = 0;
            stid = Login.sid;
            Console.WriteLine(stid);
            List<string> checkedItems2 = (from Control c in Controls where c is CheckBox && ((CheckBox)c).Checked select c.Name).ToList();
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jutsh\OneDrive\Desktop\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string qr = "SELECT name FROM course WHERE sid='" + stid + "'";
            con.Open();
            SqlCommand cmd= new SqlCommand(qr, con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            { 
                list.Add(reader.GetString(0));
                
                a++;
            }
            
            
                foreach(string i in list)
                {
                
                Control ct = (from Control c in this.Controls where c.Text.Equals(i) select c).FirstOrDefault();
                    if  (ct != null)
                {
                   
                    ct.Enabled = false;
                }
                }
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jutsh\OneDrive\Desktop\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            List<string> checkedItems = (from Control c in Controls where c is CheckBox && ((CheckBox)c).Checked select c.Text).ToList();
            List<string> checkedItems2 = (from Control c in Controls where c is CheckBox && ((CheckBox)c).Checked select c.Name).ToList();
            
           

          

            foreach (string item in checkedItems)
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO course VALUES (@name,@sid)", con);
                    cmd.Parameters.AddWithValue("@name", item);
                    cmd.Parameters.AddWithValue("@sid", stid);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("data eneterd");
                    }
                    con.Close();

                }
                catch
                {
                    throw;
                }

            }
            

            AvailableCourses availableCourses = new AvailableCourses();
           availableCourses.Show();
           this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
