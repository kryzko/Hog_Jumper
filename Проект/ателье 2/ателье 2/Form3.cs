using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;


namespace ателье_2
{

    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            var connection = new SqliteConnection("Data Source=ателье.db");
            var command = new SqliteCommand("select * from Services");
            connection.Open();
            SqliteDataReader dataReader = command.ExecuteReader();

            dataGridView1.DataSource = dataReader;
            connection.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 0) label1.Text = "В";
            if (i == 1) label1.Text = "В Р";
            if (i == 2) label1.Text = "В РАЗ";
            if (i == 3) label1.Text = "В РАЗР";
            if (i == 4) label1.Text = "В РАЗРА";
            if (i == 5) label1.Text = "В РАЗРАБ";
            if (i == 6) label1.Text = "В РАЗРАБО";
            if (i == 7) label1.Text = "В РАЗРАБОТ";
            if (i == 8) label1.Text = "В РАЗРАБОТК";
            if (i == 9) { label1.Text = "В РАЗРАБОТКЕ"; i = -1; }
            i++;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataTable dataTable = new DataTable();
            
       




        }
    }
}
