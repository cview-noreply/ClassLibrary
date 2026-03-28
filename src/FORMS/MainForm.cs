using $safeprojectname$.Const;
using $safeprojectname$.Logic.Entity;
using $safeprojectname$.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace $safeprojectname$.Forms
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 取込ファイルデータ
        /// </summary>
        private DataTable inputDt;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定中のツールに表示切り替え
        /// ※SysAdminUtilsを設けてもよい
        /// 　参考：https://ghe.rjbdev.jp/MTC/MailMaker/blob/master/src/MailMaker/Utils/SysAdminUtils.cs
        /// </summary>
        public void SetTgtToolDisp()
        {
            this.Btn_ファイル取込.BackColor = ColorTranslator.FromHtml(DispToolInfo.ToolRow[Constants.CLM_BTN_COLOR].ToString());
            this.Btn_ファイル出力.BackColor = ColorTranslator.FromHtml(DispToolInfo.ToolRow[Constants.CLM_BTN_COLOR].ToString());

            ResetControl();
        }

        /// <summary>
        /// 経過時間表示
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Lbl_経過時間.Text = ProgressUtils.CalcRunningTime();
            this.Refresh();
        }

        /// <summary>
        /// 保持データや画面制御を初期化
        /// </summary>
        private void ResetControl()
        {
            inputDt = null;
            this.Btn_ファイル出力.Enabled = false;

            this.Refresh();
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ドラッグ&ドロップの処理

        /// <summary>
        /// TextBoxにファイルをドラッグした時の動作
        /// </summary>
        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            //ファイルがドラッグされている場合、カーソルを変更する
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// TextBoxにファイルをドロップした時の動作
        /// </summary>
        private void TextBox_DragDropFile(object sender, DragEventArgs e)
        {
            TextBox txtTarget = sender as TextBox;
            string extension = this.Pnl_取込ファイル拡張子.Controls.OfType<RadioButton>().SingleOrDefault(rb => rb.Checked == true).Text;

            txtTarget = FormSettingUtils.DragDropFile(sender, e, extension);
            if (txtTarget != null) FormSettingUtils.SetFileToolTip(this.ToolTip_ファイル名, txtTarget);
        }

        /// <summary>
        /// TextBoxにフォルダをドロップした時の動作
        /// </summary>
        private void TextBox_DragDropFolder(object sender, DragEventArgs e)
        {
            TextBox txtTarget = FormSettingUtils.DragDropFolder(sender, e);
            if (txtTarget != null) FormSettingUtils.SetFolderToolTip(this.ToolTip_フォルダパス, txtTarget);
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///システム管理アイコン関連

        /// <summary>
        /// システム管理アイコンマウスホバー時
        /// </summary>
        private void PicBox_システム管理_MouseHover(object sender, EventArgs e)
        {
            this.PicBox_システム管理.Image = Properties.Resources.setting_hover;
        }

        /// <summary>
        /// システム管理アイコンマウスリムーブ時
        /// </summary>
        private void PicBox_システム管理_MouseLeave(object sender, EventArgs e)
        {
            this.PicBox_システム管理.Image = Properties.Resources.setting;
        }

        /// <summary>
        /// システム管理アイコンクリック時
        /// </summary>
        private void PicBox_システム管理_Click(object sender, EventArgs e)
        {
            try
            {
                var subForm = new SysAdminForm();
                subForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                MessageUtils.ShowMsgOnTop(string.Format(Messages.ERR_EXEC, "システム管理画面の表示") + Messages.CHK_ERR_LOG, false);
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// メイン処理

        /// <summary>
        /// 画面初回表示
        /// </summary>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            var result = new Params.Result();
            try
            {
                //進捗表示のためのコントロールを設定
                ProgressUtils.SetProgressControl(this.Timer, this.Lbl_経過時間, this.ProgressBar);

                FormSettingUtils.SetControl(true, this, null, result); //処理開始

                //設定中のツールを取得
                DataTable toolTbl = SQLiteUtils.GetDataTableOfExcuteSql(Constants.DB_NAME, "SELECT * FROM " + Constants.DB_T_TOOL + " WHERE " + Constants.CLM_SELECT + " = 1");
                if (toolTbl == null)
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, "DBの接続") + Messages.CHK_ERR_LOG;
                    return;
                }
                if (toolTbl.Rows.Count == 0) throw new Exception("ツール未設定");

                DispToolInfo.ToolId = toolTbl.Rows[0][Constants.CLM_TOOL_ID].ToString();
                DispToolInfo.ToolRow = toolTbl.Rows[0];

                SetTgtToolDisp();


                //Version
                FileVersionInfo version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
                this.Lbl_ver.Text = "ver : " + version.ProductVersion;

                //Settings
                SettingsUtils.ToolPw(this.Txt_ツールパスワード, this.ChkBox_ツールパスワード保存, true);
                SettingsUtils.RindLoginInfo(this.Txt_RINDログインID, this.Txt_RINDパスワード, this.ChkBox_RIND入力内容保存, true);
                string tmp = SettingsUtils.StringColumn(true, "inputExtension");
                if (tmp != "") ((RadioButton)this.Pnl_取込ファイル拡張子.Controls[tmp]).Checked = true;
                this.Txt_取込ファイル.Text = SettingsUtils.StringColumn(true, "inputFilePath");
                this.Txt_出力フォルダ.Text = SettingsUtils.StringColumn(true, "outputFolderPath");

                //ToolTip
                FormSettingUtils.SetFileToolTip(this.ToolTip_ファイル名, this.Txt_取込ファイル);
                FormSettingUtils.SetFolderToolTip(this.ToolTip_フォルダパス, this.Txt_出力フォルダ);


                //更新日時テーブルを取得し保持しておく
                Params.UpdateDtTbl = SQLiteUtils.GetDataTableOfExcuteSql(Constants.DB_NAME, "SELECT * FROM " + Constants.DB_T_UPDATE_DT);
                if (Params.UpdateDtTbl == null)
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, "DBの接続") + Messages.CHK_ERR_LOG;
                    return;
                }

                result.ExecFlg = true;
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                result.Msg = string.Format(Messages.ERR_EXEC, "ツール起動") + Messages.CHK_ERR_LOG;
            }
            finally
            {
                FormSettingUtils.SetControl(false, this, null, result); //処理終了
                if (!result.ExecFlg) this.Close();
            }
        }


        /// <summary>
        /// 画面終了時
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLiteUtils.Vacuum(Constants.DB_NAME); //※大量データをDBに保持しているときのみ

            SettingsUtils.ToolPw(this.Txt_ツールパスワード, this.ChkBox_ツールパスワード保存, false);
            SettingsUtils.RindLoginInfo(this.Txt_RINDログインID, this.Txt_RINDパスワード, this.ChkBox_RIND入力内容保存, false);
            SettingsUtils.StringColumn(false, "inputExtension", this.Pnl_取込ファイル拡張子.Controls.OfType<RadioButton>().SingleOrDefault(rb => rb.Checked == true).Name);
            SettingsUtils.StringColumn(false, "inputFilePath", this.Txt_取込ファイル.Text);
            SettingsUtils.StringColumn(false, "outputFolderPath", this.Txt_出力フォルダ.Text);
        }


        /// <summary>
        /// 取込ファイル拡張子変更時
        /// </summary>
        private void Radio_取込ファイル拡張子_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton tmp = sender as RadioButton;
            if (tmp == null || !tmp.Checked) return; //チェックを外すイベントは通さない

            ResetControl();
            this.Txt_取込ファイル.Text = "";
            FormSettingUtils.SetFileToolTip(this.ToolTip_ファイル名, this.Txt_取込ファイル);
        }


        /// <summary>
        /// 取込ファイル参照ボタン押下時
        /// </summary>
        private void Btn_取込ファイル参照_Click(object sender, EventArgs e)
        {
            string defaultDir = this.Txt_取込ファイル.Text == "" ? "" : Path.GetDirectoryName(this.Txt_取込ファイル.Text);
            string extension = this.Pnl_取込ファイル拡張子.Controls.OfType<RadioButton>().SingleOrDefault(rb => rb.Checked == true).Text;
            string tmp = DialogUtils.GetFilePathFromDialog("ファイル選択", DialogUtils.GetExtensionFilter(extension), defaultDir);
            if (tmp != "")
            {
                this.Txt_取込ファイル.Text = tmp;
                FormSettingUtils.SetFileToolTip(this.ToolTip_ファイル名, this.Txt_取込ファイル);
            }
        }

        /// <summary>
        /// 出力フォルダ参照ボタン押下時
        /// </summary>
        private void Btn_出力フォルダ参照_Click(object sender, EventArgs e)
        {
            string tmp = DialogUtils.GetFolderPathFromDialog("フォルダ選択", this.Txt_出力フォルダ.Text);
            if (tmp != "")
            {
                this.Txt_出力フォルダ.Text = tmp;
                FormSettingUtils.SetFolderToolTip(this.ToolTip_フォルダパス, this.Txt_出力フォルダ);
            }
        }

        /// <summary>
        /// 取込ファイルフォーカスアウト時
        /// </summary>
        private void Txt_取込ファイル_Leave(object sender, EventArgs e)
        {
            FormSettingUtils.SetFileToolTip(this.ToolTip_ファイル名, this.Txt_取込ファイル);
        }

        /// <summary>
        /// 出力フォルダフォーカスアウト時
        /// </summary>
        private void Txt_出力フォルダ_Leave(object sender, EventArgs e)
        {
            FormSettingUtils.SetFolderToolTip(this.ToolTip_フォルダパス, this.Txt_出力フォルダ);
        }


        /// <summary>
        /// テストリンク押下時
        /// </summary>
        private void Link_テスト_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Link_テスト.LinkVisited = true;
            Process.Start("https://e0tub.cybozu.com/k/#/space/62"); //ブラウザで開く
        }


        /// <summary>
        /// チェック管理ボタン押下時
        /// </summary>
        private void Btn_チェック管理_Click(object sender, EventArgs e)
        {
            try
            {
                var subForm = new CheckAdminForm();
                subForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                MessageUtils.ShowMsgOnTop(string.Format(Messages.ERR_EXEC, this.Btn_チェック管理.Text + "画面の表示") + Messages.CHK_ERR_LOG, false);
            }
        }


        /// <summary>
        /// マスタ管理ボタン押下時
        /// </summary>
        private void Btn_マスタ管理_Click(object sender, EventArgs e)
        {
            try
            {
                //※ツール毎に必要なマスタを実装
                var subForm = new MasterAdminForm();
                subForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                MessageUtils.ShowMsgOnTop(string.Format(Messages.ERR_EXEC, this.Btn_マスタ管理.Text + "画面の表示") + Messages.CHK_ERR_LOG, false);
            }
        }


        /// <summary>
        /// ファイル取込ボタン押下時
        /// </summary>
        private async void Btn_ファイル取込_Click(object sender, EventArgs e)
        {
            FormSettingUtils.SetControlWithTimer(true, this, this.Btn_ファイル取込, null); //処理開始
            ResetControl();

            Params.Result result = await Task.Run(() => ExecInputFile(ProgressUtils.progress));
            if (result.ExecFlg)
            {
                this.Btn_ファイル出力.Enabled = true;
            }

            FormSettingUtils.SetControlWithTimer(false, this, this.Btn_ファイル取込, result); //処理終了
        }

        private Params.Result ExecInputFile(IProgress<int> p)
        {
            var result = new Params.Result();
            try
            {
                //実行権限チェック
                if (string.IsNullOrWhiteSpace(this.Txt_ツールパスワード.Text)) result.Msg = string.Format(Messages.ERR_NOTINPUT, this.Lbl_ツールパスワード.Text);
                else if (this.Txt_ツールパスワード.Text != DispToolInfo.ToolRow[Constants.CLM_TOOL_PW].ToString()) result.Msg = Messages.ERR_PW;

                //バリデーション
                else if (string.IsNullOrWhiteSpace(this.Txt_取込ファイル.Text)) result.Msg = string.Format(Messages.ERR_NOTSELECT, this.Lbl_取込ファイル.Text);
                else if (!ValidationUtils.IsFileExists(this.Txt_取込ファイル.Text)) result.Msg = string.Format(Messages.ERR_NOTEXIST, this.Lbl_取込ファイル.Text);
                else if (ValidationUtils.IsTooLongPath(this.Txt_取込ファイル.Text)) result.Msg = string.Format(Messages.ERR_INPUT_FILEPATH_MAX, this.Lbl_取込ファイル.Text);
                else if (ValidationUtils.IsFileLocked(this.Txt_取込ファイル.Text)) result.Msg = string.Format(Messages.ERR_OPEN_FILE, this.Lbl_取込ファイル.Text);

                if (result.Msg != "") return result;

                p.Report(10); //progressBarを進める


                string extension = this.Pnl_取込ファイル拡張子.Controls.OfType<RadioButton>().SingleOrDefault(rb => rb.Checked == true).Text;
                if (extension.Contains("xls"))
                {
                    inputDt = FileOperationUtils.ExcelToDataTable(this.Txt_取込ファイル.Text);
                }
                else
                {
                    inputDt = FileOperationUtils.TextToDataTable(this.Txt_取込ファイル.Text, ',');
                }
                if (inputDt == null)
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, Path.GetFileNameWithoutExtension(this.Txt_取込ファイル.Text) + "の読込") + Messages.CHK_ERR_LOG;
                    return result;
                }
                if (inputDt.Rows.Count == 0)
                {
                    result.Msg = string.Format(Messages.ERR_NO_DATA, this.Lbl_取込ファイル.Text);
                    return result;
                }

                //FMTチェック（使用する項目が少ない時は項目存在チェック、多い時は最初と最後の項目名チェックなど）
                if (inputDt.Columns.Count != 10 || inputDt.Columns[0].ColumnName != "最初" || inputDt.Columns[9].ColumnName != "最後")
                {
                    result.Msg = string.Format(Messages.ERR_INPUT_FILE, this.Lbl_取込ファイル.Text);
                    return result;
                }

                //完了メッセージ
                result.Msg = Messages.INFO_INPUT_END;

                result.ExecFlg = true; //処理成功
                p.Report(100); //progressBarを100%にする
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                result.Msg = string.Format(Messages.ERR_EXEC, this.Btn_ファイル取込.Text) + Messages.CHK_ERR_LOG;
            }

            return result;
        }


        /// <summary>
        /// ファイル出力ボタン押下時
        /// </summary>
        private async void Btn_ファイル出力_Click(object sender, EventArgs e)
        {
            FormSettingUtils.SetControlWithTimer(true, this, this.Btn_ファイル出力, null); //処理開始
            Params.Result result = await Task.Run(() => ExecOutputFile(ProgressUtils.progress));
            FormSettingUtils.SetControlWithTimer(false, this, this.Btn_ファイル出力, result); //処理終了
        }

        private Params.Result ExecOutputFile(IProgress<int> p)
        {
            var result = new Params.Result();
            try
            {
                //実行権限チェック
                if (string.IsNullOrWhiteSpace(this.Txt_ツールパスワード.Text)) result.Msg = string.Format(Messages.ERR_NOTINPUT, this.Lbl_ツールパスワード.Text);
                else if (this.Txt_ツールパスワード.Text != DispToolInfo.ToolRow[Constants.CLM_TOOL_PW].ToString()) result.Msg = Messages.ERR_PW;

                //バリデーション
                else if (string.IsNullOrWhiteSpace(this.Txt_出力フォルダ.Text)) result.Msg = string.Format(Messages.ERR_NOTSELECT, this.Lbl_出力フォルダ.Text);
                else if (!ValidationUtils.IsFolderExists(this.Txt_出力フォルダ.Text)) result.Msg = string.Format(Messages.ERR_NOTEXIST, this.Lbl_出力フォルダ.Text);

                else if (string.IsNullOrWhiteSpace(this.Txt_RINDログインID.Text) || string.IsNullOrWhiteSpace(this.Txt_RINDパスワード.Text)) result.Msg = string.Format(Messages.ERR_NOTINPUT, this.GrpBox_RINDBERG.Text + "の接続情報");
                else if (!RindAccessUtils.ConnectCheck(this.Txt_RINDログインID.Text, this.Txt_RINDパスワード.Text)) result.Msg = Messages.ERR_RIND_ACCESS;

                if (result.Msg != "") return result;

                string filePath = this.Txt_出力フォルダ.Text + "\\" + string.Format(Constants.FILE_NAME, "ファイル出力", DateTime.Now.ToString(Constants.FMT_FILE_OUTPUT_DATE));
                if (ValidationUtils.IsTooLongPath(filePath))
                {
                    result.Msg = Messages.ERR_OUTPUT_FILEPATH_MAX;
                    return result;
                }
                if (ValidationUtils.IsFileExists(filePath))
                {
                    if (!MessageUtils.ShowMsgOnTop(Messages.INFO_OVERWRITE_FILE_CHECK + filePath, false, true))
                    {
                        result.Msg = Messages.INFO_STOP;
                        result.ExecFlg = true;
                        return result;
                    }
                }

                p.Report(10); //progressBarを進める


                //RINDからデータ取得
                DataTable rind = RindAccessUtils.SelectAsDataTable(this.Txt_RINDログインID.Text, this.Txt_RINDパスワード.Text, Sql.SELECT_RIND_IDU_USER);
                if (rind == null)
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, this.GrpBox_RINDBERG.Text + "のデータ取得") + Messages.CHK_ERR_LOG;
                    return result;
                }

                var outputFiles = new List<string>(); //出力完了ファイル管理用

                //Excel出力　※エラーデータ出力時のヘッダー色は Constants.COLOR_ERR_FILE
                if (!FileOperationUtils.DataTableToFile(filePath, rind, 1, "", DispToolInfo.ToolRow[Constants.CLM_BTN_COLOR].ToString()))
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, Path.GetFileName(filePath) + "の出力") + Messages.CHK_ERR_LOG;
                    return result;
                }

                outputFiles.Add(Path.GetFileName(filePath));


                //完了メッセージ
                result.Msg = Messages.INFO_OUTPUT_END + string.Join("\r\n", outputFiles);

                result.ExecFlg = true; //処理成功
                p.Report(100); //progressBarを100%にする
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                result.Msg = string.Format(Messages.ERR_EXEC, this.Btn_ファイル出力.Text) + Messages.CHK_ERR_LOG;
            }

            return result;
        }

    }
}
