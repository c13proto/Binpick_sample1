namespace Binpick1
{
    partial class 検査対象画像画面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.textBox_CannyTH1 = new System.Windows.Forms.TextBox();
            this.trackBar_CannyTH1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar_CannyTH2 = new System.Windows.Forms.TrackBar();
            this.textBox_CannyTH2 = new System.Windows.Forms.TextBox();
            this.label_座標 = new System.Windows.Forms.Label();
            this.色 = new System.Windows.Forms.Label();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_Binary = new System.Windows.Forms.TrackBar();
            this.textBox_Binary = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_CannyTH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_CannyTH2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Binary)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(90, 4);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(414, 328);
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            this.pictureBoxIpl1.Click += new System.EventHandler(this.OnClick_pictureBoxIpl1);
            this.pictureBoxIpl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_pictureBoxIpl1);
            // 
            // textBox_CannyTH1
            // 
            this.textBox_CannyTH1.Location = new System.Drawing.Point(59, 56);
            this.textBox_CannyTH1.Name = "textBox_CannyTH1";
            this.textBox_CannyTH1.Size = new System.Drawing.Size(25, 19);
            this.textBox_CannyTH1.TabIndex = 2;
            this.textBox_CannyTH1.Text = "0";
            this.textBox_CannyTH1.TextChanged += new System.EventHandler(this.TextChanged_CannyTH1);
            // 
            // trackBar_CannyTH1
            // 
            this.trackBar_CannyTH1.AutoSize = false;
            this.trackBar_CannyTH1.Location = new System.Drawing.Point(3, 77);
            this.trackBar_CannyTH1.Maximum = 255;
            this.trackBar_CannyTH1.Name = "trackBar_CannyTH1";
            this.trackBar_CannyTH1.Size = new System.Drawing.Size(79, 19);
            this.trackBar_CannyTH1.TabIndex = 3;
            this.trackBar_CannyTH1.ValueChanged += new System.EventHandler(this.ValueChanged_TB_CannyTH1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "<Canny>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "TH1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "TH2";
            // 
            // trackBar_CannyTH2
            // 
            this.trackBar_CannyTH2.AutoSize = false;
            this.trackBar_CannyTH2.Location = new System.Drawing.Point(1, 126);
            this.trackBar_CannyTH2.Maximum = 255;
            this.trackBar_CannyTH2.Name = "trackBar_CannyTH2";
            this.trackBar_CannyTH2.Size = new System.Drawing.Size(79, 17);
            this.trackBar_CannyTH2.TabIndex = 14;
            this.trackBar_CannyTH2.Value = 180;
            this.trackBar_CannyTH2.ValueChanged += new System.EventHandler(this.ValueChanged_TB_CannyTH2);
            // 
            // textBox_CannyTH2
            // 
            this.textBox_CannyTH2.Location = new System.Drawing.Point(59, 103);
            this.textBox_CannyTH2.Name = "textBox_CannyTH2";
            this.textBox_CannyTH2.Size = new System.Drawing.Size(25, 19);
            this.textBox_CannyTH2.TabIndex = 13;
            this.textBox_CannyTH2.Text = "180";
            this.textBox_CannyTH2.TextChanged += new System.EventHandler(this.TextChanged_CannyTH2);
            // 
            // label_座標
            // 
            this.label_座標.AutoSize = true;
            this.label_座標.Location = new System.Drawing.Point(12, 32);
            this.label_座標.Name = "label_座標";
            this.label_座標.Size = new System.Drawing.Size(27, 12);
            this.label_座標.TabIndex = 16;
            this.label_座標.Text = "(x,y)";
            // 
            // 色
            // 
            this.色.AutoSize = true;
            this.色.Location = new System.Drawing.Point(70, 13);
            this.色.Name = "色";
            this.色.Size = new System.Drawing.Size(10, 12);
            this.色.TabIndex = 17;
            this.色.Text = "?";
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(38, 10);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(26, 19);
            this.textBox_y.TabIndex = 19;
            this.textBox_y.Text = "y";
            this.textBox_y.TextChanged += new System.EventHandler(this.TextChanged_y);
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(5, 10);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(27, 19);
            this.textBox_x.TabIndex = 18;
            this.textBox_x.Text = "x";
            this.textBox_x.TextChanged += new System.EventHandler(this.TextChanged_x);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "開始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClick比較開始);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "二値化";
            // 
            // trackBar_Binary
            // 
            this.trackBar_Binary.AutoSize = false;
            this.trackBar_Binary.Location = new System.Drawing.Point(5, 183);
            this.trackBar_Binary.Maximum = 255;
            this.trackBar_Binary.Name = "trackBar_Binary";
            this.trackBar_Binary.Size = new System.Drawing.Size(79, 19);
            this.trackBar_Binary.TabIndex = 29;
            this.trackBar_Binary.Value = 250;
            this.trackBar_Binary.ValueChanged += new System.EventHandler(this.ValueChanged_Binary);
            // 
            // textBox_Binary
            // 
            this.textBox_Binary.Location = new System.Drawing.Point(62, 158);
            this.textBox_Binary.Name = "textBox_Binary";
            this.textBox_Binary.Size = new System.Drawing.Size(25, 19);
            this.textBox_Binary.TabIndex = 28;
            this.textBox_Binary.Text = "250";
            this.textBox_Binary.TextChanged += new System.EventHandler(this.TextChanged_Binary);
            // 
            // 検査対象画像画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(515, 344);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar_Binary);
            this.Controls.Add(this.textBox_Binary);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.色);
            this.Controls.Add(this.label_座標);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBar_CannyTH2);
            this.Controls.Add(this.textBox_CannyTH2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar_CannyTH1);
            this.Controls.Add(this.textBox_CannyTH1);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "検査対象画像画面";
            this.Text = "検査画像画面";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_CannyTH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_CannyTH2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Binary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.TextBox textBox_CannyTH1;
        private System.Windows.Forms.TrackBar trackBar_CannyTH1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar_CannyTH2;
        private System.Windows.Forms.TextBox textBox_CannyTH2;
        private System.Windows.Forms.Label label_座標;
        private System.Windows.Forms.Label 色;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar_Binary;
        private System.Windows.Forms.TextBox textBox_Binary;
    }
}