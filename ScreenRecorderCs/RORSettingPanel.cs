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
    /// ROR(記録画像範囲)設定用パネル
    /// </summary>
    public partial class RORSettingPanel : UserControl
    {
        Bitmap parentImage = null;
        float imageMagnification = 1.0f;
        bool topLeftMouseMode = false;
        bool bottomRightMouseMode = false;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent">親コントロール</param>
        /// <param name="parentImage">ROR設定パネルが対象とする画像</param>
        public RORSettingPanel(Bitmap parentImage)
        {
            InitializeComponent();

            // ROR外形は画像サイズと等しくしておく
            topNumericUpDown.Value = 0;
            leftNumericUpDown.Value = 0;
            bottomNumericUpDown.Value = parentImage.Height;
            rightNumericUpDown.Value = parentImage.Width;

            // 画像を登録する。最初なので、比較はしない
            UpdateImage(parentImage);
        }


        /// <summary>
        /// 画像を更新する
        /// </summary>
        /// <param name="parentImage">対象とする画像</param>
        public void UpdateImage(Bitmap parentImage)
        {
            this.parentImage = parentImage;
            imageMagnification = Math.Min((float)pictureBox1.Width / parentImage.Width, (float)pictureBox1.Height / parentImage.Height);
            UpdateSmallImage();
        }


        /// <summary>
        /// 記録範囲設定パネルの縮小画像を作る
        /// </summary>
        private void UpdateSmallImage()
        {
            Bitmap smallBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(smallBmp);
            // 縮小画像を作る
            g.DrawImage(parentImage,
                new Rectangle(0, 0, (int)(parentImage.Width * imageMagnification), (int)(parentImage.Height * imageMagnification)),
                new Rectangle(0, 0, parentImage.Width, parentImage.Height),
                GraphicsUnit.Pixel);
            // 記録範囲矩形を描画する
            Pen p;
            p = new Pen(Color.Blue, 1.0f);
            g.DrawRectangle(
                p,
                Decimal.ToInt32(leftNumericUpDown.Value) * imageMagnification,
                decimal.ToInt32(topNumericUpDown.Value) * imageMagnification,
                decimal.ToInt32(rightNumericUpDown.Value - leftNumericUpDown.Value) * imageMagnification,
                decimal.ToInt32(bottomNumericUpDown.Value - topNumericUpDown.Value) * imageMagnification);
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Image = smallBmp;
            pictureBox1.Refresh();
            g.Dispose();
        }


        /// <summary>
        /// ROR部分の画像を切り出す
        /// </summary>
        /// <param name="img">ROR部分を切り出したい画像</param>
        /// <returns>切り出したROR画像</returns>
        public Bitmap GetRORImage(Image img)
        {
            Bitmap rorBmp = new Bitmap(decimal.ToInt32(rightNumericUpDown.Value - leftNumericUpDown.Value), decimal.ToInt32(bottomNumericUpDown.Value - topNumericUpDown.Value));
            Graphics g = Graphics.FromImage(rorBmp);
            g.DrawImage(img, new Rectangle(0, 0, rorBmp.Width, rorBmp.Height), GetRectangle(), GraphicsUnit.Pixel);
            g.Dispose();
            return rorBmp;
        }

        
        /// <summary>
        /// RORの座標をSystem.Drawing.Rectangleで取得
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
        /// RORの座標をSystem.Drawing.Rectangleで設定
        /// </summary>
        public void SetRectangle(Rectangle r)
        {
            leftNumericUpDown.Value = r.X;
            topNumericUpDown.Value = r.Y;
            rightNumericUpDown.Value = r.X + r.Width;
            bottomNumericUpDown.Value = r.Y + r.Height;
        }


        /// <summary>
        /// RORの左上座標を変更する。
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
        /// RORの右下座標を変更する。
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
        /// 縮小画像をクリック。ROR座標変更モードでの操作内容
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
                UpdateSmallImage();
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
                UpdateSmallImage();
            }
        }


        /// <summary>
        /// ROR座標を数値で変更したときに受け取るイベント。縮小画像を更新する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RORPositionChanged(object sender, EventArgs e)
        {
            if (parentImage == null)
            {
                return;
            }
            UpdateSmallImage();
        }
    }
}
