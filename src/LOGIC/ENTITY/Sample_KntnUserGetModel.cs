using System.Collections.Generic;

namespace $safeprojectname$.Logic.Entity
{
    /// <summary>
    /// 【サンプル】kintone　ユーザー情報取得用データ ※必要な項目のみ
    /// https://cybozu.dev/ja/common/docs/user-api/overview/data-structure/#user
    /// </summary>
    internal class Sample_KntnUserGetModel
    {
        /// <summary>
        /// ユーザ情報の一覧
        /// </summary>
        public List<User> users { get; set; }

        /// <summary>
        /// ユーザ情報　
        /// </summary>
        public class User
        {
            /// <summary>
            /// ユーザー ID
            /// </summary>
            public string id { get; set; }

            /// <summary>
            /// ログイン名
            /// </summary>
            public string code { get; set; }

            /// <summary>
            /// 使用可能ユーザーかどうか
            /// </summary>
            public bool valid { get; set; }

            /// <summary>
            /// 表示名
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 姓
            /// </summary>
            public string surName { get; set; }

            /// <summary>
            /// 名
            /// </summary>
            public string givenName { get; set; }

            /// <summary>
            /// よみがな（姓）
            /// </summary>
            public string surNameReading { get; set; }

            /// <summary>
            /// よみがな（名）
            /// </summary>
            public string givenNameReading { get; set; }

            /// <summary>
            /// メールアドレス
            /// </summary>
            public string email { get; set; }

            /// <summary>
            /// 従業員番号
            /// </summary>
            public string employeeNumber { get; set; }
        }
    }
}
