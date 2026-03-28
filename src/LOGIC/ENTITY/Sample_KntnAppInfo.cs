namespace $safeprojectname$.Logic.Entity
{
    /// <summary>
    /// 【サンプル】kintone　アプリ情報データ ※必要な項目のみ
    /// https://cybozu.dev/ja/kintone/docs/rest-api/apps/settings/get-general-settings/
    /// </summary>
    internal class Sample_KntnAppInfo
    {
        /// <summary>
        /// アプリ名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// アプリの説明
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// アプリのアイコンの情報
        /// </summary>
        public Icon icon { get; set; }

        /// <summary>
        /// デザインテーマ
        /// </summary>
        public string theme { get; set; }

        /// <summary>
        /// アプリのアイコンの情報
        /// </summary>
        public class Icon
        {
            /// <summary>
            /// アイコンの種類
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// アイコンのキー（識別子）
            /// </summary>
            public string key { get; set; }
        }
    }
}
