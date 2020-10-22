using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using Microsoft.Office.Interop.Word;
using DataBase.Modules;

namespace DataBase.Forms
{
    public partial class Show_Form : MetroFramework.Forms.MetroForm
    {
        public Show_Form()
        {
            InitializeComponent();
        }

        private void Show_Form_Shown(object sender, EventArgs e)
        {
            //
            // Вывод списка ведомостей персонального учета
            //

            Statement1[] statements1 = Statement1.GetStatementsFromDocument();

            foreach (Statement1 statement in statements1)
            {
                ListViewItem item = metroListView1.Items.Add(statement.Year.ToString());
                item.Tag = statement.UniqueKey;
                item.SubItems.Add(statement.Group.ToString());
                item.SubItems.Add(statement.getTabularPart().ChildNodes.Count.ToString()); //Количество потомков в "элементе" таблицы(потомки - строки)
            }

            this.metroListView2.Columns[1].Width = 100;
            this.metroListView2.Columns[2].Width = 250;

            Show_Form_ResizeEnd(null, null);


            //
            // Вывод списка ведомостей распределения
            //

            Statement2[] statements = Statement2.GetStatements2FromDocument();

            foreach(Statement2 statement in statements)
            {
                ListViewItem item = metroListView2.Items.Add(statement.codeAndSpecialityName);
                item.Tag = statement.UniqueKey;
                item.SubItems.Add(statement.Year.ToString());
                item.SubItems.Add(statement.getTabularPart().ChildNodes.Count.ToString()); //Количество потомков в "элементе" таблицы(потомки - строки)
            }

            this.metroListView2.Columns[1].Width = 100;
            this.metroListView2.Columns[2].Width = 250;

            Show_Form_ResizeEnd(null, null);
        }

        private void Show_Form_ResizeEnd(object sender, EventArgs e)
        {
            //Размеры 2-ой колонки таблицы распределения выпускников
            var size = this.metroListView2.Width - this.metroListView2.Columns[1].Width - this.metroListView2.Columns[2].Width - 7;
            this.metroListView2.Columns[0].Width = size;
        }


        FormWindowState prevState;
        private void Show_Form_Resize(object sender, EventArgs e)
        {
            if(prevState == FormWindowState.Normal || prevState == FormWindowState.Maximized)
                Show_Form_ResizeEnd(null, null);

            prevState = this.WindowState;
        }

        private void печатьВедомостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (metroListView2.SelectedItems.Count == 0) return;

            Statement2 SelectedStatement = Statement2.GetStatementByUniqueKey(metroListView2.SelectedItems[0].Tag.ToString());

            DocumentBuilder.BuildStatement2(SelectedStatement);
        }

        private void редактированиеВедомостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (metroListView2.SelectedItems.Count > 0)
            {
                new Statement2_Form( Statement2.GetStatementByUniqueKey(metroListView2.SelectedItems[0].Tag.ToString()) ).Show();
            }
        }
    }
}
