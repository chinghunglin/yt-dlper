using System;
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
using System.Security.Policy;
using static System.Windows.Forms.LinkLabel;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace yt_dlper
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public string Wrk_Dir { get; private set; }
        private string Command = "";
        private string Exe_Name = "yt-dlp.exe ";
        private string YT_Vid_Parameters = "";
        private string Mp3_Parameters = "";
        private const string Sub_Parameters = " --write-subs --write-auto-sub --sub-lang "
                                            + "\"zh-TW,zh-CN,zh-Hant,zh-Hans,zh-Hant-zh-CN,zh-Hans-zh-CN\" ";
        private int Total_cnt = 0;
        private int OK_cnt = 0;
        private int NG_cnt = 0;

        private void Btn_Wrk_Dir_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                Wrk_Dir = FolderBrowserDialog1.SelectedPath;

                Tbx_Wrk_Dir.Text = Wrk_Dir;
            }

        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Wrk_Dir = Directory.GetCurrentDirectory();

            Tbx_Wrk_Dir.Text = Wrk_Dir;

            FolderBrowserDialog1.SelectedPath = Wrk_Dir;

            Check_Requirements();

            if (Same_Proc()) {
                MessageBox.Show("相同的程式已經在執行中！Duplicated process is running!");
                this.Close();
            }

            // setting window title with version number
            this.Text += File_Version();
        }

        private bool Same_Proc()
        {
            Process process = Process.GetCurrentProcess();
            var dupl = Process.GetProcessesByName(process.ProcessName);

            if (dupl.Length > 1) {
                //MessageBox.Show($"{process.ProcessName} have {dupl.Length} processes!!!");
                return true;
            }

            return false;
        }

        private void Check_Requirements()
        {
            // check if the yt-dlp.exe exist
            if (!File.Exists("yt-dlp.exe"))
            {
                MessageBox.Show("yt-dlp.exe 不存在 isn't existed!");

                Btn_Video.Enabled = false;
                Btn_mp3.Enabled = false;
            }
        }

        private bool Link_NG(string link)
        {
            if (link.Length == 0)
            {
                return true;
            }

            if (link.Length == 11)
            {
                // trying with https://www.youtube.com/watch?v=LEN_11_String
                return false;
            }

            if (!link.ToLower().Contains("http"))
            {
                return true;
            }

            return false;
        }

        private string AutoCompleteToYTLink(string link)
        {
            return "https://www.youtube.com/watch?v=" + link;
        }

        private void Single_Download(string link)
        {
            String Full_Command = string.Empty;

            Tbx_Info.Text = string.Empty;

            if (Link_NG(link))
            {
                MessageBox.Show($"{link}下載連結無效 Download link is invalid.");
                return;
            }

            if (link.Length == 11)
            {
                link = AutoCompleteToYTLink(link);
            }

            Tbx_Info.AppendText($"開始嘗試下載第{Total_cnt}個連結\r\n" + 
                    $"Start trying download No.{Total_cnt} link...\r\n");
            Tbx_Info.Refresh();
            Disable_Download_Btns();

    
            if (Is_YT_Link(link))
            {
                Full_Command = $"{Exe_Name} {YT_Vid_Parameters} {Mp3_Parameters} ";

                if (Cbx_YT_Subs.Checked) {
                    Full_Command += $" {Sub_Parameters} ";
                }
            }
            else 
            {
                Full_Command = $"{Exe_Name} {Mp3_Parameters}";
            }

            // add the download Path parameter and link
            Full_Command += $" -P \'{Wrk_Dir}\'  {link.Trim()}";

            Tbx_Info.AppendText($"{Full_Command}\r\n");

            // 建立 Process 物件並設定相關屬性
            Process process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = $"-Command \"{Full_Command}\"";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            //process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            
            // 清空 StandardOutput
            process.OutputDataReceived += (sender, e) => { };

            // 開始執行 PowerShell
            process.Start();

            // 讀取輸出
            string output = string.Empty;
            output = process.StandardOutput.ReadToEnd();

            // 等待 PowerShell 執行完畢
            process.WaitForExit();

            // 清除 StandardOutput
            process.StandardOutput.ReadToEnd();

            // 將換行符號轉換為 TextBox 所需的換行格式
            output = output.Replace("\n", "\r\n");

            // 顯示powershell執行過程
            Tbx_Info.AppendText(output);
            //Tbx_Info.AppendText(string.Format("N'{0}'", output));

            // 分析執行結果
            Tbx_Info.AppendText(Analysis_Download_Result(output) + "\r\n");

            Tbx_Info.AppendText($"{OK_cnt}/{Total_cnt} 下載OK。");

            Tbx_Info.SelectionLength = 0;
            Tbx_Info.SelectionStart = Tbx_Info.Text.Length;
            Tbx_Info.Focus();
            Tbx_Info.ScrollToCaret();

            if (NG_cnt > 0)
            {
                Tbx_Info.AppendText($"\r\n {NG_cnt} 下載NG。");
            }
            
            Enable_Download_Btns();
        }

        private void Reset_Cnt()
        {
            OK_cnt = 0;
            NG_cnt = 0;
            Total_cnt = 0;
        }

        private bool Is_YT_Link(string url)
        {
            if (url.ToLower().Contains("youtube"))
            {
                return true; //youtu.be
            } 
            else if (url.ToLower().Contains("youtu.be"))
            {
                return true; //youtu.be
            }

            return false;
        }

        private void Btn_SubOnly_Click(object sender, EventArgs e)
        {
            Mp3_Parameters = "";
            Cbx_YT_Subs.Checked = true;
            YT_Vid_Parameters = " --skip-download ";
            Whole_download();
        }

        private void Btn_Video_Click(object sender, EventArgs e)
        {
            Mp3_Parameters = "";

            if (Rbn_Res_Unlimited.Checked != false)
            {
                YT_Vid_Parameters = "";
            }
            else
            {
                YT_Vid_Parameters = "-f bestvideo[height<=";

                if (Rbn_Res_720P.Checked)
                {
                    YT_Vid_Parameters += "720";
                }
                else if (Rbn_Res_1080P.Checked)
                {
                    YT_Vid_Parameters += "1080";
                }
                else if (Rbn_Res_1440P.Checked)
                {
                    YT_Vid_Parameters += "1440";
                }

                YT_Vid_Parameters += "][ext=webm]+bestaudio[ext=webm]/best[ext=mp4]/best ";
            }


            Whole_download();
        }

        private void Btn_mp3_Click(object sender, EventArgs e)
        {
            Cbx_YT_Subs.Checked = false;

            YT_Vid_Parameters = "";
            Mp3_Parameters = "--extract-audio -x --audio-format mp3 ";

            Whole_download();
        }

        private void Whole_download()
        {
            string[] links = Tbx_Link.Lines;

            foreach (string link in links)
            {
                if(link.Trim().Length == 0)
                {
                    continue;
                }

                // 使用&作為分隔符號將字串拆分成子字串，藉此去除掉從&開始的字元
                string[] substrings = link.Split('&');

                Total_cnt++;
                Single_Download(substrings[0]);

                Thread.Sleep(500);
            }

            Reset_Cnt();
        }

        private string File_Version()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            return version;
        }

        private void Btn_Clear_Link_Click(object sender, EventArgs e)
        {
            Tbx_Link.Text = string.Empty;
            Tbx_Info.Text = string.Empty;

            Tbx_Link.Refresh();
            Tbx_Info.Refresh();

            Reset_Cnt();
        }

        private void Disable_Download_Btns()
        { 
            Btn_Video.Enabled = false;
            Btn_mp3.Enabled = false;
        }

        private void Enable_Download_Btns()
        {
            Btn_Video.Enabled = true;
            Btn_mp3.Enabled = true;
        }

        private string Analysis_Download_Result(string str_to_check)
        { 
            if (str_to_check.Contains("has already been downloaded")) {
                OK_cnt++;
                return "已經下載過此檔案。Already been downloaded";
            }

            if (str_to_check.Contains("Merging") 
                && str_to_check.Contains("Deleting original file"))
            {
                OK_cnt++;
                return "影片下載已完成。Download completed.";
            }

            if (str_to_check.Contains("[ExtractAudio] Destination")
                && str_to_check.Contains("mp3")
                && str_to_check.Contains("Deleting original file"))
            {
                OK_cnt++;
                return "mp3下載已完成。Download completed.";
            }

            if (str_to_check.Contains("100%"))
            {
                OK_cnt++;
                return "影片下載已完成。Download completed.";
            }

            NG_cnt++;
            return "下載失敗！Download failed.";
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/chinghunglin/yt-dlper");
        }

        private void Btn_Update_yt_dlp_Click(object sender, EventArgs e)
        {
            Tbx_Info.Text = string.Empty;

            Disable_Download_Btns();

            // make sure there is space between link and command
            String Update_Command = "yt-dlp.exe -U";

            Tbx_Info.AppendText($"{Update_Command}\r\n");

            // 建立 Process 物件並設定相關屬性
            Process process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = $"-Command \"{Update_Command}\"";
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

            MessageBox.Show(output);

            // 顯示powershell執行過程
            //Tbx_Info.AppendText(output);
            Tbx_Info.AppendText(string.Format("N'{0}'", output));

            Enable_Download_Btns();
        }
    }
}
