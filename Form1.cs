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

namespace DataBase
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
    }




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
        public Row TableRow;

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
    }
}
