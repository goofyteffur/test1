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
    public partial class auto : Form
    {
        public auto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string mod = "";
                string id = "";
                string query = "select id, rol from user where login ='" + textBox1.Text + "' and pass = '" + textBox2.Text + "';";//Запрос на выход по данным из textbox1/2
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                cmDB.CommandTimeout = 60;
                try
                {
                    conn.Open();
                    MySqlDataReader rd = cmDB.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            id = rd.GetString(0);
                            mod = rd.GetString(1);
                        }
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка авторизации. Попробуйте еще раз.");
                    MessageBox.Show(ex.Message);
                }
                if (Convert.ToInt32(id) > 0)
                {
                    if (mod == "1")
                    {
                        Form1 Win = new Form1();
                        Win.Show();
                        this.Hide();

                    }
                    else if (mod == "2")
                    {
                        add Win = new add("add",0); ;
                        Win.Show();
                        this.Hide();

                    }
                }
            }
            }
        }
}
