using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoClient
{
    class Remote
    {
        Server.ToDoServerClient Server = new Server.ToDoServerClient();
        public Task Register(string username, string email, string password)
        {
            
            if (Server.Register(username, password, email))
            {
                System.Windows.Forms.MessageBox.Show("Register Completed");
                return null;
            }
            System.Windows.Forms.MessageBox.Show("Register failed");
            return null;
        }

        public Task Login(string username, string password,string email)
        {
            string[] vs = Server.Login(username, password, email).Split(' ');
            Properties.Settings.Default.UserGuid = Guid.Parse(vs[0]);
            Properties.Settings.Default.UserToken = Guid.Parse(vs[1]);
            return null;
        }

        public List<string> GetNotes()
        {
            return Server.getNotes(Properties.Settings.Default.UserToken, Properties.Settings.Default.UserGuid.ToString());
        }

        public void Insert(string data)
        {
            Server.InsertNote(Properties.Settings.Default.UserGuid,Properties.Settings.Default.UserToken.ToString(), data, null);
        }
    }
}