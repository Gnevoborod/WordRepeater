using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace WordRepeater
{
    static class Program
    {
        //Настроечные переменные программы
        public const int MaxLanguagesCount = 15;
        public static bool ToClose = false;
        public const int ModelVersion = 0;//Версия моделей данных. При несовпадении требуется конвертация модели локальных данных
        public static MainForm mfMainForm;
        public static string PATH = Application.StartupPath;//Environment.CurrentDirectory;
        public static string PRG_PATH = Application.ExecutablePath;
        public static Repeater rRepeater = new Repeater();
        //конец настроечных переменных
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists(Program.PATH + "UserData\\"))
                Directory.CreateDirectory(Program.PATH + "UserData\\");
            CultureInfo ci = CultureInfo.CurrentCulture;
            Controller.Init();
            Controller.LoadSettings();
            Controller.LoadDictionary();
            Controller.LoadLanguages();
            Controller.LoadEnvironment();
            if (null == Controller.sSettings.bStartOnLoad)
                Controller.AutorunRegistry(true);
            if (null == Controller.sSettings.bRareAlgo)
                Controller.sSettings.bRareAlgo = true;
            Thread tRepeat = new Thread(rRepeater.Repeat);
            tRepeat.Start();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int language = 0;
            if (ci.Name == "ru-RU")
                language = 1;
            Application.Run(mfMainForm=new MainForm(language));
        }
    }
}
