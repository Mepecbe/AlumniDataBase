using System;
using System.IO;
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
    /// Ведомость персонального учета выпускников
    /// </summary>
    public class Statement1
    {
        /// <summary>
        /// Элемент, представляющий ведомость в XML
        /// </summary>
        public XmlElement StatementInXml;

        #region Статические поля, методы, конструкторы
        public static XmlDocument Statement1_Document = new XmlDocument();
        static Statement1()
        {
            if (!File.Exists(Config.Statement1_Path))
            {
                StreamWriter writer = new StreamWriter(File.Create(Config.Statement1_Path));
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?> " +
                    $"<statements> </statements>");

                writer.Close();
            }

            Statement1_Document.Load(Config.Statement1_Path);
        }

        /// <summary>
        /// Получить все ведомости из документа XML
        /// </summary>
        /// <returns></returns>
        public static Statement1[] GetStatementsFromDocument()
        {
            List<Statement1> Statements = new List<Statement1>();
            foreach (XmlElement statement in Statement1_Document.DocumentElement)
            {
                Statements.Add(new Statement1(statement));
            }

            return Statements.ToArray();
        }

        /// <summary>
        /// Удалить ведомость из документа
        /// </summary>
        /// <param name="statement">XML Элемент представляющий ведомость</param>
        public static void DeleteStatementFromDocument(XmlElement statement)
        {
            Statement1_Document.DocumentElement.RemoveChild(statement);
            Statement1_Document.Save(Config.Statement1_Path);
        }

        /// <summary>
        /// Получить ведомость по уникальному ключу
        /// </summary>
        /// <param name="key">Уникальный ключ</param>
        /// <returns>Ведомость</returns>
        public static Statement1 GetStatementByUniqueKey(string key)
        {
            Statement1[] statements = Statement1.GetStatementsFromDocument();

            foreach (Statement1 st in statements)
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
        /// На основании уже существующего элемента
        /// </summary>
        /// <param name="StatementElement"></param>
        public Statement1(XmlElement StatementElement)
        {
            this.StatementInXml = StatementElement;

            List<Statement1_Row> Rows = new List<Statement1_Row>();

            foreach(XmlElement Xml_Row in getTabularPart().ChildNodes)
            {
                if (Xml_Row.Name == "row")
                {
                    Rows.Add(new Statement1_Row(Xml_Row));
                }
            }

            this.TabularPart = Rows.ToArray();
        }

        /// <summary>
        /// Создать и сохранить ведомость
        /// </summary>
        /// <param name="In">Элемент, в который будет вложена ведомость</param>
        /// <param name="EducationName">Наименование учреждения образования</param>
        /// <param name="InformationAboutGraduates">Информация о выпускиниках</param>
        /// <param name="Specialty">Специальность</param>
        /// <param name="SpecialtyDirection">Направление специальности</param>
        /// <param name="Specialization">Специализация</param>
        /// <param name="Qualification">Квалификация</param>
        /// <param name="Group">Группа</param>
        public Statement1(
            XmlElement In,
            string year,
            string EducationName,
            string InformationAboutGraduates,
            string Specialty,
            string SpecialtyDirection,
            string Specialization,
            string Qualification, 
            string Group
            )
        {
            XmlAttribute Attr_UniqueKey = Statement1_Document.CreateAttribute("UniqueKey");
            Attr_UniqueKey.Value = Config.GenKey();

            XmlAttribute Attr_Year = Statement1_Document.CreateAttribute("Year");
            Attr_Year.Value = year;

            XmlAttribute Attr_EducationName = Statement1_Document.CreateAttribute("EducationName");
            Attr_EducationName.Value = EducationName;

            XmlAttribute Attr_InformationAboutGraduates = Statement1_Document.CreateAttribute("InformationAboutGraduates");
            Attr_InformationAboutGraduates.Value = InformationAboutGraduates;

            XmlAttribute Attr_Specialty = Statement1_Document.CreateAttribute("Specialty");
            Attr_Specialty.Value = Specialty;

            XmlAttribute Attr_SpecialtyDirection = Statement1_Document.CreateAttribute("SpecialtyDirection");
            Attr_SpecialtyDirection.Value = SpecialtyDirection;

            XmlAttribute Attr_Specialization = Statement1_Document.CreateAttribute("Specialization");
            Attr_Specialization.Value = Specialization;

            XmlAttribute Attr_Qualification = Statement1_Document.CreateAttribute("Qualification");
            Attr_Qualification.Value = Qualification;

            XmlAttribute Attr_Group = Statement1_Document.CreateAttribute("Group");
            Attr_Group.Value = Group;

            XmlElement Xml_TabularPart = Statement1_Document.CreateElement("TabularPart");

            this.StatementInXml = Statement1_Document.CreateElement("statement");
            this.StatementInXml.Attributes.Append(Attr_UniqueKey);
            this.StatementInXml.Attributes.Append(Attr_Year);
            this.StatementInXml.Attributes.Append(Attr_EducationName);
            this.StatementInXml.Attributes.Append(Attr_InformationAboutGraduates);
            this.StatementInXml.Attributes.Append(Attr_Specialty);
            this.StatementInXml.Attributes.Append(Attr_SpecialtyDirection);
            this.StatementInXml.Attributes.Append(Attr_Specialization);
            this.StatementInXml.Attributes.Append(Attr_Qualification);
            this.StatementInXml.Attributes.Append(Attr_Group);
            this.StatementInXml.AppendChild(Xml_TabularPart);

            In.AppendChild(this.StatementInXml);

            Statement1_Document.Save(Config.Statement1_Path);
        }

        #endregion
        #region Поля Ведомости
        /// <summary>
        /// Уникальный ключ(идентификатор) ведомости
        /// </summary>
        public string UniqueKey
        {
            get { return this.StatementInXml.Attributes["UniqueKey"].Value; }
            set { this.StatementInXml.Attributes["UniqueKey"].Value = value; }
        }

        public System.UInt16 Year
        {
            get { return Convert.ToUInt16(this.StatementInXml.Attributes["Year"].Value); }
            set { this.StatementInXml.Attributes["Year"].Value = value.ToString(); }
        }

        /// <summary>
        /// Наименование учреждения образования
        /// </summary>
        public string EducationName
        {
            get { return this.StatementInXml.Attributes["EducationName"].Value; }
            set { this.StatementInXml.Attributes["EducationName"].Value = value; }
        }

        /// <summary>
        /// Информация о выпускниках факультета(отделения)
        /// </summary>
        public string InformationAboutGraduates
        {
            get { return this.StatementInXml.Attributes["InformationAboutGraduates"].Value; }
            set { this.StatementInXml.Attributes["InformationAboutGraduates"].Value = value; }
        }

        /// <summary>
        /// Специальность
        /// </summary>
        public string Specialty
        {
            get { return this.StatementInXml.Attributes["Specialty"].Value;  }
            set { this.StatementInXml.Attributes["Specialty"].Value = value; }
        }

        /// <summary>
        /// Направление специальности
        /// </summary>
        public string SpecialtyDirection
        {
            get { return this.StatementInXml.Attributes["SpecialtyDirection"].Value; }
            set { this.StatementInXml.Attributes["SpecialtyDirection"].Value = value; }
        }

        /// <summary>
        /// Специализация
        /// </summary>
        public string Specialization
        {
            get { return this.StatementInXml.Attributes["Specialization"].Value; }
            set { this.StatementInXml.Attributes["Specialization"].Value = value; }
        }

        /// <summary>
        /// Квалификация
        /// </summary>
        public string Qualification
        {
            get { return this.StatementInXml.Attributes["Qualification"].Value; }
            set { this.StatementInXml.Attributes["Qualification"].Value = value; }
        }

        /// <summary>
        /// Группа
        /// </summary>
        public string Group
        {
            get { return this.StatementInXml.Attributes["Group"].Value; }
            set { this.StatementInXml.Attributes["Group"].Value = value; }
        }

        /// <summary>
        /// Табличная часть
        /// </summary>
        public Statement1_Row[] TabularPart = new Statement1_Row[0];
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
            Statement1_Document.Save(Config.Statement1_Path);
        }

        public Statement1_Row AppendRow(string FIO = " ")
        {
            XmlElement Xml_Row = Statement1_Document.CreateElement("row");
            this.getTabularPart().AppendChild(Xml_Row);

            Statement1_Row newRow = new Statement1_Row(Xml_Row);
            newRow.FIO = FIO;

            Array.Resize(ref this.TabularPart, this.TabularPart.Length + 1);
            this.TabularPart[this.TabularPart.Length - 1] = newRow;

            Statement1_Document.Save(Config.Statement1_Path);
            return newRow;
        }

        public void AppendRow(Statement1_Row row)
        {
            this.getTabularPart().AppendChild(row.RowElement);
        }

        public Statement1_Row[] GetAllRows()
        {
            List<Statement1_Row> rows = new List<Statement1_Row>();
            XmlElement TabularPart = getElementByName(StatementInXml, "TabularPart");

            foreach (XmlElement element in TabularPart.ChildNodes)
            {
                rows.Add(new Statement1_Row(element));
            }

            return rows.ToArray();
        }
        #endregion
    }

    /// <summary>
    /// Представляет собой строку таблицы ведомости персонального учета выпускников
    /// </summary>
    public class Statement1_Row
    {
        public XmlElement RowElement;

        /// <summary>
        /// Создать элемент, но никуда не вставлять
        /// </summary>
        public Statement1_Row() : this(Statement1.Statement1_Document.CreateElement("row"))
        {
            //
            //Элемент создается, но никуда не вставляется
            //Главное не забыть его вставить)
            //
        }

        /// <summary>
        /// На основании уже существующего
        /// </summary>
        /// <param name="XmlRowElement">XML элемент, представляющий строку таблицы</param>
        public Statement1_Row(XmlElement XmlRowElement)
        {
            this.RowElement = XmlRowElement;

            if (XmlRowElement.Attributes["FIO"] is null)
            {
                XmlAttribute Attr_FIO = Statement1.Statement1_Document.CreateAttribute("FIO");
                this.RowElement.Attributes.Append(Attr_FIO);
            }
        }

        /// <summary>
        /// Фамилия, имя, отчество
        /// </summary>
        public string FIO
        {
            get { return RowElement.Attributes["FIO"].Value; }
            set { RowElement.Attributes["FIO"].Value = value; }
        }

        /// <summary>
        /// Получить информацию за год
        /// </summary>
        /// <param name="year">год</param>
        /// <returns></returns>
        public InformationForTheYear this[System.UInt16 year]
        {
            get
            {
                foreach (XmlElement element in RowElement.ChildNodes)
                {
                    if (element.Attributes["number"].Value == year.ToString())
                        return new InformationForTheYear(element);
                }

                throw new Exception("Element not found");
            }
        }

        /// <summary>
        /// Получить информацию за все "годы" в этой строке
        /// </summary>
        /// <returns></returns>
        public InformationForTheYear[] GetAllInformation()
        {
            List<InformationForTheYear> list = new List<InformationForTheYear>();

            foreach (XmlElement child in RowElement.ChildNodes)
            {
                list.Add(new InformationForTheYear(child));
            }

            return list.ToArray();
        }

        /// <summary>
        /// Добавить информацию за год
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="organization">Организация</param>
        /// <param name="position">Должность</param>
        /// <param name="note">Примечание</param>
        public InformationForTheYear Append_InformationForTheYear(string year, string organization, string position, string note)
        {
            XmlElement Xml_year = Statement1.Statement1_Document.CreateElement("year");

            XmlAttribute Attr_Year = Statement1.Statement1_Document.CreateAttribute("number");
            Attr_Year.Value = year;

            XmlElement Xml_Organization = Statement1.Statement1_Document.CreateElement("Organization");
            Xml_Organization.InnerText = organization;

            XmlElement Xml_Position = Statement1.Statement1_Document.CreateElement("Position");
            Xml_Position.InnerText = position;

            XmlElement Xml_Note = Statement1.Statement1_Document.CreateElement("Note");
            Xml_Note.InnerText = note;

            Xml_year.Attributes.Append(Attr_Year);
            Xml_year.AppendChild(Xml_Organization);
            Xml_year.AppendChild(Xml_Position);
            Xml_year.AppendChild(Xml_Note);

            this.RowElement.AppendChild(Xml_year);
            Statement1.Statement1_Document.Save(Config.Statement1_Path);

            return new InformationForTheYear(this, year, organization, position, note);
        }

        /// <summary>
        /// Вставить информацию за год, пустые поля
        /// </summary>
        /// <returns></returns>
        public InformationForTheYear Append_InformationForTheYear()
        {
            return new InformationForTheYear(this, "", "", "", "");
        }
    }

    /// <summary>
    /// Представляет собой информацию за год
    /// </summary>
    public class InformationForTheYear
    {
        public XmlElement Element;

        /// <summary>
        /// На основании уже существующего элемента XML
        /// </summary>
        /// <param name="element">Элемент, представляющий информацию за год в XML</param>
        public InformationForTheYear(XmlElement element)
        {
            this.Element = element;
        }

        /// <summary>
        /// Создать элемент, представляющий информацию за год
        /// </summary>
        /// <param name="TableRow">Элемент представляющий "строку" таблицы(во внутрь которого будет вложен элемент, представляющий информацию за год)</param>
        /// <param name="year">Год</param>
        /// <param name="Organization">Наименование организации</param>
        /// <param name="Position">Должность</param>
        /// <param name="Note">Примечание</param>
        public InformationForTheYear(
            Statement1_Row TableRow,
            string year,
            string Organization,
            string Position,
            string Note)
        {
            Element = Statement1.Statement1_Document.CreateElement("year");

            XmlAttribute Attr_number = Statement1.Statement1_Document.CreateAttribute("number");
            Attr_number.Value = year.ToString();

            XmlElement Xml_Organization = Statement1.Statement1_Document.CreateElement("Organization");
            Xml_Organization.InnerText = Organization;

            XmlElement Xml_Position = Statement1.Statement1_Document.CreateElement("Position");
            Xml_Position.InnerText = Position;

            XmlElement Xml_Note = Statement1.Statement1_Document.CreateElement("Note");
            Xml_Note.InnerText = Note;

            Element.Attributes.Append(Attr_number);
            Element.AppendChild(Xml_Organization);
            Element.AppendChild(Xml_Position);
            Element.AppendChild(Xml_Note);

            TableRow.RowElement.AppendChild(Element);
        }

        public System.UInt16 Year
        {
            get { return Convert.ToUInt16(Element.Attributes["number"].Value); }
            set { Element.Attributes["number"].Value = value.ToString(); }
        }

        public string Organization
        {
            get { return Element.ChildNodes[0].InnerText; }
            set { Element.ChildNodes[0].InnerText = value; }
        }

        public string Position
        {
            get { return Element.ChildNodes[1].InnerText; }
            set { Element.ChildNodes[1].InnerText = value; }
        }

        public string Note
        {
            get { return Element.ChildNodes[2].InnerText; }
            set { Element.ChildNodes[2].InnerText = value; }
        }
    }







    /// <summary>
    /// Ведомость распределения выпускников
    /// </summary>
    public class Statement2
    {
        /// <summary>
        /// Элемент, представляющий ведомость в XML
        /// </summary>
        public XmlElement StatementInXml;

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
            foreach (XmlElement statement in Statement2_Document.DocumentElement.ChildNodes)
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

        /// <summary>
        /// Табличная часть
        /// </summary>
        public Statement2_Row[] TabularPart
        {
            get {
                XmlElement TabularPart = this.getTabularPart();
                Statement2_Row[] rows = new Statement2_Row[TabularPart.ChildNodes.Count];

                for(int index = 0; index < TabularPart.ChildNodes.Count; index++)
                {
                    rows[index] = new Statement2_Row((XmlElement)TabularPart.ChildNodes[index]);
                }

                return rows;
            }
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
        /// Вставить табличную часть на основании таблицы элемента ListView 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="columns"></param>
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
    /// <summary>
    /// Представляет собой строку таблицы ведомости распределения
    /// </summary>
    public class Statement2_Row
    {
        public XmlElement Xml_Row;

        /// <summary>
        /// Конструктор новой строки
        /// </summary>
        /// <param name="Element">Куда вставить элемент строки</param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="YearOfBirth"></param>
        /// <param name="familyStatus"></param>
        /// <param name="Address"></param>
        /// <param name="GovernmentAgency"></param>
        /// <param name="Organization"></param>
        /// <param name="Position"></param>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        public Statement2_Row(XmlElement Element,
            string name,
            string sex,
            string YearOfBirth,
            string familyStatus,
            string Address,
            string GovernmentAgency,
            string Organization,
            string Position,
            string m1,
            string m2)
        {
            this.Xml_Row = Statement2.Statement2_Document.CreateElement("row");

            XmlElement Xml_Name = Statement2.Statement2_Document.CreateElement("name");
            Xml_Name.InnerText = name;

            XmlElement Xml_Sex = Statement2.Statement2_Document.CreateElement("Sex");
            Xml_Sex.InnerText = sex;

            XmlElement Xml_YearOfBirth = Statement2.Statement2_Document.CreateElement("YearOfBirth");
            Xml_YearOfBirth.InnerText = YearOfBirth;

            XmlElement Xml_FamilyStatus = Statement2.Statement2_Document.CreateElement("FamilyStatus");
            Xml_FamilyStatus.InnerText = familyStatus;

            XmlElement Xml_Address = Statement2.Statement2_Document.CreateElement("Address");
            Xml_Address.InnerText = Address;

            XmlElement Xml_GovernmentAgency = Statement2.Statement2_Document.CreateElement("GovernmentAgency");
            Xml_GovernmentAgency.InnerText = GovernmentAgency;

            XmlElement Xml_Organization = Statement2.Statement2_Document.CreateElement("Organization");
            Xml_Organization.InnerText = Organization;

            XmlElement Xml_Position = Statement2.Statement2_Document.CreateElement("Position");
            Xml_Position.InnerText = Position;

            XmlElement Xml_m1 = Statement2.Statement2_Document.CreateElement("m1");
            Xml_m1.InnerText = m1;

            XmlElement Xml_m2 = Statement2.Statement2_Document.CreateElement("m2");
            Xml_m2.InnerText = m2;

            this.Xml_Row.AppendChild(Xml_Name);
            this.Xml_Row.AppendChild(Xml_Sex);
            this.Xml_Row.AppendChild(Xml_YearOfBirth);
            this.Xml_Row.AppendChild(Xml_FamilyStatus);
            this.Xml_Row.AppendChild(Xml_Address);
            this.Xml_Row.AppendChild(Xml_GovernmentAgency);
            this.Xml_Row.AppendChild(Xml_Organization);
            this.Xml_Row.AppendChild(Xml_Position);
            this.Xml_Row.AppendChild(Xml_m1);
            this.Xml_Row.AppendChild(Xml_m2);

            Element.AppendChild(Xml_Row);

            Statement2.Statement2_Document.Save(Config.Statement2_Path);
        }

        /// <summary>
        /// На основании уже готового
        /// </summary>
        /// <param name="element"></param>
        public Statement2_Row(XmlElement element)
        {
            this.Xml_Row = element;
        }

#warning Добавить описание в XML
        public string Name
        {
            get { return getElementByName("name", this.Xml_Row).InnerText; }
            set { getElementByName("name", this.Xml_Row).InnerText = value; }
        }

        public string Sex
        {
            get { return getElementByName("Sex", this.Xml_Row).InnerText; }
            set { getElementByName("Sex", this.Xml_Row).InnerText = value; }
        }

        public string YearOfBirth
        {
            get { return getElementByName("YearOfBirth", this.Xml_Row).InnerText; }
            set { getElementByName("YearOfBirth", this.Xml_Row).InnerText = value; }
        }

        public string FamilyStatus
        {
            get { return getElementByName("FamilyStatus", this.Xml_Row).InnerText; }
            set { getElementByName("FamilyStatus", this.Xml_Row).InnerText = value; }
        }

        public string Address
        {
            get { return getElementByName("Address", this.Xml_Row).InnerText; }
            set { getElementByName("Address", this.Xml_Row).InnerText = value; }
        }

        public string GovernmentAgency
        {
            get { return getElementByName("GovernmentAgency", this.Xml_Row).InnerText; }
            set { getElementByName("GovernmentAgency", this.Xml_Row).InnerText = value; }
        }

        public string Organization
        {
            get { return getElementByName("Organization", this.Xml_Row).InnerText; }
            set { getElementByName("Organization", this.Xml_Row).InnerText = value; }
        }

        public string Position
        {
            get { return getElementByName("Position", this.Xml_Row).InnerText; }
            set { getElementByName("Position", this.Xml_Row).InnerText = value; }
        }

        public string m1
        {
            get { return getElementByName("m1", this.Xml_Row).InnerText; }
            set { getElementByName("m1", this.Xml_Row).InnerText = value; }
        }

        public string m2
        {
            get { return getElementByName("m2", this.Xml_Row).InnerText; }
            set { getElementByName("m2", this.Xml_Row).InnerText = value; }
        }


        /// <summary>
        /// Получить элемент по имени
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="element">XML элемент, среди потомков которого будет производится поиск</param>
        /// <returns></returns>
        private static XmlElement getElementByName(string name, XmlElement element)
        {
            foreach (XmlElement child in element.ChildNodes)
            {
                if (child.Name == name)
                {
                    return child;
                }
            }

            throw new Exception("Element not found");
        }
    }
}
