using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ebibliotekarz
{
    public partial class FormDown : Form
    {
        private Point cursloc = new Point(0, 0);
        private Point formloc;
        private Form1 ownerForm;

        public FormDown(Form1 form1)
        {
            InitializeComponent();
            ownerForm = form1;
            BackColor = Color.FromArgb(54, 52, 52);
            listView1.Columns.Add("URL");
            listView1.Columns.Add("stan");
        }

        public string MyProperty { get; set; }

        public void set_list_view(List<string> items)
        {
            int k = 0;
            foreach (string i in items)
            {
                var item = new ListViewItem(i);
                item.SubItems.Add("Oczekuje");
                listView1.Items.AddRange(new[] {item});
                k++;
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public void updatelist(int[] table, int[] table2, int[] table3)
        {
            int k = 0;

            for (int i = 0; i < table.Count(); i++)
            {
                listView1.Items[i].SubItems[1].Text = zmiana(table[i]);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                k++;
            }
            for (int i = 0; i < table2.Count(); i++)
            {
                listView1.Items[k].SubItems[1].Text = zmiana(table2[i]);
                k++;
            }
            for (int i = 0; i < table3.Count(); i++)
            {
                listView1.Items[k].SubItems[1].Text = zmiana(table3[i]);
                k++;
            }
        }

        private string zmiana(int p)
        {
            if (p == -1)
            {
                return "Niepowodzenie";
            }
            if (p == 0)
                return "Oczekuje";
            if (p == 1)
                return "Pobrano";
            return null;
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

        private void setpositions()
        {
            formloc = Location;
            cursloc = Cursor.Position;
        }

        private string get_folder(string folder)
        {
            return folder;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(MyProperty);
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            //     if (this.ownerForm.backgroundWorker4.IsBusy)
            //     {
            //         this.ownerForm.backgroundWorker4.CancelAsync();
            //    }
            //   if(this.ownerForm.backgroundWorker4.IsBusy)              
            DialogResult = DialogResult.Abort;
            clear();
            Close();
        }

        public void clear()
        {
            listView1.Clear();
        }
    }
}