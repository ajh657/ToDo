using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoClient
{
    public partial class LoginForm : Form
    {
        Remote remote = new Remote();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = true;
            try
            {
                Task t = remote.Login(textBox1.Text, textBox3.Text, textBox2.Text);
            }
            catch(Exception E)
            {
                MessageBox.Show("Login failed:" + E);
                success = false;
            }
            finally
            {
                if (success) MessageBox.Show("login Completed");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
