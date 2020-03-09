using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsBindingMultiRowCs
{
    public partial class View_Form : Form
    {
        private DataSet _ds;

        public DialogResult ShowDialog(Form owner, DataSet ds)
        {
            _ds = ds;
            return base.ShowDialog(owner);
        }

        public View_Form()
        {
            InitializeComponent();
        }

        private void Me_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (DataRow row in _ds.Tables[0].Rows)
                {
                    String StateValue = "";
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            StateValue = "Added";
                            break;
                        case DataRowState.Deleted:
                            StateValue = "Deleted";
                            break;
                        case DataRowState.Detached:
                            StateValue = "Detached";
                            break;
                        case DataRowState.Modified:
                            StateValue = "Modified";
                            break;
                        case DataRowState.Unchanged:
                            StateValue = "Unchanged";
                            break;
                        default:
                            break;
                    }
                    this.View_ListBox.Items.Add(StateValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
