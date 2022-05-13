using System.Collections.Generic;
using System.IO;

namespace WordRepeater.Languages
{
    public class SettingsFormLanguage
    {
        public bool bIsDefaultedLanguage = false;
        public string sLanguageToLoad;
        public Dictionary<string, string> settingsFormWords;

        public SettingsFormLanguage(bool flag, string langToLoad)
        {
            bIsDefaultedLanguage = !flag;//false становится true. True-если успешно загружен словарь с названиями языков.
            sLanguageToLoad = langToLoad;//имя языка ru, en etc

            settingsFormWords = new Dictionary<string, string>();
        }
        public bool LoadApplicationLanguages()
        {
            string path = Program.PATH + "Localization\\" + sLanguageToLoad + "\\SettingsForm.txt";
            FileStream fs;
            StreamReader streamReader = null;
            try
            {
                if (!File.Exists(path) || bIsDefaultedLanguage)
                {
                    settingsFormWords.Add("TITLE", "Settings");
                    settingsFormWords.Add("TAB_LANGUAGE", "Languages");
                    settingsFormWords.Add("TAB_TRAINING", "Trainee");
                    settingsFormWords.Add("TAB_APPLICATION", "Application");
                    settingsFormWords.Add("TAB_LANGUAGE_LABEL", "Learning languages:");
                    settingsFormWords.Add("TAB_LANGUAGE_CHECKBOX", "Repeat words of this language");
                    settingsFormWords.Add("TAB_TRAINING_LABEL", "Seconds between repeating");
                    settingsFormWords.Add("TAB_TRAINING_TRAININGACTIVE", "Training is active");
                    settingsFormWords.Add("TAB_TRAINING_RAREWORDS", "Rare repeating words to repeat in priority");
                    settingsFormWords.Add("TAB_TRAINING_FOREIGN", "Repeating words are foreign");
                    settingsFormWords.Add("TAB_TRAINING_SWITCH", "Switch foreign and mother language for repeating word while trainee");
                    settingsFormWords.Add("TAB_APPLICATION_LABEL_AL", "Application language:");
                    settingsFormWords.Add("TAB_APPLICATION_BTN_AL", "Change language");
                    settingsFormWords.Add("TAB_APPLICATION_AUTORUN", "Run when computer turns on");
                    settingsFormWords.Add("TAB_LANGUAGE_DELETE_TITLE", "Confirmation");
                    settingsFormWords.Add("TAB_LANGUAGE_DELETE_BODY2", "All words for that language will be also deleted.");
                    settingsFormWords.Add("TAB_LANGUAGE_DELETE_BODY1", "Are you sure you want to delete the language");
                    settingsFormWords.Add("TAB_LANGUAGE_SUCCESS", "Language has been deleted successfully");
                    settingsFormWords.Add("TAB_LANGUAGE_SUCCESS_TITLE", "Succcessfull");

                    return true;
                }

                fs = new FileStream(path, FileMode.Open);
                streamReader = new StreamReader(fs);
                string buffer;
                while ((buffer = streamReader.ReadLine()) != null)
                {
                    string[] subBuffer = buffer.Split("=");
                    settingsFormWords.Add(subBuffer[0].Trim(), subBuffer[1]);
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
