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
    public partial class Shelf : Form
    {
        public Shelf()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                string query = "INSERT INTO Shelf VALUES (@SHELF_NO, @aisle_no, @floor_no)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SHELF_NO", numericUpDown2.Value);
                cmd.Parameters.AddWithValue("@aisle_no", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@floor_no", numericUpDown3.Value);
                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    MessageBox.Show("New Shelf Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
