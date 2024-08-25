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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["button"].Index)
            {
                DataGridViewRow selectedRow =dataGridView1.Rows[e.RowIndex];
                string id= Convert.ToString(selectedRow.Cells["id"].Value); ;
                Console.WriteLine(id);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jutsh\OneDrive\Desktop\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                string qr = "DELETE From Student where id='" + id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(qr, con);
                cmd.ExecuteNonQuery();
            }
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string id = Convert.ToString(selectedRow.Cells["id"].Value); 
                this.Close();
                EditSudentInfo edit=new EditSudentInfo();
                edit.sid = id;
                edit.Show();
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                this.Hide();
                AddSudent addSudent = new AddSudent();
                addSudent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditSudentInfo editSudentInfo = new EditSudentInfo();
            editSudentInfo.Show();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jutsh\OneDrive\Desktop\Final Project oop-2 Final\Final Project oop-2\CourseMappingSystem1\CourseMappingSystem1\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string qr = "SELECT id,name,email,number FROM Student";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = qr;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "button";
                button.HeaderText = "Delete";
                button.Text = "Delete";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                this.dataGridView1.Columns.Add(button);
            }
            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            {
                edit.Name = "Edit";
                edit.HeaderText = "Edit";
                edit.Text = "Edit";
                edit.UseColumnTextForButtonValue = true; //dont forget this line
                this.dataGridView1.Columns.Add(edit);
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if(dataGridView1.SelectedRows.Count > 0)
            {

            }

        }
    }
}
