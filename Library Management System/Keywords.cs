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
    public partial class Keywords : Form
    {

        private List<TextBox> authorNameTextBoxes;
        private List<TextBox> authorEmailTextBoxes;
        string subname;
        public Keywords()
        {
            InitializeComponent();
            authorNameTextBoxes = new List<TextBox>();
            authorEmailTextBoxes = new List<TextBox>();
        }

        public Keywords(string subname)
        {
            InitializeComponent();
            authorNameTextBoxes = new List<TextBox>();
            authorEmailTextBoxes = new List<TextBox>();
            this.subname=subname;
        }

        private void Keywords_Load(object sender, EventArgs e)
        {

        }
        private void ClearTextBoxesAndLabels()
        {
            foreach (var textBox in authorNameTextBoxes)
            {
                Controls.Remove(textBox);
                textBox.Dispose();
            }
            foreach (var textBox in authorEmailTextBoxes)
            {
                Controls.Remove(textBox);
                textBox.Dispose();
            }
            authorNameTextBoxes.Clear();
            authorEmailTextBoxes.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Top = this.Height - 100;
            button3.Top = this.Height - 100;
            // Clear previous textboxes and labels
            ClearTextBoxesAndLabels();
            int numberOfAuthors = 0;
            // Get the number of authors
            if (int.TryParse(numericUpDown2.Value.ToString(), out numberOfAuthors))
            {
                // Create textboxes and labels for each author
                for (int i = 0; i < numberOfAuthors; i++)
                {
                    // Create labels
                    Label nameLabel = new Label();
                    nameLabel.Text = $"Keyword {i + 1} :";
                    nameLabel.Top = 30 * i + 200;
                    nameLabel.Left = 334;
                    nameLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold | FontStyle.Italic);
                    Controls.Add(nameLabel);

                    // Create textboxes
                    TextBox nameTextBox = new TextBox();
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
                    string InsertQuery = "INSERT INTO KeyWords (Keyword_name,sub_name) VALUES (@Keyword_name,@sub_name);";
                    SqlCommand cmd = new SqlCommand(InsertQuery, conn);
                    cmd.Parameters.AddWithValue("@Keyword_name", athname);
                    cmd.Parameters.AddWithValue("@sub_name", subname);

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


                //MessageBox.Show("Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            MessageBox.Show("Keywords added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Author not added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();

          
        }
    }
}


