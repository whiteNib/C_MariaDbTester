using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MariaDbTester
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection(string.Format("Server={0};Database={1};Uid ={2};Pwd={3};",
"127.0.0.1", "testdb", "root", "123456"));

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (textBox1.Text == "")
            {
                string selectQuery = "SELECT * from testdb";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                while(table.Read()) 
                {
                    dataGridView1.Rows.Add(table["analyzer_tag"], table["house_tag"], table["measure_type"]);
                }
                connection.Close();
            }
            else
            {
                string selectQuery = "SELECT * from testdb where analyzer_tag" + textBox1.Text + "";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                ArrayList Test = new ArrayList();
                while(table.Read()) 
                {
                    Test.Add(table["analyzer_tag"]);
                    dataGridView1.Rows.Add(table["analyzer_tag"], table["house_tag"], table["measure_type"]);
                }

                textBox2.Text = Test[1].ToString();
                connection.Close();
            }
        }
    }
}
