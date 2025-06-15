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



namespace Library_Management_System
{
    public partial class All_Data : Form
    {
        public All_Data()
        {
            InitializeComponent();
            DisplayBookData();
        }

        private void DisplayBookData()
        {
            using (SqlConnection conn = new SqlConnection(connecting_Class.connectio_string))
            {
                try
                {
                    conn.Open();
                    string query = "select b.ISBN_NO,b.title,b.subject_name,a.author_name,b.edition,b.Copy_writeYear,b.Publication_place,b.publisher,b.shelf_NO,b.Quantity " +
                        " from Book as b " +
                        " join Authors as a on a.ISBN_NO = b.ISBN_NO ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    DataTable dt = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (SqlException ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connecting_Class.connectio_string))
            {
                try
                {
                    conn.Open();
                    string query = "select b.ISBN_NO,b.title,b.subject_name,a.author_name,b.edition,b.Copy_writeYear,b.Publication_place,b.publisher,b.shelf_NO,b.Quantity " +
                        " from Book as b " +
                        " join Authors as a on a.ISBN_NO = b.ISBN_NO " +
                        " WHERE a.author_name = @author_name ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@author_name", textBox1.Text);
                    DataTable dt = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (SqlException ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
