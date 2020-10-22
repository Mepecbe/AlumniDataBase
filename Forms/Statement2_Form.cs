using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tulpep.NotificationWindow;

namespace DataBase.Forms
{
    public partial class Statement2_Form : MetroFramework.Forms.MetroForm
    {
        //Если statement не null, то происходит редактирование уже сохраненного документа
        public Statement2 statement;

        public Statement2_Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Если ведомость уже существует, и форма открывается для редактирования
        /// </summary>
        /// <param name="statement"></param>
        public Statement2_Form(Statement2 statement)
        {
            InitializeComponent();

            this.statement = statement;
            this.Button_SaveStatement.Text = "Применить изменения";

            //
            // Установка значений
            //

            this.Year.Text = this.statement.Year.ToString();
            this.Education.Text = this.statement.EducationalInstitution;
            this.CodeAndName.Text = this.statement.codeAndSpecialityName;
            this.ChairMan.Text = this.statement.chairman;
            this.deputy.Text = this.statement.deputy;
            this.CommissionMember1.Text = this.CommissionMember1.Text;
            this.CommissionMember2.Text = this.CommissionMember2.Text;

            //
            // Табличная часть
            //

            foreach (Statement2_Row row in this.statement.TabularPart)
            {
                ListViewItem item = this.Table.Items.Add(row.Name);
                item.SubItems.Add(row.Sex);
                item.SubItems.Add(row.YearOfBirth);
                item.SubItems.Add(row.FamilyStatus);
                item.SubItems.Add(row.Address);
                item.SubItems.Add(row.GovernmentAgency);
                item.SubItems.Add(row.Organization);
                item.SubItems.Add(row.Position);
                item.SubItems.Add(row.m1);
                item.SubItems.Add(row.m2);
            }
        }


        private void Add_Form_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<string>> keyValues = Config.GetValues();

            this.Year.Text = DateTime.Now.Year.ToString();

            /***** Добавление "Вариантов выбора" *****/

            //Наименование учреждения образования
            if (keyValues.ContainsKey("Наименование УО"))
            {
                this.Education.Items.AddRange(keyValues["Наименование УО"].ToArray());
            }

            //Председатель комиссии
            if (keyValues.ContainsKey("Председатель комиссии"))
                this.ChairMan.Items.AddRange(keyValues["Председатель комиссии"].ToArray());

            //Заместитель председателя
            if (keyValues.ContainsKey("Заместитель председателя"))
                this.deputy.Items.AddRange(keyValues["Заместитель председателя"].ToArray());

            //Члены комиссии
            if (keyValues.ContainsKey("Член комиссии"))
            {
                this.CommissionMember1.Items.AddRange(keyValues["Член комиссии"].ToArray());
                this.CommissionMember2.Items.AddRange(keyValues["Член комиссии"].ToArray());
            }
            /**/

            //Выставление значений по умолчанию
            foreach (Control control in this.Controls)
            {
                if (control is MetroFramework.Controls.MetroComboBox && ((MetroComboBox)control).Items.Count != 0)
                {
                    ((MetroComboBox)control).Text = ((MetroComboBox)control).Items[0].ToString();
                }
            }

            Add_Form_ResizeEnd(null, null);
        }

        /// <summary>
        /// Добавление строки в табличную часть
        /// </summary>
        private void Add_button_Click(object sender, EventArgs e)
        {
            if (EditItem != null)
            {
#warning Отредактированное в таблице не будет сохраняться при редактировании документа
                //Если происходит редактирование ITEM'а в табличке
                this.AddToTable_button.Text = "Добавить в таблицу";

                for (byte number = 1; number <= 10; number++)
                {
                    if (this.Controls["Table_" + number.ToString()] is MetroFramework.Controls.MetroTextBox)
                    {
                        EditItem.SubItems[number - 1].Text = this.Controls["Table_" + number.ToString()].Text;
                        this.Controls["Table_" + number.ToString()].Text = "";
                    }
                    else if (this.Controls["Table_" + number.ToString()] is MetroFramework.Controls.MetroComboBox)
                    {
                        EditItem.SubItems[number - 1].Text = this.Controls["Table_" + number.ToString()].Text;
                    }
                }

                EditItem = null;
                this.Update();
                return;
            }

            if (this.statement != null)
            {
                //Если это редактирование уже готового документа, то сразу же добавляем в него новый Item
                Statement2_Row newRow = new Statement2_Row(
                    this.statement.getTabularPart(),
                    this.Table_1.Text,
                    this.Table_2.Text,
                    this.Table_3.Text,
                    this.Table_4.Text,
                    this.Table_5.Text,
                    this.Table_6.Text,
                    this.Table_7.Text,
                    this.Table_8.Text,
                    this.Table_9.Text,
                    this.Table_10.Text
                    );
            }

            
            {
                //Добавление в табличку на форме
                ListViewItem item = this.Table.Items.Add(this.Table_1.Text);

                //Добавление в строчку различных реквизитов(контролы реквизитов начинаются с "Table_", после "_" идет порядковый номер)
                for (byte number = 2; number <= 10; number++)
                {
#warning Можно оптимизировать, заменив перебор на прямое обращение к контролу по имени
                    foreach (Control control in this.Controls)
                    {
                        if (control.Name == "Table_" + number)
                        {
                            item.SubItems.Add(control.Text);

                            if (control is MetroFramework.Controls.MetroTextBox)
                                control.Text = "";
                        }
                    }
                }
            }

            
        }

        private void Add_Form_ResizeEnd(object sender, EventArgs e)
        {
            int width = (int)Math.Ceiling(
                Convert.ToSingle(this.Table.Width - this.Table.Columns[1].Width - this.Table.Columns[2].Width - this.Table.Columns[3].Width - this.Table.Columns[8].Width - this.Table.Columns[9].Width) / (this.Table.Columns.Count - 5)) - 2;

            for (byte index = 0; index < this.Table.Columns.Count; index++)
            {
                //Пропуск изменения ширины некоторых колонок 
                if (index == 1 || index == 2 || index == 3 || index == 8 || index == 9) continue;

                this.Table.Columns[index].Width = width;
            }

            //Размер ListView, по дефолту 1281; 456
            this.Table.Size = new Size(this.Table.Width, this.Height - this.AddToTable_button.Location.Y - this.AddToTable_button.Size.Height - 25);
        }

        private FormWindowState PrevState;
        private void Add_Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                Add_Form_ResizeEnd(null, null);
            else if (PrevState == FormWindowState.Maximized && this.WindowState == FormWindowState.Normal)
                Add_Form_ResizeEnd(null, null);

            PrevState = this.WindowState;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (ListViewItem item in this.Table.SelectedItems)
            {
                item.Remove();
            }
        }


        /// <summary>
        /// Сохранить ведомость
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClickSaveStatement(object sender, EventArgs e)
        {
            if (((Control)(sender)).Text == "Применить изменения")
            {
                statement.EducationalInstitution = this.Education.Text;
                statement.codeAndSpecialityName = this.CodeAndName.Text;
                statement.chairman = this.ChairMan.Text;
                statement.deputy = this.deputy.Text;
                statement.CommissionMember1 = this.CommissionMember1.Text;
                statement.CommissionMember2 = this.CommissionMember2.Text;

                Statement2.Statement2_Document.Save(Config.Statement2_Path);
            }
            else
            {
                Statement2 newStatement = new Statement2(
                    Statement2.Statement2_Document.DocumentElement,
                    Convert.ToUInt16(this.Year.Text),
                    this.Education.Text,
                    this.CodeAndName.Text,
                    this.ChairMan.Text,
                    this.deputy.Text,
                    this.CommissionMember1.Text,
                    this.CommissionMember2.Text
                    );

                if (this.Table.Items.Count != 0)
                {
                    newStatement.AppendTabularPart(this.Table.Items, this.Table.Columns);
                }
            }

            new PopupNotifier()
            {
                TitleText = "База данных",
                ContentText = "Ведомость сохранена"
            }.Popup();

            this.Close();
        }


        ListViewItem EditItem;
        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Table.SelectedItems.Count > 0)
            {
                EditItem = this.Table.SelectedItems[0];

                for (byte number = 1; number <= 10; number++)
                {
                    if (this.Controls["Table_" + number.ToString()] is MetroFramework.Controls.MetroTextBox)
                    {
                        this.Controls["Table_" + number.ToString()].Text = EditItem.SubItems[number - 1].Text;
                    }
                    else if (this.Controls["Table_" + number.ToString()] is MetroFramework.Controls.MetroComboBox)
                    {
                        this.Controls["Table_" + number.ToString()].Text = EditItem.SubItems[number - 1].Text;
                    }
                }

                this.AddToTable_button.Text = "Завершить редактирование";
            }
        }
    }
}
