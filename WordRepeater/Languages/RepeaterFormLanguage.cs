using System.Collections.Generic;
using System.IO;

namespace WordRepeater.Languages
{
    public class RepeaterFormLanguage
    {

        public bool bIsDefaultedLanguage = false;
        public string sLanguageToLoad;
        public Dictionary<string, string> repeatFormWords;

        public RepeaterFormLanguage(bool flag, string langToLoad)
        {
            bIsDefaultedLanguage = !flag;//false становится true. True-если успешно загружен словарь с названиями языков.
            sLanguageToLoad = langToLoad;//имя языка ru, en etc

            repeatFormWords = new Dictionary<string, string>();
        }

        public bool LoadApplicationLanguages()
        {
            string path = Program.PATH + "Localization\\" + sLanguageToLoad + "\\RepeaterForm.txt";
            FileStream fs;
            StreamReader streamReader = null;
            try
            {
                if (!File.Exists(path) || bIsDefaultedLanguage)
                {
                    repeatFormWords.Add("TITLE", "Repeat the word");
                    repeatFormWords.Add("CONTINUE_BUTTON", "Continue");
                    repeatFormWords.Add("CONTEXT_MENU_STOP", "Stop repeating this word");
  
                    return true;
                }

                fs = new FileStream(path, FileMode.Open);
                streamReader = new StreamReader(fs);
                string buffer;
                while ((buffer = streamReader.ReadLine()) != null)
                {
                    string[] subBuffer = buffer.Split("=");
                    repeatFormWords.Add(subBuffer[0].Trim(), subBuffer[1]);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
        }
    }
}
