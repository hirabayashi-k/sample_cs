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
    public partial class BindingMultiRow_Form : Form
    {
        private string DataFileName = System.IO.Path.Combine(Application.StartupPath, "data.xml");
        private DataSet Ds = new DataSet();

        public BindingMultiRow_Form()
        {
            InitializeComponent();
        }

        private void Me_Load(object sender, EventArgs e)
        {

            this.List_DataGridView.AutoGenerateColumns = false;
            {
                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.DataPropertyName = "日付";
                textColumn.Name = "公開日";
                textColumn.HeaderText = "公開日";
                this.List_DataGridView.Columns.Add(textColumn);
            }
            {
                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.DataPropertyName = "タイトル";
                textColumn.Name = "件名";
                textColumn.HeaderText = "件名";
                this.List_DataGridView.Columns.Add(textColumn);
            }
        }

        private void FileOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ds.Tables.Clear();
            Ds.ReadXml(DataFileName);
            Ds.Tables["data"].AcceptChanges();
            this.List_DataGridView.DataSource = Ds;
            this.List_DataGridView.DataMember = "data";
            {
                this.DebugViewToolStripMenuItem.Enabled = true;
                this.FileSaveToolStripMenuItem.Enabled = true;
            }
        }

        private void FileSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ds.WriteXml(DataFileName);
            Ds.AcceptChanges();
        }

        private void FileExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DebugViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (View_Form _dialog = new View_Form())
            {
                _dialog.ShowDialog(this, Ds);
            }
        }
    }
}
