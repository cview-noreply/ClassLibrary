namespace $safeprojectname$.Const
{
    /// <summary>
    /// SQL配置クラス　※整形はGBQの「クエリを整形」で行う
    /// </summary>
    internal class Sql
    {
        //IDUユーザ情報
        public const string SELECT_RIND_IDU_USER = @"
            SELECT
              ユーザID
            FROM
              RINDBG.ＩＤＵ＿ユーザ情報
            WHERE
              ""E-mailアドレス"" IS NOT NULL";
    }
}
