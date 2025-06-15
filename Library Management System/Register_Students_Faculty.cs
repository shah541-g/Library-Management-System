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
    public partial class Register_Students_Faculty : Form
    {
        public Register_Students_Faculty()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " " || textBox2.Text == "" || textBox2.Text == " " || textBox3.Text == "" || textBox3.Text == " " || textBox4.Text == "" || textBox4.Text == " " || textBox5.Text == "" || textBox5.Text == " " || textBox6.Text == "" || textBox6.Text == " " || (!radioButton1.Checked && !radioButton2.Checked))
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

                string query = "INSERT INTO [Student Faculty] VALUES (@USER_NAME, @password, @name, @DOB, @gender, @email, @address, @dept, @panelty, @isDebarred, @isFaculity)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@USER_NAME", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.Parameters.AddWithValue("@name", textBox3.Text);
                cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@gender", radioButton1.Checked ? 'M' : 'F');
                cmd.Parameters.AddWithValue("@email", textBox4.Text);
                cmd.Parameters.AddWithValue("@address", textBox5.Text);
                cmd.Parameters.AddWithValue("@dept", textBox6.Text);
                cmd.Parameters.AddWithValue("@panelty", 0);
                cmd.Parameters.AddWithValue("@isDebarred", 0);
                cmd.Parameters.AddWithValue("@isFaculity", checkBox1.Checked ? 1 : 0);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                    MessageBox.Show("Registered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("Registration Fails!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
