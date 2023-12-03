using Hog_Jumper.DBFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public bool passwordValidationCheck(string password)
        {
            int chisla = 0;
            int litters = 0;
            int kolSymbols = 0;
            foreach (char c in password)
            {
                if (char.IsNumber(c))
                {
                    chisla++;
                }
                if (char.IsLetter(c))
                {
                    litters++;
                }
                kolSymbols++;
            }
            if (chisla == 0) {  MessageBox.Show("в пароле должны быть цифры"); return false; }
            if (litters == 0) { MessageBox.Show("в пароле должны быть буквы"); return false;  }
            if (kolSymbols < 6) { MessageBox.Show("не меньше 5 символов"); return false;  }
            else return true;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(controller.SearchReapeat(textBox1.Text))
            {
                if(textBox2.Text != "" &&  textBox3.Text != "" && textBox1.Text != "")
                {
                    if(textBox2.Text == textBox3.Text)
                    {
                        if(passwordValidationCheck(textBox2.Text))
                        {
                            controller.Add(textBox1.Text, textBox2.Text);
                            Form1 form1 = new Form1();
                            form1.Visible = true;
                            this.Visible = false;
                        }
                          
                    }
                    else { MessageBox.Show("Пароли не совпадают"); }
                }
                else { MessageBox.Show("Поля пустые"); }
            }
            else { MessageBox.Show("Такой логин сущесвует"); }
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
        int clickPictureBox8 = 0;
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (clickPictureBox8 == 0)
            {
                textBox3.UseSystemPasswordChar = false;
                pictureBox8.Image = Image.FromFile("3.jpg");
                clickPictureBox8 = 1;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
                pictureBox8.Image = Image.FromFile("глаз.png");
                clickPictureBox8 = 0;
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            LogIn form7 = new LogIn();
            form7.Visible = true;
            this.Visible = false;
        }
    }
}
