using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBoxDataBind
{

    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class Form1 : Form
    {
        Person person = new Person();

        PropertyPerson properson = new PropertyPerson();

        public Form1()
        {
            InitializeComponent();

            // 自分で記述する場合 参考　URL http://www.digi-con.co.jp/tech/node/66
            txtBox1.DataBindings.Add("Text", person, "First");

            txtBox2.DataBindings.Add("Text", person, "FamilyName");

            // プロパティで記述する場合 参考 URL http://kitunechan.hatenablog.jp/entry/2015/04/16/123314
            propertyPersonBindingSource.DataSource = new PropertyPerson();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            person.First = "[First]変更が押された";
            person.FamilyName = "[FamilyName]変更が押された";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBox3.Clear();
            txtBox3.AppendText(person.First + "\r\n");
            txtBox3.AppendText(person.FamilyName + "\r\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PropertyPerson obj = (PropertyPerson)propertyPersonBindingSource.DataSource;

            txtBox3.Clear();
            txtBox3.AppendText(obj.First + "\r\n");
            txtBox3.AppendText(obj.FamilyName + "\r\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PropertyPerson obj = (PropertyPerson)propertyPersonBindingSource.DataSource;

            obj.First = "[First]変更が押された";
            obj.FamilyName = "[FamilyName]変更が押された";
        }
    }

    /// <summary>
    /// サンプルクラス
    /// </summary>
    public class Person : NofityPropertyChanged

    {
        private string first;
        public string First
        {

            get { return first; }

            set

            {

                if (value != first)

                {

                    // ※必ずfirstに値を設定してからNotifyPropertyChangeを呼び出すこと

                    first = value;



                    // NotifyPropertyChangeの引数に設定するのは"プロパティ名"

                    NotifyPropertyChanged("First");

                }

            }

        }

        private string familyName;
        public string FamilyName
        {

            get { return familyName; }

            set

            {

                if (value != familyName)

                {

                    // ※必ずfirstに値を設定してからNotifyPropertyChangeを呼び出すこと

                    familyName = value;



                    // NotifyPropertyChangeの引数に設定するのは"プロパティ名"

                    NotifyPropertyChanged("FamilyName");

                }

            }

        }

    }
    /// <summary>
    /// 継承クラス
    /// </summary>
    public class NofityPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }

    public class PropertyPerson : NofityPropertyChanged
    {
        private string first;
        public string First
        {

            get { return first; }

            set

            {

                if (value != first)

                {

                    // ※必ずfirstに値を設定してからNotifyPropertyChangeを呼び出すこと

                    first = value;



                    // NotifyPropertyChangeの引数に設定するのは"プロパティ名"

                    NotifyPropertyChanged("First");

                }

            }

        }

        private string familyName;
        public string FamilyName
        {

            get { return familyName; }

            set

            {

                if (value != familyName)

                {

                    // ※必ずfirstに値を設定してからNotifyPropertyChangeを呼び出すこと

                    familyName = value;



                    // NotifyPropertyChangeの引数に設定するのは"プロパティ名"

                    NotifyPropertyChanged("FamilyName");

                }

            }

        }
    }

}
