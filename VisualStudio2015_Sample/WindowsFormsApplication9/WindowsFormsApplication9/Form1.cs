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
using System.Drawing.Printing;

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

            Text = "sample data";

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


            // cell size fixed
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;

            // header size fixed
            dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // headselect disable
            //dataGridView1.SelectionBlockOptions = SelectionBlockOptions.Cells;

            // Visual style
            dataGridView1.EnableHeadersVisualStyles = false;

            // color
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Gray;

            // select mode
            dataGridView1.MultiSelect = true; 
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // sort false
            foreach (DataGridViewColumn c in dataGridView1.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;


            // current mark
            //DataGridView1.RowTemplate.HeaderCell = new DgvRowHeaderNoTriangle();

            // edit disable
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;


            //デフォルトのセルスタイルの設定
            this.defaultCellStyle = new DataGridViewCellStyle();

            //現在のセルのセルスタイルの設定
            this.mouseCellStyle = new DataGridViewCellStyle();
            this.mouseCellStyle.Font = new Font(dataGridView1.Font, dataGridView1.Font.Style | FontStyle.Bold);

            //セルの上と左を二重線のくぼんだ境界線にし、
            //下と右を一重線のくぼんだ境界線にする
            dataGridView1.AdvancedCellBorderStyle.Top =
                DataGridViewAdvancedCellBorderStyle.InsetDouble;
            dataGridView1.AdvancedCellBorderStyle.Right =
                DataGridViewAdvancedCellBorderStyle.Inset;
            dataGridView1.AdvancedCellBorderStyle.Bottom =
                DataGridViewAdvancedCellBorderStyle.Inset;
            dataGridView1.AdvancedCellBorderStyle.Left =
                DataGridViewAdvancedCellBorderStyle.InsetDouble;


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
            //Lines = Strings.ToStrings("");

            foreach (string s0 in Lines)
            {
                textBox1.AppendText("..." +s0 + "\r\n");
            }

            //MessageBox.Show("sample");

            foreach ( object obj  in comboBox1.Items)
            {
                textBox1.AppendText(obj.ToString());
            }


            //--------
            //
            // chart
            //
            //--------
            
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            
            string chart_area1 = "Area1";
            chart1.ChartAreas.Add(new ChartArea(chart_area1));

            string legend1 = "Graph1";
            string legend2 = "Graph2";
            chart1.Series.Add(legend1);
            chart1.Series.Add(legend2);

            // 折れ線グラフを指定してみます
            chart1.Series[legend1].ChartType = SeriesChartType.Line; 
            chart1.Series[legend2].ChartType = SeriesChartType.Line;

            //chart1.Legends[0].Enabled = false;
            chart1.Legends.Clear();

            double[] y_values = new double[5] { 1.0, 1.2, 0.8, 1.8, 0.2 };
            double[] y_values2 = new double[5] { 1.0*2, 1.2*2, 0.8*2, 1.8*2, 0.2*2 };

            //Array.Resize(ref y_values2, y_values2.GetLength(0) - 2);


            for (int i = 0; i < y_values.Length; i++)
            {
                //chart1.Series[legend1].Points.AddY(y_values[i]);
                //chart1.Series[legend2].Points.AddY(y_values[i]);
                chart1.Series[0].Points.AddY(y_values[i]);
                chart1.Series[1].Points.AddY(y_values2[i]);

            }


            //---------------------
            //
            // picturebox drawing
            //
            //---------------------

            Bitmap img1 =  new Bitmap(10, 10);
            Graphics Canvas = Graphics.FromImage(img1);
            Canvas.FillRectangle(Brushes.LimeGreen, 0, 0, 10, 10);
            pictureBox1.Image = img1;
            pictureBox1.Update();

            pictureBox2.Image = null;

            //Bitmap img = new Bitmap(100, 100);

            Graphics g = Graphics.FromImage(img);

            g.FillRectangle(Brushes.Black, 25, 25, 50, 50);

            pictureBox2.Image = img;

            // polygon

            Pen _Pen = new Pen(Color.Red, 3);


            // Create points that define polygon.
            Point point1 = new Point(5, 5);
            Point point2 = new Point(10, 25);
            Point point3 = new Point(20, 5);
            Point point4 = new Point(25, 50);
            Point point5 = new Point(30, 10);
            Point point6 = new Point(35, 20);
            Point point7 = new Point(100, 100);
            Point[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7
             };

            _Pen.Width = 1;
            g.DrawPolygon(_Pen, curvePoints);
            g.FillPolygon(Brushes.Lime, curvePoints);

            //g.FillRectangle(Brushes.LimeGreen, 10, 10, 100, 100);

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

            //--------
            // array
            //--------

            int[] ai0 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1};

            textBox1.AppendText("base: ");
            foreach (int a in ai0)
            {
                textBox1.AppendText(a.ToString() + ", ");
            }
            textBox1.AppendText("\r\n");

            Array.Clear(ai0, 0, 1);
            textBox1.AppendText("clear: ");
            foreach (int a in ai0)
            {
                textBox1.AppendText(a.ToString() + ", ");
            }
            textBox1.AppendText("\r\n");


            //----------
            // tooltip
            //----------
            toolTip1.SetToolTip(button1, "tooltip sample");
            toolTip1.SetToolTip(button2, "tooltip sample");


            groupBox1.TabIndexChanged += BindingsCollection1_CollectionChanged;




            //--------
            // parse
            //--------
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            double d0 = double.Parse("10.01", System.Globalization.NumberStyles.Any, ci);

            textBox1.AppendText("parse(\"10.01\", Integer, null) = " + d0.ToString() + "\r\n");
        }

        Bitmap img = new Bitmap(200, 100);

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

            //if (toolTip1.IsBalloon)
            //    toolTip1.IsBalloon = false;
            //else
            //    toolTip1.IsBalloon = true;

           toolTip1.Active = false;

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
            MessageBox.Show("正しい値を入力してください。",
                            "警告",
                             MessageBoxButtons.YesNoCancel,
                             MessageBoxIcon.Warning);
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
            /*
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


            textBox1.AppendText("grid height: " + dataGridView1.Height.ToString() + "\r\n");
            textBox1.AppendText("grid width: " + dataGridView1.Width.ToString() + "\r\n");
            textBox1.AppendText("grid size height: " + dataGridView1.Size.Height.ToString() + "\r\n");
            textBox1.AppendText("grid size width: " + dataGridView1.Size.Height.ToString() + "\r\n");

            int i0 = int.MaxValue;
            int i1 = int.MinValue;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int rowval = row.Index;
                i0 = Math.Min(i0, rowval);
                i1 = Math.Max(i1, rowval);
            }
            label4.Text = "min: " + i0.ToString();
            label5.Text = "max: " + i1.ToString();
            */

            /*
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.AppendText(row.Index.ToString() +", ");
            }
            textBox1.AppendText("\r\n");
            */

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
            textBox1.AppendText("groupbox enter\r\n");
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

        private void panel1_Click(object sender, EventArgs e)
        {
            if( openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                textBox1.AppendText("file name: " +openFileDialog1.FileName +"\r\n");

                //IEnumerable<string> lines = File.ReadLines(openFileDialog1.FileName);
                //string[] as0 = lines.Cast<string>().ToArray();

                string[] as0 = File.ReadAllLines(openFileDialog1.FileName);
                string s0 = Strings.ToCommaText(as0);

                textBox1.AppendText(s0);

                //foreach (string line in lines)
                //{
                //    textBox1.AppendText(line);
                //}
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //--------
        // print
        //--------

        Bitmap memoryImage;
        PrintDocument printDocument1 = new PrintDocument();
        PrintPreviewDialog printPreviewDialog1;

        private void button27_Click(object sender, EventArgs e)
        {
            PrintDialog prtdlg = new PrintDialog();

            // CaptureScreen
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            //Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            //memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
            this.DrawToBitmap(memoryImage, new Rectangle(0, 0, this.Width, this.Height));

            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            //printDocument1.Print();

            prtdlg.Document = printDocument1;
            if( prtdlg.ShowDialog()==DialogResult.OK )
            {
                printDocument1.Print();
            }

            //printPreviewDialog1 = new PrintPreviewDialog();
            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.AppendText("tabControl1 SelectedIndexChanged: " + tabControl1.SelectedIndex.ToString() +"\r\n");
        }

        private void textBox1_Move(object sender, EventArgs e)
        {
            //label3.Text = textBox1.SelectionStart.ToString();
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            label3.Text =
                textBox1.SelectionStart.ToString() +", "
                    +textBox1.SelectionLength.ToString() +", "
                        +textBox1.SelectedText;
        }


        // radio group

        private void BindingsCollection1_CollectionChanged(Object sender, EventArgs e)
        {
            textBox1.AppendText("BindingContextChanged\r\n");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }



        private void button29_Click(object sender, EventArgs e)
        {
            /*
            int [] rowidx = new int [dataGridView1.SelectedRows.Count];
            int idx = 0;

            foreach (DataGridViewRow rows in dataGridView1.SelectedRows)
            {
                rowidx[idx] = rows.Index;
                idx += 1;
            }
            int min = rowidx.Min();
            int max = rowidx.Max();

            if (min <= 0) return;

            dataGridView1.ClearSelection();
            //dataGridView1.CurrentCell = dataGridView1[0, 0];

            dataGridView1.CurrentCell =  dataGridView1[0, min - 1];
            for ( int i0 = min-1; i0<max; i0++)
            {
                dataGridView1[0, i0].Selected = true;
            }
            */

            //foreach (DataGridViewCell dr in dataGridView1.SelectedCells)
            //{
            //    dr.Value = "";
            //}

            //dataGridView1.Columns[2].Visible = !dataGridView1.Columns[2].Visible;
            //dataGridView1.Rows[10].Visible = !dataGridView1.Rows[10].Visible;

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button29_MouseDown(object sender, MouseEventArgs e)
        {

        }

        int tabidx = 0;
        private void button30_Click(object sender, EventArgs e)
        {
            double i0, i1;

            i0 = 0;
            i1 = 0;
            i0 /= i1;
            tabControl1.SelectedIndex = tabidx;
            tabidx += 1;
            if (tabControl1.TabCount <= tabidx) tabidx = 0;
        }

        void inserttab(TabControl tc, int index)
        {
            tc.TabPages.Insert(index, "");
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /*
            //ヘッダー以外のセルで、背景を描画する時
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                (e.PaintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
            {
                //選択されているか調べ、色を決定する
                //bColor1が開始色、bColor2が終了色
                Color bColor1, bColor2;
                if ((e.PaintParts & DataGridViewPaintParts.SelectionBackground) ==
                        DataGridViewPaintParts.SelectionBackground &&
                    (e.State & DataGridViewElementStates.Selected) ==
                        DataGridViewElementStates.Selected)
                {
                    bColor1 = e.CellStyle.SelectionBackColor;
                    bColor2 = Color.Black;
                }
                else
                {
                    bColor1 = e.CellStyle.BackColor;
                    bColor2 = Color.LemonChiffon;
                }
                //グラデーションブラシを作成
                using (System.Drawing.Drawing2D.LinearGradientBrush b =
                    new System.Drawing.Drawing2D.LinearGradientBrush(
                    e.CellBounds, bColor1, bColor2,
                    System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                {
                    //セルを塗りつぶす
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }

                //背景以外が描画されるようにする
                DataGridViewPaintParts paintParts =
                   e.PaintParts & ~DataGridViewPaintParts.Background;
                //セルを描画する
                e.Paint(e.ClipBounds, paintParts);

                //描画が完了したことを知らせる
                e.Handled = true;
            }

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                (e.PaintParts & DataGridViewPaintParts.ContentForeground) ==
                    DataGridViewPaintParts.ContentForeground)
            {

                DataGridView dgv = (DataGridView)sender;

                if (dgv[e.ColumnIndex, e.RowIndex].Style.Equals(this.mouseCellStyle))
                    dgv[e.ColumnIndex, e.RowIndex].Style = this.defaultCellStyle;
                else
                    dgv[e.ColumnIndex, e.RowIndex].Style = this.mouseCellStyle;

                dgv[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Blue;

                //描画が完了したことを知らせる
                e.Handled = true;
            }
            */

            //ヘッダー以外のセルで、背景を描画する時
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {


                if ((e.PaintParts & DataGridViewPaintParts.Background) ==
                                                DataGridViewPaintParts.Background)
                {

                    Color bColor1, bColor2;

                    if ((e.PaintParts & DataGridViewPaintParts.SelectionBackground) ==
                            DataGridViewPaintParts.SelectionBackground &&
                        (e.State & DataGridViewElementStates.Selected) ==
                            DataGridViewElementStates.Selected)
                    {
                        bColor1 = e.CellStyle.SelectionBackColor;
                        bColor2 = Color.Black;
                    }
                    else
                    {
                        bColor1 = e.CellStyle.BackColor;
                        bColor2 = Color.LemonChiffon;
                    }

                    //グラデーションブラシを作成
                    //using (System.Drawing.Drawing2D.LinearGradientBrush b =
                    //    new System.Drawing.Drawing2D.LinearGradientBrush(
                    //    e.CellBounds, bColor1, bColor2,
                    //    System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                    //{
                    //    //セルを塗りつぶす
                    //    e.Graphics.FillRectangle(b, e.CellBounds);
                    //}
                    SolidBrush Brush = new SolidBrush(bColor1);
                    e.Graphics.FillRectangle(Brush, e.CellBounds);

                }

                if ((e.PaintParts & DataGridViewPaintParts.ContentForeground) ==
                    DataGridViewPaintParts.ContentForeground)
                {

                    DataGridView dgv = (DataGridView)sender;

                    if((e.State & DataGridViewElementStates.Selected) ==
                        DataGridViewElementStates.Selected)
                        dgv[e.ColumnIndex, e.RowIndex].Style = this.defaultCellStyle;
                    else
                        dgv[e.ColumnIndex, e.RowIndex].Style = this.mouseCellStyle;

                    dgv[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Blue;

                    e.Graphics.DrawString(
                                    Convert.ToString(dgv[e.ColumnIndex, e.RowIndex].Value),
                                    new Font(dgv.Font.FontFamily, 6),
                                    Brushes.LightGray,
                                    new Rectangle(e.CellBounds.Left + (e.CellBounds.Width >> 2), 
                                                    e.CellBounds.Top + (e.CellBounds.Height >> 2), 
                                                    e.CellBounds.Width, 
                                                    e.CellBounds.Height));
                }

                //背景以外が描画されるようにする
                DataGridViewPaintParts paintParts =
                   e.PaintParts & ~DataGridViewPaintParts.Background & ~DataGridViewPaintParts.ContentForeground;

                //セルを描画する
                e.Paint(e.ClipBounds, paintParts);
                //e.Paint(e.ClipBounds, e.PaintParts);

                //描画が完了したことを知らせる
                e.Handled = true;
            }
            //else
            //{
            //    textBox1.AppendText("col: " + e.ColumnIndex.ToString() + "\r\n");
            //    textBox1.AppendText("row: " + e.RowIndex.ToString() + "\r\n");
            //    textBox1.AppendText("fixed col: " + ((DataGridView)sender).TopLeftHeaderCell.ColumnIndex.ToString() + "\r\n");
            //    textBox1.AppendText("fixed row: " + ((DataGridView)sender).TopLeftHeaderCell.RowIndex.ToString() + "\r\n");
            //}

        }

        //デフォルトのセルスタイル
        private DataGridViewCellStyle defaultCellStyle;

        //マウスポインタの下にあるセルのセルスタイル
        private DataGridViewCellStyle mouseCellStyle;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Graphics Canvas = pictureBox2.CreateGraphics();
            //Canvas.FillRectangle(Brushes.LimeGreen, 80, 10, 10, 10);
            //Graphics Canvas = Graphics.FromImage(pictureBox2.Image);

            Canvas.DrawImage( pictureBox1.Image, new Point(150, 50) );

            pictureBox2.Update();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.AppendText("key code: " +e.KeyCode.ToString() + "\r\n");
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            label6.Text = e.X.ToString();
            label7.Text = e.Y.ToString();

            // クライアント座標をグラフ上の座標に変換する
            var x = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            var y = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
            // Chartコントロールにデータを追加する
            //chart1.Series[0].Points.AddXY(x, y);
            HitTestResult Result = chart1.HitTest(e.X, e.Y);
            int i0 = Result.PointIndex;
            if (0 <= i0)
            {
                label8.Text = Result.Series.Points[i0].YValues[0].ToString();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(((MouseEventArgs)e).X.ToString());
            textBox1.AppendText(((MouseEventArgs)e).Y.ToString());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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


    class DgvRowHeaderNoTriangle : DataGridViewRowHeaderCell
    {
        protected override void Paint(Graphics graphics,
                                        Rectangle clipBounds,
                                        Rectangle cellBounds,
                                        int rowIndex,
                                        DataGridViewElementStates cellState,
                                        Object value,
                                        Object formattedValue,
                                        string errorText,
                                        DataGridViewCellStyle cellStyle,
                                        DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                        DataGridViewPaintParts paintParts)
        {
            paintParts &= ~DataGridViewPaintParts.ContentBackground;
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value,
                        formattedValue, errorText, cellStyle, advancedBorderStyle,
                        paintParts);
        }
    };
}
