using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DBtest
{
    class test1
    {


        /** select文のテスト レコード件数の取得 */
        public string SelectTest(SqlCommand com, string tableName)
        {
            //実行するSQLコマンドを設定する

            //要素数
            com.CommandText = "SELECT Count(*) FROM " + tableName;

            int num = (int)com.ExecuteScalar();

            string result = "レコード件数:" + num + "\n";

            return result;

        }

        /** select文のテスト 年齢が30歳以上の名前を取得 */
        public string SelectSample(SqlCommand com, string tableName)
        {
            //列名をすべて表示
            com.CommandText = "SELECT 名前, 年齢 FROM " + tableName + " WHERE 年齢 < 30";


            string reslut = "";

            using (SqlDataReader reader = com.ExecuteReader())
            {//コマンドの実行

                while (reader.Read()) //1行読み込み
                {
                    // Console.WriteLine("{0} - {1}", reader[0],reader[1]); でも可 
                    reslut = reslut + reader["名前"] + "-" + reader["年齢"] + "\r\n";
                }
                reader.Close();
            }

            return reslut;

        }

        /** 指定したテーブル名を取得する */
        public string getColumn(SqlCommand com, string tableName)
        {
            com.CommandText = "SELECT * FROM syscolumns WHERE id = object_id('" + tableName + "')";


            string result = "";

            using (SqlDataReader reader = com.ExecuteReader())
            {//コマンドの実行


                while (reader.Read()) //1行読み込み
                {
                    result = result + (reader[0] + "\r\n");
                }
                reader.Close();
            }

            return result;

        }

        /** 指定したテーブルの列名とデータ型を取得する */
        public string getColmnToDataType(SqlCommand com, string tableName)
        {
            com.CommandText = "select name ,type_name(xtype)AS type from syscolumns where id=object_id('" + tableName + "')";

            string result = "";

            using (SqlDataReader reader = com.ExecuteReader())
            {//コマンドの実行


                while (reader.Read()) //1行読み込み
                {
                    result = result + ("名前:" + reader[0] + "データ型:" + reader[1] + "\r\n");

                    switch ((string)reader[1])
                    {
                        /** [r1] */
                        case "bigint": System.Console.WriteLine((string)reader[1]); break;
                        case "bit": System.Console.WriteLine((string)reader[1]); break;
                        case "decimal": System.Console.WriteLine((string)reader[1]); break;
                        case "int": System.Console.WriteLine((string)reader[1]); break;
                        case "money": System.Console.WriteLine((string)reader[1]); break;
                        case "numeric": System.Console.WriteLine((string)reader[1]); break;
                        case "smallint": System.Console.WriteLine((string)reader[1]); break;
                        case "smallmoney": System.Console.WriteLine((string)reader[1]); break;
                        case "tinyint": System.Console.WriteLine((string)reader[1]); break;
                        case "float": System.Console.WriteLine((string)reader[1]); break;
                        case "real": System.Console.WriteLine((string)reader[1]); break;

                        case "date": System.Console.WriteLine((string)reader[1]); break;
                        case "datetime2": System.Console.WriteLine((string)reader[1]); break;
                        case "datetime": System.Console.WriteLine((string)reader[1]); break;
                        case "datetimeoffset": System.Console.WriteLine((string)reader[1]); break;
                        case "smalldatetime": System.Console.WriteLine((string)reader[1]); break;
                        case "Time": System.Console.WriteLine((string)reader[1]); break;

                        case "char": System.Console.WriteLine((string)reader[1]); break;
                        case "text": System.Console.WriteLine((string)reader[1]); break;
                        case "nchar": System.Console.WriteLine((string)reader[1]); break;
                        case "varchar": System.Console.WriteLine((string)reader[1]); break;
                        case "nvarchar": System.Console.WriteLine((string)reader[1]); break;

                    }

                }
                reader.Close();
            }

            return result;
        }


        public override string ToString()
        {
            return base.ToString();
        }

    }
}
