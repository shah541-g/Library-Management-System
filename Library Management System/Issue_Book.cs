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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Library_Management_System
{
    public partial class Issue_Book : Form
    {
        public Issue_Book()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool checkonHold()
        {

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();


                // Query to check if the user exists and the password matches
                string query = "SELECT COUNT(*) FROM BOOK_COPY WHERE COPY_NO=@copyno AND ISBN_NO=@isbn AND onHold=@onhold;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@copyno", textBox2.Text);
                cmd.Parameters.AddWithValue("@isbn", textBox1.Text);
                cmd.Parameters.AddWithValue("@onhold", 0);
                int count = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // If there is at least one row, read the first row
                        count = reader.GetInt32(0);
                    }
                }

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
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
            return false;
        }

        void markonhold()
        {
            SqlConnection conn = null;
            try
            {
            conn = new SqlConnection();
            conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();
                string UpdateJournals = "UPDATE BOOK_COPY SET onHold=@onhold WHERE COPY_NO = @copyno AND ISBN_NO=@isbnno;";
                SqlCommand command = new SqlCommand(UpdateJournals, conn);
                command.Parameters.AddWithValue("@copyno", textBox2.Text);
                command.Parameters.AddWithValue("@isbnno", textBox1.Text);
                command.Parameters.AddWithValue("@onhold", 1);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    MessageBox.Show("No records updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " "|| textBox2.Text == " "|| textBox6.Text == " ")
            {
                MessageBox.Show("Incomplete Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!checkonHold())
                {
                    MessageBox.Show("Wrong Information about Copy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    SqlConnection conn = new SqlConnection(connecting_Class.connectio_string);
                    try
                    {
                        conn.Open();
                        string checkQuery = "SELECT extension_count FROM Issues WHERE username = @username AND ISBN_NO = @isbn";
                        SqlCommand cmd = new SqlCommand(checkQuery, conn);
                        cmd.Parameters.AddWithValue("@username", textBox6.Text);
                        cmd.Parameters.AddWithValue("@isbn", textBox1.Text);
                        int rowAffected = cmd.ExecuteNonQuery();
                        if (rowAffected <= 3)
                        {

                            string insertQuery = "INSERT INTO Issues (username, copy_no, date_of_issue, extension_date, return_date, extension_count, ISBN_NO) " +
                                                 "VALUES (@username, @copyNo, @date_of_issue, @extension_date, @return_date, @extension_count, @isbn)";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@username", textBox6.Text);
                            insertCmd.Parameters.AddWithValue("@copyNo", textBox2.Text);
                            insertCmd.Parameters.AddWithValue("@date_of_issue", dateTimePicker1.Value);
                            insertCmd.Parameters.AddWithValue("@extension_date", DBNull.Value);
                            insertCmd.Parameters.AddWithValue("@return_date", dateTimePicker2.Value);
                            insertCmd.Parameters.AddWithValue("@extension_count", 0);
                            insertCmd.Parameters.AddWithValue("@isbn", textBox1.Text);
                            insertCmd.ExecuteNonQuery();
                            markonhold();
                            MessageBox.Show("Book issued successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("You have reached the maximum number of extensions for this book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text==" ")
            {
                MessageBox.Show("Incomplete Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string keyword = textBox3.Text;

            SqlConnection conn = new SqlConnection(connecting_Class.connectio_string);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string query = "SELECT " +
                    "b.title, " +
                    "b.subject_name, " +
                    "b.edition, " +
                    "b.ISBN_NO, " +
                    "b.shelf_NO, " +
                    "BOC.COPY_NO " +
                    "FROM Book AS b " +
                    "JOIN KeyWords AS k ON k.SUB_NAME = b.subject_name " +
                    "JOIN BOOK_COPY AS BOC ON BOC.ISBN_NO = b.ISBN_NO AND BOC.onHold = @reserve " +
                    "WHERE k.keyword_name LIKE '%" + keyword + "%'";

                //MessageBox.Show("Ma aaaaa gaya");


                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@reserve", 0);
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

            //this.Close();
        }
    }
}
