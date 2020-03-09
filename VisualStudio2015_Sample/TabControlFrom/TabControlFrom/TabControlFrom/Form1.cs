using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabControlFrom
{
    public partial class Form1 : Form
    {
        public TabControl Page;
        // tab control
        int tabrmvnum = 0;
        TabPage[] tabrmvlst = null;
        string[] TabNameLst = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Page = tabControl1;

            TabNameLst = new string[this.Page.TabCount];

            int idx = 0;
            foreach (TabPage tpg in this.Page.TabPages)
            {
                tpg.Name = tpg.Text;
                TabNameLst[idx] = tpg.Name;
                idx += 1;
            }
        }


        public void tab_visible(String tab_name, Boolean visible)
        {
            int i0 = 0;
            int tabpt = -1;
            int tabrmvpt;
            TabPage tgttpg = null;
            int idx;

            if (visible)
            {
                //-------
                // show
                //-------
                if (0 < tabrmvnum)
                {
                    idx = Array.IndexOf(TabNameLst, tab_name);

                    tabrmvpt = 0;
                    foreach (TabPage tpg in tabrmvlst)
                    {
                        if (tpg.Name.Equals(tab_name))
                        {
                            tgttpg = tpg;
                            break;
                        }
                        tabrmvpt += 1;
                    }

                    if (tgttpg != null)
                    {
                        if (Page.TabCount == 0)
                        {
                            Page.TabPages.Add(tgttpg);
                        }
                        else
                        {
                            int tabidx = 0, crt;
                            bool chkins = false;
                            foreach (TabPage chktpg in Page.TabPages)
                            {
                                crt = Array.IndexOf(TabNameLst, chktpg.Name);
                                if (crt > idx)
                                {
                                    Page.TabPages.Insert(tabidx, tgttpg);
                                    chkins = true;
                                    break;
                                }
                                tabidx += 1;
                            }

                            if (!chkins)
                            {
                                Page.TabPages.Add(tgttpg);
                            }
                        }

                        List<TabPage> numberList = new List<TabPage>(tabrmvlst);
                        numberList.RemoveAt(tabrmvpt);
                        tabrmvnum = numberList.Count;
                        tabrmvlst = numberList.ToArray();
                    }
                }
            }
            else
            {
                //-------
                // hide
                //-------

                TabControl.TabPageCollection tabclec = Page.TabPages;

                idx = -1;

                int tabIndex = 0;
                foreach(TabPage tabp in tabclec)
                {
                    if (tabp.Text.CompareTo(tab_name) == 0)
                    {
                        idx = tabIndex;
                        break;
                    }
                    tabIndex++;
                }

                //idx = Array.IndexOf(TabNameLst, tab_name);

                

                if (0 <= idx && idx < TabNameLst.GetLength(0))
                {
                    if (tabrmvlst != null)
                    {
                        i0 = tabrmvlst.GetLength(0);
                    }

                    if (tabrmvnum <= i0)
                    {
                        i0 = tabrmvnum + 1;

                        TabPage[] new_page = new TabPage[i0];
                        if (tabrmvlst != null)
                        {
                            Array.Copy(tabrmvlst, 0, new_page, 0, tabrmvlst.GetLength(0));
                        }
                        tabrmvlst = new_page;
                    }

                    tabrmvlst[tabrmvnum] = Page.TabPages[idx];

                    tabrmvnum += 1;

                    Page.TabPages.Remove(Page.TabPages[idx]);
                }
            }
        }

        private void tabControlSample(string tabname)
        {
            bool enable = false;

            var RadioButtonChecked_InGroup = groupBox1.Controls.OfType<RadioButton>()
                                                .SingleOrDefault(rb => rb.Checked == true);

            if (RadioButtonChecked_InGroup.Text.CompareTo("Enable") == 0)
            {
                enable = true;
            }

            utils.tab_visible(tabname,enable,ref tabrmvnum,ref tabrmvlst,TabNameLst,ref Page);

            //tab_visible(tabname, enable);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControlSample(tabPage1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControlSample(tabPage2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControlSample(tabPage3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControlSample(tabPage4.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControlSample(tabPage5.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControlSample(tabPage6.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }
    }
}
