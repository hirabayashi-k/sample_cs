using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NADMS_DLL_CALL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try { 

                LocalDB_lan_Cs.LocalDB_lan_DLL cs = new LocalDB_lan_Cs.LocalDB_lan_DLL();


                int i = cs.LanConnectInit("192.168.11.1", "NADMS_Z");

                MessageBox.Show(string.Format("戻り値:{0}",i), "初期化", MessageBoxButtons.OK, MessageBoxIcon.None);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}
