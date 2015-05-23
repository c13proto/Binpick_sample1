using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System.Runtime.InteropServices;
using OpenCvSharp.Blob;
namespace ビンピッキング
{

    public partial class メイン画面 : Form
    {
        public static IplImage 検査対象画像;//640*480で読み込まれる
        public static IplImage 検査結果画像;
        public static IplImage 目標画像;
        public static IplImage 検査結果画像_color;//3ch

        IplImage Gauss;
        IplImage Canny;
        CvSeq<CvCircleSegment> circles;

        public メイン画面()
        {
            InitializeComponent();
        }
        private void OnClick_評価画面(object sender, EventArgs e)
        {
            if (検査対象画像 != null)
            {
                評価画面.Instance.Show();
            }
        }
        private void OnClick検査参照(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ファイル名をタイトルバーに設定
                this.Text = dialog.SafeFileName;
                //OpenCV処理
                if (検査対象画像 != null) 検査対象画像.Dispose();

                IplImage raw = new IplImage(dialog.FileName, LoadMode.GrayScale);
                検査対象画像 = Cv.CreateImage(new CvSize(640,480),BitDepth.U8,1);
                Cv.Resize(raw,検査対象画像);

                検査対象画像画面.Instance.Show();
                pictureBoxIpl1.Size = pictureBoxIplのサイズ調整(検査対象画像);
                pictureBoxIpl1.ImageIpl = 検査対象画像;
                raw.Dispose();
            }
        }
        private void Click_目標参照ボタン(object sender, EventArgs e)
        {

                OpenFileDialog dialog = new OpenFileDialog()
                {
                    Multiselect = false,  // 複数選択の可否
                    Filter =  // フィルタ
                    "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
                };
                //ダイアログを表示
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // ファイル名をタイトルバーに設定
                    this.Text = dialog.SafeFileName;
                    if (目標画像 != null) 目標画像.Dispose();

                    IplImage raw = new IplImage(dialog.FileName, LoadMode.GrayScale);
                    目標画像 = Cv.CreateImage(new CvSize(640, 480), BitDepth.U8, 1);
                    Cv.Resize(raw, 目標画像);
                    Cv.Threshold(目標画像, 目標画像,254,255,ThresholdType.Binary);

                    //評価画面.Instance.Show();
                    pictureBoxIpl1.Size = pictureBoxIplのサイズ調整(目標画像);
                    pictureBoxIpl1.ImageIpl = 目標画像;
                    raw.Dispose();
                }

        }
        private void Gauss実行()
        {
            if (検査対象画像画面.輪郭線差分 != null)
            {
                if (Gauss != null) Gauss.Dispose();
                Gauss = 検査対象画像画面.輪郭線差分.Clone();
                Cv.Smooth(Gauss, Gauss, SmoothType.Gaussian, trackBar_GaussSize.Value * 2 + 1);
                pictureBoxIpl1.ImageIpl = Gauss;
 
            }
        }
        private void Canny実行()
        {
            if (Gauss!= null)
            {
                if (Canny != null) Canny.Dispose();
                Canny=Gauss.Clone();
                Gauss.Canny(Canny, trackBar_Canny.Value, trackBar_Canny.Value/2);
                pictureBoxIpl1.ImageIpl = Canny;

            }
        }
        private void Hough変換()
        {
            if (Gauss != null)
            {
                if (circles != null) circles.Dispose();

                検査結果画像_color = Cv.CreateImage(検査対象画像.Size,検査対象画像.Depth,3);
                Cv.CvtColor(検査対象画像, 検査結果画像_color, ColorConversion.GrayToBgr);

                CvMemStorage storage = new CvMemStorage();
                circles = Cv.HoughCircles(Gauss, storage, HoughCirclesMethod.Gradient, 1.0d, (double)trackBar_minDist.Value, (double)trackBar_Canny.Value, (double)trackBar_param2.Value, trackBar_minR.Value, trackBar_maxR.Value);
                foreach (CvCircleSegment circle in circles)
                {
                    検査結果画像_color.Circle(circle.Center, (int)circle.Radius, CvColor.Red,2,LineType.AntiAlias);
                }
                pictureBoxIpl1.ImageIpl = 検査結果画像_color;
                storage.Dispose();
            }
        }
        public static System.Drawing.Size pictureBoxIplのサイズ調整(IplImage sample)
        {
            return new System.Drawing.Size(sample.Width, sample.Height);
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

        public static void GetEnclosingCircle(IEnumerable<CvPoint> points, out CvPoint2D32f center, out float radius)
        {
            var pointsArray = points.ToArray();
            using (var pointsMat = new CvMat(pointsArray.Length, 1, MatrixType.S32C2, pointsArray))
            {
                Cv.MinEnclosingCircle(pointsMat, out center, out radius);
            }
        }
        private void トラックバーの値をテキストボックスに適用()
        {
            textBox_GaussSize.Text = trackBar_GaussSize.Value.ToString();
            textBox_Canny.Text = trackBar_Canny.Value.ToString();
            textBox_minDist.Text = trackBar_minDist.Value.ToString();
            textBox_param2.Text = trackBar_param2.Value.ToString();
            textBox_minR.Text = trackBar_minR.Value.ToString();
            textBox_maxR.Text = trackBar_maxR.Value.ToString();
        }
        private void ValueChanged_TB_GaussNum(object sender, EventArgs e)
        {
            トラックバーの値をテキストボックスに適用();
            Gauss実行();
        }

        private void ValueChanged_TB_Canny(object sender, EventArgs e)
        {
            トラックバーの値をテキストボックスに適用();
            Canny実行();
        }

        private void TextChanged_GaussNum(object sender, EventArgs e)
        {
            int isnumber;
            if (int.TryParse(textBox_GaussSize.Text, out isnumber))
                if (isnumber >= trackBar_GaussSize.Minimum && isnumber <= trackBar_GaussSize.Maximum)
                    trackBar_GaussSize.Value = isnumber;
        }

        private void TextChanged_Canny(object sender, EventArgs e)
        {
            int isnumber;
            if (int.TryParse(textBox_Canny.Text, out isnumber))
                if (isnumber >= trackBar_Canny.Minimum && isnumber <= trackBar_Canny.Maximum)
                    trackBar_Canny.Value = isnumber;
        }

        private void ValueChanged_minDist(object sender, EventArgs e)
        {
            トラックバーの値をテキストボックスに適用();
            Hough変換();
        }

        private void ValueChanged_param2(object sender, EventArgs e)
        {
            トラックバーの値をテキストボックスに適用();
            Hough変換();
        }

        private void ValueChanged_minR(object sender, EventArgs e)
        {
            トラックバーの値をテキストボックスに適用();
            Hough変換();
        }

        private void ValueChanged_maxR(object sender, EventArgs e)
        {
            トラックバーの値をテキストボックスに適用();
            Hough変換();
        }

        private void TextChanged_minDist(object sender, EventArgs e)
        {
            int isnumber;
            if (int.TryParse(textBox_minDist.Text, out isnumber))
                if (isnumber >= trackBar_minDist.Minimum && isnumber <= trackBar_minDist.Maximum)
                    trackBar_minDist.Value = isnumber;
        }

        private void TextChanged_param2(object sender, EventArgs e)
        {
            int isnumber;
            if (int.TryParse(textBox_param2.Text, out isnumber))
                if (isnumber >= trackBar_param2.Minimum && isnumber <= trackBar_param2.Maximum)
                    trackBar_param2.Value = isnumber;
        }

        private void TextChanged_minR(object sender, EventArgs e)
        {
            int isnumber;
            if (int.TryParse(textBox_minR.Text, out isnumber))
                if (isnumber >= trackBar_minR.Minimum && isnumber <= trackBar_minR.Maximum)
                    trackBar_minR.Value = isnumber;
        }

        private void TextChanged_maxR(object sender, EventArgs e)
        {
            int isnumber;
            if (int.TryParse(textBox_maxR.Text, out isnumber))
                if (isnumber >= trackBar_maxR.Minimum && isnumber <= trackBar_maxR.Maximum)
                    trackBar_maxR.Value = isnumber;
        }

        private void Click_円検出開始ボタン(object sender, EventArgs e)
        {
            Hough変換();
        }


    }
}
