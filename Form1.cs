using Hog_Jumper.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hog_Jumper
{
    public partial class Form1 : Form
    {
        public int skin1 = 0;
        public Form1()
        {
            InitializeComponent();   
            this.Width = 600;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = ThemeSettings.backgroundTheme;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.Size = this.Size;
            this.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.skin3 = this.skin1;
            form3.Show();
            form3.Size = this.Size;
            this.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            form4.Size = this.Size;
            this.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.changedSkin = this.skin1;
            MessageBox.Show(form5.changedSkin.ToString());
            form5.Show();
            form5.Size = this.Size;
            this.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SoundPlayer Player = new SoundPlayer();
            Player.SoundLocation =  "7.wav";
            Player.PlayLooping();
            timer1.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
