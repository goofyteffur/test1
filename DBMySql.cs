using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ex
{
    class DBMySql
    {
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password) //строка для подлюкчение к бд с помощью пакета из NuGet
        {
            String connString = "Server = " + host + "; Database = " + database + "; Port = " + port + "; User = " + username + "; Password = " + password;
            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
