using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace yt_dlper
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Tbx_Link.DragEnter += new System.Windows.Forms.DragEventHandler(this.Tbx_Link_DragEnter);
            this.Tbx_Link.DragDrop += new System.Windows.Forms.DragEventHandler(this.Tbx_Link_DragDrop);
        }

        public string Wrk_Dir { get; private set; }
        private string Exe_Name = "yt-dlp.exe ";
        private string YT_Vid_Parameters = "";
        private string Mp3_Parameters = "";
        private const string Sub_Parameters = " --write-subs --write-auto-sub --sub-lang "
                                            + "\"zh,zh-TW,zh-CN,zh-Hant,zh-Hans,zh-Hant-zh-CN,zh-Hans-zh-CN\" ";
        private int Total_cnt = 0;
        private int OK_cnt = 0;
        private int NG_cnt = 0;

        private void Btn_Wrk_Dir_Click(object sender, EventArgs e)
        {
            using (var cofd = new CommonOpenFileDialog())
            {
                cofd.InitialDirectory = Wrk_Dir;
                cofd.IsFolderPicker = true;
                cofd.Title = "選擇儲存目錄";

                if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Wrk_Dir = cofd.FileName;
                    Tbx_Wrk_Dir.Text = Wrk_Dir;
                }
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Wrk_Dir = Directory.GetCurrentDirectory();

            Tbx_Wrk_Dir.Text = Wrk_Dir;

            

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

        private Task Single_Download(string link)
        {
            if (Link_NG(link))
            {
                MessageBox.Show($"{link} 下載連結無效 Download link is invalid.");
                return Task.CompletedTask;
            }

            if (link.Length == 11)
            {
                link = AutoCompleteToYTLink(link);
            }

            this.Invoke((MethodInvoker)delegate
            {
                Tbx_Info.AppendText($"開始嘗試下載第{Total_cnt}個連結\r\n" +
                                    $"Start trying download No.{Total_cnt} link...\r\n");
                ScrollToCaret(this.Tbx_Info);
            });

            return ExecuteDownloadAsync(link);
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

        private async void Btn_SubOnly_Click(object sender, EventArgs e)
        {
            Mp3_Parameters = "";
            Cbx_YT_Subs.Checked = true;
            YT_Vid_Parameters = " --skip-download ";
            await Whole_download();
        }

        private async void Btn_Video_Click(object sender, EventArgs e)
        {
            Mp3_Parameters = "";

            if (Rbn_Res_Unlimited.Checked)
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

            await Whole_download();
        }

        private async void Btn_mp3_Click(object sender, EventArgs e)
        {
            Cbx_YT_Subs.Checked = false;

            YT_Vid_Parameters = "";
            Mp3_Parameters = "--extract-audio -x --audio-format mp3 ";

            await Whole_download();
        }

        private async Task Whole_download()
        {
            Preaction();
            Disable_Download_Btns();

            string[] links = RemoveEmptyLines(Tbx_Link.Lines);
            Reset_Cnt();

            try
            {
                foreach (string link in links)
                {
                    // 使用&作為分隔符號將字串拆分成子字串，藉此去除掉從&開始的字元
                    string[] substrings = link.Split('&');

                    Total_cnt++;
                    Tbx_Progress.Text = $"[{Total_cnt}/{links.Length}] {substrings[0]}";
                    await Single_Download(substrings[0]);

                    await Task.Delay(500); // Replaces Thread.Sleep
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"下載過程中發生錯誤: {ex.Message}\r\n{ex.StackTrace}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable_Download_Btns();
            }
        }

        private static string[] RemoveEmptyLines(string[] inputArray)
        {
            return inputArray
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToArray();
        }

        // Minimize window or something else
        private void Preaction()
        {
            //this.WindowState = FormWindowState.Minimized;
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
            Tbx_Progress.Text = string.Empty;

            Tbx_Link.Refresh();
            Tbx_Info.Refresh();
            Tbx_Progress.Refresh();

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
            process.StartInfo.Arguments = $"-Command \"$OutputEncoding = [System.Text.Encoding]::UTF8; {Update_Command}\" ";
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
            Tbx_Info.AppendText(string.Format("N'{{0}}'", output));

            Enable_Download_Btns();
        }

        private void Tbx_Link_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Tbx_Link_DragDrop(object sender, DragEventArgs e)
        {
            string link = (string)e.Data.GetData(DataFormats.Text);
            Tbx_Link.AppendText(link + Environment.NewLine);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V))
            {
                if (Clipboard.ContainsText())
                {
                    Tbx_Link.AppendText(Clipboard.GetText() + Environment.NewLine);
                    return true; // 表示我們已經處理了這個按鍵
                }
            }
            return base.ProcessCmdKey(ref msg, keyData); // 其他按鍵交給基底類別處理
        }

        private Task ExecuteDownloadAsync(string link)
        {
            var tcs = new TaskCompletionSource<bool>();

            string fullCommand;
            if (Is_YT_Link(link))
            {
                fullCommand = $"{Exe_Name} {YT_Vid_Parameters} {Mp3_Parameters} ";
                if (Cbx_YT_Subs.Checked)
                {
                    fullCommand += $" {Sub_Parameters} ";
                }
            }
            else
            {
                fullCommand = $"{Exe_Name} {Mp3_Parameters}";
            }
            fullCommand += $" -P \"{Wrk_Dir}\"  {link.Trim()}";

            this.Invoke((MethodInvoker)delegate
            {
                Tbx_Info.AppendText($"{fullCommand}\r\n");
                ScrollToCaret(this.Tbx_Info);
            });

            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powershell.exe",
                    Arguments = $"-Command \"$OutputEncoding = [System.Text.Encoding]::UTF8; {fullCommand}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.Default,
                    StandardErrorEncoding = Encoding.Default
                },
                EnableRaisingEvents = true
            };

            var outputBuilder = new StringBuilder();
            var syncLock = new object();

            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    lock (syncLock)
                    {
                        outputBuilder.AppendLine(e.Data);
                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        Tbx_Info.AppendText(e.Data + "\r\n");
                        ScrollToCaret(this.Tbx_Info);
                    });
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    lock (syncLock)
                    {
                        outputBuilder.AppendLine(e.Data);
                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        Tbx_Info.AppendText("ERROR: " + e.Data + "\r\n");
                        ScrollToCaret(this.Tbx_Info);
                    });
                }
            };

            process.Exited += (sender, e) =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    string finalOutput;
                    lock (syncLock)
                    {
                        finalOutput = outputBuilder.ToString();
                    }
                    Tbx_Info.AppendText(Analysis_Download_Result(finalOutput) + "\r\n");
                    Tbx_Info.AppendText($"{OK_cnt}/{Total_cnt} 下載OK.\r\n");
                    if (NG_cnt > 0)
                    {
                        Tbx_Info.AppendText($"{NG_cnt} 下載NG.\r\n");
                    }
                    ScrollToCaret(this.Tbx_Info);
                });
                tcs.SetResult(true);
                process.Dispose();
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return tcs.Task;
        }

        private void ScrollToCaret(RichTextBox tb)
        {
            tb.SelectionStart = tb.Text.Length;
            tb.ScrollToCaret();
        }
    }
}