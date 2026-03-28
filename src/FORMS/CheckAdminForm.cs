using $safeprojectname$.Const;
using $safeprojectname$.Logic.Entity;
using $safeprojectname$.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace $safeprojectname$.Forms
{
    public partial class CheckAdminForm : Form
    {
        /// <summary>
        /// 検索ボックス対象列一覧
        /// </summary>
        private List<string> searchClmList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CheckAdminForm()
        {
            InitializeComponent();

            searchClmList = new List<string>();
        }

        /// <summary>
        /// フィルタプルダウン　作成
        /// </summary>
        private void SetFilterComboBox(DataTable checkTbl)
        {
            //元データの重複削除
            DataView dv = new DataView(checkTbl);
            DataTable dt = dv.ToTable(true, new string[] { Constants.CLM_CATEGORY });

            //先頭にブランク行を追加しフィルタ解除できるようにする
            DataRow nr = dt.NewRow();
            dt.Rows.InsertAt(nr, 0);

            this.CbBox_フィルタ.DataSource = dt;
            this.CbBox_フィルタ.DisplayMember = Constants.CLM_CATEGORY;
        }

        /// <summary>
        /// 検索ボックス　プレースホルダーを設定
        /// </summary>
        private void SetSearchBox()
        {
            this.Txt_検索.Text = "検索";
            this.Txt_検索.ForeColor = Color.Gray;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// メイン処理

        /// <summary>
        /// 画面読込時
        /// </summary>
        private void CheckAdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                var conditions = " WHERE " + Constants.CLM_TOOL_ID + " = " + DispToolInfo.ToolId + " ORDER BY " + Constants.CLM_NO;
                DataTable checkTbl = SQLiteUtils.GetDataTableOfExcuteSql(Constants.DB_NAME, "SELECT * FROM " + Constants.DB_T_CHECK + conditions);
                if (checkTbl == null)
                {
                    MessageUtils.ShowMsgOnTop(string.Format(Messages.ERR_EXEC, "DBの接続") + Messages.CHK_ERR_LOG, false);
                    this.Close();
                    return;
                }

                this.BS_チェック一覧.DataSource = checkTbl;

                SetFilterComboBox(checkTbl);

                //検索ボックス対象列一覧を作成
                foreach (DataColumn c in checkTbl.Columns)
                {
                    if (c.ColumnName == Constants.CLM_CATEGORY) continue; //フィルタプルダウンがある項目を飛ばす
                    if (c.ColumnName == Constants.CLM_TOOL_ID || c.ColumnName == Constants.CLM_NO) continue; //検索対象外の項目を飛ばす
                    searchClmList.Add(c.ColumnName);
                }

                //フィルタコントロールの初期設定をする
                this.CbBox_フィルタ.SelectedIndex = 0;
                SetSearchBox();
                this.CbBox_フィルタ.Enabled = true;
                this.Txt_検索.Enabled = true;

                //↓DGVのヘッダー色を変えたいときのサンプルコード
                this.Dgv_チェック一覧.EnableHeadersVisualStyles = false;
                this.Dgv_チェック一覧.Columns[Constants.CLM_CATEGORY].HeaderCell.Style.BackColor = Color.Yellow;
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                MessageUtils.ShowErrMsg(string.Format(Messages.ERR_EXEC, this.Name + "画面の表示") + Messages.CHK_ERR_LOG);
                this.Close();
            }
        }


        /// <summary>
        /// 検索ボックス　フォーカスイン時
        /// </summary>
        private void Txt_検索_Enter(object sender, EventArgs e)
        {
            if (this.Txt_検索.Text == "検索")
            {
                //プレースホルダーを外す
                this.Txt_検索.Text = "";
                this.Txt_検索.ForeColor = SystemColors.ControlText;
            }
        }


        /// <summary>
        /// 検索ボックス　フォーカスアウト時
        /// </summary>
        private void Txt_検索_Leave(object sender, EventArgs e)
        {
            if (this.Txt_検索.Text == "")
            {
                SetSearchBox();
            }
        }


        /// <summary>
        /// 検索ボックス　値変更時
        /// </summary>
        private void Txt_検索_TextChanged(object sender, EventArgs e)
        {
            if (!this.Txt_検索.Enabled) return;
            SetFilter();
        }

        /// <summary>
        /// フィルタプルダウン　変更時
        /// </summary>
        private void CbBox_フィルタ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.CbBox_フィルタ.Enabled) return;
            SetFilter();
        }

        /// <summary>
        ///DGV　フィルタ
        /// </summary>
        private void SetFilter()
        {
            try
            {
                List<string> filterList = new List<string>();
                string filter = "";

                //検索ボックスの値でフィルタ
                if (this.Txt_検索.Text == "" || this.Txt_検索.Text == "検索") goto cbBoxFilter;

                foreach (string clm in searchClmList)
                {
                    filterList.Add(clm + " Like '%" + this.Txt_検索.Text + "%'");
                }
                filter = string.Join(" OR ", filterList);

            cbBoxFilter:
                //プルダウンの値でフィルタ
                if (this.CbBox_フィルタ.SelectedIndex != 0)
                {
                    if (filter != "") filter = "(" + filter + ") AND ";
                    filter += Constants.CLM_CATEGORY + " = '" + this.CbBox_フィルタ.Text + "'";
                }

                if (filter != "") this.BS_チェック一覧.Filter = filter;
                else this.BS_チェック一覧.Filter = null;
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                MessageUtils.ShowErrMsg(string.Format(Messages.ERR_EXEC, "フィルター") + Messages.CHK_ERR_LOG);
            }
        }

    }
}
