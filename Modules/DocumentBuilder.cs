using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Xml;
using Tulpep.NotificationWindow;

namespace DataBase.Modules
{
    static class DocumentBuilder
    {
        /// <summary>
        /// Сгенерировать ведомость персонального учета выпускников в формате Word
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="PathToTemplateDocument"></param>
        /// <returns></returns>
        public static bool BuildStatement1(
            Statement1 statement,
            string PathToTemplateDocument = "Templates\\Statement2.docx"
            )
        {
            string FileName = $"{statement.Specialty} {statement.Specialization} {DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day}.docx";
            bool Error = false;

            //Если файл существует, то добавляем (Количество файлов в папке + 1) к названию файла
            if (File.Exists(Directory.GetCurrentDirectory() + "\\TemporaryFiles\\" + FileName))
                FileName = (1 + Directory.GetFiles(Directory.GetCurrentDirectory() + "\\TemporaryFiles\\").Length) + "  " + FileName;

            File.Copy(Directory.GetCurrentDirectory() + "\\Templates\\Statement1.docx",
                Directory.GetCurrentDirectory() + "\\TemporaryFiles\\" + FileName);

            var wordApplication = new Word.Application() { Visible = false };
            var wordDocument = wordApplication.Documents.Open(Directory.GetCurrentDirectory() + "\\TemporaryFiles\\" + FileName);

            ReplaceInWord("{Edu}", statement.EducationName + "    ", wordDocument);
            ReplaceInWord("{Info}", statement.InformationAboutGraduates, wordDocument);
            ReplaceInWord("{Specialty}", statement.Specialty, wordDocument);
            ReplaceInWord("{dSpecialty}", statement.SpecialtyDirection, wordDocument);
            ReplaceInWord("{Specialization}", statement.Specialization, wordDocument);
            ReplaceInWord("{Qualification}", statement.Qualification, wordDocument);
            ReplaceInWord("{Group}", statement.Group, wordDocument);

            Word.Table TabularPart = wordDocument.Tables[1];

#warning проверить все циклы на использование слишком больших переменных
#warning Если учтено больше трёх лет, запрашиваем у пользователя за какие "годы" выводить информацию в документ

            Statement1_Row[] Rows = statement.GetAllRows();

            int AllRowOffset = 4; //Первая строка, с которой начинается вывод информации, является четвертой, поэтому тут 4 заранее
            
            for (int index = 0; index < Rows.Length; index++)
            {
                //TabularPart.Rows.Add();

                InformationForTheYear[] info = Rows[index].GetAllInformation();
                Array.Sort(info);

                Dictionary<System.UInt16, List<InformationForTheYear>> keyValues = ArrayToDictionary(info);

                //
                // Добавление строк в таблицу
                //

                int AllocateRows = 0;
                foreach (System.UInt16 key in keyValues.Keys)
                {
                    if(keyValues[key].Count > AllocateRows)
                    {
                        AllocateRows = keyValues[key].Count;
                    }
                }

                for(int counter = 0; counter < AllocateRows; counter++)
                {
                    TabularPart.Rows.Add();
                }

                //
                // Добавление информации в таблицу
                //

                //ФИО, адрес, телефон
                TabularPart.Cell(AllRowOffset, 1).Range.Text = Rows[index].FIO;

                byte Column = 2;    //Колонка для "название организации, адрес, телефон отдел кадров", 2 потому что первая колонка это ФИО, может принимать значения 2 5 8

                //С УЧЕТОМ ТОГО, ЧТО УЧЕТ БЫЛ НЕ БОЛЕЕ ЧЕМ ЗА 3 ГОДА
                foreach (System.UInt16 key in keyValues.Keys)
                {
                    byte localRowOffset = 0; //Сдвиг от первой строки(где первая строка - строка с фамилией)

                    foreach (InformationForTheYear YearInfo in keyValues[key])
                    {
                        TabularPart.Cell(AllRowOffset + localRowOffset, Column).Range.Text = YearInfo.Organization;
                        TabularPart.Cell(AllRowOffset + localRowOffset, Column+1).Range.Text = YearInfo.Position;
                        TabularPart.Cell(AllRowOffset + localRowOffset, Column+2).Range.Text = YearInfo.Note;

                        localRowOffset++;
                    }

                    //Потому что двигаемся дальше, записывать информацию за следующий год
                    Column += 3;
                }

                AllRowOffset += AllocateRows;
            }

            wordDocument.Save();
            wordApplication.Visible = true;

            return Error;
        }

        /// <summary>
        /// Структурирование данных, преобразует массив в удобный словарь
        ///   2020
        ///     Лист информации
        ///   2021
        ///     Лист информации
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        private static Dictionary<System.UInt16, List<InformationForTheYear>> ArrayToDictionary(InformationForTheYear[] Info)
        {
            Dictionary<System.UInt16, List<InformationForTheYear>> keys = new Dictionary<System.UInt16, List<InformationForTheYear>>();

            foreach (InformationForTheYear info in Info)
            {
                if (keys.ContainsKey(info.Year))
                {
                    keys[info.Year].Add(info);
                }
                else
                {
                    keys.Add(info.Year, new List<InformationForTheYear>());
                    keys[info.Year].Add(info);
                }
            }

            return keys;
        }

        /// <summary>
        /// Сгенерировать ведомость распределения в формате WORD
        /// </summary>
        /// <param name="Statement">Ведомость</param>
        /// <param name="PathToTemplateDocument">Путь к шаблону</param>
        /// <returns></returns>
        public static bool BuildStatement2(
            Statement2 Statement,
            string PathToTemplateDocument = "Templates\\Statement2.docx"
        )
        {
            string FileName =  $"{Statement.codeAndSpecialityName} {DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day}.docx";
            bool Error = false;

            //Если файл существует, то добавляем (Количество файлов в папке + 1) к названию файла
            if (File.Exists(Directory.GetCurrentDirectory() + "\\TemporaryFiles\\" + FileName))
                FileName = (1 + Directory.GetFiles(Directory.GetCurrentDirectory() + "\\TemporaryFiles\\").Length) + "  " + FileName;

            File.Copy(Directory.GetCurrentDirectory() + "\\Templates\\Statement2.docx",
                Directory.GetCurrentDirectory() + "\\TemporaryFiles\\" + FileName);

            var wordApplication = new Word.Application() { Visible = false };
            var wordDocument = wordApplication.Documents.Open(Directory.GetCurrentDirectory() + "\\TemporaryFiles\\" + FileName);

            //Год
            if (!ReplaceInWord("yr", Statement.Year.ToString().Substring(2), wordDocument))
                Error = true;

            //Наименование учреждения образования или организации
            if (!ReplaceInWord("{Edu}", Statement.EducationalInstitution, wordDocument))
                Error = true;

            //Код и наименование специальности
            if (!ReplaceInWord("{CodeAndName}", Statement.codeAndSpecialityName, wordDocument))
                Error = true;

#warning Уточнить

            //Председатель комиссии
            ReplaceInWord("{CM}", Statement.chairman, wordDocument);

            //Заместитель председателя
            ReplaceInWord("{CH}", Statement.deputy, wordDocument);

            //Члены комиссии
            ReplaceInWord("{M1}", Statement.CommissionMember1, wordDocument);
            ReplaceInWord("{M2}", Statement.CommissionMember1, wordDocument);

            /*Формирование табличной части*/
            XmlElement XmlTabularPart = Statement.getTabularPart();
            Word.Table TabularPart = wordDocument.Tables[1];

            //Добавление строк, -1 потому что 1 строки в шаблоне уже есть
            for(int count = XmlTabularPart.ChildNodes.Count - 1; count > 0; count--)
                TabularPart.Rows.Add();

            for (int RowIndex = 0; RowIndex < XmlTabularPart.ChildNodes.Count; RowIndex++)
            {
                for (int column = 0; column < 10; column++)
                    TabularPart.Cell(4 + RowIndex, column + 1).Range.Text = XmlTabularPart.ChildNodes[RowIndex].ChildNodes[column].InnerText;
            }

            wordDocument.Save();
            wordApplication.Visible = true;

            return Error;
        }


        private static bool ReplaceInWord(string findText, string replaceText, Word.Document word)
        {
            var range = word.Content;
            range.Find.ClearFormatting();

            return range.Find.Execute(FindText: findText, ReplaceWith: replaceText);
        }
    }
}
