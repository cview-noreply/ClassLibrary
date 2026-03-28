using System.Windows.Forms;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// メッセージボックス出力用クラス
    /// </summary>
    internal static class MessageUtils
    {
        /// <summary>
        /// 親フォームを作成しメッセージを最前面に表示
        /// 参考：https://hensa40.cutegirl.jp/archives/7488
        /// </summary>
        /// <param name="msg">出力メッセージ</param>
        /// <param name="result">【実行結果アイコン】true:Information false:Error or Exclamation</param>
        /// <param name="chk">【確認ボタン】true:OKCancel false:OK</param>
        /// <returns>true:OK false:Cancel</returns>
        public static bool ShowMsgOnTop(string msg, bool result, bool chk = false)
        {
            using (Form f = new Form())
            {
                f.TopMost = true;
                if (chk)
                {
                    DialogResult dialogResult;
                    if (result) dialogResult = MessageBox.Show(msg, "INFO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    else dialogResult = MessageBox.Show(msg, "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dialogResult == DialogResult.Cancel) return false;
                }
                else
                {
                    if (result) MessageBox.Show(f, msg, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show(f, msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                f.TopMost = false;
            }

            return true;
        }

        /// <summary>
        /// インフォメーション用　メッセージボックス出力
        /// </summary>
        /// <param name="msg">出力メッセージ</param>
        /// <param name="yesNo">「OK」「キャンセル」ボタンを使用する場合true　使用しない場合false</param>
        public static DialogResult ShowInfoMsg(string msg, bool yesNo)
        {
            return ShowMsg(msg, "INFO", yesNo, false);
        }

        /// <summary>
        /// エラーメッセージ用　メッセージボックス出力
        /// </summary>
        /// <param name="msg">出力メッセージ</param>
        public static void ShowErrMsg(string msg)
        {
            ShowMsg(msg, "ERROR", false, true);
        }

        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="title">メッセージタイトル</param>
        /// <param name="msg">メッセージ内容</param>
        /// <param name="okcancel">「OK」「キャンセル」ボタンを使用する場合true　使用しない場合false</param>
        /// <param name="err">エラーかどうか</param>
        private static DialogResult ShowMsg(string msg, string title, bool okcancel, bool err)
        {
            DialogResult result;

            // エラー
            if (err) result = MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

            // OK or キャンセルボタン　使用時　※ShowMsgOnTopにある 見出し「WARNING」やアイコン「Information」は未実装
            else if (okcancel) result = MessageBox.Show(msg, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            // 通常
            else result = MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            return result;
        }

    }
}
