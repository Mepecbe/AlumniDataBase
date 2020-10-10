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
            Dictionary<string, List<string>> keyValues = Config.GetValues();

            foreach (string key in keyValues.Keys)
            {
                foreach (string value in keyValues[key])
                {
                    ListViewItem newItem = this.metroListView1.Items.Add(key);
                    newItem.SubItems.Add(value);
                }
            }
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


        public static class Config
        {
            static XmlDocument document = new XmlDocument();
            static XmlElement rootElement;

            static Config()
            {
                if (!System.IO.File.Exists("Settings.xml"))
                {
                    StreamWriter writer = new StreamWriter(File.Create("Settings.xml"));
                    writer.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
                    writer.Close();
                }

                document.Load("Settings.xml");
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
                    
                    foreach(XmlElement ChildElement in element.ChildNodes)
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
                    if(Elements.Attributes[0].Value == key)
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

                document.Save("Settings.xml");
            }

            public static void DeleteFromConfig(string key, string value)
            {
                foreach (XmlElement Elements in rootElement)
                {
                    if (Elements.Attributes[0].Value == key)
                    {
                        foreach(XmlElement child in Elements.ChildNodes)
                        {
                            if(child.InnerText == value)
                            {
                                Elements.RemoveChild(child);
                            }
                        }
                    }
                }

                document.Save("Settings.xml");
            }
        }

        
    }
}
