using Hog_Jumper.classes;
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
            this.BackgroundImage = ThemeSettings.backgroundTheme;
            this.StartPosition = FormStartPosition.CenterScreen;
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
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string propertiesPath = Path.Combine(projectDirectory, "Resources");
            if (isOn)
            { 
                pictureBox2.Image = Image.FromFile("sound_no.png");
                isOn = false;

                SoundPlayer Player = new SoundPlayer();
                if (MusicSkin.MusicNum == 1) { Player.SoundLocation = "1.wav"; }
                else { Player.SoundLocation = "2.wav"; }
                MusicSkin.MusicEnabled = false;
                Player.Stop();
            }
            else if (!isOn)
            {
                pictureBox2.Image = Image.FromFile( "sound_yes.png");
                isOn= true;

                SoundPlayer Player = new SoundPlayer();
                if (MusicSkin.MusicNum == 1) { Player.SoundLocation = "1.wav"; }
                else { Player.SoundLocation = "2.wav"; }
                MusicSkin.MusicEnabled = true;
                Player.Play();
            }

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ThemeSettings.backgroundTheme = new Bitmap("light_theme.png");
            ThemeSettings.gameTheme = new Bitmap("background.png");
            ThemeSettings.platformTheme = new Bitmap("platform_cl.png");
            this.BackgroundImage = ThemeSettings.backgroundTheme;
            SoundPlayer Player = new SoundPlayer();
            Player.SoundLocation = "1.wav";
            MusicSkin.MusicNum = 1;
            if (MusicSkin.MusicEnabled) { Player.Play(); }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ThemeSettings.backgroundTheme = new Bitmap("dark_theme.png");
            ThemeSettings.gameTheme = new Bitmap("background_dark.png");
            ThemeSettings.platformTheme = new Bitmap("platform_cl_dark.png");
            this.BackgroundImage = ThemeSettings.backgroundTheme;
            SoundPlayer Player = new SoundPlayer();
            Player.SoundLocation = "2.wav";
            MusicSkin.MusicNum = 2;
            if (MusicSkin.MusicEnabled) { Player.Play(); }
        }
    }
}
