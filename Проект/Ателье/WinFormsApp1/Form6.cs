using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        Guna2PictureBox[] arrPicture = new Guna2PictureBox[100];
        Guna2Shapes[] arrSh = new Guna2Shapes[100];
        System.Windows.Forms.Label[] arrName = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrCen = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrOrder = new System.Windows.Forms.Label[100];
        Guna2ImageButton[] arrButton = new Guna2ImageButton[100];
        public Form6()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            guna2Panel2.Location = new System.Drawing.Point(140, 300);
            guna2Panel2.Size = new System.Drawing.Size(guna2Panel2.Size.Width, this.Height - 340);
            label7.Location = new System.Drawing.Point(190, 490);
            ToolTip toolImage = new ToolTip();
            toolImage.SetToolTip(guna2PictureBox1, "Нажмите на фото чтобы изменить его");

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            try
            {
                openFileDialog1.Filter = "(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"; openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    guna2PictureBox1.Image = Image.FromFile(openFileDialog1.FileName);


                }
                Image image = guna2PictureBox1.Image;
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                var connection = new SqliteConnection("Data Source=Studio.db");
                var command = new SqliteCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = $"UPDATE Users SET picture = @value WHERE login = '{label3.Text}'";
                SqliteParameter valueParam = new SqliteParameter("@value", SqliteType.Blob);
                valueParam.Value = imageBytes;
                command.Parameters.Add(valueParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch { }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Visible = true;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 form5 = new Form5();
            if (timer1.Enabled == true) { form5.label1.Text = "4"; }
            else { form5.label1.Text = "5"; }
            form5.label2.Text = label3.Text;
            form5.Visible = true;
            timer2.Start();
        }

        private void guna2Shapes8_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Visible = true;
            if (timer1.Enabled == true) { form4.timer1.Enabled = true; }
            timer2.Start();
            form4.label2.Text = label3.Text;
            this.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Visible = true;
            if (timer1.Enabled == true) { form3.timer2.Enabled = true; }
            form3.label2.Text = label3.Text;
            this.Visible = false;
            timer2.Start();
        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Shapes2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Shapes11_Click(object sender, EventArgs e)
        {

        }
        System.Windows.Forms.Label[] arrTitleLabel = new System.Windows.Forms.Label[100];
        private void timer2_Tick(object sender, EventArgs e)
        {
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.Connection = connection;
            connection.Open();
            command.CommandText = $"select picture from Users where login = '{label3.Text}'";
            try
            {
                byte[] photoBytes = (byte[])command.ExecuteScalar();
                using (MemoryStream ms = new MemoryStream(photoBytes))
                {
                    Image photo = Image.FromStream(ms);
                    guna2PictureBox1.Image = photo;
                }

                connection.Close();
            }
            catch (Exception ex) { }

            command.CommandText = $"select name from Users where login = '{label3.Text}'";
            try
            {
                connection.Open();
                if (command.ExecuteScalar() != null) label6.Text = command.ExecuteScalar().ToString();
                connection.Close();
            }
            catch (Exception ex) { }

            int max = 0;
            int y = 20;
            bool cartTrue = false;
            command.Connection = connection;
            for (int i = 0; i < 100; i++)
            {
                int j = i + 1;
                command.CommandText = "SELECT EXISTS(SELECT * FROM Orders WHERE login='" + label3.Text + "' AND id=" + j + ");";
                connection.Open();
                if (command.ExecuteScalar().ToString() == "1") { cartTrue = true; }
                else { cartTrue = false; }
                connection.Close();
                arrPicture[i] = new Guna2PictureBox();
                arrPicture[i].Size = new Size(276, 276);
                arrPicture[i].Location = new Point(50, y);
                arrPicture[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPicture[i].BorderRadius = 30;
                arrPicture[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPicture[i].Name = Convert.ToString(i + 1);


                command.CommandText = $"select picture from Orders where login = '{label3.Text}' and id = '{i + 1}'";
                try
                {
                    connection.Open();
                    byte[] photoBytes = (byte[])command.ExecuteScalar();
                    using (MemoryStream ms = new MemoryStream(photoBytes))
                    {
                        Image photo = Image.FromStream(ms);
                        arrPicture[i].Image = photo;
                        if (cartTrue == true)
                        {
                            y += 306;
                            guna2Panel2.Controls.Add(arrPicture[i]);
                            max = i;
                        }


                    }
                    connection.Close();
                }
                catch { }


            }
            y = 312;
            for (int i = 0; i < max; i++)
            {
                int j = i + 1;
                command.CommandText = "SELECT EXISTS(SELECT * FROM Orders WHERE login='" + label3.Text + "' AND id=" + j + ");";
                connection.Open();
                if (command.ExecuteScalar().ToString() == "1") { cartTrue = true; }
                else { cartTrue = false; }
                connection.Close();
                arrSh[i] = new Guna2Shapes();
                arrSh[i].Size = new Size(guna2Panel2.Width - 25, 2);
                arrSh[i].Location = new Point(0, y);
                arrSh[i].BackColor = Color.FromArgb(106, 65, 87);
                arrSh[i].BorderColor = Color.FromArgb(106, 65, 87);
                arrSh[i].FillColor = Color.FromArgb(106, 65, 87);

                if (cartTrue == true)
                {
                    y += 306;
                    guna2Panel2.Controls.Add(arrSh[i]);

                }

            }
            y = 47;
            for (int i = 0; i < 100; i++)
            {
                int j = i + 1;
                command.CommandText = "SELECT EXISTS(SELECT * FROM Orders WHERE login='" + label3.Text + "' AND id=" + j + ");";
                connection.Open();
                if (command.ExecuteScalar().ToString() == "1") { cartTrue = true; }
                else { cartTrue = false; }
                connection.Close();
                arrName[i] = new System.Windows.Forms.Label();
                arrName[i].Font = new Font("Roboto", 18, FontStyle.Regular);
                arrName[i].ForeColor = Color.Silver;
                arrName[i].Location = new Point(356, y);
                arrName[i].AutoSize = true;

                command.CommandText = $"select title from Orders where login = '{label3.Text}' and id = '{i + 1}'";
                try
                {
                    connection.Open();
                    if (command.ExecuteScalar() != null)
                    {
                        arrName[i].Text = command.ExecuteScalar().ToString();
                        if (cartTrue == true)
                        {
                            y += 306;
                            guna2Panel2.Controls.Add(arrName[i]);

                        }
                    }
                    connection.Close();
                }
                catch (Exception ex) { }

            }
            y = 24;
            for (int i = 0; i < max - 1; i++)
            {
                arrTitleLabel[i] = new System.Windows.Forms.Label();
                arrTitleLabel[i].Font = new Font("Roboto", 12, FontStyle.Regular);
                arrTitleLabel[i].ForeColor = Color.Gray;
                arrTitleLabel[i].Location = new Point(356, y);
                arrTitleLabel[i].AutoSize = true;
                arrTitleLabel[i].Text = "Название услуги: ";
                guna2Panel2.Controls.Add(arrTitleLabel[i]);
                y += 306;

            }
            y = 210;
            for (int i = 0; i < 100; i++)
            {
                int j = i + 1;
                command.CommandText = "SELECT EXISTS(SELECT * FROM Orders WHERE login='" + label3.Text + "' AND id=" + j + ");";
                connection.Open();
                if (command.ExecuteScalar().ToString() == "1") { cartTrue = true; }
                else { cartTrue = false; }
                connection.Close();
                arrCen[i] = new System.Windows.Forms.Label();
                arrCen[i].Font = new Font("Roboto", 18, FontStyle.Regular);
                arrCen[i].ForeColor = Color.Silver;
                arrCen[i].Location = new Point(356, y);
                arrCen[i].AutoSize = true;

                command.CommandText = $"select status from Orders where login = '{label3.Text}' and id = '{j}'";
                try
                {
                    connection.Open();
                    if (command.ExecuteScalar() != null)
                    {
                        arrCen[i].Text = "Статус: " + command.ExecuteScalar().ToString();
                    }
                    connection.Close();
                }
                catch (Exception ex) { }
                if (cartTrue == true)
                {
                    y += 306;
                    guna2Panel2.Controls.Add(arrCen[i]);

                }
            }

            y = 168;
            for (int i = 0; i < 100; i++)
            {
                int j = i + 1;
                command.CommandText = "SELECT EXISTS(SELECT * FROM Orders WHERE login='" + label3.Text + "' AND id=" + j + ");";
                connection.Open();
                if (command.ExecuteScalar().ToString() == "1") { cartTrue = true; }
                else { cartTrue = false; }
                connection.Close();
                arrButton[i] = new Guna2ImageButton();
                arrButton[i].Size = new Size(78, 82);
                arrButton[i].ImageSize = new Size(52, 52);
                arrButton[i].Location = new Point(1450, y);
                arrButton[i].Cursor = Cursors.Hand;
                arrButton[i].Name = Convert.ToString(i + 1);
                arrButton[i].Click += deleteOrder;
                arrButton[i].Image = Image.FromFile("мусор.png");
                if (cartTrue == true)
                {
                    y += 306;
                    guna2Panel2.Controls.Add(arrButton[i]);


                }

            }

            timer2.Stop();
        }

        public void deleteOrder(object sender, EventArgs e)
        {
            Guna2ImageButton clickButton = sender as Guna2ImageButton;
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = $"DELETE FROM Orders WHERE id = {Convert.ToInt32(clickButton.Name)} and login = '{label3.Text}'";
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton8_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Visible = true;
            form7.label2.Text = label3.Text;
            if (timer1.Enabled == true) { form7.timer1.Enabled = true; }
            this.Visible = false;
            timer2.Start();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Visible = true;
            this.Visible = false;
        }
    }
}
