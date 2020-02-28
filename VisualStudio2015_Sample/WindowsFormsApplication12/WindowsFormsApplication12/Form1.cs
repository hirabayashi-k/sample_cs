using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.RowCount = 10;
            dataGridView1.ColumnCount = 15;

            dataGridView1.RowHeadersWidth = 10;

            int i0;
            for (i0 = 0; i0 < dataGridView1.ColumnCount; i0++)
            {
                dataGridView1.Columns[i0].Width = 20;
            }

            // add row
            dataGridView1.AllowUserToAddRows = false;

            // cell size fixed
            //sg.AllowUserToResizeColumns = false;
            //sg.AllowUserToResizeRows = false;

            // header size fixed
            //sg.ColumnHeadersHeightSizeMode =
            //    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //sg.RowHeadersWidthSizeMode =
            //    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // headselect disable
            //dataGridView1.SelectionBlockOptions = SelectionBlockOptions.Cells;

            // Visual style
            //sg.EnableHeadersVisualStyles = false;

            // color
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Gray;

            // select mode
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // sort false
            foreach (DataGridViewColumn c in dataGridView1.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            // edit disable
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

        }
    }
}
