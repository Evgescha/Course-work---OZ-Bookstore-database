using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZ_Bookstore_database
{
    public partial class Main : Form
    {
        public static Main main;
        public Main()
        {
            InitializeComponent();
            main = this;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void справочникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Guide().Show();
            this.Hide();
        }

        private void смотретьКнигиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Books().Show();
            this.Hide();
        }
    }
}
