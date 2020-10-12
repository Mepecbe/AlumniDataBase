using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                foreach (string param in Environment.GetCommandLineArgs())
                {
                    switch (param)
                    {
                        case "reboot":
                            {
                                //Если производится перезагрузка программы, то даём 200 миллисекунд предыдущей программе на закрытие
                                Thread.Sleep(TimeSpan.FromMilliseconds(200));
                                break;
                            }
                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
