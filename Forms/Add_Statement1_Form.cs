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
    public partial class Add_Statement1_Form : MetroFramework.Forms.MetroForm
    {
        public Statement1 Statement;
        

        public Add_Statement1_Form()
        {
            InitializeComponent();
        }

        private void Add_Statement1_Form_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Statement1_AddToTable Form = new Statement1_AddToTable();
            Form.ShowDialog();

            if (string.IsNullOrEmpty(Form.TextBox_FIO.Text))
            {
                return;
            }

            if (Form.metroListView1.Items.Count != 0)
            {
                if(Statement == null)
                {
                    Statement = new Statement1(
                        Statement1.Statement1_Document.DocumentElement,
                        this.ComboBox_Education.Text,
                        this.TextBox_Info.Text,
                        this.ComboBox_Specialty.Text,
                        this.ComboBox_SpecialityDirection.Text,
                        this.ComboBox_Specialization.Text,
                        this.ComboBox_Qualification.Text,
                        this.ComboBox_Group.Text
                        );


                }


                Row[] rows = new Row[8];
            }

        }
    }
}
