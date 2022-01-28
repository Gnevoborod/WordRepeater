using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordRepeater
{
    static class Program
    {
        //����������� ���������� ���������
        public const int MaxLanguagesCount = 3;
        public const int ModelVersion = 0;//������ ������� ������. ��� ������������ ��������� ����������� ������ ��������� ������
        public static MainForm mfMainForm;
        public static string PATH = Environment.CurrentDirectory;
        //����� ����������� ����������
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists(Program.PATH + "\\UserData\\"))
                Directory.CreateDirectory(Program.PATH + "\\UserData\\");
            Controller.Init();
            Controller.LoadDictionary();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mfMainForm=new MainForm());
        }
    }
}
