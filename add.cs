using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ex
{
    public partial class add : Form
    {
        public add(string v, int v1)
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into otel values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "');"; //Добавление данных через insert
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 Win = new Form1();
            this.Hide();
        }
    }
}
