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
    public partial class MainForm : System.Windows.Forms.Form
    {
        List<string> FromServer;
        List<string> notes;
        RegisterForm Register = new RegisterForm();
        LoginForm Login = new LoginForm();
        Remote remote = new Remote();
        public MainForm()
        {
            InitializeComponent();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register.ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.ShowDialog();
            initNotes();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void initNotes()
        {
            FromServer = remote.GetNotes();
            comboBox1.Items.Clear();

            for (int i = 0; i < FromServer.Count; i++)
            {
                if (FromServer[i].Length < 6)
                {
                    comboBox1.Items.Add(FromServer[i]);
                }
                else
                {
                    comboBox1.Items.Add(FromServer[i].Substring(0,6));
                }
            }

            notes = FromServer;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("<New Note>");
            comboBox1.SelectedIndex = comboBox1.Items.Count -1;
            richTextBox1.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == comboBox1.Items.Count -1)
            {
                remote.Insert(richTextBox1.Text);
                initNotes();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception E)
            {

                richTextBox1.Text = E.ToString();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initNotes();
        }
    }
}
