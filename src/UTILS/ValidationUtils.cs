using System;
using System.IO;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// バリデーション関連クラス
    /// </summary>
    internal static class ValidationUtils
    {
        /// <summary>
        /// ファイルが存在するか確認するメソッド
        /// </summary>
        /// <param name="filePath">確認したいファイルのファイルパス</param>
        /// <returns>存在する場合　　→　true
        ///                存在しない場合　→　false</returns>
        internal static bool IsFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// フォルダが存在するか確認するメソッド
        /// </summary>
        /// <param name="folderPath">確認したいフォルダのフォルダパス</param>
        /// <returns>存在する場合　　→　true
        ///                存在しない場合　→　false</returns>
        internal static bool IsFolderExists(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ファイルのパスが.NETの最大長を超えていないか確認するメソッド
        /// 参考：https://docs.microsoft.com/ja-jp/dotnet/api/system.io.pathtoolongexception?view=net-5.0
        /// </summary>
        /// <param name="filePath">確認したいファイルのファイルパス</param>
        /// <returns>最大長を超えている場合　→　true
        ///                超えていない場合　　　　→　false</returns>
        internal static bool IsTooLongPath(string filePath)
        {
            if (filePath.Length > 259)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ファイルがロック(別プロセスで使用)されているか確認するメソッド
        /// </summary>
        /// <param name="filePath">確認したいファイルのファイルパス</param>
        /// <returns>ロックされている場合　→　true
        ///                されていない場合　　　→　false</returns>
        internal static bool IsFileLocked(string filePath)
        {
            try
            {
                using (var fs = File.Open(filePath, FileMode.Open, FileAccess.Write))
                {
                    fs.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
