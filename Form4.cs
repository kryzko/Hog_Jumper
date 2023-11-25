using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hog_Jumper
{
    public partial class Form4 : Form
    {
        bool isOn = true;
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Visible = true;
            this.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string propertiesPath = Path.Combine(projectDirectory, "Resources");
            if (isOn)
            { 
                pictureBox2.Image = Image.FromFile(Path.Combine(propertiesPath, "3.jpg"));
                isOn = false;

                SoundPlayer Player = new SoundPlayer();
                Player.SoundLocation = Path.Combine(propertiesPath, "7.wav"); 
                Player.Stop();
            }
            else if (!isOn)
            {
                pictureBox2.Image = Image.FromFile(Path.Combine(propertiesPath, "5.jpg"));
                isOn= true;

                SoundPlayer Player = new SoundPlayer();
                Player.SoundLocation = Path.Combine(propertiesPath, "7.wav");
                Player.PlayLooping();
            }

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            //string propertiesPath = Path.Combine(projectDirectory, "Resources");

            //SoundPlayer Player = new SoundPlayer();
            //Player.SoundLocation = Path.Combine(propertiesPath, "7.wav");

            //в интернете ничего по этому поводу нет, сама я тоже не нашла как можно сделать
            //изменение громкости. пока оставлю так, может все таки найду
        }
    }
}
