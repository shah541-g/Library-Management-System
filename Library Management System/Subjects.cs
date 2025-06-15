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
    public partial class Subjects : Form
    {
        public Subjects()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void insertSubjects()
        {

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();
                string query = "INSERT INTO Subjects VALUES (@SUB_NAME, @journels_no, @floor_no)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SUB_NAME", textBox1.Text);
                cmd.Parameters.AddWithValue("@journels_no", 0);
                cmd.Parameters.AddWithValue("@floor_no", numericUpDown2.Value);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("Subject Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            insertSubjects();
            Keywords keywords = new Keywords(textBox1.Text);
            keywords.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " " || numericUpDown2.Value == 0)
            {
                MessageBox.Show("Incomplete Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Subjects_Load(object sender, EventArgs e)
        {

        }
    }
}
