using System.Collections.Generic;

namespace $safeprojectname$.Logic.Entity
{
    /// <summary>
    /// 【サンプル】kintoneスペース情報データ ※必要な項目のみ
    /// https://cybozu.dev/ja/kintone/docs/rest-api/spaces/get-space/
    /// </summary>
    internal class Sample_KntnSpaceInfoModel
    {
        /// <summary>
        /// スペースID
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// スペース名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// スレッド内アプリのリスト
        /// </summary>
        public List<AttachedApp> attachedApps { get; set; }

        /// <summary>
        /// スレッド内アプリデータ
        /// </summary>
        public partial class AttachedApp
        {
            /// <summary>
            /// アプリID
            /// </summary>
            public long appId { get; set; }

            /// <summary>
            /// アプリの名前
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// アプリ作成者
            /// </summary>
            public UserInfo creator { get; set; }
        }

        /// <summary>
        /// kintone ユーザー情報
        /// </summary>
        public partial class UserInfo
        {
            /// <summary>
            /// ユーザーコード
            /// </summary>
            public string code { get; set; }

            /// <summary>
            /// ユーザー名
            /// </summary>
            public string name { get; set; }
        }
    }
}
