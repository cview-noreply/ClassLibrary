namespace $safeprojectname$.Const
{
    /// <summary>
    /// 固定値を配置するクラスです。
    /// </summary>
    internal class Constants
    {
        //システム管理PW
        public const string PW = "mtc";

        //DB情報
        public const string DB_NAME = "ToolName.db";
        public const string DB_T_TOOL = "T_ツール一覧";
        public const string DB_T_UPDATE_DT = "T_更新日時";
        public const string DB_T_CHECK = "T_チェック一覧";
        public const string DB_T_MASTER = "T_マスタ";

        //項目名
        public const string CLM_SELECT = "選択";
        public const string CLM_TOOL_ID = "ツールID";
        public const string CLM_BTN_COLOR = "ボタン色(Hex)";
        public const string CLM_TOOL_PW = "ツールPW";
        public const string CLM_KNTN_SUBDOMAIN = "サブドメイン";
        public const string CLM_KNTN_ID = "kintoneユーザーID";
        public const string CLM_KNTN_PW = "kintoneユーザーPW";
        public const string CLM_TBL_NAME = "テーブル名";
        public const string CLM_UPDATE_DT = "更新日時";
        public const string CLM_CATEGORY = "カテゴリ";
        public const string CLM_NO = "No";

        //ファイル関連
        public const string FILE_NAME = "{0}_{1}.xlsx";
        public const string COLOR_ERR_FILE = "#FF9999";

        //FMT
        public const string FMT_FILE_OUTPUT_DATE = "yyyyMMddHHmm";
        public const string FMT_UPDATE_DT = "yyyy/MM/dd HH:mm";
    }
}
