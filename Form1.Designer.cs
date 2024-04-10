namespace TotkRandomizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            progressBar1 = new ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            textBox1 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label7 = new Label();
            panel2 = new Panel();
            label11 = new Label();
            paragliderPatternBox = new ComboBox();
            label2 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            weaponsBox = new ComboBox();
            label5 = new Label();
            natureBox = new ComboBox();
            label4 = new Label();
            chestsBox = new ComboBox();
            label3 = new Label();
            enemiesBox = new ComboBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(18, 282);
            button1.Name = "button1";
            button1.Size = new Size(709, 62);
            button1.TabIndex = 0;
            button1.Text = "Randomize Game!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(18, 249);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(709, 27);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(194, 18);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(394, 23);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 22);
            label1.Name = "label1";
            label1.Size = new Size(170, 15);
            label1.TabIndex = 3;
            label1.Text = "Tears of the Kingdom ROMFS : ";
            // 
            // button2
            // 
            button2.Location = new Point(594, 18);
            button2.Name = "button2";
            button2.Size = new Size(133, 23);
            button2.TabIndex = 4;
            button2.Text = "Browse...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(753, 390);
            tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(progressBar1);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(button2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(15);
            tabPage1.Size = new Size(745, 362);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Generate";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(10);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(15);
            tabPage2.Size = new Size(745, 362);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 109);
            label7.Name = "label7";
            label7.Size = new Size(105, 15);
            label7.TabIndex = 22;
            label7.Text = "Cosmetic Settings:";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label11);
            panel2.Controls.Add(paragliderPatternBox);
            panel2.Location = new Point(18, 117);
            panel2.Margin = new Padding(10);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15);
            panel2.Size = new Size(709, 49);
            panel2.TabIndex = 23;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(18, 15);
            label11.Name = "label11";
            label11.Size = new Size(104, 15);
            label11.TabIndex = 20;
            label11.Text = "Paraglider Pattern:";
            // 
            // paragliderPatternBox
            // 
            paragliderPatternBox.DropDownStyle = ComboBoxStyle.DropDownList;
            paragliderPatternBox.FormattingEnabled = true;
            paragliderPatternBox.Items.AddRange(new object[] { "Random", "Ordinary Fabric", "Goron Fabric", "Zora Fabric", "Gerudo Fabric", "Royal Hyrulean Fabric", "Zonai Fabric", "Sheikah Fabric", "Yiga Fabric", "Monster-Control-Crew Fabric", "Zonai Survey Team Fabric", "Horse-God Fabric", "Lurelin Village Fabric", "Lucky Clover Gazette Fabric", "Hudson Construction Fabric", "Koltin's Fabric", "Korok Fabric", "Grizzlemaw-Bear Fabric", "Robbie's Fabric", "Cece Fabric", "Aerocuda Fabric", "Eldin-Ostrich Fabric", "Cucco Fabric", "Horse Fabric", "Chuchu Fabric", "Lynel Fabric", "Gleeok Fabric", "Stalnox Fabric" });
            paragliderPatternBox.Location = new Point(128, 12);
            paragliderPatternBox.Name = "paragliderPatternBox";
            paragliderPatternBox.Size = new Size(196, 23);
            paragliderPatternBox.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 10);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 20;
            label2.Text = "Randomizer Settings:";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(weaponsBox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(natureBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(chestsBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(enemiesBox);
            panel1.Location = new Point(18, 18);
            panel1.Margin = new Padding(10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(709, 79);
            panel1.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(418, 44);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 26;
            label6.Text = "Weapons:";
            // 
            // weaponsBox
            // 
            weaponsBox.DropDownStyle = ComboBoxStyle.DropDownList;
            weaponsBox.FormattingEnabled = true;
            weaponsBox.Items.AddRange(new object[] { "Default", "Random" });
            weaponsBox.Location = new Point(483, 41);
            weaponsBox.Name = "weaponsBox";
            weaponsBox.Size = new Size(206, 23);
            weaponsBox.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(431, 15);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 24;
            label5.Text = "Nature:";
            // 
            // natureBox
            // 
            natureBox.DropDownStyle = ComboBoxStyle.DropDownList;
            natureBox.FormattingEnabled = true;
            natureBox.Items.AddRange(new object[] { "Default", "Random" });
            natureBox.Location = new Point(483, 12);
            natureBox.Name = "natureBox";
            natureBox.Size = new Size(206, 23);
            natureBox.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 44);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 22;
            label4.Text = "Chests:";
            // 
            // chestsBox
            // 
            chestsBox.DropDownStyle = ComboBoxStyle.DropDownList;
            chestsBox.FormattingEnabled = true;
            chestsBox.Items.AddRange(new object[] { "Default", "Random" });
            chestsBox.Location = new Point(78, 41);
            chestsBox.Name = "chestsBox";
            chestsBox.Size = new Size(206, 23);
            chestsBox.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 15);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 20;
            label3.Text = "Enemies:";
            // 
            // enemiesBox
            // 
            enemiesBox.DropDownStyle = ComboBoxStyle.DropDownList;
            enemiesBox.FormattingEnabled = true;
            enemiesBox.Items.AddRange(new object[] { "Default", "Random" });
            enemiesBox.Location = new Point(78, 12);
            enemiesBox.Name = "enemiesBox";
            enemiesBox.Size = new Size(206, 23);
            enemiesBox.TabIndex = 19;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 390);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "TotK Randomizer";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox textBox1;
        private Label label1;
        private Button button2;
        private CheckBox randomizeEnemies;
        private CheckBox randomizeWeapons;
        private CheckBox randomizeNature;
        private CheckBox randomizeParagliderFabric;
        private CheckBox randomizeChests;
        private CheckBox test;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label2;
        private Panel panel1;
        private Label label3;
        private ComboBox enemiesBox;
        private Label label6;
        private ComboBox weaponsBox;
        private Label label5;
        private ComboBox natureBox;
        private Label label4;
        private ComboBox chestsBox;
        private Label label7;
        private Panel panel2;
        private Label label11;
        private ComboBox paragliderPatternBox;
    }
}