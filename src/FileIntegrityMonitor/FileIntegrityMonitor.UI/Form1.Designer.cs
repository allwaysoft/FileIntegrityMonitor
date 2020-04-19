namespace FileIntegrityMonitor.UI
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
            this.NewScanPanel = new System.Windows.Forms.Panel();
            this.ScanFolderSelector = new System.Windows.Forms.Button();
            this.RecursiveCheckBox = new System.Windows.Forms.CheckBox();
            this.HashAlgorithmsList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.scanningProgressBar = new System.Windows.Forms.ProgressBar();
            this.FolderToScanTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.NewScanPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NewScanPanel
            // 
            this.NewScanPanel.Controls.Add(this.ScanFolderSelector);
            this.NewScanPanel.Controls.Add(this.RecursiveCheckBox);
            this.NewScanPanel.Controls.Add(this.HashAlgorithmsList);
            this.NewScanPanel.Controls.Add(this.label2);
            this.NewScanPanel.Controls.Add(this.button1);
            this.NewScanPanel.Controls.Add(this.ProgressLabel);
            this.NewScanPanel.Controls.Add(this.scanningProgressBar);
            this.NewScanPanel.Controls.Add(this.FolderToScanTextBox);
            this.NewScanPanel.Controls.Add(this.label1);
            this.NewScanPanel.Location = new System.Drawing.Point(113, 207);
            this.NewScanPanel.Name = "NewScanPanel";
            this.NewScanPanel.Size = new System.Drawing.Size(881, 704);
            this.NewScanPanel.TabIndex = 0;
            // 
            // ScanFolderSelector
            // 
            this.ScanFolderSelector.Location = new System.Drawing.Point(831, 15);
            this.ScanFolderSelector.Name = "ScanFolderSelector";
            this.ScanFolderSelector.Size = new System.Drawing.Size(33, 23);
            this.ScanFolderSelector.TabIndex = 8;
            this.ScanFolderSelector.Text = "...";
            this.ScanFolderSelector.UseVisualStyleBackColor = true;
            this.ScanFolderSelector.Click += new System.EventHandler(this.ScanFolderSelector_Click);
            // 
            // RecursiveCheckBox
            // 
            this.RecursiveCheckBox.AutoSize = true;
            this.RecursiveCheckBox.Checked = true;
            this.RecursiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RecursiveCheckBox.Location = new System.Drawing.Point(312, 47);
            this.RecursiveCheckBox.Name = "RecursiveCheckBox";
            this.RecursiveCheckBox.Size = new System.Drawing.Size(93, 21);
            this.RecursiveCheckBox.TabIndex = 7;
            this.RecursiveCheckBox.Text = "Recursive";
            this.RecursiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // HashAlgorithmsList
            // 
            this.HashAlgorithmsList.FormattingEnabled = true;
            this.HashAlgorithmsList.Items.AddRange(new object[] {
            "Sha256",
            "Sha512"});
            this.HashAlgorithmsList.Location = new System.Drawing.Point(125, 44);
            this.HashAlgorithmsList.Name = "HashAlgorithmsList";
            this.HashAlgorithmsList.Size = new System.Drawing.Size(172, 24);
            this.HashAlgorithmsList.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Algorithm:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(739, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start new scan ...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(122, 147);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(73, 17);
            this.ProgressLabel.TabIndex = 3;
            this.ProgressLabel.Text = "Starting ...";
            // 
            // scanningProgressBar
            // 
            this.scanningProgressBar.Location = new System.Drawing.Point(125, 121);
            this.scanningProgressBar.Name = "scanningProgressBar";
            this.scanningProgressBar.Size = new System.Drawing.Size(739, 23);
            this.scanningProgressBar.TabIndex = 2;
            // 
            // FolderToScanTextBox
            // 
            this.FolderToScanTextBox.Location = new System.Drawing.Point(125, 15);
            this.FolderToScanTextBox.Name = "FolderToScanTextBox";
            this.FolderToScanTextBox.Size = new System.Drawing.Size(699, 22);
            this.FolderToScanTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder to scan:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // LogoBox
            // 
            this.LogoBox.Location = new System.Drawing.Point(2, -2);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(935, 203);
            this.LogoBox.TabIndex = 1;
            this.LogoBox.TabStop = false;
            this.LogoBox.Paint += new System.Windows.Forms.PaintEventHandler(this.LogoBox_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1006, 739);
            this.Controls.Add(this.LogoBox);
            this.Controls.Add(this.NewScanPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.NewScanPanel.ResumeLayout(false);
            this.NewScanPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel NewScanPanel;
        private System.Windows.Forms.TextBox FolderToScanTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar scanningProgressBar;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox HashAlgorithmsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox RecursiveCheckBox;
        private System.Windows.Forms.Button ScanFolderSelector;
        private System.Windows.Forms.PictureBox LogoBox;
    }
}

