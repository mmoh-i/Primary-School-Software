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


namespace Primary_School_Software
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        static void create()
        {
            if (!System.IO.File.Exists("test.db"))
            {
                string db = "test.db";
                string connectsql = @"URI = file:" + Application.StartupPath + "\\test.db";
                SQLiteConnection connection = new SQLiteConnection(connectsql);
                connection.Open();
                string query = "CREATE TABLE Registration ( SurName  TEXT,FirstName TEXT, PromotedClass INTEGER NOT NULL,Term  INTEGER, Age  INTEGER, AddmissionNo  INTEGER NOT NULL);";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            else
            {
                Console.WriteLine("Database Created!");
            }
        }
        static void addRow()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text =="" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Missing text field must be filled");
            }
            else
            {
                create();

            }
        }
        
        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            BIODATAFORM f2= new BIODATAFORM();
            f2.Show();
            
        }
    }
}
