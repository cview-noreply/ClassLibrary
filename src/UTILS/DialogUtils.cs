using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Forms;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// ダイアログ関連機能クラス
    /// </summary>
    internal static class DialogUtils
    {
        /// <summary>
        /// ファイル拡張子からファイルダイアログのフィルタを取得するメソッド
        /// </summary>
        internal static string GetExtensionFilter(string fileExtension)
        {
            if (fileExtension == ".xlsx" || fileExtension == ".xls") return "Excelブック|*" + fileExtension;
            else if (fileExtension == ".tsv") return "タブ区切り値|*.tsv";
            else if (fileExtension == ".csv") return "カンマ区切り値|*.csv";
            else if (fileExtension == ".txt") return "テキスト文書|*.txt";
            else return "すべてのファイル|*.*";
        }


        /// <summary>
        /// ファイルダイアログを表示し、選択されたファイルのファイルパスを取得するメソッド
        /// </summary>
        /// <param name="dialogTitle">ダイアログのタイトル</param>
        /// <param name="fileExtension">選択可能なファイル拡張子</param>
        /// <returns>ダイアログでファイルが選択された場合　　　　→　選択されたファイルのファイルパス
        ///             　ダイアログでファイルが選択されなかった場合　→　空文字</returns>
        internal static string GetFilePathFromDialog(string dialogTitle, string fileExtension)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                //ダイアログの設定付与
                ofd.Title = dialogTitle;
                ofd.Filter = fileExtension;
                ofd.RestoreDirectory = true;

                //ダイアログ表示
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// ファイルダイアログを表示し、選択されたファイルのファイルパスを取得するメソッド
        /// </summary>
        /// <param name="dialogTitle">ダイアログのタイトル</param>
        /// <param name="fileExtension">選択可能なファイル拡張子</param>
        /// <param name="initialDirectory">初期表示ディレクトリ</param>
        /// <returns>ダイアログでファイルが選択された場合　　　　→　選択されたファイルのファイルパス
        ///             　ダイアログでファイルが選択されなかった場合　→　空文字</returns>
        internal static string GetFilePathFromDialog(string dialogTitle, string fileExtension, string initialDirectory)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                //ダイアログの設定付与
                if (initialDirectory.Length > 0)
                {
                    ofd.InitialDirectory = initialDirectory;
                }
                else
                {
                    ofd.InitialDirectory = @"C:\";
                }
                ofd.Title = dialogTitle;
                ofd.Filter = fileExtension;
                ofd.RestoreDirectory = true;


                //ダイアログ表示
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// フォルダダイアログを表示し、選択されたフォルダのフォルダパスを取得するメソッド
        /// </summary>
        /// <param name="dialogTitle">ダイアログのタイトル</param>
        /// <returns>ダイアログでフォルダが選択された場合　　　　→　選択されたフォルダのフォルダパス
        ///             　ダイアログでフォルダが選択されなかった場合　→　空文字</returns>
        internal static string GetFolderPathFromDialog(string dialogTitle)
        {
            using (CommonOpenFileDialog cofd = new CommonOpenFileDialog())
            {
                //ダイアログに設定付与
                cofd.IsFolderPicker = true;
                cofd.Title = dialogTitle;
                cofd.RestoreDirectory = true;

                //ダイアログ表示
                if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    return cofd.FileName;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// フォルダダイアログを表示し、選択されたフォルダのフォルダパスを取得するメソッド
        /// </summary>
        /// <param name="dialogTitle">ダイアログのタイトル</param>
        /// <param name="initialDirectory">初期表示ディレクトリ</param>
        /// <returns>ダイアログでフォルダが選択された場合　　　　→　選択されたフォルダのフォルダパス
        ///             　ダイアログでフォルダが選択されなかった場合　→　空文字</returns>
        internal static string GetFolderPathFromDialog(string dialogTitle, string initialDirectory)
        {
            using (CommonOpenFileDialog cofd = new CommonOpenFileDialog())
            {
                //ダイアログに設定付与
                if (initialDirectory.Length > 0)
                {
                    cofd.InitialDirectory = initialDirectory;
                }
                else
                {
                    cofd.InitialDirectory = @"C:\";
                }
                cofd.IsFolderPicker = true;
                cofd.Title = dialogTitle;
                cofd.RestoreDirectory = true;

                //ダイアログ表示
                if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    return cofd.FileName;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
