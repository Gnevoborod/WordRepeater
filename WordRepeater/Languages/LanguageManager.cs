using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordRepeater.Languages
{
    public class LanguageManager
    {
        public ApplicationLanguage applicationLanguage;
        MainFormLanguage mainFormLanguage;
        RepeaterFormLanguage repeaterFormLanguage;
        SettingsFormLanguage settingsFormLanguage;
        bool isLanguagesLoaded;
        string languageCode;
        public LanguageManager(string langCode)
        {
            applicationLanguage = new ApplicationLanguage();
            isLanguagesLoaded=applicationLanguage.LoadLanguageList();
            languageCode = langCode;
            
        }
        public MainFormLanguage LoadMainFormText()
        {
            mainFormLanguage = new MainFormLanguage(isLanguagesLoaded, languageCode);//пробрасываем значение определённое в системе или же значение установленное в настройках
            mainFormLanguage.LoadApplicationLanguages();
            return mainFormLanguage;
        }

        public RepeaterFormLanguage LoadRepeaterFormText()
        {
            repeaterFormLanguage = new RepeaterFormLanguage(isLanguagesLoaded, languageCode);//пробрасываем значение определённое в системе или же значение установленное в настройках
            repeaterFormLanguage.LoadApplicationLanguages();
            return repeaterFormLanguage;
        }

        public SettingsFormLanguage LoadSettingsFormText()
        {
            settingsFormLanguage = new SettingsFormLanguage(isLanguagesLoaded, languageCode);//пробрасываем значение определённое в системе или же значение установленное в настройках
            settingsFormLanguage.LoadApplicationLanguages();
            return settingsFormLanguage;
        }
        //method for repeating form ought to return the object includes all needed texts. Otherwise we'll have LanguageManager stucked in the memory
    }
}
