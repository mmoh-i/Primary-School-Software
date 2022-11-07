using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Primary_School_Software
{
    public partial class Form3 : Form
    {
        string Path = "test.db";
        string connectsql = @"URI = file:" + Application.StartupPath + "\\test.db";
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public Form3()
        {
            InitializeComponent();
        }
        //show data in table
        private void data_show()
        {
            var con = new SQLiteConnection(connectsql);
            con.Open();

            var cmd = new SQLiteCommand("SELECT * FROM student_biod", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Insert(0, dr.GetString(0), dr.GetString(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4));
            }
            
        }
        private void create_db()
        {
            if(!File.Exists(Path))
            {
                SQLiteConnection.CreateFile(Path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + Path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE student_biod ( SurName  TEXT, FirstName TEXT, AddmissionNo  NUMERIC NOT NULL, Class  INTEGER, Date OF Birth  TEXT, PRIMARY KEY(AddmissionNo)";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("DataBase cannot create");
                return;
            }
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //Create button
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    var con = new SQLiteConnection(connectsql);
                    con.Open();
                    var cmd = new SQLiteCommand(con);
                    
                    cmd.CommandText = "INSERT INTO student_biod(SurName, FirstName, AddmissionNo, Class, DateOfBirth) VALUES (@SurName, @FirstName, @AddmissionNo, @Class, @DateOfBirth)";
                    string FirstName = textBox1.Text;
                    string SurName = textBox2.Text;
                    string Addmission = textBox3.Text;
                    string Class = textBox4.Text;
                    string Date = dateTimePicker1.Text;

                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@SurName", SurName);
                    cmd.Parameters.AddWithValue("@AddmissionNo", Addmission);
                    cmd.Parameters.AddWithValue("@Class", Class);
                    cmd.Parameters.AddWithValue("@DateOfBirth", Date);

                    /*taGridView1.ColumnCount = 5;
                    dataGridView1.Columns[0].*/
                    string[] row = new string[] { FirstName, SurName, Addmission, Class, Date };
                    dataGridView1.Rows.Add(row);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Cannot insert data");
                    return;
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            create_db();
            data_show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(connectsql);
            con.Open();
            var cmd = new SQLiteCommand(con);
            cmd.CommandText = "update student_biod set Class=@class, SurName=@SurName, FirstName=@FirstName, DateOfBirth=@DateOfBirth where AddmissionNo=@AddmissionNo";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@SurName", textBox1.Text);
            cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Class", textBox4.Text);
            cmd.Parameters.AddWithValue("@AddmissionNo", textBox3.Text);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);

            cmd.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            data_show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            BIODATAFORM  f2 = new BIODATAFORM();
            f2.Show();
        }
    }
}
