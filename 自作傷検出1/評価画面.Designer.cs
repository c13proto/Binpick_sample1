﻿namespace Binpick1
{
    partial class 評価画面
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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_1e = new System.Windows.Forms.TextBox();
            this.textBox_1s = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_4e = new System.Windows.Forms.TextBox();
            this.textBox_4s = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_2e = new System.Windows.Forms.TextBox();
            this.textBox_2s = new System.Windows.Forms.TextBox();
            this.textBox_5e = new System.Windows.Forms.TextBox();
            this.textBox_5s = new System.Windows.Forms.TextBox();
            this.開始ボタン = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBox_PfGA = new System.Windows.Forms.CheckBox();
            this.textBox_PfGA = new System.Windows.Forms.TextBox();
            this.textBox_list_num = new System.Windows.Forms.TextBox();
            this.checkBox_list = new System.Windows.Forms.CheckBox();
            this.textBox_list_score = new System.Windows.Forms.TextBox();
            this.textBox_6e = new System.Windows.Forms.TextBox();
            this.textBox_6s = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_3e = new System.Windows.Forms.TextBox();
            this.textBox_3s = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(120, 9);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(295, 293);
            this.pictureBoxIpl1.TabIndex = 1;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Canny";
            // 
            // textBox_1e
            // 
            this.textBox_1e.Location = new System.Drawing.Point(84, 21);
            this.textBox_1e.Name = "textBox_1e";
            this.textBox_1e.Size = new System.Drawing.Size(30, 19);
            this.textBox_1e.TabIndex = 7;
            this.textBox_1e.Text = "255";
            // 
            // textBox_1s
            // 
            this.textBox_1s.Location = new System.Drawing.Point(48, 21);
            this.textBox_1s.Name = "textBox_1s";
            this.textBox_1s.Size = new System.Drawing.Size(30, 19);
            this.textBox_1s.TabIndex = 6;
            this.textBox_1s.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "Param1";
            // 
            // textBox_4e
            // 
            this.textBox_4e.Location = new System.Drawing.Point(87, 97);
            this.textBox_4e.Name = "textBox_4e";
            this.textBox_4e.Size = new System.Drawing.Size(30, 19);
            this.textBox_4e.TabIndex = 14;
            this.textBox_4e.Text = "30";
            // 
            // textBox_4s
            // 
            this.textBox_4s.Location = new System.Drawing.Point(51, 97);
            this.textBox_4s.Name = "textBox_4s";
            this.textBox_4s.Size = new System.Drawing.Size(30, 19);
            this.textBox_4s.TabIndex = 13;
            this.textBox_4s.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Gaussian";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "<検査画像>";
            // 
            // textBox_2e
            // 
            this.textBox_2e.Location = new System.Drawing.Point(84, 46);
            this.textBox_2e.Name = "textBox_2e";
            this.textBox_2e.Size = new System.Drawing.Size(30, 19);
            this.textBox_2e.TabIndex = 10;
            this.textBox_2e.Text = "255";
            // 
            // textBox_2s
            // 
            this.textBox_2s.Location = new System.Drawing.Point(48, 46);
            this.textBox_2s.Name = "textBox_2s";
            this.textBox_2s.Size = new System.Drawing.Size(30, 19);
            this.textBox_2s.TabIndex = 9;
            this.textBox_2s.Text = "0";
            // 
            // textBox_5e
            // 
            this.textBox_5e.Location = new System.Drawing.Point(87, 122);
            this.textBox_5e.Name = "textBox_5e";
            this.textBox_5e.Size = new System.Drawing.Size(30, 19);
            this.textBox_5e.TabIndex = 17;
            this.textBox_5e.Text = "255";
            // 
            // textBox_5s
            // 
            this.textBox_5s.Location = new System.Drawing.Point(51, 122);
            this.textBox_5s.Name = "textBox_5s";
            this.textBox_5s.Size = new System.Drawing.Size(30, 19);
            this.textBox_5s.TabIndex = 16;
            this.textBox_5s.Text = "1";
            // 
            // 開始ボタン
            // 
            this.開始ボタン.Location = new System.Drawing.Point(3, 172);
            this.開始ボタン.Name = "開始ボタン";
            this.開始ボタン.Size = new System.Drawing.Size(75, 23);
            this.開始ボタン.TabIndex = 19;
            this.開始ボタン.Text = "開始";
            this.開始ボタン.UseVisualStyleBackColor = true;
            this.開始ボタン.Click += new System.EventHandler(this.OnClick開始ボタン);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 201);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(111, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // checkBox_PfGA
            // 
            this.checkBox_PfGA.AutoSize = true;
            this.checkBox_PfGA.Checked = true;
            this.checkBox_PfGA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_PfGA.Location = new System.Drawing.Point(6, 230);
            this.checkBox_PfGA.Name = "checkBox_PfGA";
            this.checkBox_PfGA.Size = new System.Drawing.Size(51, 16);
            this.checkBox_PfGA.TabIndex = 22;
            this.checkBox_PfGA.Text = "PfGA";
            this.checkBox_PfGA.UseVisualStyleBackColor = true;
            // 
            // textBox_PfGA
            // 
            this.textBox_PfGA.Location = new System.Drawing.Point(57, 229);
            this.textBox_PfGA.Name = "textBox_PfGA";
            this.textBox_PfGA.Size = new System.Drawing.Size(30, 19);
            this.textBox_PfGA.TabIndex = 23;
            this.textBox_PfGA.Text = "2000";
            // 
            // textBox_list_num
            // 
            this.textBox_list_num.Location = new System.Drawing.Point(71, 274);
            this.textBox_list_num.Name = "textBox_list_num";
            this.textBox_list_num.Size = new System.Drawing.Size(30, 19);
            this.textBox_list_num.TabIndex = 25;
            this.textBox_list_num.Text = "500";
            // 
            // checkBox_list
            // 
            this.checkBox_list.AutoSize = true;
            this.checkBox_list.Location = new System.Drawing.Point(6, 252);
            this.checkBox_list.Name = "checkBox_list";
            this.checkBox_list.Size = new System.Drawing.Size(108, 16);
            this.checkBox_list.TabIndex = 24;
            this.checkBox_list.Text = "遺伝子リスト作成";
            this.checkBox_list.UseVisualStyleBackColor = true;
            // 
            // textBox_list_score
            // 
            this.textBox_list_score.Location = new System.Drawing.Point(2, 274);
            this.textBox_list_score.Name = "textBox_list_score";
            this.textBox_list_score.Size = new System.Drawing.Size(63, 19);
            this.textBox_list_score.TabIndex = 26;
            this.textBox_list_score.Text = "8000,9500";
            // 
            // textBox_6e
            // 
            this.textBox_6e.Location = new System.Drawing.Point(87, 147);
            this.textBox_6e.Name = "textBox_6e";
            this.textBox_6e.Size = new System.Drawing.Size(30, 19);
            this.textBox_6e.TabIndex = 29;
            this.textBox_6e.Text = "60";
            // 
            // textBox_6s
            // 
            this.textBox_6s.Location = new System.Drawing.Point(51, 147);
            this.textBox_6s.Name = "textBox_6s";
            this.textBox_6s.Size = new System.Drawing.Size(30, 19);
            this.textBox_6s.TabIndex = 28;
            this.textBox_6s.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "Param2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "*2+1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.タイマ割り込み);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "二値化";
            // 
            // textBox_3e
            // 
            this.textBox_3e.Location = new System.Drawing.Point(84, 72);
            this.textBox_3e.Name = "textBox_3e";
            this.textBox_3e.Size = new System.Drawing.Size(30, 19);
            this.textBox_3e.TabIndex = 32;
            this.textBox_3e.Text = "255";
            // 
            // textBox_3s
            // 
            this.textBox_3s.Location = new System.Drawing.Point(48, 72);
            this.textBox_3s.Name = "textBox_3s";
            this.textBox_3s.Size = new System.Drawing.Size(30, 19);
            this.textBox_3s.TabIndex = 31;
            this.textBox_3s.Text = "0";
            // 
            // 評価画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(421, 309);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_3e);
            this.Controls.Add(this.textBox_3s);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_6e);
            this.Controls.Add(this.textBox_6s);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_list_score);
            this.Controls.Add(this.textBox_list_num);
            this.Controls.Add(this.checkBox_list);
            this.Controls.Add(this.textBox_PfGA);
            this.Controls.Add(this.checkBox_PfGA);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.開始ボタン);
            this.Controls.Add(this.textBox_5e);
            this.Controls.Add(this.textBox_5s);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_4e);
            this.Controls.Add(this.textBox_4s);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_2e);
            this.Controls.Add(this.textBox_2s);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_1e);
            this.Controls.Add(this.textBox_1s);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "評価画面";
            this.Text = "評価画面";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_1e;
        private System.Windows.Forms.TextBox textBox_1s;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_4e;
        private System.Windows.Forms.TextBox textBox_4s;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_2e;
        private System.Windows.Forms.TextBox textBox_2s;
        private System.Windows.Forms.TextBox textBox_5e;
        private System.Windows.Forms.TextBox textBox_5s;
        private System.Windows.Forms.Button 開始ボタン;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBox_PfGA;
        private System.Windows.Forms.TextBox textBox_PfGA;
        private System.Windows.Forms.TextBox textBox_list_num;
        private System.Windows.Forms.CheckBox checkBox_list;
        private System.Windows.Forms.TextBox textBox_list_score;
        private System.Windows.Forms.TextBox textBox_6e;
        private System.Windows.Forms.TextBox textBox_6s;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_3e;
        private System.Windows.Forms.TextBox textBox_3s;
    }
}