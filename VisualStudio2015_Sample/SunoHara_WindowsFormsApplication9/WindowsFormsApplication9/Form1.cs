using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using System.IO;        // Path
using System.Text.RegularExpressions; // regex
using System.Reflection;        // MethodInfo
using System.Runtime.InteropServices;
using System.Threading;



namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {

        public void smpfnc(int a)
        {
            textBox1.AppendText(a.ToString());
        }

        public Form1()
        {
            InitializeComponent();

            panel1.MouseDoubleClick += Panel1_MouseDoubleClick;
            panel2.MouseDoubleClick += Panel2_MouseDoubleClick;


            //---------------
            // DataGridView
            //---------------

            dataGridView1.ColumnCount = 6;
            dataGridView1.RowCount = 100;
            // dataGridView1.AutoGenerateColumns = false;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.RowHeadersWidth = 50;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders;

            int i0, i1;

            for(i0=0; i0<dataGridView1.ColumnCount; i0++)
            {
                for(i1=0; i1<dataGridView1.RowCount; i1++)
                {
                    dataGridView1[i0, i1].Value = (i0 * 10 + i1).ToString();
                }
            }

            // 左上隅のセルの値
            dataGridView1.TopLeftHeaderCell.Value = "表";

            for (int i = 1; i <= dataGridView1.ColumnCount; i++)
            {
                // 行ヘッダと列ヘッダのセルの値
                dataGridView1.Columns[i - 1].HeaderCell.Value = "C" +i.ToString();

            }

            for (int i = 1; i <= dataGridView1.RowCount; i++)
            {
                // 行ヘッダと列ヘッダのセルの値
                dataGridView1.Rows[i - 1].HeaderCell.Value = "R" +i.ToString();
            }

            int R;
            for (R = 0; R < dataGridView1.RowCount; R++)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[R].Cells)
                {
                    cell.Value = R.ToString();
                }
            }

            textBox1.AppendText(
                "Displayed: "
                    + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Displayed).ToString()
                        + "\r\n");

            textBox1.AppendText(
                "Visible: "
                    + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString()
                        + "\r\n");
            

            //---------------------------------------
            //
            //---------------------------------------

            textBox1.AppendText(DateTime.Now.ToString() +"\r\n");


            //-------------
            // tabcontrol
            //-------------

            tabpoint = new string[tabControl1.TabCount];

            int idx = 0;
            foreach(TabPage tpg in tabControl1.TabPages)
            {
                tabpoint[idx] = tpg.Name;
                idx += 1;
            }

            foreach(string s0 in tabpoint)
            {
                textBox1.AppendText(s0 + "\r\n");
            }


            int[,,] arysmp = new int[8, 4, 2];
            textBox1.AppendText("0: " + arysmp.GetLength(0).ToString() + "\r\n");
            textBox1.AppendText("1: " + arysmp.GetLength(1).ToString() + "\r\n");
            textBox1.AppendText("2: " + arysmp.GetLength(2).ToString() + "\r\n");


            //-------------
            // comma text
            //-------------

            string[] Lines;
            string Result = "";
                        
            Lines = Strings.ToStrings(",NAME,FL(mm),FB(mm),NA, DW,FA(mm),FS(mm/s),THRESH,SIZE,FTL(mm)");

            foreach(string s0 in Lines)
            {
                textBox1.AppendText("..." +s0 + "\r\n");
            }

            //MessageBox.Show("sample");

            foreach ( object obj  in comboBox1.Items)
            {
                textBox1.AppendText(obj.ToString());
            }


            //--------
            // chart
            //--------

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            
            string chart_area1 = "Area1";
            chart1.ChartAreas.Add(new ChartArea(chart_area1));
            
            string legend1 = "Graph1";
            chart1.Series.Add(legend1);
            
            chart1.Series[legend1].ChartType = SeriesChartType.Line; // 折れ線グラフを指定してみます

            double[] y_values = new double[5] { 1.0, 1.2, 0.8, 1.8, 0.2 };
                        
            for (int i = 0; i < y_values.Length; i++)
            {
                chart1.Series[legend1].Points.AddY(y_values[i]);
            }


            //---------------------
            // picturebox drawing
            //---------------------

            pictureBox2.Image = null;

            Bitmap img = new Bitmap(100, 100);

            Graphics g = Graphics.FromImage(img);

            g.FillRectangle(Brushes.Black, 25, 25, 50, 50);

            pictureBox2.Image = img;


            //--------------
            // class clone
            //--------------

            cs0 = new clonesmp();
            cs1 = cs0;

            textBox1.AppendText("\r\n----- cs0 -----\r\n");
            putcloneprm(cs0);
            textBox1.AppendText("\r\n----- cs1 -----\r\n");
            putcloneprm(cs1);

            cs0.ci0 = 11111;
            cs0.cai0[5] = 55555;

            textBox1.AppendText("\r\n----- cs0 -----\r\n");
            putcloneprm(cs0);
            textBox1.AppendText("\r\n----- cs1 -----\r\n");
            putcloneprm(cs1);

            cs1 = cs0.clone();
            cs0.ci0 = 22222;
            cs0.cai0[5] = 66666;

            textBox1.AppendText("\r\n----- cs0 -----\r\n");
            putcloneprm(cs0);
            textBox1.AppendText("\r\n----- cs1 -----\r\n");
            putcloneprm(cs1);

        }

        clonesmp cs0, cs1;

        void putcloneprm(clonesmp cs)
        {
            int i0;

            textBox1.AppendText("ci0: " +cs.ci0.ToString() +"\r\n");
            textBox1.AppendText("cs0: " + cs.cs0 +"\r\n");

            textBox1.AppendText("cai0: " + "\r\n");
            for (i0 = 0; i0 < cs.cai0.GetLength(0); i0++)
            {
                textBox1.AppendText( cs.cai0[i0].ToString() +", " );
            }
            textBox1.AppendText("\r\n");

            textBox1.AppendText("cas0: " + "\r\n");
            for (i0 = 0; i0 < cs.cas0.GetLength(0); i0++)
            {
                textBox1.AppendText(i0.ToString() +": " +cs.cas0[i0] + "\r\n");
            }
            textBox1.AppendText("\r\n");
        }


        public void Panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            textBox1.AppendText("panel2 MouseDoubleClick\r\n");
        }

        public void Panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            textBox1.AppendText("panel1 MouseDoubleClick\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s0 = "d:\\wutemp\\lcump.exe";

            textBox1.AppendText(Path.GetDirectoryName(s0+"\\"));

            textBox1.AppendText(Application.ExecutablePath);

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }


        public static string[] SplitCSV(string input)
        {
            Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
            List<string> list = new List<string>();
            string curr = null;
            foreach (Match match in csvSplit.Matches(input))
            {
                curr = match.Value;
                if (0 == curr.Length)
                {
                    list.Add("");
                }

                list.Add(curr.TrimStart(','));
            }

            return list.ToArray<string>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i0;
            //string[] as0 = SplitCSV("111,222,\"33,44,55\",666,\"77,88\",\"99\"");
            string[] as0 = SplitCSV("111,222,\"\"33,44,55\"\",666,\"\"77,88\"\",\"\"99\"\"");

            for (i0 = 0; i0 < as0.GetLength(0); i0++)
            {
                textBox1.AppendText(as0[i0] +"\r\n");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = dataGridView1.CurrentCell.ColumnIndex.ToString();
            label2.Text = dataGridView1.CurrentCell.RowIndex.ToString();

        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Action<int> func = smpfnc;
            Class1.set(func);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1.smpfnctest();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1.mtdinf(panel2);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //TestClassクラスのTypeオブジェクトを取得する
            Type t = panel1.GetType();

            //メンバを取得する
            //MemberInfo[] members = t.GetMembers(
            //    BindingFlags.Public | BindingFlags.NonPublic |
            //    BindingFlags.Instance | BindingFlags.Static |
            //    BindingFlags.DeclaredOnly);
            //MethodInfo[] methods = t.GetMethods(
            //    BindingFlags.Public |
            //    BindingFlags.Instance | BindingFlags.DeclaredOnly);

            EventInfo[] evinf = t.GetEvents(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance );

            //foreach (MemberInfo m in members)
            //foreach (MemberInfo m in methods)
            foreach (EventInfo m in evinf)
            {
                //メンバの型と、名前を表示する
                //Console.WriteLine("{0} - {1}", m.MemberType, m.Name);
                textBox1.AppendText(string.Format("{0} - {1}\r\n", m.MemberType, m.Name));
                if(m.Name.EndsWith("MouseDoubleClick"))
                {
                    //MethodInfo[] mi = m.GetOtherMethods(true);
                    textBox1.AppendText("GetAddMethod: ");
                    MethodInfo add_mi = m.GetAddMethod();
                    if(add_mi!=null)
                    {
                        textBox1.AppendText(add_mi.Name);

                        //MouseEventArgs mea = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                        //object[] pnl = panel1;
                        //mi.Invoke(new object[] { pnl, mea });


                    }
                    textBox1.AppendText("\r\n");

                    textBox1.AppendText("GetRaiseMethod: ");
                    MethodInfo raise_mi = m.GetRaiseMethod(true);
                    if (raise_mi != null)
                    {
                        textBox1.AppendText(raise_mi.Name);
                    }
                    textBox1.AppendText("\r\n");

                    textBox1.AppendText("GetOtherMethods: ");
                    MethodInfo[] other_mi = m.GetOtherMethods(true);
                    foreach (MethodInfo mi in other_mi)
                    {
                        if (mi != null)
                        {
                            textBox1.AppendText(mi.Name);
                        }
                    }
                    textBox1.AppendText("\r\n");


                    //foreach (MethodInfo mix in mi)
                    //{
                    //    if (mix != null)
                    //    {
                    //        textBox1.AppendText("call method: " + mix.Name);
                    //    }
                    //}

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.MouseDoubleClick += mousedclick2;           
        }

        public void mousedclick2(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("mousedclick2\r\n");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.MouseDoubleClick -= mousedclick2;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = new MouseEventArgs(MouseButtons.Right, 2, 0, 0, 0);
        }


        private static BindingFlags All
        {
            get
            {
                return
                    BindingFlags.Public | BindingFlags.NonPublic |
                    BindingFlags.Instance | BindingFlags.IgnoreCase |
                    BindingFlags.Static;
            }
        }



        private static MethodInfo GetEventsMethod(Type objType)
        {
            MethodInfo mi = objType.GetMethod("get_Events", All);
            if ((mi == null) & (objType.BaseType != null))
                mi = GetEventsMethod(objType.BaseType);
            return mi;
        }



        private static EventHandlerList GetEvents(object obj)
        {
            MethodInfo mi = GetEventsMethod(obj.GetType());
            if (mi == null) return null;
            return (EventHandlerList)mi.Invoke(obj, new object[] { });
        }

        private static FieldInfo GetEventIDField(Type objType, string eventName)
        {
            FieldInfo fi = objType.GetField("Event" + eventName, All);
            if ((fi == null) & (objType.BaseType != null))
                fi = GetEventIDField(objType.BaseType, eventName);
            return fi;
        }

        private static object GetEventID(object obj, string eventName)
        {
            FieldInfo fi = GetEventIDField(obj.GetType(), eventName);
            if (fi == null) return null;
            return fi.GetValue(obj);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            EventHandlerList list = GetEvents(panel2);
            object key = GetEventID(panel2, "MouseDoubleClick");
            Delegate evnt = list[key];
            if (evnt == null)
            {
                MessageBox.Show("event is not assigned");
            }
            else
            {
                Delegate[] el = evnt.GetInvocationList();
                foreach (Delegate evnt1 in el)
                {
                    textBox1.AppendText(evnt1.Method.Name +"\r\n");

                    ParameterInfo[] pinf = evnt1.Method.GetParameters();
                    foreach(ParameterInfo pinfx in pinf)
                    {
                        if(pinfx!=null)
                        {
                            textBox1.AppendText(pinfx.ToString() +"\r\n");
                        }

                    }

                    MouseEventArgs mea = new MouseEventArgs(MouseButtons.Right, 2, 0, 0, 0);
                    System.Object obj = panel2;

                    //evnt1.Method.Invoke(obj, new object[] { obj, mea });
                }

            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(string.Format("{0:f5}", 1000012.3456789) +"\r\n");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            byte[] src = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };

            UInt32 dst = BitConverter.ToUInt32(src, 0);

            textBox1.AppendText(string.Format("{0:x}\r\n", dst));

            dst = BitConverter.ToUInt32(src, 4);

            textBox1.AppendText(string.Format("{0:x}\r\n", dst));

            BitConverter.ToUInt32(src, 4);
        }

        private void dataGridView1_CursorChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            label1.Text = dataGridView1.CurrentCell.ColumnIndex.ToString();
            label2.Text = dataGridView1.CurrentCell.RowIndex.ToString();

            textBox1.AppendText(
                "Displayed: "
                    + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Displayed).ToString()
                        + "\r\n");

            textBox1.AppendText(
                "Visible: "
                    + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString()
                        + "\r\n");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string filename = ".\\sample.txt";
            List<string> txts = new List<string>();

            int i0;

            for(i0=0; i0<10; i0++)
            {
                txts.Add(i0.ToString() + " : " + i0.ToString());
            }

            File.WriteAllLines(filename, txts);
            

        }

        void ItemIndex(Control ctrl, int idx)
        {
            int i0, i1;

            i0 = 0;
            for( i1= ctrl.Controls.Count-1; i1>=0; i1--)
            {
                if (ctrl.Controls[i1] is RadioButton)
                {
                    if (i0 == idx)
                    {
                        ((RadioButton)ctrl.Controls[i1]).Checked = true;
                        break;
                    }
                    i0 += 1;
                }
            }
        }

        int GetItemIndex(Control ctrl)
        {
            int Result = -1;
            int i0, i1;

            i0 = 0;
            for (i1 = ctrl.Controls.Count - 1; i1 >= 0; i1--)
            {
                if (ctrl.Controls[i1] is RadioButton)
                {
                    if( ((RadioButton)ctrl.Controls[i1]).Checked == true )
                    {
                        Result = i0;
                        break;
                    }
                    i0 += 1;
                }
            }

            return (Result);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            /*
            var RadioButtonChecked_InGroup = 
                groupBox1.Controls.OfType<RadioButton>().SingleOrDefault(rb => rb.Checked == true);

            // 結果
            if (RadioButtonChecked_InGroup == null)
            {
                textBox1.AppendText("no chaek\r\n");
            }
            else
            {
                textBox1.AppendText(string.Format("checked button text = {0}\r\n", RadioButtonChecked_InGroup.Text));
                textBox1.AppendText(string.Format("checked button name = {0}\r\n", RadioButtonChecked_InGroup.Name));
            }
            */

            ItemIndex(groupBox1, 1);
        }


        //int[] array = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        int[] array;

        private void button16_Click(object sender, EventArgs e)
        {
            int i0;

            textBox1.AppendText("\r\n");
/*
            for (i0 = 0; i0 < 10; i0++)
            {
                textBox1.AppendText(array[i0].ToString() + "\r\n");
            }
*/
            Array.Resize(ref array, 15);

            for (i0 = 0; i0 < 10; i0++)
            {
                textBox1.AppendText(array[i0].ToString() + "\r\n");
            }

            for (i0 = 10; i0 < 15; i0++)
            {
                textBox1.AppendText(array[i0].ToString() + "\r\n");
            }


        }

        private void button17_Click(object sender, EventArgs e)
        {
            string s = "$RabababcdeabcdeABCDE$R\r\n";


            Regex Rex = new Regex("abc");
            textBox1.AppendText(Rex.Replace(s, "-----") + "\r\n");

            Rex = new Regex("abc", RegexOptions.None);
            textBox1.AppendText(Rex.Replace(s, "-----") + "\r\n");

            Rex = new Regex("abc", RegexOptions.IgnoreCase);
            textBox1.AppendText(Rex.Replace(s, "-----") + "\r\n");

            Rex = new Regex("abc", RegexOptions.IgnoreCase);
            textBox1.AppendText(Rex.Replace(s, "-----", 1) + "\r\n");

            Rex = new Regex("\\$R", RegexOptions.IgnoreCase);
            textBox1.AppendText(Rex.Replace(s, "ooooo", 1) + "\r\n");

            Rex = new Regex("\\$R", RegexOptions.IgnoreCase);
            textBox1.AppendText(Rex.Replace(s, "ooooo", int.MaxValue) + "\r\n");

            string s0 = "E:\\オリンパス\\trunk\\ソース２\\lcump\\lcump\\bin\\Debug\\";
            Rex = new Regex("\\\\$", RegexOptions.IgnoreCase);
            textBox1.AppendText(Rex.Replace(s0, "____", int.MaxValue) + "\r\n");

            //todo
            /*
            string defdat = null;
            StreamReader StrmRdr = null;
            try
            {
                StrmRdr = new StreamReader(".\\default.dat");
                defdat = StrmRdr.ReadToEnd();
            }
            finally
            {
                StrmRdr.Close();
            }

            setDialog.LoadFromString(defdat, FormatType.Ini);

            
            string savedat = null;

            savedat = setDialog.SaveToString(FormatType.Ini);
            StreamWriter StrmWtr = null;

            try
            {
                StrmWtr = new StreamWriter(".\\new_default.dat");
                StrmWtr.Write(savedat);
            }
            finally
            {
                StrmWtr.Close();
            }
            */

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        int tabnum = 0;
        TabPage[] page = null;
        string[] tabpoint = null;

        private void button18_Click(object sender, EventArgs e)
        {
            //tabControl1.TabPages.Add(tabControl1.TabPages.Count.ToString());
            if(0<tabnum)
            {
                foreach(TabPage tpg in page)
                {
                    int idx = Array.IndexOf(tabpoint, tpg.Name);
                    if (0<=idx && idx<tabpoint.GetLength(0))
                    {
                        if( tabControl1.TabCount== 0)
                        {
                            tabControl1.TabPages.Add(tpg);
                            continue;
                        }

                        int tabidx = 0, crt;
                        bool chkins = false;
                        foreach(TabPage chktpg in tabControl1.TabPages)
                        {
                            crt = Array.IndexOf(tabpoint, chktpg.Name);
                            if (crt > idx)
                            {
                                tabControl1.TabPages.Insert(tabidx, tpg);
                                chkins = true;
                                break;
                            }
                            tabidx += 1;
                        }

                        if (!chkins)
                        {
                            tabControl1.TabPages.Add(tpg);
                        }
                    }
                }
                tabnum = 0;
                page = null;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

            int i0 = 0;

            /*
            if (page != null)
            {
                i0 = page.GetLength(0);
            }

            textBox1.AppendText("tab num = " + tabControl1.TabCount.ToString() + "\r\n");

            if( tabidx<=i0)
            {
                i0 = tabidx + 1;

                TabPage[] new_page = new TabPage[i0];
                int[] new_tabpoint = new int[i0];
                if (page != null)
                {
                    Array.Copy(page, 0, new_page, 0, page.GetLength(0));
                    Array.Copy(tabpoint, 0, new_tabpoint, 0, tabpoint.GetLength(0));
                }
                page = new_page;
                tabpoint = new_tabpoint;
            }

            page[tabidx] = null;
            tabpoint[tabidx] = 0;
            page[tabidx] = tabControl1.SelectedTab;
            tabpoint[tabidx] = tabControl1.SelectedIndex;

            textBox1.AppendText(page[tabidx].Text +"\r\n");
            textBox1.AppendText(tabpoint[tabidx].ToString() + "\r\n");

            tabidx += 1;

            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            */


            int idx = Array.IndexOf(tabpoint, tabControl1.SelectedTab.Name);
            if (0 <= idx && idx < tabControl1.TabCount)
            {

                if (page != null)
                {
                    i0 = page.GetLength(0);
                }

                textBox1.AppendText("tab num = " + tabControl1.TabCount.ToString() + "\r\n");
                textBox1.AppendText("tab idx = " + idx.ToString() + "\r\n");

                if (tabnum <= i0)
                {
                    i0 = tabnum + 1;

                    TabPage[] new_page = new TabPage[i0];
                    if (page != null)
                    {
                        Array.Copy(page, 0, new_page, 0, page.GetLength(0));
                    }
                    page = new_page;
                }

                page[tabnum] = tabControl1.SelectedTab;

                textBox1.AppendText(page[tabnum].Text + "\r\n");

                tabnum += 1;

                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        testthreadclass testthread = null;
        testthreadclass samplethread = null;

        private void button20_Click(object sender, EventArgs e)
        {
            testthread = new testthreadclass("test", this);
            samplethread = new testthreadclass("sample", this);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (testthread != null)
            {
                testthread.stop();
            }
            if(samplethread != null)
            {
                samplethread.stop();
            }
        }

        public delegate void fncputdeligate(string msg);

        static object o = new object();

        public void fncput(string msg)
        {
            //if (InvokeRequired)
            //{
            //    // 別スレッドから呼び出された場合
            //    this.Invoke(new fncputdeligate( this.fncput ));
            //    return;
            //}
            //lock (o)
            //{
                string fncstr = msg;
            Task.Delay(750);
                this.textBox1.AppendText(fncstr);
            //}
        }


        void SetLength<T>(ref T[] ary, int siz)
        {
            int crtsiz = 0;

            if (siz <= 0)
            {
                ary = null;
                return;
            }

            if (ary != null)
            {
                crtsiz = ary.GetLength(0);
            }

            var tmp = new T[siz];
            if (crtsiz > 0)
            {
                Array.Copy(ary, tmp, Math.Min(crtsiz, siz));
            }
            ary = tmp;
        }

        struct smp
        {
            public int a, b;
            public string c, d;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int[] ai0 = new int[] { 0, 1, 2, 3, 4, 5 };
            string[] as0 = new string[] { "a", "b", "c" };

            smp[] asmp0 = new smp[] {   new smp() { a=0, b=1, c="a", d="b" },
                                        new smp() { a=2, b=3, c="c", d="d" },
                                        new smp() { a=4, b=5, c="e", d="f" },
                                    };

            //smp smp0 = new smp() { a=1, b=2, c="a", d="b" };

            textBox1.AppendText("ai0: " +ai0.GetLength(0).ToString() + "\r\n");
            textBox1.AppendText("as0: " +as0.GetLength(0).ToString() + "\r\n");
            textBox1.AppendText("asmp0: " + asmp0.GetLength(0).ToString() + "\r\n");

            SetLength(ref ai0, 10);
            SetLength(ref as0, 5);
            SetLength(ref asmp0, 6);

            textBox1.AppendText("ai0: " + ai0.GetLength(0).ToString() + "\r\n");
            textBox1.AppendText("as0: " + as0.GetLength(0).ToString() + "\r\n");
            textBox1.AppendText("asmp0: " + asmp0.GetLength(0).ToString() + "\r\n");

            foreach (int i0 in ai0)
            {
                textBox1.AppendText(i0.ToString() +"\r\n");
            }
            foreach (string s0 in as0)
            {
                textBox1.AppendText(s0 + "\r\n");
            }
            foreach (smp smp0 in asmp0)
            {
                textBox1.AppendText(smp0.a.ToString() +"," +smp0.b.ToString() +"," 
                                        +smp0.c +"," + smp0.d + "\r\n");
            }

        }

        //[DllImport("kernel32.dll")]
        //private static extern int GetShortPathName(string longPath,
        //    StringBuilder shortPathBuffer, int bufferSize);

        //[DllImport("kernel32.dll")]
        //private static extern int GetShortPathName(string longPath, StringBuilder shortPathBuffer, int bufferSize);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]

        public static extern int GetShortPathName(
                 [MarshalAs(UnmanagedType.LPTStr)]
                   string path,
                 [MarshalAs(UnmanagedType.LPTStr)]
                   StringBuilder shortPath,
                 int shortPathLength
                 );

        private void button23_Click(object sender, EventArgs e)
        {
            //string longPath = @"C:\Documents and Settings\Administrator\UserData\index.dat";
            string longPath = "C:\\Documents and Settings\\Administrator\\UserData\\index.dat";

            //int bufferSize = 260;
            //StringBuilder shortPathBuffer = new StringBuilder(bufferSize);
            //GetShortPathName(longPath, shortPathBuffer, bufferSize);
            //string shortPath = shortPathBuffer.ToString();

            //int bufferSize = 260;
            //StringBuilder shortPathBuffer = new StringBuilder(bufferSize);
            //GetShortPathName(longPath, shortPathBuffer, bufferSize);
            //string shortPath = shortPathBuffer.ToString();

            
            //textBox1.AppendText("longpath: " + longPath +"\r\n");
            //textBox1.AppendText("shortpath: " + shortPath.ToString() + "\r\n");

        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.AppendText( "current Index: " +GetItemIndex(groupBox1).ToString() +"\r\n") ;
        }


        //------------------
        // move picturebox
        //------------------

        bool pnlloop = false;

        private void button25_Click(object sender, EventArgs e)
        {
            if (pnlloop) return;

            //pictureBox1.Width = 10;
            //pictureBox1.Height = 10;

            Task.Run(() =>
            {
                pnlloop = true;
                movpnl();
            });

        }

        private void button26_Click(object sender, EventArgs e)
        {
            pnlloop = false;
        }

        public delegate void fncmovpnl( int point );

        void mov(int point)
        {
            pictureBox1.Top = point;
            pictureBox1.BringToFront();
            //コントロールのBringToFrontメソッド：最前面へ移動する
            //コントロールのSendToBackメソッド：最背面へ移動する
            Update();
        }
        
        private void movpnl()
        {
            int i0, i1, i2;
            fncmovpnl fmp = new fncmovpnl(mov);

            //i1 = pictureBox1.Controls.Owner.TopLevelControl.Top;
            //i2 = pictureBox1.Controls.Owner.TopLevelControl.Bottom;
            //i1 = pictureBox1.Controls.Owner.Parent.Top;
            //i2 = pictureBox1.Controls.Owner.Parent.Bottom;
            i1 = this.Top;
            i2 = this.Bottom;

            while (pnlloop)
            {
                pictureBox1.Invoke(fmp, i1);

                for (i0 = i1; i0 <i2 ; i0++)
                {
                    pictureBox1.Invoke(fmp, i0);
                    //Application.DoEvents();
                    Thread.Sleep(10);

                    if (!pnlloop) break;
                }
            }
        }

    }


    //---------
    // thread
    //---------
    class testthreadclass
    {
        string threadname = "";

        Thread testthread = null;
        int counter = 0;
        bool loop = true;

        Form1 f1 = null;
     
        public testthreadclass(string name, Form1 f1)
        {
            threadname = name;
            this.f1 = f1;

            loop = true;
            testthread = new Thread(new ThreadStart(ThreadFunction));
            testthread.Start();
        }

        public void stop()
        {
            loop = false;
        }

        //async void ThreadFunction()
        void ThreadFunction()
        {
            Form1.fncputdeligate fpd = new Form1.fncputdeligate(f1.fncput);

            while (loop)
            {
                //Console.Write(threadname +" : " +counter.ToString() +"\r\n");
                //Console.ReadLine();
                f1.textBox1.Invoke(fpd, threadname + " : " + counter.ToString() + "\r\n");
                counter += 1;
                //await Task.Delay(500);
                System.Threading.Thread.Sleep(500);
            }
        }
    }



    //--------------
    // class clone
    //--------------

    class clonesmp
    {
        public int ci0;
        public string cs0;

        public int[] cai0;
        public string[] cas0;

        public clonesmp()
        {
            int i0;

            ci0 = 0;
            cs0 = "";

            cai0 = new int[10];
            for (i0=0; i0<cai0.GetLength(0); i0++)
            {
                cai0[i0] = cai0.GetLength(0) -i0;
            }

            cas0 = new string[10];
            for (i0 = 0; i0 < cas0.GetLength(0); i0++)
            {
                cas0[i0] = i0.ToString();
            }

        }

        public clonesmp clone()
        {
            clonesmp cloned = (clonesmp)MemberwiseClone();

            cloned.cai0 = (int[])this.cai0.Clone();
            cloned.cas0 = (string[])this.cas0.Clone();

            return cloned;
        }

        /*

        Object.MemberwiseCloneメソッドによる複製
        class Account {
          public int ID;
          public string Name;

          // コピーを作成するメソッド
          public Account Clone()
          {
            return (Account)MemberwiseClone();
          }
        }

        簡易コピー後にコピー元の参照型フィールドを変更した場合
        class Account {
          public int ID;
          public string Name;
          public string[] ContactAddresses;

          public Account Clone()
          {
            // 簡易コピーを作成する
            Account cloned = (Account)MemberwiseClone();

            // 参照型フィールドの複製を作成する(詳細コピーを行う)
            if (this.ContactAddresses != null) {
              cloned.ContactAddresses = (string[])this.ContactAddresses.Clone();
            }

            return cloned;
          }
        }
        */
    }
}
