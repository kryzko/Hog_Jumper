using Hog_Jumper.DBFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hog_Jumper
{
    public partial class Form2 : Form
    {
        Query controller;
        Label[] LoginUsers = new Label[100];
        Label[] ScoreUsers = new Label[100];
        int KolUsers = 0;
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            controller = new Query(ConnectionString.ConnectStr);
            int y = 20;
            int x = 200;
            for(int i = 0; i< 100; i++)
            {
                ScoreUsers[i] = new Label();
                ScoreUsers[i].Location = new Point(x, y);
                ScoreUsers[i].Font= new Font("System", 14, FontStyle.Regular);
                try
                {
                    controller.OutputOfRecordsInLabel(i, ScoreUsers[i]);
                }
                catch { KolUsers = i; break; }
                panel1.Controls.Add(ScoreUsers[i]);
                y += 40;
            }
            y = 20;
            x = 40;
            for (int i = 0; i < 100; i++)
            {
                LoginUsers[i] = new Label();
                LoginUsers[i].Location = new Point(x, y);
                LoginUsers[i].Font = new Font("System", 14, FontStyle.Regular);
                try
                {
                    controller.OutputOfLoginInLabel(i, LoginUsers[i]);
                }
                catch { KolUsers = i; break; }
                panel1.Controls.Add(LoginUsers[i]);
                y += 40;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.timer1.Enabled = false;
            form1.Visible = true;
            this.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.timer1.Enabled = false;
            form1.Visible = true;
            this.Visible = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
