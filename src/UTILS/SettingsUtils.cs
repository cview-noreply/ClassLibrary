using $safeprojectname$.Properties;
using System.Windows.Forms;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// PropertiesのSettings操作クラス
    /// </summary>
    internal class SettingsUtils
    {
        /// <summary>
        /// ツールパスワード
        /// </summary>
        /// <param name="pw">パスワード</param>
        /// <param name="chk">保存チェック</param>
        /// <param name="getFlg">true:取得 false:保存</param>
        public static void ToolPw(TextBox pw, CheckBox chk, bool getFlg)
        {
            if (getFlg)
            {
                pw.Text = Settings.Default.toolPw;
                chk.Checked = Settings.Default.toolPwSaveChk;
            }
            else
            {
                Settings.Default.toolPw = chk.Checked ? pw.Text : "";
                Settings.Default.toolPwSaveChk = chk.Checked;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// RINDBERG接続情報
        /// </summary>
        /// <param name="loginId">ログインID</param>
        /// <param name="pw">パスワード</param>
        /// <param name="chk">保存チェック</param>
        /// <param name="getFlg">true:取得 false:保存</param>
        public static void RindLoginInfo(TextBox loginId, TextBox pw, CheckBox chk, bool getFlg)
        {
            if (getFlg)
            {
                loginId.Text = Settings.Default.rindLoginId;
                pw.Text = Settings.Default.rindPw;
                chk.Checked = Settings.Default.rindSaveChk;
            }
            else
            {
                Settings.Default.rindLoginId = chk.Checked ? loginId.Text : "";
                Settings.Default.rindPw = chk.Checked ? pw.Text : "";
                Settings.Default.rindSaveChk = chk.Checked;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// 文字列項目（TextBox,ComboBox等）
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="settingNm">Settingsの名前</param>
        /// <param name="getFlg">true:取得 false:保存</param>
        public static string StringColumn(bool getFlg, string settingNm, string str = "")
        {
            if (getFlg) return (string)Settings.Default[settingNm];
            else
            {
                Settings.Default[settingNm] = str;
                Settings.Default.Save();
                return str;
            }
        }

        /// <summary>
        /// チェックボックス項目
        /// </summary>
        /// <param name="chk">CheckBox</param>
        /// <param name="settingNm">Settingsの名前</param>
        /// <param name="getFlg">true:取得 false:保存</param>
        public static bool CheckBoxColumn(bool getFlg, string settingNm, bool chk = false)
        {
            if (getFlg) return (bool)Settings.Default[settingNm];
            else
            {
                Settings.Default[settingNm] = chk;
                Settings.Default.Save();
                return chk;
            }
        }

    }
}
