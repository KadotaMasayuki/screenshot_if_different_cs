
namespace ScreenRecorderCs
{
    partial class RORSettingPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.withMouseTopLeftButton = new System.Windows.Forms.Button();
            this.leftNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.topNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.rightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bottomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.withMouseBottomRightButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.leftNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // withMouseTopLeftButton
            // 
            this.withMouseTopLeftButton.Location = new System.Drawing.Point(16, 88);
            this.withMouseTopLeftButton.Name = "withMouseTopLeftButton";
            this.withMouseTopLeftButton.Size = new System.Drawing.Size(128, 23);
            this.withMouseTopLeftButton.TabIndex = 0;
            this.withMouseTopLeftButton.Text = "マウスで左上を指定";
            this.withMouseTopLeftButton.UseVisualStyleBackColor = true;
            this.withMouseTopLeftButton.Click += new System.EventHandler(this.WithMouseTopLeftButton_Click);
            // 
            // leftNumericUpDown
            // 
            this.leftNumericUpDown.Location = new System.Drawing.Point(47, 30);
            this.leftNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.leftNumericUpDown.Name = "leftNumericUpDown";
            this.leftNumericUpDown.Size = new System.Drawing.Size(56, 19);
            this.leftNumericUpDown.TabIndex = 2;
            this.leftNumericUpDown.ValueChanged += new System.EventHandler(this.RORPositionChanged);
            // 
            // topNumericUpDown
            // 
            this.topNumericUpDown.Location = new System.Drawing.Point(89, 6);
            this.topNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.topNumericUpDown.Name = "topNumericUpDown";
            this.topNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.topNumericUpDown.TabIndex = 2;
            this.topNumericUpDown.ValueChanged += new System.EventHandler(this.RORPositionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "左";
            // 
            // rightNumericUpDown
            // 
            this.rightNumericUpDown.Location = new System.Drawing.Point(141, 30);
            this.rightNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.rightNumericUpDown.Name = "rightNumericUpDown";
            this.rightNumericUpDown.Size = new System.Drawing.Size(61, 19);
            this.rightNumericUpDown.TabIndex = 2;
            this.rightNumericUpDown.Value = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.rightNumericUpDown.ValueChanged += new System.EventHandler(this.RORPositionChanged);
            // 
            // bottomNumericUpDown
            // 
            this.bottomNumericUpDown.Location = new System.Drawing.Point(89, 55);
            this.bottomNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.bottomNumericUpDown.Name = "bottomNumericUpDown";
            this.bottomNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.bottomNumericUpDown.TabIndex = 2;
            this.bottomNumericUpDown.Value = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.bottomNumericUpDown.ValueChanged += new System.EventHandler(this.RORPositionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "下";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "上";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "右";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(231, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 139);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // withMouseBottomRightButton
            // 
            this.withMouseBottomRightButton.Location = new System.Drawing.Point(97, 115);
            this.withMouseBottomRightButton.Name = "withMouseBottomRightButton";
            this.withMouseBottomRightButton.Size = new System.Drawing.Size(128, 23);
            this.withMouseBottomRightButton.TabIndex = 0;
            this.withMouseBottomRightButton.Text = "マウスで右下を指定";
            this.withMouseBottomRightButton.UseVisualStyleBackColor = true;
            this.withMouseBottomRightButton.Click += new System.EventHandler(this.WithMouseBottomRightButton_Click);
            // 
            // RORSettingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bottomNumericUpDown);
            this.Controls.Add(this.topNumericUpDown);
            this.Controls.Add(this.rightNumericUpDown);
            this.Controls.Add(this.leftNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.withMouseBottomRightButton);
            this.Controls.Add(this.withMouseTopLeftButton);
            this.Name = "RORSettingPanel";
            this.Size = new System.Drawing.Size(594, 143);
            ((System.ComponentModel.ISupportInitialize)(this.leftNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button withMouseTopLeftButton;
        private System.Windows.Forms.NumericUpDown leftNumericUpDown;
        private System.Windows.Forms.NumericUpDown topNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown rightNumericUpDown;
        private System.Windows.Forms.NumericUpDown bottomNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button withMouseBottomRightButton;
    }
}
