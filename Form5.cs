using Hog_Jumper.classes;
using Hog_Jumper.DBFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hog_Jumper
{
    public partial class Form5 : Form
    {
        Player player;
        Timer timer2;
        Timer secondTimer;
        Query controller;//для БД
        public int changedSkin;

        public void Init()
        {
            controller = new Query(ConnectionString.ConnectStr);//для БД
            PlatformController.platforms = new System.Collections.Generic.List<Platforms>();
            PlatformController.AddPlatform(new System.Drawing.PointF(100, 300));
            PlatformController.startPlatformPosY = 300; // подогнать размеры
            PlatformController.score = 0;
            PlatformController.GenerateStartSequance();
            //Form1 newForm = new Form1();
            //changedSkin = newForm.skin1;
            player = new Player(changedSkin);
            //player.change();
            //player.sprite = Properties.Resources.Png;
            //player.changeSprite(2);
        }

        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            player.physics.dx = 0;
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    if (player.IsFacingLeft)
                    {
                        player.sprite.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        player.IsFacingLeft = false;
                    }
                    player.physics.dx = 8;
                    break;
                case "Left":
                    if (!player.IsFacingLeft)
                    {
                        player.sprite.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        player.IsFacingLeft = true;
                    }
                    player.physics.dx = -8;
                    break;

            }
        }

        private void Update(object sender, EventArgs e)
        {
            this.Text = "Hog Jump: score - " + PlatformController.score;
            int score = PlatformController.score;
            label1.Text = score.ToString();

            if (player.physics.transform.position.Y >= PlatformController.platforms[0].transform.position.Y + 200)
            {
                timer2.Stop();
                pictureBox2.Visible = true;
                label1.BringToFront();
                label1.Visible = true;
                controller.UpdatingRecordsToTable(login.log, score);// запись счета в БД
            }

            player.physics.ApplyPhysics();
            FollowPlayer();
            Invalidate();
        }

        public void FollowPlayer()
        {
            int offset = 400 - (int)player.physics.transform.position.Y;
            player.physics.transform.position.Y += offset;
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                platform.transform.position.Y += offset;
            }
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (PlatformController.platforms.Count > 0)
            {
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                    PlatformController.platforms[i].DrawSprite(g);
            }
            player.DrawSprite(g);   
        }


        public Form5()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Init();
            secondTimer = new Timer();
            secondTimer.Interval = 5;
            secondTimer.Tick += new EventHandler(UpdateTimer);
            secondTimer.Start();

            timer2 = new Timer();
            timer2.Interval = 15;
            timer2.Tick += new EventHandler(Update);
            timer2.Start();

            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);
            this.BackgroundImage = ThemeSettings.gameTheme;
            this.Width = 600;
            this.Height = 600;
            this.Paint += new PaintEventHandler(OnRepaint);

            SoundPlayer Player = new SoundPlayer();
            Player.SoundLocation = "6.wav";
            if (MusicSkin.MusicEnabled) { Player.Play(); }

        }

        private void UpdateTimer(object sender, EventArgs e)
        {
            Init();
            secondTimer.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.timer1.Enabled = false;
            SoundPlayer Player = new SoundPlayer();
            if (MusicSkin.MusicNum == 1) { Player.SoundLocation = "1.wav"; }
            else { Player.SoundLocation = "2.wav"; }
            if (MusicSkin.MusicEnabled) { Player.Play(); }
            form1.skin1 = this.changedSkin;
            form1.Visible = true;
            this.Close();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            label1.Visible = false;
            Init();
            timer2.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
      
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
