using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFmpeg.NET;
using FFmpeg.NET.Events;

namespace VTAC
{
    public partial class Main : Form
    {
        private readonly Engine ffmpeg = new Engine(@"ffmpeg\x32\bin\ffmpeg.exe");
        private string filePath;
        private string outputfilePath;
        private TimeSpan totalDuration;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ffmpeg.Progress += OnProgress;
            ffmpeg.Data += OnData;
            ffmpeg.Error += OnError;
            ffmpeg.Complete += OnComplete;
            LogMessage("Starting Application");
        }

        private void BtnVideoSelect_Click(object sender, EventArgs e)
        {
            var result = choseVideoDlg.ShowDialog();
            LogMessage("Opened File Dialog.");
            if (result == DialogResult.OK)
            {
                var file = choseVideoDlg.FileName;
                filePath = file;
                LogMessage($"Got File path {filePath}");
                lblFileName.Text = $"Selected File: {Path.GetFileName(file)}";
                LogMessage($"File Name: {Path.GetFileName(file)}");
                lblFileName.Visible = true;
                btnRun.Visible = true;
            }
        }

        private async void BtnRun_Click(object sender, EventArgs e)
        {
            if (filePath != null)
            {
                var basePath = Path.GetDirectoryName(filePath);
                var outputFileM4A = $"{basePath}\\sample_m4a.m4a";
                var outputFileMP3 = $"{basePath}\\{Path.GetFileNameWithoutExtension(filePath)}.mp3";
                outputfilePath = outputFileMP3;
                LogMessage($"Base Path: {basePath}");
                LogMessage($"Step one output file path: {outputFileM4A}");
                LogMessage($"Step Two output file path: {outputFileMP3}");
                var cmdStep1 = $"-i {filePath} -vn -acodec copy {outputFileM4A}";
                var cmdStep2 = $"-i {outputFileM4A} -acodec libmp3lame -b:a 16k -ac 1 -ar 11025 {outputFileMP3}";
                LogMessage($"Step one Command: {cmdStep1}");
                LogMessage($"Step Two Command: {cmdStep2}");
                progBarStatus.Visible = true;
                await ffmpeg.ExecuteAsync(cmdStep1);
                await ffmpeg.ExecuteAsync(cmdStep2);
                if (File.Exists(outputFileM4A))
                {
                    LogMessage("Deleting M4A File...");
                    await Task.Run(() => File.Delete(outputFileM4A));
                    appNotifiy.BalloonTipIcon = ToolTipIcon.Info;
                    appNotifiy.Icon = SystemIcons.Information;
                    appNotifiy.BalloonTipTitle = "VTAC";
                    appNotifiy.BalloonTipText = "تم الانتهاء من تحويل الفديو و ضغط الصوت بنجاح.";
                    appNotifiy.Text = "تم الانتهاء من تحويل الفديو و ضغط الصوت بنجاح.";
                    appNotifiy.Visible = true;
                    appNotifiy.ShowBalloonTip(5000);
                    btnOpenOutputDirectory.Visible = true;
                    btnReset.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("من فضلك اختر ملف الفديو !");
                LogMessage("filePath = null");
            }
        }

        private void OnProgress(object sender, ConversionProgressEventArgs e)
        {
            if (e != null)
            {
                StartTimer();
                totalDuration = e.ProcessedDuration;
                LogMessage($"Total TotalDuration {e.TotalDuration}");
                LogMessage($"Total ProcessedDuration {e.ProcessedDuration}");
                LogMessage($"Total SizeKb {e.SizeKb}kB");
            }

        }

        private void OnData(object sender, ConversionDataEventArgs e)
        {
            if (e.Data != null)
            {
                var data = e.Data.ToString();
                LogMessage($"FFMPEG: {data}");
            }
        }

        private void OnComplete(object sender, ConversionCompleteEventArgs e)
        {
            LogMessage("Complited !");
            SetProgressValue(100);
        }

        private void OnError(object sender, ConversionErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                LogMessage($"Error: {e.Exception.Message}\r\n ExitCode: {e.Exception.ExitCode}\r\n Trace: {e.Exception.StackTrace} \r\n");
            }
        }

        private void LogMessage(string msg)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(LogMessage);
                Invoke(d, new object[] { msg });
            }
            else
            {
                var currentTime = DateTime.Now.ToString();
                txtLog.AppendText($"{currentTime} - {msg}\r\n");
            }

        }

        private void SetProgressValue(int value)
        {
            if (progBarStatus.InvokeRequired)
            {
                SetProgressCallback d = new SetProgressCallback(SetProgressValue);
                Invoke(d, new object[] { value });
            }
            else
            {
                progBarStatus.Value = value;
            }
        }

        private void StartTimer()
        {
            progressTimer.Enabled = true;
            progressTimer.Start();
        }

        delegate void SetTextCallback(string text);
        delegate void SetProgressCallback(int value);

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            totalDuration = totalDuration.Subtract(TimeSpan.FromMilliseconds(100));
            if (totalDuration == TimeSpan.Zero)
            {
                progressTimer.Stop();
                progressTimer.Enabled = false;
            }
            SetProgressValue(progBarStatus.Value + 1);
        }

        private async void BtnCopyLogs_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(txtLog.Text);
            lblLogCopied.Visible = true;
            await Task.Delay(TimeSpan.FromSeconds(8));
            lblLogCopied.Visible = false;

        }

        private void AppNotifiy_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenOutputDirectory();
        }

        private void AppNotifiy_BalloonTipClicked(object sender, EventArgs e)
        {
            OpenOutputDirectory();
        }

        private void OpenOutputDirectory()
        {
            var basePath = Path.GetDirectoryName(outputfilePath);
            Process.Start("explorer.exe", basePath);
        }

        private void BtnOpenOutputDirectory_Click(object sender, EventArgs e)
        {
            OpenOutputDirectory();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            progBarStatus.Value = 0;
            lblFileName.Text = "";
            outputfilePath = null;
            filePath = null;
            progBarStatus.Visible = false;
            btnRun.Visible = false;
            btnOpenOutputDirectory.Visible = false;
            btnReset.Visible = false;
            LogMessage("Restarting Again...");
            LogMessage("--------------------------------");
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutBox
            {
                ShowInTaskbar = false
            };
            aboutBox.Show();
        }
    }
}
