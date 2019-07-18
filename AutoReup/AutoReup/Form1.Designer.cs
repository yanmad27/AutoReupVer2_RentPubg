namespace AutoReup
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRentAccID = new System.Windows.Forms.TextBox();
            this.txtRentAccPass = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSkipLog = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmailPass = new System.Windows.Forms.TextBox();
            this.txtEmailID = new System.Windows.Forms.TextBox();
            this.chkShowBrowser = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressbar = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbltime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWorking = new System.Windows.Forms.Label();
            this.lblCurrentIDSteam = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.TextBox();
            this.b = new System.Windows.Forms.TextBox();
            this.c = new System.Windows.Forms.TextBox();
            this.chkShowSkipLog = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblRateRent = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblError = new System.Windows.Forms.Label();
            this.lblNumberOfRent = new System.Windows.Forms.Label();
            this.lblRent = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblReady = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.d = new System.Windows.Forms.TextBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.session_time = new System.Windows.Forms.Timer(this.components);
            this.checkRun = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.nico = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxtmnstrMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.infoBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTotalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkUpdateTotal = new System.Windows.Forms.CheckBox();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.ctxtmnstrMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.txtRentAccID);
            this.groupBox6.Controls.Add(this.txtRentAccPass);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(150, 75);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Rent Acc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pass";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // txtRentAccID
            // 
            this.txtRentAccID.Enabled = false;
            this.txtRentAccID.Location = new System.Drawing.Point(45, 20);
            this.txtRentAccID.Name = "txtRentAccID";
            this.txtRentAccID.Size = new System.Drawing.Size(100, 20);
            this.txtRentAccID.TabIndex = 0;
            // 
            // txtRentAccPass
            // 
            this.txtRentAccPass.Location = new System.Drawing.Point(45, 46);
            this.txtRentAccPass.Name = "txtRentAccPass";
            this.txtRentAccPass.Size = new System.Drawing.Size(100, 20);
            this.txtRentAccPass.TabIndex = 1;
            this.txtRentAccPass.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(129, 696);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Token";
            // 
            // txtToken
            // 
            this.txtToken.Enabled = false;
            this.txtToken.Location = new System.Drawing.Point(168, 693);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(100, 20);
            this.txtToken.TabIndex = 0;
            this.txtToken.UseSystemPasswordChar = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtSkipLog);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox5.Location = new System.Drawing.Point(250, 229);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(229, 196);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Skip Log";
            // 
            // txtSkipLog
            // 
            this.txtSkipLog.Location = new System.Drawing.Point(6, 19);
            this.txtSkipLog.Multiline = true;
            this.txtSkipLog.Name = "txtSkipLog";
            this.txtSkipLog.ReadOnly = true;
            this.txtSkipLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSkipLog.Size = new System.Drawing.Size(217, 171);
            this.txtSkipLog.TabIndex = 7;
            this.txtSkipLog.TextChanged += new System.EventHandler(this.txtSkipLog_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLog);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox4.Location = new System.Drawing.Point(12, 229);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 196);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log ";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(7, 19);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(219, 171);
            this.txtLog.TabIndex = 6;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtEmailPass);
            this.groupBox3.Controls.Add(this.txtEmailID);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox3.Location = new System.Drawing.Point(12, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 75);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Pass";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "ID";
            // 
            // txtEmailPass
            // 
            this.txtEmailPass.Location = new System.Drawing.Point(42, 48);
            this.txtEmailPass.Name = "txtEmailPass";
            this.txtEmailPass.Size = new System.Drawing.Size(100, 20);
            this.txtEmailPass.TabIndex = 1;
            this.txtEmailPass.UseSystemPasswordChar = true;
            // 
            // txtEmailID
            // 
            this.txtEmailID.Location = new System.Drawing.Point(42, 22);
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Size = new System.Drawing.Size(100, 20);
            this.txtEmailID.TabIndex = 0;
            // 
            // chkShowBrowser
            // 
            this.chkShowBrowser.AutoSize = true;
            this.chkShowBrowser.Location = new System.Drawing.Point(21, 179);
            this.chkShowBrowser.Name = "chkShowBrowser";
            this.chkShowBrowser.Size = new System.Drawing.Size(94, 17);
            this.chkShowBrowser.TabIndex = 24;
            this.chkShowBrowser.Text = "Show Browser";
            this.chkShowBrowser.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(24, 757);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 79);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rent acc";
            // 
            // progressbar
            // 
            this.progressbar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.progressbar.Location = new System.Drawing.Point(6, 49);
            this.progressbar.MarqueeAnimationSpeed = 10;
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(299, 20);
            this.progressbar.Step = 1;
            this.progressbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressbar.TabIndex = 28;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbltime);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblWorking);
            this.groupBox2.Controls.Add(this.lblCurrentIDSteam);
            this.groupBox2.Controls.Add(this.progressbar);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox2.Location = new System.Drawing.Point(168, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 75);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Account";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbltime.Location = new System.Drawing.Point(281, 16);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(19, 13);
            this.lbltime.TabIndex = 31;
            this.lbltime.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(242, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Timer";
            // 
            // lblWorking
            // 
            this.lblWorking.AutoSize = true;
            this.lblWorking.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblWorking.Location = new System.Drawing.Point(4, 33);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(47, 13);
            this.lblWorking.TabIndex = 29;
            this.lblWorking.Text = "Working";
            // 
            // lblCurrentIDSteam
            // 
            this.lblCurrentIDSteam.AutoSize = true;
            this.lblCurrentIDSteam.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblCurrentIDSteam.Location = new System.Drawing.Point(5, 16);
            this.lblCurrentIDSteam.Name = "lblCurrentIDSteam";
            this.lblCurrentIDSteam.Size = new System.Drawing.Size(52, 13);
            this.lblCurrentIDSteam.TabIndex = 2;
            this.lblCurrentIDSteam.Text = "CurrentID";
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(709, 54);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(100, 20);
            this.a.TabIndex = 30;
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(709, 81);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(100, 20);
            this.b.TabIndex = 31;
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(709, 108);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(100, 20);
            this.c.TabIndex = 32;
            // 
            // chkShowSkipLog
            // 
            this.chkShowSkipLog.AutoSize = true;
            this.chkShowSkipLog.Location = new System.Drawing.Point(21, 199);
            this.chkShowSkipLog.Name = "chkShowSkipLog";
            this.chkShowSkipLog.Size = new System.Drawing.Size(79, 17);
            this.chkShowSkipLog.TabIndex = 33;
            this.chkShowSkipLog.Text = "Show Logs";
            this.chkShowSkipLog.UseVisualStyleBackColor = true;
            this.chkShowSkipLog.CheckedChanged += new System.EventHandler(this.chkShowSkipLog_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblRateRent);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.lblError);
            this.groupBox7.Controls.Add(this.lblNumberOfRent);
            this.groupBox7.Controls.Add(this.lblRent);
            this.groupBox7.Controls.Add(this.lblEnd);
            this.groupBox7.Controls.Add(this.lblReady);
            this.groupBox7.Controls.Add(this.lblRevenue);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox7.Location = new System.Drawing.Point(168, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(311, 75);
            this.groupBox7.TabIndex = 30;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tổng quan";
            // 
            // lblRateRent
            // 
            this.lblRateRent.AutoSize = true;
            this.lblRateRent.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblRateRent.Location = new System.Drawing.Point(216, 23);
            this.lblRateRent.Name = "lblRateRent";
            this.lblRateRent.Size = new System.Drawing.Size(30, 13);
            this.lblRateRent.TabIndex = 10;
            this.lblRateRent.Text = "S/W";
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(3, 36);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(305, 10);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblError.Location = new System.Drawing.Point(254, 49);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(21, 13);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "Lỗi";
            // 
            // lblNumberOfRent
            // 
            this.lblNumberOfRent.AutoSize = true;
            this.lblNumberOfRent.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblNumberOfRent.Location = new System.Drawing.Point(136, 23);
            this.lblNumberOfRent.Name = "lblNumberOfRent";
            this.lblNumberOfRent.Size = new System.Drawing.Size(52, 13);
            this.lblNumberOfRent.TabIndex = 7;
            this.lblNumberOfRent.Text = "Lượt thuê";
            // 
            // lblRent
            // 
            this.lblRent.AutoSize = true;
            this.lblRent.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblRent.Location = new System.Drawing.Point(136, 49);
            this.lblRent.Name = "lblRent";
            this.lblRent.Size = new System.Drawing.Size(85, 13);
            this.lblRent.TabIndex = 5;
            this.lblRent.Text = "Đang được thuê";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblEnd.Location = new System.Drawing.Point(6, 49);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(33, 13);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "Reup";
            // 
            // lblReady
            // 
            this.lblReady.AutoSize = true;
            this.lblReady.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblReady.Location = new System.Drawing.Point(58, 49);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(52, 13);
            this.lblReady.TabIndex = 3;
            this.lblReady.Text = "Sẵn sàng";
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblRevenue.Location = new System.Drawing.Point(6, 23);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(57, 13);
            this.lblRevenue.TabIndex = 2;
            this.lblRevenue.Text = "Doanh thu";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // d
            // 
            this.d.Location = new System.Drawing.Point(709, 134);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(100, 20);
            this.d.TabIndex = 38;
            // 
            // cmdStart
            // 
            this.cmdStart.BackColor = System.Drawing.Color.White;
            this.cmdStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdStart.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.cmdStart.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.cmdStart.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.cmdStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdStart.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStart.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.cmdStart.Location = new System.Drawing.Point(285, 171);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(94, 45);
            this.cmdStart.TabIndex = 20;
            this.cmdStart.Text = "START";
            this.cmdStart.UseVisualStyleBackColor = false;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.cmdStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdStop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cmdStop.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.cmdStop.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.cmdStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdStop.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStop.ForeColor = System.Drawing.Color.White;
            this.cmdStop.Location = new System.Drawing.Point(385, 171);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(94, 45);
            this.cmdStop.TabIndex = 23;
            this.cmdStop.Text = "STOP";
            this.cmdStop.UseVisualStyleBackColor = false;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // session_time
            // 
            this.session_time.Interval = 1000;
            this.session_time.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkRun
            // 
            this.checkRun.Interval = 5000;
            this.checkRun.Tick += new System.EventHandler(this.checkRun_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(158, 179);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 17);
            this.checkBox1.TabIndex = 39;
            this.checkBox1.Text = "Info Background";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // nico
            // 
            this.nico.ContextMenuStrip = this.ctxtmnstrMenu;
            this.nico.Icon = ((System.Drawing.Icon)(resources.GetObject("nico.Icon")));
            this.nico.Text = "AutoReup_Pubg";
            this.nico.BalloonTipClicked += new System.EventHandler(this.nico_BalloonTipClicked);
            this.nico.BalloonTipClosed += new System.EventHandler(this.nico_BalloonTipClosed);
            this.nico.Click += new System.EventHandler(this.nico_Click);
            this.nico.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.nico.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nico_MouseClick);
            // 
            // ctxtmnstrMenu
            // 
            this.ctxtmnstrMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoBackgroundToolStripMenuItem,
            this.updateTotalToolStripMenuItem});
            this.ctxtmnstrMenu.Name = "ctxtmnstrMenu";
            this.ctxtmnstrMenu.Size = new System.Drawing.Size(163, 70);
            this.ctxtmnstrMenu.Click += new System.EventHandler(this.ctxtmnstrMenu_Click);
            // 
            // infoBackgroundToolStripMenuItem
            // 
            this.infoBackgroundToolStripMenuItem.Name = "infoBackgroundToolStripMenuItem";
            this.infoBackgroundToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.infoBackgroundToolStripMenuItem.Text = "Info Background";
            this.infoBackgroundToolStripMenuItem.Click += new System.EventHandler(this.infoBackgroundToolStripMenuItem_Click);
            // 
            // updateTotalToolStripMenuItem
            // 
            this.updateTotalToolStripMenuItem.Name = "updateTotalToolStripMenuItem";
            this.updateTotalToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.updateTotalToolStripMenuItem.Text = "Exit";
            this.updateTotalToolStripMenuItem.Click += new System.EventHandler(this.updateTotalToolStripMenuItem_Click);
            // 
            // chkUpdateTotal
            // 
            this.chkUpdateTotal.AutoSize = true;
            this.chkUpdateTotal.Location = new System.Drawing.Point(158, 199);
            this.chkUpdateTotal.Name = "chkUpdateTotal";
            this.chkUpdateTotal.Size = new System.Drawing.Size(88, 17);
            this.chkUpdateTotal.TabIndex = 40;
            this.chkUpdateTotal.Text = "Update Total";
            this.chkUpdateTotal.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(491, 222);
            this.Controls.Add(this.chkUpdateTotal);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.d);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.chkShowSkipLog);
            this.Controls.Add(this.c);
            this.Controls.Add(this.b);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.a);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.chkShowBrowser);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoReup";
            this.TransparencyKey = System.Drawing.Color.Yellow;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ctxtmnstrMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtSkipLog;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmailPass;
        private System.Windows.Forms.TextBox txtEmailID;
        private System.Windows.Forms.CheckBox chkShowBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRentAccPass;
        private System.Windows.Forms.TextBox txtRentAccID;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ProgressBar progressbar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCurrentIDSteam;
        private System.Windows.Forms.TextBox a;
        private System.Windows.Forms.TextBox b;
        private System.Windows.Forms.TextBox c;
        private System.Windows.Forms.CheckBox chkShowSkipLog;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblNumberOfRent;
        private System.Windows.Forms.Label lblRent;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox d;
        private System.Windows.Forms.Timer session_time;
        private System.Windows.Forms.Timer checkRun;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lblRateRent;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NotifyIcon nico;
        private System.Windows.Forms.CheckBox chkUpdateTotal;
        private System.Windows.Forms.ContextMenuStrip ctxtmnstrMenu;
        private System.Windows.Forms.ToolStripMenuItem infoBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateTotalToolStripMenuItem;
    }
}

