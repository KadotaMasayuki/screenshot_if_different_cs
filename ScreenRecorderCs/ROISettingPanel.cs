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
    /// ROI設定用パネル
    /// </summary>
    public partial class ROISettingPanel : UserControl
    {
        MainForm parent = null;
        Bitmap parentImage = null;
        float imageMagnification = 1.0f;
        bool topLeftMouseMode = false;
        bool bottomRightMouseMode = false;
        Bitmap lastROIBmp = null;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent">親コントロール</param>
        /// <param name="parentImage">ROI設定パネルが対象とする画像</param>
        public ROISettingPanel(MainForm parent, Bitmap parentImage)
        {
            InitializeComponent();

            // 親コントロールを登録
            this.parent = parent;

            // ROI外形は画像サイズと等しくしておく
            topNumericUpDown.Value = 0;
            leftNumericUpDown.Value = 0;
            bottomNumericUpDown.Value = parentImage.Height;
            rightNumericUpDown.Value = parentImage.Width;

            // 画像を登録する。最初なので、比較はしない
            UpdateImage(parentImage, false);
        }


        /// <summary>
        /// 画像を更新する
        /// </summary>
        /// <param name="parentImage">対象とする画像</param>
        /// <param name="compareROI">ROI領域を比較するか</param>
        /// <returns>
        /// compareROIがtrueであれば、ROI部分を前回画像と比較する。差があればtrueを返す
        /// compareROIがfalseであれば、falseを返す
        /// </returns>
        public bool UpdateImage(Bitmap parentImage, bool compareROI)
        {
            bool isDifferentROI = false;
            this.parentImage = parentImage;
            imageMagnification = Math.Min((float)pictureBox1.Width / parentImage.Width, (float)pictureBox1.Height / parentImage.Height);
            Bitmap newROIBmp = GetROIImage(parentImage);
            if (compareROI)
            {
                isDifferentROI = IsDifferentROI(newROIBmp);
            }
            if (isDifferentROI)
            {
                UpdateSmallImage(true);
            }
            else
            {
                UpdateSmallImage(false);
            }
            lastROIBmp = newROIBmp;
            return isDifferentROI;
        }


        /// <summary>
        /// ROI設定パネルの縮小画像を作る
        /// </summary>
        /// <param name="isDifferentROI">trueであれば、ROI領域に変化あり。赤色で矩形描画。falseであれば変化なし。青色で矩形描画</param>
        private void UpdateSmallImage(bool isDifferentROI)
        {
            Bitmap ROIPBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(ROIPBmp);
            // 縮小画像を作る
            g.DrawImage(parentImage,
                new Rectangle(0, 0, (int)(parentImage.Width * imageMagnification), (int)(parentImage.Height * imageMagnification)),
                new Rectangle(0, 0, parentImage.Width, parentImage.Height),
                GraphicsUnit.Pixel);
            // ROI部分の矩形を描画する
            Pen p;
            if (isDifferentROI)
            {
                p = new Pen(Color.Red, 1.0f);
            }
            else
            {
                p = new Pen(Color.Blue, 1.0f);
            }
            g.DrawRectangle(
                p,
                Decimal.ToInt32(leftNumericUpDown.Value) * imageMagnification,
                decimal.ToInt32(topNumericUpDown.Value) * imageMagnification,
                decimal.ToInt32(rightNumericUpDown.Value - leftNumericUpDown.Value) * imageMagnification,
                decimal.ToInt32(bottomNumericUpDown.Value - topNumericUpDown.Value) * imageMagnification);
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Image = ROIPBmp;
            pictureBox1.Refresh();
            g.Dispose();
        }


        /// <summary>
        /// ROI部分の画像を切り出す
        /// </summary>
        /// <param name="img">ROI部分を切り出したい画像</param>
        /// <returns>切り出したROI画像</returns>
        public Bitmap GetROIImage(Image img)
        {
            Bitmap ROIBmp = new Bitmap(decimal.ToInt32(rightNumericUpDown.Value - leftNumericUpDown.Value), decimal.ToInt32(bottomNumericUpDown.Value - topNumericUpDown.Value));
            Graphics g = Graphics.FromImage(ROIBmp);
            g.DrawImage(img, new Rectangle(0, 0, ROIBmp.Width, ROIBmp.Height), GetRectangle(), GraphicsUnit.Pixel);
            g.Dispose();
            return ROIBmp;
        }


        /// <summary>
        /// 現在のROI画像と、指定した新しいROI画像を比較する。
        /// ピクセルごとに、色の差が規定値以上であれば変化ありとしてカウント。
        /// ROI全体のピクセル数に対して、変化ありのピクセル数が規定割合以上であれば、ROI画像に変化ありと判断する。
        /// </summary>
        /// <param name="newROIBmp">新しいROI画像</param>
        /// <returns>変化があると判断した場合true</returns>
        public bool IsDifferentROI(Bitmap newROIBmp)
        {
            if (lastROIBmp == null)
            {
                return false;
            }
            if (lastROIBmp.Width != newROIBmp.Width)
            {
                return false;
            }
            if (lastROIBmp.Height != newROIBmp.Height)
            {
                return false;
            }
            int thColor = GetThresholdColor();
            double thRate = GetThresholdRate();
            int diffCount = 0;
            double thCount = (lastROIBmp.Width * lastROIBmp.Height * thRate / 100);
            int i = lastROIBmp.Width * lastROIBmp.Height;
            for (int x = 0; x < lastROIBmp.Width; x++)
            {
                for (int y = 0; y < lastROIBmp.Height; y++)
                {
                    i--;
                    Color lastColor = lastROIBmp.GetPixel(x, y);
                    Color currentColor = newROIBmp.GetPixel(x, y);
                    if (Math.Abs(lastColor.R - currentColor.R) >= thColor
                        || Math.Abs(lastColor.G - currentColor.G) >= thColor
                        || Math.Abs(lastColor.B - currentColor.B) >= thColor)
                    {
                        diffCount++;
                        if (diffCount >= thCount)
                        {
                            return true;
                        }
                        else if (thCount - diffCount > i)  // 後続ピクセルを計算しても「差あり」にならないなら、ここでやめる
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// ピクセルごとの、色の変化量の閾値。この値以上であれば、変化ありとする
        /// </summary>
        /// <returns></returns>
        public int GetThresholdColor()
        {
            return Decimal.ToInt32(thresholdColorNumericUpDown.Value);
        }


        /// <summary>
        /// ピクセルごとの、色の変化量の閾値。この値以上であれば、変化ありとする
        /// </summary>
        /// <param name="v">0 to 255</param>
        public void SetThresholdColor(int v)
        {
            thresholdColorNumericUpDown.Value = v;
        }


        /// <summary>
        /// ROI全体に対する、変化のあったピクセルの割合の閾値。この値以上であれば、変化ありとする
        /// </summary>
        /// <returns></returns>
        public double GetThresholdRate()
        {
            return Decimal.ToDouble(thresholdRateNumericUpDown.Value);
        }

        /// <summary>
        /// ROI全体に対する、変化のあったピクセルの割合の閾値。この値以上であれば、変化ありとする
        /// </summary>
        /// <param name="v">0.0 to 100.0</param>
        public void SetThresholdRate(double v)
        {
            thresholdRateNumericUpDown.Value = (decimal)v;
        }
        
        
        /// <summary>
        /// ROIの座標をSystem.Drawing.Rectangleで取得
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            return new Rectangle(Decimal.ToInt32(leftNumericUpDown.Value),
                Decimal.ToInt32(topNumericUpDown.Value),
                Decimal.ToInt32(rightNumericUpDown.Value) - Decimal.ToInt32(leftNumericUpDown.Value),
                Decimal.ToInt32(bottomNumericUpDown.Value) - Decimal.ToInt32(topNumericUpDown.Value));
        }


        /// <summary>
        /// ROIの座標をSystem.Drawing.Rectangleで設定
        /// </summary>
        public void SetRectangle(Rectangle r)
        {
            leftNumericUpDown.Value = r.X;
            topNumericUpDown.Value = r.Y;
            rightNumericUpDown.Value = r.X + r.Width;
            bottomNumericUpDown.Value = r.Y + r.Height;
        }


        /// <summary>
        /// ROI設定パネルを親コントロールから削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            parent.RemoveROISettingPanel(this);
        }
        
        
        /// <summary>
        /// ROIの左上座標を変更する。
        /// このボタン操作を行ってから、画像をクリックすると、その位置を新たな座標にする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WithMouseTopLeftButton_Click(object sender, EventArgs e)
        {
            if (topLeftMouseMode)
            {
                withMouseTopLeftButton.BackColor = Control.DefaultBackColor;
                topLeftMouseMode = false;
            }
            else
            {
                if (!bottomRightMouseMode)
                {
                    withMouseTopLeftButton.BackColor = Color.Orange;
                    topLeftMouseMode = true;
                }
            }
        }


        /// <summary>
        /// ROIの右下座標を変更する。
        /// このボタン操作を行ってから、画像をクリックすると、その位置を新たな座標にする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WithMouseBottomRightButton_Click(object sender, EventArgs e)
        {
            if (bottomRightMouseMode)
            {
                withMouseBottomRightButton.BackColor = Control.DefaultBackColor;
                bottomRightMouseMode = false;
            }
            else
            {
                if (!topLeftMouseMode)
                {
                    withMouseBottomRightButton.BackColor = Color.Orange;
                    bottomRightMouseMode = true;
                }
            }
        }


        /// <summary>
        /// 縮小画像をクリック。ROI座標変更モードでの操作内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (topLeftMouseMode)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                int x1, x2, y1, y2;
                x1 = (int)(me.X / imageMagnification);
                y1 = (int)(me.Y / imageMagnification);
                x2 = (int)(rightNumericUpDown.Value);
                y2 = (int)(bottomNumericUpDown.Value);
                if (x1 < x2)
                {
                    leftNumericUpDown.Value = x1;
                    rightNumericUpDown.Value = x2;
                }
                else
                {
                    leftNumericUpDown.Value = x2;
                    rightNumericUpDown.Value = x1;
                }
                if (y1 < y2)
                {
                    topNumericUpDown.Value = y1;
                    bottomNumericUpDown.Value = y2;
                }
                else
                {
                    topNumericUpDown.Value = y2;
                    bottomNumericUpDown.Value = y1;
                }
                WithMouseTopLeftButton_Click(null, null);
                UpdateSmallImage(false);
            }
            else if (bottomRightMouseMode)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                int x1, x2, y1, y2;
                x1 = (int)(leftNumericUpDown.Value);
                y1 = (int)(topNumericUpDown.Value);
                x2 = (int)(me.X / imageMagnification);
                y2 = (int)(me.Y / imageMagnification);
                if (x1 < x2)
                {
                    leftNumericUpDown.Value = x1;
                    rightNumericUpDown.Value = x2;
                }
                else
                {
                    leftNumericUpDown.Value = x2;
                    rightNumericUpDown.Value = x1;
                }
                if (y1 < y2)
                {
                    topNumericUpDown.Value = y1;
                    bottomNumericUpDown.Value = y2;
                }
                else
                {
                    topNumericUpDown.Value = y2;
                    bottomNumericUpDown.Value = y1;
                }
                WithMouseBottomRightButton_Click(null, null);
                UpdateSmallImage(false);
            }
        }


        /// <summary>
        /// ROI座標を数値で変更したときに受け取るイベント。ROI画像を更新し、縮小画像を更新する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ROIPositionChanged(object sender, EventArgs e)
        {
            if (parentImage == null)
            {
                return;
            }
            lastROIBmp = GetROIImage(parentImage);
            UpdateSmallImage(false);
        }
    }
}
