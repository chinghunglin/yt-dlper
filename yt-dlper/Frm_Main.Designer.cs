namespace yt_dlper
{
    partial class Frm_Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.label1 = new System.Windows.Forms.Label();
            this.Tbx_Link = new System.Windows.Forms.TextBox();
            this.Tbx_Wrk_Dir = new System.Windows.Forms.TextBox();
            this.Btn_Wrk_Dir = new System.Windows.Forms.Button();
            this.Btn_Video = new System.Windows.Forms.Button();
            this.Btn_mp3 = new System.Windows.Forms.Button();
            this.Btn_Clear_Link = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Cbx_YT_Subs = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Rbn_Res_Unlimited = new System.Windows.Forms.RadioButton();
            this.Rbn_Res_1440P = new System.Windows.Forms.RadioButton();
            this.Rbn_Res_1080P = new System.Windows.Forms.RadioButton();
            this.Rbn_Res_720P = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Btn_Update_yt_dlp = new System.Windows.Forms.Button();
            this.Tbx_Info = new System.Windows.Forms.RichTextBox();
            this.Btn_SubOnly = new System.Windows.Forms.Button();
            this.Tbx_Progress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "影片網址:Links:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Tbx_Link
            // 
            this.Tbx_Link.AllowDrop = true;
            this.Tbx_Link.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Tbx_Link.Location = new System.Drawing.Point(116, 6);
            this.Tbx_Link.Multiline = true;
            this.Tbx_Link.Name = "Tbx_Link";
            this.Tbx_Link.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tbx_Link.Size = new System.Drawing.Size(656, 109);
            this.Tbx_Link.TabIndex = 0;
            // 
            // Tbx_Wrk_Dir
            // 
            this.Tbx_Wrk_Dir.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Tbx_Wrk_Dir.Location = new System.Drawing.Point(116, 121);
            this.Tbx_Wrk_Dir.Name = "Tbx_Wrk_Dir";
            this.Tbx_Wrk_Dir.ReadOnly = true;
            this.Tbx_Wrk_Dir.Size = new System.Drawing.Size(656, 29);
            this.Tbx_Wrk_Dir.TabIndex = 17;
            this.Tbx_Wrk_Dir.DoubleClick += new System.EventHandler(this.Tbx_Wrk_Dir_DoubleClick);
            // 
            // Btn_Wrk_Dir
            // 
            this.Btn_Wrk_Dir.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Wrk_Dir.Location = new System.Drawing.Point(4, 120);
            this.Btn_Wrk_Dir.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Wrk_Dir.Name = "Btn_Wrk_Dir";
            this.Btn_Wrk_Dir.Size = new System.Drawing.Size(110, 30);
            this.Btn_Wrk_Dir.TabIndex = 18;
            this.Btn_Wrk_Dir.Text = "目錄 Save to";
            this.Btn_Wrk_Dir.UseVisualStyleBackColor = true;
            this.Btn_Wrk_Dir.Click += new System.EventHandler(this.Btn_Wrk_Dir_Click);
            // 
            // Btn_Video
            // 
            this.Btn_Video.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Video.Location = new System.Drawing.Point(398, 173);
            this.Btn_Video.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Video.Name = "Btn_Video";
            this.Btn_Video.Size = new System.Drawing.Size(98, 36);
            this.Btn_Video.TabIndex = 19;
            this.Btn_Video.Text = "下載 Video";
            this.Btn_Video.UseVisualStyleBackColor = true;
            this.Btn_Video.Click += new System.EventHandler(this.Btn_Video_Click);
            // 
            // Btn_mp3
            // 
            this.Btn_mp3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_mp3.Location = new System.Drawing.Point(496, 173);
            this.Btn_mp3.Name = "Btn_mp3";
            this.Btn_mp3.Size = new System.Drawing.Size(104, 36);
            this.Btn_mp3.TabIndex = 20;
            this.Btn_mp3.Text = "只下載MP3";
            this.Btn_mp3.UseVisualStyleBackColor = true;
            this.Btn_mp3.Click += new System.EventHandler(this.Btn_mp3_Click);
            // 
            // Btn_Clear_Link
            // 
            this.Btn_Clear_Link.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Clear_Link.Location = new System.Drawing.Point(8, 57);
            this.Btn_Clear_Link.Name = "Btn_Clear_Link";
            this.Btn_Clear_Link.Size = new System.Drawing.Size(102, 31);
            this.Btn_Clear_Link.TabIndex = 22;
            this.Btn_Clear_Link.Text = "清空 Clear";
            this.Btn_Clear_Link.UseVisualStyleBackColor = true;
            this.Btn_Clear_Link.Click += new System.EventHandler(this.Btn_Clear_Link_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // Cbx_YT_Subs
            // 
            this.Cbx_YT_Subs.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Cbx_YT_Subs.Location = new System.Drawing.Point(6, 16);
            this.Cbx_YT_Subs.Name = "Cbx_YT_Subs";
            this.Cbx_YT_Subs.Size = new System.Drawing.Size(120, 46);
            this.Cbx_YT_Subs.TabIndex = 23;
            this.Cbx_YT_Subs.Text = "YT字幕Subs    (如果有)";
            this.Cbx_YT_Subs.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Cbx_YT_Subs);
            this.groupBox1.Location = new System.Drawing.Point(6, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 68);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "影片選項";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Rbn_Res_Unlimited);
            this.groupBox2.Controls.Add(this.Rbn_Res_1440P);
            this.groupBox2.Controls.Add(this.Rbn_Res_1080P);
            this.groupBox2.Controls.Add(this.Rbn_Res_720P);
            this.groupBox2.Location = new System.Drawing.Point(121, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 46);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "YT最大解析度 Max Resolution";
            // 
            // Rbn_Res_Unlimited
            // 
            this.Rbn_Res_Unlimited.AutoSize = true;
            this.Rbn_Res_Unlimited.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.Rbn_Res_Unlimited.Location = new System.Drawing.Point(206, 18);
            this.Rbn_Res_Unlimited.Name = "Rbn_Res_Unlimited";
            this.Rbn_Res_Unlimited.Size = new System.Drawing.Size(54, 22);
            this.Rbn_Res_Unlimited.TabIndex = 28;
            this.Rbn_Res_Unlimited.Text = "不限";
            this.Rbn_Res_Unlimited.UseVisualStyleBackColor = true;
            // 
            // Rbn_Res_1440P
            // 
            this.Rbn_Res_1440P.AutoSize = true;
            this.Rbn_Res_1440P.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.Rbn_Res_1440P.Location = new System.Drawing.Point(136, 18);
            this.Rbn_Res_1440P.Name = "Rbn_Res_1440P";
            this.Rbn_Res_1440P.Size = new System.Drawing.Size(67, 22);
            this.Rbn_Res_1440P.TabIndex = 27;
            this.Rbn_Res_1440P.Text = "1440P";
            this.Rbn_Res_1440P.UseVisualStyleBackColor = true;
            // 
            // Rbn_Res_1080P
            // 
            this.Rbn_Res_1080P.AutoSize = true;
            this.Rbn_Res_1080P.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.Rbn_Res_1080P.Location = new System.Drawing.Point(66, 18);
            this.Rbn_Res_1080P.Name = "Rbn_Res_1080P";
            this.Rbn_Res_1080P.Size = new System.Drawing.Size(67, 22);
            this.Rbn_Res_1080P.TabIndex = 26;
            this.Rbn_Res_1080P.Text = "1080P";
            this.Rbn_Res_1080P.UseVisualStyleBackColor = true;
            // 
            // Rbn_Res_720P
            // 
            this.Rbn_Res_720P.AutoSize = true;
            this.Rbn_Res_720P.Checked = true;
            this.Rbn_Res_720P.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.Rbn_Res_720P.Location = new System.Drawing.Point(4, 18);
            this.Rbn_Res_720P.Name = "Rbn_Res_720P";
            this.Rbn_Res_720P.Size = new System.Drawing.Size(59, 22);
            this.Rbn_Res_720P.TabIndex = 25;
            this.Rbn_Res_720P.TabStop = true;
            this.Rbn_Res_720P.Text = "720P";
            this.Rbn_Res_720P.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(19, 443);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(194, 12);
            this.linkLabel1.TabIndex = 26;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/chinghunglin/yt-dlper";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Btn_Update_yt_dlp
            // 
            this.Btn_Update_yt_dlp.Location = new System.Drawing.Point(644, 437);
            this.Btn_Update_yt_dlp.Name = "Btn_Update_yt_dlp";
            this.Btn_Update_yt_dlp.Size = new System.Drawing.Size(128, 23);
            this.Btn_Update_yt_dlp.TabIndex = 27;
            this.Btn_Update_yt_dlp.Text = "update 升級 yt_dlp.exe";
            this.Btn_Update_yt_dlp.UseVisualStyleBackColor = true;
            this.Btn_Update_yt_dlp.Click += new System.EventHandler(this.Btn_Update_yt_dlp_Click);
            // 
            // Tbx_Info
            // 
            this.Tbx_Info.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbx_Info.Location = new System.Drawing.Point(8, 231);
            this.Tbx_Info.Name = "Tbx_Info";
            this.Tbx_Info.ReadOnly = true;
            this.Tbx_Info.Size = new System.Drawing.Size(764, 200);
            this.Tbx_Info.TabIndex = 28;
            this.Tbx_Info.Text = "";
            // 
            // Btn_SubOnly
            // 
            this.Btn_SubOnly.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_SubOnly.Location = new System.Drawing.Point(600, 167);
            this.Btn_SubOnly.Name = "Btn_SubOnly";
            this.Btn_SubOnly.Size = new System.Drawing.Size(83, 51);
            this.Btn_SubOnly.TabIndex = 29;
            this.Btn_SubOnly.Text = "下載字幕 SubOnly";
            this.Btn_SubOnly.UseVisualStyleBackColor = true;
            this.Btn_SubOnly.Click += new System.EventHandler(this.Btn_SubOnly_Click);
            // 
            // Tbx_Progress
            // 
            this.Tbx_Progress.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Tbx_Progress.Location = new System.Drawing.Point(116, 470);
            this.Tbx_Progress.Name = "Tbx_Progress";
            this.Tbx_Progress.ReadOnly = true;
            this.Tbx_Progress.Size = new System.Drawing.Size(656, 29);
            this.Tbx_Progress.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(17, 462);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 42);
            this.label2.TabIndex = 31;
            this.label2.Text = "進度Progress:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tbx_Progress);
            this.Controls.Add(this.Btn_SubOnly);
            this.Controls.Add(this.Tbx_Info);
            this.Controls.Add(this.Btn_Update_yt_dlp);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Video);
            this.Controls.Add(this.Btn_Clear_Link);
            this.Controls.Add(this.Btn_mp3);
            this.Controls.Add(this.Btn_Wrk_Dir);
            this.Controls.Add(this.Tbx_Wrk_Dir);
            this.Controls.Add(this.Tbx_Link);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 550);
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "Frm_Main";
            this.Text = "簡易影片/音樂下載器 Simple yt-dlp GUI By CHL v";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tbx_Link;
        internal System.Windows.Forms.TextBox Tbx_Wrk_Dir;
        internal System.Windows.Forms.Button Btn_Wrk_Dir;
        
        internal System.Windows.Forms.Button Btn_Video;
        internal System.Windows.Forms.Button Btn_mp3;
        internal System.Windows.Forms.Button Btn_Clear_Link;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox Cbx_YT_Subs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Rbn_Res_Unlimited;
        private System.Windows.Forms.RadioButton Rbn_Res_1440P;
        private System.Windows.Forms.RadioButton Rbn_Res_1080P;
        private System.Windows.Forms.RadioButton Rbn_Res_720P;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button Btn_Update_yt_dlp;
        private System.Windows.Forms.RichTextBox Tbx_Info;
        internal System.Windows.Forms.Button Btn_SubOnly;
        internal System.Windows.Forms.TextBox Tbx_Progress;
        private System.Windows.Forms.Label label2;
    }
}

