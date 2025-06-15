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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Management_System
{
    public partial class Check_Penalty : Form
    {
        public Check_Penalty()
        {
            InitializeComponent();
            CheckPanelty();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            debarred Debarred = new debarred();
            Debarred.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void CheckPanelty()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();


                // Query to check if the user exists and the password matches
                string query = "SELECT username,copy_no, ISBN_NO ,date_of_issue, return_date FROM Issues;";

                SqlCommand cmd = new SqlCommand(query, conn);

                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                // Add a new column for fine calculation
                dt.Columns.Add("Fine", typeof(decimal));

                // Calculate fine for each row
                foreach (DataRow row in dt.Rows)
                {
                    DateTime returnDate = Convert.ToDateTime(row["return_date"]);
                    DateTime currentDate = DateTime.Today;

                    // Calculate the difference in days between today's date and the return date
                    TimeSpan difference = currentDate - returnDate;
                    int daysDifference = (int)difference.TotalDays;

                    // Calculate fine by multiplying days difference with a constant value (e.g., 50)
                    decimal fine = daysDifference * 50;

                    // Ensure the fine is not negative
                    if (fine < 0)
                    {
                        fine = 0;
                    }

                    // Set the fine value in the new column
                    row["Fine"] = fine;
                }

                dataGridView1.DataSource = dt;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
