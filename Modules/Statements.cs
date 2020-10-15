using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Configuration;

namespace DataBase
{
    /// <summary>
    /// Ведомость распределения выпускников
    /// </summary>
    public class Statement2
    {
        #region Статические поля, методы, конструкторы
        public static XmlDocument Statement2_Document = new XmlDocument();

        static Statement2()
        {
            Statement2_Document.Load(Config.Statement2_Path);
        }

        /// <summary>
        /// Получить все ведомости из документа XML
        /// </summary>
        /// <returns></returns>
        public static Statement2[] GetStatements2FromDocument()
        {
            List<Statement2> Statements = new List<Statement2>();
            foreach (XmlElement statement in Statement2_Document.DocumentElement)
            {
                Statements.Add(new Statement2(statement));
            }

            return Statements.ToArray();
        }

        /// <summary>
        /// Удалить ведомость из документа
        /// </summary>
        /// <param name="statement">XML Элемент представляющий ведомость</param>
        public static void DeleteStatementFromDocument(XmlElement statement)
        {
            Statement2_Document.DocumentElement.RemoveChild(statement);
        }

        /// <summary>
        /// Получить ведомость по уникальному ключу
        /// </summary>
        /// <param name="key">Уникальный ключ</param>
        /// <returns>Ведомость</returns>
        public static Statement2 GetStatementByUniqueKey(string key)
        {
            Statement2[] statements = Statement2.GetStatements2FromDocument();

            foreach (Statement2 st in statements)
            {
                if (st.UniqueKey == key)
                {
                    return st;
                }
            }

            throw new Exception("Statement not found");
        }
        #endregion
        #region Конструкторы класса
        /// <summary>
        /// Элемент, представляющий ведомость в XML
        /// </summary>
        public XmlElement StatementInXml;

        /// <summary>
        /// "Загрузить" ведомость из XML элемента
        /// </summary>
        /// <param name="StatementElement">Элемент ведомости</param>
        public Statement2(XmlElement StatementElement)
        {
            this.StatementInXml = StatementElement;
        }

        /// <summary>
        ///  Создать и сохранить ведомость
        /// </summary>
        /// <param name="document">Документ XML</param>
        /// <param name="In">Элемент, в который будет вложен элемент ведомости</param>
        /// <param name="year">год ведомости</param>
        /// <param name="EducationalInstitution">Учреждение образования</param>
        /// <param name="codeAndSpecialityName">Код и наименование специальности</param>
        /// <param name="chairman">Председатель</param>
        /// <param name="deputy">Заместитель</param>
        /// <param name="CommissionMember1">Член комиссии</param>
        /// <param name="CommissionMember2">Член комиссии</param>
        public Statement2(XmlElement In,
                          System.UInt16 year = 0,
                          string EducationalInstitution = "",
                          string codeAndSpecialityName = "",
                          string chairman = "",
                          string deputy = "",
                          string CommissionMember1 = "",
                          string CommissionMember2 = ""
            )
        {
            //
            //Можно было всё очень сильно упростить, если передавать параметры(атрибуты) ведомости с помощью словаря
            // но я уже вот так сделал
            //
            this.StatementInXml = Statement2_Document.CreateElement("statement");
            In.AppendChild(this.StatementInXml);

            XmlAttribute Attr_UniqueKey = Statement2_Document.CreateAttribute("UniqueKey");
            Attr_UniqueKey.Value = Config.GenKey();
            
            XmlAttribute Attr_year = Statement2_Document.CreateAttribute("year");
            Attr_year.Value = year.ToString();

            XmlAttribute Attr_EducationalInstitution = Statement2_Document.CreateAttribute("EducationalInstitution");
            Attr_EducationalInstitution.Value = EducationalInstitution;

            XmlAttribute Attr_codeAndSpecialityName = Statement2_Document.CreateAttribute("codeAndSpecialityName");
            Attr_codeAndSpecialityName.Value = codeAndSpecialityName;

            XmlAttribute Attr_chairman = Statement2_Document.CreateAttribute("chairman");
            Attr_chairman.Value = chairman;

            XmlAttribute Attr_deputy = Statement2_Document.CreateAttribute("deputy");
            Attr_deputy.Value = deputy;

            XmlAttribute Attr_CommissionMember1 = Statement2_Document.CreateAttribute("CommissionMember1");
            Attr_CommissionMember1.Value = CommissionMember1;

            XmlAttribute Attr_CommissionMember2 = Statement2_Document.CreateAttribute("CommissionMember2");
            Attr_CommissionMember2.Value = CommissionMember2;

            this.StatementInXml.Attributes.Append(Attr_UniqueKey);
            this.StatementInXml.Attributes.Append(Attr_year);
            this.StatementInXml.Attributes.Append(Attr_EducationalInstitution);
            this.StatementInXml.Attributes.Append(Attr_codeAndSpecialityName);
            this.StatementInXml.Attributes.Append(Attr_chairman);
            this.StatementInXml.Attributes.Append(Attr_deputy);
            this.StatementInXml.Attributes.Append(Attr_CommissionMember1);
            this.StatementInXml.Attributes.Append(Attr_CommissionMember2);

            XmlElement TabularPart = Statement2_Document.CreateElement("TabularPart");
            this.StatementInXml.AppendChild(TabularPart);

            Statement2_Document.Save(Config.Statement2_Path);
        }
        #endregion
        #region Поля Ведомости

        /// <summary>
        /// Уникальный ключ(идентификатор) ведомости
        /// </summary>
        public string UniqueKey
        {
            get { return this.StatementInXml.Attributes["UniqueKey"].Value;  }
            set { this.StatementInXml.Attributes["UniqueKey"].Value = value; }
        }

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
        public string EducationalInstitution
        {
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
        #endregion
        #region Методы класса
        /// <summary>
        /// По имени ищет XmlElement среди потомков элемента, передаваемого в параметре
        /// </summary>
        /// <param name="element">Элемент, среди потомков которого будет производится поиск</param>
        /// <param name="name">Название элемента</param>
        /// <returns></returns>
        public XmlElement getElementByName(XmlElement element, string name)
        {
            foreach (XmlElement elem in element.ChildNodes)
            {
                if (elem.Name == name)
                    return elem;
            }

            return null;
        }

        /// <summary>
        /// Возвращает табличную часть
        /// </summary>
        /// <returns></returns>
        public XmlElement getTabularPart()
        {
            return getElementByName(this.StatementInXml, "TabularPart");
        }

        /// <summary>
        /// Вставить в документ и сохранить
        /// </summary>
        /// <param name="document"></param>
        public void AppendAndSaveStatementInDocument(XmlDocument document)
        {
            document.DocumentElement.AppendChild(this.StatementInXml);
        }

        public void AppendTabularPart(ListView.ListViewItemCollection items, ListView.ColumnHeaderCollection columns)
        {
            XmlElement TabularPart = getTabularPart();

            for (int row = 0; row < items.Count; row++)
            {
                XmlElement TableRow = Statement2_Document.CreateElement("row");
                TabularPart.AppendChild(TableRow);

                for (byte column = 0; column < items[0].SubItems.Count; column++)
                {
                    XmlElement XmlColumn = Statement2_Document.CreateElement(columns[column].Tag.ToString());
                    XmlColumn.InnerText = items[row].SubItems[column].Text;
                    TableRow.AppendChild(XmlColumn);
                }
            }

            Statement2_Document.Save(Config.Statement2_Path);
        }
        #endregion
    }
}
