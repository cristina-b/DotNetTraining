namespace UiFormApp
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System;
    using System.Threading;

    public partial class UiForm : Form
    {
        public UiForm()
        {
            this.InitializeComponent();
        }

        private async void DownloadBtnLeft_Click(object sender, System.EventArgs e)
        {
            var url = this.urlTextBoxLeft.Text;
            /*var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Task<string> task = new Task<string>(() =>
            {
                return this.DownloadString(url);
            });

            task.ContinueWith(ant =>
            {
                this.contentTxbLeft.Text = ant.Exception.Message;
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, uiScheduler);

            task.ContinueWith(prev =>
            {
                this.contentTxbLeft.Text = task.Result;
                this.logLabelLeft.Text = $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms";
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, uiScheduler);

            task.Start();*/

            Task<string> task = this.DownloadStringAsync(url);
            var result = await task;
            this.contentTxbLeft.Text = result;

        }

        private void DownloadBtnRight_Click(object sender, System.EventArgs e)
        {
            var url = this.urlTextBoxRight.Text;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var source = this.DownloadString(url);

            this.contentTxbRight.Text = source;
            this.logLabelRight.Text = $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms";
        }

        private string DownloadString(string url)
        {
            return new WebClient().DownloadString(url);
        }

        private Task<string> DownloadStringAsync(string url)
        {
            return Task.Run(() =>
            {
                return DownloadString(url);
            });
        }
    }
}
