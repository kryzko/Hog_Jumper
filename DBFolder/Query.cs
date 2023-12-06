using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hog_Jumper.DBFolder
{
    internal class Query
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();
        }

        public DataTable UpdatePerson()//обновление данных в таблице Users
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Users", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void Add(string login, string password)//добавление строки в таблицу Users
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [Users] ([login], [password]) VALUES('{login}', '{password}' )", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(string login)//удаление строки в таблице Users по логину
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Users WHERE login = '{login}'", connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public bool SearchReapeatLogin(string login)//Проверка на повторени логина
        {
            connection.Open();
            command = new OleDbCommand($"select count(*) from Users where login ='{login}'", connection);
            int countRecords = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            if (countRecords > 0) { return false; }
            else { return true; }
        }
        public bool SearchPasswordWhereLogin(string login, string password)//поиск пароля по логину
        {
            connection.Open();
            command = new OleDbCommand($"select password from Users where login = '{login}' ", connection);
            var result = command.ExecuteScalar();
            connection.Close();
            if (result.ToString() == password) { return true; }
            else { return false; }
        }
        public void UpdatingRecordsToTable(string login, int score)
        {
            connection.Open();
            command = new OleDbCommand($"UPDATE Users SET score = {score} WHERE login = '{login}'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void OutputOfRecords(DataGridView tableRecords)
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT login,score FROM Users", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            tableRecords.DataSource = dataTable;
            connection.Close();
        }
    }
}
