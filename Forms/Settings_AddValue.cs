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
    public partial class Settings_AddValue : MetroFramework.Forms.MetroForm
    {
        public string[] values;
        public Settings_AddValue()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TypeComboBox.Text) || string.IsNullOrEmpty(this.valueTextBox.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Необходимо заполнить поля");
                return;
            }

            values = new string[]{ this.TypeComboBox.Text, this.valueTextBox.Text};
            this.Close();
        }
    }
}
