/*
C#でINIファイルを読み書きするクラス

INIファイルの読み書きをスマートに記述出来るように
Win32APIのGetPrivateProfileStringとWritePrivateProfileStringをラップした

ホームページ：
http://anis774.net/codevault/inifile.html

使用例：
using System;
 
class Program {
    static void Main(string[] args) {
        //ファイルを指定して初期化
        IniFile ini = new IniFile("./test.ini");
 
        //書き込み
        ini["section", "key"] = "value";
 
        //読み込み
        string value = ini["section", "key"];
 
        Console.WriteLine(value);
 
        //この様に書き込まれる。
        //[section]
        //key=value
    }
}
*/

using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using System;

namespace DBtest
{
    /// <summary>
    /// INIファイルを読み書きするクラス
    /// </summary>
    public class IniFile
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedstring,
            int nSize,
            string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpstring,
            string lpFileName);


        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(
            string lpAppName,
            byte[] lpszReturnBuffer,
            int nSize, string
            lpFileName);

        string filePath;

        /// <summary>
        /// ファイル名を指定して初期化します。
        /// ファイルが存在しない場合は初回書き込み時に作成されます。
        /// </summary>
        public IniFile(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// sectionとkeyからiniファイルの設定値を取得、設定します。 
        /// </summary>
        /// <returns>指定したsectionとkeyの組合せが無い場合は""が返ります。</returns>
        public string this[string section, string key]
        {
            set
            {
                WritePrivateProfileString(section, key, value, filePath);
            }
            get
            {
                StringBuilder sb = new StringBuilder(256);
                GetPrivateProfileString(section, key, string.Empty, sb, sb.Capacity, filePath);
                return sb.ToString();
            }
        }

        /// <summary>
        /// sectionとkeyからiniファイルの設定値を取得します。
        /// 指定したsectionとkeyの組合せが無い場合はdefaultvalueで指定した値が返ります。
        /// </summary>
        /// <returns>
        /// 指定したsectionとkeyの組合せが無い場合はdefaultvalueで指定した値が返ります。
        /// </returns>
        public string GetValue(string section, string key, string defaultvalue)
        {
            StringBuilder sb = new StringBuilder(256);
            GetPrivateProfileString(section, key, defaultvalue, sb, sb.Capacity, filePath);
            return sb.ToString();
        }

        //============
        // キー名取得メソッド ＜文字コード指定＞
        //
        // 指定のiniファイルの、指定のセクション名から、キー名の一覧を取得
        // します。なお、本メソッドは、iniファイルの文字コードを指定します。
        //
        // 第1引数: iniファイルのファイル名
        // 第2引数: セクション名
        // 第3引数: iniﾌｧｲﾙのｴﾝｺｰﾄﾞを入力指定(ｼﾌﾄJISｺｰﾄﾞ時は、"shift_jis")
        // 戻り値: 取得したキー名の一覧
        //
        // ｴﾝｺｰﾃﾞｨﾝｸﾞを示すｺｰﾄﾞﾍﾟｰｼﾞ名(第2引数指定値)
        //   ｼﾌﾄJIS: "shift_jis"
        //   JIS: "iso-2022-jp"
        //   日本語EUC: "euc-jp"
        //   Unicode (UTF-8): "utf-8"
        public List<string> GetKeys(
            string category,
            string BeforeEncod)
        {

            byte[] buffer = new byte[2048];


            // Windows API でキー名を取得
            GetPrivateProfileSection(category, buffer, 2048, this.filePath);


            // 取得したデーターをバイト型配列からstring型に変換
            // （ﾊﾞｲﾄ型配列 ---> ﾕﾆｺｰﾄﾞstring 変換）
            string DataWork;

            if (ChangeBinaryToUnicodeStr(buffer, BeforeEncod, out DataWork) != 0)
            {
                return null;
            }


            // string型オブジェクト内に並べられた各値をstring型配列に変換
            String[] tmp = DataWork.Trim('\0').Split('\0');


            List<string> result = new List<string>();


            // string型配列をリストに変換
            foreach (string entry in tmp)
            {
                result.Add(entry.Substring(0, entry.IndexOf("=")));
            }

            return result;
        }

                //============
        // 指定ｺｰﾄﾞﾊﾞｲﾄ型配列 ---> ﾕﾆｺｰﾄﾞstring 変換ﾒｿｯﾄﾞ
        //
        // 内容: 指定ｺｰﾄﾞ(例: ｼﾌﾄJISｺｰﾄﾞ)のﾊﾞｲﾄ型配列をﾕﾆｺｰﾄﾞの文字列に変換する。
        //
        // 第1引数: 変換前の文字列を入力指定(byte型配列のｼﾌﾄJISｺｰﾄﾞの文字列)
        // 第2引数: 変換前のｴﾝｺｰﾄﾞを入力指定(ｼﾌﾄJISｺｰﾄﾞ時は、"shift_jis")
        // 第3引数: 変換後の文字列を出力(string型のﾕﾆｺｰﾄﾞの文字列)
        //
        // 戻り値: ｴﾗｰ情報(0から1: 成功、2以上: 失敗)
        // _______________(1: 警告(ﾌｫｰﾙﾊﾞｯｸ発生))
        //
        // ｴﾝｺｰﾃﾞｨﾝｸﾞを示すｺｰﾄﾞﾍﾟｰｼﾞ名(第2引数指定値)
        //   ｼﾌﾄJIS: "shift_jis"
        //   JIS: "iso-2022-jp"
        //   日本語EUC: "euc-jp"
        //   Unicode (UTF-8): "utf-8"
        public int ChangeBinaryToUnicodeStr(byte[] BeforeBytes, string BeforeEncod, out string UnicodeText)
        {

            // 初期化
            UnicodeText = "";
            int ErrorInfo = 0; // ｴﾗｰ情報


            // 入力がnull時のｴﾗｰ処理
            if (BeforeBytes == null || BeforeEncod == null) return 2;


            // 文字ｺｰﾄﾞを示すｴﾝｺｰﾄﾞを生成
            System.Text.Encoding AfterEncodObj = System.Text.Encoding.Unicode; // 変換後ｴﾝｺｰﾄﾞ
            System.Text.Encoding BeforeEncodObj = System.Text.Encoding.GetEncoding(BeforeEncod); // 変換前ｴﾝｺｰﾄﾞ


            // 指定ｺｰﾄﾞをﾕﾆｺｰﾄﾞに変換
            byte[] AfterBytes = null;
            try
            {
                AfterBytes = System.Text.Encoding.Convert(BeforeEncodObj, AfterEncodObj, BeforeBytes);
            }
            catch (DecoderFallbackException)
            {
                // ﾌｫｰﾙﾊﾞｯｸが発生
                ErrorInfo = 1;
            }
            catch (EncoderFallbackException)
            {
                // ﾌｫｰﾙﾊﾞｯｸが発生
                ErrorInfo = 1;
            }
            catch (ArgumentNullException)
            {
                // 入出力文字列格納用ｵﾌﾞｼﾞｪｸﾄ または encoding が null を参照し、失敗
                ErrorInfo = 2;
            }


            // ﾊﾞｲﾄ型配列のﾕﾆｺｰﾄﾞ文字列をstring型に設定
            char[] AfterChars = new char[AfterEncodObj.GetCharCount(AfterBytes, 0, AfterBytes.Length)];
            AfterEncodObj.GetChars(AfterBytes, 0, AfterBytes.Length, AfterChars, 0);
            UnicodeText = new string(AfterChars);


            return ErrorInfo;
        }


    }

}