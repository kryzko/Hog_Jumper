﻿using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        Guna2PictureBox[] arrPicture = new Guna2PictureBox[100];
        Guna2Shapes[] arrSh = new Guna2Shapes[100];
        System.Windows.Forms.Label[] arrName = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrCen = new System.Windows.Forms.Label[100];
        int[] arrCenn = new int[100];
        public Form4()
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            int max = 0;
            int y = 181;
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            for (int i = 0; i < 100; i++)
            {
                arrPicture[i] = new Guna2PictureBox();
                arrPicture[i].Size = new Size(276, 276);
                arrPicture[i].Location = new Point(150, y);
                arrPicture[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPicture[i].BorderRadius = 30;
                arrPicture[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPicture[i].Click += PictureBox_Click;
                arrPicture[i].Name = Convert.ToString(i + 1);
                y += 306;
                command.CommandText = $"select picture from Services where id = '{i + 1}'";
                try
                {
                    connection.Open();

                    byte[] photoBytes = (byte[])command.ExecuteScalar();
                    using (MemoryStream ms = new MemoryStream(photoBytes))
                    {
                        Image photo = Image.FromStream(ms);
                        arrPicture[i].Image = photo;
                    }

                    connection.Close();
                }
                catch { break; }
                this.Controls.Add(arrPicture[i]);
                max = i;

            }


            y = 472;
            for (int i = 0; i < max; i++)
            {
                arrSh[i] = new Guna2Shapes();
                arrSh[i].Size = new Size(1898, 2);
                arrSh[i].Location = new Point(0, y);
                arrSh[i].BackColor = Color.FromArgb(55, 11, 35);
                arrSh[i].BorderColor = Color.FromArgb(55, 11, 35);
                arrSh[i].FillColor = Color.FromArgb(55, 11, 35);
                y += 306;
                this.Controls.Add(arrSh[i]);

            }

            y = 197;
            for (int i = 0; i <= max; i++)
            {
                arrName[i] = new System.Windows.Forms.Label();
                arrName[i].Font = new Font("Roboto", 18, FontStyle.Regular);
                arrName[i].ForeColor = Color.FromArgb(55, 11, 35);
                arrName[i].Location = new Point(518, y);
                arrName[i].AutoSize = true;
                y += 306;
                command.CommandText = $"select title from Services where id = '{i + 1}'";
                try
                {
                    connection.Open();
                    if (command.ExecuteScalar() != null)
                    {
                        arrName[i].Text = command.ExecuteScalar().ToString();
                    }
                    connection.Close();
                }
                catch (Exception ex) { }
                this.Controls.Add(arrName[i]);
            }
            
            y = 380;
            for (int i = 0; i <= max; i++)
            {
                arrCen[i] = new System.Windows.Forms.Label();
                arrCen[i].Font = new Font("Roboto", 18, FontStyle.Regular);
                arrCen[i].ForeColor = Color.Black;
                arrCen[i].Location = new Point(508, y);
                arrCen[i].AutoSize = true;
                y += 306;
                command.CommandText = $"select price from Services where id = '{i + 1}'";
                try
                {
                    connection.Open();
                    if (command.ExecuteScalar() != null)
                    {
                        arrCen[i].Text = "от " + command.ExecuteScalar().ToString() + "р.";
                        arrCenn[i] = Convert.ToInt32(command.ExecuteScalar().ToString());
                    }
                    connection.Close();
                }
                catch (Exception ex) { }
                this.Controls.Add(arrCen[i]);
            }
            Guna2ImageButton[] arrButton = new Guna2ImageButton[100];
            y = 340;
            for (int i = 0; i <= max; i++)
            {
                arrButton[i] = new Guna2ImageButton();
                arrButton[i].Size = new Size(78, 82);
                arrButton[i].ImageSize = new Size(52, 52);
                arrButton[i].Location = new Point(1668, y);
                arrButton[i].Name = Convert.ToString(i + 1);
                arrButton[i].Click += Guna2ImageButton_Click;
                arrButton[i].Cursor = Cursors.Hand;
                y += 306;
                arrButton[i].Image = Image.FromFile("корзина1.png");
                this.Controls.Add(arrButton[i]);

            }

        }
        public void Guna2ImageButton_Click(object sender, EventArgs e)
        {

            Guna2ImageButton clickButton = sender as Guna2ImageButton;
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = $"SELECT EXISTS(SELECT * FROM Cart WHERE login='{label2.Text}' AND id={Convert.ToInt32(clickButton.Name)});";
            connection.Open();
            if (command.ExecuteScalar().ToString() == "0")
            {
                command.CommandText = $"select picture from Services where id = '{Convert.ToInt32(clickButton.Name)}'";
                connection.Open();
                byte[] photoBytes = (byte[])command.ExecuteScalar();
                connection.Close();
                MemoryStream ms = new MemoryStream(photoBytes);
                try
                {
                    Image photo = Image.FromStream(ms);
                }
                catch (Exception ex) { }
                byte[] imageBytes = ms.ToArray();
                connection.Open();
                command.CommandText = "INSERT INTO Cart (login, title, cen, id, picture) VALUES (:login, :title, :cen,:id, @value)";
                command.Parameters.AddWithValue("login", label2.Text);
                command.Parameters.AddWithValue("title", arrName[Convert.ToInt32(clickButton.Name) - 1].Text);
                command.Parameters.AddWithValue("cen", arrCenn[Convert.ToInt32(clickButton.Name) - 1]);
                command.Parameters.AddWithValue("id", Convert.ToInt32(clickButton.Name));
                SqliteParameter valueParam = new SqliteParameter("@value", SqliteType.Blob);
                valueParam.Value = imageBytes;
                command.Parameters.Add(valueParam);
                command.ExecuteNonQuery();
                connection.Close();
                clickButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Товар уже добавлен в корзину!");
            }



        }

        public void PictureBox_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                int numPicture = 0;
                PictureBox clickedPictureBox = sender as PictureBox;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"; openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    clickedPictureBox.Image = Image.FromFile(openFileDialog1.FileName);


                }

                Image image = clickedPictureBox.Image;
                MemoryStream ms = new MemoryStream();
                try { image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); }
                catch { }
                byte[] imageBytes = ms.ToArray();
                var connection = new SqliteConnection("Data Source=Studio.db");
                var command = new SqliteCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = $"UPDATE Services SET picture = @value WHERE id = '{clickedPictureBox.Name}'";
                SqliteParameter valueParam = new SqliteParameter("@value", SqliteType.Blob);
                valueParam.Value = imageBytes;
                command.Parameters.Add(valueParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            if (timer1.Enabled == true) { form3.timer2.Enabled = true; }
            form3.label2.Text = label2.Text;
            form3.Visible = true;
            this.Visible = false;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 form5 = new Form5();
            if (timer1.Enabled == true) { form5.label1.Text = "2"; }
            else { form5.label1.Text = "3"; }
            form5.label2.Text = label2.Text;
            form5.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private void guna2Shapes8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            if (timer1.Enabled == true) { form6.timer1.Enabled = true; }
            form6.label3.Text = label2.Text;
            form6.Visible = true;
            this.Visible = false;
        }

        private void guna2ImageButton8_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Visible = true;
            form7.label2.Text = label2.Text;
            if (timer1.Enabled == true) { form7.timer1.Enabled = true; }
            this.Visible = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void guna2Shapes4_Click(object sender, EventArgs e)
        {

        }
    }
}
