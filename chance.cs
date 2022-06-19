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
    public partial class chance : Form
    {
        public chance(string v, int v1)
        {
            InitializeComponent();
        }

        private void chance_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "update otel set id ='" + textBox1.Text + "',name ='" + textBox2.Text + "',adress = '" + textBox3.Text + "'' where otel =" + ";";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 600;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
                Form1 Win = new Form1();
                Win.Show();
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
