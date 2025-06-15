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
    public partial class Authors : Form
    {
        private List<System.Windows.Forms.TextBox> authorNameTextBoxes;
        int numberOfAuthors = 0;
        string ISBN;
        public Authors()
        {

            InitializeComponent();
            authorNameTextBoxes = new List<System.Windows.Forms.TextBox>();

        }

        public Authors(string ISBN)
        {

            InitializeComponent();
            authorNameTextBoxes = new List<System.Windows.Forms.TextBox>();
            this.ISBN = ISBN;

        }

        //private void createFieldsButton_Click(object sender, EventArgs e)
        //{

        //}

        private void ClearTextBoxesAndLabels()
        {
            foreach (var textBox in authorNameTextBoxes)
            {
                Controls.Remove(textBox);
                textBox.Dispose();
            }

            authorNameTextBoxes.Clear();

        }
        private void Authors_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Top = this.Height - 100;
            button3.Top = this.Height - 100;
            // Clear previous textboxes and labels
            ClearTextBoxesAndLabels();
            // Get the number of authors
            if (int.TryParse(numericUpDown2.Value.ToString(), out numberOfAuthors))
            {
                // Create textboxes and labels for each author
                for (int i = 0; i < numberOfAuthors; i++)
                {
                    // Create labels
                    Label nameLabel = new Label();
                    nameLabel.Text = $"Author {i + 1} Name:";
                    nameLabel.Top = 30 * i + 200;
                    nameLabel.Left = 334;
                    nameLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold | FontStyle.Italic);
                    Controls.Add(nameLabel);

                    // Create textboxes
                    System.Windows.Forms.TextBox nameTextBox = new System.Windows.Forms.TextBox();
                     
                    nameTextBox.Top = 30 * i + 200;
                    nameTextBox.Left = 420;
                    nameTextBox.Size = new System.Drawing.Size(226, 26);
                    Controls.Add(nameTextBox);
                    authorNameTextBoxes.Add(nameTextBox);

                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number of authors.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {



            SqlConnection conn = new SqlConnection(connecting_Class.connectio_string);

            int rowAffected = 0;

            foreach (System.Windows.Forms.TextBox textboxe in authorNameTextBoxes)
            {

                string athname = textboxe.Text;
                try
                {
                    conn.Open();
                    string insertToBook = "";
                    string InsertQuery = "INSERT INTO Authors (author_name,ISBN_NO) VALUES (@athname,@isbn);";
                    SqlCommand cmd = new SqlCommand(InsertQuery, conn);
                    cmd.Parameters.AddWithValue("@athname", athname);
                    cmd.Parameters.AddWithValue("@isbn", ISBN.ToString());

                    //rowAffected = cmd.ExecuteNonQuery();
                    rowAffected += cmd.ExecuteNonQuery(); 

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { conn.Close(); }
            }
            if (rowAffected > 0)
            {


                 MessageBox.Show("Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Author not added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }
    
    }
}
