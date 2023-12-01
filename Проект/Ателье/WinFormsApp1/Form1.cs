using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;
using System.Data.SqlServerCe;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            guna2TextBox2.UseSystemPasswordChar = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Visible = true;
            this.Visible = false;
        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {




        }

        private void label3_Click(object sender, EventArgs e)
        {
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = "SELECT blocked FROM Users WHERE login= '" + guna2TextBox1.Text + "'";
            connection.Open();
            if (command.ExecuteScalar().ToString() == "0")
            {
                if (guna2TextBox1.Text != "")
                {

                    command.CommandText = "select count(*) from Users where login ==:login";
                    command.Parameters.AddWithValue(":login", guna2TextBox1.Text);
                    connection.Open();
                    int countRecords = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    command.Parameters.Clear();
                    if (countRecords == 0)
                    {
                        timer1.Enabled = true;

                    }
                    else
                    {
                        command.CommandText = $"select password from Users where login = '{guna2TextBox1.Text}' ";
                        connection.Open();
                        var result = command.ExecuteScalar();
                        connection.Close();
                        if (result.ToString() == guna2TextBox2.Text)
                        {
                            Form3 form3 = new Form3();
                            command.CommandText = "SELECT EXISTS(SELECT * FROM Users WHERE login= '" + guna2TextBox1.Text + "' AND role='1');";
                            connection.Open();
                            if (command.ExecuteScalar().ToString() == "1")
                            {

                                form3.timer2.Enabled = true;

                            }
                            else
                            {
                                form3.label1.Visible = false;

                            }

                            form3.label2.Text = guna2TextBox1.Text;

                            connection.Close();
                            form3.Visible = true;
                            this.Visible = false;
                        }
                        else
                        {

                            label6.Visible = true;
                        }
                    }


                }
            }
            else { MessageBox.Show("Ваш аккаун заблокирован("); }



        }
        public void ChangeTB1(string login)
        {
            login = guna2TextBox1.Text;
        }
        private void guna2Shapes4_Click(object sender, EventArgs e)
        {
            var connection = new SqliteConnection("Data Source=Studio.db");
            var command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = "SELECT blocked FROM Users WHERE login= '" + guna2TextBox1.Text + "'";
            connection.Open();
            if (command.ExecuteScalar().ToString() == "0")
            {
                if (guna2TextBox1.Text != "")
                {

                    command.CommandText = "select count(*) from Users where login ==:login";
                    command.Parameters.AddWithValue(":login", guna2TextBox1.Text);
                    connection.Open();
                    int countRecords = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    command.Parameters.Clear();
                    if (countRecords == 0)
                    {
                        timer1.Enabled = true;

                    }
                    else
                    {
                        command.CommandText = $"select password from Users where login = '{guna2TextBox1.Text}' ";
                        connection.Open();
                        var result = command.ExecuteScalar();
                        connection.Close();
                        if (result.ToString() == guna2TextBox2.Text)
                        {
                            Form3 form3 = new Form3();
                            command.CommandText = "SELECT EXISTS(SELECT * FROM Users WHERE login= '" + guna2TextBox1.Text + "' AND role='1');";
                            connection.Open();
                            if (command.ExecuteScalar().ToString() == "1")
                            {

                                form3.timer2.Enabled = true;

                            }
                            else
                            {
                                form3.label1.Visible = false;

                            }

                            form3.label2.Text = guna2TextBox1.Text;

                            connection.Close();
                            form3.Visible = true;
                            this.Visible = false;
                        }
                        else
                        {

                            label6.Visible = true;
                        }
                    }


                }
            }
            else { MessageBox.Show("Ваш аккаун заблокирован("); }



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
                if (countRecords == 0)
                {
                    label7.Visible = true;
                    guna2Shapes4.Enabled = false;
                    label3.Enabled = false;

                }
                else
                {

                    label7.Visible = false;
                    guna2Shapes4.Enabled = true;
                    label3.Enabled = true;
                }

                //SASHA
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        int click = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                pictureBox1.Image = Image.FromFile("глаз зак.png");
                guna2TextBox2.UseSystemPasswordChar = false;
            }
            else
            {
                pictureBox1.Image = Image.FromFile("глаз.png");
                guna2TextBox2.UseSystemPasswordChar = true;
                click = -1;
            }
            click++;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.label2.Text = "1";
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}