using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ToDoServer
{
    public class MYSql
    {
        public MySqlConnection Createconnection()
        {
            string connectionString;

            string password = "iCSsvkpJqqKXDD1u2RGnC0yF3VGcchMB7Ue2kVfQwiFKYpfuG9ZAaxBNzGqjiWTBDJDhz44mx6PeKpWdjLMAggaUN5";
            string username = "WCF";
            string DB = "ToDo";
            string Server = "185.101.93.152";

            connectionString = "SERVER=" + Server + ";" + "DATABASE=" + DB + ";"
                + "UID=" + username + ";" + "PASSWORD=" + password + ";";

            return new MySqlConnection(connectionString);
        }

        public bool ValidUser(Guid guid,string password)
        {
            MySqlConnection conn = Createconnection();

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Data Where Guid = @Guid;";

            cmd.Parameters.AddWithValue("@Guid", guid.ToString());

            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                return true;
            }

            return false;
        }
    }
}