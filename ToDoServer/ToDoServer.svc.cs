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

        public bool InsertData(Guid guid, string Data)
        {
            bool test = false;
            MYSql sql = new MYSql();
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

        public List<string> getNotes(Guid guid)
        {
            MYSql sql = new MYSql();
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

        public bool Register(string Username, string password, string email)
        {
            SHA Hash = new SHA();
            string hashPw = Hash.sha256encrypt(password, Username,email);
            return false;
        }
    }
}