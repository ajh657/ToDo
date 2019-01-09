using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace ToDoServer
{
    public class ToDoServer : IToDoServer
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
         }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool InsertNote(Guid guid,string token, string Data,string Title)
        {
            MYSql sql = new MYSql();
            if (!sql.ValidToken(token)) return false;
            bool test = false;
            
            MySqlConnection conn = sql.Createconnection();
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into Data(Guid, Data,Date) VALUES (@Guid,@Data,@Time);";

                cmd.Parameters.AddWithValue("@guid", guid.ToString());
                cmd.Parameters.AddWithValue("@Data", Data);
                cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                test = false;
            }
            finally
            {
                conn.Close();
            }
            return test;
        }

        public List<string> getNotes(Guid guid,string token)
        {
            MYSql sql = new MYSql();
            if (!sql.ValidToken(token)) return null;
            MySqlConnection conn = sql.Createconnection();

            conn.Open();

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "select Data from Data where Guid = @Guid;";

            cmd.Parameters.AddWithValue("@Guid", guid.ToString());

            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<string> vs = new List<string>();

            while (dataReader.Read()) vs.Add(dataReader["Data"].ToString());

            return vs;
        }

        public bool Register(string username, string password, string email)
        {
            MYSql sql = new MYSql();
            if (!sql.UserExists(username, email)) return false;
            SHA Hash = new SHA();
            string hashPw = Hash.sha256encrypt(password, username,email);

            MySqlConnection conn = sql.Createconnection();

            conn.Open();

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;

            cmd.CommandText = "insert into Users (guid,username,email,password) values (@guid, @user, @email, @pwd);";

            cmd.Parameters.AddWithValue("@guid", Guid.NewGuid().ToString());
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwd", hashPw);

            cmd.ExecuteNonQuery();

            return true;
        }

        public string Login(string username, string password, string email)
        {
            MYSql sql = new MYSql();
            if (sql.UserExists(username, email)) return null;
            if (!sql.ValidPwd(password,username,email)) return null;
            Guid Token = Guid.NewGuid();

            sql.SaveToken(Token.ToString(),username);

            return Token.ToString() + " " + sql.getUserToken(username);
        }
    }
}