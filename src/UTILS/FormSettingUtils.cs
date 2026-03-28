using $safeprojectname$.Const;
using $safeprojectname$.Logic.Entity;
using System.IO;
using System.Windows.Forms;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// フォーム関連の設定クラス
    /// </summary>
    internal class FormSettingUtils
    {
        /// <summary>
        /// 処理中の画面制御（進捗表示あり）
        /// </summary>
        /// <param name="setFlg">true:開始 false:終了</param>
        /// <param name="f">フォーム</param>
        /// <param name="btn">ボタン</param>
        /// <param name="result">実行結果</param>
        public static void SetControlWithTimer(bool setFlg, Form f, Button btn, Params.Result result)
        {
            ProgressUtils.SetTimer(ProgressUtils.timer, setFlg);

            if (setFlg) f.Cursor = Cursors.WaitCursor;
            else f.Cursor = Cursors.Default;

            if (result != null && result.Msg != "") MessageUtils.ShowMsgOnTop(result.Msg, result.ExecFlg);

            if (!setFlg) ProgressUtils.lbl.Text = ProgressUtils.defaultDisp;
            ProgressUtils.pb.Value = 0;

            if (btn != null) btn.Enabled = !setFlg;

            f.Refresh();
        }

        /// <summary>
        /// 処理中の画面制御（進捗表示なし）
        /// </summary>
        /// <param name="setFlg">true:開始 false:終了</param>
        /// <param name="f">フォーム</param>
        /// <param name="btn">ボタン</param>
        /// <param name="result">実行結果</param>
        public static void SetControl(bool setFlg, Form f, Button btn, Params.Result result)
        {
            if (setFlg) f.Cursor = Cursors.WaitCursor;
            else f.Cursor = Cursors.Default;

            if (result != null && result.Msg != "") MessageUtils.ShowMsgOnTop(result.Msg, result.ExecFlg);

            if (btn != null) btn.Enabled = !setFlg;

            f.Refresh();
        }

        /// <summary>
        /// ツールチップでファイル名を表示
        /// </summary>
        public static void SetFileToolTip(ToolTip toolTip, TextBox txtBox)
        {
            toolTip.SetToolTip(txtBox, Path.GetFileName(txtBox.Text));
        }

        /// <summary>
        /// ツールチップでフォルダパスを表示
        /// </summary>
        public static void SetFolderToolTip(ToolTip toolTip, TextBox txtBox)
        {
            toolTip.SetToolTip(txtBox, txtBox.Text);
        }

        /// <summary>
        /// TextBoxにファイルをドロップした時の動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="extension">許容するファイル拡張子</param>
        /// <returns>パスを挿入したTextBox</returns>
        public static TextBox DragDropFile(object sender, DragEventArgs e, string extension)
        {
            //ドロップされたファイルの一覧を取得
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length <= 0) return null;

            //複数選択されていた場合
            if (fileName.Length > 1)
            {
                MessageUtils.ShowMsgOnTop(Messages.ERR_FILEDROP_MULT, false);
                return null;
            }

            //ドロップ先がTextBoxであるかチェック
            TextBox txtTarget = sender as TextBox;
            if (txtTarget == null) return null;

            //ファイル拡張子チェック
            if (Path.GetExtension(fileName[0]) != extension)
            {
                MessageUtils.ShowMsgOnTop(string.Format(Messages.ERR_NOTSELECT, extension + "ファイル"), false);
                return null;
            }

            txtTarget.Text = fileName[0];
            return txtTarget;
        }

        /// <summary>
        /// TextBoxにフォルダをドロップした時の動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>パスを挿入したTextBox</returns>
        public static TextBox DragDropFolder(object sender, DragEventArgs e)
        {
            //ドロップされたファイルの一覧を取得
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length <= 0) return null;

            //複数選択されていた場合
            if (fileName.Length > 1)
            {
                MessageUtils.ShowMsgOnTop(Messages.ERR_FILEDROP_MULT, false);
                return null;
            }

            //選択されたものがファイルだった場合
            if (!Directory.Exists(fileName[0]))
            {
                MessageUtils.ShowMsgOnTop(Messages.ERR_FILEDROP_FOLDER, false);
                return null;
            }

            //ドロップ先がTextBoxであるかチェック
            TextBox txtTarget = sender as TextBox;
            if (txtTarget == null) return null;

            txtTarget.Text = fileName[0];
            return txtTarget;
        }

    }
}
