using System;
using System.Windows.Forms;
using OpenCvSharp;
namespace Binpick1
{
    public partial class 検査対象画像画面 : Form
    {
        IplImage 編集前;
        IplImage Canny実行後;
        IplImage 二値化実行後;
        public static IplImage 輪郭線差分;
        IplImage 表示中;
        private static 検査対象画像画面 _instance;

        public 検査対象画像画面()
        {
            
            InitializeComponent();
            if(編集前!=null)編集前.Dispose();
            編集前=メイン画面.検査対象画像.Clone();
            pictureBoxIpl1.Size = メイン画面.pictureBoxIplのサイズ調整(編集前);
            比較実行();
        }
        public static 検査対象画像画面 Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new 検査対象画像画面();
                return _instance;
            }
        }

        private void Canny実行()
        {
            if (Canny実行後 != null) Canny実行後.Dispose();
            IplImage sample = 編集前.Clone();
            Canny実行後 = sample.Clone();
            sample.Canny(Canny実行後, trackBar_CannyTH1.Value, trackBar_CannyTH2.Value);

            表示中 = Canny実行後.Clone();
            pictureBoxIpl1.ImageIpl = 表示中;
            sample.Dispose();
        }
        private void 二値化と膨張()
        {
            if (二値化実行後 != null) 二値化実行後.Dispose();
            IplImage sample = 編集前.Clone();
            Cv.Threshold(sample, sample, trackBar_Binary.Value, 255, ThresholdType.Binary);
            Cv.Dilate(sample,sample,null,3);
            表示中 = sample.Clone();
            二値化実行後 = sample.Clone();
            pictureBoxIpl1.ImageIpl = 表示中;
            sample.Dispose();
        }
        private void 比較実行()
        {
            Canny実行();//対象の輪郭線含む
            二値化と膨張();
            if (輪郭線差分 != null) 輪郭線差分.Dispose();

            輪郭線差分 = 二値化実行後.Clone();
            IplImage notCanny実行後 = Canny実行後.Clone();
            Cv.Not(Canny実行後, notCanny実行後);
            notCanny実行後.Add(二値化実行後, 輪郭線差分);
            輪郭線差分.Not(輪郭線差分);

            表示中 = 輪郭線差分.Clone();
            pictureBoxIpl1.ImageIpl = 表示中;
            notCanny実行後.Dispose();
        }
        private void OnClick比較開始(object sender, EventArgs e)
        {
            比較実行();
        }
        private void MouseMove_pictureBoxIpl1(object sender, MouseEventArgs e)
        {
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = this.PointToClient(sp);
            label_座標.Text = "(" + (cp.X - pictureBoxIpl1.Location.X) + "," + (cp.Y - pictureBoxIpl1.Location.Y) + ")";
        }

        private void OnClick_pictureBoxIpl1(object sender, EventArgs e)
        {
            if (pictureBoxIpl1.ImageIpl != null)
            {
                System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                System.Drawing.Point cp = this.PointToClient(sp);
                CvColor c = pictureBoxIpl1.ImageIpl[cp.Y - pictureBoxIpl1.Location.Y, cp.X - pictureBoxIpl1.Location.X];
                色.Text = "" + c.B;
                textBox_x.Text = "" + (cp.X - pictureBoxIpl1.Location.X);
                textBox_y.Text = "" + (cp.Y - pictureBoxIpl1.Location.Y);
            }
        }

        private void TextChanged_x(object sender, EventArgs e)
        {
            if (pictureBoxIpl1.ImageIpl != null)
            {
                double isnumber_x, isnumber_y;
                if (double.TryParse(textBox_x.Text, out isnumber_x) && double.TryParse(textBox_y.Text, out isnumber_y))
                    if ((isnumber_x >= 0 && isnumber_x <= pictureBoxIpl1.ImageIpl.Width) && (isnumber_y >= 0 && isnumber_y <= pictureBoxIpl1.ImageIpl.Height))
                    {
                        CvColor c = pictureBoxIpl1.ImageIpl[(int)isnumber_y, (int)isnumber_x];
                        色.Text = "" + c.B;
                        //クライアント座標を画面座標に変換する
                        System.Drawing.Point mp = this.PointToScreen(new System.Drawing.Point((int)isnumber_x + pictureBoxIpl1.Location.X, (int)isnumber_y + pictureBoxIpl1.Location.Y));
                        //マウスポインタの位置を設定する
                        System.Windows.Forms.Cursor.Position = mp;
                    }
            }
        }

        private void TextChanged_y(object sender, EventArgs e)
        {
            if (pictureBoxIpl1.ImageIpl != null)
            {
                double isnumber_x, isnumber_y;
                if (double.TryParse(textBox_x.Text, out isnumber_x) && double.TryParse(textBox_y.Text, out isnumber_y))
                    if ((isnumber_x >= 0 && isnumber_x <= pictureBoxIpl1.ImageIpl.Width) && (isnumber_y >= 0 && isnumber_y <= pictureBoxIpl1.ImageIpl.Height))
                    {
                        CvColor c = pictureBoxIpl1.ImageIpl[(int)isnumber_y, (int)isnumber_x];
                        色.Text = "" + c.B;
                        //クライアント座標を画面座標に変換する
                        System.Drawing.Point mp = this.PointToScreen(new System.Drawing.Point((int)isnumber_x + pictureBoxIpl1.Location.X, (int)isnumber_y + pictureBoxIpl1.Location.Y));
                        //マウスポインタの位置を設定する
                        System.Windows.Forms.Cursor.Position = mp;
                    }
            }
        }
        private void トラックバーの値をテキストボックスに適用()
        {
            textBox_CannyTH2.Text = trackBar_CannyTH2.Value.ToString();
            textBox_CannyTH1.Text = trackBar_CannyTH1.Value.ToString();
            textBox_Binary.Text = trackBar_Binary.Value.ToString();
        }


        private void TextChanged_CannyTH1(object sender, EventArgs e)
        {
            int isnumber;
            if (int.TryParse(textBox_CannyTH1.Text, out isnumber))
                if (isnumber >= trackBar_CannyTH1.Minimum && isnumber <= trackBar_CannyTH1.Maximum)
                    trackBar_CannyTH1.Value = isnumber;
        }

        private void TextChanged_CannyTH2(object sender, EventArgs e)
        {
            int isnumber;
            if (int.TryParse(textBox_CannyTH2.Text, out isnumber))
                if (isnumber >= trackBar_CannyTH2.Minimum && isnumber <= trackBar_CannyTH2.Maximum)
                    trackBar_CannyTH2.Value = isnumber;

        }
        private void TextChanged_Binary(object sender, EventArgs e)
        {
            int isnumber;
            if (int.TryParse(textBox_Binary.Text, out isnumber))
                if (isnumber >= trackBar_Binary.Minimum && isnumber <= trackBar_Binary.Maximum)
                    trackBar_Binary.Value = isnumber;

        }
        private void ValueChanged_TB_CannyTH1(object sender, EventArgs e)
        {
            トラックバーの値をテキストボックスに適用();
            Canny実行();
        }

        private void ValueChanged_TB_CannyTH2(object sender, EventArgs e)
        {
            トラックバーの値をテキストボックスに適用();
            Canny実行();
        }



        private void ValueChanged_Binary(object sender, EventArgs e)
        {
            トラックバーの値をテキストボックスに適用();
            二値化と膨張();
        }






    }


}
