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
        public Form1()
        {
            InitializeComponent();
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string propertiesPath = Path.Combine(projectDirectory, "Resources");
            SoundPlayer Player = new SoundPlayer();
            Player.SoundLocation = Path.Combine(propertiesPath, "7.wav"); ;
            Player.PlayLooping();
        }
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 0) { MessageBox.Show("Сигма"); }
            if (i == 1) { MessageBox.Show("СССИИИСЬКИ"); i = -1; }
            i++;
        }
        int j = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(j==0) { this.BackColor = Color.Red; }
            if (j == 1) { this.BackColor = Color.Yellow; }
            if (j == 2) { this.BackColor = Color.Green; }
            if (j == 3) { this.BackColor = Color.Blue; }
            if (j == 4) { this.BackColor = Color.Purple; }
            if (j == 5) { this.BackColor = Color.Pink; j = -1; }
            j++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Visible = true;
            this.Visible = false;
        }
    }
}
