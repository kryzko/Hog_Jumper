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
            int y = 50;
            int x = 200;
            for(int i = 0; i< 100; i++)
            {
                ScoreUsers[i] = new Label();
                ScoreUsers[i].ForeColor = Color.FromArgb(100, 81, 70);
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
            y = 50;
            x = 50;
            for (int i = 0; i < 100; i++)
            {
                LoginUsers[i] = new Label();
                LoginUsers[i].ForeColor = Color.FromArgb(100, 81, 70);
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

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            //if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
            //{
            //    panel1.BackgroundImage = new Bitmap(panel1.BackgroundImage, panel1.BackgroundImage.Width, (int)(panel1.BackgroundImage.Height * 1.1)); // Увеличиваем высоту на 10%
            //}
            //// Уменьшение высоты фоновой картинки при скролле вверх
            //else if (e.Type == ScrollEventType.SmallDecrement || e.Type == ScrollEventType.LargeDecrement)
            //{
            //    panel1.BackgroundImage = new Bitmap(panel1.BackgroundImage, panel1.BackgroundImage.Width, (int)(panel1.BackgroundImage.Height * 0.9)); // Уменьшаем высоту на 10%
            //}
        }
    }
}
