﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace yt_dlper
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public string Wrk_Dir { get; private set; }
        public string Command = "";

        private void Btn_Wrk_Dir_Click(object sender, EventArgs e)
        {
            if(FolderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                Wrk_Dir = FolderBrowserDialog1.SelectedPath;

                Tbx_Wrk_Dir.Text = Wrk_Dir;
            }
            
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Wrk_Dir = Directory.GetCurrentDirectory();

            Tbx_Wrk_Dir.Text = Wrk_Dir;

            FolderBrowserDialog1.SelectedPath = Wrk_Dir;
        }

        private bool Link_NG(string link)
        { 
            if (link.Length == 0 )
            {
                return true;
            }

            if (!link.ToLower().Contains("http"))
            {
                return true;
            }

            return false;
        }


        private void single_download(string link)
        {
            Tbx_Info.Text = string.Empty;

            if (Link_NG(link))
            {
                MessageBox.Show("下載連結無效");
                return;
            }

            Tbx_Info.AppendText("開始嘗試下載\r\n");
            Disable_Download_Btns();

            // make sure there is space between link and command
            Command += " ";
            Command += link.Trim();
            Tbx_Info.AppendText($"{Command}\r\n");

            // 建立 Process 物件並設定相關屬性
            Process process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = $"-Command \"{Command}\"";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // 開始執行 PowerShell
            process.Start();

            // 讀取輸出
            string output = process.StandardOutput.ReadToEnd();

            // 等待 PowerShell 執行完畢
            process.WaitForExit();

            // 將換行符號轉換為 TextBox 所需的換行格式
            output = output.Replace("\n", "\r\n");

            // 顯示powershell執行過程
            Tbx_Info.AppendText(output);

            // 分析執行結果
            Tbx_Info.AppendText(Analysis_Download_Result(output));

            Enable_Download_Btns();
        }

        private void Btn_mp4_Click(object sender, EventArgs e)
        {
            if (Rbn_Unlimited.Checked)
            {
                Command = "yt-dlp.exe ";
            }
            else {
                Command = "yt-dlp.exe -f bestvideo[height<=";

                if (Rbn_720P.Checked)
                {
                    Command += "720";
                }
                else if (Rbn_1080P.Checked)
                {
                    Command += "1080";
                }
                else if (Rbn_1440P.Checked)
                {
                    Command += "1440";
                }

                Command += "][ext=webm]+bestaudio[ext=webm]/best[ext=mp4]/best ";
            }

            if (Cbx_Subs.Checked)
            {
                Command += " --write-subs ";
            }

            Whole_download();
        }

        private void Btn_mp3_Click(object sender, EventArgs e)
        {
            Cbx_Subs.Checked = false;

            Command = "yt-dlp.exe --extract-audio -x --audio-format mp3 ";

            Whole_download();
        }

        private void Whole_download()
        {
            string[] links = Tbx_Link.Lines;

            foreach (string link in links)
            {
                single_download(link);
            }
        }

        private void Btn_Clear_Link_Click(object sender, EventArgs e)
        {
            Tbx_Link.Text = string.Empty;
        }

        private void Disable_Download_Btns()
        { 
            Btn_mp4.Enabled = false;
            Btn_mp3.Enabled = false;
        }

        private void Enable_Download_Btns()
        {
            Btn_mp4.Enabled = true;
            Btn_mp3.Enabled = true;
        }

        private string Analysis_Download_Result(string str_to_check)
        { 
            if (str_to_check.Contains("has already been downloaded")) {
                return "已經下載過此檔案。";
            }

            if (str_to_check.Contains("Merging") 
                && str_to_check.Contains("Deleting original file"))
            {
                return "影片下載已完成。";
            }

            if (str_to_check.Contains("[ExtractAudio] Destination")
                && str_to_check.Contains("mp3")
                && str_to_check.Contains("Deleting original file"))
            {
                return "mp3下載已完成。";
            }
            
            return "下載失敗";
        }

        private void Tbx_Wrk_Dir_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", Wrk_Dir);
            }
            catch (Exception ex)
            {
                // 處理開啟目錄失敗的例外情況
                MessageBox.Show("Failed to open directory: " + ex.Message);
            }
        }

        private void Tbx_Info_DoubleClick(object sender, EventArgs e)
        {
            Tbx_Info.Text = string.Empty;
        }
    }
}
