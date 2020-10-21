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
    public partial class Select_Statement : MetroFramework.Forms.MetroForm
    {
        public string number;

        public Select_Statement()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.number = ((MetroFramework.Controls.MetroTile)sender).Tag.ToString();
            this.Close();
        }
    }
}
