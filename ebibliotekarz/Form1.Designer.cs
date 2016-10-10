using Microsoft.Win32;

namespace ebibliotekarz
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxX = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinim = new System.Windows.Forms.PictureBox();
            this.pictureBoxQuestion = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labeltemp = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxOpen = new System.Windows.Forms.PictureBox();
            this.pictureBoxHistory = new System.Windows.Forms.PictureBox();
            this.pictureBoxSave = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxDownload = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.label_science = new System.Windows.Forms.Label();
            this.label_scopus = new System.Windows.Forms.Label();
            this.label_wos = new System.Windows.Forms.Label();
            this.label_springer = new System.Windows.Forms.Label();
            this.label_ieee = new System.Windows.Forms.Label();
            this.labelIEEE = new System.Windows.Forms.Label();
            this.labelSr = new System.Windows.Forms.Label();
            this.labelWOS = new System.Windows.Forms.Label();
            this.label_Ss = new System.Windows.Forms.Label();
            this.label_sd = new System.Windows.Forms.Label();
            this.pictureBoxline = new System.Windows.Forms.PictureBox();
            this.pictureBoxmax = new System.Windows.Forms.PictureBox();
            this.pictureBoxmin = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.progressBarpdf = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker5 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker6 = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxhide = new System.Windows.Forms.PictureBox();
            this.checkBoxyear = new System.Windows.Forms.CheckBox();
            this.checkBoxScience = new System.Windows.Forms.CheckBox();
            this.checkBoxScopus = new System.Windows.Forms.CheckBox();
            this.checkBoxWos = new System.Windows.Forms.CheckBox();
            this.checkBoxSpringer = new System.Windows.Forms.CheckBox();
            this.checkBoxIEEE = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxhide)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSearch.BackColor = System.Drawing.Color.White;
            this.textBoxSearch.Location = new System.Drawing.Point(100, 284);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(200, 20);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.Text = "Szukaj";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.Leave += new System.EventHandler(this.textBoxSearch_Leave);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBoxX
            // 
            this.pictureBoxX.BackgroundImage = global::ebibliotekarz.Properties.Resources.x1;
            this.pictureBoxX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxX.Location = new System.Drawing.Point(741, 7);
            this.pictureBoxX.Name = "pictureBoxX";
            this.pictureBoxX.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxX.TabIndex = 3;
            this.pictureBoxX.TabStop = false;
            this.pictureBoxX.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBoxX.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBoxX.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // pictureBoxMinim
            // 
            this.pictureBoxMinim.BackgroundImage = global::ebibliotekarz.Properties.Resources._1;
            this.pictureBoxMinim.Location = new System.Drawing.Point(634, 7);
            this.pictureBoxMinim.Name = "pictureBoxMinim";
            this.pictureBoxMinim.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxMinim.TabIndex = 4;
            this.pictureBoxMinim.TabStop = false;
            this.pictureBoxMinim.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBoxMinim.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.pictureBoxMinim.MouseHover += new System.EventHandler(this.pictureBox3_MouseHover);
            // 
            // pictureBoxQuestion
            // 
            this.pictureBoxQuestion.BackgroundImage = global::ebibliotekarz.Properties.Resources.z1;
            this.pictureBoxQuestion.Location = new System.Drawing.Point(578, 7);
            this.pictureBoxQuestion.Name = "pictureBoxQuestion";
            this.pictureBoxQuestion.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxQuestion.TabIndex = 5;
            this.pictureBoxQuestion.TabStop = false;
            this.pictureBoxQuestion.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pictureBoxQuestion.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            this.pictureBoxQuestion.MouseHover += new System.EventHandler(this.pictureBox4_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(28, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox5.BackgroundImage = global::ebibliotekarz.Properties.Resources.szukaj;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(256, 408);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(287, 55);
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.buttonSearch_Click);
            this.pictureBox5.MouseLeave += new System.EventHandler(this.buttonSearch_MouseLeave);
            this.pictureBox5.MouseHover += new System.EventHandler(this.buttonSearch_MouseHover);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // labeltemp
            // 
            this.labeltemp.AutoSize = true;
            this.labeltemp.Location = new System.Drawing.Point(223, 197);
            this.labeltemp.Name = "labeltemp";
            this.labeltemp.Size = new System.Drawing.Size(108, 13);
            this.labeltemp.TabIndex = 11;
            this.labeltemp.Text = "Wczytywanie danych";
            this.labeltemp.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // pictureBoxOpen
            // 
            this.pictureBoxOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxOpen.Location = new System.Drawing.Point(648, 118);
            this.pictureBoxOpen.Name = "pictureBoxOpen";
            this.pictureBoxOpen.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOpen.TabIndex = 16;
            this.pictureBoxOpen.TabStop = false;
            this.pictureBoxOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            this.pictureBoxOpen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOpen_MouseClick);
            this.pictureBoxOpen.MouseLeave += new System.EventHandler(this.pictureBoxOpen_MouseLeave);
            this.pictureBoxOpen.MouseHover += new System.EventHandler(this.pictureBoxOpen_MouseHover);
            // 
            // pictureBoxHistory
            // 
            this.pictureBoxHistory.Location = new System.Drawing.Point(718, 118);
            this.pictureBoxHistory.Name = "pictureBoxHistory";
            this.pictureBoxHistory.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxHistory.TabIndex = 18;
            this.pictureBoxHistory.TabStop = false;
            this.pictureBoxHistory.BackgroundImageChanged += new System.EventHandler(this.pictureBoxHistory_BackgroundImageChanged);
            this.pictureBoxHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            this.pictureBoxHistory.MouseLeave += new System.EventHandler(this.pictureBoxHistory_MouseLeave);
            this.pictureBoxHistory.MouseHover += new System.EventHandler(this.pictureBoxHistory_MouseHover);
            // 
            // pictureBoxSave
            // 
            this.pictureBoxSave.Location = new System.Drawing.Point(718, 118);
            this.pictureBoxSave.Name = "pictureBoxSave";
            this.pictureBoxSave.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxSave.TabIndex = 19;
            this.pictureBoxSave.TabStop = false;
            this.pictureBoxSave.Click += new System.EventHandler(this.buttonSave_Click);
            this.pictureBoxSave.MouseHover += new System.EventHandler(this.pictureBoxSave_MouseHover);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pictureBoxDownload
            // 
            this.pictureBoxDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxDownload.Location = new System.Drawing.Point(578, 118);
            this.pictureBoxDownload.Name = "pictureBoxDownload";
            this.pictureBoxDownload.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxDownload.TabIndex = 21;
            this.pictureBoxDownload.TabStop = false;
            this.pictureBoxDownload.Click += new System.EventHandler(this.button1_Click_1);
            this.pictureBoxDownload.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox7_MouseDown);
            this.pictureBoxDownload.MouseHover += new System.EventHandler(this.pictureBox7_MouseHover);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(100, 463);
            this.progressBar1.Maximum = 5;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(596, 33);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 22;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // label_science
            // 
            this.label_science.AutoSize = true;
            this.label_science.BackColor = System.Drawing.Color.Transparent;
            this.label_science.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_science.Location = new System.Drawing.Point(301, 336);
            this.label_science.Name = "label_science";
            this.label_science.Size = new System.Drawing.Size(95, 17);
            this.label_science.TabIndex = 23;
            this.label_science.Text = "ScienceDirect";
            // 
            // label_scopus
            // 
            this.label_scopus.AutoSize = true;
            this.label_scopus.BackColor = System.Drawing.Color.Transparent;
            this.label_scopus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_scopus.Location = new System.Drawing.Point(301, 352);
            this.label_scopus.Name = "label_scopus";
            this.label_scopus.Size = new System.Drawing.Size(55, 17);
            this.label_scopus.TabIndex = 24;
            this.label_scopus.Text = "Scopus";
            this.label_scopus.Click += new System.EventHandler(this.label_scopus_Click);
            // 
            // label_wos
            // 
            this.label_wos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_wos.AutoSize = true;
            this.label_wos.BackColor = System.Drawing.Color.Transparent;
            this.label_wos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_wos.Location = new System.Drawing.Point(301, 369);
            this.label_wos.Name = "label_wos";
            this.label_wos.Size = new System.Drawing.Size(102, 17);
            this.label_wos.TabIndex = 25;
            this.label_wos.Text = "WebOfScience";
            // 
            // label_springer
            // 
            this.label_springer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_springer.AutoSize = true;
            this.label_springer.BackColor = System.Drawing.Color.Transparent;
            this.label_springer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_springer.Location = new System.Drawing.Point(301, 386);
            this.label_springer.Name = "label_springer";
            this.label_springer.Size = new System.Drawing.Size(62, 17);
            this.label_springer.TabIndex = 26;
            this.label_springer.Text = "Springer";
            // 
            // label_ieee
            // 
            this.label_ieee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ieee.AutoSize = true;
            this.label_ieee.BackColor = System.Drawing.Color.Transparent;
            this.label_ieee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_ieee.Location = new System.Drawing.Point(301, 403);
            this.label_ieee.Name = "label_ieee";
            this.label_ieee.Size = new System.Drawing.Size(38, 17);
            this.label_ieee.TabIndex = 27;
            this.label_ieee.Text = "IEEE";
            // 
            // labelIEEE
            // 
            this.labelIEEE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIEEE.AutoSize = true;
            this.labelIEEE.BackColor = System.Drawing.Color.Transparent;
            this.labelIEEE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelIEEE.Location = new System.Drawing.Point(419, 403);
            this.labelIEEE.Name = "labelIEEE";
            this.labelIEEE.Size = new System.Drawing.Size(39, 17);
            this.labelIEEE.TabIndex = 32;
            this.labelIEEE.Text = "temp";
            // 
            // labelSr
            // 
            this.labelSr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSr.AutoSize = true;
            this.labelSr.BackColor = System.Drawing.Color.Transparent;
            this.labelSr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelSr.Location = new System.Drawing.Point(419, 386);
            this.labelSr.Name = "labelSr";
            this.labelSr.Size = new System.Drawing.Size(39, 17);
            this.labelSr.TabIndex = 31;
            this.labelSr.Text = "temp";
            // 
            // labelWOS
            // 
            this.labelWOS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWOS.AutoSize = true;
            this.labelWOS.BackColor = System.Drawing.Color.Transparent;
            this.labelWOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelWOS.Location = new System.Drawing.Point(419, 369);
            this.labelWOS.Name = "labelWOS";
            this.labelWOS.Size = new System.Drawing.Size(39, 17);
            this.labelWOS.TabIndex = 30;
            this.labelWOS.Text = "temp";
            // 
            // label_Ss
            // 
            this.label_Ss.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Ss.AutoSize = true;
            this.label_Ss.BackColor = System.Drawing.Color.Transparent;
            this.label_Ss.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_Ss.Location = new System.Drawing.Point(419, 352);
            this.label_Ss.Name = "label_Ss";
            this.label_Ss.Size = new System.Drawing.Size(39, 17);
            this.label_Ss.TabIndex = 29;
            this.label_Ss.Text = "temp";
            // 
            // label_sd
            // 
            this.label_sd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_sd.AutoSize = true;
            this.label_sd.BackColor = System.Drawing.Color.Transparent;
            this.label_sd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_sd.Location = new System.Drawing.Point(419, 335);
            this.label_sd.Name = "label_sd";
            this.label_sd.Size = new System.Drawing.Size(39, 17);
            this.label_sd.TabIndex = 28;
            this.label_sd.Text = "temp";
            // 
            // pictureBoxline
            // 
            this.pictureBoxline.BackgroundImage = global::ebibliotekarz.Properties.Resources.Bez_tytułu;
            this.pictureBoxline.Location = new System.Drawing.Point(150, 276);
            this.pictureBoxline.Name = "pictureBoxline";
            this.pictureBoxline.Size = new System.Drawing.Size(500, 2);
            this.pictureBoxline.TabIndex = 33;
            this.pictureBoxline.TabStop = false;
            this.pictureBoxline.Visible = false;
            // 
            // pictureBoxmax
            // 
            this.pictureBoxmax.BackgroundImage = global::ebibliotekarz.Properties.Resources.max1;
            this.pictureBoxmax.Location = new System.Drawing.Point(690, 9);
            this.pictureBoxmax.Name = "pictureBoxmax";
            this.pictureBoxmax.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxmax.TabIndex = 39;
            this.pictureBoxmax.TabStop = false;
            this.pictureBoxmax.Click += new System.EventHandler(this.pictureBox8_Click);
            this.pictureBoxmax.MouseLeave += new System.EventHandler(this.pictureBoxmax_MouseLeave);
            this.pictureBoxmax.MouseHover += new System.EventHandler(this.pictureBoxmax_MouseHover);
            // 
            // pictureBoxmin
            // 
            this.pictureBoxmin.BackgroundImage = global::ebibliotekarz.Properties.Resources.min;
            this.pictureBoxmin.Location = new System.Drawing.Point(690, 7);
            this.pictureBoxmin.Name = "pictureBoxmin";
            this.pictureBoxmin.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxmin.TabIndex = 40;
            this.pictureBoxmin.TabStop = false;
            this.pictureBoxmin.Visible = false;
            this.pictureBoxmin.Click += new System.EventHandler(this.pictureBoxmin_Click);
            this.pictureBoxmin.MouseLeave += new System.EventHandler(this.pictureBoxmin_MouseLeave);
            this.pictureBoxmin.MouseHover += new System.EventHandler(this.pictureBoxmin_MouseHover);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = global::ebibliotekarz.Properties.Resources.logo;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox8.Location = new System.Drawing.Point(31, 11);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(365, 50);
            this.pictureBox8.TabIndex = 41;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.Location = new System.Drawing.Point(508, 118);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxBack.TabIndex = 17;
            this.pictureBoxBack.TabStop = false;
            this.pictureBoxBack.Click += new System.EventHandler(this.button1_Click);
            this.pictureBoxBack.MouseEnter += new System.EventHandler(this.pictureBoxBack_MouseEnter);
            this.pictureBoxBack.MouseLeave += new System.EventHandler(this.pictureBoxBack_MouseLeave);
            this.pictureBoxBack.MouseHover += new System.EventHandler(this.pictureBoxBack_MouseHover);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // progressBarpdf
            // 
            this.progressBarpdf.Location = new System.Drawing.Point(613, 576);
            this.progressBarpdf.Maximum = 5;
            this.progressBarpdf.Name = "progressBarpdf";
            this.progressBarpdf.Size = new System.Drawing.Size(181, 19);
            this.progressBarpdf.Step = 1;
            this.progressBarpdf.TabIndex = 44;
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.WorkerReportsProgress = true;
            this.backgroundWorker4.WorkerSupportsCancellation = true;
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            this.backgroundWorker4.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker4_ProgressChanged);
            this.backgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker4_RunWorkerCompleted);
            // 
            // backgroundWorker5
            // 
            this.backgroundWorker5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker5_DoWork);
            // 
            // pictureBoxhide
            // 
            this.pictureBoxhide.BackgroundImage = global::ebibliotekarz.Properties.Resources.background;
            this.pictureBoxhide.Location = new System.Drawing.Point(2, 9);
            this.pictureBoxhide.Name = "pictureBoxhide";
            this.pictureBoxhide.Size = new System.Drawing.Size(792, 584);
            this.pictureBoxhide.TabIndex = 34;
            this.pictureBoxhide.TabStop = false;
            this.pictureBoxhide.Visible = false;
            this.pictureBoxhide.Click += new System.EventHandler(this.pictureBoxhide_Click);
            // 
            // checkBoxyear
            // 
            this.checkBoxyear.AutoSize = true;
            this.checkBoxyear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxyear.Location = new System.Drawing.Point(272, 538);
            this.checkBoxyear.Name = "checkBoxyear";
            this.checkBoxyear.Size = new System.Drawing.Size(60, 24);
            this.checkBoxyear.TabIndex = 45;
            this.checkBoxyear.Text = "Lata";
            this.checkBoxyear.UseVisualStyleBackColor = true;
            this.checkBoxyear.CheckedChanged += new System.EventHandler(this.checkBoxyear_CheckedChanged);
            // 
            // checkBoxScience
            // 
            this.checkBoxScience.AutoSize = true;
            this.checkBoxScience.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxScience.Location = new System.Drawing.Point(135, 469);
            this.checkBoxScience.Name = "checkBoxScience";
            this.checkBoxScience.Size = new System.Drawing.Size(131, 24);
            this.checkBoxScience.TabIndex = 46;
            this.checkBoxScience.Text = "Science Direct";
            this.checkBoxScience.UseVisualStyleBackColor = true;
            // 
            // checkBoxScopus
            // 
            this.checkBoxScopus.AutoSize = true;
            this.checkBoxScopus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxScopus.Location = new System.Drawing.Point(272, 469);
            this.checkBoxScopus.Name = "checkBoxScopus";
            this.checkBoxScopus.Size = new System.Drawing.Size(82, 24);
            this.checkBoxScopus.TabIndex = 47;
            this.checkBoxScopus.Text = "Scopus";
            this.checkBoxScopus.UseVisualStyleBackColor = true;
            this.checkBoxScopus.CheckedChanged += new System.EventHandler(this.checkBoxScopus_CheckedChanged);
            // 
            // checkBoxWos
            // 
            this.checkBoxWos.AutoSize = true;
            this.checkBoxWos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxWos.Location = new System.Drawing.Point(362, 469);
            this.checkBoxWos.Name = "checkBoxWos";
            this.checkBoxWos.Size = new System.Drawing.Size(140, 24);
            this.checkBoxWos.TabIndex = 48;
            this.checkBoxWos.Text = "Web of Science";
            this.checkBoxWos.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpringer
            // 
            this.checkBoxSpringer.AutoSize = true;
            this.checkBoxSpringer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxSpringer.Location = new System.Drawing.Point(508, 469);
            this.checkBoxSpringer.Name = "checkBoxSpringer";
            this.checkBoxSpringer.Size = new System.Drawing.Size(88, 24);
            this.checkBoxSpringer.TabIndex = 49;
            this.checkBoxSpringer.Text = "Springer";
            this.checkBoxSpringer.UseVisualStyleBackColor = true;
            // 
            // checkBoxIEEE
            // 
            this.checkBoxIEEE.AutoSize = true;
            this.checkBoxIEEE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxIEEE.Location = new System.Drawing.Point(605, 469);
            this.checkBoxIEEE.Name = "checkBoxIEEE";
            this.checkBoxIEEE.Size = new System.Drawing.Size(66, 24);
            this.checkBoxIEEE.TabIndex = 50;
            this.checkBoxIEEE.Text = "IEEE";
            this.checkBoxIEEE.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(792, 599);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxIEEE);
            this.Controls.Add(this.checkBoxSpringer);
            this.Controls.Add(this.checkBoxWos);
            this.Controls.Add(this.checkBoxScopus);
            this.Controls.Add(this.checkBoxScience);
            this.Controls.Add(this.checkBoxyear);
            this.Controls.Add(this.progressBarpdf);
            this.Controls.Add(this.pictureBoxline);
            this.Controls.Add(this.labeltemp);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxmax);
            this.Controls.Add(this.pictureBoxX);
            this.Controls.Add(this.pictureBoxMinim);
            this.Controls.Add(this.pictureBoxmin);
            this.Controls.Add(this.pictureBoxQuestion);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelIEEE);
            this.Controls.Add(this.labelSr);
            this.Controls.Add(this.labelWOS);
            this.Controls.Add(this.label_Ss);
            this.Controls.Add(this.label_sd);
            this.Controls.Add(this.label_ieee);
            this.Controls.Add(this.label_springer);
            this.Controls.Add(this.label_wos);
            this.Controls.Add(this.label_scopus);
            this.Controls.Add(this.label_science);
            this.Controls.Add(this.pictureBoxDownload);
            this.Controls.Add(this.pictureBoxSave);
            this.Controls.Add(this.pictureBoxHistory);
            this.Controls.Add(this.pictureBoxBack);
            this.Controls.Add(this.pictureBoxOpen);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.pictureBoxhide);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eBibliotekarz";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxhide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBoxX;
        private System.Windows.Forms.PictureBox pictureBoxMinim;
        private System.Windows.Forms.PictureBox pictureBoxQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labeltemp;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBoxOpen;
        private System.Windows.Forms.PictureBox pictureBoxHistory;
        private System.Windows.Forms.PictureBox pictureBoxSave;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBoxDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label_science;
        private System.Windows.Forms.Label label_scopus;
        private System.Windows.Forms.Label label_wos;
        private System.Windows.Forms.Label label_springer;
        private System.Windows.Forms.Label label_ieee;
        private System.Windows.Forms.Label labelIEEE;
        private System.Windows.Forms.Label labelSr;
        private System.Windows.Forms.Label labelWOS;
        private System.Windows.Forms.Label label_Ss;
        private System.Windows.Forms.Label label_sd;
        private System.Windows.Forms.PictureBox pictureBoxline;
        private System.Windows.Forms.PictureBox pictureBoxmax;
        private System.Windows.Forms.PictureBox pictureBoxmin;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBoxBack;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.ProgressBar progressBarpdf;
        public System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.ComponentModel.BackgroundWorker backgroundWorker5;
        private System.ComponentModel.BackgroundWorker backgroundWorker6;
        private System.Windows.Forms.PictureBox pictureBoxhide;
        private System.Windows.Forms.CheckBox checkBoxyear;
        private System.Windows.Forms.CheckBox checkBoxScience;
        private System.Windows.Forms.CheckBox checkBoxScopus;
        private System.Windows.Forms.CheckBox checkBoxWos;
        private System.Windows.Forms.CheckBox checkBoxSpringer;
        private System.Windows.Forms.CheckBox checkBoxIEEE;
    }
}

