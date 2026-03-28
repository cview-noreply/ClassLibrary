using System;
using System.Data;
using System.Data.Odbc;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// RINDBERG接続クラス
    /// </summary>
    internal class RindAccessUtils
    {
        /// <summary>
        /// ODBC接続DSN
        /// </summary>
        private const string ODBC_DSN = "dsn=RINDBERG;uid={0};pwd={1};";

        /// <summary>
        /// 接続チェック
        /// </summary>
        /// <param name="id">接続ID</param>
        /// <param name="pass">接続パスワード</param>
        /// <returns>true:成功 false:失敗</returns>
        public static bool ConnectCheck(string id, string pass)
        {
            bool result = false;
            OdbcConnectionStringBuilder ocsb = new OdbcConnectionStringBuilder(string.Format(ODBC_DSN, id, pass));

            try
            {
                using (OdbcConnection con = new OdbcConnection(ocsb.ConnectionString))
                {
                    con.Open();
                    result = true;
                    con.Close();
                }
            }
            catch (OdbcException)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 必要なデータを抽出しDataTableに格納するメソッド
        /// </summary>
        /// <param name="id">接続ID</param>
        /// <param name="pass">接続パスワード</param>
        /// <param name="sql">SQL</param>
        /// <returns>抽出データを格納したDataTable</returns>
        public static DataTable SelectAsDataTable(string id, string pass, string sql)
        {
            DataTable dt = new DataTable();
            OdbcConnectionStringBuilder ocsb = new OdbcConnectionStringBuilder(string.Format(ODBC_DSN, id, pass));

            try
            {
                using (OdbcConnection con = new OdbcConnection(ocsb.ConnectionString))
                {
                    try
                    {
                        con.Open();
                    }
                    catch (Exception ex)
                    {
                        //接続失敗
                        LogUtils.ExportErrLog(ex);
                        return null;
                    }

                    using (OdbcCommand cmd = new OdbcCommand(sql, con))
                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                    {
                        try
                        {
                            adapter.Fill(dt);
                        }
                        catch (Exception ex)
                        {
                            LogUtils.ExportErrLog(ex);
                            return null;
                        }
                    }
                }
            }
            catch (OdbcException oex)
            {
                LogUtils.ExportErrLog(oex);
                return null;
            }

            return dt;
        }

    }
}
