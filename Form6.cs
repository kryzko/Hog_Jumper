using Hog_Jumper.DBFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hog_Jumper
{
    public partial class Form6 : Form
    {
        Query controller;
        public Form6()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnectStr);
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            controller.Add(textBox1.Text,textBox2.Text);
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            LogIn form7 = new LogIn();
            form7.Visible = true;
            this.Visible = false;
        }
    }
}
