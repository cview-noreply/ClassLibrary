using $safeprojectname$.Const;
using $safeprojectname$.Logic.Entity;
using $safeprojectname$.Utils;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace $safeprojectname$.Forms
{
    public partial class SysAdminForm : Form
    {
        public DataTable toolTbl;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SysAdminForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面読込時
        /// </summary>
        private void SysAdminForm_Load(object sender, EventArgs e)
        {
            toolTbl = SQLiteUtils.GetDataTableOfExcuteSql(Constants.DB_NAME, "SELECT * FROM " + Constants.DB_T_TOOL + " ORDER BY " + Constants.CLM_TOOL_ID);
            if (toolTbl == null)
            {
                MessageUtils.ShowMsgOnTop(string.Format(Messages.ERR_EXEC, "DBの接続") + Messages.CHK_ERR_LOG, false);
                this.Close();
                return;
            }

            this.Lbl_更新日時.Text = UpdateDtTblUtils.GetDate(Params.UpdateDtTbl, Constants.DB_T_TOOL, "");
        }


        /// <summary>
        /// ログインボタン押下時
        /// </summary>
        private void Btn_ログイン_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Txt_パスワード.Text))
            {
                MessageUtils.ShowErrMsg(string.Format(Messages.ERR_NOTINPUT, "パスワード"));
                this.Txt_パスワード.Select();
                return;
            }
            else if (this.Txt_パスワード.Text != Constants.PW)
            {
                MessageUtils.ShowErrMsg(Messages.ERR_PW);
                this.Txt_パスワード.Text = "";
                this.Txt_パスワード.Select();
                return;
            }

            this.Txt_パスワード.Enabled = false;
            this.Btn_ログイン.Enabled = false;
            this.Btn_保存.Enabled = true;
            this.Btn_キャンセル.Enabled = true;

            this.BS_ツール一覧.DataSource = toolTbl;
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

                var rowList = toolTbl.AsEnumerable().Where(r => r[Constants.CLM_SELECT].ToString() == "1").ToArray();
                if (rowList.Length == 0)
                {
                    result.Msg = string.Format(Messages.ERR_NOTSELECT, "ツール");
                    return;
                }

                //DB更新
                if (!SQLiteUtils.DeleteInsertDataTable(Constants.DB_NAME, toolTbl, Constants.DB_T_TOOL))
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, Constants.DB_T_TOOL + "DBの更新") + Messages.CHK_ERR_LOG;
                    return;
                }
                if (!SQLiteUtils.DeleteInsertDataTable(Constants.DB_NAME, UpdateDtTblUtils.UpdateDate(Params.UpdateDtTbl, Constants.DB_T_TOOL, ""), Constants.DB_T_UPDATE_DT))
                {
                    result.Msg = string.Format(Messages.ERR_EXEC, Constants.DB_T_UPDATE_DT + "DBの更新") + Messages.CHK_ERR_LOG;
                    return;
                }

                //ツール情報差し替え
                DispToolInfo.ToolId = rowList[0][Constants.CLM_TOOL_ID].ToString();
                DispToolInfo.ToolRow = rowList[0];

                result.ExecFlg = true;

                //MainFormへ
                this.Close();
                ((MainForm)Application.OpenForms["MainForm"]).SetTgtToolDisp();
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


        /// <summary>
        /// データグリッドビュー選択時
        /// </summary>
        private void Dgv_ツール一覧_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex == -1) return;

            //ラジオボタンと同様の動きを実現させる
            var tgtCellVal = this.Dgv_ツール一覧.CurrentCell.EditedFormattedValue ?? "";
            if (Convert.ToBoolean(tgtCellVal.ToString())) this.Dgv_ツール一覧.Rows.Cast<DataGridViewRow>().Where(row => row.Index != e.RowIndex).Select(row => row.Cells[0].Value = 0).ToList();
        }

    }
}
