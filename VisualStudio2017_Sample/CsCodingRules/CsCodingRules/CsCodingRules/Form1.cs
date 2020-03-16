//----------------------------------------------------------------------
// Csコーディングルール
//----------------------------------------------------------------------
// @author 平林＠タクト
// 
// @date 2020/03/12 平林＠タクト　作成開始
// 
// Copyright (C) 2020 Hirabayashi Kota, Takt
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Takt.CsCodingRules.WinForm
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
    //    Okey ⇒ Ok 
    //  ⑤　namespace作成規則
    //      会社名+製品名+プロジェクト名+フォルダー名
    //      プロジェクト名  WinForm とか　WPFとか　LIB
    //  ⑥ private変数名に_をつける
    //      _userName
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
    //     1.プロジェクト⇒　プロパティ　⇒　NuGetパッケージの管理　にて 入手
    //     2.プロジェクト⇒　プロパティ　⇒　コード分析　⇒　リストBOX「この規則セットを実行」⇒「参照」　⇒　配布した「CsCodingRules.ruleset」を選択
    //     3.SA001⇒プロジェクト⇒プロパティ⇒ビルド⇒XMLドキュメントファイルにチェック
    //     4.各警告を消していく

    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class Form1 : Form
    {
        #region Fields

        // publicは基本的にパスカル

        /// <summary>
        /// ユーザーID
        /// </summary>
        public static readonly string UserId;

        // private の Constはパスカル

        /// <summary>
        /// ユーザーID　メンバー
        /// </summary>
        private const int UserIDNumber = 1;

        // private はキャメル　先頭に_をつける

        /// <summary>
        /// ユーザーネーム
        /// </summary>
        private string _userName;

        /// <summary>
        /// ユーザーID
        /// </summary>
        private int _userId;

        #endregion

        #region Constructors Finalizers (Destructors)

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            ProductIdChanged += SetDataUserId;
        }

        #endregion

        #region Delegates

        #endregion

        #region Events

        /// <summary>
        /// 製品変更Action
        /// </summary>
        public event Action<int> ProductIdChanged;

        #endregion

        #region Enums

        /// <summary>
        /// 製品モード
        /// </summary>
        public enum ProductMode
        {
            /// <summary>
            /// ノーマル
            /// </summary>
            Normal,

            /// <summary>
            /// レベル1
            /// </summary>
            Level1,
        }

        #endregion

        #region Interfaces
        #endregion

        #region Properties

        /// <summary>
        /// 製品取得 
        /// </summary>
        public int ProductId { get; set; }

        #endregion

        #region Indexers

        #endregion

        #region Methods

        // パラメーターはキャメル　_はつけない

        /// <summary>
        /// データセット
        /// </summary>
        /// <param name="userName">Name</param>
        public void SetData(string userName)
        {
            _userName = userName;
            MessageBox.Show(userName);            
        }

        /// <summary>
        /// ユザーID設定
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        public void SetDataUserId(int userId)
        {
            _userId = userId;
        }

        /// <summary>
        /// データ取得
        /// </summary>
        /// <returns>データ</returns>
        private int GetData()
        {
            ProductIdChanged(2);

            return 0;
        }

        #endregion

        #region Structs

        #endregion
    }
}
