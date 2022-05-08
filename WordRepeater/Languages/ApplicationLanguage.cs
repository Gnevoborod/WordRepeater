using System.Collections.Generic;
using System.IO;


namespace WordRepeater.Languages
{
    public class ApplicationLanguage
    {
        public string sLanguageName { get; set; }//наименование языка
        public string sFileName { get; set; }//имя файла в котором размещается локализация

        public Dictionary<string, string> lsLanguageList=null;
        public bool LoadLanguageList()
        {
            string path = Program.PATH + "Localization\\ApplicationLanguage.txt";
            FileStream fs;
            StreamReader streamReader=null;
            try
            {
                if (!File.Exists(path))
                    return false;
                fs = new FileStream(path, FileMode.Open);
                streamReader = new StreamReader(fs);
                string buffer;
                lsLanguageList = new Dictionary<string, string>();
                while((buffer=streamReader.ReadLine())!=null)
                {

                    string[] splittedString = buffer.Split(":");
                    lsLanguageList.Add(splittedString[0], splittedString[1]);
                }    
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if(streamReader!=null)
                    streamReader.Close();
                
            }
        }
    }
}
