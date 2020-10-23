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
        public Statement1_Row Row;

        public Statement1_AddToTable(Statement1_Row row)
        {
            InitializeComponent();
            Statement1_AddToTable_ResizeEnd(null, null);

            this.Row = row;

            this.TextBox_FIO.Text = this.Row.FIO;

            foreach(InformationForTheYear Info in this.Row.GetAllInformation())
            {
                ListViewItem item = this.metroListView1.Items.Add(Info.Year.ToString());
                item.SubItems.Add(Info.Organization);
                item.SubItems.Add(Info.Position);
                item.SubItems.Add(Info.Note);

                item.Tag = Info;
            }
        }

        /// <summary>
        /// Добавление нового элемента("Информация за год")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton1_Click(object sender, EventArgs e)
        {
            InformationForTheYear NewInfo = this.Row.Append_InformationForTheYear();

            ListViewItem item = this.metroListView1.Items.Add(this.TextBox_Year.Text);
            item.SubItems.Add(this.TextBox_Organization.Text);
            item.SubItems.Add(this.TextBox_Position.Text);
            item.SubItems.Add(this.TextBox_Note.Text);
            item.Tag = NewInfo;

            NewInfo.Year = Convert.ToUInt16(this.TextBox_Year.Text);
            NewInfo.Organization = this.TextBox_Organization.Text;
            NewInfo.Position = this.TextBox_Position.Text;
            NewInfo.Note = this.TextBox_Note.Text;
        }

        private void удалитьВыбранноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.metroListView1.SelectedItems)
            {
                if(this.Row != null)
                {
                    this.Row.RowElement.RemoveChild(((InformationForTheYear)(item.Tag)).Element);
                    Statement1.Statement1_Document.Save(Config.Statement1_Path);
                }

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
            this.Row.FIO = this.TextBox_FIO.Text;
        }

        public ListViewItem SelectedItem;
        private void изменитьВыбранноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.metroListView1.SelectedItems.Count > 0)
            {
                SelectedItem = this.metroListView1.SelectedItems[0];

                this.TextBox_Year.Text         = SelectedItem.SubItems[0].Text;
                this.TextBox_Organization.Text = SelectedItem.SubItems[1].Text;
                this.TextBox_Position.Text     = SelectedItem.SubItems[2].Text;
                this.TextBox_Note.Text         = SelectedItem.SubItems[3].Text;

                this.Edit_Button.Visible = true;
            }
        }


        /// <summary>
        /// Закончить редактирование
        /// </summary>
        private void metroButton2_Click(object sender, EventArgs e)
        {
            SelectedItem.SubItems[0].Text = this.TextBox_Year.Text;
            SelectedItem.SubItems[1].Text = this.TextBox_Organization.Text;
            SelectedItem.SubItems[2].Text = this.TextBox_Position.Text;
            SelectedItem.SubItems[3].Text = this.TextBox_Note.Text;

            InformationForTheYear info = (InformationForTheYear)SelectedItem.Tag;
            info.Year = Convert.ToUInt16(this.TextBox_Year.Text);
            info.Organization = this.TextBox_Organization.Text;            info.Position = this.TextBox_Position.Text;
            info.Note = this.TextBox_Note.Text;

            this.TextBox_Year.Text= "";
            this.TextBox_Organization.Text = "";
            this.TextBox_Position.Text = "";
            this.TextBox_Note.Text = "";

            SelectedItem = null;
            this.Edit_Button.Visible = false;
        }
    }
}
