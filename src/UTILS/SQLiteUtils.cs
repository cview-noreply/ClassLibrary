using System;
using System.Data;
using System.Data.SQLite;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// SQLite操作クラス
    /// </summary>
    internal class SQLiteUtils
    {
        /// <summary>
        /// SQL実行結果をDataTableで取得するメソッド(SELECT分のみ対応)
        /// </summary>
        /// <param name="dbName">DB名</param>
        /// <param name="sql">実行するSQL文字列</param>
        /// <returns>処理成功の場合　→　実行結果が格納されたDataTable
        /// 　　　　  処理失敗の場合　→　Null</returns>
        internal static DataTable GetDataTableOfExcuteSql(string dbName, string sql)
        {
            //SQLite接続設定
            SQLiteConnectionStringBuilder scsb = CreateSQLiteConnectionSettings(dbName);
            scsb.ReadOnly = true;

            DataTable dt = new DataTable();

            using (SQLiteConnection con = new SQLiteConnection(scsb.ConnectionString))
            {
                try
                {
                    con.Open();
                }
                catch (SQLiteException ex)
                {
                    LogUtils.ExportErrLog(ex);
                    return null;
                }

                using (SQLiteDataAdapter sda = new SQLiteDataAdapter(sql, con))
                {
                    try
                    {
                        sda.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        LogUtils.ExportErrLog(ex);
                        return null;
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// DataTableのデータをDB内テーブルにインサートするメソッド
        /// </summary>
        /// <param name="dbName">DB名</param>
        /// <param name="dt">インサートするDataTable</param>
        /// <param name="tableName">インサート先テーブル名</param>
        /// <returns>処理成功の場合　→　true
        /// 　　　　  処理失敗の場合　→　false</returns>
        internal static bool InsertDataTable(string dbName, DataTable dt, string tableName)
        {
            string sql = "SELECT * FROM " + tableName + ";";

            SQLiteConnectionStringBuilder scsb = CreateSQLiteConnectionSettings(dbName);

            using (SQLiteConnection con = new SQLiteConnection(scsb.ConnectionString))
            {
                try
                {
                    con.Open();
                }
                catch (SQLiteException ex)
                {
                    LogUtils.ExportErrLog(ex);
                    return false;
                }

                using (SQLiteDataAdapter sda = new SQLiteDataAdapter(sql, con))
                {
                    try
                    {
                        DataTable tempDt = new DataTable();
                        sda.Fill(tempDt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow newRow = tempDt.NewRow();

                            for (int n = 0; n < tempDt.Columns.Count; n++)
                            {
                                newRow[n] = dt.Rows[i][n];
                            }

                            tempDt.Rows.Add(newRow);
                        }

                        //アップデート用コマンドを生成後、テーブル更新
                        SQLiteCommandBuilder scb = new SQLiteCommandBuilder(sda);
                        sda.Update(tempDt);
                    }
                    catch (Exception ex)
                    {
                        LogUtils.ExportErrLog(ex);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// テーブルの全レコードを削除するメソッド
        /// </summary>
        /// <param name="dbName">DB名</param>
        /// <param name="tableName">レコードを削除するテーブル名</param>
        /// <returns>処理成功の場合　→　true
        /// 　　　　  処理失敗の場合　→　false</returns>
        internal static bool DeleteAllRecord(string dbName, string tableName)
        {
            string delSql = "DELETE FROM " + tableName + ";";

            SQLiteConnectionStringBuilder scsb = CreateSQLiteConnectionSettings(dbName);

            using (SQLiteConnection con = new SQLiteConnection(scsb.ConnectionString))
            {
                try
                {
                    con.Open();
                }
                catch (SQLiteException ex)
                {
                    LogUtils.ExportErrLog(ex);
                    return false;
                }

                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Transaction = con.BeginTransaction();

                    try
                    {
                        cmd.CommandText = delSql;

                        cmd.ExecuteNonQuery();
                        cmd.Transaction.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        cmd.Transaction.Rollback();

                        LogUtils.ExportErrLog(ex);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// テーブルの全レコードを削除し、DataTableのデータをインサートするメソッド（同一トランザクション内）
        /// </summary>
        /// <param name="dbName">DB名</param>
        /// <param name="dt">インサートするDataTable</param>
        /// <param name="tableName">インサート先テーブル名</param>
        /// <returns>処理成功の場合　→　true
        /// 　　　　  処理失敗の場合　→　false</returns>
        public static bool DeleteInsertDataTable(string dbName, DataTable dt, string tableName)
        {
            string delSql = "DELETE FROM " + tableName + ";";
            string sql = "SELECT * FROM " + tableName + ";";

            SQLiteConnectionStringBuilder scsb = CreateSQLiteConnectionSettings(dbName);

            using (SQLiteConnection con = new SQLiteConnection(scsb.ConnectionString))
            {
                try
                {
                    con.Open();
                }
                catch (SQLiteException ex)
                {
                    LogUtils.ExportErrLog(ex);
                    return false;
                }

                using (SQLiteTransaction tran = con.BeginTransaction())
                using (SQLiteDataAdapter sda = new SQLiteDataAdapter(sql, con))
                {
                    //レコード一括削除
                    using (SQLiteCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = delSql;

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();

                            LogUtils.ExportErrLog(ex);
                            return false;
                        }
                    }

                    //DataTableインサート
                    try
                    {
                        DataTable tempDt = new DataTable();
                        sda.Fill(tempDt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow newRow = tempDt.NewRow();

                            for (int n = 0; n < tempDt.Columns.Count; n++)
                            {
                                newRow[n] = dt.Rows[i][n];
                            }

                            tempDt.Rows.Add(newRow);
                        }

                        //アップデート用コマンドを生成後、テーブル更新
                        SQLiteCommandBuilder scb = new SQLiteCommandBuilder(sda);
                        sda.Update(tempDt);

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();

                        LogUtils.ExportErrLog(ex);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 条件に一致するレコードをテーブルから削除し、DataRowをインサートするメソッド（同一トランザクション内）
        /// </summary>
        /// <param name="dbName">DB名</param>
        /// <param name="dr">インサートするDataRow</param>
        /// <param name="tableName">インサート先テーブル名</param>
        /// <param name="condition">削除条件</param>
        /// <returns>処理成功の場合　→　true
        /// 　　　　  処理失敗の場合　→　false</returns>
        public static bool DeleteInsertDataRow(string dbName, DataRow dr, string tableName, string condition)
        {
            string delSql = "DELETE FROM " + tableName + " WHERE " + condition + ";";
            string sql = "SELECT * FROM " + tableName + ";";

            SQLiteConnectionStringBuilder scsb = CreateSQLiteConnectionSettings(dbName);

            using (SQLiteConnection con = new SQLiteConnection(scsb.ConnectionString))
            {
                try
                {
                    con.Open();
                }
                catch (SQLiteException ex)
                {
                    LogUtils.ExportErrLog(ex);
                    return false;
                }

                using (SQLiteTransaction tran = con.BeginTransaction())
                {
                    //レコード削除
                    using (SQLiteCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = delSql;

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();

                            LogUtils.ExportErrLog(ex);
                            return false;
                        }
                    }

                    //DataRowインサート
                    using (SQLiteDataAdapter sda = new SQLiteDataAdapter(sql, con))
                    {
                        try
                        {
                            DataTable tempDt = new DataTable();
                            sda.Fill(tempDt);

                            tempDt.Rows.Add(dr.ItemArray);

                            //アップデート用コマンドを生成後、テーブル更新
                            SQLiteCommandBuilder scb = new SQLiteCommandBuilder(sda);
                            sda.Update(tempDt);

                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();

                            LogUtils.ExportErrLog(ex);
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// SQLite接続設定を作成するメソッド
        /// </summary>
        /// <param name="dbName">DB名</param>
        /// <returns></returns>
        private static SQLiteConnectionStringBuilder CreateSQLiteConnectionSettings(string dbName)
        {
            SQLiteConnectionStringBuilder scsb = new SQLiteConnectionStringBuilder();

            scsb.DataSource = @".\Database\" + dbName;
            scsb.JournalMode = SQLiteJournalModeEnum.Persist;
            scsb.SyncMode = SynchronizationModes.Normal;

            return scsb;
        }

        /// <summary>
        /// DBファイル軽量化
        /// </summary>
        public static void Vacuum(string dbName)
        {
            SQLiteConnectionStringBuilder scsb = CreateSQLiteConnectionSettings(dbName);

            using (SQLiteConnection con = new SQLiteConnection(scsb.ConnectionString))
            {
                con.Open();

                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "VACUUM";
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
