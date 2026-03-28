using System;
using System.IO;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// ログ関連機能クラス
    /// </summary>
    internal static class LogUtils
    {
        /// <summary>
        /// ログ出力先ディレクトリのパス
        /// </summary>
        private const string LOG_DIRECTORY_PATH = @"logs\";

        /// <summary>
        /// ログ出力メソッド
        /// </summary>
        /// <param name="exportFileName">出力ファイル名</param>
        /// <param name="exportMessage">出力内容</param>
        internal static void ExportLog(string exportFileName, string exportMessage)
        {
            CreateLogDirectory();

            string exportFilePath = LOG_DIRECTORY_PATH + exportFileName;

            string readText = "";
            if (File.Exists(exportFilePath)) readText = File.ReadAllText(exportFilePath);

            //更新日時降順で書き込み
            string exportText = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss\t") + exportMessage + Environment.NewLine;
            File.WriteAllText(exportFilePath, exportText + readText);
        }

        /// <summary>
        /// エラーログ出力メソッド
        /// </summary>
        /// <param name="ex">エラー</param>
        internal static void ExportErrLog(Exception ex)
        {
            CreateLogDirectory();

            string exportFilePath = LOG_DIRECTORY_PATH + "Error_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            string readText = "";
            if (File.Exists(exportFilePath)) readText = File.ReadAllText(exportFilePath);

            //更新日時降順で書き込み
            string exportText = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " | ERROR | " + ex.Message + Environment.NewLine
                    + "Stack Trace :" + ex.StackTrace + Environment.NewLine + Environment.NewLine;
            File.WriteAllText(exportFilePath, exportText + readText);
        }

        /// <summary>
        /// ログ出力先ディレクトリを作成するメソッド
        /// </summary>
        private static void CreateLogDirectory()
        {
            if (!Directory.Exists(LOG_DIRECTORY_PATH))
            {
                Directory.CreateDirectory(LOG_DIRECTORY_PATH);
            }
        }
    }
}
