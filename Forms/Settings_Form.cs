using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using System.Xml;
using System.Runtime.CompilerServices;
using MetroFramework;
using System.Windows.Forms.VisualStyles;

namespace DataBase.Forms
{
    public partial class Settings_Form : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// Типы "констант", которые мы можем добавлять
        /// </summary>
        public readonly string[] types =
            {
                "Наименование УО",
                "Специальность",
                "Направление специальности",
                "Специализация",
                "Квалификация",
                "Группа",
                "Председатель комиссии",
                "Заместитель председателя",
                "Член комиссии"
            };


        public Settings_Form()
        {
            InitializeComponent();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings_AddValue form = new Settings_AddValue();
            form.TypeComboBox.Items.AddRange(types);
            Config.GetValues();
            form.ShowDialog();

            Config.AddToConfig(form.TypeComboBox.Text, form.valueTextBox.Text);

            ListViewItem newItem = this.metroListView1.Items.Add(form.TypeComboBox.Text);
            newItem.SubItems.Add(form.valueTextBox.Text);
        }

        private void Settings_Form_Shown(object sender, EventArgs e)
        {
            /*загрузка "ключ-значение" в ListView*/
            Dictionary<string, List<string>> keyValues = Config.GetValues();

            foreach (string key in keyValues.Keys)
            {
                foreach (string value in keyValues[key])
                {
                    ListViewItem newItem = this.metroListView1.Items.Add(key);
                    newItem.SubItems.Add(value);
                }
            }

            this.PathToStatement1File.Text = Config.Statement1_Path;
            this.PathToStatement2File.Text = Config.Statement2_Path;
        }

        private void удалитьВыбранноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.metroListView1.SelectedItems.Count == 0) return;

            for (int index = 0; index < metroListView1.SelectedItems.Count; index++)
            {
                Config.DeleteFromConfig(this.metroListView1.SelectedItems[index].SubItems[0].Text,
                                        this.metroListView1.SelectedItems[index].SubItems[1].Text);

                this.metroListView1.SelectedItems[index].Remove();
            }
        }

        public string getFile()
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            return openFileDialog1.FileName;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //Открыть диалог на открытие персонального учета выпускников
            string file = getFile();
            if(!string.IsNullOrWhiteSpace(file)){
                if (!Config.CheckValidXmlDocument(file))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Выбранный вами документ не прошёл проверку\n" +
                        "Изменения не будут применены", "Внимание");
                    return;
                }

                if (!(Config.Statement1_Path == file))
                {
                    Config.Statement1_Path = this.PathToStatement1File.Text = file;
                    SelectedNewFile_reboot();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Вы выбрали файл, который открыт сейчас\n" +
                        "Изменения не будут применены", "Внимание");
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //Открыть диалог на открытие ведомости распределения выпускников
            string file = getFile();
            if (!string.IsNullOrWhiteSpace(file))
            {
                if (!Config.CheckValidXmlDocument(file))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Выбранный вами документ не прошёл проверку\n" +
                        "Изменения не будут применены", "Внимание");
                    return;
                }

                if (!(Config.Statement2_Path == file))
                {
                    Config.Statement2_Path = this.PathToStatement2File.Text = file;
                    SelectedNewFile_reboot();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Вы выбрали файл, который открыт сейчас\n" +
                        "Изменения не будут применены", "Внимание");
                }
            }
        }

        private void CreateStatement1_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();

            if (!(string.IsNullOrWhiteSpace(this.saveFileDialog1.FileName)))
            {
                CreateXml(this.saveFileDialog1.FileName);
                Config.Statement1_Path = this.PathToStatement1File.Text = this.saveFileDialog1.FileName;
                SelectedNewFile_reboot();
            }
        }

        private void CreateStatement2_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();

            if (!(string.IsNullOrWhiteSpace(this.saveFileDialog1.FileName)))
            {
                CreateXml(this.saveFileDialog1.FileName);
                Config.Statement2_Path = this.PathToStatement2File.Text = this.saveFileDialog1.FileName;
                SelectedNewFile_reboot();
            }
        }

        private void SelectedNewFile_reboot()
        {
            MetroFramework.MetroMessageBox.Show(this, "Вы выбрали новый файл, необходимо перезагрузить программу\n" +
                        "После нажатия кнопки \"OK\" будет выполнена перезагрузка", "Внимание", MessageBoxButtons.OK);
            Process.Start(Environment.GetCommandLineArgs()[0], "reboot");
            Application.Exit();
        }

        private void CreateXml(string path)
        {
            StreamWriter writer = new StreamWriter(File.Create(path));
            writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?> <nodes></nodes>");
            writer.Close();
        }
    }


    public static class Config
    {
        public const string SETTINGS_FILE_NAME = "Settings.xml";
        static XmlDocument document = new XmlDocument();
        static XmlElement rootElement;

        static Config()
        {
            if (!System.IO.File.Exists(SETTINGS_FILE_NAME))
            {
                StreamWriter writer = new StreamWriter(File.Create(SETTINGS_FILE_NAME));
                writer.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
                writer.Close();
            }

            document.Load(SETTINGS_FILE_NAME);
            rootElement = document.DocumentElement;
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
        /// Добавить значение в конфиг
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public static void AddToConfig(string key, string value)
        {
            /*XmlElement element = document.CreateElement("value");

            XmlAttribute attr = document.CreateAttribute("type");
            attr.Value = value
            element.Attributes.Append()*/

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

        public static string Statement1_Path
        {
            get
            {
                return rootElement.Attributes["PathToStatement1"].Value;
            }

            set
            {
                rootElement.Attributes["PathToStatement1"].Value = value;
                document.Save(SETTINGS_FILE_NAME);
            }
        }

        public static string Statement2_Path
        {
            get
            {
                return rootElement.Attributes["PathToStatement2"].Value;
            }

            set
            {
                rootElement.Attributes["PathToStatement2"].Value = value;
                document.Save(SETTINGS_FILE_NAME);
            }
        }

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
            catch(XmlException)
            {
                return false;
            }catch
            {
                return true;
            }          
        }
    }
}
