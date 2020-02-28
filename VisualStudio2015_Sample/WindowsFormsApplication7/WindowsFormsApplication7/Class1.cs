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

namespace WindowsFormsApplication7
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

        public readonly string[] VerNameArray =
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
        List<string> FFileFlags;
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
        const string FormatStr = "{0}{1,4:x4}{2,4:x4}\\{3}{4}";


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
            //FillFixedFileInfoBuf();

            // ファイルマスクの値を取得する
            //FillFileMaskInfo();
        }

        //----------------
        //----------------
        //destructor TVerInfoRes.Destroy;
        //begin
        //  FFileFlags.Free;
        //end;

        ~TVerInfoRes()
        {
            if ((int)buffer != 0)
            {
                Marshal.FreeCoTaskMem(buffer);
            }
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



struct VS_FIXEDFILEINFO
{
    DWORD dwSignature;
    DWORD dwStrucVersion;
    DWORD dwFileVersionMS;
    DWORD dwFileVersionLS;
    DWORD dwProductVersionMS;
    DWORD dwProductVersionLS;
    DWORD dwFileFlagsMask;
    DWORD dwFileFlags;
    DWORD dwFileOS;
    DWORD dwFileType;
    DWORD dwFileSubtype;
    DWORD dwFileDateMS;
    DWORD dwFileDateLS;
}


        byte[] b;

        public void FillFileVersionInfo()
        {
            vinf = FileVersionInfo.GetVersionInfo(FFileName);

            //  バージョン情報のサイズを取得する
            Size = GetFileVersionInfoSize( FFileName, out Handle);

            if (Size<=0)     //{ サイズがゼロ以下なら例外を生成する }
            {
                throw new AccessViolationException("No Version Info Available.");
            }

            //  取得した長さをバッファにセットする
            RezBuffer = Marshal.AllocCoTaskMem(Size);

            //  バッファにバージョン情報を入れる。エラーが発生したら例外を生成する
            if ( !(GetFileVersionInfo(FFileName, Handle, Size, RezBuffer) ) )
            {
                throw new AccessViolationException("Cannot obtain version info.");
            }

            //  変換テーブルの値を取得する。エラーが発生したら例外を生成する
            if( !(VerQueryValue(RezBuffer, VerTranslation, out buffer, out bufferLength) ) )
            {
                throw new AccessViolationException("No language info.");
            }

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

        public void FillFixedFileInfoBuf()
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

            if (vinf.IsPrivateBuild)
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

        public byte[] GetPreDefKeyString(TVerInfoType AVerKind)
        {
            byte[] Result = null;
            string s0, s1;

/*
                        var localeIds = new int[bufferLength / 4];
                        Marshal.Copy(buffer, localeIds, 0, localeIds.Length);

                        int i0 = buffer.;

                        foreach (var localeId in localeIds)
                        {
                            var hiword = (int)(((uint)localeId & 0xFFFF0000u) >> 16);
                            var loword = localeId & 0xFFFF;
                            var s00 = $@"\StringFileInfo\{loword:x4}{hiword:x4}\ProductName";


                            if (VerQueryValue(RezBuffer, s00, out buffer, out bufferLength))
                            {
                                Result = new byte[bufferLength];
                                var description = Marshal.PtrToStringAuto(buffer, bufferLength);
                                s1 = Marshal.PtrToStringAuto(buffer, bufferLength);
                                //Marshal.Copy(buffer, b, 0, bufferLength);
                            }
                            else
                            {
                                Result = null;
                            }
                        }*/

/*

            var hiword = (int)(((uint)buffer & 0xFFFF0000u) >> 16);
            var loword = (int)buffer & 0xFFFF;
            var s3 = $@"\StringFileInfo\{loword:x4}{hiword:x4}\ProductName";

            int i0 = (int)@buffer;
            s0 = string.Format(FormatStr, SFInfo, (i0&0xffff), (i0>>16), VerNameArray[(int)AVerKind],  null );
            if (VerQueryValue(RezBuffer, s0, out buffer, out bufferLength))
            {
                var description = Marshal.PtrToStringAuto(buffer, bufferLength);
                s1 = Marshal.PtrToStringAuto(buffer, bufferLength);
            }
            else
            {
                Result = null;
            }
*/

            /*
                //  P: PChar;
                //  S: UInt;

                //s0 = string.Format(FormatStr, SFInfo, (i0&0xffff), (i0>>16), 
                //                                                            VerNameArray[(int)AVerKind],  null );

                // 特定のバージョン情報を取得する。エラーが発生した場合は空文字列を返す
                if ( VerQueryValue(RezBuffer, s0, out buffer, out bufferLength) )
            {
                Result = new byte[bufferLength];
                Marshal.Copy(buffer, b, 0, bufferLength);
            }
            else
            {
                Result = null;
            }
            */

            return (Result);
        }

        public byte[] getinfo()
        {
            VS_FIXEDFILEINFO a = new VS_FIXEDFILEINFO();
            b = new byte[bufferLength];

            Marshal.Copy(buffer, b, 0, bufferLength);

            return (b);
        }

        //----------------
        //----------------
        //function VersionString(Ms, Ls: Longint): String;
        //begin
        //  Result := Format('%d.%d.%d.%d', [HIWORD(Ms), LOWORD(Ms),
        //  HIWORD(Ls), LOWORD(Ls)]);
        //end;

        public string VersionString(Longint Ms, Longint Ls)
        {
            string Result = string.Format("{0:d}.{1:d}.{2:d}.{3:d}",
                                                (Ms >> 16), (Ms & 0xffff), (Ls >> 16), (Ls & 0xffff));
            return (Result);
        }


        //----------------
        //----------------
        //function TVerInfoRes.GetFileVersion: String;
        //begin
        //  with FixedFileInfoBuf^ do
        //      Result := VersionString(dwFileVersionMS, dwFileVersionLS);
        //end;

        string GetFileVersion()
        {
            string Result = VersionString(vinf.FileMajorPart, vinf.FileMinorPart);
            return (Result);
        }

        //----------------
        //----------------
        //function TVerInfoRes.GetProductVersion: String;
        //begin
        //  with FixedFileInfoBuf^ do
        //      Result := VersionString(dwProductVersionMS, dwProductVersionLS);
        //end;

        string GetProductVersion()
        {
            string Result = VersionString(vinf.ProductMajorPart, vinf.ProductMinorPart);
            return (Result);
        }


        //----------------
        //----------------
        //function TVerInfoRes.GetFileOS: String;
        //        begin
        //          with FixedFileInfoBuf^ do
        //    case dwFileOS of
        //      VOS_UNKNOWN:  // VOS__BASEと同じ
        //        Result := 'Unknown';
        //      VOS_DOS:
        //        Result := 'Designed for MS-DOS';
        //      VOS_OS216:
        //        Result := 'Designed for 16-bit OS/2';
        //      VOS_OS232:
        //        Result := 'Designed for 32-bit OS/2';
        //      VOS_NT:
        //        Result := 'Designed for Windows NT';

        //      VOS__WINDOWS16:
        //        Result := 'Designed for 16-bit Windows';
        //      VOS__PM16:
        //        Result := 'Designed for 16-bit PM';
        //      VOS__PM32:
        //        Result := 'Designed for 32-bit PM';
        //      VOS__WINDOWS32:
        //        Result := 'Designed for 32-bit Windows';

        //      VOS_DOS_WINDOWS16:
        //        Result := 'Designed for 16-bit Windows, running on MS-DOS';
        //      VOS_DOS_WINDOWS32:
        //        Result := 'Designed for Win32 API, running on MS-DOS';
        //      VOS_OS216_PM16:
        //        Result := 'Designed for 16-bit PM, running on 16-bit OS/2';
        //      VOS_OS232_PM32:
        //        Result := 'Designed for 32-bit PM, running on 32-bit OS/2';
        //      VOS_NT_WINDOWS32:
        //        Result := 'Designed for Win32 API, running on Windows/NT';
        //    else
        //      Result := 'Unknown';
        //    end;
        //end;

        string GetFileOS()
        {
            string Result = "";

            //          with FixedFileInfoBuf^ do
            //    case dwFileOS of
            //      VOS_UNKNOWN:  // VOS__BASEと同じ
            //        Result := 'Unknown';
            //      VOS_DOS:
            //        Result := 'Designed for MS-DOS';
            //      VOS_OS216:
            //        Result := 'Designed for 16-bit OS/2';
            //      VOS_OS232:
            //        Result := 'Designed for 32-bit OS/2';
            //      VOS_NT:
            //        Result := 'Designed for Windows NT';

            //      VOS__WINDOWS16:
            //        Result := 'Designed for 16-bit Windows';
            //      VOS__PM16:
            //        Result := 'Designed for 16-bit PM';
            //      VOS__PM32:
            //        Result := 'Designed for 32-bit PM';
            //      VOS__WINDOWS32:
            //        Result := 'Designed for 32-bit Windows';

            //      VOS_DOS_WINDOWS16:
            //        Result := 'Designed for 16-bit Windows, running on MS-DOS';
            //      VOS_DOS_WINDOWS32:
            //        Result := 'Designed for Win32 API, running on MS-DOS';
            //      VOS_OS216_PM16:
            //        Result := 'Designed for 16-bit PM, running on 16-bit OS/2';
            //      VOS_OS232_PM32:
            //        Result := 'Designed for 32-bit PM, running on 32-bit OS/2';
            //      VOS_NT_WINDOWS32:
            //        Result := 'Designed for Win32 API, running on Windows/NT';
            //    else
            //      Result := 'Unknown';
            //    end;

            return (Result);
        }

    }
}
