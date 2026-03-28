using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// kintoneAPI 接続クラス
    /// </summary>
    internal class KintoneAPIUtils
    {
        /// <summary>
        /// kintone ベーシック認証ID
        /// </summary>
        private static string KINTONE_BASIC_LOGIN_NAME = "microtoolcenter";

        /// <summary>
        /// kintone ベーシック認証PW
        /// </summary>
        private static string KINTONE_BASIC_LOGIN_PASSWORD = "zaq!2wsx";

        /// <summary>
        /// Httpクライアント
        /// </summary>
        private static HttpClient _client;

        /// <summary>
        /// サブドメイン
        /// </summary>
        private static string _subDomain;

        /// <summary>
        /// kintoneAPI実行ユーザーID
        /// </summary>
        private static string _userID;

        /// <summary>
        /// kintoneAPI実行ユーザーPW
        /// </summary>
        private static string _userPW;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static KintoneAPIUtils()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// kintone情報を設定するメソッド
        /// </summary>
        /// <param name="subDomain">サブドメイン</param>
        /// <param name="userID">kintoneAPI実行ユーザーID</param>
        /// <param name="userPW">kintoneAPI実行ユーザーPW</param>
        public static void SetBasicKintoneInfo(string subDomain, string userID, string userPW)
        {
            _subDomain = subDomain;
            _userID = userID;
            _userPW = userPW;
        }

        /// <summary>
        /// HTTPメソッドGETのAPIを呼び出す
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="parameters">パラメータ</param>
        /// <returns>レスポンス</returns>
        public async static Task<string> CallGetAPIAsync(string url, Dictionary<string, string> parameters)
        {
            //TLS設定
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //リクエストメッセージを生成
            string paramStr = new FormUrlEncodedContent(parameters).ReadAsStringAsync().Result;
            string paramUrl = paramStr != "" ? string.Format(url, _subDomain) + "?" + paramStr : string.Format(url, _subDomain);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, paramUrl);

            //ヘッダー付与
            CreatKntReqHeader(ref request);

            return await SendAsyncCall(request);
        }

        /// <summary>
        /// HTTPメソッドPUTのAPIを呼び出す
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="parameters">パラメータ</param>
        /// <returns>レスポンス</returns>
        public async static Task<string> CallPutAPIAsync(string url, Dictionary<string, object> parameters)
        {
            //TLS設定
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //リクエストメッセージを生成
            string paramStr = GetJsonFroObj(parameters);
            if (paramStr == null) return null;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, string.Format(url, _subDomain));
            request.Content = new StringContent(paramStr, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //ヘッダー付与
            CreatKntReqHeader(ref request);

            return await SendAsyncCall(request);
        }

        /// <summary>
        /// HTTPメソッドPOSTのAPIを呼び出す
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="parameters">パラメータ</param>
        /// <returns>レスポンス</returns>
        public async static Task<string> CallPostAPIAsync(string url, Dictionary<string, object> parameters)
        {
            //TLS設定
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //リクエストメッセージを生成
            string paramStr = GetJsonFroObj(parameters);
            if (paramStr == null) return null;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, string.Format(url, _subDomain));
            request.Content = new StringContent(paramStr, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //ヘッダー付与
            CreatKntReqHeader(ref request);

            return await SendAsyncCall(request);
        }

        /// <summary>
        /// API処理
        /// </summary>
        /// <param name="APIType">API種別</param>
        /// <param name="url">URL</param>
        /// <param name="webType">Backlog or kinton　初期値Backlog</param>
        /// <returns>処理成功：レスポンス　処理失敗：null　エラーレスポンス：空文字</returns>
        private async static Task<string> SendAsyncCall(HttpRequestMessage request)
        {
            string exportFileName = string.Format(@"APIlog_{0}.log", DateTime.Now.ToString("yyyyMMdd"));

            try
            {
                var response = await _client.SendAsync(request);
                string respStr = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string resp = "※DEBUG時のみ出力";

#if DEBUG
                    resp = respStr;
#endif

                    LogUtils.ExportLog(exportFileName, CreateAPILog(true, request, resp));
                    return respStr;
                }
                else
                {
                    LogUtils.ExportLog(exportFileName, CreateAPILog(false, request, respStr));
                    return "";
                }
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                return null;
            }
        }

        /// <summary>
        /// リクエストメッセージのヘッダーを付与するメソッド
        /// </summary>
        /// <param name="request">リクエストメッセージ</param>
        /// <returns>リクエストメッセージ</returns>
        private static HttpRequestMessage CreatKntReqHeader(ref HttpRequestMessage request)
        {
            //認証用文字列を作成
            string userAuthenticationString =
                ConvertBase64Encode(_userID + ":" + _userPW);
            string basicAuthenticationString =
                ConvertBase64Encode(KINTONE_BASIC_LOGIN_NAME + ":" + KINTONE_BASIC_LOGIN_PASSWORD);

            //ヘッダー設定
            request.Headers.Add("X-Cybozu-Authorization", userAuthenticationString);
            request.Headers.Add("Authorization", basicAuthenticationString);

            return request;
        }

        /// <summary>
        /// 文字列をBase64エンコードに変換
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string ConvertBase64Encode(string str)
        {
            byte[] strData = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(strData);
        }

        /// <summary>
        /// Jsonデータを指定したデータ型にデシリアライズする処理
        /// </summary>
        /// <typeparam name="T">kintoneデータ型</typeparam>
        /// <param name="jsonString">Json</param>
        /// <returns>変換後データ</returns>
        public static T GetObjFromJson<T>(string jsonString) where T : new()
        {
            var obj = new T();

            try
            {
                obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                return default(T);
            }

            return obj;
        }

        /// <summary>
        /// 指定したデータ型をJonデータにシリアライズする処理
        /// </summary>
        /// <typeparam name="T">kintoneデータ型</typeparam>
        /// <param name="jsonString">Json</param>
        /// <returns>変換後データ</returns>
        public static string GetJsonFroObj<T>(T obj) where T : new()
        {
            string jsonString = "";

            try
            {
                jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                return null;
            }

            return jsonString;
        }

        /// <summary>
        /// APIログ作成メソッド
        /// </summary>
        /// <param name="err">true：通常時　false：エラー時</param>
        /// <param name="request">リクエストメッセージ</param>
        /// <param name="resp">レスポンス情報</param>
        /// <returns>APIログメッセージ</returns>
        private static string CreateAPILog(bool err, HttpRequestMessage request, string resp)
        {
            string logMsg = "";

            if (err)
            {
                logMsg = "｜API Info｜" + Environment.NewLine +
                   "【Header】" + request.Headers + "【URI】" + request.RequestUri + Environment.NewLine + "【Body】" + request.Content + Environment.NewLine + "【Response】" + resp + Environment.NewLine + Environment.NewLine;
            }
            else
            {
                logMsg = "｜API Error｜" + Environment.NewLine +
                     "【Header】" + request.Headers + "【URI】" + request.RequestUri + Environment.NewLine + "【Body】" + request.Content + Environment.NewLine + "【Response】" + resp + Environment.NewLine + Environment.NewLine;
            }

            return logMsg;
        }
    }
}
