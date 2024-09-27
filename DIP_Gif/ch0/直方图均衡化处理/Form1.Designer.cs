namespace 直方图均衡化处理
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_getpic = new System.Windows.Forms.Button();
            this.btn_calgray = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btn_gray = new System.Windows.Forms.Button();
            this.btn_smooth = new System.Windows.Forms.Button();
            this.btn_rouhua = new System.Windows.Forms.Button();
            this.btn_ruihua = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_wuhua = new System.Windows.Forms.Button();
            this.btn_dipian = new System.Windows.Forms.Button();
            this.btn_fudiao = new System.Windows.Forms.Button();
            this.btn_size = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 234);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(349, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(245, 234);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_getpic
            // 
            this.btn_getpic.Location = new System.Drawing.Point(497, 287);
            this.btn_getpic.Name = "btn_getpic";
            this.btn_getpic.Size = new System.Drawing.Size(80, 30);
            this.btn_getpic.TabIndex = 2;
            this.btn_getpic.Text = "获取图像";
            this.btn_getpic.UseVisualStyleBackColor = true;
            this.btn_getpic.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_calgray
            // 
            this.btn_calgray.Location = new System.Drawing.Point(497, 335);
            this.btn_calgray.Name = "btn_calgray";
            this.btn_calgray.Size = new System.Drawing.Size(80, 30);
            this.btn_calgray.TabIndex = 3;
            this.btn_calgray.Text = "直方图均衡化处理";
            this.btn_calgray.UseVisualStyleBackColor = true;
            this.btn_calgray.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(27, 287);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(245, 234);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // btn_gray
            // 
            this.btn_gray.Location = new System.Drawing.Point(333, 335);
            this.btn_gray.Name = "btn_gray";
            this.btn_gray.Size = new System.Drawing.Size(80, 30);
            this.btn_gray.TabIndex = 4;
            this.btn_gray.Text = "灰度图";
            this.btn_gray.UseVisualStyleBackColor = true;
            this.btn_gray.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_smooth
            // 
            this.btn_smooth.Location = new System.Drawing.Point(333, 287);
            this.btn_smooth.Name = "btn_smooth";
            this.btn_smooth.Size = new System.Drawing.Size(80, 30);
            this.btn_smooth.TabIndex = 6;
            this.btn_smooth.Text = "平滑处理";
            this.btn_smooth.UseVisualStyleBackColor = true;
            this.btn_smooth.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_rouhua
            // 
            this.btn_rouhua.Location = new System.Drawing.Point(333, 385);
            this.btn_rouhua.Name = "btn_rouhua";
            this.btn_rouhua.Size = new System.Drawing.Size(80, 30);
            this.btn_rouhua.TabIndex = 7;
            this.btn_rouhua.Text = "柔化处理";
            this.btn_rouhua.UseVisualStyleBackColor = true;
            this.btn_rouhua.Click += new System.EventHandler(this.btn_rouhua_Click);
            // 
            // btn_ruihua
            // 
            this.btn_ruihua.Location = new System.Drawing.Point(497, 385);
            this.btn_ruihua.Name = "btn_ruihua";
            this.btn_ruihua.Size = new System.Drawing.Size(80, 30);
            this.btn_ruihua.TabIndex = 8;
            this.btn_ruihua.Text = "锐化处理";
            this.btn_ruihua.UseVisualStyleBackColor = true;
            this.btn_ruihua.Click += new System.EventHandler(this.btn_jianrui_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(482, 548);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(80, 30);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "保存图像";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "图片1",
            "图片2",
            "图片3"});
            this.comboBox1.Location = new System.Drawing.Point(578, 554);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(113, 20);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Text = "请选择图像";
            // 
            // btn_wuhua
            // 
            this.btn_wuhua.Location = new System.Drawing.Point(333, 437);
            this.btn_wuhua.Name = "btn_wuhua";
            this.btn_wuhua.Size = new System.Drawing.Size(80, 30);
            this.btn_wuhua.TabIndex = 11;
            this.btn_wuhua.Text = "雾化处理";
            this.btn_wuhua.UseVisualStyleBackColor = true;
            this.btn_wuhua.Click += new System.EventHandler(this.btn_wuhua_Click);
            // 
            // btn_dipian
            // 
            this.btn_dipian.Location = new System.Drawing.Point(497, 437);
            this.btn_dipian.Name = "btn_dipian";
            this.btn_dipian.Size = new System.Drawing.Size(80, 30);
            this.btn_dipian.TabIndex = 12;
            this.btn_dipian.Text = "底片效果";
            this.btn_dipian.UseVisualStyleBackColor = true;
            this.btn_dipian.Click += new System.EventHandler(this.btn_dipian_Click);
            // 
            // btn_fudiao
            // 
            this.btn_fudiao.Location = new System.Drawing.Point(333, 491);
            this.btn_fudiao.Name = "btn_fudiao";
            this.btn_fudiao.Size = new System.Drawing.Size(80, 30);
            this.btn_fudiao.TabIndex = 13;
            this.btn_fudiao.Text = "浮雕效果";
            this.btn_fudiao.UseVisualStyleBackColor = true;
            this.btn_fudiao.Click += new System.EventHandler(this.btn_fudiao_Click);
            // 
            // btn_size
            // 
            this.btn_size.Location = new System.Drawing.Point(497, 491);
            this.btn_size.Name = "btn_size";
            this.btn_size.Size = new System.Drawing.Size(80, 30);
            this.btn_size.TabIndex = 14;
            this.btn_size.Text = "缩放";
            this.btn_size.UseVisualStyleBackColor = true;
            this.btn_size.Click += new System.EventHandler(this.btn_size_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(602, 500);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(77, 21);
            this.textBox1.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 586);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_size);
            this.Controls.Add(this.btn_fudiao);
            this.Controls.Add(this.btn_dipian);
            this.Controls.Add(this.btn_wuhua);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_ruihua);
            this.Controls.Add(this.btn_rouhua);
            this.Controls.Add(this.btn_smooth);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btn_gray);
            this.Controls.Add(this.btn_calgray);
            this.Controls.Add(this.btn_getpic);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_getpic;
        private System.Windows.Forms.Button btn_calgray;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btn_gray;
        private System.Windows.Forms.Button btn_smooth;
        private System.Windows.Forms.Button btn_rouhua;
        private System.Windows.Forms.Button btn_ruihua;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_wuhua;
        private System.Windows.Forms.Button btn_dipian;
        private System.Windows.Forms.Button btn_fudiao;
        private System.Windows.Forms.Button btn_size;
        private System.Windows.Forms.TextBox textBox1;
    }
}

