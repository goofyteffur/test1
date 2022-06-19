using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ex
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection() //Подлючение к самой бд
        {
            string host = "localhost";
            int port = 3306;
            string database = "otell";
            string username = "root";
            string password = "root";

            return DBMySql.GetDBConnection(host, port, database, username, password);
        }
    }
}
