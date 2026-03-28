using $safeprojectname$.Const;
using System;
using System.Data;
using System.Linq;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// DBの更新日時テーブル操作クラス
    /// </summary>
    internal class UpdateDtTblUtils
    {
        /// <summary>
        /// 日時を取得
        /// </summary>
        public static string GetDate(DataTable updateDtTbl, string tbl, string tool)
        {
            var rowList = updateDtTbl.AsEnumerable().Where(r => r[Constants.CLM_TBL_NAME].ToString() == tbl && r[Constants.CLM_TOOL_ID].ToString() == tool).ToArray();
            if (rowList.Length > 0) return Constants.CLM_UPDATE_DT + "：" + rowList[0][Constants.CLM_UPDATE_DT].ToString();
            else return "";
        }

        /// <summary>
        /// 日時を更新
        /// </summary>
        public static DataTable UpdateDate(DataTable updateDtTbl, string saveTblNm, string saveToolId)
        {
            DataRow[] rowList = updateDtTbl.AsEnumerable().Where(r => r[Constants.CLM_TBL_NAME].ToString() == saveTblNm && r[Constants.CLM_TOOL_ID].ToString() == saveToolId).ToArray();

            if (rowList.Length > 0) rowList[0][Constants.CLM_UPDATE_DT] = DateTime.Now.ToString(Constants.FMT_UPDATE_DT);
            else
            {
                DataRow nr = updateDtTbl.NewRow();
                nr[Constants.CLM_TOOL_ID] = saveToolId;
                nr[Constants.CLM_TBL_NAME] = saveTblNm;
                nr[Constants.CLM_UPDATE_DT] = DateTime.Now.ToString(Constants.FMT_UPDATE_DT);
                updateDtTbl.Rows.Add(nr);
            }

            return updateDtTbl;
        }

    }
}
