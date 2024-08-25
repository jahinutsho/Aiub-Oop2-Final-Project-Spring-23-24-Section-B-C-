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
    public partial class AvailableCourses : Form
    {
        public string stid;
        List<CompletedCourse> completedCourses1 = new List<CompletedCourse>();
        List<string> incompleteCourseNames=new List<string>();
        int a = 0;
       Class1 c = new Class1();
        public AvailableCourses()
        {
            InitializeComponent();
            dataGridView.AutoSize = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompletedCourses completedCourses = new CompletedCourses();
            completedCourses.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TotalBill T = new TotalBill();
            T.stid = stid;  
            T.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
        }

        private void AvailableCourses_Load(object sender, EventArgs e)
        {
            stid = Login.sid;
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jutsh\OneDrive\Desktop\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string qr = "SELECT name FROM course WHERE sid='" + stid + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                completedCourses1.Add(new CompletedCourse(reader.GetString(0)));

                a++;
            }
            c.setcomcourse(completedCourses1);
           
            
             incompleteCourseNames = c.courseset();
            DataTable table = new DataTable();

            table.Columns.Add("NAME", typeof(string));
            foreach (string n in incompleteCourseNames)
            {
                table.Rows.Add(n);
            }

            dataGridView.DataSource = table;


        }
    }
}
