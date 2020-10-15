using MetroFramework;
using MetroFramework.Controls;
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
    public partial class Add_Statement2_Form : MetroFramework.Forms.MetroForm
    {
        public Add_Statement2_Form()
        {
            InitializeComponent();
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
            if(keyValues.ContainsKey("Председатель комиссии"))
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
            foreach(Control control in this.Controls)
            {
                if (control is MetroFramework.Controls.MetroComboBox && ((MetroComboBox)control).Items.Count == 0)
                {
                    ((MetroComboBox)control).Text = ((MetroComboBox)control).Items[0].ToString();
                }
            }
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            //Добавление строки в табличку
            ListViewItem item = this.Table.Items.Add(this.Table_1.Text);
            
            //Добавление в строчку различных реквизитов(контролы реквизитов начинаются с "Table_", после "_" идет порядковый номер)
            for(byte a = 2; a <= 10; a++)
            {
                foreach (Control control in this.Controls)
                {
                    if (control.Name == "Table_" + a)
                    {
                        if (string.IsNullOrEmpty(control.Text))
                        {
                            MetroMessageBox.Show(this, "Необходимо заполнить все поля!");
                            item.Remove();
                            return;
                        }

                        item.SubItems.Add(control.Text);
                    }
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if(this.Table.Items.Count == 0)
            {
                DialogResult result = MetroMessageBox.Show(this, "Вы точно хотите сохранить ведомость? Табличная часть пуста", "Внимание", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;

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

                newStatement.AppendTabularPart(this.Table.Items, this.Table.Columns);
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
        }

        private FormWindowState PrevState;
        private void Add_Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                Add_Form_ResizeEnd(null, null);
            else if(PrevState == FormWindowState.Maximized && this.WindowState == FormWindowState.Normal)
                Add_Form_ResizeEnd(null, null);

            PrevState = this.WindowState;
        }
    }
}
