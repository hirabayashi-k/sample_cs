// ------------------------------------------------ ---------------------- 
// <copyright file = "{fileName}" company = "{companyName}"> 
// {copyrightText} 
// </ copyright> 
// ---------------------------------------------- ------------------------
// Csコーディングルール
// -------------------------------------------------------------------------
// 	@author	平林＠ワンプラスワン
// 
// @date 2020/03/12	平林＠ワンプラスワン　作成開始
// 
// 	Copyright (C) 2020 Hirabayashi Kota, OnePluseOne
// --------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePluseOne.CsCodingRules.WinForm
{
    // ★ 名前の付け方ルール https://docs.microsoft.com/ja-jp/dotnet/standard/design-guidelines/naming-guidelines
    // ①英語名でつける
    // ② パスカル　1単語ごとの頭文字を大文字にする UserName
    //              1単語になっている場合は途中での大文字はなし Namespace
    //    対象  
    //      名前空間
    //      型
    //      InterFace
    //      メソッド
    //      プロパティ
    //      イベント
    //      フィールド
    //      列挙値 
    // ③キャメル userName
    //    対象    
    //      パラメータ
    // ④ 単語の頭文字をとった場合は大文字
    //    2文字の場合
    //     Internet Protocol ⇒　IP
    //     No good ⇒　NG
    //    3文字の場合
    //    Transmission Control Protocol ⇒　Tcp
    //    Structured Query Language ⇒ Sql
    //    例外 頭文字２文字での略語は例外
    //    Identifier　⇒ Id
    //　　Okey ⇒ Ok 
    //  ⑤　namespace作成規則
    //      会社名+製品名+プロジェクト名+フォルダー名
    //      プロジェクト名  WinForm とか　WPFとか　LIB
    //  ⑥ private変数に名に_をつける
    //　　　　_userName
    //     メソッド内の変数とクラス変数が区別できる
    //     アンダーバーを打ち込むとインテリセンスにクラス内変数のみが表示される
    //  ⑦ コントロールの名前つけ
    //     語尾にコントロール名を付ける
    //     ProdctNameButton ⇒ Button
    //     ProdctNameTextBox ⇒ TextBox
    //     ProdctNameCheckBox ⇒ CheckBox
    //     ProdctNameLabel ⇒ Label
    //     インテリセンスによって区別ができる
    //  ⑧　クラス名(ファイル名)
    //     語尾に種類をつける
    //     SaveFrom
    //     SaveViewModel
    //     SaveEntity
    //  ⑨ StyleCop.Analyzersをインストールして自動でプログラムをチェックする
    //     
    public partial class Form1 : Form
    {
        public enum ProductMode
        {
            Normal,
            Level1,
        }

        // publicは基本的にパスカル
        public static readonly string UserId;

        // private はキャメル　先頭に_をつける
        private string _userName;
        // private の Constはパスカル
        private const int UserIDNumber = 1;

        /// <summary>
        /// 画面の1
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            //System.IO
            //IPAddress
            //TcpClint
            //SqlConnection
        }

        public int ProductId { get; set; }

        public event Action<int> ProductIdChanged;

        /// <summary>
        /// データ取得
        /// </summary>
        /// <returns></returns>
        private int GetData()
        {
            return 0;
        }

        // パラメーターはキャメル　_はつけない
        public void SetData(int userId,string userName)
        {
            _userName = userName;
            MessageBox.Show(userName);
        }

    }
}
