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

using Tulpep.NotificationWindow;

namespace DataBase.Forms
{
    public partial class Statement1_Form : MetroFramework.Forms.MetroForm
    {
        public Statement1 Statement;

        public Statement1_Form()
        {
            InitializeComponent();
            this.TextBox_Year.Text = DateTime.Now.Year.ToString();
        }

        /// <summary>
        /// Форма для редактирования уже существующей ведомости
        /// </summary>
        /// <param name="statement"></param>
        public Statement1_Form(Statement1 statement)
        {
            InitializeComponent();
            this.Statement = statement;
            this.Text = "Редактирование существующей ведомости";

            //
            // Информация в контролы
            //

            this.TextBox_Year.Text = statement.Year.ToString();
            this.ComboBox_Education.Text = statement.EducationName;
            this.ComboBox_Group.Text = statement.EducationName;
            this.ComboBox_Qualification.Text = statement.EducationName;
            this.ComboBox_Specialization.Text = statement.EducationName;
            this.ComboBox_SpecialtyDirection.Text = statement.EducationName;
            this.ComboBox_Specialty.Text = statement.EducationName;
            this.TextBox_Info.Text = statement.InformationAboutGraduates;

            //
            // Табличная часть
            //

            for (int rowIndex = 0; rowIndex < this.Statement.TabularPart.Length; rowIndex++)
            {
                ListViewItem item = this.metroListView1.Items.Add(this.Statement.TabularPart[rowIndex].FIO);
                item.Tag = this.Statement.TabularPart[rowIndex];
            }
        }

        /// <summary>
        /// Загрузка формы(выставление значений по умолчанию)
        /// </summary>
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
            Statement1_AddToTable Form = new Statement1_AddToTable(new Statement1_Row());
            Form.ShowDialog();
            
            if (string.IsNullOrEmpty(Form.TextBox_FIO.Text))
            {
                return;
            }

            if (this.Statement != null)
            {
                //
                // Если редактируем ведомость, то сразу же добавляем строку в табличную часть
                //

                this.Statement.AppendRow(Form.Row);
            }

            if (Form.metroListView1.Items.Count != 0)
            {
                //
                // Добавление ITEM'ов в таблицу на форме
                //

                ListViewItem item = this.metroListView1.Items.Add(Form.TextBox_FIO.Text);
                item.Tag = Form.Row;
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

            this.metroListView1.Height = this.Height - this.metroButton1.Location.Y - this.metroButton1.Height - 60;
        }

        /// <summary>
        /// Сохранить ведомость
        /// </summary>
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (this.Statement != null)
            {
                //
                // Если форма была создана для редактирования ведомости
                //
                this.Statement.Year = Convert.ToUInt16(this.TextBox_Year.Text);
                this.Statement.EducationName = this.ComboBox_Education.Text;
                this.Statement.InformationAboutGraduates = this.TextBox_Info.Text;
                this.Statement.Specialty = this.ComboBox_Specialty.Text;
                this.Statement.SpecialtyDirection = this.ComboBox_SpecialtyDirection.Text;
                this.Statement.Specialization = this.ComboBox_Specialization.Text;
                this.Statement.Qualification = this.ComboBox_Qualification.Text;
                this.Statement.Group = this.ComboBox_Group.Text;
            }
            else {
                Statement1 newStatement = new Statement1(Statement1.Statement1_Document.DocumentElement,
                    this.TextBox_Year.Text,
                    this.ComboBox_Education.Text,
                    this.TextBox_Info.Text,
                    this.ComboBox_Specialty.Text,
                    this.ComboBox_SpecialtyDirection.Text,
                    this.ComboBox_Specialization.Text,
                    this.ComboBox_Qualification.Text,
                    this.ComboBox_Group.Text);

                //
                //  Табличная часть
                //

                foreach (ListViewItem item in this.metroListView1.Items)
                {
                    newStatement.AppendRow((Statement1_Row)item.Tag);
                }
            }

            new PopupNotifier()
            {
                TitleText = "База данных",
                ContentText = "Ведомость сохранена"
            }.Popup();

            Statement1.Statement1_Document.Save(Config.Statement1_Path);
            Save = true;
            this.Close();
        }


        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.metroListView1.SelectedItems.Count > 0)
            {
                Statement1_Row Row = (Statement1_Row)this.metroListView1.SelectedItems[0].Tag;
                Statement1_AddToTable form = new Statement1_AddToTable(Row);
                form.ShowDialog();

                this.metroListView1.SelectedItems[0].SubItems[0].Text = form.TextBox_FIO.Text;
            }
        }

        bool Save = false;
        private void Statement1_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Save && MetroFramework.MetroMessageBox.Show(this, "Сохранить все изменения?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                metroButton1_Click(null, null);
            }
        }
    }
}
