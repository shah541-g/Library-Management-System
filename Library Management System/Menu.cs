using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            string path1 = @"D:\University\Semesters\4th Semester\DBS\AFTER MID\Project\Library Management System\Images\Library.jpg";
            pictureBox1.Image = new System.Drawing.Bitmap(path1);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void AboutTabBtn_MouseHover(object sender, EventArgs e)
        {
            AboutTabBtn.ForeColor = Color.Black;
        }

        private void AboutTabBtn_MouseLeave(object sender, EventArgs e)
        {
            AboutTabBtn.ForeColor = Color.White;
        }

        private void SettingTabBtn_MouseHover(object sender, EventArgs e)
        {
            SettingTabBtn.ForeColor = Color.Black;
        }

        private void SettingTabBtn_MouseLeave(object sender, EventArgs e)
        {
            SettingTabBtn.ForeColor = Color.White;
        }

        private void TransactionTabBtn_MouseHover(object sender, EventArgs e)
        {
            TransactionTabBtn.ForeColor = Color.Black;
        }

        private void TransactionTabBtn_MouseLeave(object sender, EventArgs e)
        {
            TransactionTabBtn.ForeColor= Color.White;
        }

        private void BorrowersTabBtn_MouseLeave(object sender, EventArgs e)
        {
            BorrowersTabBtn.ForeColor = Color.White;
        }

       

        private void BooksTabBtn_MouseHover(object sender, EventArgs e)
        {
            BooksTabBtn.ForeColor=Color.Black;

        }

        

        private void BooksTabBtn_MouseLeave(object sender, EventArgs e)
        {

            BooksTabBtn.ForeColor = Color.White;
        }

        private void BorrowersTabBtn_MouseHover(object sender, EventArgs e)
        {
            BorrowersTabBtn.ForeColor = Color.Black;
        }

        private void BorrowersTabBtn_Click(object sender, EventArgs e)
        {
            Register_Students_Faculty register_Students_Faculty = new Register_Students_Faculty();
            register_Students_Faculty.Show();
        }

       
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor= Color.Black;
        }

        private void BooksTabBtn_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void TransactionTabBtn_Click(object sender, EventArgs e)
        {
            Subjects subjects = new Subjects();
            subjects.Show();
        }

        private void SettingTabBtn_Click(object sender, EventArgs e)
        {
            Floor floor = new Floor();
            floor.Show();
        }

        private void AboutTabBtn_Click(object sender, EventArgs e)
        {
            Shelf shelf = new Shelf();
            shelf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Issue_Book issue_Book = new Issue_Book();
            issue_Book.Show();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor= Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Extend_Date extend = new Extend_Date();
            extend.Show();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ForeColor= Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.ForeColor= Color.Black;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Check_Penalty check_Penalty = new Check_Penalty();
            check_Penalty.Show();
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.ForeColor= Color.Black;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor= Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reserved reserved = new Reserved();
            reserved.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
