using Guna.UI2.WinForms;
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
using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            guna2TextBox4.UseSystemPasswordChar = true;
            guna2TextBox3.UseSystemPasswordChar = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;



        }
        bool checkPassword = false;
        private void label6_Click(object sender, EventArgs e)
        {
            if (checkPassword == true && guna2TextBox1.Text != "" && guna2TextBox2.Text != "" && guna2TextBox3.Text != "" && guna2TextBox4.Text != "")
            {
                var connection = new SqliteConnection("Data Source=Studio.db");
                var command = new SqliteCommand("select * from Users", connection);
                connection.Open();
                command.CommandText = "INSERT INTO Users (login, password, name, role, blocked) VALUES (:login, :password, :name, :role, :blocked)";
                command.Parameters.AddWithValue("login", guna2TextBox1.Text);
                command.Parameters.AddWithValue("password", guna2TextBox3.Text);
                command.Parameters.AddWithValue("name", guna2TextBox2.Text);
                command.Parameters.AddWithValue("role", 0);
                command.Parameters.AddWithValue("blocked", 0);
                command.ExecuteNonQuery();
                Form3 form3 = new Form3();
                form3.label2.Text = guna2TextBox1.Text;
                form3.ShowDialog();
                this.Visible = false;
            }
            timer2.Enabled = true;



        }

        private void guna2Shapes6_Click(object sender, EventArgs e)
        {
            if (checkPassword == true && guna2TextBox1.Text != "" && guna2TextBox2.Text != "" && guna2TextBox3.Text != "" && guna2TextBox4.Text != "")
            {
                var connection = new SqliteConnection("Data Source=Studio.db");
                var command = new SqliteCommand("select * from Users", connection);
                connection.Open();
                command.CommandText = "INSERT INTO Users (login, password, name, role, blocked) VALUES (:login, :password, :name, :role, :blocked)";
                command.Parameters.AddWithValue("login", guna2TextBox1.Text);
                command.Parameters.AddWithValue("password", guna2TextBox3.Text);
                command.Parameters.AddWithValue("name", guna2TextBox2.Text);
                command.Parameters.AddWithValue("role", 0);
                command.Parameters.AddWithValue("blocked", 0);
                command.ExecuteNonQuery();
                Form3 form3 = new Form3();
                form3.label2.Text = guna2TextBox1.Text;
                form3.ShowDialog();
                this.Visible = false;
            }
            timer2.Enabled = true;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (guna2TextBox1.Text != "")
            {

                var connection = new SqliteConnection("Data Source=Studio.db");
                var command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "select count(*) from Users where login ==:login";
                command.Parameters.AddWithValue(":login", guna2TextBox1.Text);
                connection.Open();
                int countRecords = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                command.Parameters.Clear();
                if (countRecords > 0)
                {
                    label7.Visible = true;
                    guna2Shapes6.Enabled = false;
                    label6.Enabled = false;
                }
                else
                {
                    label7.Visible = false;
                    guna2Shapes6.Enabled = true;
                    label6.Enabled = true;
                }
            }




        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text != guna2TextBox4.Text)
            {
                label8.Text = "пароли не совпадают";
                label8.Visible = true;
                checkPassword = false;
            }
            if (guna2TextBox2.Text == "")
            {
                label9.Visible = true;
            }
            if (guna2TextBox3.Text == guna2TextBox4.Text)
            {
                label8.Visible = false;
                checkPassword = true;
            }
            if (guna2TextBox2.Text != "")
            {
                label9.Visible = false;
            }
            if (guna2TextBox3.Text != "")
            {
                int chisla = 0;
                int litters = 0;
                int kolSymbols = 0;
                foreach (char c in guna2TextBox3.Text)
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
                if (chisla == 0) { label8.Visible = true; label8.Text = "в пароле должны быть цифры"; checkPassword = false; }
                if (litters == 0) { label8.Visible = true; label8.Text = "в пароле должны быть буквы"; checkPassword = false; }
                if (kolSymbols < 4) { label8.Visible = true; label8.Text = "не меньше 4 символов"; checkPassword = false; }
            }



        }
        int click = 0, click2 = 0;
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                pictureBox1.Image = Image.FromFile("глаз зак.png");
                guna2TextBox3.UseSystemPasswordChar = false;
            }
            else
            {
                pictureBox1.Image = Image.FromFile("глаз.png");
                guna2TextBox3.UseSystemPasswordChar = true;
                click = -1;
            }
            click++;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (click2 == 0)
            {
                pictureBox2.Image = Image.FromFile("глаз зак.png");
                guna2TextBox4.UseSystemPasswordChar = false;
            }
            else
            {
                pictureBox2.Image = Image.FromFile("глаз.png");
                guna2TextBox4.UseSystemPasswordChar = true;
                click2 = -1;
            }
            click2++;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Shapes2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void guna2Shapes3_Click(object sender, EventArgs e)
        {
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void guna2Shapes4_Click(object sender, EventArgs e)
        {
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void guna2Shapes5_Click(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

        }
    }
}
