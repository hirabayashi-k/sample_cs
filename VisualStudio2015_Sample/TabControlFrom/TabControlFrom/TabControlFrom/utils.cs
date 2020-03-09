using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabControlFrom
{
    public static class utils
    {
        public static void tab_visible(String tab_name, Boolean visible, ref int tabrmvnum,ref TabPage[] tabrmvlst, string[] TabNameLst,ref TabControl Page)
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

                /*
                 * // 消し方修正版
                 * 
                TabControl.TabPageCollection tabclec = Page.TabPages;

                idx = -1;

                int tabIndex = 0;
                foreach (TabPage tabp in tabclec)
                {
                    if (tabp.Text.CompareTo(tab_name) == 0)
                    {
                        idx = tabIndex;
                        break;
                    }
                    tabIndex++;
                }
                */
                idx = Array.IndexOf(TabNameLst, tab_name);


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

    }
}
