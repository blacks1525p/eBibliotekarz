using System;
using System.Windows.Forms;

namespace ebibliotekarz
{
    public partial class FormQ : Form
    {
        public FormQ()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormQ_Load(object sender, EventArgs e)
        {
            //      this.Location = new Point(800, 330);
        }
    }
}