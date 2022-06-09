
namespace ScreenRecorderCs
{
    partial class MainForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addROIPanelButton = new System.Windows.Forms.Button();
            this.fileNameStartTextBox = new System.Windows.Forms.TextBox();
            this.intervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setDirectoryButton = new System.Windows.Forms.Button();
            this.startMovieButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.imageFormatComboBox = new System.Windows.Forms.ComboBox();
            this.save1ShotButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 266);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(625, 265);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // addROIPanelButton
            // 
            this.addROIPanelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addROIPanelButton.Image = ((System.Drawing.Image)(resources.GetObject("addROIPanelButton.Image")));
            this.addROIPanelButton.Location = new System.Drawing.Point(3, 3);
            this.addROIPanelButton.Name = "addROIPanelButton";
            this.addROIPanelButton.Size = new System.Drawing.Size(32, 23);
            this.addROIPanelButton.TabIndex = 1;
            this.addROIPanelButton.UseVisualStyleBackColor = true;
            this.addROIPanelButton.Click += new System.EventHandler(this.AddROIPanelButton_Click);
            // 
            // fileNameStartTextBox
            // 
            this.fileNameStartTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fileNameStartTextBox.Location = new System.Drawing.Point(313, 5);
            this.fileNameStartTextBox.Name = "fileNameStartTextBox";
            this.fileNameStartTextBox.Size = new System.Drawing.Size(88, 19);
            this.fileNameStartTextBox.TabIndex = 3;
            this.fileNameStartTextBox.Text = "ScreenRecord";
            // 
            // intervalNumericUpDown
            // 
            this.intervalNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.intervalNumericUpDown.DecimalPlaces = 1;
            this.intervalNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.intervalNumericUpDown.Location = new System.Drawing.Point(100, 5);
            this.intervalNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.intervalNumericUpDown.Name = "intervalNumericUpDown";
            this.intervalNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.intervalNumericUpDown.TabIndex = 2;
            this.intervalNumericUpDown.Value = new decimal(new int[] {
            80,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "監視頻度";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "秒";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "ファイル名先頭";
            // 
            // setDirectoryButton
            // 
            this.setDirectoryButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.setDirectoryButton.Image = ((System.Drawing.Image)(resources.GetObject("setDirectoryButton.Image")));
            this.setDirectoryButton.Location = new System.Drawing.Point(194, 3);
            this.setDirectoryButton.Name = "setDirectoryButton";
            this.setDirectoryButton.Size = new System.Drawing.Size(32, 23);
            this.setDirectoryButton.TabIndex = 4;
            this.setDirectoryButton.UseVisualStyleBackColor = true;
            this.setDirectoryButton.Click += new System.EventHandler(this.SetDirectoryButton_Click);
            // 
            // startMovieButton
            // 
            this.startMovieButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.startMovieButton.Image = ((System.Drawing.Image)(resources.GetObject("startMovieButton.Image")));
            this.startMovieButton.Location = new System.Drawing.Point(469, 3);
            this.startMovieButton.Name = "startMovieButton";
            this.startMovieButton.Size = new System.Drawing.Size(32, 23);
            this.startMovieButton.TabIndex = 6;
            this.startMovieButton.UseVisualStyleBackColor = true;
            this.startMovieButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.Location = new System.Drawing.Point(3, 37);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(625, 62);
            this.logTextBox.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.logTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(631, 534);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.addROIPanelButton);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.intervalNumericUpDown);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.setDirectoryButton);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.fileNameStartTextBox);
            this.flowLayoutPanel2.Controls.Add(this.imageFormatComboBox);
            this.flowLayoutPanel2.Controls.Add(this.startMovieButton);
            this.flowLayoutPanel2.Controls.Add(this.save1ShotButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(625, 28);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // imageFormatComboBox
            // 
            this.imageFormatComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.imageFormatComboBox.FormattingEnabled = true;
            this.imageFormatComboBox.Items.AddRange(new object[] {
            "PNG",
            "JPG",
            "BMP"});
            this.imageFormatComboBox.Location = new System.Drawing.Point(407, 4);
            this.imageFormatComboBox.Name = "imageFormatComboBox";
            this.imageFormatComboBox.Size = new System.Drawing.Size(56, 20);
            this.imageFormatComboBox.TabIndex = 5;
            this.imageFormatComboBox.Text = "PNG";
            // 
            // save1ShotButton
            // 
            this.save1ShotButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.save1ShotButton.Image = ((System.Drawing.Image)(resources.GetObject("save1ShotButton.Image")));
            this.save1ShotButton.Location = new System.Drawing.Point(507, 3);
            this.save1ShotButton.Name = "save1ShotButton";
            this.save1ShotButton.Size = new System.Drawing.Size(32, 23);
            this.save1ShotButton.TabIndex = 7;
            this.save1ShotButton.UseVisualStyleBackColor = true;
            this.save1ShotButton.Click += new System.EventHandler(this.Save1ShotButton_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 155);
            this.panel1.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 534);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addROIPanelButton;
        private System.Windows.Forms.TextBox fileNameStartTextBox;
        private System.Windows.Forms.NumericUpDown intervalNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button setDirectoryButton;
        private System.Windows.Forms.Button startMovieButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox imageFormatComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button save1ShotButton;
        private System.Windows.Forms.Panel panel1;
    }
}

