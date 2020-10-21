using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DataBase.Forms
{
    public partial class Add_Statement1_Form : MetroFramework.Forms.MetroForm
    {
        public Statement1 Statement;
        
        public Add_Statement1_Form()
        {
            InitializeComponent();
        }

        public Add_Statement1_Form(Statement1 statement)
        {
            throw new NotImplementedException();
        }

        private void Add_Statement1_Form_Load(object sender, EventArgs e)
        {
            /***** Добавление "Вариантов выбора" *****/

            Dictionary<string, List<string>> keyValues = Config.GetValues();

            //Наименование учреждения образования
            if (keyValues.ContainsKey("Наименование УО"))
            {
                this.ComboBox_Education.Items.AddRange(keyValues["Наименование УО"].ToArray());
            }

            //Специальность
            if (keyValues.ContainsKey("Специальность"))
            {
                this.ComboBox_Specialty.Items.AddRange(keyValues["Специальность"].ToArray());
            }

            //Направление специальности
            if (keyValues.ContainsKey("Направление специальности"))
            {
                this.ComboBox_SpecialtyDirection.Items.AddRange(keyValues["Направление специальности"].ToArray());
            }

            //Специализация
            if (keyValues.ContainsKey("Специализация"))
            {
                this.ComboBox_Specialization.Items.AddRange(keyValues["Специализация"].ToArray());
            }

            //Квалификация
            if (keyValues.ContainsKey("Квалификация"))
            {
                this.ComboBox_Qualification.Items.AddRange(keyValues["Квалификация"].ToArray());
            }

            //Группа
            if (keyValues.ContainsKey("Группа"))
            {
                this.ComboBox_Group.Items.AddRange(keyValues["Группа"].ToArray());
            }
            /**/

            //Выставление значений по умолчанию
            foreach (Control control in this.Controls)
            {
                if (control is MetroFramework.Controls.MetroComboBox && ((MetroFramework.Controls.MetroComboBox)control).Items.Count != 0)
                {
                    ((MetroFramework.Controls.MetroComboBox)control).Text = ((MetroFramework.Controls.MetroComboBox)control).Items[0].ToString();
                }
            }
        }
         
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statement1_AddToTable Form = new Statement1_AddToTable();
            Form.ShowDialog();


            //Если ведомость ещё не была создана, то создаем
            if (Statement == null)
            {
                Statement = new Statement1(
                    Statement1.Statement1_Document.DocumentElement,
                    this.ComboBox_Education.Text,
                    this.TextBox_Info.Text,
                    this.ComboBox_Specialty.Text,
                    this.ComboBox_SpecialtyDirection.Text,
                    this.ComboBox_Specialization.Text,
                    this.ComboBox_Qualification.Text,
                    this.ComboBox_Group.Text
                    );
            }

            if (string.IsNullOrEmpty(Form.TextBox_FIO.Text))
            {
                return;
            }

            if (Form.metroListView1.Items.Count != 0)
            {
                ListViewItem item = this.metroListView1.Items.Add(Form.TextBox_FIO.Text);

                Row newRow = Statement.AppendRow(Form.TextBox_FIO.Text);

                for (int index = 0; index < Form.metroListView1.Items.Count; index++)
                {
                    newRow.Append_InformationForTheYear(
                        Form.metroListView1.Items[index].SubItems[0].Text,
                        Form.metroListView1.Items[index].SubItems[1].Text,
                        Form.metroListView1.Items[index].SubItems[2].Text,
                        Form.metroListView1.Items[index].SubItems[3].Text
                    );
                }
            }
        }

        private void удалитьВыбранноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.metroListView1.Items)
            {
                item.Remove();
            }
        }

        FormWindowState PrevState;
        private void Add_Statement1_Form_Resize(object sender, EventArgs e)
        {
            if(PrevState == FormWindowState.Normal && this.WindowState == FormWindowState.Maximized)
            {
                TryResize();
            }
            else if(PrevState == FormWindowState.Maximized)
            {
                TryResize();
            }

            PrevState = this.WindowState;
        }

        private void Add_Statement1_Form_ResizeEnd(object sender, EventArgs e)
        {
            TryResize();
        }

        private void TryResize()
        {
            int CellSize = (this.metroListView1.Width / this.metroListView1.Columns.Count) - 2;

            for (byte index = 0; index < this.metroListView1.Columns.Count; index++)
            {
                this.metroListView1.Columns[index].Width = CellSize;
            }

            this.metroListView1.Height = this.Height - this.metroButton1.Location.Y - this.metroButton1.Height - 30;
        }
    }
}
