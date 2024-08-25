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
    public partial class TotalBill : Form
    {
        public string stid;
        double d = 0;
        List<CompletedCourse> completedCourses1 = new List<CompletedCourse>();
        public TotalBill()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AvailableCourses availableCourses = new AvailableCourses();
            availableCourses.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Bill of Courses =" + d);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TotalBill_Load(object sender, EventArgs e)
        {
            stid = Login.sid;
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jutsh\OneDrive\Desktop\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string qr = "SELECT name FROM course WHERE sid='" + stid + "'";
            con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = qr;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            SqlCommand cmd1 = new SqlCommand(qr, con);
            var reader = cmd1.ExecuteReader();
            int a = 0;
            
            while (reader.Read())
            {

                completedCourses1.Add(new CompletedCourse(reader.GetString(0)));
                a++;
            }
            Class1 class1 = new Class1();
            List<Course> c = class1.getcourses1(completedCourses1);
            
            foreach (Course course in c)
            {
                Console.WriteLine(course.CourseName);
                Console.WriteLine(course.cost);
                d += course.cost;
                
            }
            Console.WriteLine(d);

            dataGridView1.DataSource = c;
        }
    }
}
