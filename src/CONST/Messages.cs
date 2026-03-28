
namespace $safeprojectname$.Const
{
    /// <summary>
    /// 出力メッセージ定数クラス
    /// </summary>
    internal static class Messages
    {
        //--正常系メッセージ

        /// <summary>
        /// ファイル出力完了
        /// </summary>
        public const string INFO_OUTPUT_END = "以下のファイルを出力しました。\r\n\r\n";

        /// <summary>
        /// ファイル取込完了
        /// </summary>
        public const string INFO_INPUT_END = "ファイルを取り込みました。";

        /// <summary>
        /// 処理中断
        /// </summary>
        public const string INFO_STOP = "処理を中断しました。";

        /// <summary>
        /// サブフォーム　キャンセル確認
        /// </summary>
        public const string INFO_CANCEL_CHECK = "変更内容を保存せずにメイン画面に戻ります。よろしいですか？";

        /// <summary>
        /// 既存ファイル削除確認
        /// </summary>
        public const string INFO_OVERWRITE_FILE_CHECK = "以下のファイルは既に存在します。上書きしてよろしいですか？\r\n\r\n";


        //--異常系メッセージ

        /// <summary>
        /// エラーログ確認依頼
        /// </summary>
        public const string CHK_ERR_LOG = "\r\nlogsフォルダのError.logを確認してください。";

        /// <summary>
        /// 実行失敗
        /// </summary>
        public const string ERR_EXEC = "{0}に失敗しました。";

        /// <summary>
        /// RINDBERG　接続失敗
        /// </summary>
        public const string ERR_RIND_ACCESS = "RINDBERGにアクセスできませんでした。\r\nログインIDとパスワードが間違っていないか確認してください。";

        /// <summary>
        /// 取込ファイル　1行目とその他行の列数が不一致
        /// </summary>
        public const string ERR_FILE_CLM_CNT = "以下ファイルのデータ及び列数を正しく取得できません。\r\n";

        /// <summary>
        /// 取込ファイル　不正
        /// </summary>
        public const string ERR_INPUT_FILE = "{0}の内容が間違っています。\r\n正しいファイルを選択してください。";

        /// <summary>
        /// データなし
        /// </summary>
        public const string ERR_NO_DATA = "{0}のデータがありませんでした。";

        /// <summary>
        /// バリデーション　パスワード不正
        /// </summary>
        public const string ERR_PW = "パスワードが間違っています。";

        /// <summary>
        /// バリデーション　未入力
        /// </summary>
        public const string ERR_NOTINPUT = "{0}を入力してください。";

        /// <summary>
        /// バリデーション　未選択
        /// </summary>
        public const string ERR_NOTSELECT = "{0}を選択してください。";

        /// <summary>
        /// バリデーション　不在
        /// </summary>
        public const string ERR_NOTEXIST = "{0}が存在しません。";

        /// <summary>
        /// バリデーション　ファイル使用中
        /// </summary>
        public const string ERR_OPEN_FILE = "{0}を閉じてください。";

        /// <summary>
        /// バリデーション　取込ファイルパス最大長超過
        /// </summary>
        public const string ERR_INPUT_FILEPATH_MAX = "{0}のファイルパスが最大長を超えています。\r\nファイル名を変更するか、ファイルを別のフォルダに移動してください。";

        /// <summary>
        /// バリデーション　出力ファイルパス最大長超過
        /// </summary>
        public const string ERR_OUTPUT_FILEPATH_MAX = "出力ファイルパスが最大長を超えています。\r\n出力フォルダを変更してください。";

        /// <summary>
        /// ドラッグ&ドロップ　複数ファイルドロップ
        /// </summary>
        public const string ERR_FILEDROP_MULT = "複数ファイルが選択されています。";

        /// <summary>
        /// ドラッグ&ドロップ　フォルダ以外をドロップ
        /// </summary>
        public const string ERR_FILEDROP_FOLDER = "フォルダを選択してください。";
    }
}
