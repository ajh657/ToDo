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

        public bool ValidUser(Guid guid, string password)
        {
            MySqlConnection conn = Createconnection();

            MySqlCommand cmd = new MySqlCommand();

            conn.Open();

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

        public bool UserExists(string username, string email)
        {
            MySqlConnection conn = Createconnection();

            MySqlCommand cmd = new MySqlCommand();

            conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = "select * from Users where username = @username or email = @email;";

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@email", email);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                return false;
            }

            return true;
        }

        public bool ValidPwd(string password, string username, string email)
        {
            MySqlConnection conn = Createconnection();

            MySqlCommand cmd = new MySqlCommand();

            conn.Open();

            SHA hash = new SHA();
            string PWD = hash.sha256encrypt(password, username, email);

            cmd.Connection = conn;
            cmd.CommandText = "select * from Users where username = @username and Password = @pwd;";

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pwd", PWD);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                return true;
            }

            return false;
        }

        public bool SaveToken(string token,string user)
        {
            MYSql sql = new MYSql();
            MySqlConnection conn = sql.Createconnection();
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Token(User,Token) values (@user,@token);";

            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@token", token);
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool ValidToken(string token)
        {
            MySqlConnection conn = Createconnection();

            MySqlCommand cmd = new MySqlCommand();

            conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = "select Token from Token where Token = @token;";

            cmd.Parameters.AddWithValue("@token", token);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                return true;
            }

            return false;
        }

        public string getUserToken(string username)
        {
            MySqlConnection conn = Createconnection();

            MySqlCommand cmd = new MySqlCommand();

            conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = "select Guid from Users where username = @user;";

            cmd.Parameters.AddWithValue("@user", username);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                return dataReader.GetString(0);
            }

            return null;
        }
    }
}