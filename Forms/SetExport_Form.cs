using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace DataBase.Forms
{
    public partial class SetExport_Form : MetroFramework.Forms.MetroForm
    {
        public SetExport_Form()
        {
            InitializeComponent();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            //На флешку
            List<DriveInfo> RemovableDrives = new List<DriveInfo>();

            DriveInfo[] AllDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in AllDrives)
            {
                if (drive.DriveType == DriveType.Removable) RemovableDrives.Add(drive);
            }

            if (RemovableDrives.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Нет подключенных съемных устройств");
            }
            else if (RemovableDrives.Count == 1)
            {
                try
                {
                    MetroFramework.MetroMessageBox.Show(this, "Файлы будут сохранены на " + RemovableDrives[0].VolumeLabel + " " + RemovableDrives[0].Name, "Внимание");
                    if (!Directory.Exists(RemovableDrives[0].Name + "Экспортированные ведомости\\"))
                    {
                        Directory.CreateDirectory(RemovableDrives[0].Name + "Экспортированные ведомости\\");
                    }

                    File.Copy(Config.Statement1_Path, RemovableDrives[0].Name + "Экспортированные ведомости\\" + "Statements1.xml");
                    File.Copy(Config.Statement2_Path, RemovableDrives[0].Name + "Экспортированные ведомости\\" + "Statements2.xml");

                    new PopupNotifier()
                    {
                        ContentText = $"Эспорт завершен\n\t{RemovableDrives[0].Name + "Экспортированные ведомости\\"}",
                        TitleText = "База данных выпускников",
                        ContentColor = Color.Green
                    }.Popup();
                }
                catch(Exception exInfo)
                {
                    new PopupNotifier()
                    {
                        ContentText = $"Во время экспорта произошла ошибка\n{exInfo.Message}",
                        TitleText = "База данных выпускников",
                        ContentColor = Color.Red
                    }.Popup();
                }
            }

            this.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            //Выбор путя
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.LastIndexOf('\\') + 1);

                File.Copy(Config.Statement1_Path, saveFileDialog1.FileName + "Statements1.xml");
                File.Copy(Config.Statement2_Path, saveFileDialog1.FileName + "Statements2.xml");

                new PopupNotifier()
                {
                    ContentText = $"Эспорт завершен\n{saveFileDialog1.FileName}",
                    TitleText = "База данных выпускников",
                    ContentColor = Color.Green
                }.Popup();
            }
            catch (Exception exInfo)
            {
                new PopupNotifier()
                {
                    ContentText = $"Во время экспорта произошла ошибка\n{exInfo.Message}",
                    TitleText = "База данных выпускников",
                    ContentColor = Color.Red
                }.Popup();
            }
        }
    }
}