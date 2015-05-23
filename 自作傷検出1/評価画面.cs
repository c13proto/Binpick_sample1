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
using System.IO;
using System.Threading;

namespace ビンピッキング
{
    public partial class 評価画面 : Form
    {
        private static 評価画面 _instance;
        IplImage 目標画像;
        IplImage 編集前の検査対象画像;
        IplImage 編集後の検査対象画像;
        IplImage 比較結果画像;
        IplImage 最終工程終了画像;//カラー
        
        bool perfect = false;
        int 表計算timer = 0;

        public 評価画面()
        {

            InitializeComponent();
            
            if (目標画像 != null) 目標画像.Dispose();
            目標画像 = メイン画面.目標画像.Clone();
            if (編集前の検査対象画像 != null) 編集前の検査対象画像.Dispose();
            編集前の検査対象画像 = メイン画面.検査対象画像.Clone();

            pictureBoxIpl1.Size = メイン画面.pictureBoxIplのサイズ調整(目標画像);
            pictureBoxIpl1.ImageIpl = 編集前の検査対象画像;
        }
        public static 評価画面 Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new 評価画面();
                return _instance;
            }
        }


        private void Hough変換で円を検出(int canny1,int canny2,int gauss_size,int param1,int param2)
        {
            IplImage raw = 編集前の検査対象画像.Clone();
            IplImage color = Cv.CreateImage(編集前の検査対象画像.Size, 編集前の検査対象画像.Depth, 3);

            raw.Canny(raw,canny1,canny2);
            Cv.Smooth(raw, raw, SmoothType.Gaussian, gauss_size * 2 + 1);

            CvMemStorage storage = new CvMemStorage();
            CvSeq<CvCircleSegment> circles = Cv.HoughCircles(raw, storage, HoughCirclesMethod.Gradient, 1.0d, 5.0d, param1, param2, 5, 25);

            if (編集後の検査対象画像 != null) 編集後の検査対象画像.Dispose();
            編集後の検査対象画像 = 編集前の検査対象画像.Clone();
            編集後の検査対象画像.Zero();
            color.Zero();
            foreach (CvCircleSegment circle in circles)
            {
                color.Circle(circle.Center, (int)circle.Radius, CvColor.White, -1, LineType.AntiAlias);
            }
            Cv.CvtColor(color, 編集後の検査対象画像, ColorConversion.BgrToGray);

            color.Dispose();
            raw.Dispose();
            storage.Dispose();
            circles.Dispose();
        }
        private int 点数計算()
        {
            if (比較結果画像 != null) 比較結果画像.Dispose();
            比較結果画像 = 目標画像.Clone();
            比較結果画像.Zero();
            Cv.AbsDiff(目標画像, 編集後の検査対象画像,比較結果画像);

            return 比較結果画像.CountNonZero();

        }
        private void OnClick開始ボタン(object sender, EventArgs e)
        {
            Console.WriteLine("評価開始");
            if (checkBox_list.Checked) リストの作成();
            else if(checkBox_PfGA.Checked)PfGA処理();
            else 遺伝的アルゴリズム処理();
        }

        private int 評価結果(int p1,int p2,int p3,int p4,int p5)
        {
            int 点数 = 0;
            
            timer1.Enabled = true;
            timer1.Start(); 
            表計算timer = 0;

            Hough変換で円を検出(p1, p2, p3, p4, p5);
            点数=-点数計算();
            
            表計算timer = 0;
            timer1.Stop();
            timer1.Enabled = false; 

            return 点数;
        }
        private void 遺伝子情報を画面に出力(int p1, int p2, int p3, int p4, int p5, int 点数)
        {
            
            Console.WriteLine("画像出力");

            CvMemStorage storage = new CvMemStorage();
            IplImage raw = 編集前の検査対象画像.Clone();
            

            raw.Canny(raw, p1, p2);
            Cv.Smooth(raw, raw, SmoothType.Gaussian, p3 * 2 + 1);
            CvSeq<CvCircleSegment> circles = Cv.HoughCircles(raw, storage, HoughCirclesMethod.Gradient, 1.0d, 5.0d, p4,p5, 5, 25);
            
            IplImage color = new IplImage(編集前の検査対象画像.Size, 編集前の検査対象画像.Depth, 3);
            Cv.CvtColor(編集前の検査対象画像,color,ColorConversion.GrayToBgr);
            CvFont フォント = new CvFont(FontFace.HersheyComplex, 0.5, 0.5);
            Cv.PutText(color, "p1 = " + p1, new CvPoint(10, 20), フォント, new CvColor(0, 0, 255));
            Cv.PutText(color, "p2 = " + p2, new CvPoint(10, 40), フォント, new CvColor(0, 0, 255));
            Cv.PutText(color, "p3 = " + p3, new CvPoint(10, 60), フォント, new CvColor(0, 0, 255));
            Cv.PutText(color, "p4 = " + p4, new CvPoint(10, 80), フォント, new CvColor(0, 0, 255));
            Cv.PutText(color, "p5 = " + p5, new CvPoint(10, 100), フォント, new CvColor(0, 0, 255));
            Cv.PutText(color, "score= " + 点数, new CvPoint(10, 120), フォント, new CvColor(0, 0, 255));
            foreach (CvCircleSegment circle in circles)
            {
                color.Circle(circle.Center, (int)circle.Radius, CvColor.Red, 2);
            }
            pictureBoxIpl1.ImageIpl = color;
            if (最終工程終了画像 != null) 最終工程終了画像.Dispose();
            最終工程終了画像 = color.Clone();

            フォント.Dispose();
            color.Dispose();
            
        }
        private void 遺伝的アルゴリズム処理()
        {
            int 実験体数 = 500;
            int 受け継がれる個体数 = 100;
            int 突然変異確率=5;//3%
            int 突然変異の範囲 = 2;//突然変異によって影響するパラメータの個数(1以上)
            int 最終世代=10;
            int 今の世代=1;
            progressBar1.Maximum = 最終世代;
            int[,] パラメータ ={ //[i,0]=i番目のパラメータの最小値,[i,1]=最大値
                {int.Parse(textBox_1s.Text),int.Parse(textBox_1e.Text)}, 
                {int.Parse(textBox_1s.Text),int.Parse(textBox_1e.Text)},
                {int.Parse(textBox_2s.Text),int.Parse(textBox_2e.Text)},
                {int.Parse(textBox_3s.Text),int.Parse(textBox_3e.Text)},
                {int.Parse(textBox_4s.Text),int.Parse(textBox_4e.Text)}, 
            };          

            //第一世代の遺伝子をランダムに作成し、それをいくつか個作る
            //そのあと遺伝子の評価が行われ、点数化される
            int[,] 第一世代の遺伝子 = ランダムで遺伝子生成(実験体数, パラメータ);

            //点数順に遺伝子個体をソートする．ソート方法は工夫できていない
            int[,] 第一世代のソートされた遺伝子 = 遺伝子を成績順にソート(第一世代の遺伝子, 実験体数, パラメータ.Length / 2);

            int[,] gene = 第一世代のソートされた遺伝子;

            for (今の世代 = 1; 今の世代 <= 最終世代;今の世代++ )
            {
                //上位数体の優秀な個体を記録して、これを親にして子孫を作成する
                //次の世代の遺伝子をランダムに作成し、そのうちのある範囲を親から受け継ぐようにする
                //ある確率で突然変異が起こる．これを繰り返す
                gene = 成績順から次の遺伝子を作成(gene, 実験体数, パラメータ, 受け継がれる個体数, 突然変異確率, 突然変異の範囲);
                gene = 遺伝子を成績順にソート(gene, 実験体数, パラメータ.Length / 2);

                Console.WriteLine(今の世代);
                progressBar1.Value = 今の世代;

                if (今の世代 % 2 == 0 || 今の世代 == 1)//途中と最終結果を出力 
                    遺伝子情報をCSV出力(gene, 実験体数, パラメータ.Length / 2,
                      DateTime.Now.ToString("yy-MM-dd_") + 突然変異確率 + "-" + 突然変異の範囲 + "-" + 今の世代);
            }
            遺伝子情報を画面に出力(gene[0, 0], gene[0, 1], gene[0, 2], gene[0, 3], gene[0, 4], gene[0, 5]);


        }
        private int[,] ランダムで遺伝子生成(int 遺伝子の個数, int[,] パラメータ)
        {

            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // 厳密にランダムなInt32を作る
            var buffer = new byte[sizeof(int)];
            rng.GetBytes(buffer);
            var seed = BitConverter.ToInt32(buffer, 0);
            // そのseedを基にRandomを作る
            var r = new Random(seed++);

            int[,] gene = new int[遺伝子の個数, パラメータ.Length/2+1];

            for (int i = 0; i < 遺伝子の個数; i++)//遺伝子作成
                for (int j = 0; j < パラメータ.Length / 2; j++)
                    gene[i, j] = r.Next(パラメータ[j, 0], パラメータ[j, 1] + 1);

            for (int i = 0; i < 遺伝子の個数; i++)//パラメータの後(パラメータ数+1番目)に成績を代入
            {
                gene[i, パラメータ.Length / 2] = 評価結果(gene[i, 0], gene[i, 1], gene[i, 2], gene[i, 3], gene[i, 4]);
            }
            return gene;
        }
        private int[,] 遺伝子を成績順にソート(int[,] 遺伝子, int 遺伝子の個数, int パラメータ数)
        {
            //Console.WriteLine("遺伝子ソート中");
            bool NotSort = true;
            while (NotSort)
            {
                for (int i = 0; i < 遺伝子の個数 - 1; i++)//ソート完了まで継続
                {
                    NotSort = false;
                    if (遺伝子[i, パラメータ数] < 遺伝子[i + 1, パラメータ数])//[i,パラメータ数]に評価が入っている
                    {
                        //次の遺伝子のほうが成績が良かったら
                        NotSort = true;
                        int[] 遺伝子temp = new int[パラメータ数+1];//一時的にi番目の遺伝子を保存
                        for (int j = 0; j < パラメータ数 + 1; j++) 遺伝子temp[j] = 遺伝子[i, j];
                        //i番目の遺伝子とi+1番目の遺伝子を交換
                        for (int j = 0; j < パラメータ数 + 1; j++)
                        {
                            遺伝子[i, j] = 遺伝子[i + 1, j];
                            遺伝子[i + 1, j] = 遺伝子temp[j];
                        }
                        break;
                    }
                }
            }


            return p1をp2より大きくする(遺伝子,遺伝子の個数);
        }
        private int[,] 成績順から次の遺伝子を作成(int[,] 成績順の遺伝子, int 遺伝子作成数,int[,] パラメータ,int 上位数,int 突然変異率,int 影響範囲)//突然変異率は%
        {
            //Console.WriteLine("遺伝子作成中");
            int[,] 新しい遺伝子 = new int[遺伝子作成数, パラメータ.Length/2 + 1];
            
            //上位遺伝子の選定
            int[,] 上位遺伝子 = new int[上位数, パラメータ.Length / 2 + 1];//
            for (int i = 0; i < 上位数; i++)
                for (int j = 0; j < パラメータ.Length / 2 + 1; j++)
                    上位遺伝子[i, j] = 成績順の遺伝子[i, j];

            //突然変異の個体数を決定
            int 交叉数 = 遺伝子作成数 - 突然変異回数(遺伝子作成数,突然変異率);
            
            //交叉遺伝子と突然変異遺伝子を作成
            int[,] 交叉遺伝子 = 交叉遺伝子作成(交叉数, 上位遺伝子, 上位数, パラメータ.Length / 2);
            int[,] 突然変異遺伝子 = 突然変異遺伝子作成(遺伝子作成数 - 交叉数, 上位遺伝子, 上位数, パラメータ, 影響範囲);

            //交叉遺伝子と突然変異遺伝子をマージ
            for (int i = 0; i < 交叉数; i++)
                for (int j = 0; j < パラメータ.Length / 2 + 1; j++)
                    新しい遺伝子[i, j] = 交叉遺伝子[i, j];
            for (int i = 交叉数; i < 遺伝子作成数;i++ )
                for (int j = 0; j < パラメータ.Length / 2 + 1; j++)
                    新しい遺伝子[i, j] = 突然変異遺伝子[i-交叉数, j];
            
            return 新しい遺伝子;
        }
        private int 突然変異回数(int 全体数, int 突然変異率)
        {
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // 厳密にランダムなInt32を作る
            var buffer = new byte[sizeof(int)];
            rng.GetBytes(buffer);
            var seed = BitConverter.ToInt32(buffer, 0);
            // そのseedを基にRandomを作る
            var r = new Random(seed++);

            int count = 0;
            for (int i = 0; i < 全体数; i++) if (r.Next(全体数) < 全体数 * 突然変異率 / 100) count++;
            return count;
        }
        private int[,] 交叉遺伝子作成(int 作成数, int[,]上位の遺伝子,int 上位数,int パラメータ数)
        {
            int[,] 交叉遺伝子 = new int[作成数, パラメータ数 + 1];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // 厳密にランダムなInt32を作る
            var buffer = new byte[sizeof(int)];
            rng.GetBytes(buffer);
            var seed = BitConverter.ToInt32(buffer, 0);
            // そのseedを基にRandomを作る
            var r = new Random(seed++);

            //上位の遺伝子からパラメータを選ぶ
            for (int i = 0; i < 作成数; i++)
                for (int j = 0; j < パラメータ数; j++)
                {
                    /*
                    //p2とp3はペアで考えてやる必要あり
                    int rand=r.Next(上位数);
                    if (j == 2) 
                    {
                        交叉遺伝子[i, 1] = 上位の遺伝子[rand, 1];
                        交叉遺伝子[i, 2] = 上位の遺伝子[rand, 2];
                    }
                    else 交叉遺伝子[i, j] = 上位の遺伝子[rand, j];
                    */
                    交叉遺伝子[i, j] = 上位の遺伝子[r.Next(上位数), j];
                }
            for (int i = 0; i < 作成数; i++)//成績を代入
                交叉遺伝子[i, パラメータ数] = 評価結果(交叉遺伝子[i, 0], 交叉遺伝子[i, 1], 交叉遺伝子[i, 2], 交叉遺伝子[i, 3], 交叉遺伝子[i, 4]);

           return 交叉遺伝子;
        }
        private int[,] 突然変異遺伝子作成(int 作成数, int[,] 上位の遺伝子, int 上位数, int[,] パラメータ,int 影響範囲)
        {
            int[,] 突然変異 = new int[作成数, パラメータ.Length / 2 + 1];//+1は得点格納用
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // 厳密にランダムなInt32を作る
            var buffer = new byte[sizeof(int)];
            rng.GetBytes(buffer);
            var seed = BitConverter.ToInt32(buffer, 0);
            // そのseedを基にRandomを作る
            var r = new Random(seed++);

            //重複しないように変更するパラメータを選ぶ
            HashSet<int> 変更するパラメータ = new HashSet<int>();

            //上位の遺伝子かパラメータの範囲からパラメータを選ぶ
            for (int i = 0; i < 作成数; i++)
            {
                while (変更するパラメータ.Count < 影響範囲) 変更するパラメータ.Add(r.Next(パラメータ.Length / 2));//変更するパラメータを選択
                for (int j = 0; j < パラメータ.Length / 2; j++)
                {
                    if (変更するパラメータ.Contains(j)) 突然変異[i, j] = r.Next(パラメータ[j, 0], パラメータ[j, 1] + 1);
                    else 突然変異[i, j] = 上位の遺伝子[r.Next(上位数), j];
                }
                変更するパラメータ.Clear();
            }

            return 突然変異;
        }

        private int[,] p1をp2より大きくする(int[,] gene,int 遺伝子の個数)
        {
            for (int i = 0; i < 遺伝子の個数; i++)
            {
                if (gene[i, 0] < gene[i, 1])
                {
                    int temp = gene[i, 0];
                    gene[i, 0] = gene[i, 1];
                    gene[i, 1] = temp;
                }
            }

            return gene;
        }

        private void 遺伝子情報をCSV出力(int[,] 遺伝子,int 実験体数,int パラメータ数,String ファイル名)
        {
            System.IO.Directory.CreateDirectory(@"result");
            String 結果 = "";
            for (int i = 0; i < 実験体数; i++)
                for (int j = 0; j < パラメータ数 + 1; j++)
                {
                    結果 += 遺伝子[i, j] + ",";
                    if (j == パラメータ数) 結果 += "\n";
                }
            using (StreamWriter w = new StreamWriter(@"result\"+ファイル名+".csv"))
            {
                w.Write(結果);
            }
        }
        private void PfGA処理() 
        {
            int 最終世代 = int.Parse(textBox_PfGA.Text)/4;
            int 今の世代 = 0;
            progressBar1.Maximum = 最終世代;

            int[,] パラメータ ={ //[i,0]=i番目のパラメータの最小値,[i,1]=最大値
                {int.Parse(textBox_1s.Text),int.Parse(textBox_1e.Text)}, 
                {int.Parse(textBox_2s.Text),int.Parse(textBox_2e.Text)},
                {int.Parse(textBox_3s.Text),int.Parse(textBox_3e.Text)},
                {int.Parse(textBox_4s.Text),int.Parse(textBox_4e.Text)},
                {int.Parse(textBox_5s.Text),int.Parse(textBox_5e.Text)}, 
            };

            //親は[0~1,],子は[2~3,]に戻す
            int[,] 局所集団 = new int[4, パラメータ.Length / 2 + 1];

            int[] 初期親1=ランダムに遺伝子1つ作成(パラメータ);
            int[] 初期親2 = ランダムに遺伝子1つ作成(パラメータ);
            int[] 初期子1 = 親からランダムな交叉(初期親1,初期親2,パラメータ.Length/2);
            int[] 初期子2 = 親からランダムな交叉(初期親1, 初期親2, パラメータ.Length / 2);
            初期子2 = ランダムな突然変異(初期子2, パラメータ);

            for (int i = 0; i < パラメータ.Length / 2; i++)
            {
                局所集団[0, i] = 初期親1[i];
                局所集団[1, i] = 初期親2[i];
                局所集団[2, i] = 初期子1[i];
                局所集団[3, i] = 初期子2[i];
            }
            p1をp2より大きくする(局所集団, 4);

            while (今の世代 <= 最終世代)
            {
                局所集団 = 次の局所集団を作成(局所集団, パラメータ);
                for (int i = 0; i < 4; i++)
                {
                    局所集団[i, パラメータ.Length / 2] = 評価結果(局所集団[i, 0], 局所集団[i, 1], 局所集団[i, 2], 局所集団[i, 3], 局所集団[i, 4]);

                }
                Console.WriteLine(今の世代);
                progressBar1.Value = 今の世代;

                if (今の世代 % 100 == 0 || 今の世代 == 1 || perfect)//途中と最終結果を出力 
                {
                    遺伝子情報をCSV出力(局所集団, 4, パラメータ.Length / 2,
                       DateTime.Now.ToString("yy-MM-dd_") + "Pf_" + 今の世代 );
                }
                if (perfect) break;
                今の世代++;
            }

            局所集団 = 遺伝子を成績順にソート(局所集団, 4, パラメータ.Length / 2);
            遺伝子情報を画面に出力(局所集団[0, 0], 局所集団[0, 1], 局所集団[0, 2], 局所集団[0, 3], 局所集団[0, 4], 局所集団[0, 5]);
            Console.WriteLine("PfGA終了");
            progressBar1.Value = 最終世代;

        }
        private int[] ランダムに遺伝子1つ作成(int[,] パラメータ)
        {

            System.Security.Cryptography.RNGCryptoServiceProvider rng =new System.Security.Cryptography.RNGCryptoServiceProvider();
            // 厳密にランダムなInt32を作る
            var buffer = new byte[sizeof(int)];
            rng.GetBytes(buffer);
            var seed = BitConverter.ToInt32(buffer, 0);
            // そのseedを基にRandomを作る
            var r = new Random(seed++);
           
            int[] gene =new int[パラメータ.Length/2+1];

            for (int i = 0; i < パラメータ.Length / 2; i++)
            {
                gene[i] = r.Next(パラメータ[i, 0], パラメータ[i, 1] + 1);
            }
            //Console.WriteLine("" + gene[0] + "," + gene[1] + "," + gene[2] + "," + gene[3] + "," + gene[4] + "\n");
            return gene;

        }
        private int[] 親からランダムな交叉(int[] geneA, int[] geneB, int パラメータ数)
        {
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // 厳密にランダムなInt32を作る
            var buffer = new byte[sizeof(int)];
            rng.GetBytes(buffer);
            var seed = BitConverter.ToInt32(buffer, 0);
            // そのseedを基にRandomを作る
            var r = new Random(seed++);

            int[] gene=new int[パラメータ数+1];

            for (int i = 0; i < パラメータ数; i++)
            {
                if (r.Next(2) == 1) gene[i] = geneA[i];
                else gene[i] = geneB[i];
            }

            return gene;
        }

        private int[] ランダムな突然変異(int[] original, int[,] パラメータ)
        {
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // 厳密にランダムなInt32を作る
            var buffer = new byte[sizeof(int)];
            rng.GetBytes(buffer);
            var seed = BitConverter.ToInt32(buffer, 0);
            // そのseedを基にRandomを作る
            var r = new Random(seed++);

            int 個数 = r.Next(パラメータ.Length/2 + 1);
            int[] gene = new int[パラメータ.Length / 2 + 1];

            //重複しないように変更するパラメータを選ぶ
            HashSet<int> 変更するパラメータ = new HashSet<int>();
            while (変更するパラメータ.Count < 個数) 変更するパラメータ.Add(r.Next(パラメータ.Length / 2));
            for (int j = 0; j < パラメータ.Length / 2; j++)
            {
                if (変更するパラメータ.Contains(j)) gene[j] = r.Next(パラメータ[j, 0], パラメータ[j, 1] + 1);
                else gene[j] = original[j];

            }
            変更するパラメータ.Clear();
                
            return gene;
        }
        private int[,] 次の局所集団を作成(int[,] group,int[,] パラメータ)
        {
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // 厳密にランダムなInt32を作る
            var buffer = new byte[sizeof(int)];
            rng.GetBytes(buffer);
            var seed = BitConverter.ToInt32(buffer, 0);
            // そのseedを基にRandomを作る
            var r = new Random(seed++);

            int[] 親の大きい方 = new int[パラメータ.Length/2 + 1];
            int[] 親の小さい方 = new int[パラメータ.Length / 2 + 1];
            int[] 子の大きい方 = new int[パラメータ.Length / 2 + 1];
            int[] 子の小さい方 = new int[パラメータ.Length / 2 + 1];
            int[] 新子供1 = new int[パラメータ.Length / 2 + 1];
            int[] 新子供2 = new int[パラメータ.Length / 2 + 1];
            int[,] next_group = new int[4, パラメータ.Length / 2 + 1];

            //パラメータから点数を評価
            for (int i = 0; i < 4; i++)
            {
                group[i, パラメータ.Length / 2] = 評価結果(group[i, 0], group[i, 1], group[i, 2], group[i, 3], group[i, 4]);
                //Console.WriteLine("" + group[i, 0] + "," + group[i, 1] + "," + group[i, 2] + "," + group[i, 3] + "," + group[i, 4] + "," + group[i, 5] + "\n");
            }
            if (group[0, パラメータ.Length / 2] > group[1, パラメータ.Length / 2])
                for (int i = 0; i < パラメータ.Length / 2; i++)
                {
                    親の大きい方 [i]=group[0,i];
                    親の小さい方 [i]=group[1,i];
                }
            else
                for (int i = 0; i < パラメータ.Length / 2; i++)
                {
                    親の大きい方[i] = group[1, i];
                    親の小さい方 [i]=group[0,i];
                }
            if (group[2, パラメータ.Length / 2] > group[3, パラメータ.Length / 2])
                for (int i = 0; i < パラメータ.Length / 2; i++)
                {
                    子の大きい方[i] = group[2, i];
                    子の小さい方[i] = group[3, i];
                }
            else
                for (int i = 0; i < パラメータ.Length / 2; i++)
                {
                    子の大きい方[i] = group[3, i];
                    子の小さい方[i] = group[2, i];
                }

            //子2個体がともに親の2個体より良かった場合（ケースA）は、子2個体及び適応度の良かった方の親個体計3個体が局所集団に戻し，そのうち二体を親として選ぶ。
            if ((group[2, パラメータ.Length / 2] >= 親の大きい方[パラメータ.Length / 2]) && (group[3, パラメータ.Length / 2] >= 親の大きい方[パラメータ.Length / 2]))
            {
                int number = r.Next(3);


                //局所集団から2個体（親）をランダムに取り出し、ランダムな多点交叉を行なう
                if (number == 2)
                {
                    新子供1 = 親からランダムな交叉(子の大きい方, 子の小さい方, パラメータ.Length / 2);
                    新子供2 = 親からランダムな交叉(子の大きい方, 子の小さい方, パラメータ.Length / 2);
                    for (int i = 0; i < パラメータ.Length / 2; i++)
                    {
                        next_group[0, i] = 子の大きい方[i];
                        next_group[1, i] = 子の小さい方[i];
                        next_group[2, i] = 新子供1[i];
                    }
                }
                if (number == 1)
                {
                    新子供1 = 親からランダムな交叉(子の大きい方, 親の大きい方, パラメータ.Length / 2);
                    新子供2 = 親からランダムな交叉(子の大きい方, 親の大きい方, パラメータ.Length / 2);
                    for (int i = 0; i < パラメータ.Length / 2; i++)
                    {
                        next_group[0, i] = 子の大きい方[i];
                        next_group[1, i] = 親の大きい方[i];
                        next_group[2, i] = 新子供1[i];
                    }
                }
                else
                {
                    新子供1 = 親からランダムな交叉(子の小さい方, 親の大きい方, パラメータ.Length / 2);
                    新子供2 = 親からランダムな交叉(子の小さい方, 親の大きい方, パラメータ.Length / 2);
                    for (int i = 0; i < パラメータ.Length / 2; i++)
                    {
                        next_group[0, i] = 子の小さい方[i];
                        next_group[1, i] = 親の大きい方[i];
                        next_group[2, i] = 新子供1[i];
                    }

                }
                //交叉によって生成された2個体（子）のうち1個体をランダムに選択し、ランダムな数と位置において突然変異を行なう。
                新子供2 = ランダムな突然変異(新子供2, パラメータ);
                for (int i = 0; i < パラメータ.Length / 2; i++)
                    next_group[3, i] = 新子供2[i];

            }
            //子2個体がともに親の2個体より悪かった場合（ケースB）は、親2個体のうち良かった方のみが局所集団に戻り、局所集団数は1減少する。
            else if (子の大きい方[パラメータ.Length / 2] <= 親の小さい方[パラメータ.Length / 2])
            {
                //全探索空間から1個体をランダムに取り出し、これを局所集団に追加する。
                int[] 新親 = ランダムに遺伝子1つ作成(パラメータ);

                新子供1 = 親からランダムな交叉(親の大きい方, 新親, パラメータ.Length / 2);
                新子供2 = 親からランダムな交叉(親の大きい方, 新親, パラメータ.Length / 2);
                新子供2 = ランダムな突然変異(新子供2, パラメータ);
                for (int i = 0; i < パラメータ.Length / 2; i++)
                {
                    next_group[0, i] = 親の大きい方[i];
                    next_group[1, i] = 新親[i];
                    next_group[2, i] = 新子供1[i];
                    next_group[3, i] = 新子供2[i];
                }
            }
            //親2個体のうちどちらか一方のみが子2個体より良かった場合（ケースC）は、親2個体のうち良かった方と子2個体のうち良かった方が局所集団に戻り、局所集団数は変化しない。
            else if ((親の大きい方[パラメータ.Length / 2] >= 子の大きい方[パラメータ.Length / 2])
                && (親の小さい方[パラメータ.Length / 2] <= 子の大きい方[パラメータ.Length / 2]))
            {
                新子供1 = 親からランダムな交叉(親の大きい方, 子の大きい方, パラメータ.Length / 2);
                新子供2 = 親からランダムな交叉(親の大きい方, 子の大きい方, パラメータ.Length / 2);
                新子供2 = ランダムな突然変異(新子供2, パラメータ);
                for (int i = 0; i < パラメータ.Length / 2; i++)
                {
                    next_group[0, i] = 親の大きい方[i];
                    next_group[1, i] = 子の大きい方[i];
                    next_group[2, i] = 新子供1[i];
                    next_group[3, i] = 新子供2[i];
                }
            }
            //子2個体のうちどちらか一方のみが親2個体より良かった場合（ケースD）は、子2個体のうち良かった方のみが局所集団に戻り、全探索空間からランダムに1個体選んで局所集団に追加
            else if ((子の大きい方[パラメータ.Length / 2] >= 親の大きい方[パラメータ.Length / 2])
                && (子の小さい方[パラメータ.Length / 2] <= 親の大きい方[パラメータ.Length / 2]))
            {
                //全探索空間から1個体をランダムに取り出し、これを局所集団に追加する。
                int[] 新親 = ランダムに遺伝子1つ作成(パラメータ);

                新子供1 = 親からランダムな交叉(子の大きい方, 新親, パラメータ.Length / 2);
                新子供2 = 親からランダムな交叉(子の大きい方, 新親, パラメータ.Length / 2);
                新子供2 = ランダムな突然変異(新子供2, パラメータ);
                for (int i = 0; i < パラメータ.Length / 2; i++)
                {
                    next_group[0, i] = 親の大きい方[i];
                    next_group[1, i] = 子の大きい方[i];
                    next_group[2, i] = 新子供1[i];
                    next_group[3, i] = 新子供2[i];
                }
            }
            else Console.WriteLine("newPattern?");

            return p1をp2より大きくする(next_group, 4);
        }
        private void リストの作成()
        {
            int 累計達成者 = 0;
            int 総世代数 = 0;
            int 目標累計 = int.Parse(textBox_list_num.Text);
            string[] 目標スコア = textBox_list_score.Text.Split(',');

            progressBar1.Maximum = 目標累計;
            int[,] パラメータ ={ //[i,0]=i番目のパラメータの最小値,[i,1]=最大値
                {int.Parse(textBox_1s.Text),int.Parse(textBox_1e.Text)}, 
                {int.Parse(textBox_1s.Text),int.Parse(textBox_1e.Text)},
                {int.Parse(textBox_2s.Text),int.Parse(textBox_2e.Text)},
                {int.Parse(textBox_3s.Text),int.Parse(textBox_3e.Text)},
                {int.Parse(textBox_4s.Text),int.Parse(textBox_4e.Text)}, 
            };
            //親は[0~1,],子は[2~3,]に戻す
            int[,] 局所集団 = new int[4, パラメータ.Length / 2 + 1];
            int[,] リスト = new int[目標累計, パラメータ.Length / 2 + 1];


            while (累計達成者 < 目標累計)
            {
                progressBar1.Value = 累計達成者;
                bool ノルマ達成 = false;
                局所集団 = 局所集団の初期化(パラメータ);

                while (!ノルマ達成)
                {
                    局所集団 = 次の局所集団を作成(局所集団, パラメータ);
                    for (int i = 0; i < 4; i++) 局所集団[i, パラメータ.Length / 2] = 評価結果(局所集団[i, 0], 局所集団[i, 1], 局所集団[i, 2], 局所集団[i, 3], 局所集団[i, 4]);
                    for (int i = 0; i < 4; i++)
                    {
                        if (局所集団[i, パラメータ.Length / 2] >= int.Parse(目標スコア[0]) && 局所集団[i, パラメータ.Length / 2] <= int.Parse(目標スコア[1]))
                        {
                            for (int j = 0; j < パラメータ.Length / 2 + 1; j++) リスト[累計達成者, j] = 局所集団[i, j];
                            ノルマ達成 = true;
                        }
                    }
                    Console.WriteLine("総世代数:" + 総世代数 + ",累計達成者:" + 累計達成者);
                    総世代数++;
                }
                累計達成者++;
                遺伝子情報をCSV出力(リスト, 目標累計, パラメータ.Length / 2, DateTime.Now.ToString("yy-MM-dd_") + "List" + "_" + 目標スコア[0] + "_" + 目標スコア[1]);
                //Console.WriteLine("総世代数:" + 総世代数+",累計満点者:"+累計満点者);
            }
            Console.WriteLine("総世代数:" + 総世代数 + ",累計達成者:" + 累計達成者);
            Console.WriteLine("リスト出力完了");
            progressBar1.Value = 目標累計;
        }
        private int[,] 局所集団の初期化(int[,] パラメータ)
        {
            var group = new int[4, パラメータ.Length / 2 + 1];

            int[] 初期親1 = ランダムに遺伝子1つ作成(パラメータ);
            int[] 初期親2 = ランダムに遺伝子1つ作成(パラメータ);
            int[] 初期子1 = 親からランダムな交叉(初期親1, 初期親2, パラメータ.Length / 2);
            int[] 初期子2 = 親からランダムな交叉(初期親1, 初期親2, パラメータ.Length / 2);
            初期子2 = ランダムな突然変異(初期子2, パラメータ);

            for (int i = 0; i < パラメータ.Length / 2; i++)
            {
                group[0, i] = 初期親1[i];
                group[1, i] = 初期親2[i];
                group[2, i] = 初期子1[i];
                group[3, i] = 初期子2[i];
            }

            return group;
        }

        private void タイマ割り込み(object sender, EventArgs e)
        {
            表計算timer++;
            if (表計算timer >= 10) Console.WriteLine("計算時間[]:" + (float)表計算timer / 10.0f);
        }
    }
}
