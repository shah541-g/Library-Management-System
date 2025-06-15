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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Library_Management_System
{
    public partial class Extend_Date : Form
    {
        public Extend_Date()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (textBox1.Text==" ")
            {
               MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SqlConnection conn = new SqlConnection(connecting_Class.connectio_string);

            try
            {
                conn.Open();
                string query = "SELECT i.*,b.title " +
                                "FROM Issues as i " +
                                "join Book as b on b.ISBN_NO =i.ISBN_no " +
                                "WHERE i.username = @username";
                                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (textBox6.Text == " ")
            {
                MessageBox.Show("Please enter ISBN number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SqlConnection conn = new SqlConnection(connecting_Class.connectio_string);

            try
            {
                conn.Open();
                string query = "SELECT isu.*, b.title AS book_title " +
                                "FROM Issues AS isu " +
                                "JOIN Book AS b ON b.ISBN_NO = isu.ISBN_NO " +
                                "WHERE isu.username = @username AND isu.ISBN_NO = @ISBN_NO";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@ISBN_NO", textBox6.Text); 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlConnection conn = new SqlConnection(connecting_Class.connectio_string);
            try
            {
                conn.Open();
                string query = "UPDATE Issues " +
                               "SET extension_date = @extended_date " +
                               "WHERE ISBN_NO = @ISBN_NO";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@extended_date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ISBN_NO", textBox6.Text);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt2);
                    dataGridView1.DataSource = dt2;
                    MessageBox.Show("Extension date updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No records updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
    }
}

