using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;   // VS_FIXEDFILEINFO
using System.Runtime.InteropServices; // DLL Import

using Word = System.UInt16;
using DWORD = System.UInt32;
using Longint = System.Int64;
using Integer = System.Int64;

namespace lcump.lib
{
    public class TVerInfoRes
    {

        //type
        //{ バージョン情報に関する一般的な例外クラスと、
        //バージョン情報がないことを示す例外を定義する。 }
        //EVerInfoError   = class(Exception);
        //ENoVerInfoError = class(Exception);
        //eNoFixeVerInfo  = class(Exception);

        // さまざまなバージョン情報を示す列挙型
        //TVerInfoType =
        //(viCompanyName,
        // viFileDescription,
        // viFileVersion,
        // viInternalName,
        // viLegalCopyright,
        // viLegalTrademarks,
        // viOriginalFilename,
        // viProductName,
        // viProductVersion,
        // viComments);

        public enum TVerInfoType : int
        {
            viCompanyName,
            viFileDescription,
            viFileVersion,
            viInternalName,
            viLegalCopyright,
            viLegalTrademarks,
            viOriginalFilename,
            viProductName,
            viProductVersion,
            viComments
        };

        //const
        // あらかじめ定義されたバージョン情報キーを表わす
        // 文字列の定数配列を定義する
        //  VerNameArray: array[viCompanyName..viComments] of String[20] =
        //  ('CompanyName',
        //   'FileDescription',
        //   'FileVersion',
        //   'InternalName',
        //   'LegalCopyright',
        //   'LegalTrademarks',
        //   'OriginalFilename',
        //   'ProductName',
        //   'ProductVersion',
        //   'Comments');

        readonly string[] VerNameArray =
        {
            "CompanyName",
            "FileDescription",
            "FileVersion",
            "InternalName",
            "LegalCopyright",
            "LegalTrademarks",
            "OriginalFilename",
            "ProductName",
            "ProductVersion",
            "Comments"
        };

        //private
        //  Handle            : DWord;
        //  Size              : Integer;
        //  RezBuffer         : String;
        //  TransTable        : PLongint;
        //  FixedFileInfoBuf  : PVSFixedFileInfo;
        //  FFileFlags        : TStringList;
        //  FFileName         : String;

        int Handle;
        int Size;
        IntPtr RezBuffer;
        Longint TransTable;
        FileVersionInfo FixedFileInfoBuf;
        List<string>  FFileFlags;
        string FFileName;

        IntPtr buffer;
        int bufferLength;

        FileVersionInfo vinf;

        //const
        //関数VerQueryValue()で使う文字列
        //  SFInfo                = '\StringFileInfo\';
        //  VerTranslation: PChar = '\VarFileInfo\Translation';
        //  FormatStr             = '%s%.4x%.4x\%s%s';

        const string SFInfo = "\\StringFileInfo\\";
        const string VerTranslation = "\\VarFileInfo\\Translation";
        const string FormatStr = "%s%.4x%.4x\\%s%s";


        //----------------
        //----------------
        //constructor TVerInfoRes.Create(AFileName: String);
        //begin
        //  FFileName := aFileName;
        //  FFileFlags := TStringList.Create;
        //
        //  ファイルのバージョン情報を取得する
        //  FillFileVersionInfo;
        //
        //  固定ファイル情報を取得する
        //  FillFixedFileInfoBuf;
        //
        //  ファイルマスクの値を取得する
        //  FillFileMaskInfo;
        //end;

        public TVerInfoRes(string aFileName)
        {
            FFileName = aFileName;
            FFileFlags = new List<string>();

            // ファイルのバージョン情報を取得する
            FillFileVersionInfo();

            // 固定ファイル情報を取得する
            FillFixedFileInfoBuf();

            // ファイルマスクの値を取得する
            FillFileMaskInfo();
        }

        //----------------
        //----------------
        //destructor TVerInfoRes.Destroy;
        //begin
        //  FFileFlags.Free;
        //end;

        ~TVerInfoRes()
        {
            //
        }

        //procedure TVerInfoRes.FillFileVersionInfo;
        //var
        //  SBSize:   UInt;
        //begin
        //  バージョン情報のサイズを取得する
        //  Size := GetFileVersionInfoSize(PChar(FFileName), Handle);
        //
        //  if Size <= 0 then         { サイズがゼロ以下なら例外を生成する }
        //  raise ENoVerInfoError.Create('No Version Info Available.');
        //
        //  取得した長さをバッファにセットする
        //  SetLength(RezBuffer, Size);
        //
        //  バッファにバージョン情報を入れる。エラーが発生したら例外を生成する
        //  if not GetFileVersionInfo(PChar(FFileName), Handle, Size, PChar(RezBuffer)) then
        //      raise EVerInfoError.Create('Cannot obtain version info.');
        //
        //  変換テーブルの値を取得する。エラーが発生したら例外を生成する
        //  if not VerQueryValue(PChar(RezBuffer), 
        //                              VerTranslation,  pointer(TransTable), SBSize) then
        //          raise EVerInfoError.Create('No language info.');
        //end;

        [DllImport("Version.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetFileVersionInfoSize(
             [In] string lptstrFilename,
             [Out, Optional] out int lpdwHandle);

        [DllImport("Version.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetFileVersionInfoSize(
            [In] string lptstrFilename,
            IntPtr lpdwHandle);

        [DllImport("Version.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetFileVersionInfo(
            [In] string lptstrFilename,
            int dwHandle,
            [In] int dwLen,
            [Out] IntPtr lpData);

        [DllImport("Version.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool VerQueryValue(
            [In] IntPtr pBlock,
            [In] string lpSubBlock,
            [Out] out IntPtr lplpBuffer,
            [Out] out int puLen);


        void FillFileVersionInfo()
        {
            vinf = FileVersionInfo.GetVersionInfo(FFileName);

            //  バージョン情報のサイズを取得する
            //Size = GetFileVersionInfoSize( FFileName, out Handle);

            //if (Size<=0)     //{ サイズがゼロ以下なら例外を生成する }
            //{
            //    throw new AccessViolationException("No Version Info Available.");
            //}

            //  取得した長さをバッファにセットする
            //RezBuffer = Marshal.AllocCoTaskMem(Size);

            //  バッファにバージョン情報を入れる。エラーが発生したら例外を生成する
            //if ( !(GetFileVersionInfo(FFileName, Handle, Size, RezBuffer) ) )
            //{
            //    throw new AccessViolationException("Cannot obtain version info.");
            //}

            //  変換テーブルの値を取得する。エラーが発生したら例外を生成する
            //if( !(VerQueryValue(RezBuffer, VerTranslation, out buffer, out bufferLength) ) )
            //{
            //    throw new AccessViolationException("No language info.");
            //}
        }


        //----------------
        //----------------
        //procedure TVerInfoRes.FillFixedFileInfoBuf;
        //var
        //  Size: Uint;
        //begin
        //  if VerQueryValue(PChar(RezBuffer), '\', Pointer(FixedFileInfoBuf), Size) then begin
        //      if Size<SizeOf(TVSFixedFileInfo) then
        //          raise eNoFixeVerInfo.Create('No fixed file info');
        //  end
        //  else
        //    raise eNoFixeVerInfo.Create('No fixed file info')
        //end;

        void FillFixedFileInfoBuf()
        {
            if (VerQueryValue(RezBuffer, "\\", out buffer, out bufferLength))
            {
                if (Size < Marshal.SizeOf(buffer))
                {
                    throw new AccessViolationException("No fixed file info");
                }
            }
            else
            {
                throw new AccessViolationException("No fixed file info");
            }
        }


        //----------------
        //----------------
        //procedure TVerInfoRes.FillFileMaskInfo;
        //begin
        //  with FixedFileInfoBuf^ do begin
        //if (dwFileFlagsMask and dwFileFlags and VS_FF_PRERELEASE) <> 0then
        //  FFileFlags.Add('Pre-release');
        //if (dwFileFlagsMask and dwFileFlags and VS_FF_PRIVATEBUILD) <> 0 then
        //  FFileFlags.Add('Private build');
        //if (dwFileFlagsMask and dwFileFlags and VS_FF_SPECIALBUILD) <> 0 then
        //  FFileFlags.Add('Special build');
        //if (dwFileFlagsMask and dwFileFlags and VS_FF_DEBUG) <> 0 then
        //  FFileFlags.Add('Debug');
        //    end;
        //end;

        void FillFileMaskInfo()
        {
            if (vinf.IsPreRelease)
            {
                FFileFlags.Add("Pre-release");
            }

            if (vinf.IsPrivateBuild )
            {
                FFileFlags.Add("Private build");
            }

            if (vinf.IsSpecialBuild)
            {
                FFileFlags.Add("Special build");
            }

            if (vinf.IsDebug)
            {
                FFileFlags.Add("Debug");
            }
        }

        //----------------
        //----------------
        //function TVerInfoRes.GetPreDefKeyString(AVerKind: TVerInfoType): String;
        //var
        //  P: PChar;
        //  S: UInt;
        //begin
        //  Result := Format(FormatStr, [SfInfo, LoWord(TransTable^),HiWord(TransTable^),
        //    VerNameArray[aVerKind], #0]);
        // 特定のバージョン情報を取得する。エラーが発生した場合は空文字列を返す
        //  if VerQueryValue(PChar(RezBuffer), @Result[1], Pointer(P), S) then
        //    Result := StrPas(P)
        //  else
        //    Result := '';
        //end;

        public string GetPreDefKeyString(TVerInfoType AVerKind)
        {
            string Result = "";

            //  P: PChar;
            //  S: UInt;
            //begin
            //  Result := Format(FormatStr, [SfInfo, LoWord(TransTable^),HiWord(TransTable^),
            //    VerNameArray[aVerKind], #0]);
            // 特定のバージョン情報を取得する。エラーが発生した場合は空文字列を返す
            //  if VerQueryValue(PChar(RezBuffer), @Result[1], Pointer(P), S) then
            //    Result := StrPas(P)
            //  else
            //    Result := '';

            return (Result);
        }




    }
}
