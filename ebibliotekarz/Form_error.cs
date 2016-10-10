using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ebibliotekarz
{
    public partial class Form_error : Form
    {
        private readonly Form1 ownerForm;

        public Form_error(Form1 form1)
        {
            InitializeComponent();
            ownerForm = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ownerForm.Close(); //to turn off current app
            Process.Start(Application.ExecutablePath); // to start new instance of application
            DialogResult = DialogResult.Abort;
        }

        private void Form_error_Load(object sender, EventArgs e)
        {
            //   this.Location = new Point(330, 330);
        }
    }
}