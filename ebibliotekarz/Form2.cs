using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ebibliotekarz
{
    public partial class FormHistory : Form
    {
        private readonly Form1 ownerForm;
        private DateTime _lastKeyPress;
        private string _searchString;
        private Point cursloc = new Point(0, 0);
        private FileInfo[] files;
        private Point formloc;

        public FormHistory(Form1 ownerForm)
        {
            InitializeComponent();
            PopulateList();
            this.ownerForm = ownerForm;
            //   listBox1.Font = new Font("Arial", 20);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if ()
            //  {

            //  }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateTime newDate = DateTime.Now;
            TimeSpan diff = newDate - _lastKeyPress;

            if (diff.TotalSeconds >= 0.20)
                _searchString = string.Empty;
            _searchString += e.KeyChar;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString();
                if (item.ToLower().StartsWith(_searchString))
                {
                    listBox1.SelectedItem = item;
                    break;
                }
            }
            _lastKeyPress = newDate;
            e.Handled = true; //REALLY IMPORTANT TO HAVE THIS
        }

        //    private DirectoryInfo di;
        private void PopulateList()

        {
            string line;
            /*string strFolder = ".\\historia\\";
            di = new DirectoryInfo(strFolder);
            FileInfo[] files=di.GetFiles("*.bib");
            
            //files = di.GetFiles(); 
            string line;
            foreach (FileInfo file in files)
            {
               
                listBox1.Items.Add(file.Name);
             }*/


            var file = new StreamReader("autoComplete.acs");
            while ((line = file.ReadLine()) != null)
            {
                if (!listBox1.Items.Contains(line))
                {
                    listBox1.Items.Add(line);
                }
            }

            file.Close();
        }

        private void setpositions()
        {
            formloc = Location;
            cursloc = Cursor.Position;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            setpositions();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int exe = formloc.X - cursloc.X + Cursor.Position.X;
            int eye = formloc.Y - cursloc.Y + Cursor.Position.Y;
            Location = new Point(exe, eye);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Musisz wybrać wyrażenie!");
            }
            else
            {
                //   List<string> data = new List<string>();
                //  data = File.OpenFile(null,".\\historia\\"+listBox1.SelectedItem.ToString());
                //   if (File.Sprawdzenie(data) == true)

                // StructBibliotekarz StrBibliotekarz = new StructBibliotekarz();
                //   StrBibliotekarz.Dodawanie(data);
                ownerForm.PassValue(listBox1.SelectedItem.ToString());
                    //.Remove(listBox1.SelectedItem.ToString().Length - 4));
                DialogResult = DialogResult.OK;
                Close();

                //   DGV_populate(StrBibliotekarz);
                // }

                //  {
                //        MessageBox.Show("Plik niepoprawny");
                //   }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            //   this.Location = new Point(330, 330);
        }

        private void FormHistory_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                buttonAccept.PerformClick();
            }
        }
    }
}