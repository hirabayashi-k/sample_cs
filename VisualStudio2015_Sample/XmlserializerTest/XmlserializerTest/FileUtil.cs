using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace XmlserializerTest
{
    public static class FileUtil
    {
        //private static XmlAttributeOverrides ovrd1 = new XmlAttributeOverrides();
        //private static XmlAttributeOverrides ovrd2 = new XmlAttributeOverrides();
        //private static XmlAttributeOverrides ovrd3 = new XmlAttributeOverrides();
        //private static XmlAttributeOverrides ovrd4 = new XmlAttributeOverrides();
        //private static XmlAttributeOverrides ovrd5 = new XmlAttributeOverrides();
        //private static XmlAttributeOverrides ovrd6 = new XmlAttributeOverrides();

        private static XmlSerializer xmlClass1Seri = new XmlSerializer(typeof(XmlClass1));


        /// <summary>
        /// 通信設定値保存
        /// </summary>
        /// <param name="filepath">ファイルパス</param>
        /// <param name="_port_setting">設定値</param>
        public static bool SaveComXml(string filepath, XmlClass1 cs)
        {

            try
            {
                StreamWriter sw = new StreamWriter(filepath, false, new UTF8Encoding(false));

                xmlClass1Seri.Serialize(sw, cs);
                //sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            catch
            {
                MessageBox.Show($"[{filepath}]設定ファイルの保存に失敗しました。");
                return false;
            }

            return true;
        }
        /// <summary>
        /// 通信設定値復帰
        /// </summary>
        /// <param name="filepath">ファイルパス</param>
        /// <param name="_port_setting">設定値</param>
        public static bool LoadComXml(string filepath, ref XmlClass1 cs)
        {

            if (!File.Exists(filepath))
            {
                // 初回ファイル作成
                cs = new XmlClass1();
                SaveComXml(filepath, cs);
                System.Threading.Thread.Sleep(500);
            }
            try
            {

                StreamReader sr = new StreamReader(filepath, new UTF8Encoding(false));
                cs = (XmlClass1)xmlClass1Seri.Deserialize(sr);
                sr.Close();
                sr.Dispose();
            }
            catch
            {
                MessageBox.Show($"[{filepath}]設定ファイルの読込みに失敗しました。");
                return false;
            }

            return true;
        }



        /// <summary>
        /// シリアライズ可能なオブジェクトをXMLファイルへ書き込みます。
        /// </summary>
        /// <param name="filePath">書き込むXMLファイルパス
        /// <param name="obj">シリアライズするオブジェクト
        /// <param name="type">シリアライズするオブジェクトの型
        public static void SaveToFile(string filePath, object obj, Type type)
        {
            var serializer = new XmlSerializer(type);

            // 書き込む書式の設定
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = false;

            // ファイルへオブジェクトを書き込み（シリアライズ）
            using (var writer = XmlWriter.Create(filePath, settings))
            {
                serializer.Serialize(writer, obj);
            }
        }

        /// <summary>
        /// XMLファイルからシリアライズ可能なオブジェクトを読み込みます。
        /// </summary>
        /// <typeparam name="T">読み込むオブジェクトの型</typeparam>
        /// <param name="filePath">オブジェクトが保存されたXMLファイルパス
        /// <returns>デシリアライズされたオブジェクト</returns>
        public static T LoadFromFile<T>(string filePath)
            where T : class
        {
            T obj = null;
            var serializer = new XmlSerializer(typeof(T));

            // ファイルが存在するときだけ実行可能
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            // ファイルからオブジェクトの読み込み（デシリアライズ）
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                obj = serializer.Deserialize(fs) as T;
            }

            return obj;
        }

    }
}
