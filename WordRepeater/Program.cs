using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WordRepeater
{
    static class Program
    {
        //����������� ���������� ���������
        public const int MaxLanguagesCount = 3;
        public static bool ToClose = false;
        public const int ModelVersion = 0;//������ ������� ������. ��� ������������ ��������� ����������� ������ ��������� ������
        public static MainForm mfMainForm;
        public static string PATH = Application.StartupPath;//Environment.CurrentDirectory;
        public static string PRG_PATH = Application.ExecutablePath;
        public static Repeater rRepeater = new Repeater();
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
            if (null == Controller.sSettings.bStartOnLoad)
                Controller.AutorunRegistry(true);
            Thread tRepeat = new Thread(rRepeater.Repeat);
            tRepeat.Start();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mfMainForm=new MainForm());
        }
    }
}
