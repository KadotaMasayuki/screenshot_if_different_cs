using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenRecorderCs
{
    /// <summary>
    /// 指定位置のピクセルに変化があった場合、スクリーンキャプチャ全体を保存する
    /// </summary>
    public partial class MainForm : Form
    {
        Bitmap desktopBmp = null;
        string directorySaveTo = AppDomain.CurrentDomain.BaseDirectory;
        bool isRunning = false;
        Timer timer = null;
        List<string> logString = new List<string>();
        ulong counter = 0;


        /// <summary>
        /// タイトルを初期化、タイマーを初期化
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            this.Text = "ScreenRecorder";

            // タイマーを初期化
            timer = new Timer();
            timer.Tick += Timer_Tick;
        }


        /// <summary>
        /// 新しい画像を取得し、管理している複数のROI設定を更新、ROI領域をチェック。いずれかのROI画像で変化ありと判断できればtrueを返す
        /// </summary>
        /// <returns>複数のROI画像のいずれかで変化があればtrue</returns>
        private bool isROIDifferent()
        {
            bool isDifferentROI = false;
            // 新しいスクリーンキャプチャ
            desktopBmp = GetDesktopImage();
            // ROI設定それぞれと、ROI領域を比較
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is ROISettingPanel)
                {
                    ROISettingPanel roip = (ROISettingPanel)c;
                    if (isDifferentROI)
                    {
                        // 変化ありとわかっているので、比較せずに縮小表示の更新のみ。
                        roip.UpdateImage(desktopBmp, false);
                    }
                    else
                    {
                        // 縮小表示の更新と、ROIの比較
                        isDifferentROI = roip.UpdateImage(desktopBmp, true);
                    }
                }
            }
            return isDifferentROI;
        }


        /// <summary>
        /// 新しい画像を保存する
        /// </summary>
        private void ExecSave()
        {
            string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss_fff");
            string filePath = "";
            if (imageFormatComboBox.Text.Equals("JPG", StringComparison.CurrentCultureIgnoreCase))
            {
                filePath = System.IO.Path.Combine(directorySaveTo, fileNameStartTextBox.Text + "_" + dateTimeStr + ".jpg");
                desktopBmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (imageFormatComboBox.Text.Equals("BMP", StringComparison.CurrentCultureIgnoreCase))
            {
                filePath = System.IO.Path.Combine(directorySaveTo, fileNameStartTextBox.Text + "_" + dateTimeStr + ".bmp");
                desktopBmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            else
            {
                filePath = System.IO.Path.Combine(directorySaveTo, fileNameStartTextBox.Text + "_" + dateTimeStr + ".png");
                desktopBmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            }
            WriteLog(filePath);
        }


        /// <summary>
        /// 新しいスクリーンキャプチャを取得。複数ディスプレイに対応
        /// </summary>
        /// <returns>新しいスクリーンキャプチャ</returns>
        private Bitmap GetDesktopImage()
        {
            int totalLeft = 0;
            int totalTop = 0;
            int totalRight = 0;
            int totalBottom = 0;
            // 複数ディスプレイに対応
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                var screen = Screen.AllScreens[i];
                Console.WriteLine("Screen.DeviceName:" + screen.DeviceName);  // デバイス名
                Console.WriteLine("Screen.Bounds.X:" + screen.Bounds.X);  // 画面の左上X座標
                Console.WriteLine("Screen.Bounds.Y:" + screen.Bounds.Y);  // 画面の左上Y座標
                Console.WriteLine("Screen.Bounds.Height:" + screen.Bounds.Height);  // 画面の高さ
                Console.WriteLine("Screen.Bounds.Width:" + screen.Bounds.Width);  // 画面の横幅
                Console.WriteLine("Screen.WorkingArea.Height:" + screen.WorkingArea.Height); // ワーキングエリアの高さ
                Console.WriteLine("Screen.WorkingArea.Width:" + screen.WorkingArea.Width);  // ワーキングエリアの横幅
                // まとめ画像のサイズを計算する
                int left = screen.Bounds.X;
                int top = screen.Bounds.Y;
                int right = screen.Bounds.X + screen.Bounds.Width - 1;
                int bottom = screen.Bounds.Y + screen.Bounds.Height - 1;
                if (left < totalLeft)
                {
                    totalLeft = left;
                }
                if (top < totalTop)
                {
                    totalTop = top;
                }
                if (right > totalRight)
                {
                    totalRight = right;
                }
                if (bottom > totalBottom)
                {
                    totalBottom = bottom;
                }
            }
            Bitmap totalBitmap = new Bitmap((totalRight - totalLeft), (totalBottom - totalTop));
            // 各画面デバイスの画像を配置する
            Graphics g = Graphics.FromImage(totalBitmap);
            g.CopyFromScreen(new Point(totalLeft, totalTop), new Point(0, 0), totalBitmap.Size);
            g.Dispose();
            return totalBitmap;
        }


        /// <summary>
        /// ROI設定パネルを削除
        /// </summary>
        /// <param name="roip">削除したいROI設定パネル</param>
        public void RemoveROISettingPanel(ROISettingPanel roip)
        {
            flowLayoutPanel1.Controls.Remove(roip);
        }


        /// <summary>
        /// ROI設定パネルを追加
        /// </summary>
        /// <param name="bmp">ROI設定パネルに表示する画像</param>
        private void AddNewROIPanel(Bitmap bmp)
        {
            ROISettingPanel roip = new ROISettingPanel(this, bmp);
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                // スクロール許可する(サイズ変更許可するとスクロールしなくなるらしいので注意)
                flowLayoutPanel1.AutoSize = false;
                flowLayoutPanel1.AutoScroll = true;
                flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            }
            flowLayoutPanel1.Controls.Add(roip);
        }


        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="s"></param>
        private void WriteLog(string s)
        {
            logString.Insert(0, s);
            if (logString.Count > 50)
            {
                logString.RemoveAt(logString.Count - 1);
            }
            logTextBox.Text = string.Join("\r\n", logString);
            logTextBox.SelectionStart = 0;
            logTextBox.SelectionLength = 0;
        }


        /// <summary>
        /// タイマーでROIチェック。変化ありと判断した場合、保存。
        /// タイマーで稼働カウンタをログ出力。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            WriteLog(counter.ToString());
            if (isROIDifferent())
            {
                ExecSave();
            }
        }


        /// <summary>
        /// スクリーンキャプチャを保存するフォルダを指定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDirectoryButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "フォルダを選択してください";
            ofd.InitialDirectory = directorySaveTo;
            ofd.Filter = "Foloder|.";
            ofd.FileName = "Select Folder";
            ofd.CheckFileExists = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                directorySaveTo = System.IO.Path.GetDirectoryName(ofd.FileName);
            }
        }


        /// <summary>
        /// 監視＆録画　をスタートする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                // 運転しているので、停止する
                startMovieButton.BackColor = Control.DefaultBackColor;
                isRunning = false;
                timer.Stop();
                intervalNumericUpDown.Enabled = true;
                fileNameStartTextBox.Enabled = true;
                imageFormatComboBox.Enabled = true;
            }
            else
            {
                if (flowLayoutPanel1.Controls.Count == 0)
                {
                    MessageBox.Show("監視設定を1つ以上作成してください", "", MessageBoxButtons.OK);
                    return;
                }
                // 停止しているので、運転開始する
                startMovieButton.BackColor = Color.Red;
                isRunning = true;
                // 1回目は強制発動
                Timer_Tick(null, null);
                // 2回目からはタイマーで
                timer.Interval = decimal.ToInt32(intervalNumericUpDown.Value * 1000);
                timer.Start();
                intervalNumericUpDown.Enabled = false;
                fileNameStartTextBox.Enabled = false;
                imageFormatComboBox.Enabled = false;
            }
        }


        /// <summary>
        /// ROI設定パネルを追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddROIPanelButton_Click(object sender, EventArgs e)
        {
            AddNewROIPanel(GetDesktopImage());
        }


        /// <summary>
        /// 静止画を撮影する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save1ShotButton_Click(object sender, EventArgs e)
        {
            desktopBmp = GetDesktopImage();
            ExecSave();
        }
    }
}
