using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {

        int table = 0;
        public Form5()
        {
            InitializeComponent();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Guna2PictureBox[] arrPicture = new Guna2PictureBox[100];
        Guna2Shapes[] arrSh = new Guna2Shapes[100];
        System.Windows.Forms.Label[] arrName = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrLogin = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrPassword = new System.Windows.Forms.Label[100];
        Guna2TextBox[] arrRole = new Guna2TextBox[100];
        Guna2ImageButton[] arrButton = new Guna2ImageButton[100];
        System.Windows.Forms.Label[] arrTextRole = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrTextRole2 = new System.Windows.Forms.Label[100];
        int max = 0;
        private void button4_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            if (label1.Text == "0")
            {
                Form3 form3 = new Form3();
                form3.timer2.Enabled = true;
                form3.label2.Text = label2.Text;
                form3.Visible = true;
            }
            if (label1.Text == "1")
            {
                Form3 form3 = new Form3();
                form3.label2.Text = label2.Text;
                form3.Visible = true;
            }
            if (label1.Text == "2")
            {
                Form4 form4 = new Form4();
                form4.timer1.Enabled = true;
                form4.label2.Text = label2.Text;
                form4.Visible = true;
            }
            if (label1.Text == "3")
            {
                Form4 form4 = new Form4();
                form4.label2.Text = label2.Text;
                form4.Visible = true;
            }
            if (label1.Text == "4")
            {
                Form6 form6 = new Form6();
                form6.timer1.Enabled = true;
                form6.label3.Text = label2.Text;
                form6.Visible = true;
            }
            if (label1.Text == "5")
            {
                Form6 form6 = new Form6();
                form6.label3.Text = label2.Text;
                form6.Visible = true;
            }
            if (label1.Text == "6")
            {
                Form7 form7 = new Form7();
                form7.timer1.Enabled = true;
                form7.label2.Text = label2.Text;
                form7.Visible = true;
            }
            if (label1.Text == "7")
            {
                Form7 form7 = new Form7();
                form7.label2.Text = label2.Text;
                form7.Visible = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.Connection = connection;
            int y = 20;
            bool cartTrue = false;
            command.Connection = connection;
            y = 27;
            for (int i = 0; i < 100; i++)
            {
                arrLogin[i] = new System.Windows.Forms.Label();
                arrLogin[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrLogin[i].ForeColor = Color.Silver;
                arrLogin[i].Location = new Point(356, y);
                arrLogin[i].AutoSize = true;
                string query = "SELECT login FROM Users";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrLogin[i].Name = dataTable.Rows[i]["login"].ToString();
                        arrLogin[i].Text = "Логин: " + dataTable.Rows[i]["login"].ToString();
                        panel1.Controls.Add(arrLogin[i]);
                        y += 220;
                        max = i + 1;
                    }
                }
                catch (Exception ex) { }

            }
            y = 20;
            for (int i = 0; i < max; i++)
            {
                connection.Close();
                arrPicture[i] = new Guna2PictureBox();
                arrPicture[i].Size = new Size(200, 200);
                arrPicture[i].Location = new Point(50, y);
                arrPicture[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPicture[i].BorderRadius = 30;
                arrPicture[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPicture[i].Name = Convert.ToString(i + 1);
                string query = "select picture from Users";
                connection.Open();

                using (command = new SqliteCommand(query, connection))
                {
                    SqliteDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    try
                    {
                        byte[] photoBytes = (byte[])dataTable.Rows[i]["picture"];
                        using (MemoryStream ms = new MemoryStream(photoBytes))
                        {
                            Image photo = Image.FromStream(ms);
                            arrPicture[i].Image = photo;


                        }
                    }
                    catch { }
                }
                panel1.Controls.Add(arrPicture[i]);
                y += 220;

            }
            y = 60;
            for (int i = 0; i < max; i++)
            {
                arrName[i] = new System.Windows.Forms.Label();
                arrName[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrName[i].ForeColor = Color.Silver;
                arrName[i].Location = new Point(356, y);
                arrName[i].AutoSize = true;
                string query = "SELECT name FROM Users";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrName[i].Text = "Имя: " + dataTable.Rows[i]["name"].ToString();
                        panel1.Controls.Add(arrName[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }

            }
            y = 93;
            for (int i = 0; i < max; i++)
            {
                arrPassword[i] = new System.Windows.Forms.Label();
                arrPassword[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrPassword[i].ForeColor = Color.Silver;
                arrPassword[i].Location = new Point(356, y);
                arrPassword[i].AutoSize = true;
                string query = "SELECT password FROM Users";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrPassword[i].Text = "Пароль: " + dataTable.Rows[i]["password"].ToString();
                        panel1.Controls.Add(arrPassword[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }

            }
            y = 134;

            for (int i = 0; i < max; i++)
            {
                arrTextRole[i] = new System.Windows.Forms.Label();
                arrTextRole[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrTextRole[i].ForeColor = Color.Silver;
                arrTextRole[i].Location = new Point(356, y);
                arrTextRole[i].AutoSize = true;
                arrTextRole[i].Text = "Роль: ";
                panel1.Controls.Add(arrTextRole[i]);
                y += 220;

            }
            y = 126;

            for (int i = 0; i < max; i++)
            {
                arrRole[i] = new Guna2TextBox();
                arrRole[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrRole[i].ForeColor = Color.Silver;
                arrRole[i].Location = new Point(440, y);
                arrRole[i].Size = new Size(45, 45);
                arrRole[i].MaxLength = 1;
                arrRole[i].TextChanged += textBox_TextChanged;
                arrRole[i].TextAlign = HorizontalAlignment.Center;
                arrRole[i].FillColor = Color.FromArgb(55, 11, 35);
                arrRole[i].BorderColor = Color.FromArgb(106, 65, 87);
                arrRole[i].Name = arrLogin[i].Name;
                string query = "SELECT role FROM Users";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrRole[i].Text = dataTable.Rows[i]["role"].ToString();
                        panel1.Controls.Add(arrRole[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }
            }

            y = 134;
            for (int i = 0; i < max; i++)
            {
                arrTextRole[i] = new System.Windows.Forms.Label();
                arrTextRole[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrTextRole[i].ForeColor = Color.Silver;
                arrTextRole[i].Location = new Point(490, y);
                arrTextRole[i].AutoSize = true;
                if (arrRole[i].Text == "0") { arrTextRole[i].Text = "Клиент"; }
                if (arrRole[i].Text == "1") { arrTextRole[i].Text = "Администратор"; }
                panel1.Controls.Add(arrTextRole[i]);
                y += 220;

            }
            y = 144;
            for (int i = 0; i < max; i++)
            {
                int j = i + 1;
                connection.Close();
                arrButton[i] = new Guna2ImageButton();
                arrButton[i].Size = new Size(78, 82);
                arrButton[i].ImageSize = new Size(52, 52);
                arrButton[i].Location = new Point(900, y);
                arrButton[i].Cursor = Cursors.Hand;
                arrButton[i].Name = Convert.ToString(arrLogin[i].Name);
                arrButton[i].Click += deleteUsers;
                command.CommandText = "SELECT blocked FROM Users WHERE login= '" + arrLogin[i].Name + "'";
                connection.Open();
                if (command.ExecuteScalar().ToString() == "0") { arrButton[i].Image = Image.FromFile("открытый.png"); }
                if (command.ExecuteScalar().ToString() == "1") { arrButton[i].Image = Image.FromFile("закрытый.png"); }
                panel1.Controls.Add(arrButton[i]);
                y += 220;

            }

        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox changedText = (Guna2TextBox)sender;
            if (!System.Text.RegularExpressions.Regex.IsMatch(changedText.Text, "^[0-1]*$"))
            {
                MessageBox.Show("Пожалуйста, введите 1(права администратора) либо 0(клиен)");
                changedText.Text = "0";
            }
            else
            {
                var connection = new SqliteConnection("Data Source=Studio.db");
                var command = new SqliteCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = $"UPDATE Users SET role = @role WHERE login = '{changedText.Name}'";
                command.Parameters.AddWithValue("@role", changedText.Text);
                command.ExecuteNonQuery();
            }
        }
        int click = 0;
        private void deleteUsers(object sender, EventArgs e)
        {
            Guna2ImageButton clickButton = sender as Guna2ImageButton;
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = $"SELECT blocked From Users Where login = '{clickButton.Name}'";
            connection.Open();
            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
            {
                clickButton.Image = Image.FromFile("закрытый.png");
                command.CommandText = $"UPDATE Users SET blocked = @blocked WHERE login = '{clickButton.Name}'";
                command.Parameters.AddWithValue("@blocked", 1);
                command.ExecuteNonQuery();
            }
            else
            {
                clickButton.Image = Image.FromFile("открытый.png");
                command.CommandText = $"UPDATE Users SET blocked = @blocked WHERE login = '{clickButton.Name}'";
                command.Parameters.AddWithValue("@blocked", 0);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        System.Windows.Forms.Label[] arrIDOrders = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrLoginOrders = new System.Windows.Forms.Label[100];
        Guna2PictureBox[] arrPictureOrders = new Guna2PictureBox[100];
        System.Windows.Forms.Label[] arrTitleOrders = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrCenOrders = new System.Windows.Forms.Label[100];
        Guna2TextBox[] arrStatusOrders = new Guna2TextBox[100];
        System.Windows.Forms.Label[] arrStatusOrdersLabel = new System.Windows.Forms.Label[100];
        Guna2ImageButton[] arrButtonOrders = new Guna2ImageButton[100];
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.Connection = connection;
            int y = 20;
            bool cartTrue = false;
            command.Connection = connection;
            y = 30;
            for (int i = 0; i < 100; i++)
            {
                arrIDOrders[i] = new System.Windows.Forms.Label();
                arrIDOrders[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrIDOrders[i].ForeColor = Color.Silver;
                arrIDOrders[i].Location = new Point(356, y);
                arrIDOrders[i].AutoSize = true;
                string query = "SELECT id FROM Orders";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrIDOrders[i].Name = dataTable.Rows[i]["id"].ToString();
                        arrIDOrders[i].Text = "ID: " + dataTable.Rows[i]["id"].ToString();
                        panel1.Controls.Add(arrIDOrders[i]);
                        y += 220;
                        max = i + 1;
                    }
                }
                catch (Exception ex) { }

            }
            y = 30;
            for (int i = 0; i < 100; i++)
            {
                arrLoginOrders[i] = new System.Windows.Forms.Label();
                arrLoginOrders[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrLoginOrders[i].ForeColor = Color.Silver;
                arrLoginOrders[i].Location = new Point(490, y);
                arrLoginOrders[i].AutoSize = true;
                string query = "SELECT login FROM Orders";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrLoginOrders[i].Name = dataTable.Rows[i]["login"].ToString();
                        arrLoginOrders[i].Text = "Логин: " + dataTable.Rows[i]["login"].ToString();
                        panel1.Controls.Add(arrLoginOrders[i]);
                        y += 220;
                        max = i + 1;
                    }
                }
                catch (Exception ex) { }

            }
            y = 20;
            for (int i = 0; i < max; i++)
            {
                connection.Close();
                arrPictureOrders[i] = new Guna2PictureBox();
                arrPictureOrders[i].Size = new Size(200, 200);
                arrPictureOrders[i].Location = new Point(50, y);
                arrPictureOrders[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPictureOrders[i].BorderRadius = 30;
                arrPictureOrders[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPictureOrders[i].Name = Convert.ToString(i + 1);
                string query = "select picture from Orders";
                connection.Open();

                using (command = new SqliteCommand(query, connection))
                {
                    SqliteDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    try
                    {
                        byte[] photoBytes = (byte[])dataTable.Rows[i]["picture"];
                        using (MemoryStream ms = new MemoryStream(photoBytes))
                        {
                            Image photo = Image.FromStream(ms);
                            arrPictureOrders[i].Image = photo;


                        }
                    }
                    catch { }
                }
                panel1.Controls.Add(arrPictureOrders[i]);
                y += 220;

            }
            y = 63;
            for (int i = 0; i < max; i++)
            {
                arrTitleOrders[i] = new System.Windows.Forms.Label();
                arrTitleOrders[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrTitleOrders[i].ForeColor = Color.Silver;
                arrTitleOrders[i].Location = new Point(356, y);
                arrTitleOrders[i].AutoSize = true;
                string query = "SELECT title FROM Orders";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrTitleOrders[i].Text = "Название услуги: " + dataTable.Rows[i]["title"].ToString();
                        panel1.Controls.Add(arrTitleOrders[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }

            }
            y = 96;
            for (int i = 0; i < max; i++)
            {
                arrCenOrders[i] = new System.Windows.Forms.Label();
                arrCenOrders[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrCenOrders[i].ForeColor = Color.Silver;
                arrCenOrders[i].Location = new Point(356, y);
                arrCenOrders[i].AutoSize = true;
                string query = "SELECT cen FROM Orders";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrCenOrders[i].Text = "Цена: " + dataTable.Rows[i]["cen"].ToString();
                        panel1.Controls.Add(arrCenOrders[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }

            }
            y = 144;
            for (int i = 0; i < max; i++)
            {
                int j = i + 1;
                connection.Close();
                arrButtonOrders[i] = new Guna2ImageButton();
                arrButtonOrders[i].Size = new Size(78, 82);
                arrButtonOrders[i].ImageSize = new Size(52, 52);
                arrButtonOrders[i].Location = new Point(900, y);
                arrButtonOrders[i].Cursor = Cursors.Hand;
                arrButtonOrders[i].Name = Convert.ToString(arrLoginOrders[i].Name);
                arrButtonOrders[i].Tag = arrIDOrders[i].Name;
                arrButtonOrders[i].Click += deleteOrders;
                arrButtonOrders[i].Image = Image.FromFile("мусор.png");
                panel1.Controls.Add(arrButtonOrders[i]);
                y += 220;
            }
            y = 126;

            for (int i = 0; i < max; i++)
            {
                arrStatusOrders[i] = new Guna2TextBox();
                arrStatusOrders[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrStatusOrders[i].ForeColor = Color.Silver;
                arrStatusOrders[i].Location = new Point(590, y);
                arrStatusOrders[i].Size = new Size(200, 45);
                arrStatusOrders[i].TextChanged += StatusOrder_TextChanged;
                arrStatusOrders[i].TextAlign = HorizontalAlignment.Left;
                arrStatusOrders[i].FillColor = Color.FromArgb(55, 11, 35);
                arrStatusOrders[i].BorderColor = Color.FromArgb(106, 65, 87);
                arrStatusOrders[i].Name = arrLoginOrders[i].Name;
                arrStatusOrders[i].Tag = arrIDOrders[i].Name;
                string query = "SELECT status FROM Orders";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrStatusOrders[i].Text = dataTable.Rows[i]["status"].ToString();
                        panel1.Controls.Add(arrStatusOrders[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }
            }
            y = 134;
            for (int i = 0; i < max; i++)
            {
                arrStatusOrdersLabel[i] = new System.Windows.Forms.Label();
                arrStatusOrdersLabel[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrStatusOrdersLabel[i].ForeColor = Color.Silver;
                arrStatusOrdersLabel[i].Location = new Point(356, y);
                arrStatusOrdersLabel[i].AutoSize = true;
                arrStatusOrdersLabel[i].Text = "Статус товара";
                panel1.Controls.Add(arrStatusOrdersLabel[i]);
                y += 220;

            }

        }
        private void deleteOrders(object sender, EventArgs e)
        {
            Guna2ImageButton clickButton = sender as Guna2ImageButton;
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = $"DELETE FROM Orders WHERE  login = '{clickButton.Name}' and id = {Convert.ToInt32(clickButton.Tag)}";
            connection.Open();
            command.ExecuteNonQuery();
            timer1.Enabled = true;
        }
        private void StatusOrder_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox changedText = (Guna2TextBox)sender;
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            connection.Open();
            command.CommandText = $"UPDATE Orders SET status = @status WHERE login = '{changedText.Name}' and id = {Convert.ToInt32(changedText.Tag)}";
            command.Parameters.AddWithValue("@status", changedText.Text);
            command.ExecuteNonQuery();
        }
        System.Windows.Forms.Label[] arrIDService = new System.Windows.Forms.Label[100];
        Guna2PictureBox[] arrPictureService = new Guna2PictureBox[100];
        System.Windows.Forms.Label[] arrTitleService = new System.Windows.Forms.Label[100];
        System.Windows.Forms.Label[] arrCenService = new System.Windows.Forms.Label[100];
        Guna2ImageButton[] arrButtonService = new Guna2ImageButton[100];
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.Connection = connection;
            int y = 20;
            bool cartTrue = false;
            command.Connection = connection;
            y = 30;
            for (int i = 0; i < 100; i++)
            {
                arrIDService[i] = new System.Windows.Forms.Label();
                arrIDService[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrIDService[i].ForeColor = Color.Silver;
                arrIDService[i].Location = new Point(356, y);
                arrIDService[i].AutoSize = true;
                string query = "SELECT id FROM Services";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrIDService[i].Name = dataTable.Rows[i]["id"].ToString();
                        arrIDService[i].Text = "ID: " + dataTable.Rows[i]["id"].ToString();
                        panel1.Controls.Add(arrIDService[i]);
                        y += 220;
                        max = i + 1;
                    }
                }
                catch (Exception ex) { }

            }
            y = 20;
            for (int i = 0; i < max; i++)
            {
                connection.Close();
                arrPictureService[i] = new Guna2PictureBox();
                arrPictureService[i].Size = new Size(200, 200);
                arrPictureService[i].Location = new Point(50, y);
                arrPictureService[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPictureService[i].BorderRadius = 30;
                arrPictureService[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPictureService[i].Name = Convert.ToString(i + 1);
                string query = "select picture from Services";
                connection.Open();

                using (command = new SqliteCommand(query, connection))
                {
                    SqliteDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    try
                    {
                        byte[] photoBytes = (byte[])dataTable.Rows[i]["picture"];
                        using (MemoryStream ms = new MemoryStream(photoBytes))
                        {
                            Image photo = Image.FromStream(ms);
                            arrPictureService[i].Image = photo;


                        }
                    }
                    catch { }
                }
                panel1.Controls.Add(arrPictureService[i]);
                y += 220;

            }
            y = 63;
            for (int i = 0; i < max; i++)
            {
                arrTitleService[i] = new System.Windows.Forms.Label();
                arrTitleService[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrTitleService[i].ForeColor = Color.Silver;
                arrTitleService[i].Location = new Point(356, y);
                arrTitleService[i].AutoSize = true;
                string query = "SELECT title FROM Services";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrTitleService[i].Text = "Название услуги: " + dataTable.Rows[i]["title"].ToString();
                        panel1.Controls.Add(arrTitleService[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }

            }
            y = 96;
            for (int i = 0; i < max; i++)
            {
                arrCenService[i] = new System.Windows.Forms.Label();
                arrCenService[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrCenService[i].ForeColor = Color.Silver;
                arrCenService[i].Location = new Point(356, y);
                arrCenService[i].AutoSize = true;
                string query = "SELECT price FROM Services";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrCenService[i].Text = "Цена: " + dataTable.Rows[i]["price"].ToString();
                        panel1.Controls.Add(arrCenService[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }

            }
            y = 144;
            for (int i = 0; i < max; i++)
            {
                int j = i + 1;
                connection.Close();
                arrButtonService[i] = new Guna2ImageButton();
                arrButtonService[i].Size = new Size(78, 82);
                arrButtonService[i].ImageSize = new Size(52, 52);
                arrButtonService[i].Location = new Point(900, y);
                arrButtonService[i].Cursor = Cursors.Hand;
                arrButtonService[i].Name = Convert.ToString(arrIDService[i].Name);
                arrButtonService[i].Click += deleteServices;
                arrButtonService[i].Image = Image.FromFile("мусор.png");
                panel1.Controls.Add(arrButtonService[i]);
                y += 220;
            }
            Guna2ImageButton button = new Guna2ImageButton();
            button.Size = new Size(100, 100);
            button.ImageSize = new Size(100, 100);
            button.Image = Image.FromFile("плюс.png");
            button.Location = new Point(453, y - 120);
            button.Click += addServices;
            button.Cursor = Cursors.Hand;
            panel1.Controls.Add(button);
        }
        private void deleteServices(object sender, EventArgs e)
        {
            Guna2ImageButton clickButton = sender as Guna2ImageButton;
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = $"DELETE FROM Services WHERE id = {Convert.ToInt32(clickButton.Name)}";
            connection.Open();
            command.ExecuteNonQuery();
            timer2.Enabled = true;
        }
        private void addServices(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Visible = true;

        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.Connection = connection;
            int y = 20;
            bool cartTrue = false;
            command.Connection = connection;
            y = 30;
            for (int i = 0; i < 100; i++)
            {
                arrIDOrders[i] = new System.Windows.Forms.Label();
                arrIDOrders[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrIDOrders[i].ForeColor = Color.Silver;
                arrIDOrders[i].Location = new Point(356, y);
                arrIDOrders[i].AutoSize = true;
                string query = "SELECT id FROM Orders";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrIDOrders[i].Name = dataTable.Rows[i]["id"].ToString();
                        arrIDOrders[i].Text = "ID: " + dataTable.Rows[i]["id"].ToString();
                        panel1.Controls.Add(arrIDOrders[i]);
                        y += 220;
                        max = i + 1;
                    }
                }
                catch (Exception ex) { }

            }
            y = 30;
            for (int i = 0; i < 100; i++)
            {
                arrLoginOrders[i] = new System.Windows.Forms.Label();
                arrLoginOrders[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrLoginOrders[i].ForeColor = Color.Silver;
                arrLoginOrders[i].Location = new Point(490, y);
                arrLoginOrders[i].AutoSize = true;
                string query = "SELECT login FROM Orders";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrLoginOrders[i].Name = dataTable.Rows[i]["login"].ToString();
                        arrLoginOrders[i].Text = "Логин: " + dataTable.Rows[i]["login"].ToString();
                        panel1.Controls.Add(arrLoginOrders[i]);
                        y += 220;
                        max = i + 1;
                    }
                }
                catch (Exception ex) { }

            }
            y = 20;
            for (int i = 0; i < max; i++)
            {
                connection.Close();
                arrPictureOrders[i] = new Guna2PictureBox();
                arrPictureOrders[i].Size = new Size(200, 200);
                arrPictureOrders[i].Location = new Point(50, y);
                arrPictureOrders[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPictureOrders[i].BorderRadius = 30;
                arrPictureOrders[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPictureOrders[i].Name = Convert.ToString(i + 1);
                string query = "select picture from Orders";
                connection.Open();

                using (command = new SqliteCommand(query, connection))
                {
                    SqliteDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    try
                    {
                        byte[] photoBytes = (byte[])dataTable.Rows[i]["picture"];
                        using (MemoryStream ms = new MemoryStream(photoBytes))
                        {
                            Image photo = Image.FromStream(ms);
                            arrPictureOrders[i].Image = photo;


                        }
                    }
                    catch { }
                }
                panel1.Controls.Add(arrPictureOrders[i]);
                y += 220;

            }
            y = 63;
            for (int i = 0; i < max; i++)
            {
                arrTitleOrders[i] = new System.Windows.Forms.Label();
                arrTitleOrders[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrTitleOrders[i].ForeColor = Color.Silver;
                arrTitleOrders[i].Location = new Point(356, y);
                arrTitleOrders[i].AutoSize = true;
                string query = "SELECT title FROM Orders";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrTitleOrders[i].Text = "Название услуги: " + dataTable.Rows[i]["title"].ToString();
                        panel1.Controls.Add(arrTitleOrders[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }

            }
            y = 96;
            for (int i = 0; i < max; i++)
            {
                arrCenOrders[i] = new System.Windows.Forms.Label();
                arrCenOrders[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrCenOrders[i].ForeColor = Color.Silver;
                arrCenOrders[i].Location = new Point(356, y);
                arrCenOrders[i].AutoSize = true;
                string query = "SELECT cen FROM Orders";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrCenOrders[i].Text = "Цена: " + dataTable.Rows[i]["cen"].ToString();
                        panel1.Controls.Add(arrCenOrders[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }

            }
            y = 144;
            for (int i = 0; i < max; i++)
            {
                int j = i + 1;
                connection.Close();
                arrButtonOrders[i] = new Guna2ImageButton();
                arrButtonOrders[i].Size = new Size(78, 82);
                arrButtonOrders[i].ImageSize = new Size(52, 52);
                arrButtonOrders[i].Location = new Point(900, y);
                arrButtonOrders[i].Cursor = Cursors.Hand;
                arrButtonOrders[i].Name = Convert.ToString(arrLoginOrders[i].Name);
                arrButtonOrders[i].Tag = arrIDOrders[i].Name;
                arrButtonOrders[i].Click += deleteOrders;
                arrButtonOrders[i].Image = Image.FromFile("мусор.png");
                panel1.Controls.Add(arrButtonOrders[i]);
                y += 220;
            }
            y = 126;

            for (int i = 0; i < max; i++)
            {
                arrStatusOrders[i] = new Guna2TextBox();
                arrStatusOrders[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrStatusOrders[i].ForeColor = Color.Silver;
                arrStatusOrders[i].Location = new Point(590, y);
                arrStatusOrders[i].Size = new Size(200, 45);
                arrStatusOrders[i].TextChanged += StatusOrder_TextChanged;
                arrStatusOrders[i].TextAlign = HorizontalAlignment.Left;
                arrStatusOrders[i].FillColor = Color.FromArgb(55, 11, 35);
                arrStatusOrders[i].BorderColor = Color.FromArgb(106, 65, 87);
                arrStatusOrders[i].Name = arrLoginOrders[i].Name;
                arrStatusOrders[i].Tag = arrIDOrders[i].Name;
                string query = "SELECT status FROM Orders";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrStatusOrders[i].Text = dataTable.Rows[i]["status"].ToString();
                        panel1.Controls.Add(arrStatusOrders[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }
            }
            y = 134;
            for (int i = 0; i < max; i++)
            {
                arrStatusOrdersLabel[i] = new System.Windows.Forms.Label();
                arrStatusOrdersLabel[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrStatusOrdersLabel[i].ForeColor = Color.Silver;
                arrStatusOrdersLabel[i].Location = new Point(356, y);
                arrStatusOrdersLabel[i].AutoSize = true;
                arrStatusOrdersLabel[i].Text = "Статус товара";
                panel1.Controls.Add(arrStatusOrdersLabel[i]);
                y += 220;

            }
            timer1.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.Connection = connection;
            int y = 20;
            bool cartTrue = false;
            command.Connection = connection;
            y = 30;
            for (int i = 0; i < 100; i++)
            {
                arrIDService[i] = new System.Windows.Forms.Label();
                arrIDService[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrIDService[i].ForeColor = Color.Silver;
                arrIDService[i].Location = new Point(356, y);
                arrIDService[i].AutoSize = true;
                string query = "SELECT id FROM Services";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrIDService[i].Name = dataTable.Rows[i]["id"].ToString();
                        arrIDService[i].Text = "ID: " + dataTable.Rows[i]["id"].ToString();
                        panel1.Controls.Add(arrIDService[i]);
                        y += 220;
                        max = i + 1;
                    }
                }
                catch (Exception ex) { }

            }
            y = 20;
            for (int i = 0; i < max; i++)
            {
                connection.Close();
                arrPictureService[i] = new Guna2PictureBox();
                arrPictureService[i].Size = new Size(200, 200);
                arrPictureService[i].Location = new Point(50, y);
                arrPictureService[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPictureService[i].BorderRadius = 30;
                arrPictureService[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPictureService[i].Name = Convert.ToString(i + 1);
                string query = "select picture from Services";
                connection.Open();

                using (command = new SqliteCommand(query, connection))
                {
                    SqliteDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    try
                    {
                        byte[] photoBytes = (byte[])dataTable.Rows[i]["picture"];
                        using (MemoryStream ms = new MemoryStream(photoBytes))
                        {
                            Image photo = Image.FromStream(ms);
                            arrPictureService[i].Image = photo;


                        }
                    }
                    catch { }
                }
                panel1.Controls.Add(arrPictureService[i]);
                y += 220;

            }
            y = 63;
            for (int i = 0; i < max; i++)
            {
                arrTitleService[i] = new System.Windows.Forms.Label();
                arrTitleService[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrTitleService[i].ForeColor = Color.Silver;
                arrTitleService[i].Location = new Point(356, y);
                arrTitleService[i].AutoSize = true;
                string query = "SELECT title FROM Services";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrTitleService[i].Text = "Название услуги: " + dataTable.Rows[i]["title"].ToString();
                        panel1.Controls.Add(arrTitleService[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }

            }
            y = 96;
            for (int i = 0; i < max; i++)
            {
                arrCenService[i] = new System.Windows.Forms.Label();
                arrCenService[i].Font = new Font("Roboto", 14, FontStyle.Regular);
                arrCenService[i].ForeColor = Color.Silver;
                arrCenService[i].Location = new Point(356, y);
                arrCenService[i].AutoSize = true;
                string query = "SELECT price FROM Services";
                connection.Open();
                try
                {
                    using (command = new SqliteCommand(query, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        arrCenService[i].Text = "Цена: " + dataTable.Rows[i]["price"].ToString();
                        panel1.Controls.Add(arrCenService[i]);
                        y += 220;

                    }
                }
                catch (Exception ex) { }

            }
            y = 144;
            for (int i = 0; i < max; i++)
            {
                int j = i + 1;
                connection.Close();
                arrButtonService[i] = new Guna2ImageButton();
                arrButtonService[i].Size = new Size(78, 82);
                arrButtonService[i].ImageSize = new Size(52, 52);
                arrButtonService[i].Location = new Point(900, y);
                arrButtonService[i].Cursor = Cursors.Hand;
                arrButtonService[i].Name = Convert.ToString(arrIDService[i].Name);
                arrButtonService[i].Click += deleteServices;
                arrButtonService[i].Image = Image.FromFile("мусор.png");
                panel1.Controls.Add(arrButtonService[i]);
                y += 220;

            }
            Guna2ImageButton button = new Guna2ImageButton();
            button.Size = new Size(78, 82);
            button.ImageSize = new Size(52, 52);
            button.Image = Image.FromFile("плюс.png");
            button.Location = new Point(453, y);
            button.Click += addServices;
            panel1.Controls.Add(button);
            timer2.Enabled = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
