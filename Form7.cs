using Hog_Jumper.DBFolder;
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
    public partial class Form7 : Form
    {
        Query controller;
        public Form7()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            controller = new Query(ConnectionString.ConnectStr);
            textBox2.UseSystemPasswordChar = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(!controller.SearchReapeatLogin(textBox1.Text))
            {
                if(controller.SearchPasswordWhereLogin(textBox1.Text, textBox2.Text))
                {
                    login.log = textBox1.Text;
                    Form1 form1 = new Form1();
                    form1.Visible = true;
                    this.Visible = false;
                }
                else { MessageBox.Show("Неверный пароль"); }
            }
            else { MessageBox.Show("Такого пользователя нет"); }
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Visible = true;
            this.Visible = false;
        }
        int clickPictureBox7 = 0;
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (clickPictureBox7 == 0)
            {
                textBox2.UseSystemPasswordChar = false;
                pictureBox7.Image = Image.FromFile("3.jpg");
                clickPictureBox7 = 1;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                pictureBox7.Image = Image.FromFile("глаз.png");
                clickPictureBox7 = 0;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
