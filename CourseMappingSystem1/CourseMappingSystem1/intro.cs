﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseMappingSystem1
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 10;
            timer1.Start();

            if (panel2.Width >= 574) {
                timer1.Stop();
                Login login = new Login();
                login.Show();
                this.Hide();

            }
        }
    }
}
