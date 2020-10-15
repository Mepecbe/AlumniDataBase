using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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


}
