/*
C#��INI�t�@�C����ǂݏ�������N���X

INI�t�@�C���̓ǂݏ������X�}�[�g�ɋL�q�o����悤��
Win32API��GetPrivateProfileString��WritePrivateProfileString�����b�v����

�z�[���y�[�W�F
http://anis774.net/codevault/inifile.html

�g�p��F
using System;
 
class Program {
    static void Main(string[] args) {
        //�t�@�C�����w�肵�ď�����
        IniFile ini = new IniFile("./test.ini");
 
        //��������
        ini["section", "key"] = "value";
 
        //�ǂݍ���
        string value = ini["section", "key"];
 
        Console.WriteLine(value);
 
        //���̗l�ɏ������܂��B
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
    /// INI�t�@�C����ǂݏ�������N���X
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
        /// �t�@�C�������w�肵�ď��������܂��B
        /// �t�@�C�������݂��Ȃ��ꍇ�͏��񏑂����ݎ��ɍ쐬����܂��B
        /// </summary>
        public IniFile(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// section��key����ini�t�@�C���̐ݒ�l���擾�A�ݒ肵�܂��B 
        /// </summary>
        /// <returns>�w�肵��section��key�̑g�����������ꍇ��""���Ԃ�܂��B</returns>
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
        /// section��key����ini�t�@�C���̐ݒ�l���擾���܂��B
        /// �w�肵��section��key�̑g�����������ꍇ��defaultvalue�Ŏw�肵���l���Ԃ�܂��B
        /// </summary>
        /// <returns>
        /// �w�肵��section��key�̑g�����������ꍇ��defaultvalue�Ŏw�肵���l���Ԃ�܂��B
        /// </returns>
        public string GetValue(string section, string key, string defaultvalue)
        {
            StringBuilder sb = new StringBuilder(256);
            GetPrivateProfileString(section, key, defaultvalue, sb, sb.Capacity, filePath);
            return sb.ToString();
        }

        //============
        // �L�[���擾���\�b�h �������R�[�h�w�聄
        //
        // �w���ini�t�@�C���́A�w��̃Z�N�V����������A�L�[���̈ꗗ���擾
        // ���܂��B�Ȃ��A�{���\�b�h�́Aini�t�@�C���̕����R�[�h���w�肵�܂��B
        //
        // ��1����: ini�t�@�C���̃t�@�C����
        // ��2����: �Z�N�V������
        // ��3����: ini̧�ق̴ݺ��ނ���͎w��(���JIS���ގ��́A"shift_jis")
        // �߂�l: �擾�����L�[���̈ꗗ
        //
        // �ݺ��ިݸނ����������߰�ޖ�(��2�����w��l)
        //   ���JIS: "shift_jis"
        //   JIS: "iso-2022-jp"
        //   ���{��EUC: "euc-jp"
        //   Unicode (UTF-8): "utf-8"
        public List<string> GetKeys(
            string category,
            string BeforeEncod)
        {

            byte[] buffer = new byte[2048];


            // Windows API �ŃL�[�����擾
            GetPrivateProfileSection(category, buffer, 2048, this.filePath);


            // �擾�����f�[�^�[���o�C�g�^�z�񂩂�string�^�ɕϊ�
            // �i�޲Č^�z�� ---> �ƺ���string �ϊ��j
            string DataWork;

            if (ChangeBinaryToUnicodeStr(buffer, BeforeEncod, out DataWork) != 0)
            {
                return null;
            }


            // string�^�I�u�W�F�N�g���ɕ��ׂ�ꂽ�e�l��string�^�z��ɕϊ�
            String[] tmp = DataWork.Trim('\0').Split('\0');


            List<string> result = new List<string>();


            // string�^�z������X�g�ɕϊ�
            foreach (string entry in tmp)
            {
                result.Add(entry.Substring(0, entry.IndexOf("=")));
            }

            return result;
        }

                //============
        // �w�躰���޲Č^�z�� ---> �ƺ���string �ϊ�ҿ���
        //
        // ���e: �w�躰��(��: ���JIS����)���޲Č^�z����ƺ��ނ̕�����ɕϊ�����B
        //
        // ��1����: �ϊ��O�̕��������͎w��(byte�^�z��̼��JIS���ނ̕�����)
        // ��2����: �ϊ��O�̴ݺ��ނ���͎w��(���JIS���ގ��́A"shift_jis")
        // ��3����: �ϊ���̕�������o��(string�^���ƺ��ނ̕�����)
        //
        // �߂�l: �װ���(0����1: �����A2�ȏ�: ���s)
        // _______________(1: �x��(̫���ޯ�����))
        //
        // �ݺ��ިݸނ����������߰�ޖ�(��2�����w��l)
        //   ���JIS: "shift_jis"
        //   JIS: "iso-2022-jp"
        //   ���{��EUC: "euc-jp"
        //   Unicode (UTF-8): "utf-8"
        public int ChangeBinaryToUnicodeStr(byte[] BeforeBytes, string BeforeEncod, out string UnicodeText)
        {

            // ������
            UnicodeText = "";
            int ErrorInfo = 0; // �װ���


            // ���͂�null���̴װ����
            if (BeforeBytes == null || BeforeEncod == null) return 2;


            // �������ނ������ݺ��ނ𐶐�
            System.Text.Encoding AfterEncodObj = System.Text.Encoding.Unicode; // �ϊ���ݺ���
            System.Text.Encoding BeforeEncodObj = System.Text.Encoding.GetEncoding(BeforeEncod); // �ϊ��O�ݺ���


            // �w�躰�ނ��ƺ��ނɕϊ�
            byte[] AfterBytes = null;
            try
            {
                AfterBytes = System.Text.Encoding.Convert(BeforeEncodObj, AfterEncodObj, BeforeBytes);
            }
            catch (DecoderFallbackException)
            {
                // ̫���ޯ�������
                ErrorInfo = 1;
            }
            catch (EncoderFallbackException)
            {
                // ̫���ޯ�������
                ErrorInfo = 1;
            }
            catch (ArgumentNullException)
            {
                // ���o�͕�����i�[�p��޼ު�� �܂��� encoding �� null ���Q�Ƃ��A���s
                ErrorInfo = 2;
            }


            // �޲Č^�z����ƺ��ޕ������string�^�ɐݒ�
            char[] AfterChars = new char[AfterEncodObj.GetCharCount(AfterBytes, 0, AfterBytes.Length)];
            AfterEncodObj.GetChars(AfterBytes, 0, AfterBytes.Length, AfterChars, 0);
            UnicodeText = new string(AfterChars);


            return ErrorInfo;
        }


    }

}