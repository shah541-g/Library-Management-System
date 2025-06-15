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
    public partial class debarred : Form
    {
        public debarred()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User Debarred successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.None);
            this.Close();
        }
    }
}
