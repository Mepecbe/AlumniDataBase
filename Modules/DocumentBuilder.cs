using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;

namespace DataBase.Modules
{
    static class DocumentBuilder
    {
        public static bool BuildStatement2(
            Statement2 Statement,
            string PathToTemplateDocument = "Templates\\Statement2.docx"
        )
        {
            string FileName =  $"{Statement.codeAndSpecialityName} {DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day}.docx";
            bool Error = false;

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
            if (ReplaceInWord("{CodeAndName}", Statement.codeAndSpecialityName, wordDocument))
                Error = true;

            /*Формирование табличной части*/
            Word.Table TabularPart = wordDocument.Tables[1];

            for (int column = 1; column < 12; column++)
                TabularPart.Cell(4, column).Range.Text = "Hello";


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
