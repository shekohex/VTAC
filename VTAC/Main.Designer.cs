namespace VTAC
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnVideoSelect = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.progBarStatus = new System.Windows.Forms.ProgressBar();
            this.choseVideoDlg = new System.Windows.Forms.OpenFileDialog();
            this.lblFileName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLogCopied = new System.Windows.Forms.Label();
            this.btnCopyLogs = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.appNotifiy = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnOpenOutputDirectory = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVideoSelect
            // 
            resources.ApplyResources(this.btnVideoSelect, "btnVideoSelect");
            this.btnVideoSelect.Name = "btnVideoSelect";
            this.btnVideoSelect.UseVisualStyleBackColor = true;
            this.btnVideoSelect.Click += new System.EventHandler(this.BtnVideoSelect_Click);
            // 
            // btnRun
            // 
            resources.ApplyResources(this.btnRun, "btnRun");
            this.btnRun.Name = "btnRun";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // progBarStatus
            // 
            resources.ApplyResources(this.progBarStatus, "progBarStatus");
            this.progBarStatus.Name = "progBarStatus";
            // 
            // choseVideoDlg
            // 
            this.choseVideoDlg.DefaultExt = "mp4";
            this.choseVideoDlg.FileName = "choseVideoDlg";
            resources.ApplyResources(this.choseVideoDlg, "choseVideoDlg");
            this.choseVideoDlg.ShowHelp = true;
            // 
            // lblFileName
            // 
            resources.ApplyResources(this.lblFileName, "lblFileName");
            this.lblFileName.Name = "lblFileName";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLogCopied);
            this.groupBox1.Controls.Add(this.btnCopyLogs);
            this.groupBox1.Controls.Add(this.txtLog);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblLogCopied
            // 
            resources.ApplyResources(this.lblLogCopied, "lblLogCopied");
            this.lblLogCopied.Name = "lblLogCopied";
            // 
            // btnCopyLogs
            // 
            resources.ApplyResources(this.btnCopyLogs, "btnCopyLogs");
            this.btnCopyLogs.Name = "btnCopyLogs";
            this.btnCopyLogs.UseVisualStyleBackColor = true;
            this.btnCopyLogs.Click += new System.EventHandler(this.BtnCopyLogs_Click);
            // 
            // txtLog
            // 
            resources.ApplyResources(this.txtLog, "txtLog");
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            // 
            // progressTimer
            // 
            this.progressTimer.Tick += new System.EventHandler(this.ProgressTimer_Tick);
            // 
            // appNotifiy
            // 
            this.appNotifiy.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.appNotifiy, "appNotifiy");
            this.appNotifiy.BalloonTipClicked += new System.EventHandler(this.AppNotifiy_BalloonTipClicked);
            this.appNotifiy.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AppNotifiy_MouseDoubleClick);
            // 
            // btnOpenOutputDirectory
            // 
            resources.ApplyResources(this.btnOpenOutputDirectory, "btnOpenOutputDirectory");
            this.btnOpenOutputDirectory.Name = "btnOpenOutputDirectory";
            this.btnOpenOutputDirectory.UseVisualStyleBackColor = true;
            this.btnOpenOutputDirectory.Click += new System.EventHandler(this.BtnOpenOutputDirectory_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReset.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnAbout
            // 
            resources.ApplyResources(this.btnAbout, "btnAbout");
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.progBarStatus);
            this.Controls.Add(this.btnOpenOutputDirectory);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnVideoSelect);
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVideoSelect;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ProgressBar progBarStatus;
        private System.Windows.Forms.OpenFileDialog choseVideoDlg;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.Button btnCopyLogs;
        private System.Windows.Forms.Label lblLogCopied;
        private System.Windows.Forms.NotifyIcon appNotifiy;
        private System.Windows.Forms.Button btnOpenOutputDirectory;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAbout;
    }
}

