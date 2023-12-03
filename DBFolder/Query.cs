using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DataTable UpdatePerson()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Users", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void Add(string login, string password)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [Users] ([login], [password]) VALUES('{login}', '{password}' )", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(string login)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Users WHERE login = '{login}'", connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
    }
}
