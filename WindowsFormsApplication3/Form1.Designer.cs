namespace WindowsFormsApplication3
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.configbox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtip = new System.Windows.Forms.TextBox();
            this.radnet = new System.Windows.Forms.RadioButton();
            this.radusb = new System.Windows.Forms.RadioButton();
            this.radlpt = new System.Windows.Forms.RadioButton();
            this.btnzpl = new System.Windows.Forms.Button();
            this.txtzpl = new System.Windows.Forms.TextBox();
            this.labzpl = new System.Windows.Forms.Label();
            this.comprint = new System.Windows.Forms.ComboBox();
            this.labprint = new System.Windows.Forms.Label();
            this.btnlogo = new System.Windows.Forms.Button();
            this.btnsaveseted = new System.Windows.Forms.Button();
            this.btnfolder = new System.Windows.Forms.Button();
            this.txtrecord = new System.Windows.Forms.TextBox();
            this.labrecord = new System.Windows.Forms.Label();
            this.txtdatafolder = new System.Windows.Forms.TextBox();
            this.labdataaddress = new System.Windows.Forms.Label();
            this.txtadmin = new System.Windows.Forms.TextBox();
            this.labadmin = new System.Windows.Forms.Label();
            this.btnautostart = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtmemorytime = new System.Windows.Forms.TextBox();
            this.timer_memo = new System.Windows.Forms.Timer(this.components);
            this.timer_autorun = new System.Windows.Forms.Timer(this.components);
            this.labVersion = new System.Windows.Forms.Label();
            this.btncheck = new System.Windows.Forms.Button();
            this.btnstart = new System.Windows.Forms.Button();
            this.txtlabelcount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupprintmode = new System.Windows.Forms.GroupBox();
            this.configbox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupprintmode.SuspendLayout();
            this.SuspendLayout();
            // 
            // configbox
            // 
            this.configbox.Controls.Add(this.groupBox1);
            this.configbox.Controls.Add(this.btnzpl);
            this.configbox.Controls.Add(this.txtzpl);
            this.configbox.Controls.Add(this.labzpl);
            this.configbox.Controls.Add(this.comprint);
            this.configbox.Controls.Add(this.labprint);
            this.configbox.Controls.Add(this.btnlogo);
            this.configbox.Controls.Add(this.btnsaveseted);
            this.configbox.Controls.Add(this.btnfolder);
            this.configbox.Controls.Add(this.txtrecord);
            this.configbox.Controls.Add(this.labrecord);
            this.configbox.Controls.Add(this.txtdatafolder);
            this.configbox.Controls.Add(this.labdataaddress);
            this.configbox.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.configbox.Location = new System.Drawing.Point(12, 46);
            this.configbox.Name = "configbox";
            this.configbox.Size = new System.Drawing.Size(475, 248);
            this.configbox.TabIndex = 0;
            this.configbox.TabStop = false;
            this.configbox.Text = "列印設定";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtip);
            this.groupBox1.Controls.Add(this.radnet);
            this.groupBox1.Controls.Add(this.radusb);
            this.groupBox1.Controls.Add(this.radlpt);
            this.groupBox1.Location = new System.Drawing.Point(9, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 47);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "傳輸介面";
            // 
            // txtip
            // 
            this.txtip.Font = new System.Drawing.Font("標楷體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtip.Location = new System.Drawing.Point(196, 20);
            this.txtip.Multiline = true;
            this.txtip.Name = "txtip";
            this.txtip.Size = new System.Drawing.Size(117, 17);
            this.txtip.TabIndex = 17;
            this.txtip.Visible = false;
            // 
            // radnet
            // 
            this.radnet.AutoSize = true;
            this.radnet.Location = new System.Drawing.Point(134, 19);
            this.radnet.Name = "radnet";
            this.radnet.Size = new System.Drawing.Size(44, 20);
            this.radnet.TabIndex = 16;
            this.radnet.TabStop = true;
            this.radnet.Text = "IP";
            this.radnet.UseVisualStyleBackColor = true;
            this.radnet.CheckedChanged += new System.EventHandler(this.radnet_CheckedChanged);
            // 
            // radusb
            // 
            this.radusb.AutoSize = true;
            this.radusb.Location = new System.Drawing.Point(6, 21);
            this.radusb.Name = "radusb";
            this.radusb.Size = new System.Drawing.Size(53, 20);
            this.radusb.TabIndex = 14;
            this.radusb.TabStop = true;
            this.radusb.Text = "USB";
            this.radusb.UseVisualStyleBackColor = true;
            // 
            // radlpt
            // 
            this.radlpt.AutoSize = true;
            this.radlpt.Location = new System.Drawing.Point(70, 21);
            this.radlpt.Name = "radlpt";
            this.radlpt.Size = new System.Drawing.Size(53, 20);
            this.radlpt.TabIndex = 15;
            this.radlpt.TabStop = true;
            this.radlpt.Text = "LPT";
            this.radlpt.UseVisualStyleBackColor = true;
            // 
            // btnzpl
            // 
            this.btnzpl.Location = new System.Drawing.Point(427, 111);
            this.btnzpl.Name = "btnzpl";
            this.btnzpl.Size = new System.Drawing.Size(37, 23);
            this.btnzpl.TabIndex = 12;
            this.btnzpl.Text = ">>";
            this.btnzpl.UseVisualStyleBackColor = true;
            this.btnzpl.Click += new System.EventHandler(this.btnzpl_Click);
            // 
            // txtzpl
            // 
            this.txtzpl.Location = new System.Drawing.Point(95, 111);
            this.txtzpl.Name = "txtzpl";
            this.txtzpl.Size = new System.Drawing.Size(326, 27);
            this.txtzpl.TabIndex = 11;
            // 
            // labzpl
            // 
            this.labzpl.AutoSize = true;
            this.labzpl.Location = new System.Drawing.Point(9, 118);
            this.labzpl.Name = "labzpl";
            this.labzpl.Size = new System.Drawing.Size(85, 16);
            this.labzpl.TabIndex = 10;
            this.labzpl.Text = "標籤格式:";
            // 
            // comprint
            // 
            this.comprint.Font = new System.Drawing.Font("標楷體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comprint.FormattingEnabled = true;
            this.comprint.Location = new System.Drawing.Point(95, 159);
            this.comprint.Name = "comprint";
            this.comprint.Size = new System.Drawing.Size(178, 21);
            this.comprint.Sorted = true;
            this.comprint.TabIndex = 9;
            // 
            // labprint
            // 
            this.labprint.AutoSize = true;
            this.labprint.Location = new System.Drawing.Point(6, 162);
            this.labprint.Name = "labprint";
            this.labprint.Size = new System.Drawing.Size(85, 16);
            this.labprint.TabIndex = 8;
            this.labprint.Text = "列印設備:";
            // 
            // btnlogo
            // 
            this.btnlogo.Location = new System.Drawing.Point(427, 73);
            this.btnlogo.Name = "btnlogo";
            this.btnlogo.Size = new System.Drawing.Size(37, 23);
            this.btnlogo.TabIndex = 7;
            this.btnlogo.Text = ">>";
            this.btnlogo.UseVisualStyleBackColor = true;
            this.btnlogo.Click += new System.EventHandler(this.btnlogo_Click);
            // 
            // btnsaveseted
            // 
            this.btnsaveseted.Location = new System.Drawing.Point(367, 178);
            this.btnsaveseted.Name = "btnsaveseted";
            this.btnsaveseted.Size = new System.Drawing.Size(97, 64);
            this.btnsaveseted.TabIndex = 1;
            this.btnsaveseted.Text = "儲存設定";
            this.btnsaveseted.UseVisualStyleBackColor = true;
            this.btnsaveseted.Click += new System.EventHandler(this.btnsaveseted_Click);
            // 
            // btnfolder
            // 
            this.btnfolder.Location = new System.Drawing.Point(427, 32);
            this.btnfolder.Name = "btnfolder";
            this.btnfolder.Size = new System.Drawing.Size(37, 23);
            this.btnfolder.TabIndex = 6;
            this.btnfolder.Text = ">>";
            this.btnfolder.UseVisualStyleBackColor = true;
            this.btnfolder.Click += new System.EventHandler(this.btnfolder_Click);
            // 
            // txtrecord
            // 
            this.txtrecord.Location = new System.Drawing.Point(95, 73);
            this.txtrecord.Name = "txtrecord";
            this.txtrecord.Size = new System.Drawing.Size(326, 27);
            this.txtrecord.TabIndex = 3;
            // 
            // labrecord
            // 
            this.labrecord.AutoSize = true;
            this.labrecord.Location = new System.Drawing.Point(9, 76);
            this.labrecord.Name = "labrecord";
            this.labrecord.Size = new System.Drawing.Size(85, 16);
            this.labrecord.TabIndex = 2;
            this.labrecord.Text = "記錄存放:";
            // 
            // txtdatafolder
            // 
            this.txtdatafolder.Location = new System.Drawing.Point(106, 32);
            this.txtdatafolder.Name = "txtdatafolder";
            this.txtdatafolder.Size = new System.Drawing.Size(315, 27);
            this.txtdatafolder.TabIndex = 1;
            // 
            // labdataaddress
            // 
            this.labdataaddress.AutoSize = true;
            this.labdataaddress.Location = new System.Drawing.Point(9, 35);
            this.labdataaddress.Name = "labdataaddress";
            this.labdataaddress.Size = new System.Drawing.Size(102, 16);
            this.labdataaddress.TabIndex = 0;
            this.labdataaddress.Text = "檔案資料夾:";
            // 
            // txtadmin
            // 
            this.txtadmin.Location = new System.Drawing.Point(104, 18);
            this.txtadmin.Name = "txtadmin";
            this.txtadmin.Size = new System.Drawing.Size(73, 22);
            this.txtadmin.TabIndex = 5;
            // 
            // labadmin
            // 
            this.labadmin.AutoSize = true;
            this.labadmin.Font = new System.Drawing.Font("標楷體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labadmin.Location = new System.Drawing.Point(19, 19);
            this.labadmin.Name = "labadmin";
            this.labadmin.Size = new System.Drawing.Size(79, 15);
            this.labadmin.TabIndex = 4;
            this.labadmin.Text = "User ID:";
            // 
            // btnautostart
            // 
            this.btnautostart.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnautostart.Location = new System.Drawing.Point(10, 17);
            this.btnautostart.Name = "btnautostart";
            this.btnautostart.Size = new System.Drawing.Size(106, 55);
            this.btnautostart.TabIndex = 4;
            this.btnautostart.Text = "AutoStart";
            this.btnautostart.UseVisualStyleBackColor = true;
            this.btnautostart.Click += new System.EventHandler(this.btnautostart_Click);
            // 
            // txtmemorytime
            // 
            this.txtmemorytime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmemorytime.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtmemorytime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmemorytime.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtmemorytime.ForeColor = System.Drawing.Color.Yellow;
            this.txtmemorytime.Location = new System.Drawing.Point(493, 278);
            this.txtmemorytime.Multiline = true;
            this.txtmemorytime.Name = "txtmemorytime";
            this.txtmemorytime.Size = new System.Drawing.Size(132, 16);
            this.txtmemorytime.TabIndex = 6;
            this.txtmemorytime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer_memo
            // 
            this.timer_memo.Enabled = true;
            this.timer_memo.Interval = 500;
            this.timer_memo.Tick += new System.EventHandler(this.timer_memo_Tick);
            // 
            // timer_autorun
            // 
            this.timer_autorun.Interval = 2000;
            this.timer_autorun.Tick += new System.EventHandler(this.timer_autorun_Tick);
            // 
            // labVersion
            // 
            this.labVersion.AutoSize = true;
            this.labVersion.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labVersion.Location = new System.Drawing.Point(493, 241);
            this.labVersion.Name = "labVersion";
            this.labVersion.Size = new System.Drawing.Size(128, 16);
            this.labVersion.TabIndex = 7;
            this.labVersion.Text = "Version: D_1.0.0.0";
            // 
            // btncheck
            // 
            this.btncheck.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btncheck.Location = new System.Drawing.Point(183, 18);
            this.btncheck.Name = "btncheck";
            this.btncheck.Size = new System.Drawing.Size(54, 23);
            this.btncheck.TabIndex = 18;
            this.btncheck.Text = "Check";
            this.btncheck.UseVisualStyleBackColor = true;
            this.btncheck.Click += new System.EventHandler(this.btncheck_Click);
            // 
            // btnstart
            // 
            this.btnstart.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnstart.Location = new System.Drawing.Point(10, 83);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(106, 55);
            this.btnstart.TabIndex = 19;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // txtlabelcount
            // 
            this.txtlabelcount.Location = new System.Drawing.Point(71, 144);
            this.txtlabelcount.Name = "txtlabelcount";
            this.txtlabelcount.Size = new System.Drawing.Size(45, 22);
            this.txtlabelcount.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(14, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "份數:";
            // 
            // groupprintmode
            // 
            this.groupprintmode.Controls.Add(this.btnautostart);
            this.groupprintmode.Controls.Add(this.label1);
            this.groupprintmode.Controls.Add(this.btnstart);
            this.groupprintmode.Controls.Add(this.txtlabelcount);
            this.groupprintmode.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupprintmode.Location = new System.Drawing.Point(492, 54);
            this.groupprintmode.Name = "groupprintmode";
            this.groupprintmode.Size = new System.Drawing.Size(123, 175);
            this.groupprintmode.TabIndex = 22;
            this.groupprintmode.TabStop = false;
            this.groupprintmode.Text = "列印模式";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 300);
            this.Controls.Add(this.groupprintmode);
            this.Controls.Add(this.btncheck);
            this.Controls.Add(this.labVersion);
            this.Controls.Add(this.txtmemorytime);
            this.Controls.Add(this.configbox);
            this.Controls.Add(this.txtadmin);
            this.Controls.Add(this.labadmin);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unitech列印程式";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.configbox.ResumeLayout(false);
            this.configbox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupprintmode.ResumeLayout(false);
            this.groupprintmode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox configbox;
        private System.Windows.Forms.Label labrecord;
        private System.Windows.Forms.TextBox txtdatafolder;
        private System.Windows.Forms.Label labdataaddress;
        private System.Windows.Forms.Button btnsaveseted;
        private System.Windows.Forms.Label labadmin;
        private System.Windows.Forms.TextBox txtrecord;
        private System.Windows.Forms.Button btnfolder;
        private System.Windows.Forms.TextBox txtadmin;
        private System.Windows.Forms.Button btnautostart;
        private System.Windows.Forms.Button btnlogo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ComboBox comprint;
        private System.Windows.Forms.Label labprint;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnzpl;
        private System.Windows.Forms.TextBox txtzpl;
        private System.Windows.Forms.Label labzpl;
        private System.Windows.Forms.RadioButton radnet;
        private System.Windows.Forms.RadioButton radlpt;
        private System.Windows.Forms.RadioButton radusb;
        private System.Windows.Forms.TextBox txtmemorytime;
        private System.Windows.Forms.Timer timer_memo;
        private System.Windows.Forms.Timer timer_autorun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labVersion;
        private System.Windows.Forms.Button btncheck;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.TextBox txtlabelcount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupprintmode;
        private System.Windows.Forms.TextBox txtip;
    }
}

