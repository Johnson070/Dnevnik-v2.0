﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik.DnevnikClasses
{
    class CheckUpdate
    {
        private StatusStrip strip;
        private ToolStripProgressBar bar;
        private ToolStripLabel label;
        private string nameFile;

        public string GetVersion()
        {
            string version = "";

            using (WebClient Client = new WebClient())
            {
                Client.Encoding = Encoding.UTF8;
                version = Client.DownloadString("https://raw.githubusercontent.com/Johnson070/Dnevnik-v2.0/master/version.txt");
            }

            return version;
        }

        public string CheckProgramUpdate()
        {
            string version = "";

            using (WebClient Client = new WebClient())
            {
                Client.Encoding = Encoding.UTF8;
                version = Client.DownloadString("https://raw.githubusercontent.com/Johnson070/Dnevnik-v2.0/master/version.txt");
            }

            return "Ваша версиия программы " + Application.ProductVersion + ".\n\rВерсия загруженая на сервере " + version;
        }

        void StartDownload(String url, string saveFile)
        {
            strip.Visible = true;

            bar.Value = 0;
            bar.Style = ProgressBarStyle.Continuous;
            label.Text = "";

            Uri uri = new Uri(url);

            using WebClient web = new WebClient();
            web.DownloadProgressChanged += Web_DownloadProgressChanged;
            web.DownloadFileCompleted += Web_DownloadFileCompleted;
            web.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            web.DownloadFileAsync(uri, saveFile);
        }

        void WebClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            try
            {
                label.Text = e.ProgressPercentage.ToString() + "%" + "   " + (Convert.ToDouble(e.BytesReceived) / 1024 / 1024).ToString("0,00") + " МБ" + "  /  " + (Convert.ToDouble(e.TotalBytesToReceive) / 1024 / 1024).ToString("0.00") + " МБ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Web_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        { 
            bar.Value = 100;
            label.Text = "";
            label.Text = "";
            strip.Visible = false;

            MessageBox.Show("Загрузка обновления завершена!\n\nПрограмма будет закрыта и будет запущен установщик обновления.", "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), nameFile));

            Properties.Settings.Default.change_log = true;
            Properties.Settings.Default.Save();

            Application.Exit();
        }

        void Web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            bar.Value = e.ProgressPercentage;
        }

        public string GetChangeLog()
        {
            string change_log = "";

            using (WebClient Client = new WebClient())
            {
                Client.Encoding = Encoding.UTF8;
                change_log = Client.DownloadString("https://raw.githubusercontent.com/Johnson070/Dnevnik-v2.0/master/change_log.txt");
            }

            return change_log;
        }

        public void UpdateProgram(StatusStrip strip, ToolStripProgressBar bar, ToolStripLabel label)
        {
            this.strip = strip;
            this.bar = bar;
            this.label = label;

            string link = "";

            using (WebClient Client = new WebClient())
            {
                Client.Encoding = Encoding.UTF8;
                link = Client.DownloadString("https://raw.githubusercontent.com/Johnson070/Dnevnik-v2.0/master/download_link.txt").Replace("\n", string.Empty);
            }

            nameFile = link.Substring(link.LastIndexOf("/") + 1, link.Length - link.LastIndexOf("/") - 1);

            StartDownload(link, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), nameFile));

            //startDownload(link, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SchoolMetric_v." + vers + ".exe"));
        }
    }
}
