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
            randomizeEnemies = new CheckBox();
            randomizeWeapons = new CheckBox();
            randomizeNature = new CheckBox();
            randomizeParagliderFabric = new CheckBox();
            randomizeChests = new CheckBox();
            test = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(12, 149);
            button1.Name = "button1";
            button1.Size = new Size(588, 64);
            button1.TabIndex = 0;
            button1.Text = "Randomize Game!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 41);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(588, 27);
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
            textBox1.Location = new Point(188, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(273, 23);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(170, 15);
            label1.TabIndex = 3;
            label1.Text = "Tears of the Kingdom ROMFS : ";
            // 
            // button2
            // 
            button2.Location = new Point(467, 12);
            button2.Name = "button2";
            button2.Size = new Size(133, 23);
            button2.TabIndex = 4;
            button2.Text = "Browse...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // randomizeEnemies
            // 
            randomizeEnemies.AutoSize = true;
            randomizeEnemies.Checked = true;
            randomizeEnemies.CheckState = CheckState.Checked;
            randomizeEnemies.Location = new Point(12, 74);
            randomizeEnemies.Name = "randomizeEnemies";
            randomizeEnemies.Size = new Size(132, 19);
            randomizeEnemies.TabIndex = 6;
            randomizeEnemies.Text = "Randomize Enemies";
            randomizeEnemies.UseVisualStyleBackColor = true;
            // 
            // randomizeWeapons
            // 
            randomizeWeapons.AutoSize = true;
            randomizeWeapons.Checked = true;
            randomizeWeapons.CheckState = CheckState.Checked;
            randomizeWeapons.Location = new Point(12, 99);
            randomizeWeapons.Name = "randomizeWeapons";
            randomizeWeapons.Size = new Size(137, 19);
            randomizeWeapons.TabIndex = 7;
            randomizeWeapons.Text = "Randomize Weapons";
            randomizeWeapons.UseVisualStyleBackColor = true;
            // 
            // randomizeNature
            // 
            randomizeNature.AutoSize = true;
            randomizeNature.Checked = true;
            randomizeNature.CheckState = CheckState.Checked;
            randomizeNature.Location = new Point(12, 124);
            randomizeNature.Name = "randomizeNature";
            randomizeNature.Size = new Size(124, 19);
            randomizeNature.TabIndex = 8;
            randomizeNature.Text = "Randomize Nature";
            randomizeNature.UseVisualStyleBackColor = true;
            // 
            // randomizeParagliderFabric
            // 
            randomizeParagliderFabric.AutoSize = true;
            randomizeParagliderFabric.Checked = true;
            randomizeParagliderFabric.CheckState = CheckState.Checked;
            randomizeParagliderFabric.Location = new Point(424, 99);
            randomizeParagliderFabric.Name = "randomizeParagliderFabric";
            randomizeParagliderFabric.RightToLeft = RightToLeft.Yes;
            randomizeParagliderFabric.Size = new Size(176, 19);
            randomizeParagliderFabric.TabIndex = 9;
            randomizeParagliderFabric.Text = "Randomize Paraglider Fabric";
            randomizeParagliderFabric.UseVisualStyleBackColor = true;
            // 
            // randomizeChests
            // 
            randomizeChests.AutoSize = true;
            randomizeChests.Checked = true;
            randomizeChests.CheckState = CheckState.Checked;
            randomizeChests.Location = new Point(477, 74);
            randomizeChests.Name = "randomizeChests";
            randomizeChests.RightToLeft = RightToLeft.Yes;
            randomizeChests.Size = new Size(123, 19);
            randomizeChests.TabIndex = 11;
            randomizeChests.Text = "Randomize Chests";
            randomizeChests.UseVisualStyleBackColor = true;
            // 
            // test
            // 
            test.AutoSize = true;
            test.Enabled = false;
            test.Location = new Point(559, 124);
            test.Name = "test";
            test.RightToLeft = RightToLeft.Yes;
            test.Size = new Size(41, 19);
            test.TabIndex = 12;
            test.Text = "???";
            test.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 225);
            Controls.Add(test);
            Controls.Add(randomizeChests);
            Controls.Add(randomizeParagliderFabric);
            Controls.Add(randomizeNature);
            Controls.Add(randomizeWeapons);
            Controls.Add(randomizeEnemies);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "TotK Randomizer";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
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
    }
}