using System.Collections.Generic;
using System.IO;

namespace WordRepeater.Languages
{
    //по классу на каждую форму.
    public class MainFormLanguage
    {
        public bool bIsDefaultedLanguage = false;
        public string sLanguageToLoad;
        public Dictionary<string, string> mainFormWords;
        public MainFormLanguage(bool flag, string langToLoad)
        {
            bIsDefaultedLanguage = !flag;//false становится true. True-если успешно загружен словарь с названиями языков.
            sLanguageToLoad = langToLoad;//имя языка ru, en etc

            mainFormWords = new Dictionary<string, string>();
        }
        public bool LoadApplicationLanguages()
        {
            string path = Program.PATH + "Localization\\"+sLanguageToLoad+"\\MainForm.txt";
            FileStream fs;
            StreamReader streamReader = null;
            try
            {   if (!File.Exists(path) || bIsDefaultedLanguage)
                {
                    mainFormWords.Add("TITLE", "Repeating words");
                    mainFormWords.Add("SETTINGS_BTN", "Settings");
                    mainFormWords.Add("LANG_BTN", "Add new language");
                    mainFormWords.Add("WORD_BTN", "Add new word");
                    mainFormWords.Add("UPLOAD_BTN", "Load list of words");
                    mainFormWords.Add("DOWNLOAD_BTN","Save all words");
                    mainFormWords.Add("STATISTICS_BTN","Statistics");
                    mainFormWords.Add("ABOUT_BTN","About");
                    mainFormWords.Add("QUIT_BTN","Quit");
                    mainFormWords.Add("APPROVE_TITLE","Quit approving");
                    mainFormWords.Add("APPROVE_TEXT","Do you want to stop trainee and quit?");
                    mainFormWords.Add("PLACEHOLDER","Search");
                    mainFormWords.Add("ONFORM_DELETE_BTN","Delete");
                    mainFormWords.Add("ONFORM_EDIT_BTN","Edit");
                    mainFormWords.Add("ACTIVE_REPEATING","Repeat word");
                    mainFormWords.Add("STATISTICS","Statistics");
                    mainFormWords.Add("TOTAL","Total: ");
                    mainFormWords.Add("WRONG","Wrong answers: ");
                    mainFormWords.Add("RIGHT","Right answers: ");
                    mainFormWords.Add("EXAMPLE", "Example");
                    mainFormWords.Add("DELETE_APPROVE", "Are you sure tha you want to delete this word");
                    mainFormWords.Add("CONFIRM_DELETE", "Confirm");
                    mainFormWords.Add("MAXTABPAGE", "Unfortunately maximum tab amount was reached. If you want to add another one language please contact us or delete one of you current language.");
                    mainFormWords.Add("EXPORT_SUC", "Successfully exported");
                    mainFormWords.Add("CREATED_FILE_IN", "Created file in");
                    return true;
                }
                
                fs = new FileStream(path, FileMode.Open);
                streamReader = new StreamReader(fs);
                string buffer;
                while ((buffer = streamReader.ReadLine()) != null)
                {
                    string[] subBuffer = buffer.Split("=");
                    mainFormWords.Add(subBuffer[0].Trim(), subBuffer[1]);
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
