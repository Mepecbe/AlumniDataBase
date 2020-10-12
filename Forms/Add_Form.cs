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
    public partial class Add_Form : MetroFramework.Forms.MetroForm
    {
        public Add_Form()
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
                this.metroComboBox1.Items.AddRange(keyValues["Наименование УО"].ToArray());
            }

            //Председатель комиссии
            if(keyValues.ContainsKey("Председатель комиссии"))
                this.metroComboBox7.Items.AddRange(keyValues["Председатель комиссии"].ToArray());

            //Заместитель председателя
            if (keyValues.ContainsKey("Заместитель председателя"))
                this.metroComboBox8.Items.AddRange(keyValues["Заместитель председателя"].ToArray());

            //Члены комиссии
            if (keyValues.ContainsKey("Член комиссии"))
            {
                this.metroComboBox9.Items.AddRange(keyValues["Член комиссии"].ToArray());
                this.metroComboBox10.Items.AddRange(keyValues["Член комиссии"].ToArray());
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
            ListViewItem item = this.metroListView1.Items.Add(this.Table_1.Text);
            
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
            if(this.metroListView1.Items.Count == 0)
            {
                DialogResult result = MetroMessageBox.Show(this, "Вы точно хотите сохранить ведомость? Табличная часть пуста", "Внимание", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;

                
            }
        }
    }
}
