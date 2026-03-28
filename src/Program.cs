using System;
using System.Threading;
using System.Windows.Forms;

namespace $safeprojectname$
{
    internal static class Program
    {
        public static int errCnt = 0;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            Application.Run(new Forms.MainForm());
        }

        /// <summary>
        /// ハンドルされない例外発生時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //const string MSG_UNHANDLED_EXCEPTION = "例外エラーが発生しました。\r\n 1. 時間をおいて再実行をお願いします。\r\n 2.（再実行後もエラーとなる場合）logsフォルダ内のファイルを確認してください。\r\n 3.（logの内容が不明の場合）ツールのフォルダごと管理者に送付してください。\r\n 4.（読込ファイルがある場合）読込ファイルも合わせて管理者に送付してください。";

            //ログ出力&メッセージ表示
            Utils.LogUtils.ExportErrLog(e.Exception);

            if (errCnt == 0)
            {
                errCnt++;
                MessageBox.Show("例外エラーが発生しました。\r\n時間をおいて再実行してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("例外エラーが発生しました。\r\nツールをフォルダごと管理者に送付してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
