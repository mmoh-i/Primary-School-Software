using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace Primary_School_Software
{
    public partial class LOGINFORM : Form
    {
        public LOGINFORM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = Txtbusername.Text;
            string pass = txtbpassword.Text;
            
            if(user == "admin" && pass =="1234")
            {
                BIODATAFORM f = new BIODATAFORM();
                f.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Usernmae or password incorrect");
            }

        }

        private void linlblforgotpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Contact Principal or IT Admin");
        }

        private void Txtbusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
