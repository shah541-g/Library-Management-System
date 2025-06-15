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
    public partial class Floor : Form
    {
        public Floor()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0 || numericUpDown2.Value == 0 || numericUpDown3.Value == 0)
            {
                MessageBox.Show("Incomplete Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = new SqlConnection(connecting_Class.connectio_string);

            try
            {
                conn.Open();
                string query = "INSERT INTO Floors (FLOOR_NO, stud_assistant, copiers_no) VALUES (@FLOOR_NO, @stud_assistant, @copiers_no)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FLOOR_NO", numericUpDown2.Value);
                cmd.Parameters.AddWithValue("@stud_assistant", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@copiers_no", numericUpDown3.Value);
                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    MessageBox.Show("New Floor Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }
    }

}
