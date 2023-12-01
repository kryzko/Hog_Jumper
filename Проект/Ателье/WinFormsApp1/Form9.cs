using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
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
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
  
        bool idNotRepetitive = true;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[0-9]*$"))
            {
                MessageBox.Show("Пожалуйста, введите только цифры.");
                textBox3.Text = "";
            }
            else
            {
                var connection = new SqliteConnection("Data Source=Studio.db");
                var command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "select count(*) from Services where id ==:id";
                command.Parameters.AddWithValue(":id", textBox3.Text);
                connection.Open();
                int countRecords = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                command.Parameters.Clear();
                if (countRecords > 0)
                {
                    idNotRepetitive = true;
                }
                else
                {
                    idNotRepetitive = false;
                }
                if (idNotRepetitive)
                {
                    MessageBox.Show("Такой ID уже существует.");
                    textBox3.Text = "";
                }
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool ImageTrue = false;
            try { Convert.ToByte(guna2PictureBox1.Image); ImageTrue = true; } catch { ImageTrue = false; }

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && ImageTrue == false)
            {
                var connection = new SqliteConnection("Data Source=Studio.db");
                var command = new SqliteCommand("select * from Services", connection);
                connection.Open();
                Image image = guna2PictureBox1.Image;
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                command.CommandText = "INSERT INTO Services (id,title,price,picture) VALUES (:id,:title,:price,@value)";
                command.Parameters.AddWithValue("id", Convert.ToInt32(textBox3.Text));
                command.Parameters.AddWithValue("title", textBox1.Text);
                command.Parameters.AddWithValue("price", textBox2.Text);
                SqliteParameter valueParam = new SqliteParameter("@value", SqliteType.Blob);
                valueParam.Value = imageBytes;
                command.Parameters.Add(valueParam);
                command.ExecuteNonQuery(); ;
                Form5 form5 = new Form5();
                form5.timer2.Enabled = true;
                this.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[0-9]*$"))
            {
                MessageBox.Show("Пожалуйста, введите только цифры.");
                textBox2.Text = "";
            }
        }
    }
}
