using System;
using System.Windows.Forms;
using ReaLTaiizor.Enum.Poison;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Controls;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace CouInjector_Auto_Update
{
    public partial class Form1 : PoisonForm
    {
        string AppPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public Form1()
        {
            InitializeComponent();
            BorderStyle = ReaLTaiizor.Enum.Poison.FormBorderStyle.FixedSingle;
            ShadowType = FormShadowType.AeroShadow;

        }

        private void poisonButton_Click(object sender, EventArgs e)
        {
            poisonButton.Enabled = false;
            System.Threading.Thread DoTasksforDownloading = new System.Threading.Thread(Threading);
            DoTasksforDownloading.Start();
            while (DoTasksforDownloading.IsAlive)
                Application.DoEvents();

            poisonLabel.Text = "[^]-Downloading new version...";
            var webclient = new WebClient();
            var uri = new Uri("https://bymynix.de/couinjector/CouInjector.exe");

            webclient.DownloadFileCompleted += webclient_DownloadDataCompleted;
            webclient.DownloadProgressChanged += DownloadProgressChanged;

            webclient.DownloadFileAsync(uri, AppPath + @"\CouInjector.exe");
        }

        private void Threading()
        {
            poisonLabel.Text = "[^]-Closing CouInjector...";
            Process T = new Process();
            {
                var withBlock = T;
                foreach (Process p1 in Process.GetProcessesByName("CouInjector"))
                    p1.Kill();
            }
            System.Threading.Thread.Sleep(1000);
            aloneProgressBar1.Value = 5;
            System.Threading.Thread.Sleep(1000);
            aloneProgressBar1.Value = 10;
            poisonLabel.Text = "[^]-Deleting old version...";
            File.Delete(AppPath + @"\CouInjector.exe");
            System.Threading.Thread.Sleep(1000);
            aloneProgressBar1.Value = 15;
            System.Threading.Thread.Sleep(1000);
            aloneProgressBar1.Value = 20;
        }

        private void DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            aloneProgressBar1.Minimum = 20;
            aloneProgressBar1.Value = e.ProgressPercentage;
        }
        private void webclient_DownloadDataCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            PoisonMessageBox.Show(this, "Update successfully downloaded. CouInjector starts automatically after clicking 'Ok'.", "CouInjector: Auto-Updater", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Process.Start(AppPath + @"\CouInjector.exe");
            Application.Exit();
        }
    }
}
