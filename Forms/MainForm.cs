using System;
using System.Xml;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

using MetroFramework;
using DataBase.Forms;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace DataBase
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region События формы
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroStyleManager1.Theme == MetroThemeStyle.Light)
            {
                this.metroStyleManager1.Theme = MetroThemeStyle.Dark;
                this.metroButton1      .Theme = MetroThemeStyle.Dark;
                this.Export            .Theme = MetroThemeStyle.Dark;
                this.Show              .Theme = MetroThemeStyle.Dark;
                this.Add               .Theme = MetroThemeStyle.Dark;
                this                   .Theme = MetroThemeStyle.Dark;
            }
            else
            {
                this.metroStyleManager1.Theme = MetroThemeStyle.Light;
                this.metroButton1      .Theme = MetroThemeStyle.Light;
                this.Export            .Theme = MetroThemeStyle.Light;
                this.Show              .Theme = MetroThemeStyle.Light;
                this.Add               .Theme = MetroThemeStyle.Light;
                this                   .Theme = MetroThemeStyle.Light;
            }

            this.UpdateStyles();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            new Settings_Form().ShowDialog();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Select_Statement Selector = new Select_Statement();
            Selector.ShowDialog();

            if (!string.IsNullOrEmpty(Selector.number))
            {
                if (Selector.number == "1")
                {
                    new Statement1_Form().ShowDialog();
                }
                else
                {
                    new Statement2_Form().ShowDialog();
                }
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            new SetExport_Form().ShowDialog();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            new Show_Form().ShowDialog();
        }
        #endregion
    }

    
}