using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin
{
    public class DALConnection
    {
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        public static MySqlConnection connection;

        public static MySqlConnection OpenConnection()
        {
            if (connection == null) //  Si la connexion est déjà établi, il ne la refera pas 
            {
                server = "localhost";
                database = "bidcardcoin3";
                uid = "root";
                password = "";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }

    }
}
