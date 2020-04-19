using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileIntegrityMonitor.DTO;

namespace FileIntegrityMonitor.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            StartScanForms();
        }

        private void StartScanForms()
        {
            if (String.IsNullOrWhiteSpace(Folder)) { return; }

            Scan scan = new Scan
            {
                FilePath = Folder,
                HashAlgorithm = Algorithm,
                Time = DateTime.Now
            };

            scan.Insert();

            List<string> allFiles = DirectoryParser.GetAllFiles(Folder, Recursive);

            int nFiles = allFiles.Count;
            int i = 0;

            foreach (string file in allFiles)
            {
                try
                {
                    FileScan.ScanFile(file, scan);
                    int progress = (int)Math.Ceiling((double)i / nFiles) * 100;

                    backgroundWorker1.ReportProgress(progress, (object) file);
                    i++;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }

        private string Folder { get; set; }
        private FIMHashAlgorithm Algorithm { get; set; }
        private bool Recursive { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            SetScanProperties();

            int numberOfFiles = DirectoryParser.GetAllFiles(Folder, Recursive).Count;
            backgroundWorker1.RunWorkerAsync(numberOfFiles);
        }

        private void SetScanProperties()
        {
            Folder = FolderToScanTextBox.Text;
            Recursive = RecursiveCheckBox.Checked;

            Algorithm = new FIMHashAlgorithm();

            if (HashAlgorithmsList.SelectedText == "sha256")
            {
                Algorithm.Id = 1;
            }
            else
            {
                Algorithm.Id = 2;
            }

            Algorithm.AlgorithmText = HashAlgorithmsList.SelectedText;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            scanningProgressBar.Value = e.ProgressPercentage;
            ProgressLabel.Text = "Processing file: " + e.UserState.ToString();
        }

        private void ScanFolderSelector_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                FolderToScanTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Image image = Bitmap.FromFile("fim.png");
            double newWidth = image.Width / 1.35f;
            double newHeight = image.Height / 1.35f;

            Image newImage = new Bitmap((int)newWidth, (int)newHeight);

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.DrawImage(image, new Rectangle(new Point(0, 0), newImage.Size));
            }

            LogoBox.Image = newImage;
        }

        private void LogoBox_Paint(object sender, PaintEventArgs e)
        {
            

        }
    }
}
