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
    public partial class Reserved : Form
    {
        public Reserved()
        {
            InitializeComponent();
            DataLoad();
        }
        void DataLoad()
        {
            SqlConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connecting_Class.connectio_string;
                conn.Open();


                // Query to check if the user exists and the password matches
                string query = "SELECT Boc.*, b.title,i.username " +
                    "FROM BOOK_COPY AS Boc " +
                    "JOIN Book AS b ON b.ISBN_NO = Boc.ISBN_NO " +
                    "JOIN Issues AS i ON i.ISBN_NO = b.ISBN_NO " +
                    "WHERE onHold = @onhold ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@onhold", 1);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
                
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 


