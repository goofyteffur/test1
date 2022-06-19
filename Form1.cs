using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            get_Info(listView1); //вызов при включении 
        }

        void get_Info(ListView List)
        {
            string query = "select*from otel"; //вывод данных
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
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3) }; //Столбцы из ListView
                        var listItem = new ListViewItem(row);
                        listView1.Items.Add(listItem);
                    }
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            get_Info(listView1); //очищение и вызов на кнопку обновить 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "delete from otel where id = " + listView1.Items[listView1.SelectedIndices[0]].Text + ";"; //Удаление данных в ListView по id
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            listView1.Items.Clear();
            get_Info(listView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add Win = new add("add", 0); //Переход на форму добавления 
            Win.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {   
            chance Win = new chance ("chance", 0); //Переход на форму добавления 
            Win.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string query = "select * from otell.otel where concat(id, name, adress) like '%" + textBox1.Text + "%'"; //условие like позволяет искать по всем столбцам.
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
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2) };
                        var listItem = new ListViewItem(row);
                        listView1.Items.Add(listItem);
                    }
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
