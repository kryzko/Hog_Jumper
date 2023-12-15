using Hog_Jumper.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hog_Jumper
{
    public partial class Form3 : Form
    {

        public int skin3 = 0;
        public Form3()
        {
            InitializeComponent();
            this.BackgroundImage = ThemeSettings.backgroundTheme;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.skin1 = this.skin3;
            form1.timer1.Enabled = false;
            form1.Visible = true;
            this.Visible = false;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            skin3 = 0;
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            skin3 = 1;
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            skin3 = 2;
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            skin3 = 3;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
