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
            foreach(DriveInfo drive in AllDrives)
            {
                if (drive.DriveType == DriveType.Removable) RemovableDrives.Add(drive);
            }

            switch (RemovableDrives.Count)
            {
                case 0: {
                        MetroFramework.MetroMessageBox.Show(this, "Нет подключенных съемных устройств");
                        this.Close();
                        break; 
                    }
                case 1: {
                        MetroFramework.MetroMessageBox.Show(this, "Файлы будут сохранены на " + RemovableDrives[0].VolumeLabel + " " + RemovableDrives[0].Name);
                        break; 
                    }

                default: { break; }
            }

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            //Выбор путя
        }
    }
}
