using MySql.Data.MySqlClient;
using System.Data;

namespace bank
{
    class ConnectToDataBase
    {
        // Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
        MySqlConnection _connection;
        public string _connStr { get; set; }
        public ConnectToDataBase()
        {
            string connStr =
                "Server=localhost;" +
                "DataBase=logins;" +
                "Uid=root;" +
                "Pwd=root;";
            _connStr = connStr;
            _connection = new MySqlConnection(connStr);
            _connection.Open();
        }
        public void LoginInsert(string login, string password)
        {
            string query = "INSERT users (name, password) VALUES (\'" + login + "\'," + "\'" + password + "\')";

            MySqlScript mySqlScript = new MySqlScript(_connection, query);
            mySqlScript.Execute();
            _connection.Close();
        }
        public void BuyMoney(string name, int amount)
        {
            int user_money;
            string query = $"UPDATE users SET money_count={name} WHERE  name={name}";

        }
        public DataTable GetTable()
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM users", _connection);
            DataTable result = new DataTable();
            dataAdapter.Fill(result);
            return result;
        }
        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}

