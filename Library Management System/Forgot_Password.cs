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
    public partial class Forgot_Password : Form
    {
        public Forgot_Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " ")
            {

                MessageBox.Show("Incomplete Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = null;
            DataTable dataTable = new DataTable();

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();

                string query = "SELECT Password FROM Staff WHERE USER_NAME = @username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Fill the DataTable with the data from the query
                adapter.Fill(dataTable);

                // If there is at least one row, read the first row
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    string password = dataTable.Rows[0]["Password"].ToString();
                    MessageBox.Show("Your Password is: " + password);
                }
                else
                {
                    MessageBox.Show("No data to display.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
