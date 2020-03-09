using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    public static class FileUtility
    {
        [DllImport("mpr.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.U4)]
        static extern int
WNetGetUniversalName(
    string lpLocalPath,                                 // ネットワーク資源のパス 
    [MarshalAs(UnmanagedType.U4)] int dwInfoLevel,      // 情報のレベル
    IntPtr lpBuffer,                                    // 名前バッファ
    [MarshalAs(UnmanagedType.U4)] ref int lpBufferSize  // バッファのサイズ
);

        /*
         * dwInfoLevelに指定するパラメータ
         *  lpBuffer パラメータが指すバッファで受け取る構造体の種類を次のいずれかで指定
         */
        const int UNIVERSAL_NAME_INFO_LEVEL = 0x00000001;
        const int REMOTE_NAME_INFO_LEVEL = 0x00000002; //こちらは、テストしていない

        /*
         * lpBufferで受け取る構造体
         */
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct UNIVERSAL_NAME_INFO
        {
            public string lpUniversalName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct _REMOTE_NAME_INFO
        {
            string lpUniversalName;
            string lpConnectionName;
            string lpRemainingPath;
        }

        /* エラーコード一覧
         * WNetGetUniversalName固有のエラーコード
         *   http://msdn.microsoft.com/ja-jp/library/cc447067.aspx
         * System Error Codes (0-499)
         *   http://msdn.microsoft.com/en-us/library/windows/desktop/ms681382(v=vs.85).aspx
         */
        const int NO_ERROR = 0;
        const int ERROR_NOT_SUPPORTED = 50;
        const int ERROR_MORE_DATA = 234;
        const int ERROR_BAD_DEVICE = 1200;
        const int ERROR_CONNECTION_UNAVAIL = 1201;
        const int ERROR_NO_NET_OR_BAD_PATH = 1203;
        const int ERROR_EXTENDED_ERROR = 1208;
        const int ERROR_NO_NETWORK = 1222;
        const int ERROR_NOT_CONNECTED = 2250;

        /*
         * UNC変換ロジック本体
         */
        static string GetUniversalName(string path_src)
        {
            string unc_path_dest = path_src; //解決できないエラーが発生した場合は、入力されたパスをそのまま戻す
            int size = 1;

            /*
             * 前処理
             *   意図的に、ERROR_MORE_DATAを発生させて、必要なバッファ・サイズ(size)を取得する。
             */
            //1バイトならば、確実にERROR_MORE_DATAが発生するだろうという期待。
            IntPtr lp_dummy = Marshal.AllocCoTaskMem(size);

            //サイズ取得をトライ
            int apiRetVal = WNetGetUniversalName(path_src, UNIVERSAL_NAME_INFO_LEVEL, lp_dummy, ref size);

            //ダミーを解放
            Marshal.FreeCoTaskMem(lp_dummy);

            /*
             * UNC変換処理
             */
            switch (apiRetVal)
            {
                case ERROR_MORE_DATA:
                    //受け取ったバッファ・サイズ(size)で再度メモリ確保
                    IntPtr lpBufUniversalNameInfo = Marshal.AllocCoTaskMem(size);

                    //UNCパスへの変換を実施する。
                    apiRetVal = WNetGetUniversalName(path_src, UNIVERSAL_NAME_INFO_LEVEL, lpBufUniversalNameInfo, ref size);

                    //UNIVERSAL_NAME_INFOを取り出す。
                    UNIVERSAL_NAME_INFO a = (UNIVERSAL_NAME_INFO)Marshal.PtrToStructure(lpBufUniversalNameInfo, typeof(UNIVERSAL_NAME_INFO));

                    //バッファを解放する
                    Marshal.FreeCoTaskMem(lpBufUniversalNameInfo);

                    if (apiRetVal == NO_ERROR)
                    {
                        //UNCに変換したパスを返す
                        unc_path_dest = a.lpUniversalName;
                    }
                    else
                    {
                        //MessageBox.Show(path_src +"ErrorCode:" + apiRetVal.ToString());
                    }
                    break;

                case ERROR_BAD_DEVICE: //すでにUNC名(\\servername\test)
                case ERROR_NOT_CONNECTED: //ローカル・ドライブのパス(C:\test)
                                          //MessageBox.Show(path_src +"\nErrorCode:" + apiRetVal.ToString());
                    break;
                default:
                    //MessageBox.Show(path_src + "\nErrorCode:" + apiRetVal.ToString());
                    break;

            }

            return unc_path_dest;
        }


        // ネットワークドライブ対応
        public static string ExpandUNCFileName(string driveLetter)
        {
            //string driveLetter = "Z:";
            //StringBuilder nRemotePath = new StringBuilder();
            //int cbRemoteName = 1024;
            //WNetGetConnection(driveLetter, nRemotePath, ref cbRemoteName);
            //return nRemotePath.ToString();

            string Result = driveLetter;

            if (driveLetter == null || driveLetter == "")
            {
                return (Result);
            }

            Result = Path.GetFullPath(driveLetter);

            if (Result == "")
            {
                return (Result);
            }

            Uri ChkUNC = new Uri(Result);

            if (ChkUNC.IsUnc)
            {
                return (Result);
            }

            string sRoot = Path.GetPathRoot(Result);

            if (sRoot == null || sRoot == "")
            {
                return (Result);
            }

            DriveInfo drvinf = new DriveInfo(sRoot);
            if (drvinf.DriveType == DriveType.Network)
            {
                Result = GetUniversalName(Result);
            }

            return (Result);
        }


        /// <summary>
        /// 指定されたパス文字列から拡張子を削除して返します
        /// </summary>
        public static string GetPathWithoutExtension(string path)
        {
            var extension = Path.GetExtension(path);
            if (string.IsNullOrEmpty(extension))
            {
                return path;
            }
            return path.Replace(extension, string.Empty);
        }

        /// <summary>
        /// 拡張子取得
        /// </summary>
        public static string GetExtension(string path)
        {
            return System.IO.Path.GetExtension(path);
        }
    }
}
