using System;
using System.Xml;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

using MetroFramework;
using DataBase.Forms;

namespace DataBase
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public static string FILE_NAME = "D:\\Db.xml";

        public MainForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroStyleManager1.Theme == MetroThemeStyle.Light)
            {
                this.metroStyleManager1.Theme = MetroThemeStyle.Dark;
                this.metroButton1      .Theme = MetroThemeStyle.Dark;
                this.Export            .Theme = MetroThemeStyle.Dark;
                this.Show              .Theme = MetroThemeStyle.Dark;
                this.Edit              .Theme = MetroThemeStyle.Dark;
                this.Add               .Theme = MetroThemeStyle.Dark;
                this                   .Theme = MetroThemeStyle.Dark;
            }
            else
            {
                this.metroStyleManager1.Theme = MetroThemeStyle.Light;
                this.metroButton1      .Theme = MetroThemeStyle.Light;
                this.Export            .Theme = MetroThemeStyle.Light;
                this.Show              .Theme = MetroThemeStyle.Light;
                this.Edit              .Theme = MetroThemeStyle.Light;
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
            new Add_Form().ShowDialog();
        }
    }


    /*
    /// <summary>
    /// Ведомость персонального учета выпускников
    /// </summary>
    public class Statement1
    {
        public readonly string EducationalInstitution;
        public readonly System.UInt16 Year;
        public readonly string Info;
        public readonly string Speciality;
        public readonly string SpecialtyDirection;
        public readonly string Specialization;
        public readonly string Qualification;
        public readonly string Group;

        /// <summary>
        /// Строки таблицы
        /// </summary>
        public Row TableRows;

        /// <summary>
        /// Экземпляр строки
        /// </summary>
        public class Row
        {
            public string FIO;
            /// <summary>
            /// Информация за годы
            /// </summary>
            public InformationForTheYear[] InformationOverTheYears;
        }

        /// <summary>
        /// Информация за 1 год
        /// </summary>
        public class InformationForTheYear
        {
            public string OrganizationName;
            public string Position;
            public string Note;
        }
    }*/


    /// <summary>
    /// Ведомость распределения выпускников
    /// </summary>
    public class Statement2
    {
        public XmlElement StatementInXml;

        /// <summary>
        /// Год ведомости
        /// </summary>
        public System.UInt16 Year
        {
            get { return Convert.ToUInt16(this.StatementInXml.Attributes["year"].Value); }
            set { this.StatementInXml.Attributes["year"].Value = value.ToString(); }
        }

        /// <summary>
        /// Учреждение образования
        /// </summary>
        public string EducationalInstitution { 
            get { return this.StatementInXml.Attributes["EducationalInstitution"].Value; } 
            set { this.StatementInXml.Attributes["EducationalInstitution"].Value = value; } 
        }

        /// <summary>
        /// Код и наименование специальности
        /// </summary>
        public string codeAndSpecialityName
        {
            get { return this.StatementInXml.Attributes["codeAndSpecialityName"].Value; }
            set { this.StatementInXml.Attributes["codeAndSpecialityName"].Value = value; }
        }

        /// <summary>
        /// Председатель комиссии
        /// </summary>
        public string chairman
        {
            get { return this.StatementInXml.Attributes["chairman"].Value; }
            set { this.StatementInXml.Attributes["chairman"].Value = value; }
        }

        /// <summary>
        /// Заместитель
        /// </summary>
        public string deputy
        {
            get { return this.StatementInXml.Attributes["deputy"].Value; }
            set { this.StatementInXml.Attributes["deputy"].Value = value; }
        }

        /// <summary>
        /// Первый член комисии
        /// </summary>
        public string CommissionMember1
        {
            get { return this.StatementInXml.Attributes["CommissionMember1"].Value; }
            set { this.StatementInXml.Attributes["CommissionMember1"].Value = value; }
        }

        /// <summary>
        /// Второй член комисии
        /// </summary>
        public string CommissionMember2
        {
            get { return this.StatementInXml.Attributes["CommissionMember2"].Value; }
            set { this.StatementInXml.Attributes["CommissionMember2"].Value = value; }
        }

        
    }
}
