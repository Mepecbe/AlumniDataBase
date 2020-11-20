using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{

    public static class Config
    {
        public const string SETTINGS_FILE_NAME = "Settings.xml";

        public static Random RandomGenerator = new Random();

        static XmlDocument document = new XmlDocument();
        static XmlElement rootElement;

        static Config()
        {
            StreamWriter writer;

            Statement1_Path = Directory.GetCurrentDirectory() + "\\Files\\Statement1.xml";
            Statement2_Path = Directory.GetCurrentDirectory() + "\\Files\\Statement2.xml";

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\TemporaryFiles"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\TemporaryFiles");
            }

            if (!File.Exists(SETTINGS_FILE_NAME))
            {
                string CurrentDir = Directory.GetCurrentDirectory();
                writer = new StreamWriter(File.Create(SETTINGS_FILE_NAME));
                writer.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" ?> " +
                    $"<settings PathToStatement1=\"{CurrentDir}\\Files\\Statement1.xml\" PathToStatement2=\"{CurrentDir}\\Files\\Statement2.xml\"> </settings>");
                writer.Close();
            }

            document.Load(SETTINGS_FILE_NAME);
            rootElement = document.DocumentElement;

            if(!Directory.Exists(Directory.GetCurrentDirectory() + "\\Files"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Files");
            }

            if (!File.Exists(Statement1_Path))
            {
                writer = new StreamWriter(File.Create(Statement1_Path));
                writer.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" ?> " +
                $"<statements> </statements>");
                writer.Close();
            }

            if (!File.Exists(Statement2_Path))
            {
                writer = new StreamWriter(File.Create(Statement2_Path));
                writer.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" ?> " +
                $"<statements> </statements>");
                writer.Close();
            }
        }

        /// <summary>
        /// Получить значения для полей "выбора"(types)
        /// </summary>
        /// <returns>Словарь</returns>
        public static Dictionary<string, List<string>> GetValues()
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            foreach (XmlElement element in rootElement.ChildNodes)
            {
                if (element.Attributes.Count == 0) continue;

                dictionary[element.Attributes[0].Value] = new List<string>();

                foreach (XmlElement ChildElement in element.ChildNodes)
                {
                    dictionary[element.Attributes[0].Value].Add(ChildElement.InnerText);
                }
            }

            return dictionary;
        }

        /// <summary>
        /// Сгенерировать ключ
        /// </summary>
        /// <returns></returns>
        public static string GenKey()
        {
            string retKey = "";
            for (int a = 0; a < 10; a++)
                retKey += ((char)RandomGenerator.Next(97, 122)) + RandomGenerator.Next(0, 10).ToString();

            return retKey;
        }

        /// <summary>
        /// Добавить значение в конфиг
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public static void AddToConfig(string key, string value)
        {
            bool Added = false;

            foreach (XmlElement Elements in rootElement)
            {
                if (Elements.Attributes[0].Value == key)
                {
                    XmlElement newChildElement = document.CreateElement("value");
                    newChildElement.InnerText = value;
                    Elements.AppendChild(newChildElement);
                    Added = true;
                }
            }

            if (!Added)
            {
                XmlElement newElement = document.CreateElement("value");
                XmlAttribute newElement_Attributes = document.CreateAttribute("type");
                newElement_Attributes.Value = key;

                XmlElement child = document.CreateElement("value");
                child.InnerText = value;

                newElement.Attributes.Append(newElement_Attributes);
                newElement.AppendChild(child);

                rootElement.AppendChild(newElement);
            }

            document.Save(SETTINGS_FILE_NAME);
        }

        /// <summary>
        /// Удалить ключ и значение из конфига
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public static void DeleteFromConfig(string key, string value)
        {
            foreach (XmlElement Elements in rootElement)
            {
                if (Elements.Attributes[0].Value == key)
                {
                    foreach (XmlElement child in Elements.ChildNodes)
                    {
                        if (child.InnerText == value)
                        {
                            Elements.RemoveChild(child);
                        }
                    }
                }
            }

            document.Save(SETTINGS_FILE_NAME);
        }

        /// <summary>
        /// Путь к шаблону ведомости персонального учета 
        /// </summary>
        public static readonly string Statement1_Path;

        /// <summary>
        /// Путь к шаблону ведомости распределения
        /// </summary>
        public static readonly string Statement2_Path;

        /// <summary>
        /// Проверяет "валидность" XML файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public static bool CheckValidXmlDocument(string path)
        {
            XmlDocument doc = new XmlDocument();
            //Нас интересуют только ошибки XML структуры
            try
            {
                doc.Load(path);
                return true;
            }
            catch (XmlException)
            {
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
