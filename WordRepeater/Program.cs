using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordRepeater
{
    static class Program
    {
        //Настроечные переменные программы
        public const int MaxLanguagesCount = 3;
        public const int ModelVersion = 0;//Версия моделей данных. При несовпадении требуется конвертация модели локальных данных
        public static MainForm mfMainForm;
        //конец настроечных переменных
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mfMainForm=new MainForm());
        }
    }
}
