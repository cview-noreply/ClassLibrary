using System.Collections.Generic;

namespace $safeprojectname$.Logic.Entity
{
    /// <summary>
    /// 【サンプル】kintoneユーザー情報更新・追加用データ ※必要な項目のみ
    /// https://cybozu.dev/ja/common/docs/user-api/users/add-users/
    /// </summary>
    internal class Sample_KntnUserUpdateModel
    {
        public List<User> users { get; set; }

        public class User
        {
            /// <summary>
            /// ログイン名　※必須
            /// </summary>
            public string code { get; set; }

            /// <summary>
            /// ユーザーの使用状態
            /// </summary>
            public bool valid { get; set; }

            /// <summary>
            /// パスワード　※必須
            /// </summary>
            public string password { get; set; }

            /// <summary>
            /// 表示名　※必須
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

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public User()
            {
                valid = false;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Sample_KntnUserUpdateModel()
        {
            users = new List<User>();
        }
    }
}
