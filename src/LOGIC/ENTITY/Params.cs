using System.Data;

namespace $safeprojectname$.Logic.Entity
{
    /// <summary>
    /// 実行結果や引数を格納するクラス
    /// </summary>
    internal class Params
    {
        /// <summary>
        /// 実行結果
        /// </summary>
        public class Result
        {
            public bool ExecFlg { get; set; } = false;
            public string Msg { get; set; } = "";
        }

        /// <summary>
        /// 更新日時テーブル
        /// </summary>
        public static DataTable UpdateDtTbl { get; set; } = null;

    }
}
