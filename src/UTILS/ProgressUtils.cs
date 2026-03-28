using System;
using System.Windows.Forms;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// 進捗表示クラス
    /// </summary>
    internal class ProgressUtils
    {
        //ProgressBar関連
        public static ToolStripProgressBar pb;
        public static Progress<int> progress; //サブスレッド用Progress<T>オブジェクト

        //Timer関連
        public const string defaultDisp = "経過時間　00:00:00";
        public static Timer timer;
        public static ToolStripLabel lbl;
        private static DateTime startTime;
        private static TimeSpan ts;

        /// <summary>
        /// 進捗表示のためのコントロールを設定
        /// </summary>
        public static void SetProgressControl(Timer t, ToolStripLabel l, ToolStripProgressBar p)
        {
            timer = t;
            lbl = l;
            pb = p;

            progress = new Progress<int>(ProgressChanged);
        }

        /// <summary>
        /// 進捗表示
        /// </summary>
        public static void ProgressChanged(int val)
        {
            pb.Value = val;
        }

        /// <summary>
        /// タイマー開始/終了
        /// </summary>
        /// <param name="setFlg">true:開始 false:終了</param>
        public static void SetTimer(Timer timer, bool setFlg)
        {
            if (setFlg) startTime = DateTime.Now;
            timer.Enabled = setFlg;
        }

        /// <summary>
        /// 経過時間を算出
        /// </summary>
        public static string CalcRunningTime()
        {
            ts = DateTime.Now - startTime;
            return "経過時間　" + ts.ToString(@"hh\:mm\:ss");
        }

    }
}
