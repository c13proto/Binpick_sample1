namespace Binpick1
{
    partial class メイン画面
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.検査画像参照ボタン = new System.Windows.Forms.Button();
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.label_座標 = new System.Windows.Forms.Label();
            this.色 = new System.Windows.Forms.Label();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.評価画面ボタン = new System.Windows.Forms.Button();
            this.目標参照ボタン = new System.Windows.Forms.Button();
            this.円検出開始ボタン = new System.Windows.Forms.Button();
            this.trackBar_GaussSize = new System.Windows.Forms.TrackBar();
            this.trackBar_Canny = new System.Windows.Forms.TrackBar();
            this.textBox_GaussSize = new System.Windows.Forms.TextBox();
            this.textBox_Canny = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar_minR = new System.Windows.Forms.TrackBar();
            this.trackBar_param2 = new System.Windows.Forms.TrackBar();
            this.trackBar_minDist = new System.Windows.Forms.TrackBar();
            this.textBox_minR = new System.Windows.Forms.TextBox();
            this.textBox_param2 = new System.Windows.Forms.TextBox();
            this.textBox_minDist = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_maxR = new System.Windows.Forms.TextBox();
            this.trackBar_maxR = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_GaussSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Canny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_minR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_param2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_minDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_maxR)).BeginInit();
            this.SuspendLayout();
            // 
            // 検査画像参照ボタン
            // 
            this.検査画像参照ボタン.Location = new System.Drawing.Point(13, 64);
            this.検査画像参照ボタン.Name = "検査画像参照ボタン";
            this.検査画像参照ボタン.Size = new System.Drawing.Size(75, 23);
            this.検査画像参照ボタン.TabIndex = 1;
            this.検査画像参照ボタン.Text = "検査参照";
            this.検査画像参照ボタン.UseVisualStyleBackColor = true;
            this.検査画像参照ボタン.Click += new System.EventHandler(this.OnClick検査参照);
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(94, 11);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(564, 456);
            this.pictureBoxIpl1.TabIndex = 3;
            this.pictureBoxIpl1.TabStop = false;
            this.pictureBoxIpl1.Click += new System.EventHandler(this.OnClick_pictureBoxIpl1);
            this.pictureBoxIpl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_pictureBoxIpl1);
            // 
            // label_座標
            // 
            this.label_座標.AutoSize = true;
            this.label_座標.Location = new System.Drawing.Point(11, 49);
            this.label_座標.Name = "label_座標";
            this.label_座標.Size = new System.Drawing.Size(27, 12);
            this.label_座標.TabIndex = 4;
            this.label_座標.Text = "(x,y)";
            // 
            // 色
            // 
            this.色.AutoSize = true;
            this.色.Location = new System.Drawing.Point(76, 30);
            this.色.Name = "色";
            this.色.Size = new System.Drawing.Size(10, 12);
            this.色.TabIndex = 5;
            this.色.Text = "?";
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(44, 27);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(26, 19);
            this.textBox_y.TabIndex = 13;
            this.textBox_y.Text = "y";
            this.textBox_y.TextChanged += new System.EventHandler(this.TextChanged_y);
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(11, 27);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(27, 19);
            this.textBox_x.TabIndex = 12;
            this.textBox_x.Text = "x";
            this.textBox_x.TextChanged += new System.EventHandler(this.TextChanged_x);
            // 
            // 評価画面ボタン
            // 
            this.評価画面ボタン.Location = new System.Drawing.Point(8, 444);
            this.評価画面ボタン.Name = "評価画面ボタン";
            this.評価画面ボタン.Size = new System.Drawing.Size(75, 23);
            this.評価画面ボタン.TabIndex = 17;
            this.評価画面ボタン.Text = "評価画面";
            this.評価画面ボタン.UseVisualStyleBackColor = true;
            this.評価画面ボタン.Click += new System.EventHandler(this.OnClick_評価画面);
            // 
            // 目標参照ボタン
            // 
            this.目標参照ボタン.Location = new System.Drawing.Point(8, 415);
            this.目標参照ボタン.Name = "目標参照ボタン";
            this.目標参照ボタン.Size = new System.Drawing.Size(75, 23);
            this.目標参照ボタン.TabIndex = 18;
            this.目標参照ボタン.Text = "目標参照";
            this.目標参照ボタン.UseVisualStyleBackColor = true;
            this.目標参照ボタン.Click += new System.EventHandler(this.Click_目標参照ボタン);
            // 
            // 円検出開始ボタン
            // 
            this.円検出開始ボタン.Location = new System.Drawing.Point(10, 386);
            this.円検出開始ボタン.Name = "円検出開始ボタン";
            this.円検出開始ボタン.Size = new System.Drawing.Size(75, 23);
            this.円検出開始ボタン.TabIndex = 19;
            this.円検出開始ボタン.Text = "円検出開始";
            this.円検出開始ボタン.UseVisualStyleBackColor = true;
            this.円検出開始ボタン.Click += new System.EventHandler(this.Click_円検出開始ボタン);
            // 
            // trackBar_GaussSize
            // 
            this.trackBar_GaussSize.AutoSize = false;
            this.trackBar_GaussSize.Location = new System.Drawing.Point(2, 114);
            this.trackBar_GaussSize.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar_GaussSize.Maximum = 15;
            this.trackBar_GaussSize.Name = "trackBar_GaussSize";
            this.trackBar_GaussSize.Size = new System.Drawing.Size(59, 19);
            this.trackBar_GaussSize.TabIndex = 20;
            this.trackBar_GaussSize.ValueChanged += new System.EventHandler(this.ValueChanged_TB_GaussNum);
            // 
            // trackBar_Canny
            // 
            this.trackBar_Canny.AutoSize = false;
            this.trackBar_Canny.Location = new System.Drawing.Point(2, 166);
            this.trackBar_Canny.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar_Canny.Maximum = 255;
            this.trackBar_Canny.Minimum = 1;
            this.trackBar_Canny.Name = "trackBar_Canny";
            this.trackBar_Canny.Size = new System.Drawing.Size(59, 19);
            this.trackBar_Canny.TabIndex = 21;
            this.trackBar_Canny.Value = 100;
            this.trackBar_Canny.ValueChanged += new System.EventHandler(this.ValueChanged_TB_Canny);
            // 
            // textBox_GaussSize
            // 
            this.textBox_GaussSize.Location = new System.Drawing.Point(64, 114);
            this.textBox_GaussSize.Name = "textBox_GaussSize";
            this.textBox_GaussSize.Size = new System.Drawing.Size(26, 19);
            this.textBox_GaussSize.TabIndex = 22;
            this.textBox_GaussSize.Text = "0";
            this.textBox_GaussSize.TextChanged += new System.EventHandler(this.TextChanged_GaussNum);
            // 
            // textBox_Canny
            // 
            this.textBox_Canny.Location = new System.Drawing.Point(64, 166);
            this.textBox_Canny.Name = "textBox_Canny";
            this.textBox_Canny.Size = new System.Drawing.Size(26, 19);
            this.textBox_Canny.TabIndex = 23;
            this.textBox_Canny.Text = "100";
            this.textBox_Canny.TextChanged += new System.EventHandler(this.TextChanged_Canny);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "<GaussSize>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "<Canny>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "th2=th1/2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "val*2+1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "Hough Param1";
            // 
            // trackBar_minR
            // 
            this.trackBar_minR.AutoSize = false;
            this.trackBar_minR.Location = new System.Drawing.Point(2, 323);
            this.trackBar_minR.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar_minR.Maximum = 20;
            this.trackBar_minR.Name = "trackBar_minR";
            this.trackBar_minR.Size = new System.Drawing.Size(59, 19);
            this.trackBar_minR.TabIndex = 29;
            this.trackBar_minR.Value = 5;
            this.trackBar_minR.ValueChanged += new System.EventHandler(this.ValueChanged_minR);
            // 
            // trackBar_param2
            // 
            this.trackBar_param2.AutoSize = false;
            this.trackBar_param2.Location = new System.Drawing.Point(2, 290);
            this.trackBar_param2.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar_param2.Maximum = 60;
            this.trackBar_param2.Minimum = 20;
            this.trackBar_param2.Name = "trackBar_param2";
            this.trackBar_param2.Size = new System.Drawing.Size(59, 19);
            this.trackBar_param2.TabIndex = 30;
            this.trackBar_param2.Value = 20;
            this.trackBar_param2.ValueChanged += new System.EventHandler(this.ValueChanged_param2);
            // 
            // trackBar_minDist
            // 
            this.trackBar_minDist.AutoSize = false;
            this.trackBar_minDist.Location = new System.Drawing.Point(2, 253);
            this.trackBar_minDist.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar_minDist.Maximum = 50;
            this.trackBar_minDist.Minimum = 1;
            this.trackBar_minDist.Name = "trackBar_minDist";
            this.trackBar_minDist.Size = new System.Drawing.Size(59, 19);
            this.trackBar_minDist.TabIndex = 31;
            this.trackBar_minDist.Value = 5;
            this.trackBar_minDist.ValueChanged += new System.EventHandler(this.ValueChanged_minDist);
            // 
            // textBox_minR
            // 
            this.textBox_minR.Location = new System.Drawing.Point(62, 323);
            this.textBox_minR.Name = "textBox_minR";
            this.textBox_minR.Size = new System.Drawing.Size(26, 19);
            this.textBox_minR.TabIndex = 32;
            this.textBox_minR.Text = "5";
            this.textBox_minR.TextChanged += new System.EventHandler(this.TextChanged_minR);
            // 
            // textBox_param2
            // 
            this.textBox_param2.Location = new System.Drawing.Point(62, 287);
            this.textBox_param2.Name = "textBox_param2";
            this.textBox_param2.Size = new System.Drawing.Size(26, 19);
            this.textBox_param2.TabIndex = 33;
            this.textBox_param2.Text = "20";
            this.textBox_param2.TextChanged += new System.EventHandler(this.TextChanged_param2);
            // 
            // textBox_minDist
            // 
            this.textBox_minDist.Location = new System.Drawing.Point(62, 251);
            this.textBox_minDist.Name = "textBox_minDist";
            this.textBox_minDist.Size = new System.Drawing.Size(26, 19);
            this.textBox_minDist.TabIndex = 34;
            this.textBox_minDist.Text = "5";
            this.textBox_minDist.TextChanged += new System.EventHandler(this.TextChanged_minDist);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "<Hough>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "minDist";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "param2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "minR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 349);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 12);
            this.label10.TabIndex = 41;
            this.label10.Text = "maxR";
            // 
            // textBox_maxR
            // 
            this.textBox_maxR.Location = new System.Drawing.Point(62, 361);
            this.textBox_maxR.Name = "textBox_maxR";
            this.textBox_maxR.Size = new System.Drawing.Size(26, 19);
            this.textBox_maxR.TabIndex = 40;
            this.textBox_maxR.Text = "25";
            this.textBox_maxR.TextChanged += new System.EventHandler(this.TextChanged_maxR);
            // 
            // trackBar_maxR
            // 
            this.trackBar_maxR.AutoSize = false;
            this.trackBar_maxR.Location = new System.Drawing.Point(2, 361);
            this.trackBar_maxR.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar_maxR.Maximum = 50;
            this.trackBar_maxR.Name = "trackBar_maxR";
            this.trackBar_maxR.Size = new System.Drawing.Size(59, 19);
            this.trackBar_maxR.TabIndex = 39;
            this.trackBar_maxR.Value = 25;
            this.trackBar_maxR.ValueChanged += new System.EventHandler(this.ValueChanged_maxR);
            // 
            // メイン画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(664, 471);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_maxR);
            this.Controls.Add(this.trackBar_maxR);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_minDist);
            this.Controls.Add(this.textBox_param2);
            this.Controls.Add(this.textBox_minR);
            this.Controls.Add(this.trackBar_minDist);
            this.Controls.Add(this.trackBar_param2);
            this.Controls.Add(this.trackBar_minR);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Canny);
            this.Controls.Add(this.textBox_GaussSize);
            this.Controls.Add(this.trackBar_Canny);
            this.Controls.Add(this.trackBar_GaussSize);
            this.Controls.Add(this.円検出開始ボタン);
            this.Controls.Add(this.目標参照ボタン);
            this.Controls.Add(this.評価画面ボタン);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.色);
            this.Controls.Add(this.label_座標);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Controls.Add(this.検査画像参照ボタン);
            this.Name = "メイン画面";
            this.Text = "メイン画面";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_GaussSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Canny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_minR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_param2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_minDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_maxR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 検査画像参照ボタン;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Label label_座標;
        private System.Windows.Forms.Label 色;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.Button 評価画面ボタン;
        private System.Windows.Forms.Button 目標参照ボタン;
        private System.Windows.Forms.Button 円検出開始ボタン;
        private System.Windows.Forms.TrackBar trackBar_GaussSize;
        private System.Windows.Forms.TrackBar trackBar_Canny;
        private System.Windows.Forms.TextBox textBox_GaussSize;
        private System.Windows.Forms.TextBox textBox_Canny;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar_minR;
        private System.Windows.Forms.TrackBar trackBar_param2;
        private System.Windows.Forms.TrackBar trackBar_minDist;
        private System.Windows.Forms.TextBox textBox_minR;
        private System.Windows.Forms.TextBox textBox_param2;
        private System.Windows.Forms.TextBox textBox_minDist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_maxR;
        private System.Windows.Forms.TrackBar trackBar_maxR;
    }
}

