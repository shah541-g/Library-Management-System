using System;
using System.Collections;
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
    public partial class Books : Form
    {
        private Bitmap originalImage;
        private Bitmap wavingImage;

        public Books()
        {
            InitializeComponent();
            
        }

        private void Books_Load(object sender, EventArgs e)
        {
            
        }
        void insertBook()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;

                // Query to insert data into the Admins table
                string query = "INSERT INTO Book (ISBN_NO, title, edition, publisher, Publication_place, Copy_writeYear, shelf_NO, subject_name,Quantity)" +
                               "VALUES (@isbn_no, @title, @edition, @publisher, @Publication_place, @Copy_writeYear, @shelf_NO, @subject_name, @Quantity)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@isbn_no", textBox1.Text);
                cmd.Parameters.AddWithValue("@title", textBox2.Text);
                cmd.Parameters.AddWithValue("@edition", Convert.ToInt32(numericUpDown1.Value));
                cmd.Parameters.AddWithValue("@publisher", textBox4.Text);
                cmd.Parameters.AddWithValue("@Publication_place", textBox5.Text);
                cmd.Parameters.AddWithValue("@Copy_writeYear", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@shelf_NO", Convert.ToInt32(numericUpDown2.Value));
                cmd.Parameters.AddWithValue("@subject_name", textBox6.Text);
                cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(numericUpDown3.Value));

                conn.Open(); // Open the database connection
                int rowsAffected = cmd.ExecuteNonQuery();

                if(rowsAffected == 0)
                {
                    MessageBox.Show("Fail to ADD BOOK!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    

                    try
                    {


                        // Query to insert data into the Admins table
                        for (int i = 0; i < numericUpDown3.Value; i++)
                        {
                            string BookCopyquery = "INSERT INTO BOOK_COPY (COPY_NO,ISBN_NO)" +
                                           "VALUES (@copy_no,@isbn_no)";
                            SqlCommand command = new SqlCommand(BookCopyquery, conn);
                            command.Parameters.AddWithValue("@isbn_no", textBox1.Text);
                            command.Parameters.AddWithValue("@copy_no", i+1);

                            //conn.Open(); // Open the database connection
                            int rowAffected = command.ExecuteNonQuery();

                            if (rowAffected == 0)
                            {
                                MessageBox.Show("Fail to ADD BOOK COPIES!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                           
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " " || textBox2.Text == "" || textBox2.Text == " " || textBox6.Text == "" || textBox6.Text == " " || textBox4.Text == " " || textBox4.Text == "" || textBox5.Text == "" || textBox5.Text == " " || numericUpDown1.Value == 0 || numericUpDown2.Value == 0)
            {

                MessageBox.Show("Incomplete Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (numericUpDown1.Value <= 20 || textBox4.Text.Contains("@gmail.com") == false)
            //{
            //    MessageBox.Show("Invalid Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            else
            {

               MessageBox.Show("Authors must also be provided","Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
            }
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int floorShelf()
        {
            int floor = 0;

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();


                
                string subjectQuery = "SELECT floor_no FROM Shelf WHERE SHELF_NO=@shelfnum;";

                SqlCommand cmd = new SqlCommand(subjectQuery, conn);
                cmd.Parameters.AddWithValue("@shelfnum", numericUpDown2.Value.ToString());
                //cmd.Parameters.AddWithValue("@journel", 0);

                

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // If there is at least one row, read the first row
                        floor = reader.GetInt32(0);
                    }
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


            return floor;

        }
      
        void insertSubject()
        {

            int floor = floorShelf(); //of that shelf

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();


                // Query to check if the user exists and the password matches
            string subjectQuery = "INSERT INTO Subjects (SUB_NAME, journels_no, floor_no) VALUES (@subname,@journel,@floor);";

                SqlCommand cmd = new SqlCommand(subjectQuery, conn);
                cmd.Parameters.AddWithValue("@subname", textBox6.Text);
                cmd.Parameters.AddWithValue("@journel", 01);
                cmd.Parameters.AddWithValue("@floor", floor);

                int count = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // If there is at least one row, read the first row
                        count = reader.GetInt32(0);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close ();
            }


        }
        private bool findSubject()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();


                // Query to check if the user exists and the password matches
                string query = "SELECT COUNT(*) FROM Subjects WHERE SUB_NAME=@subname";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@subname", textBox6.Text);
                //cmd.Parameters.AddWithValue("@password", textBox2.Text);
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
                conn.Close ();
            }
            return false;
        }
        void JournelNoGet()
        {
            bool flag=findSubject();
            if(flag) { 
                SqlConnection conn = null;

                try
                {
                    conn = new SqlConnection();
                    conn.ConnectionString = connecting_Class.connectio_string;
                    string getQuery = "Select Journels_no From Subjects WHERE SUB_NAME = @subname;";
                    SqlCommand cmd = new SqlCommand(getQuery, conn);
                    cmd.Parameters.AddWithValue("@subname", textBox6.Text);
                    conn.Open();
                    int count = 0;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            count = reader.GetInt32(0);
                        }
                    }
                    count++;
                    string UpdateJournals = "UPDATE Subjects SET journels_no=@count WHERE SUB_NAME = @subname;";
                    SqlCommand command = new SqlCommand(UpdateJournals, conn);
                    command.Parameters.AddWithValue("@subname", textBox6.Text);
                    command.Parameters.AddWithValue("@count", count.ToString());
                    
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
            else
            {
                insertSubject();

            }

        }
        bool checkSubFloor()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();


                // Query to check if the user exists and the password matches
                string query = "SELECT COUNT(*) FROM SHELF AS S JOIN SUBJECTS AS SUB ON S.floor_no=SUB.floor_no AND S.SHELF_NO=@shelf AND SUB.SUB_NAME=@subname;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@shelf", numericUpDown2.Value);
                cmd.Parameters.AddWithValue("@subname", textBox6.Text);
                int count = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // If there is at least one row, read the first row
                        count = reader.GetInt32(0);
                    }
                }

                if (count == 0) { 

                    MessageBox.Show("Invalid reference to shelf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }

            return false;
        }
        bool bookCheck()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();


                // Query to check if the user exists and the password matches
                string query = "SELECT COUNT(*) FROM Book WHERE ISBN_NO=@isbn";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@isbn", textBox1.Text);
               
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
            finally { conn.Close(); }
            return false;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            
            if (checkSubFloor())
            {
                Menu form = new Menu();
                form.Show();
                this.Close();
            }
            else if (bookCheck())
            {
                MessageBox.Show("Book Already present in database");
                this.Close();
            }
            else
            {
                JournelNoGet();
                insertBook();
                Authors authors = new Authors(textBox1.Text);
                authors.Show();
                this.Close();
            }
        }
    }
}  
