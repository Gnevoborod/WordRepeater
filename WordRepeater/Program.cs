using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
using WordRepeater.Languages;

namespace WordRepeater
{
    public static class Program
    {
        //����������� ���������� ���������
        public delegate void LoadLanguagesDelegate(string iso);
        public const int MaxLanguagesCount = 15;
        public static bool ToClose = false;
        public const int ModelVersion = 0;//������ ������� ������. ��� ������������ ��������� ����������� ������ ��������� ������
        public static MainForm mfMainForm;
        public static string PATH = Application.StartupPath;//Environment.CurrentDirectory;
        public static string PRG_PATH = Application.ExecutablePath;
        public static Repeater rRepeater;
        //����� ����������� ����������
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists(Program.PATH + "UserData\\"))
                Directory.CreateDirectory(Program.PATH + "UserData\\");
            Controller.Init();
            Controller.LoadSettings();
            Controller.LoadDictionary();
            Controller.LoadLanguages();
            Controller.LoadEnvironment();
            if (null == Controller.sSettings.bStartOnLoad)
                Controller.AutorunRegistry(true);
            if (null == Controller.sSettings.bRareAlgo)
                Controller.sSettings.bRareAlgo = true;
            string sTwoLetterISOLanguageName;
            if (String.IsNullOrEmpty(Controller.sSettings.sApplicationLanguage))
            {
                CultureInfo ci = CultureInfo.CurrentCulture;
                sTwoLetterISOLanguageName = ci.TwoLetterISOLanguageName;
            }
            else
                sTwoLetterISOLanguageName = Controller.sSettings.sApplicationLanguage;
            rRepeater = new Repeater(sTwoLetterISOLanguageName);
            Thread tRepeat = new Thread(rRepeater.Repeat);
            tRepeat.Start();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            LoadLanguagesDelegate loadLanguagesDelegate = new LoadLanguagesDelegate(rRepeater.SetTexts);
            Application.Run(mfMainForm=new MainForm(sTwoLetterISOLanguageName, loadLanguagesDelegate));
        }
    }
}
