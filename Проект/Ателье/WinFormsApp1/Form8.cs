using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form8 : Form
    {

        public Form8()
        {
            InitializeComponent();
        }
        int Cen = 0;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cen = Convert.ToInt32(label2.Text);
            if (textBox3.Text != "")
            {
                if (Convert.ToInt32(textBox3.Text) > 96 && Convert.ToInt32(textBox3.Text) <= 102) { Cen += 2; }
                if (Convert.ToInt32(textBox3.Text) > 102 && Convert.ToInt32(textBox3.Text) <= 111) { Cen += 4; }
                if (Convert.ToInt32(textBox3.Text) > 111) { Cen += 6; }
            }
            if (textBox1.Text != "")
            {
                if (Convert.ToInt32(textBox1.Text) > 87 && Convert.ToInt32(textBox1.Text) <= 94) { Cen += 2; }
                if (Convert.ToInt32(textBox1.Text) > 94 && Convert.ToInt32(textBox1.Text) <= 104) { Cen += 4; }
                if (Convert.ToInt32(textBox1.Text) > 104) { Cen += 6; }
            }
            if (textBox2.Text != "")
            {
                if (Convert.ToInt32(textBox2.Text) > 108 && Convert.ToInt32(textBox2.Text) <= 132) { Cen += 2; }
                if (Convert.ToInt32(textBox2.Text) > 132 && Convert.ToInt32(textBox2.Text) <= 148) { Cen += 4; }
                if (Convert.ToInt32(textBox2.Text) > 148) { Cen += 6; }
            }
            if (textBox4.Text != "")
            {
                if (Convert.ToInt32(textBox1.Text) > 46 && Convert.ToInt32(textBox1.Text) <= 50) { Cen += 2; }
                if (Convert.ToInt32(textBox1.Text) > 50 && Convert.ToInt32(textBox1.Text) <= 69) { Cen += 4; }
                if (Convert.ToInt32(textBox1.Text) > 69) { Cen += 6; }
            }

            label1.Text = "Итоговая цена: " + Cen.ToString();
        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox4.Visible = false;

        }

        private void guna2Shapes2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
            pictureBox4.Visible = false;
        }

        private void guna2Shapes3_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            pictureBox2.Visible = false;
            pictureBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((pictureBox4.Visible == true || pictureBox1.Visible == true || pictureBox2.Visible == true) == true &&
                textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                DateTime currentDate = DateTime.Today.Date;
                Form7 form7 = new Form7();
                var connection = new SqliteConnection("Data Source=Studio.db");
                var command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"select picture from Cart where id = {Convert.ToInt32(label10.Text)} and login = '{label11.Text}'";
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
                command.CommandText = "INSERT INTO Orders (login, title,date , id, picture, status, cen) VALUES (:login, :title, :date,:id, @value, :status , :cen)";
                command.Parameters.AddWithValue("login", label11.Text);
                command.Parameters.AddWithValue("title", label4.Text);
                command.Parameters.AddWithValue("date", currentDate.ToString());
                command.Parameters.AddWithValue("id", Convert.ToInt32(label10.Text));
                command.Parameters.AddWithValue("status", "В процессе");
                command.Parameters.AddWithValue("cen", Cen);
                SqliteParameter valueParam = new SqliteParameter("@value", SqliteType.Blob);
                valueParam.Value = imageBytes;
                command.Parameters.Add(valueParam);
                command.ExecuteNonQuery();
                MessageBox.Show("Заказ оформлен");
                connection.Close();
            }
            else if ((pictureBox4.Visible == true || pictureBox1.Visible == true || pictureBox2.Visible == true) == false)
            {
                MessageBox.Show("Вы не выбрали цвет");
            }
            else if ((textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "") == true)
            {
                MessageBox.Show("Вы не ввели размеры");
            }
        }
        static bool IsNumeric(string input)
        {
            Regex regex = new Regex(@"^\d+(\.\d+)?$");
            return regex.IsMatch(input);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!(IsNumeric(textBox1.Text)))
            {
                MessageBox.Show("Пожалуйста, введите только цифры.");
                textBox1.Text = "";
            }
            else timer1.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (!(IsNumeric(textBox2.Text)))
            {

                MessageBox.Show("Пожалуйста, введите только цифры.");
                textBox2.Text = "";

            }
            else timer1.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (!(IsNumeric(textBox3.Text)))
            {
                MessageBox.Show("Пожалуйста, введите только цифры.");
                textBox3.Text = "";
            }
            else timer1.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (!(IsNumeric(textBox4.Text)))
            {
                MessageBox.Show("Пожалуйста, введите только цифры.");
                textBox4.Text = "";
            }
            else timer1.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
