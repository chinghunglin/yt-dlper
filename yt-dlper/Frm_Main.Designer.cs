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
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Btn_mp4 = new System.Windows.Forms.Button();
            this.Btn_mp3 = new System.Windows.Forms.Button();
            this.Tbx_Info = new System.Windows.Forms.TextBox();
            this.Btn_Clear_Link = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Cbx_Subs = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Rbn_Unlimited = new System.Windows.Forms.RadioButton();
            this.Rbn_1440P = new System.Windows.Forms.RadioButton();
            this.Rbn_1080P = new System.Windows.Forms.RadioButton();
            this.Rbn_720P = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "影片網址:Links:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Tbx_Link
            // 
            this.Tbx_Link.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Tbx_Link.Location = new System.Drawing.Point(112, 21);
            this.Tbx_Link.Multiline = true;
            this.Tbx_Link.Name = "Tbx_Link";
            this.Tbx_Link.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tbx_Link.Size = new System.Drawing.Size(437, 88);
            this.Tbx_Link.TabIndex = 1;
            // 
            // Tbx_Wrk_Dir
            // 
            this.Tbx_Wrk_Dir.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Tbx_Wrk_Dir.Location = new System.Drawing.Point(112, 121);
            this.Tbx_Wrk_Dir.Name = "Tbx_Wrk_Dir";
            this.Tbx_Wrk_Dir.ReadOnly = true;
            this.Tbx_Wrk_Dir.Size = new System.Drawing.Size(500, 29);
            this.Tbx_Wrk_Dir.TabIndex = 17;
            this.Tbx_Wrk_Dir.DoubleClick += new System.EventHandler(this.Tbx_Wrk_Dir_DoubleClick);
            // 
            // Btn_Wrk_Dir
            // 
            this.Btn_Wrk_Dir.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Wrk_Dir.Location = new System.Drawing.Point(4, 120);
            this.Btn_Wrk_Dir.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Wrk_Dir.Name = "Btn_Wrk_Dir";
            this.Btn_Wrk_Dir.Size = new System.Drawing.Size(106, 30);
            this.Btn_Wrk_Dir.TabIndex = 18;
            this.Btn_Wrk_Dir.Text = "下載到(To):";
            this.Btn_Wrk_Dir.UseVisualStyleBackColor = true;
            this.Btn_Wrk_Dir.Click += new System.EventHandler(this.Btn_Wrk_Dir_Click);
            // 
            // Btn_mp4
            // 
            this.Btn_mp4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_mp4.Location = new System.Drawing.Point(402, 173);
            this.Btn_mp4.Name = "Btn_mp4";
            this.Btn_mp4.Size = new System.Drawing.Size(97, 36);
            this.Btn_mp4.TabIndex = 19;
            this.Btn_mp4.Text = "下載 MP4";
            this.Btn_mp4.UseVisualStyleBackColor = true;
            this.Btn_mp4.Click += new System.EventHandler(this.Btn_mp4_Click);
            // 
            // Btn_mp3
            // 
            this.Btn_mp3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_mp3.Location = new System.Drawing.Point(508, 173);
            this.Btn_mp3.Name = "Btn_mp3";
            this.Btn_mp3.Size = new System.Drawing.Size(104, 36);
            this.Btn_mp3.TabIndex = 20;
            this.Btn_mp3.Text = "只下載MP3";
            this.Btn_mp3.UseVisualStyleBackColor = true;
            this.Btn_mp3.Click += new System.EventHandler(this.Btn_mp3_Click);
            // 
            // Tbx_Info
            // 
            this.Tbx_Info.AcceptsReturn = true;
            this.Tbx_Info.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.Tbx_Info.Location = new System.Drawing.Point(20, 230);
            this.Tbx_Info.Multiline = true;
            this.Tbx_Info.Name = "Tbx_Info";
            this.Tbx_Info.ReadOnly = true;
            this.Tbx_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tbx_Info.Size = new System.Drawing.Size(592, 201);
            this.Tbx_Info.TabIndex = 21;
            this.Tbx_Info.DoubleClick += new System.EventHandler(this.Tbx_Info_DoubleClick);
            // 
            // Btn_Clear_Link
            // 
            this.Btn_Clear_Link.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Clear_Link.Location = new System.Drawing.Point(555, 40);
            this.Btn_Clear_Link.Name = "Btn_Clear_Link";
            this.Btn_Clear_Link.Size = new System.Drawing.Size(57, 51);
            this.Btn_Clear_Link.TabIndex = 22;
            this.Btn_Clear_Link.Text = "清空 Clear";
            this.Btn_Clear_Link.UseVisualStyleBackColor = true;
            this.Btn_Clear_Link.Click += new System.EventHandler(this.Btn_Clear_Link_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // Cbx_Subs
            // 
            this.Cbx_Subs.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Cbx_Subs.Location = new System.Drawing.Point(6, 16);
            this.Cbx_Subs.Name = "Cbx_Subs";
            this.Cbx_Subs.Size = new System.Drawing.Size(120, 46);
            this.Cbx_Subs.TabIndex = 23;
            this.Cbx_Subs.Text = "YT字幕Subs    (如果有)";
            this.Cbx_Subs.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Cbx_Subs);
            this.groupBox1.Location = new System.Drawing.Point(6, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 68);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "影片選項";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Rbn_Unlimited);
            this.groupBox2.Controls.Add(this.Rbn_1440P);
            this.groupBox2.Controls.Add(this.Rbn_1080P);
            this.groupBox2.Controls.Add(this.Rbn_720P);
            this.groupBox2.Location = new System.Drawing.Point(121, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 46);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "最大解析度 Max Resolution";
            // 
            // Rbn_Unlimited
            // 
            this.Rbn_Unlimited.AutoSize = true;
            this.Rbn_Unlimited.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.Rbn_Unlimited.Location = new System.Drawing.Point(206, 18);
            this.Rbn_Unlimited.Name = "Rbn_Unlimited";
            this.Rbn_Unlimited.Size = new System.Drawing.Size(54, 22);
            this.Rbn_Unlimited.TabIndex = 28;
            this.Rbn_Unlimited.Text = "不限";
            this.Rbn_Unlimited.UseVisualStyleBackColor = true;
            // 
            // Rbn_1440P
            // 
            this.Rbn_1440P.AutoSize = true;
            this.Rbn_1440P.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.Rbn_1440P.Location = new System.Drawing.Point(136, 18);
            this.Rbn_1440P.Name = "Rbn_1440P";
            this.Rbn_1440P.Size = new System.Drawing.Size(67, 22);
            this.Rbn_1440P.TabIndex = 27;
            this.Rbn_1440P.Text = "1440P";
            this.Rbn_1440P.UseVisualStyleBackColor = true;
            // 
            // Rbn_1080P
            // 
            this.Rbn_1080P.AutoSize = true;
            this.Rbn_1080P.Checked = true;
            this.Rbn_1080P.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.Rbn_1080P.Location = new System.Drawing.Point(66, 18);
            this.Rbn_1080P.Name = "Rbn_1080P";
            this.Rbn_1080P.Size = new System.Drawing.Size(67, 22);
            this.Rbn_1080P.TabIndex = 26;
            this.Rbn_1080P.TabStop = true;
            this.Rbn_1080P.Text = "1080P";
            this.Rbn_1080P.UseVisualStyleBackColor = true;
            // 
            // Rbn_720P
            // 
            this.Rbn_720P.AutoSize = true;
            this.Rbn_720P.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.Rbn_720P.Location = new System.Drawing.Point(4, 18);
            this.Rbn_720P.Name = "Rbn_720P";
            this.Rbn_720P.Size = new System.Drawing.Size(59, 22);
            this.Rbn_720P.TabIndex = 25;
            this.Rbn_720P.Text = "720P";
            this.Rbn_720P.UseVisualStyleBackColor = true;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(621, 445);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_mp4);
            this.Controls.Add(this.Btn_Clear_Link);
            this.Controls.Add(this.Tbx_Info);
            this.Controls.Add(this.Btn_mp3);
            this.Controls.Add(this.Btn_Wrk_Dir);
            this.Controls.Add(this.Tbx_Wrk_Dir);
            this.Controls.Add(this.Tbx_Link);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Main";
            this.Text = "簡易影片/音樂下載器 Simeple yt-dlp GUI By CHL V 1.3";
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
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        internal System.Windows.Forms.Button Btn_mp4;
        internal System.Windows.Forms.Button Btn_mp3;
        private System.Windows.Forms.TextBox Tbx_Info;
        internal System.Windows.Forms.Button Btn_Clear_Link;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox Cbx_Subs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Rbn_Unlimited;
        private System.Windows.Forms.RadioButton Rbn_1440P;
        private System.Windows.Forms.RadioButton Rbn_1080P;
        private System.Windows.Forms.RadioButton Rbn_720P;
    }
}

