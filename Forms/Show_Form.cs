using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Statement2[] statements = Statement2.GetStatements2FromDocument();

            foreach(Statement2 statement in statements)
            {
                ListViewItem item = metroListView2.Items.Add(statement.Year.ToString());
                item.SubItems.Add(statement.codeAndSpecialityName);
                item.SubItems.Add(statement.getTabularPart().ChildNodes.Count.ToString()); //Количество потомков в "элементе" таблицы(потомки - строки)
            }

            this.metroListView2.Columns[0].Width = 100;
            this.metroListView2.Columns[2].Width = 250;
            Show_Form_ResizeEnd(null, null);
        }

        private void Show_Form_ResizeEnd(object sender, EventArgs e)
        {
            //Размеры 2-ой колонки таблицы распределения выпускников
            var size = this.metroListView2.Width - this.metroListView2.Columns[0].Width - this.metroListView2.Columns[2].Width - 7;
            this.metroListView2.Columns[1].Width = size;
        }


        FormWindowState prevState;
        private void Show_Form_Resize(object sender, EventArgs e)
        {
            if(prevState == FormWindowState.Normal || prevState == FormWindowState.Maximized)
                Show_Form_ResizeEnd(null, null);

            prevState = this.WindowState;
        }
    }
}
