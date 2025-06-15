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
    public partial class Sign_Up : Form
    {
        public Sign_Up()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " " || textBox2.Text == "" || textBox2.Text == " " || textBox3.Text == "" || textBox3.Text == " " || textBox4.Text == " " || textBox4.Text == "" || textBox5.Text == "" || textBox5.Text == " ")
            {

                MessageBox.Show("Incomplete Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox4.Text.Contains("@gmail.com") == false)
            {
                MessageBox.Show("Invalid Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                SqlConnection conn = null;

                try
                {
                    conn = new SqlConnection();
                    conn.ConnectionString = connecting_Class.connectio_string;

                    // Query to insert data into the Admins table
                    string query = "INSERT INTO Staff (USER_NAME, password, name, phone, email) " +
                                   "VALUES (@username, @password, @name, @contact, @email)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);
                    cmd.Parameters.AddWithValue("@name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@contact", textBox5.Text);
                    cmd.Parameters.AddWithValue("@email", textBox4.Text);

                    conn.Open(); // Open the database connection
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        MessageBox.Show("Signed Up successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Fail to Sign Up!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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


                this.Close();
            }
        }
      
    }
}
