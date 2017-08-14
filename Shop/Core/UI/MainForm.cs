using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shop.Book.UI;

namespace Shop.Core.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            

        }

        private void AddBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Magazyn " + System.Reflection.Assembly
                        .GetExecutingAssembly()
                        .GetName()
                        .Version;
        }
    }
}
