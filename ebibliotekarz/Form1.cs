using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ebibliotekarz.Properties;

namespace ebibliotekarz
{
    public partial class Form1 : Form
    {
        //      private const int WS_CLIPCHILDREN = 0x2000000;
        //     private const int WS_MINIMIZEBOX = 0x20000;
        //    private const int WS_MAXIMIZEBOX = 0x10000;
        private const int WS_SYSMENU = 0x80000;
        private const int CS_DBLCLKS = 0x8;
        private static BazyTh testbBazyTh;
        private readonly List<int> abstrakty = new List<int>();
        private readonly List<int> abstraktyiee = new List<int>();
        private readonly List<int> abstraktyscience = new List<int>();
        private readonly List<int> abstraktyspringer = new List<int>();

        private readonly AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
        private readonly CheckBox[] bazyBoxs;
        private readonly OrderedDictionary data = new OrderedDictionary();
        private readonly DateTimePicker dtpf = new DateTimePicker();
        private readonly DateTimePicker dtpt = new DateTimePicker();
        private readonly FormCollection forms = Application.OpenForms;


        private readonly DataGridView grid = new DataGridView();
        private readonly DataGridView gridieee = new DataGridView();
        private readonly DataGridView gridscienceDirect = new DataGridView();
        private readonly DataGridView gridscopus = new DataGridView();
        private readonly DataGridView gridspringer = new DataGridView();
        private readonly DataGridView gridwebofscience = new DataGridView();
        private readonly OpenFileDialog openFileDialog1;
        private readonly TabControl tabControl;
        private readonly Label wyniki = new Label();


        private bool am;
        private ContextMenuStrip b = new ContextMenuStrip();
        private BazyTh bazyth;
        private int col = -1;
        private bool complete;
        private long counter;
        private Point cursloc = new Point(0, 0);
        private long fcount;
        private string folderName;
        private FormDown formD;
        private Point formloc;
        private string history;
        private int licznikpdf;
        private List<string> linkIEEE;
        private List<string> linkscience;
        private List<string> linkspringer;
        private Point location;
        private MouseButtons mes;
        private IEEE objeiee;
        private OrderedDictionary pdf;
        private OrderedDictionary pdfname;
        private PDFParser pdfparser;
        private int row = -1;
        private string search;
        private string test;
        private List<string> titleIEEE;
        private List<string> titlescience;
        private List<string> titlespringer;
        private int x;
        private int xback;
        private int xdown;
        private int xhold;
        private int xlabeltemp;
        private int xlabiee;
        private int xlabiee2;
        private int xlabsd;
        private int xlabsd2;
        private int xlabsr;
        private int xlabsr2;
        private int xlabss;
        private int xlabss2;
        private int xlabwos;
        private int xlabwos2;
        private int xline;
        private int xold;
        private int xprogress;
        private int xprogressdownload;
        private int xsave;
        private int y;
        private int yback;
        private int ydown;
        private int yhold;
        private int ylabeltemp;
        private int ylabiee;
        private int ylabiee2;
        private int ylabsd;
        private int ylabsd2;
        private int ylabsr;
        private int ylabsr2;
        private int ylabss;
        private int ylabss2;
        private int ylabwos;
        private int ylabwos2;
        private int yline;
        private int yold;
        private int yprogress;
        private int yprogressdownload;
        private int ysave;

        public Form1()
        {
            bazyBoxs = new CheckBox[5];


            //Springer spr = new Springer();
            //spr.ParserPDF("http://link.springer.com/book/10.1007/978-1-4757-1860-7", "TEST.pdf");
            //ParserSD.ParserPDF("http://www.sciencedirect.com/science/article/pii/S036013151400222X","cos");
            MinimumSize = new Size(808, 638);
            PDFParser parser;

            dtpf.Location = new Point(350, 533);
            dtpf.Size = new Size(75, 75); //;50, 50);
            dtpt.Size = new Size(75, 75);
            dtpf.Font = new Font("Arial", 16);
            dtpt.Font = new Font("Arial", 16);
            dtpf.Format = DateTimePickerFormat.Custom;
            dtpf.CustomFormat = "yyyy";
            dtpf.ShowUpDown = true;
            dtpt.Location = new Point(450, 533);
            dtpt.Format = DateTimePickerFormat.Custom;
            dtpt.CustomFormat = "yyyy";
            dtpt.ShowUpDown = true;
            dtpf.Anchor = AnchorStyles.None;
            dtpt.Anchor = AnchorStyles.None;
            dtpf.Visible = false;
            dtpt.Visible = false;
            Controls.Add(dtpf);
            Controls.Add(dtpt);
            tabControl = new TabControl();
            tabControl.Location = new Point(50, 168);
            tabControl.Size = new Size(700, 400);
            InitializeComponent();
            label1.Text = "Witaj!";
            label1.Font = new Font("Trebuchet MS", 30);
            label2.Text = "Czego szukasz?";
            label2.Font = new Font("Trebuchet MS", 16);
            wyniki.Font = new Font("Trebuchet MS", 16);
            wyniki.Location = label1.Location;
            wyniki.Visible = false;
            wyniki.AutoSize = true;
            wyniki.BackColor = Color.Transparent;
            Controls.Add(wyniki);
            labeltemp.Parent = pictureBoxhide;
            labeltemp.BackColor = Color.Transparent;
            label_science.Visible = false;
            label_springer.Visible = false;
            label_wos.Visible = false;
            label_ieee.Visible = false;
            label_scopus.Visible = false;
            labelIEEE.Text = "";
            labelWOS.Text = "";
            labelSr.Text = "";
            label_Ss.Text = "";
            label_sd.Text = "";
            grid.Size = new Size(tabControl.Size.Width - 15, tabControl.Height - 35);
            pictureBox5.Left = (ClientSize.Width - pictureBox5.Width)/2;
            pictureBox5.Top = (ClientSize.Height - pictureBox5.Height)/2 + 100;
            pictureBoxline.Left = (ClientSize.Width - pictureBoxline.Width)/2;
            pictureBoxline.Top = (ClientSize.Height - pictureBoxline.Height)/2;
            labeltemp.Left = (ClientSize.Width - labeltemp.Width)/3;
            labeltemp.Top = (ClientSize.Height - labeltemp.Height)/3;
            gridieee.Size = new Size(tabControl.Size.Width - 15, tabControl.Height - 35);
            gridscienceDirect.Size = new Size(tabControl.Size.Width - 15, tabControl.Height - 35);
            gridscopus.Size = new Size(tabControl.Size.Width - 15, tabControl.Height - 35);
            gridspringer.Size = new Size(tabControl.Size.Width - 15, tabControl.Height - 35);
            gridwebofscience.Size = new Size(tabControl.Size.Width - 15, tabControl.Height - 35);
            grid.MouseUp += grid_mouseUP;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            var mnu = new ContextMenuStrip();
            var mnuOpen = new ToolStripMenuItem("Open");
            var mnuCopy = new ToolStripMenuItem("Copy");
            var mnuspr = new ContextMenuStrip();
            var mnusprOpen = new ToolStripMenuItem("Open");
            var mnusprCopy = new ToolStripMenuItem("Copy");
            var mnuscop = new ContextMenuStrip();
            var mnuscopOpen = new ToolStripMenuItem("Open");
            var mnuscopCopy = new ToolStripMenuItem("Copy");
            var mnusd = new ContextMenuStrip();
            var mnusdOpen = new ToolStripMenuItem("Open");
            var mnusdCopy = new ToolStripMenuItem("Copy");
            var mnuwos = new ContextMenuStrip();
            var mnuwosOpen = new ToolStripMenuItem("Open");
            var mnuwosCopy = new ToolStripMenuItem("Copy");
            var mnuiee = new ContextMenuStrip();
            var mnuieOpen = new ToolStripMenuItem("Open");
            var mnuieCopy = new ToolStripMenuItem("Copy");
            grid.CellContentClick += dataGridView1_CellContentClick;
            gridspringer.CellContentClick += dataGridViewspringer_CellContentClick;
            gridscienceDirect.CellContentClick += dataGridViewscience_CellContentClick;
            gridieee.CellContentClick += dataGridViewiee_CellContentClick;

            grid.AllowUserToAddRows = false;
            gridspringer.AllowUserToAddRows = false;
            gridieee.AllowUserToAddRows = false;
            gridscienceDirect.AllowUserToAddRows = false;
            gridwebofscience.AllowUserToAddRows = false;
            gridscopus.AllowUserToAddRows = false;

            progressBarpdf.Visible = false;
            grid.CellMouseDown += dataGridView1_CellMouseDown;
            mnuCopy.Click += mnuCopy_Click;
            mnuOpen.Click += mnuOpen_Click;
            mnusprCopy.Click += mnuCopyspr_Click;
            mnusprOpen.Click += mnuOpenspr_Click;
            mnuscopCopy.Click += mnuCopysco_Click;
            mnuscopOpen.Click += mnuOpensco_Click;
            mnuwosCopy.Click += mnuCopywos_Click;
            mnuwosOpen.Click += mnuOpenwos_Click;
            mnuieCopy.Click += mnuCopyiee_Click;
            mnuieOpen.Click += mnuOpeniee_Click;
            mnusdOpen.Click += mnuOpenSD_Click;
            mnusdCopy.Click += mnuCopySD_Click;

            mnu.Items.AddRange(new ToolStripItem[] { mnuOpen, mnuCopy });

            mnuspr.Items.AddRange(new ToolStripItem[] {mnusprOpen, mnusprCopy});

            mnuiee.Items.AddRange(new ToolStripItem[] {mnuieOpen, mnuieCopy});

            mnuwos.Items.AddRange(new ToolStripItem[] {mnuwosOpen, mnuwosCopy});

            mnusd.Items.AddRange(new ToolStripItem[] {mnusdOpen, mnusdCopy});

            mnuscop.Items.AddRange(new ToolStripItem[] {mnuscopOpen, mnuscopCopy});

            grid.ContextMenuStrip = mnu;

            gridspringer.ContextMenuStrip = mnuspr;
            gridieee.ContextMenuStrip = mnuiee;
            gridwebofscience.ContextMenuStrip = mnuwos;
            gridscopus.ContextMenuStrip = mnuscop;
            gridscienceDirect.ContextMenuStrip = mnusd;

            pictureBoxBack.Visible = false;
            pictureBoxOpen.Visible = true;
            pictureBoxSave.Visible = false;
            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(pictureBoxBack, "Wróć");
            var tt = new ToolTip();
            tt.SetToolTip(pictureBoxHistory, "Historia");
            var tt2 = new ToolTip();
            tt2.SetToolTip(pictureBoxOpen, "Otwórz");
            var tt3 = new ToolTip();
            tt3.SetToolTip(pictureBoxSave, "Zapisz");
            var tt4 = new ToolTip();
            tt4.SetToolTip(pictureBoxDownload, "Pobierz PDF");
            grid.RowPostPaint += dataGridView1_RowPostPaint;
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = ".\\";
            pictureBoxHistory.BackgroundImage = Resources.story;
            pictureBoxBack.BackgroundImage = Resources.back;
            pictureBoxSave.BackgroundImage = Resources.save;
            pictureBoxOpen.BackgroundImage = Resources.open;
            pictureBoxDownload.BackgroundImage = Resources.down1;
            pictureBoxDownload.Visible = false;
            progressBar1.Visible = false;
            bazyBoxs[0] = checkBoxScience;
            bazyBoxs[1] = checkBoxScopus;
            bazyBoxs[2] = checkBoxWos;
            bazyBoxs[3] = checkBoxSpringer;
            bazyBoxs[4] = checkBoxIEEE;

            for (int i = 0; i < 5; i++)
            {
                bazyBoxs[i].Checked = true;
            }
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                //  grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            }
            for (int i = 0; i < gridieee.ColumnCount; i++)
            {
                gridscienceDirect.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                gridspringer.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                gridscopus.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                gridieee.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                gridwebofscience.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            }
            BackColor = Color.FromArgb(54, 52, 52);
            foreach (Control item in Controls)
            {
                item.Anchor = AnchorStyles.None;
            }
            pictureBox8.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            pictureBoxX.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            pictureBoxmin.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            pictureBoxmax.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            pictureBoxQuestion.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            pictureBoxMinim.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            tabControl.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            pictureBoxDownload.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
            pictureBoxBack.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
            pictureBoxOpen.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
            pictureBoxHistory.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
            pictureBoxSave.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
            wyniki.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            progressBarpdf.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            grid.Dock = DockStyle.Fill;
            gridieee.Dock = DockStyle.Fill;
            gridspringer.Dock = DockStyle.Fill;
            gridscienceDirect.Dock = DockStyle.Fill;
            gridscopus.Dock = DockStyle.Fill;
            gridwebofscience.Dock = DockStyle.Fill;
        }


        public void process_string(string s)
        {
            // progressBar1.Style = ProgressBarStyle.Marquee;
            search = s;
            bazyth = new BazyTh();
            progressBar1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int exe = formloc.X - cursloc.X + Cursor.Position.X;
            int eye = formloc.Y - cursloc.Y + Cursor.Position.Y;
            Location = new Point(exe, eye);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBoxX.BackgroundImage = Resources.x3;
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            pictureBoxMinim.BackgroundImage = Resources._3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //   backgroundWorker4.RunWorkerAsync();
            //  grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;
            grid.EnableHeadersVisualStyles = false;
            grid.ReadOnly = true;
            grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            grid.ShowCellToolTips = false;

            //     gridspringer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridspringer.BorderStyle = BorderStyle.None;
            gridspringer.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            gridspringer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridspringer.EditMode = DataGridViewEditMode.EditProgrammatically;
            gridspringer.EnableHeadersVisualStyles = false;
            gridspringer.ReadOnly = true;
            gridspringer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            gridspringer.ShowCellToolTips = false;

            //      gridscopus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridscopus.BorderStyle = BorderStyle.None;
            gridscopus.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            gridscopus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridscopus.EditMode = DataGridViewEditMode.EditProgrammatically;
            gridscopus.EnableHeadersVisualStyles = false;
            gridscopus.ReadOnly = true;
            gridscopus.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            gridscopus.ShowCellToolTips = false;

            //     gridwebofscience.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridwebofscience.BorderStyle = BorderStyle.None;
            gridwebofscience.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            gridwebofscience.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridwebofscience.EditMode = DataGridViewEditMode.EditProgrammatically;
            gridwebofscience.EnableHeadersVisualStyles = false;
            gridwebofscience.ReadOnly = true;
            gridwebofscience.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            gridwebofscience.ShowCellToolTips = false;

            //       gridscienceDirect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridscienceDirect.BorderStyle = BorderStyle.None;
            gridscienceDirect.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            gridscienceDirect.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridscienceDirect.EditMode = DataGridViewEditMode.EditProgrammatically;
            gridscienceDirect.EnableHeadersVisualStyles = false;
            gridscienceDirect.ReadOnly = true;
            gridscienceDirect.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            gridscienceDirect.ShowCellToolTips = false;

            //      gridieee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridieee.BorderStyle = BorderStyle.None;
            gridieee.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            gridieee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridieee.EditMode = DataGridViewEditMode.EditProgrammatically;
            gridieee.EnableHeadersVisualStyles = false;
            gridieee.ReadOnly = true;
            gridieee.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            gridieee.ShowCellToolTips = false;

            textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxSearch.AutoCompleteCustomSource = autoComplete;

            if (System.IO.File.Exists("autoComplete.acs") == false)
            {
                FileStream a;
                a = System.IO.File.Create("autoComplete.acs");
                a.Close();
            }
            else
            {
                var sr = new StreamReader("AutoComplete.acs");


                string line = sr.ReadLine();

                while (line != null)
                {
                    autoComplete.Add(line);

                    line = sr.ReadLine();
                }


                sr.Close();
                sr.Dispose();
            }

            textBoxSearch.Font = new Font(textBoxSearch.Font.FontFamily, 25);
            textBoxSearch.AutoSize = false;
            textBoxSearch.Size = new Size(600, 53);
            creategrid();
        }

        private void searchd()
        {
            if (bazyBoxs[0].Checked == false && bazyBoxs[1].Checked == false && bazyBoxs[2].Checked == false &&
                bazyBoxs[3].Checked == false && bazyBoxs[4].Checked == false)
            {
                MessageBox.Show("Wybierz przynajmniej jedną baze!");
            }
            else
            {
                if (textBoxSearch.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Musisz coś wpisać!");
                }
                else
                {
                    var pattern = new Regex("[a-zA-Z]");


                    if (pattern.IsMatch(textBoxSearch.Text))
                    {
                        //drawline(pictureBox6,new Point(0,0),new Point(100,100),10,Color.White  );
                        var ZUT = new Tracert();
                        ZUT.Ping();
                        if (ZUT.polaczenie == -1 || ZUT.polaczenie == -2)
                        {
                            var myform = new Form_error(this);
                            labelIEEE.Visible = false;
                            labelSr.Visible = false;
                            labelWOS.Visible = false;
                            label_Ss.Visible = false;
                            label_ieee.Visible = false;
                            label_science.Visible = false;
                            label_sd.Visible = false;
                            label_springer.Visible = false;
                            label_wos.Visible = false;
                            label_scopus.Visible = false;
                            pictureBoxline.Visible = false;
                            if (myform.ShowDialog() == DialogResult.Abort)
                            {
                                Application.Exit();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                bazyBoxs[i].Visible = false;
                            }
                            dtpt.Visible = false;
                            dtpf.Visible = false;
                            checkBoxyear.Visible = false;
                            label2.Visible = false;
                            pictureBoxline.Visible = true;
                            pictureBoxBack.Visible = false;
                            labelIEEE.Visible = true;
                            labelSr.Visible = true;
                            labelWOS.Visible = true;
                            label_Ss.Visible = true;
                            label_ieee.Visible = true;
                            label_science.Visible = true;
                            label_sd.Visible = true;
                            label_springer.Visible = true;
                            label_wos.Visible = true;
                            label_scopus.Visible = true;
                            pictureBoxHistory.Visible = false;
                            pictureBoxOpen.Visible = false;
                            pictureBoxSave.Visible = false;
                            pictureBoxDownload.Visible = false;

                            test = textBoxSearch.Text;
                            autoComplete.Add(test);

                            pictureBoxhide.Visible = true;
                            labeltemp.Visible = true;
                            labeltemp.Font = new Font(labeltemp.Font.FontFamily, 25);
                            pictureBoxhide.Refresh();
                            timer2.Start();
                            process_string(test);
                            timer2.Stop();
                            if (am)
                            {
                                pictureBoxhide.Visible = false;
                                labeltemp.Visible = false;
                            }

                            textBoxSearch.Location = new Point(151, 178);
                            label1.Visible = false;

                            wyniki.Text = "Znaleziono następującą ilość wyników: " + fcount;
                            wyniki.Location = new Point(20, 57);
                            pictureBox5.Visible = false;
                            textBoxSearch.Visible = false;
                            //    pictureBoxBack.Visible = true;
                            //     pictureBox7.Visible = true;
                        }
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (checkBoxyear.Checked)
                {
                    if (Convert.ToInt32(dtpf.Text) > DateTime.Now.Year || Convert.ToInt32(dtpt.Text) > DateTime.Now.Year ||
                        Convert.ToInt32(dtpf.Text) > Convert.ToInt32(dtpt.Text))
                    {
                        MessageBox.Show("Wpisz poprawne lata");
                    }
                    else
                    {
                        var pattern = new Regex("[a-zA-Z]");

                        if (pattern.IsMatch(textBoxSearch.Text))
                        {
                            searchd();
                            return true; // return true to intercept the key press
                        }
                        MessageBox.Show("Nieprawidłowe zapytanie!");
                    }
                }
                else
                {
                    var pattern = new Regex("[a-zA-Z]");

                    if (pattern.IsMatch(textBoxSearch.Text))
                    {
                        searchd();
                        return true; // return true to intercept the key press
                    }
                    MessageBox.Show("Nieprawidłowe zapytanie!");
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (checkBoxyear.Checked)
            {
                if (Convert.ToInt32(dtpf.Text) > DateTime.Now.Year || Convert.ToInt32(dtpt.Text) > DateTime.Now.Year ||
                    Convert.ToInt32(dtpf.Text) > Convert.ToInt32(dtpt.Text))
                {
                    MessageBox.Show("Wpisz poprawne lata");
                }
                else
                {
                    if (textBoxSearch.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Musisz coś wpisać!");
                    }
                    else
                    {
                        var pattern = new Regex("[a-zA-Z]");


                        if (pattern.IsMatch(textBoxSearch.Text))
                        {
                            searchd();
                        }
                        else
                        {
                            MessageBox.Show("Nieprawidłowe zapytanie!");
                        }
                    }
                }
            }
            else
            {
                if (textBoxSearch.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Musisz coś wpisać!");
                }
                else
                {
                    var pattern = new Regex("[a-zA-Z]");


                    if (pattern.IsMatch(textBoxSearch.Text))
                    {
                        searchd();
                    }
                    else
                    {
                        MessageBox.Show("Nieprawidłowe zapytanie!");
                    }
                }
            }
        }

        private void buttonSearch_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = Resources.szukajh;
        }

        private void buttonSearch_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = Resources.szukaj;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBoxQuestion.BackgroundImage = Resources.z2;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBoxQuestion.BackgroundImage = Resources.z3;
            var formq = new FormQ();
            formq.Show();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxQuestion.BackgroundImage = Resources.z1;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBoxMinim.BackgroundImage = Resources._2;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxMinim.BackgroundImage = Resources._1;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBoxX.BackgroundImage = Resources.x2;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxX.BackgroundImage = Resources.x1;
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
        }


        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //open stream to AutoComplete save file
            var sw = new StreamWriter("AutoComplete.acs");

            //Write AutoCompleteStringCollection to stream
            foreach (string s in autoComplete)
                sw.WriteLine(s);

            //Flush to file
            sw.Flush();

            //Clean up
            sw.Close();
            sw.Dispose();
        }


        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBoxBack.BackgroundImage = Resources.back3;
            Close(); //to turn off current app
           Application.Restart(); // to start new instance of application
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var data = new List<string>();
            openFileDialog1.Filter = "Bib files (.bib)|*.bib";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                data = File.OpenFile(null, openFileDialog1.FileName);
                if (File.Sprawdzenie(data))
                {
                    var StrBibliotekarz = new StructBibliotekarz();
                    StrBibliotekarz.Dodawanie(data);
                    if (grid.RowCount > 0)
                    {
                        grid.Rows.Clear();
                    }


                    DGV_populate(StrBibliotekarz);

                    label1.Visible = false;
                    pictureBoxHistory.Visible = false;
                }
                else
                {
                    MessageBox.Show("Plik niepoprawny");
                }
            }
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            pictureBoxline.Visible = false;
            pictureBoxHistory.BackgroundImage = Resources.story3;
            pictureBoxHistory.Refresh();


            var formH = new FormHistory(this);

            if (formH.ShowDialog() == DialogResult.OK)
            {
                textBoxSearch.Text = history;
                // label1.Visible = false;
                pictureBoxHistory.BackgroundImage = Resources.story;
            }
        }


        public void PassValue(string strValue)
        {
            history = strValue;
        }

        private void creategrid()
        {
            var doWork = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = "PDF";
            doWork.Name = "PDF";
            doWork.FalseValue = "0";
            doWork.TrueValue = "1";
            var doWorkiee = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = "PDF";
            doWork.Name = "PDF";
            doWork.FalseValue = "0";
            doWork.TrueValue = "1";
            var doWorkspringer = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = "PDF";
            doWork.Name = "PDF";
            doWork.FalseValue = "0";
            doWork.TrueValue = "1";
            var doWorkscience = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = "PDF";
            doWork.Name = "PDF";
            doWork.FalseValue = "0";
            doWork.TrueValue = "1";

            grid.Columns.Insert(0, doWork);
            grid.Columns[0].Visible = true;
            gridieee.Columns.Insert(0, doWorkiee);
            gridieee.Columns[0].Visible = true;
            gridspringer.Columns.Insert(0, doWorkspringer);
            gridspringer.Columns[0].Visible = true;
            gridscienceDirect.Columns.Insert(0, doWorkscience);
            gridscienceDirect.Columns[0].Visible = true;
            int ccount = 13;
            Color clr = Color.FromArgb(54, 52, 52);
            grid.RowsDefaultCellStyle.BackColor = clr;


            grid.ForeColor = Color.White;
            grid.BackgroundColor = clr;
            grid.ColumnCount = ccount;

            grid.Columns[1].Name = "Strona";
            grid.Columns[2].Name = "Tytuł";
            grid.Columns[3].Name = "Czasopismo";
            grid.Columns[4].Name = "Wydanie";
            grid.Columns[5].Name = "Numer";
            grid.Columns[6].Name = "Liczba stron";
            grid.Columns[7].Name = "Rok wydania";
            grid.Columns[8].Name = "Notatka";
            grid.Columns[9].Name = "Issn";
            grid.Columns[10].Name = "Doi";
            grid.Columns[11].Name = "URL";
            grid.Columns[12].Name = "Autorzy";
            //   grid.Columns[13].Name = "PDF";

            grid.BorderStyle = BorderStyle.None;
            gridwebofscience.RowsDefaultCellStyle.BackColor = clr;
            //  gridspringer.Location = new Point(gridspringer.Location.Y, 178);

            gridwebofscience.ForeColor = Color.White;
            gridwebofscience.BackgroundColor = clr;
            gridwebofscience.ColumnCount = ccount;
            gridwebofscience.Columns[0].Name = "Strona";
            gridwebofscience.Columns[1].Name = "Tytuł";
            gridwebofscience.Columns[2].Name = "Czasopismo";
            gridwebofscience.Columns[3].Name = "Wydanie";
            gridwebofscience.Columns[4].Name = "Numer";
            gridwebofscience.Columns[5].Name = "Liczba stron";
            gridwebofscience.Columns[6].Name = "Rok wydania";
            gridwebofscience.Columns[7].Name = "Notatka";
            gridwebofscience.Columns[8].Name = "Issn";
            gridwebofscience.Columns[9].Name = "Doi";
            gridwebofscience.Columns[10].Name = "URL";
            gridwebofscience.Columns[11].Name = "Autorzy";
            gridwebofscience.Columns[12].Name = "Abstrakt";
            gridwebofscience.BorderStyle = BorderStyle.None;

            // gridieee.Location = new Point(0, 0); //(gridieee.Location.X, 70);
            //gridieee.AlternatingRowsDefaultCellStyle.BackColor = clr;
            gridieee.RowsDefaultCellStyle.BackColor = clr;
            //  gridieee.Location = new Point(gridieee.Location.Y, 178);

            gridieee.ForeColor = Color.White;
            gridieee.BackgroundColor = clr;
            gridieee.ColumnCount = ccount + 1;
            gridieee.Columns[1].Name = "Strona";
            gridieee.Columns[2].Name = "Tytuł";
            gridieee.Columns[3].Name = "Czasopismo";
            gridieee.Columns[4].Name = "Wydanie";
            gridieee.Columns[5].Name = "Numer";
            gridieee.Columns[6].Name = "Liczba stron";
            gridieee.Columns[7].Name = "Rok wydania";
            gridieee.Columns[8].Name = "Notatka";
            gridieee.Columns[9].Name = "Issn";
            gridieee.Columns[10].Name = "Doi";
            gridieee.Columns[11].Name = "URL";
            gridieee.Columns[12].Name = "Autorzy";
            gridieee.Columns[13].Name = "Abstrakt";
            gridieee.BorderStyle = BorderStyle.None;

            //   gridscienceDirect.Location = new Point(0, 0); //(gridscienceDirect.Location.X, 70);
            //gridscienceDirect.AlternatingRowsDefaultCellStyle.BackColor = clr;
            gridscienceDirect.RowsDefaultCellStyle.BackColor = clr;
            //  gridscienceDirect.Location = new Point(gridscienceDirect.Location.Y, 178);

            gridscienceDirect.ForeColor = Color.White;
            gridscienceDirect.BackgroundColor = clr;
            gridscienceDirect.ColumnCount = ccount + 1;
            gridscienceDirect.Columns[1].Name = "Strona";
            gridscienceDirect.Columns[2].Name = "Tytuł";
            gridscienceDirect.Columns[3].Name = "Czasopismo";
            gridscienceDirect.Columns[4].Name = "Wydanie";
            gridscienceDirect.Columns[5].Name = "Numer";
            gridscienceDirect.Columns[6].Name = "Liczba stron";
            gridscienceDirect.Columns[7].Name = "Rok wydania";
            gridscienceDirect.Columns[8].Name = "Notatka";
            gridscienceDirect.Columns[9].Name = "Issn";
            gridscienceDirect.Columns[10].Name = "Doi";
            gridscienceDirect.Columns[11].Name = "URL";
            gridscienceDirect.Columns[12].Name = "Autorzy";
            gridscienceDirect.Columns[13].Name = "Abstrakt";
            gridscienceDirect.BorderStyle = BorderStyle.None;

            //  gridscopus.Location = new Point(0, 0); //(gridscopus.Location.X, 70);
            //gridscopus.AlternatingRowsDefaultCellStyle.BackColor = clr;
            gridscopus.RowsDefaultCellStyle.BackColor = clr;
            //  gridscopus.Location = new Point(gridscopus.Location.Y, 178);

            gridscopus.ForeColor = Color.White;
            gridscopus.BackgroundColor = clr;
            gridscopus.ColumnCount = ccount;
            gridscopus.Columns[0].Name = "Strona";
            gridscopus.Columns[1].Name = "Tytuł";
            gridscopus.Columns[2].Name = "Czasopismo";
            gridscopus.Columns[3].Name = "Wydanie";
            gridscopus.Columns[4].Name = "Numer";
            gridscopus.Columns[5].Name = "Liczba stron";
            gridscopus.Columns[6].Name = "Rok wydania";
            gridscopus.Columns[7].Name = "Notatka";
            gridscopus.Columns[8].Name = "Issn";
            gridscopus.Columns[9].Name = "Doi";
            gridscopus.Columns[10].Name = "URL";
            gridscopus.Columns[11].Name = "Autorzy";
            gridscopus.Columns[12].Name = "Abstrakt";
            gridscopus.BorderStyle = BorderStyle.None;

            //   gridspringer.Location = new Point(0, 0); //(gridspringer.Location.X, 70);
            //gridspringer.AlternatingRowsDefaultCellStyle.BackColor = clr;
            gridspringer.RowsDefaultCellStyle.BackColor = clr;
            //  gridspringer.Location = new Point(gridspringer.Location.Y, 178);

            gridspringer.ForeColor = Color.White;
            gridspringer.BackgroundColor = clr;
            gridspringer.ColumnCount = ccount + 1;
            gridspringer.Columns[1].Name = "Strona";
            gridspringer.Columns[2].Name = "Tytuł";
            gridspringer.Columns[3].Name = "Czasopismo";
            gridspringer.Columns[4].Name = "Wydanie";
            gridspringer.Columns[5].Name = "Numer";
            gridspringer.Columns[6].Name = "Liczba stron";
            gridspringer.Columns[7].Name = "Rok wydania";
            gridspringer.Columns[8].Name = "Notatka";
            gridspringer.Columns[9].Name = "Issn";
            gridspringer.Columns[10].Name = "Doi";
            gridspringer.Columns[11].Name = "URL";
            gridspringer.Columns[12].Name = "Autorzy";
            gridspringer.Columns[13].Name = "Abstrakt";
            gridspringer.BorderStyle = BorderStyle.None;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            pictureBoxSave.BackgroundImage = Resources.save3;
            var saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "bib files (.bib)|*.bib";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = search;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.SaveFile(null, saveFileDialog1.FileName, ListtoString.ParserAll(data));
                MessageBox.Show("Pomyślnie zapisano plik");
                pictureBoxSave.BackgroundImage = Resources.save;
            }
            else
            {
                pictureBoxSave.BackgroundImage = Resources.save;
            }
        }

        private void DGV_populate(StructBibliotekarz pop)
        {
            checkBoxyear.Visible = false;
            for (int i = 0; i < 5; i++)
            {
                bazyBoxs[i].Visible = false;
            }
            dtpt.Visible = false;
            dtpf.Visible = false;
            pictureBoxline.Visible = false;
            pictureBoxDownload.Visible = true;
            pictureBoxhide.Visible = true;
            labeltemp.Visible = true;
            labeltemp.Font = new Font(labeltemp.Font.FontFamily, 25);
            pictureBoxhide.Refresh();
            timer2.Start();


            if (tabControl.TabPages.Count > 0)
            {
                tabControl.TabPages.Clear();
            }
            Color clr = Color.FromArgb(54, 52, 52);
            for (int i = 1; i <= 1; i++)
            {
                var page = new TabPage("Wyniki wyszukiwania");
                //  page.BackgroundImage = Resources.background;
                page.BackColor = clr;
                tabControl.TabPages.Add(page);
            }


            foreach (TabPage page in tabControl.TabPages)
            {
                //  grid.Location = new Point(10, 10);


                foreach (StructBibliotekarz test in pop.StrBibliotekarz)
                {
                    grid.Rows.Add(false, test.source, test.title, test.journal, test.volume, test.number, test.pages,
                        test.year, test.note, test.issn, test.doi, test.url, test.author, " ");
                }
                grid.ReadOnly = true;
                grid.AutoSize = false;
                page.Controls.Add(grid);
            }


            Controls.Add(tabControl);


            am = true;
            timer2.Stop();
            if (am)
            {
                pictureBoxhide.Visible = false;
                labeltemp.Visible = false;
                label2.Visible = false;
                wyniki.Visible = true;
            }

            textBoxSearch.Location = new Point(151, 178);
            label1.Text = " ";
            wyniki.Text = "Ilość wyników: " + pop.StrBibliotekarz.Count;
            //  wyniki.Location = new Point(28, 137);
            pictureBox5.Visible = false;
            textBoxSearch.Visible = false;
            pictureBoxBack.Visible = true;
            pictureBoxOpen.Visible = true;

            tabControl.Size = new Size(ClientSize.Width - 100, ClientSize.Height - 200);
            //  pictureBoxmin.Left = (this.ClientSize.Width - pictureBoxmin.Width) - 50;
            //grid.SetBounds(Left, Top, tabControl.Width/2-100, tabControl.Height/2);
            grid.Top = (tabControl.Width - grid.Width);
            //  grid.Left = (tabControl.Height - grid.Height);
        }

        private void grid_mouseUP(object sender, MouseEventArgs e)
        {
            // System.Windows.Forms.ContextMenu menu = new ContextMenu();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                Clipboard.SetData(DataFormats.Text, grid.Rows[row].Cells[col].Value.ToString());
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                string url = grid.Rows[row].Cells[col].Value.ToString();
                if (url[0].ToString() == "h" && url[1].ToString() == "t" && url[2].ToString() == "t" &&
                    url[3].ToString() == "p")

                    Process.Start(url);
            }
        }

        private void mnuCopyspr_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                Clipboard.SetData(DataFormats.Text, gridspringer.Rows[row].Cells[col].Value.ToString());
            }
        }

        private void mnuOpenspr_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                string url = gridspringer.Rows[row].Cells[col].Value.ToString();
                if (url[0].ToString() == "h" && url[1].ToString() == "t" && url[2].ToString() == "t" &&
                    url[3].ToString() == "p")

                    Process.Start(url);
            }
        }

        private void mnuCopysco_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                Clipboard.SetData(DataFormats.Text, gridscopus.Rows[row].Cells[col].Value.ToString());
            }
        }

        private void mnuOpensco_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                string url = gridscopus.Rows[row].Cells[col].Value.ToString();
                if (url[0].ToString() == "h" && url[1].ToString() == "t" && url[2].ToString() == "t" &&
                    url[3].ToString() == "p")

                    Process.Start(url);
            }
        }

        private void mnuCopySD_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                Clipboard.SetData(DataFormats.Text, gridspringer.Rows[row].Cells[col].Value.ToString());
            }
        }

        private void mnuOpenSD_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                string url = gridspringer.Rows[row].Cells[col].Value.ToString();
                if (url[0].ToString() == "h" && url[1].ToString() == "t" && url[2].ToString() == "t" &&
                    url[3].ToString() == "p")

                    Process.Start(url);
            }
        }

        private void mnuCopywos_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                Clipboard.SetData(DataFormats.Text, gridspringer.Rows[row].Cells[col].Value.ToString());
            }
        }

        private void mnuOpenwos_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                string url = gridspringer.Rows[row].Cells[col].Value.ToString();
                if (url[0].ToString() == "h" && url[1].ToString() == "t" && url[2].ToString() == "t" &&
                    url[3].ToString() == "p")

                    Process.Start(url);
            }
        }

        private void mnuCopyiee_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                Clipboard.SetData(DataFormats.Text, gridspringer.Rows[row].Cells[col].Value.ToString());
            }
        }

        private void mnuOpeniee_Click(object sender, EventArgs e)
        {
            if (row >= 0 && col >= 0)
            {
                string url = gridspringer.Rows[row].Cells[col].Value.ToString();
                if (url[0].ToString() == "h" && url[1].ToString() == "t" && url[2].ToString() == "t" &&
                    url[3].ToString() == "p")

                    Process.Start(url);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell) grid.Rows[grid.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    //objeiee.ParserPDF(.\\");
                    abstrakty.Remove(grid.CurrentRow.Index);
                    licznikpdf--;
                    break;
                case "False":
                    try
                    {
                        //   string temp = grid.Rows[grid.CurrentRow.Index].Cells[10].Value.ToString();
                        //  objeiee.ParserPDF((grid.Rows[grid.CurrentRow.Index].Cells[10].Value.ToString()),".\\");
                        abstrakty.Add(grid.CurrentRow.Index);
                        licznikpdf++;
                    }
                    catch
                    {
                        MessageBox.Show("Dana pozycja nie posiada abstraktu");
                        ch1.Value = false;
                        break;
                    }
                    ch1.Value = true;
                    break;
            }
        }

        private void dataGridViewspringer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell) gridspringer.Rows[gridspringer.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    //objeiee.ParserPDF(.\\");
                    abstraktyspringer.Remove(gridspringer.CurrentRow.Index);
                    break;
                case "False":
                    try
                    {
                        //   string temp = grid.Rows[grid.CurrentRow.Index].Cells[10].Value.ToString();
                        //  objeiee.ParserPDF((grid.Rows[grid.CurrentRow.Index].Cells[10].Value.ToString()),".\\");
                        abstraktyspringer.Add(gridspringer.CurrentRow.Index);
                    }
                    catch
                    {
                        MessageBox.Show("Dana pozycja nie posiada abstraktu");
                        ch1.Value = false;
                        break;
                    }
                    ch1.Value = true;
                    break;
            }
        }

        private void dataGridViewiee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell) gridieee.Rows[gridieee.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    //objeiee.ParserPDF(.\\");
                    abstraktyiee.Remove(gridieee.CurrentRow.Index);
                    break;
                case "False":
                    try
                    {
                        //   string temp = grid.Rows[grid.CurrentRow.Index].Cells[10].Value.ToString();
                        //  objeiee.ParserPDF((grid.Rows[grid.CurrentRow.Index].Cells[10].Value.ToString()),".\\");
                        abstraktyiee.Add(gridieee.CurrentRow.Index);
                    }
                    catch
                    {
                        MessageBox.Show("Dana pozycja nie posiada abstraktu");
                        ch1.Value = false;
                        break;
                    }
                    ch1.Value = true;
                    break;
            }
        }

        private void dataGridViewscience_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell) gridscienceDirect.Rows[gridscienceDirect.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    //objeiee.ParserPDF(.\\");
                    abstraktyscience.Remove(gridscienceDirect.CurrentRow.Index);
                    break;
                case "False":
                    try
                    {
                        //   string temp = grid.Rows[grid.CurrentRow.Index].Cells[10].Value.ToString();
                        //  objeiee.ParserPDF((grid.Rows[grid.CurrentRow.Index].Cells[10].Value.ToString()),".\\");
                        abstraktyscience.Add(gridscienceDirect.CurrentRow.Index);
                    }
                    catch
                    {
                        MessageBox.Show("Dana pozycja nie posiada abstraktu");
                        ch1.Value = false;
                        break;
                    }
                    ch1.Value = true;
                    break;
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void pictureBoxBack_MouseEnter(object sender, EventArgs e)
        {
        }

        private void pictureBoxSave_MouseHover(object sender, EventArgs e)
        {
            pictureBoxSave.BackgroundImage = Resources.save2;
        }

        private void pictureBoxHistory_MouseHover(object sender, EventArgs e)
        {
            pictureBoxHistory.BackgroundImage = Resources.story2;
        }

        private void pictureBoxHistory_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxHistory.BackgroundImage = Resources.story;
        }

        private void pictureBoxHistory_BackgroundImageChanged(object sender, EventArgs e)
        {
        }

        private void pictureBoxBack_MouseHover(object sender, EventArgs e)
        {
            pictureBoxBack.BackgroundImage = Resources.back2;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            linkscience = new List<string>();
            linkspringer = new List<string>();
            linkIEEE = new List<string>();
            titlescience = new List<string>();
            titlespringer = new List<string>();
            titleIEEE = new List<string>();
            pdf = new OrderedDictionary();
            pdfname = new OrderedDictionary();
            //pictureBoxSave.Enabled = false;
            //var abstrakto = new StringBuilder();
            if (abstrakty.Count != 0 || abstraktyscience.Count != 0 || abstraktyiee.Count != 0 ||
                abstraktyspringer.Count != 0)
            {
                var folderBrowserDialog1 = new FolderBrowserDialog();
                DialogResult result = folderBrowserDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pictureBoxDownload.Enabled = false;
                    folderName = folderBrowserDialog1.SelectedPath;

                    progressBarpdf.Visible = true;

                    foreach (int el in abstrakty)
                    {
                        if (grid.Rows[el].Cells[1].Value.ToString() == "Science Direct")
                        {
                            linkscience.Add(grid.Rows[el].Cells[11].Value.ToString());
                            titlescience.Add(grid.Rows[el].Cells[2].Value.ToString());
                        }
                        if (grid.Rows[el].Cells[1].Value.ToString() == "Springer")
                        {
                            linkspringer.Add(grid.Rows[el].Cells[11].Value.ToString());
                            titlespringer.Add(grid.Rows[el].Cells[2].Value.ToString());
                        }
                        if (grid.Rows[el].Cells[1].Value.ToString() == "IEEE")
                        {
                            linkIEEE.Add(grid.Rows[el].Cells[11].Value.ToString());
                            titleIEEE.Add(grid.Rows[el].Cells[2].Value.ToString());
                        }
                    }
                    foreach (int el in abstraktyiee)
                    {
                        if (gridieee.Rows[el].Cells[1].Value.ToString() == "IEEE")
                        {
                            linkIEEE.Add(gridieee.Rows[el].Cells[11].Value.ToString());
                            titleIEEE.Add(gridieee.Rows[el].Cells[2].Value.ToString());
                        }
                    }
                    foreach (int el in abstraktyscience)
                    {
                        if (gridscienceDirect.Rows[el].Cells[1].Value.ToString() == "Science Direct")
                        {
                            linkscience.Add(gridscienceDirect.Rows[el].Cells[11].Value.ToString());
                            titlescience.Add(gridscienceDirect.Rows[el].Cells[2].Value.ToString());
                        }
                    }
                    foreach (int el in abstraktyspringer)
                    {
                        if (gridspringer.Rows[el].Cells[1].Value.ToString() == "Springer")
                        {
                            linkspringer.Add(gridspringer.Rows[el].Cells[11].Value.ToString());
                            titlespringer.Add(gridspringer.Rows[el].Cells[2].Value.ToString());
                        }
                    }
                    pdf.Add("Science", linkscience);
                    pdf.Add("Springer", linkspringer);
                    pdf.Add("IEEE", linkIEEE);
                    pdfname.Add("Science", titlescience);
                    pdfname.Add("Springer", titlespringer);
                    pdfname.Add("IEEE", titleIEEE);


                    formD = new FormDown(this);
                    formD.MyProperty = folderName;
                    backgroundWorker5.RunWorkerAsync(); //showdialog


                    formD.set_list_view(linkscience);
                    formD.set_list_view(linkspringer);
                    formD.set_list_view(linkIEEE);
                    if (pdf.Count > 0 && !backgroundWorker3.IsBusy)
                    {
                        backgroundWorker3.RunWorkerAsync();
                    }

                    Thread.Sleep(400);
                    if (!backgroundWorker4.IsBusy)
                    {
                        backgroundWorker4.RunWorkerAsync();
                    }

                    //File.SaveFile("Abstrakt", search + ".txt", abstrakto.ToString());
                }
            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var bazacheck = new bool[5];
            bazacheck[0] = checkBoxScience.Checked;
            bazacheck[1] = checkBoxScopus.Checked;
            bazacheck[2] = checkBoxWos.Checked;
            bazacheck[3] = checkBoxSpringer.Checked;
            bazacheck[4] = checkBoxIEEE.Checked;
            if (checkBoxyear.Checked)
            {
                bazyth.Bazy(bazacheck, search, Convert.ToInt32(dtpf.Text), Convert.ToInt32(dtpt.Text));
            }
            else
            {
                bazyth.Bazy(bazacheck, search, 0, 0);
            }
            backgroundWorker1.ReportProgress(BazyTh.Getlthread());
            complete = true;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                row = e.RowIndex;
                col = e.ColumnIndex;
            }
        }

        // IEnumerable testw;
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fcount = 0;
            //   labelfont.Visible = true;
            //     textBoxfont.Visible = true;
            pictureBoxline.Visible = false;
            labelIEEE.Visible = false;
            labelSr.Visible = false;
            labelWOS.Visible = false;
            label_Ss.Visible = false;
            label_ieee.Visible = false;
            label_science.Visible = false;
            label_sd.Visible = false;
            label_springer.Visible = false;
            label_wos.Visible = false;
            label_scopus.Visible = false;
            pictureBoxBack.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            wyniki.Visible = true;
            progressBar1.Visible = false;
            pictureBoxhide.Visible = false;
            int ccount = 13;
            //      tabControl = new TabControl();
            gridscopus.Size = new Size(690, 375);
            gridspringer.Size = new Size(690, 375);
            gridscienceDirect.Size = new Size(690, 375);
            gridieee.Size = new Size(690, 375);
            gridwebofscience.Size = new Size(690, 375);
            if (bazyBoxs[0].Checked)
            {
                gridscienceDirect.Visible = true;
            }
            else
            {
                gridscienceDirect.Visible = false;
            }
            if (bazyBoxs[1].Checked)
            {
                gridscopus.Visible = true;
            }
            else
            {
                gridscopus.Visible = false;
            }
            if (bazyBoxs[2].Checked)
            {
                gridwebofscience.Visible = true;
            }
            else
            {
                gridwebofscience.Visible = false;
            }
            if (bazyBoxs[3].Checked)
            {
                gridspringer.Visible = true;
            }
            else
            {
                gridspringer.Visible = false;
              
            }
            if (bazyBoxs[4].Checked)
            {
                gridieee.Visible = true;
            }
            else
            {
                gridieee.Visible = false;
            }


            Color clr = Color.FromArgb(54, 52, 52);
            for (int i = 1; i <= 1; i++)
            {
                var page = new TabPage("Najlepsze wyniki");

                page.BackColor = Color.FromArgb(54, 52, 52);
                tabControl.TabPages.Add(page);
            }
            string[] arr1 = {"Web of Science", "Scopus", "Springer", "IEEE", "Science Direct"};
            for (int i = 2; i <= 6; i++)
            {
                var page = new TabPage(arr1[i - 2]);

                page.BackColor = Color.FromArgb(54, 52, 52); //BackgroundImage = Resources.background;
                tabControl.TabPages.Add(page);
            }


            pictureBoxSave.Visible = true;
            pictureBoxDownload.Visible = true;
            var listy = new List<string>[12];
            var listywos = new List<string>[12];
            var listyieee = new List<string>[12];
            var listysr = new List<string>[12];
            var listysd = new List<string>[12];
            var listyss = new List<string>[12];


            //  string[] springerkeys = new string[bazyth.springerlist.Count];
            // bazyth.springerlist.Keys.CopyTo(springerkeys, 0);
            // List<string> springervalue = (List<string>)bazyth.springerlist[springerkeys[0]];
            for (int i = 0; i < 12; i++)
            {
                listy[i] = new List<string>();
                listywos[i] = new List<string>();
                listyieee[i] = new List<string>();
                listysr[i] = new List<string>();
                listysd[i] = new List<string>();
                listyss[i] = new List<string>();
            }

            listy = make_list(bazyth, bazyth, bazyth, bazyth, bazyth);


            grid.ReadOnly = true;
            grid.AutoSize = false;


            foreach (StructWOS wos in bazyth.woslist)
            {
                gridwebofscience.Rows.Add("Web of science", wos.title,
                    wos.journal,
                    wos.volume,
                    wos.number,
                    wos.pages,
                    wos.year, " ",
                    wos.issn, wos.doi,
                    " ", wos.author,
                    wos.Abstract);
                listywos[0].Add("Web of science");
                listywos[1].Add(wos.title);
                listywos[2].Add(wos.journal);
                listywos[3].Add(wos.volume);
                listywos[4].Add(wos.number);
                listywos[5].Add(wos.pages);
                listywos[6].Add(wos.year);
                listywos[7].Add(" ");
                listywos[8].Add(wos.issn);
                listywos[9].Add(wos.doi);
                listywos[10].Add(" ");
                listywos[11].Add(wos.author);
            }
            foreach (StructScop wos in bazyth.scoplist)
            {
                gridscopus.Rows.Add("Scopus", wos.title,
                    wos.journal,
                    wos.volume,
                    wos.number,
                    wos.pages,
                    wos.year, wos.year,
                    " ", " ",
                    wos.url, wos.author,
                    wos.Abstract);
                listyss[0].Add("Scopus");
                listyss[1].Add(wos.title);
                listyss[2].Add(wos.journal);
                listyss[3].Add(wos.volume);
                listyss[4].Add(wos.number);
                listyss[5].Add(wos.pages);
                listyss[6].Add(wos.year);
                listyss[7].Add(wos.note);
                listyss[8].Add(" ");
                listyss[9].Add(" ");
                listyss[10].Add(wos.url);
                listyss[11].Add(wos.author);
            }
            foreach (StructSDA wos in bazyth.sdlist)
            {
                gridscienceDirect.Rows.Add(false, "Science Direct", wos.title,
                    wos.journal,
                    wos.volume,
                    wos.number,
                    wos.pages,
                    wos.year, wos.year,
                    wos.issn, wos.doi,
                    wos.url, wos.author,
                    wos.Abstract);
                listysd[0].Add("Science Direct");
                listysd[1].Add(wos.title);
                listysd[2].Add(wos.journal);
                listysd[3].Add(wos.volume);
                listysd[4].Add(wos.number);
                listysd[5].Add(wos.pages);
                listysd[6].Add(wos.year);
                listysd[7].Add(wos.note);
                listysd[8].Add(wos.issn);
                listysd[9].Add(wos.doi);
                listysd[10].Add(wos.url);
                listysd[11].Add(wos.author);
                //listysd[12].Add(wos.Abstract);
            }
            foreach (StructSpringer wos in bazyth.springerlist)
            {
                gridspringer.Rows.Add(false, "Springer", wos.title,
                    wos.journal,
                    wos.volume,
                    " ",
                    " ",
                    wos.year, wos.year,
                    " ", wos.doi,
                    wos.url, wos.author,
                    " ");
                listysr[0].Add("Springer");
                listysr[1].Add(wos.title);
                listysr[2].Add(wos.journal);
                listysr[3].Add(wos.volume);
                listysr[4].Add(" ");
                listysr[5].Add(" ");
                listysr[6].Add(wos.year);
                listysr[7].Add(" ");
                listysr[8].Add(" ");
                listysr[9].Add(wos.doi);
                listysr[10].Add(wos.url);
                listysr[11].Add(wos.author);
            }
            foreach (StructIEEE wos in bazyth.ieeelist)
            {
                gridieee.Rows.Add(false, "IEEE", wos.title,
                    wos.journal,
                    wos.volume,
                    " ",
                    wos.pages,
                    wos.year, wos.year,
                    wos.issn, wos.doi,
                    wos.url, wos.author,
                    wos.Abstract);
                listyieee[0].Add("IEE");
                listyieee[1].Add(wos.title);
                listyieee[2].Add(wos.journal);
                listyieee[3].Add(wos.volume);
                listyieee[4].Add(" ");
                listyieee[5].Add(wos.pages);
                listyieee[6].Add(wos.year);
                listyieee[7].Add(" ");
                listyieee[8].Add(wos.issn);
                listyieee[9].Add(wos.doi);
                listyieee[10].Add(wos.url);
                listyieee[11].Add(wos.author);
            }
            tabControl.TabPages[1].Controls.Add(gridwebofscience);
            tabControl.TabPages[2].Controls.Add(gridscopus);
            tabControl.TabPages[3].Controls.Add(gridspringer);
            tabControl.TabPages[4].Controls.Add(gridieee);
            tabControl.TabPages[5].Controls.Add(gridscienceDirect);
            if (bazyBoxs[0].Checked == false)
            {
             //   tabControl.TabPages.Remove(tabControl.TabPages[5]);
            }
            if (bazyBoxs[1].Checked == false)
            {
           //     tabControl.TabPages[2].Visible = false;
          //      tabControl.TabPages.Remove(tabControl.TabPages[2]);
            }
            if (bazyBoxs[2].Checked == false)
            {
           //     tabControl.TabPages[3].Visible = false;
           //     tabControl.TabPages.Remove(tabControl.TabPages[1]);
            }
            if (bazyBoxs[3].Checked == false)
            {
            //    tabControl.TabPages[4].Visible = false;
            //    tabControl.TabPages.Remove(tabControl.TabPages[3]);
            }
            if (bazyBoxs[4].Checked == false)
            {
             //   tabControl.TabPages[5].Visible = false;
          //      tabControl.TabPages.Remove(tabControl.TabPages[4]);
            }

            data.Add("source", listy[0]);
            data.Add("title", listy[1]);
            data.Add("journal", listy[2]);
            data.Add("volume", listy[3]);
            data.Add("number", listy[4]);
            data.Add("pages", listy[5]);
            data.Add("year", listy[6]);
            data.Add("note", listy[7]);
            data.Add("issn", listy[8]);
            data.Add("doi", listy[9]);
            data.Add("url", listy[10]);
            data.Add("author", listy[11]);

            OrderedDictionary newdata = Comparator.Comper(data);

            for (int i = 0; i < ((List<string>) newdata["source"]).Count; i++)
            {
                grid.Rows.Add(false, ((List<string>) newdata["source"])[i], ((List<string>) newdata["title"])[i],
                    ((List<string>) newdata["journal"])[i], ((List<string>) newdata["volume"])[i],
                    ((List<string>) newdata["number"])[i], ((List<string>) newdata["pages"])[i],
                    ((List<string>) newdata["year"])[i], ((List<string>) newdata["note"])[i],
                    ((List<string>) newdata["issn"])[i], ((List<string>) newdata["doi"])[i],
                    ((List<string>) newdata["url"])[i], ((List<string>) newdata["author"])[i]);
            }
            tabControl.TabPages[0].Controls.Add(grid);

            Controls.Add(tabControl);

            fcount = ((List<string>) newdata["source"]).Count;
            wyniki.Text = "Wyświetlam następującą ilość wyników: " + ((List<string>) newdata["source"]).Count;

            am = true;
            tabControl.Size = new Size(ClientSize.Width - 100, ClientSize.Height - 200);
            //  pictureBoxmin.Left = (this.ClientSize.Width - pictureBoxmin.Width) - 50;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count > 0)
            {
                if (tabControl.SelectedTab == tabControl.TabPages[0]) //your specific tabname
                {
                    wyniki.Text = "Wyświetlam nastepującą ilość wyników: " + fcount;
                    //  grid.AutoResizeColumns();
                    //    grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    //    grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //    backgroundWorker4.RunWorkerAsync();
                }
                if (tabControl.SelectedTab == tabControl.TabPages[1]) //your specific tabname
                {
                    wyniki.Text = "Znalazłem następującą ilość wyników: " + bazyth.woslist.Count();
                    //    gridwebofscience.AutoResizeColumns();
                    //     gridwebofscience.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    //      gridwebofscience.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    //      backgroundWorker4.RunWorkerAsync();
                }
                if (tabControl.SelectedTab == tabControl.TabPages[2]) //your specific tabname
                {
                    wyniki.Text = "Znalazłem następującą ilość wyników: " + bazyth.scoplist.Count();
                    //    gridscopus.AutoResizeColumns();
                    //      gridscopus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    //            gridscopus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    //  backgroundWorker4.RunWorkerAsync();
                }
                if (tabControl.SelectedTab == tabControl.TabPages[3]) //your specific tabname
                {
                    wyniki.Text = "Znalazłem następującą ilość wyników: " + bazyth.springerlist.Count();
                    //             gridspringer.AutoResizeColumns();
                    //               gridspringer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    //               gridspringer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //    backgroundWorker4.RunWorkerAsync();
                }
                if (tabControl.SelectedTab == tabControl.TabPages[4]) //your specific tabname
                {
                    wyniki.Text = "Znalazłem następującą ilość wyników: " + bazyth.ieeelist.Count();
                    //              gridieee.AutoResizeColumns();
                    //              gridieee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    //              gridieee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //  backgroundWorker4.RunWorkerAsync();
                }
                if (tabControl.SelectedTab == tabControl.TabPages[5]) //your specific tabname
                {
                    wyniki.Text = "Znalazłem następującą ilość wyników: " + bazyth.sdlist.Count();
                    //           gridscienceDirect.AutoResizeColumns();
                    //            gridscienceDirect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    //            gridscienceDirect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //    backgroundWorker4.RunWorkerAsync();
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (i < 4)
            {
                i = BazyTh.Getlthread();
                backgroundWorker1.ReportProgress(i);
                if (BazyTh.Getnamethread()[0])
                {
                    //   bool state = true;
                    // this.Invoke(new labeldelegate(set_label_sd), new object { state });
                    Invoke((MethodInvoker)delegate
                    {
                        label_sd.Text = "gotowe";
                        label_sd.ForeColor = Color.Green;
                    });
                }
                else
                {
                    Invoke((MethodInvoker)delegate
                    {
                        label_sd.Text = "pracuje";
                        label_sd.ForeColor = Color.Red;
                    });
                }
                if (BazyTh.Getnamethread()[1])
                    Invoke((MethodInvoker) delegate
                    {
                        label_Ss.Text = "gotowe";
                        label_Ss.ForeColor = Color.Green;
                    });
                else
                    Invoke((MethodInvoker) delegate
                    {
                        label_Ss.Text = "pracuje";
                        label_Ss.ForeColor = Color.Red;
                    });
                if (BazyTh.Getnamethread()[2])
                    Invoke((MethodInvoker) delegate
                    {
                        labelWOS.Text = "gotowe";
                        labelWOS.ForeColor = Color.Green;
                    });
                else
                    Invoke((MethodInvoker) delegate
                    {
                        labelWOS.Text = "pracuje";
                        labelWOS.ForeColor = Color.Red;
                    });
                if (BazyTh.Getnamethread()[3])
                    Invoke((MethodInvoker) delegate
                    {
                        labelSr.Text = "gotowe";
                        labelSr.ForeColor = Color.Green;
                    });
                else
                    Invoke((MethodInvoker) delegate
                    {
                        labelSr.Text = "pracuje";
                        labelSr.ForeColor = Color.Red;
                    });
                if (BazyTh.Getnamethread()[4])
                    Invoke((MethodInvoker) delegate
                    {
                        labelIEEE.Text = "gotowe";
                        labelIEEE.ForeColor = Color.Green;
                    });
                else
                    Invoke((MethodInvoker) delegate
                    {
                        labelIEEE.Text = "pracuje";
                        labelIEEE.ForeColor = Color.Red;
                    });
                Thread.Sleep(100);
            }
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBoxDownload.BackgroundImage = Resources.down2;
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxDownload.BackgroundImage = Resources.down3;
        }

        private void label_scopus_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            pictureBoxmin.Visible = true;
            pictureBoxmax.Visible = false;
        }

        private void pictureBoxmin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            pictureBoxmin.Visible = false;
            pictureBoxmax.Visible = true;
        }


        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                DataGridViewCell cello = row.Cells["Strona"];
                string sacc = cello.EditedFormattedValue.ToString();
                if (sacc == "Web of science")
                    //|| cello.EditedFormattedValue.ToString() == "Scopus") ; // || row.Cells[0].ToString() == "Scopus")
                {
                    DataGridViewCell cell = grid.Rows[row.Index].Cells[0];
                    var chkCell = new DataGridViewCheckBoxCell();
                    chkCell = cell as DataGridViewCheckBoxCell;
                    chkCell.Value = false;
                    chkCell.FlatStyle = FlatStyle.Flat;
                    chkCell.Style.ForeColor = Color.DarkGray;
                    cell.ReadOnly = true;
                }

                if (sacc == "Scopus")
                {
                    DataGridViewCell cell = grid.Rows[row.Index].Cells[0];
                    var chkCell = new DataGridViewCheckBoxCell();
                    chkCell = cell as DataGridViewCheckBoxCell;
                    chkCell.Value = false;
                    chkCell.FlatStyle = FlatStyle.Flat;
                    chkCell.Style.ForeColor = Color.DarkGray;
                    cell.ReadOnly = true;
                }
            }
        }

        private void pictureBoxmin_MouseHover(object sender, EventArgs e)
        {
            pictureBoxmin.BackgroundImage = Resources.minh;
        }

        private void pictureBoxmax_MouseHover(object sender, EventArgs e)
        {
            pictureBoxmax.BackgroundImage = Resources.maxh;
        }

        private void pictureBoxmax_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxmax.BackgroundImage = Resources.max;
        }

        private void pictureBoxmin_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxmin.BackgroundImage = Resources.min;
        }

        private void pictureBoxOpen_MouseHover(object sender, EventArgs e)
        {
            pictureBoxOpen.BackgroundImage = Resources.open2;
        }

        private void pictureBoxOpen_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxOpen.BackgroundImage = Resources.open;
        }

        private void pictureBoxOpen_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBoxOpen.BackgroundImage = Resources.open3;
        }

        private void pictureBoxBack_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBack.BackgroundImage = Resources.back;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            pdfparser = new PDFParser();
            pdfparser.pdfparser(pdf, pdfname, folderName);
            abstrakty.Clear();
            abstraktyspringer.Clear();
            abstraktyscience.Clear();
            abstraktyiee.Clear();
            //   Thread.Sleep(100);
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarpdf.Visible = false;
            pictureBoxDownload.Enabled = true;
            grid.ClearSelection();
            gridspringer.ClearSelection();
            gridieee.ClearSelection();
            gridscienceDirect.ClearSelection();
            pdf.Clear();
            MessageBox.Show("Ukończono pobieranie!");
            pictureBoxDownload.Enabled = true;
            progressBarpdf.Value = 0;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].Cells[0].Value = false;
            }
            for (int i = 0; i < gridieee.Rows.Count; i++)
            {
                gridieee.Rows[i].Cells[0].Value = false;
            }
            for (int i = 0; i < gridspringer.Rows.Count; i++)
            {
                gridspringer.Rows[i].Cells[0].Value = false;
            }
            for (int i = 0; i < gridscienceDirect.Rows.Count; i++)
            {
                gridscienceDirect.Rows[i].Cells[0].Value = false;
            }
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            int ostatni = 0;
            int i = pdfparser.IEEE.Count() + pdfparser.Science.Count() + pdfparser.Springer.Count();
            Invoke((MethodInvoker) delegate { progressBarpdf.Maximum = i; });
            while (PDFParser.Getlicznik() != i)
            {
                if (PDFParser.Getlicznik() != ostatni)
                {
                    backgroundWorker4.ReportProgress(PDFParser.Getlicznik());
                    ostatni = PDFParser.Getlicznik();
                }
                Thread.Sleep(250);
            }
            foreach (Form fm in forms)
            {
                if (fm.Name == "FormDown")
                {
                    Invoke(
                        (MethodInvoker)
                            delegate { formD.updatelist(pdfparser.Science, pdfparser.Springer, pdfparser.IEEE); });
                }
            }
            PDFParser.Zerujlicznik();
            pdfparser.Sprzataj();
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarpdf.Value = e.ProgressPercentage;
            foreach (Form fm in forms)
            {
                if (fm.Name == "FormDown")
                {
                    Invoke(
                        (MethodInvoker)
                            delegate { formD.updatelist(pdfparser.Science, pdfparser.Springer, pdfparser.IEEE); });
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            tabControl.Size = new Size(ClientSize.Width - 90, ClientSize.Height - 190);
            grid.Size = new Size(tabControl.Size.Width - 8, tabControl.Height - 30);
            gridieee.Size = new Size(tabControl.Size.Width - 8, tabControl.Height - 30);
            gridscienceDirect.Size = new Size(tabControl.Size.Width - 8, tabControl.Height - 30);
            gridscopus.Size = new Size(tabControl.Size.Width - 8, tabControl.Height - 30);
            gridspringer.Size = new Size(tabControl.Size.Width - 8, tabControl.Height - 30);
            gridwebofscience.Size = new Size(tabControl.Size.Width - 8, tabControl.Height - 30);
            if (WindowState == FormWindowState.Normal)
            {
                pictureBoxmax.Visible = true;
                pictureBoxmin.Visible = false;
            }
            if (WindowState == FormWindowState.Maximized)
            {
                pictureBoxmax.Visible = false;
                pictureBoxmin.Visible = true;
            }
        }

        private void populate_Again(DataGridView gridd)
        {
            var temp = new DataGridView();
            if (gridd.Rows.Count > 1)
            {
                foreach (DataGridViewColumn c in gridd.Columns)
                {
                    temp.Columns.Add(c.Clone() as DataGridViewColumn);
                }
                foreach (DataGridViewRow r in gridd.Rows)
                {
                    if (r.Cells[1].Value != null)
                    {
                        int index = temp.Rows.Add(r.Clone() as DataGridViewRow);
                        foreach (DataGridViewCell o in r.Cells)
                        {
                            temp.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                gridd.Rows.Clear();
                foreach (DataGridViewRow r in temp.Rows)
                {
                    if (r.Cells[1].Value != null)
                    {
                        int index = gridd.Rows.Add(r.Clone() as DataGridViewRow);
                        foreach (DataGridViewCell o in r.Cells)
                        {
                            gridd.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker) delegate { formD.ShowDialog(); });
        }

        private void pictureBoxhide_Click(object sender, EventArgs e)
        {
        }

        private void checkBoxyear_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxyear.Checked)
            {
                dtpf.Visible = true;
                dtpt.Visible = true;
                dtpf.Enabled = true;
                dtpt.Enabled = true;
            }
            else
            {
                dtpf.Visible = false;
                dtpt.Visible = false;

                dtpt.Enabled = false;
                dtpf.Enabled = false;
            }
        }

        private void checkBoxScopus_CheckedChanged(object sender, EventArgs e)
        {
        }

        private List<string>[] make_list(BazyTh wos, BazyTh sco, BazyTh sd, BazyTh spr, BazyTh iee)
        {
            var listy = new List<string>[12];
            for (int i = 0; i < 12; i++)
            {
                listy[i] = new List<string>();
            }
            for (int i = 0; i < 100; i++)
            {
                if (i < wos.woslist.Count())
                {
                    listy[0].Add("Web of science");
                    listy[1].Add(wos.woslist[i].title);
                    // listy[1].Add(testwd.zlaczane3.zlaczane2.zlaczane.Woss.title);
                    listy[2].Add(wos.woslist[i].journal);
                    listy[3].Add(wos.woslist[i].volume);
                    listy[4].Add(wos.woslist[i].number);
                    listy[5].Add(wos.woslist[i].pages);
                    listy[6].Add(wos.woslist[i].year);
                    listy[7].Add(" ");
                    listy[8].Add(wos.woslist[i].issn);
                    listy[9].Add(wos.woslist[i].doi);
                    listy[10].Add(" ");
                    listy[11].Add(wos.woslist[i].author);
                }

                if (i < sco.scoplist.Count())
                {
                    listy[0].Add("Scopus");
                    listy[1].Add(sco.scoplist[i].title);
                    listy[2].Add(sco.scoplist[i].journal);
                    listy[3].Add(sco.scoplist[i].volume);
                    listy[4].Add(sco.scoplist[i].number);
                    listy[5].Add(sco.scoplist[i].pages);
                    listy[6].Add(sco.scoplist[i].year);
                    listy[7].Add(sco.scoplist[i].note);
                    listy[8].Add(" ");
                    listy[9].Add(" ");
                    listy[10].Add(sco.scoplist[i].url);
                    listy[11].Add(sco.scoplist[i].author);
                }

                if (i < sd.sdlist.Count())
                {
                    listy[0].Add("Science Direct");
                    listy[1].Add(sd.sdlist[i].title);
                    listy[2].Add(sd.sdlist[i].journal);
                    listy[3].Add(sd.sdlist[i].volume);
                    listy[4].Add(sd.sdlist[i].number);
                    listy[5].Add(sd.sdlist[i].pages);
                    listy[6].Add(sd.sdlist[i].year);
                    listy[7].Add(sd.sdlist[i].note);
                    listy[8].Add(sd.sdlist[i].issn);
                    listy[9].Add(sd.sdlist[i].doi);
                    listy[10].Add(sd.sdlist[i].url);
                    listy[11].Add(sd.sdlist[i].author);
                }

                if (i < spr.springerlist.Count())
                {
                    listy[0].Add("Springer");
                    listy[1].Add(spr.springerlist[i].title);
                    listy[2].Add(spr.springerlist[i].journal);
                    listy[3].Add(spr.springerlist[i].volume);
                    listy[4].Add(" ");
                    listy[5].Add(" ");
                    listy[6].Add(spr.springerlist[i].year);
                    listy[7].Add(" ");
                    listy[8].Add(" ");
                    listy[9].Add(spr.springerlist[i].doi);
                    listy[10].Add(spr.springerlist[i].url);
                    listy[11].Add(spr.springerlist[i].author);
                }

                if (i < iee.ieeelist.Count())
                {
                    listy[0].Add("IEEE");
                    listy[1].Add(iee.ieeelist[i].title);
                    listy[2].Add(iee.ieeelist[i].journal);
                    listy[3].Add(iee.ieeelist[i].volume);
                    listy[4].Add(" ");
                    listy[5].Add(iee.ieeelist[i].pages);
                    listy[6].Add(iee.ieeelist[i].year);
                    listy[7].Add(" ");
                    listy[8].Add(iee.ieeelist[i].issn);
                    listy[9].Add(iee.ieeelist[i].doi);
                    listy[10].Add(iee.ieeelist[i].url);
                    listy[11].Add(iee.ieeelist[i].author);
                }
            }


            return listy;
        }
    }
}