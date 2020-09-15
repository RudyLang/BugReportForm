using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BugReporterForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString;
            MySqlConnection conn;

            connectionString = "server=127.0.0.1;port=3306;uid=Rudy;pwd=manonmyshoulder;database=bugs";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                MessageBox.Show("Connected!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString;
            MySqlConnection conn;

            connectionString = "server=127.0.0.1;port=3306;uid=Rudy;pwd=manonmyshoulder;database=bugs";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();

                // Grab Error Type
                string errorType = "VertexShader";

                // Grab comments
                string comments = "";
                comments = textBox1.Text;

                // Grab date, hour, and minute
                DateTime date = DateTime.Today;
                int hour = DateTime.Now.Hour;
                int minute = DateTime.Now.Minute;

                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO reports(type, comment, date, hour, minute) VALUES(?type, ?comment, ?date, ?hour, ?minute)";
                comm.Parameters.Add("?type", MySqlDbType.VarChar).Value = errorType;
                comm.Parameters.Add("?comment", MySqlDbType.VarChar).Value = comments;
                comm.Parameters.Add("?date", MySqlDbType.Date).Value = date;
                comm.Parameters.Add("?hour", MySqlDbType.Int16).Value = hour;
                comm.Parameters.Add("?minute", MySqlDbType.Int16).Value = minute;
                comm.ExecuteNonQuery();

                DialogResult dialog = MessageBox.Show("The error has been reported, thank you!");
                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
