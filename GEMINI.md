# 專案分析：yt-dlper

## 總結

`yt-dlper` 是一個使用 C# 和 Windows Forms (.NET Framework 4.8) 開發的桌面應用程式。它作為流行的命令列工具 `yt-dlp.exe` 的一個圖形化使用者介面 (GUI) 前端，旨在簡化從 YouTube 等影音網站下載影片、音訊和字幕的流程。整個應用程式主要以繁體中文為介面語言。

## 核心功能

1.  **多種下載模式**：
    *   **影片下載**：支援不同解析度（720p, 1080p, 1440p, 或無限制）的影片下載。
    *   **音訊提取**：能將影片轉換並儲存為 MP3 格式。
    *   **僅下載字幕**：可以單獨下載影片的字幕檔案。
2.  **批次處理**：使用者可以在文字方塊中輸入多個影片連結，程式會逐一下載。
3.  **簡易操作**：
    *   支援拖放連結到輸入框。
    *   支援使用 Ctrl+V 貼上連結。
    *   可快速清空連結與輸出訊息。
    *   雙擊下載目錄路徑，可以直接在檔案總管中開啟該資料夾。
4.  **內建更新功能**：提供一個按鈕來執行 `yt-dlp.exe -U` 命令，讓使用者可以隨時將 `yt-dlp` 更新到最新版本。
5.  **即時進度顯示**：透過一個 RichTextBox 控制項，即時顯示 `yt-dlp.exe` 的詳細輸出訊息，讓使用者了解目前的下載進度、合併情況或錯誤訊息。

## 技術細節

*   **語言**：C#
*   **框架**：.NET Framework 4.8, Windows Forms (WinForms)
*   **主要外部工具**：`yt-dlp.exe` (所有核心下載功能都依賴此執行檔)
*   **相依套件**：
    *   `Microsoft.WindowsAPICodePack-Core` 和 `Microsoft.WindowsAPICodePack-Shell`：用於顯示一個比傳統 WinForms 更現代化的資料夾選擇對話框。
    *   **資源嵌入**：從 `Program.cs` 的 `AssemblyResolve` 事件處理方式可以看出，此專案將相依的 DLL 檔案 (`Microsoft.WindowsAPICodePack.*.dll`) 作為嵌入式資源打包到最終的執行檔中。這使得應用程式更具可攜性，發佈時只需要一個 `.exe` 檔案即可。

## 執行流程

1.  **啟動**：`Program.cs` 是應用程式的進入點。它首先設定一個 `AssemblyResolve` 事件，以便在需要時從嵌入的資源中載入 DLL。接著，它會建立並執行主視窗 `Frm_Main`。
2.  **初始化**：`Frm_Main_Load` 事件被觸發。程式會檢查 `yt-dlp.exe` 是否存在於應用程式目錄下，如果不存在，則會禁用下載按鈕。它也會檢查是否有重複的實體正在執行。
3.  **使用者操作**：使用者將一個或多個影片連結貼入 `Tbx_Link` 文字方塊，然後選擇下載類型（影片、MP3、字幕）和相關選項（如解析度）。
4.  **執行下載**：
    *   當使用者點擊下載按鈕時，程式會根據使用者的選擇，動態建立一個要傳遞給 `yt-dlp.exe` 的命令列參數字串。
    *   它會建立一個 `System.Diagnostics.Process` 物件，透過 `powershell.exe` 來執行 `yt-dlp.exe` 加上組合好的參數。
    *   程式會以非同步方式 (`async/await`) 啟動該進程，並監聽其標準輸出 (StandardOutput) 和標準錯誤 (StandardError) 流。
5.  **結果回饋**：
    *   `yt-dlp.exe` 的輸出會被即時地重新導向並顯示在 `Tbx_Info` 文字方塊中。
    *   當一個下載任務完成後，程式會呼叫 `Analysis_Download_Result` 方法來分析輸出文字，判斷下載是成功、失敗還是檔案已存在，並更新成功/失敗的計數器。
6.  **完成**：所有連結處理完畢後，程式會重新啟用下載按鈕，等待下一次操作。

## 檔案結構分析

*   `README.md`: 專案的說明檔案，包含使用需求和基本介紹。
*   `yt-dlper.sln`: Visual Studio 解決方案檔案，用於組織專案。
*   `yt-dlper/yt-dlper.csproj`: C# 專案檔，定義了專案的屬性、參考、相依性等。
*   `yt-dlper/Program.cs`: 應用程式的主要進入點。
*   `yt-dlper/Frm_Main.cs`: 主視窗的後置程式碼，包含了所有的事件處理和核心邏輯。
*   `yt-dlper/Frm_Main.Designer.cs`: WinForms 設計工具自動產生的程式碼，用於定義視窗控制項的佈局和屬性。
*   `yt-dlper/Resources/`: 存放嵌入資源的資料夾，如此專案中的 `Microsoft.WindowsAPICodePack.*.dll`。

## 其他
-   請用正體中文交談
-   請一致使用Windows的 CRLF 換行符號
-   檔案請以 UTF-8 With BOM進行儲存

##   **Coding Standard:**
    - 盡量採用內建或標準函式庫
    - 嵌套(if-else, for, switch)最多三層
    - 用具名函式( Predicate Function ) 取代 Naked Condition
    - 以可測試為前提進行設計，並增加程式碼重用度、可讀性
    - 單一函式長度(包含註解)不超過 45 行
    - 單行長度不超過 120 字元
    - 如果有註解，以簡單直覺的英文書寫
	- 新函式或是重構的函式參數個數不超過5個，超過就用結構或是 DTO 傳送
	- 如果可以就符合 SOLID原則，但不用強行套用