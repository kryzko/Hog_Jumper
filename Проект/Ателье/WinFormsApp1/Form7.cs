using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form7 : Form
    {
        Guna2PictureBox[] arrPicture = new Guna2PictureBox[100];
        Guna2Shapes[] arrSh = new Guna2Shapes[100];
        System.Windows.Forms.Label[] arrName = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrCen = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrOrder = new System.Windows.Forms.Label[100];
        Guna2ImageButton[] arrButton = new Guna2ImageButton[100];
        int[] arrCenn = new int[100];
        public Form7()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 form5 = new Form5();
            form5.label2.Text = label2.Text;
            if (timer1.Enabled == true) { form5.label1.Text = "6"; }
            else { form5.label1.Text = "7"; }
            form5.Visible = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            int max = 0;
            int y = 181;
            bool cartTrue = false;
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = "SELECT EXISTS(SELECT * FROM Cart WHERE login='" + label2.Text + "');";
            connection.Open();
            if (command.ExecuteScalar() != null)
            {
                for (int i = 0; i < 100; i++)
                {
                    int j = i + 1;
                    command.CommandText = "SELECT EXISTS(SELECT * FROM Cart WHERE login='" + label2.Text + "' AND id=" + j + ");";
                    connection.Open();
                    if (command.ExecuteScalar() != null) { cartTrue = true; }
                    else { cartTrue = false; }
                    connection.Close();
                    arrPicture[i] = new Guna2PictureBox();
                    arrPicture[i].Size = new Size(276, 276);
                    arrPicture[i].Location = new Point(150, y);
                    arrPicture[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    arrPicture[i].BorderRadius = 30;
                    arrPicture[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    arrPicture[i].Name = Convert.ToString(i + 1);


                    command.CommandText = $"select picture from Cart where login = '{label2.Text}' and id = '{i + 1}'";
                    try
                    {
                        if (cartTrue == true)
                        {
                            connection.Open();
                            byte[] photoBytes = (byte[])command.ExecuteScalar();
                            using (MemoryStream ms = new MemoryStream(photoBytes))
                            {
                                Image photo = Image.FromStream(ms);
                                arrPicture[i].Image = photo;

                                y += 306;
                                this.Controls.Add(arrPicture[i]);
                                max = i + 1;
                            }
                        }
                        connection.Close();
                    }
                    catch { }

                }
                y = 472;
                for (int i = 0; i < max; i++)
                {
                    int j = i + 1;
                    command.CommandText = "SELECT EXISTS(SELECT * FROM Cart WHERE login='" + label2.Text + "' AND id=" + j + ");";
                    connection.Open();
                    if (command.ExecuteScalar().ToString() == "1") { cartTrue = true; }
                    else { cartTrue = false; }
                    connection.Close();
                    arrSh[i] = new Guna2Shapes();
                    arrSh[i].Size = new Size(1898, 2);
                    arrSh[i].Location = new Point(0, y);
                    arrSh[i].BackColor = Color.FromArgb(55, 11, 35);
                    arrSh[i].BorderColor = Color.FromArgb(55, 11, 35);
                    arrSh[i].FillColor = Color.FromArgb(55, 11, 35);

                    if (cartTrue == true)
                    {
                        y += 306;
                        this.Controls.Add(arrSh[i]);

                    }

                }
                y = 197;
                for (int i = 0; i < max; i++)
                {
                    int j = i + 1;
                    command.CommandText = "SELECT EXISTS(SELECT * FROM Cart WHERE login='" + label2.Text + "' AND id=" + j + ");";
                    connection.Open();
                    if (command.ExecuteScalar().ToString() == "1") { cartTrue = true; }
                    else { cartTrue = false; }
                    connection.Close();
                    arrName[i] = new System.Windows.Forms.Label();
                    arrName[i].Font = new Font("Roboto", 18, FontStyle.Regular);
                    arrName[i].ForeColor = Color.FromArgb(55, 11, 35);
                    arrName[i].Location = new Point(518, y);
                    arrName[i].AutoSize = true;
                    command.CommandText = $"select title from Cart where login = '{label2.Text}' and id = '{i + 1}'";
                    if (cartTrue == true)
                    {
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
                        y += 306;
                        this.Controls.Add(arrName[i]);

                    }
                }
                y = 380;
                for (int i = 0; i < max; i++)
                {
                    int j = i + 1;
                    command.CommandText = "SELECT EXISTS(SELECT * FROM Cart WHERE login='" + label2.Text + "' AND id=" + j + ");";
                    connection.Open();
                    if (command.ExecuteScalar().ToString() == "1") { cartTrue = true; }
                    else { cartTrue = false; }
                    connection.Close();
                    arrCen[i] = new System.Windows.Forms.Label();
                    arrCen[i].Font = new Font("Roboto", 18, FontStyle.Regular);
                    arrCen[i].ForeColor = Color.Black;
                    arrCen[i].Location = new Point(508, y);
                    arrCen[i].AutoSize = true;

                    command.CommandText = $"select cen from Cart where login = '{label2.Text}' and id = '{i + 1}'";

                    if (cartTrue == true)
                    {
                        try
                        {
                            connection.Open();
                            if (command.ExecuteScalar() != null)
                            {
                                arrCen[i].Text = "от "+ command.ExecuteScalar().ToString() + "p.";
                                arrCenn[i] = Convert.ToInt32(command.ExecuteScalar().ToString());
                            }
                            connection.Close();
                        }
                        catch { }
                        y += 306;
                        this.Controls.Add(arrCen[i]);

                    }
                }

                y = 340;
                for (int i = 0; i < max; i++)
                {
                    int j = i + 1;
                    command.CommandText = "SELECT EXISTS(SELECT * FROM Cart WHERE login='" + label2.Text + "' AND id=" + j + ");";
                    connection.Open();
                    if (command.ExecuteScalar().ToString() == "1") { cartTrue = true; }
                    else { cartTrue = false; }
                    connection.Close();
                    arrButton[i] = new Guna2ImageButton();
                    arrButton[i].Size = new Size(78, 82);
                    arrButton[i].ImageSize = new Size(52, 52);
                    arrButton[i].Location = new Point(1668, y);
                    arrButton[i].Cursor = Cursors.Hand;
                    arrButton[i].Name = Convert.ToString(i + 1);
                    arrButton[i].Click += deleteCart;
                    arrButton[i].Image = Image.FromFile("мусор.png");
                    if (cartTrue == true)
                    {
                        y += 306;
                        this.Controls.Add(arrButton[i]);


                    }

                }
                y = 296 + 82;
                for (int i = 0; i < max; i++)
                {
                    int j = i + 1;
                    command.CommandText = "SELECT EXISTS(SELECT * FROM Cart WHERE login='" + label2.Text + "' AND id=" + j + ");";
                    connection.Open();
                    if (command.ExecuteScalar().ToString() == "1") { cartTrue = true; }
                    else { cartTrue = false; }
                    connection.Close();
                    arrOrder[i] = new System.Windows.Forms.Label();
                    arrOrder[i].Font = new Font("Roboto", 18, FontStyle.Regular);
                    arrOrder[i].ForeColor = Color.Silver;
                    arrOrder[i].Cursor = Cursors.Hand;
                    arrOrder[i].Location = new Point(1000, y);
                    arrOrder[i].AutoSize = true;
                    arrOrder[i].Name = Convert.ToString(i + 1);
                    arrOrder[i].Text = "Оформить заказ";
                    arrOrder[i].Click += Checkout;
                    if (cartTrue == true)
                    {
                        y += 306;
                        this.Controls.Add(arrOrder[i]);

                    }
                }
                connection.Close();
            }


            timer2.Stop();
        }
        public void Checkout(object sender, EventArgs e)
        {
            System.Windows.Forms.Label clickLabel = sender as System.Windows.Forms.Label;
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = "SELECT EXISTS(SELECT * FROM Orders WHERE login='" + label2.Text + "' AND id=" + Convert.ToInt32(clickLabel.Name) + ");";
            connection.Open();
            if (command.ExecuteScalar().ToString() == "0")
            {
                Form8 form8 = new Form8();
                form8.label4.Text = arrName[Convert.ToInt32(clickLabel.Name) - 1].Text;
                form8.label2.Text = arrCenn[Convert.ToInt32(clickLabel.Name) - 1].ToString();
                form8.label10.Text = clickLabel.Name;
                form8.label11.Text = label2.Text;
                form8.Visible = true;
            }
            else MessageBox.Show("Заказ уже оформлен");
        }
        public void deleteCart(object sender, EventArgs e)
        {
            Guna2ImageButton clickButton = sender as Guna2ImageButton;
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = $"DELETE FROM Cart WHERE id = {Convert.ToInt32(clickButton.Name)} and login = '{label2.Text}'";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            this.Visible = false;
            this.Visible = true;
            for (int i = 0; i < 10; i++)
            {
                try
                {

                    arrPicture[i].Visible = false;
                    if (arrButton[i] != null) arrButton[i].Visible = false;
                    if (arrCen[i] != null) arrCen[i].Visible = false;
                    if (arrName[i] != null) arrName[i].Visible = false;
                    if (arrSh[i] != null) arrSh[i].Visible = false;
                    if (arrOrder[i] != null) arrOrder[i].Visible = false;
                }
                catch { break; }
            }
            timer2.Start();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            if (timer1.Enabled == true) { form3.timer2.Enabled = true; }
            form3.label2.Text = label2.Text;
            form3.Visible = true;
            this.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Visible = true;
            form4.label2.Text = label2.Text;
            if (timer1.Enabled == true) { form4.timer1.Enabled = true; }
            this.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = true;
        }
    }

}
