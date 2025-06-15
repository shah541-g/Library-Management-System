using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




using System.Data.SqlClient;


namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string path1 = @"D:\University\Semesters\4th semester\DBS\AFTER MID\Project\Library Management System\Images\Home page.jpg";
            pictureBox1.Image = new System.Drawing.Bitmap(path1);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sign_Up sign_Up = new Sign_Up();
            sign_Up.Show();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgot_Password forgot_Password = new Forgot_Password();
            forgot_Password.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " " || textBox2.Text == "" || textBox2.Text == " ")
            {

                MessageBox.Show("Incomplete Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();


                // Query to check if the user exists and the password matches
                string query = "SELECT COUNT(*) FROM Staff WHERE USER_NAME = @username AND password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
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
                    MessageBox.Show("Authentication successful!", "Success");
                    Menu form = new Menu();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Authentication failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
