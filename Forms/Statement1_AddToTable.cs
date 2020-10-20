using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase.Forms
{
    public partial class Statement1_AddToTable : MetroFramework.Forms.MetroForm
    {
        public Statement1_AddToTable()
        {
            InitializeComponent();
            Statement1_AddToTable_ResizeEnd(null, null);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.metroListView1.Items.Add(this.TextBox_Year.Text);
            item.SubItems.Add(this.TextBox_Organization.Text);
            item.SubItems.Add(this.TextBox_Position.Text);
            item.SubItems.Add(this.TextBox_Note.Text);

        }

        private void удалитьВыбранноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.metroListView1.SelectedItems)
            {
                item.Remove();
            }
        }

        private void Statement1_AddToTable_ResizeEnd(object sender, EventArgs e)
        {
            int CellWidth = (this.metroListView1.Width / this.metroListView1.Columns.Count) - 1;

            for (int index = 0; index < this.metroListView1.Columns.Count; index++)
            {
                this.metroListView1.Columns[index].Width = CellWidth;
            }

            this.metroListView1.Height = this.Height - this.metroButton1.Location.Y - 78;
        }

        private void Statement1_AddToTable_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
