using $safeprojectname$.Const;
using $safeprojectname$.Logic.Entity;
using $safeprojectname$.Utils;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace $safeprojectname$.Forms
{
    public partial class MasterAdminForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MasterAdminForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面読込時
        /// </summary>
        private void MasterAdminForm_Load(object sender, EventArgs e)
        {
            DataTable masterTbl = SQLiteUtils.GetDataTableOfExcuteSql(Constants.DB_NAME, "SELECT * FROM " + Constants.DB_T_MASTER);
            if (masterTbl == null)
            {
                MessageUtils.ShowMsgOnTop(string.Format(Messages.ERR_EXEC, "DBの接続") + Messages.CHK_ERR_LOG, false);
                this.Close();
                return;
            }

            this.BS_マスタ.DataSource = masterTbl;
            this.Lbl_更新日時.Text = UpdateDtTblUtils.GetDate(Params.UpdateDtTbl, Constants.DB_T_MASTER, DispToolInfo.ToolId);
        }


        /// <summary>
        /// 一括取込ボタン押下時
        /// </summary>
        private void Btn_一括取込_Click(object sender, EventArgs e)
        {
            string filePath = DialogUtils.GetFilePathFromDialog("ファイル選択", DialogUtils.GetExtensionFilter(".xlsx"));
            if (filePath == "") return;

            var result = new Params.Result();
            try
            {
                FormSettingUtils.SetControl(true, this, this.Btn_一括取込, result); //処理開始

                DataTable inputDt = FileOperationUtils.ExcelToDataTable(filePath);
                if (inputDt == null)
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, Path.GetFileNameWithoutExtension(filePath) + "の読込") + Messages.CHK_ERR_LOG;
                    return;
                }

                this.BS_マスタ.DataSource = inputDt;

                result.Msg = Messages.INFO_INPUT_END;
                result.ExecFlg = true;
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                result.Msg = string.Format(Messages.ERR_EXEC, this.Btn_一括取込.Text) + Messages.CHK_ERR_LOG;
            }
            finally
            {
                FormSettingUtils.SetControl(false, this, this.Btn_一括取込, result); //処理終了
            }
        }


        /// <summary>
        /// 一括出力ボタン押下時
        /// </summary>
        private void Btn_一括出力_Click(object sender, EventArgs e)
        {
            string folderPath = DialogUtils.GetFolderPathFromDialog("フォルダ選択");
            if (folderPath == "") return;

            var result = new Params.Result();
            try
            {
                FormSettingUtils.SetControl(true, this, this.Btn_一括出力, result); //処理開始

                string filePath = folderPath + "\\" + string.Format(Constants.FILE_NAME, "マスタ", DateTime.Now.ToString(Constants.FMT_FILE_OUTPUT_DATE));
                if (ValidationUtils.IsTooLongPath(filePath))
                {
                    result.Msg = Messages.ERR_OUTPUT_FILEPATH_MAX;
                    return;
                }
                if (ValidationUtils.IsFileExists(filePath))
                {
                    if (!MessageUtils.ShowMsgOnTop(Messages.INFO_OVERWRITE_FILE_CHECK + filePath, false, true))
                    {
                        result.Msg = Messages.INFO_STOP;
                        result.ExecFlg = true;
                        return;
                    }
                }

                DataTable dt = (DataTable)this.BS_マスタ.DataSource;

                if (!FileOperationUtils.DataTableToFile(filePath, dt, 1, "", DispToolInfo.ToolRow[Constants.CLM_BTN_COLOR].ToString()))
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, Path.GetFileName(filePath) + "の出力") + Messages.CHK_ERR_LOG;
                    return;
                }

                result.Msg = Messages.INFO_OUTPUT_END + filePath;
                result.ExecFlg = true;
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                result.Msg = string.Format(Messages.ERR_EXEC, this.Btn_一括出力.Text) + Messages.CHK_ERR_LOG;
            }
            finally
            {
                FormSettingUtils.SetControl(false, this, this.Btn_一括出力, result); //処理終了
            }
        }


        /// <summary>
        /// 保存ボタン押下時
        /// </summary>
        private void Btn_保存_Click(object sender, EventArgs e)
        {
            var result = new Params.Result();
            try
            {
                FormSettingUtils.SetControl(true, this, this.Btn_保存, result); //処理開始

                DataTable dt = (DataTable)this.BS_マスタ.DataSource;

                //DB更新
                if (!SQLiteUtils.DeleteInsertDataTable(Constants.DB_NAME, dt, Constants.DB_T_MASTER))
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, Constants.DB_T_MASTER + "DBの更新") + Messages.CHK_ERR_LOG;
                    return;
                }
                if (!SQLiteUtils.DeleteInsertDataTable(Constants.DB_NAME, UpdateDtTblUtils.UpdateDate(Params.UpdateDtTbl, Constants.DB_T_MASTER, DispToolInfo.ToolId), Constants.DB_T_UPDATE_DT))
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, Constants.DB_T_UPDATE_DT + "DBの更新") + Messages.CHK_ERR_LOG;
                    return;
                }

                result.ExecFlg = true;
                this.Close();
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                result.Msg = string.Format(Messages.ERR_EXEC, this.Btn_保存.Text) + Messages.CHK_ERR_LOG;
            }
            finally
            {
                FormSettingUtils.SetControl(false, this, this.Btn_保存, result); //処理終了
            }
        }


        /// <summary>
        /// キャンセルボタン押下時
        /// </summary>
        private void Btn_キャンセル_Click(object sender, EventArgs e)
        {
            if (MessageUtils.ShowInfoMsg(Messages.INFO_CANCEL_CHECK, true) != DialogResult.OK) return;
            this.Close();
        }

    }
}
