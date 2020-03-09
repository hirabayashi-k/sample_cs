using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;        // MethodInfo
using System.ComponentModel;    // event

// Delphi embeddedtype
using Word = System.UInt16;
using DWORD = System.UInt32;
using Longint = System.Int64;
using Integer = System.Int32;
using Boolean = System.Boolean;

// Delphi component
//using TComponent = System.ComponentModel.Component;
using TObject = System.Object;
using TComponent = System.Windows.Forms.Control;
using TControl = System.Windows.Forms.Control.ControlCollection;
using TClass = System.Object;
using TLabel = System.Windows.Forms.Label;
using TStaticText = System.Windows.Forms.TextBox;
using TStringList = System.Collections.Generic.List<string>;
using TForm = System.Windows.Forms.Form;
using TNotifyEvent = System.EventHandler;
using TWinControl = System.Windows.Forms.Control;
using TPanel = System.Windows.Forms.Panel;
using TColor = System.Drawing.Color;


using TComponentDynArray = System.Windows.Forms.Control;
using TClassDynArray = System.Object;


namespace WindowsFormsApplication9
{
    

    public static class Class1
    {

        static Action<int> smpfnc = null;

        public delegate void samplefnc(int a);

        public static void set(Action<int> func)
        {
            smpfnc = func;
        }

        public static void smpfnctest()

        {
            if (smpfnc != null)
            {
                smpfnc(100);
            }
        }

        /*
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

        */

        static BindingFlags All = BindingFlags.Public | BindingFlags.NonPublic |
                                    BindingFlags.Instance | BindingFlags.IgnoreCase |
                                    BindingFlags.Static;

        private static MethodInfo GetEventsMethod(Type typ)
        {
            MethodInfo mi = typ.GetMethod("get_Events", All);
            if ((mi == null) & (typ.BaseType != null))
            {
                mi = GetEventsMethod(typ.BaseType);
            }
            return mi;
        }

        private static FieldInfo GetEventIDField(Type typ, string evtname)
        {
            FieldInfo fi = typ.GetField("Event" + evtname, All);

            if ((fi == null) & (typ.BaseType != null))
            {
                fi = GetEventIDField(typ.BaseType, evtname);
            }
            return (fi);
        }

        static void CallEventMethod(object sender, string evtname, object[] pmt)
        {

            Type typ = sender.GetType();
            MethodInfo mi = GetEventsMethod(typ);

            if (mi == null)
            {
                return;
            }

            EventHandlerList ehlst = (EventHandlerList)mi.Invoke(sender, new object[] { });

            FieldInfo fi = GetEventIDField(typ, evtname);

            if (fi == null)
            {
                return;
            }

            object key = fi.GetValue(sender);


            Delegate evt = ehlst[key];

            if (evt == null)
            {
                return;
            }

            Delegate[] ehl = evt.GetInvocationList();

            foreach (Delegate evtitm in ehl)
            {
                if (evtitm != null)
                {
                    try
                    {
                        evtitm.DynamicInvoke(pmt);
                    }
                    catch
                    {

                    }
                }
            }

        }
        public static void mtdinf(object sender)
        {
            /*
            string s0 = "";

            //TestClassクラスのTypeオブジェクトを取得する
            Type t = sender.GetType();

            //メンバを取得する
            //MemberInfo[] members = t.GetMembers(
            //    BindingFlags.Public | BindingFlags.NonPublic |
            //    BindingFlags.Instance | BindingFlags.Static |
            //    BindingFlags.DeclaredOnly);
            //MethodInfo[] methods = t.GetMethods(
            //    BindingFlags.Public | BindingFlags.NonPublic |
            //    BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] methods = t.GetMethods(
                BindingFlags.Public | BindingFlags.DeclaredOnly |
                BindingFlags.Instance);

            foreach (MemberInfo m in methods)
            {
                //メンバの型と、名前を表示する
                //Console.WriteLine("{0} - {1}", m.MemberType, m.Name);
                //textBox1.AppendText(string.Format("{0} - {1}", m.MemberType, m.Name));
                if(m.Name.EndsWith("MouseDoubleClick"))
                {
                    s0 = m.Name;
                    break;
                }
            }

            Type Pnl = (sender).GetType();
            MethodInfo method = Pnl.GetMethod(s0);

            //MouseButtons mb = new MouseButtons();
            //MouseEventArgs e = new MouseEventArgs(mb,1,0,0,0);

            if (method != null)
            {
                MouseEventArgs mea = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                method.Invoke(sender, new object[] { sender, mea });
            }
            */

            /*
            EventHandlerList list = GetEvents(sender);
            object key = GetEventID(sender, "MouseDoubleClick");
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
                    ParameterInfo[] pinf = evnt1.Method.GetParameters();
                    foreach (ParameterInfo pinfx in pinf)
                    {
                        if (pinfx != null)
                        {
                            string s0 = pinfx.ToString();
                        }

                    }

                    MouseEventArgs mea = new MouseEventArgs(MouseButtons.Right, 2, 0, 0, 0);

                    evnt1.DynamicInvoke(new object[] { sender, mea });
                }

            }
            */


            MouseEventArgs mea = new MouseEventArgs(MouseButtons.Right, 2, 0, 0, 0);

            object[] pmt = new object[] { sender, mea };

            CallEventMethod(sender, "MouseDoubleClick", pmt);

            CallEventMethod(sender, "MouseUp", pmt);
        }

    }
}
