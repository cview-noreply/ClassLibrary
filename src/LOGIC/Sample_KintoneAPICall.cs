using $safeprojectname$.Logic.Entity;
using $safeprojectname$.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $safeprojectname$.Logic
{
    /// <summary>
    /// 【サンプル】kintoneAPI接続クラス　※必要ない場合は削除可
    /// 
    /// ★注意点★
    /// 　・各メソッドを呼び出す前に、KintoneAPIUtils.SetBasicKintoneInfo()を呼び出し、kintone情報を設定すること
    /// 　　※接続はパスワード認証（ユーザーのログイン名とパスワードを使って認証する方法）
    /// 　　※ユーザーのログイン名・パスワードはDB「T_ツール一覧」の「kintoneユーザーID」「kintoneユーザーPW」で管理可
    /// 　・メソッドGETの場合、パラメータは　Dictionary<string, string>　key：パラメータ名　value:データ　とする
    /// 　　メソッドPUT、POSTの場合、パラメータは　Dictionary<string, object>　key：パラメータ名　value:データ　とする
    /// </summary>
    internal class Sample_KintoneAPICall
    {
        /// <summary>
        /// kintone ユーザー情報API
        /// {0}:サブドメイン
        /// </summary>
        private const string KINTONE_API_USER = "https://{0}.cybozu.com/v1/users.json";

        /// <summary>
        /// kintone　アプリ情報API
        /// {0}:サブドメイン
        /// </summary>
        private const string KINTONE_API_APPINFO = "https://{0}.cybozu.com/k/v1/preview/app/settings.json";

        /// <summary>
        /// kintone スペース情報API
        /// {0}:サブドメイン
        /// </summary>
        private const string KINTONE_API_SPACEINFO = "https://{0}.cybozu.com/k/v1/space.json";

        /// <summary>
        /// 指定したユーザーコードのユーザー情報を取得するメソッド
        /// ※100件毎に処理
        /// </summary>
        /// <param name="userIDs">ユーザーコード</param>
        /// <returns>ユーザー情報　※処理失敗時は0件</returns>
        public async static Task<List<Sample_KntnUserGetModel.User>> GetKintoneSelectUserData(List<string> userCodes)
        {
            int index = 0;
            List<Sample_KntnUserGetModel.User> users = new List<Sample_KntnUserGetModel.User>();

            while (true)
            {
                if (index >= userCodes.Count) break;

                int count = index + 100 > userCodes.Count ? userCodes.Count - index : 100;
                string joined = string.Join(",", userCodes.GetRange(index, count));

                //パラメータ作成
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "codes", joined },
                    { "size", "100" }
                };

                //API実行
                string resp = await KintoneAPIUtils.CallGetAPIAsync(KINTONE_API_USER, parameters);
                if (resp == null)
                {
                    return null;
                }
                else if (resp == "")
                {
                    return new List<Sample_KntnUserGetModel.User>();
                }

                //Json変換
                Sample_KntnUserGetModel usersWrk = KintoneAPIUtils.GetObjFromJson<Sample_KntnUserGetModel>(resp);
                if (usersWrk == null)
                {
                    return null;
                }
                users.AddRange(usersWrk.users);

                index += 100;
            }

            return users;
        }

        /// <summary>
        /// 全ユーザー情報を取得するメソッド
        /// ※100件毎に処理
        /// </summary>
        /// <param name="userIDs">ユーザーコード</param>
        /// <returns>ユーザー情報　※処理失敗時は0件</returns>
        public async static Task<List<Sample_KntnUserGetModel.User>> GetKintoneAllUserData()
        {
            int prm_offset = 0;
            List<Sample_KntnUserGetModel.User> users = new List<Sample_KntnUserGetModel.User>();

            while (true)
            {
                //パラメータ作成
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "size", "100" },
                    { "offset" , prm_offset.ToString()}

                };

                //API実行
                string resp = await KintoneAPIUtils.CallGetAPIAsync(KINTONE_API_USER, parameters);
                if (resp == null)
                {
                    return null;
                }
                else if (resp == "")
                {
                    return new List<Sample_KntnUserGetModel.User>();
                }

                //Json変換
                Sample_KntnUserGetModel usersWrk = KintoneAPIUtils.GetObjFromJson<Sample_KntnUserGetModel>(resp);
                if (usersWrk == null)
                {
                    return null;
                }
                users.AddRange(usersWrk.users);

                prm_offset += 100;

                if (usersWrk.users.Count != 100)
                {
                    break;
                }
            }

            return users;
        }

        /// <summary>
        /// ユーザーを追加するメソッド
        /// ※100件毎に処理
        /// </summary>
        /// <param name="data">追加するユーザー情報</param>
        /// <returns>true：処理成功　false：処理失敗　null：API接続時予期せぬエラー発生</returns>
        public async static Task<bool?> PostKintoneUser(Sample_KntnUserUpdateModel data)
        {
            int index = 0;

            while (true)
            {
                if (index >= data.users.Count) break;
                int count = index + 100 > data.users.Count ? data.users.Count - index : 100;
                List <Sample_KntnUserUpdateModel.User> workUser = data.users.GetRange(index, count);

                //パラメータ作成
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "users", workUser}
                };

                //API実行
                string resp = await KintoneAPIUtils.CallPostAPIAsync(KINTONE_API_USER, parameters);
                if (resp == null)
                {
                    return null;
                }
                else if (resp == "")
                {
                    return false;
                }

                index += 100;
            }

            return true;
        }

        /// <summary>
        /// ユーザーを更新するメソッド
        /// ※100件毎に処理
        /// </summary>
        /// <param name="data">更新するユーザー情報</param>
        /// <returns>true：処理成功　false：処理失敗　null：API接続時予期せぬエラー発生</returns>
        public async static Task<bool?> PutKintoneUser(Sample_KntnUserUpdateModel data)
        {
            int index = 0;
            while (true)
            {
                if (index >= data.users.Count) break;
                int count = index + 100 > data.users.Count ? data.users.Count - index : 100;
                List<Sample_KntnUserUpdateModel.User> workUser = data.users.GetRange(index, count);

                //パラメータ作成
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "users", data.users}
                };

                //API実行
                string resp = await KintoneAPIUtils.CallPutAPIAsync(KINTONE_API_USER, parameters);
                if (resp == null)
                {
                    return null;
                }
                else if (resp == "")
                {
                    return false;
                }

                index += 100;
            }

            return true;
        }

        /// <summary>
        /// アプリ情報を取得するメソッド
        /// </summary>
        /// <param name="appId">アプリID</param>
        /// <returns>アプリ情報</returns>
        public async static Task<Sample_KntnAppInfo> GetKintoneAppInfo(string appId)
        {
            //パラメータ作成
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "app", appId }

            };

            //API実行
            string resp = await KintoneAPIUtils.CallGetAPIAsync(KINTONE_API_APPINFO, parameters);
            if (resp == null)
            {
                return null;
            }
            else if (resp == "")
            {
                return new Sample_KntnAppInfo();
            }

            //Json変換
            Sample_KntnAppInfo appIndfo = KintoneAPIUtils.GetObjFromJson<Sample_KntnAppInfo>(resp);
            if (appIndfo == null)
            {
                return null;
            }

            return appIndfo;
        }

        /// <summary>
        /// スペース情報を取得するメソッド
        /// </summary>
        /// <param name="spaceId">スペースID</param>
        /// <returns>スペース情報</returns>
        public async static Task<Sample_KntnSpaceInfoModel> GetKintoneSpaceInfo(string spaceId)
        {
            //パラメータ作成
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "id", spaceId }

            };

            //API実行
            string resp = await KintoneAPIUtils.CallGetAPIAsync(KINTONE_API_SPACEINFO, parameters);
            if (resp == null)
            {
                return null;
            }
            else if (resp == "")
            {
                return new Sample_KntnSpaceInfoModel();
            }

            //Json変換
            Sample_KntnSpaceInfoModel spaceIndfo = KintoneAPIUtils.GetObjFromJson<Sample_KntnSpaceInfoModel>(resp);
            if (spaceIndfo == null)
            {
                return null;
            }

            return spaceIndfo;
        }
    }
}
