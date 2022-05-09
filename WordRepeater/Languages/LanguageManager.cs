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
        public MainFormLanguage mainFormLanguage;

        public LanguageManager(string langCode)
        {
            applicationLanguage = new ApplicationLanguage();
            bool isLanguagesLoaded=applicationLanguage.LoadLanguageList();
            mainFormLanguage = new MainFormLanguage(isLanguagesLoaded,langCode);//пробрасываем значение определённое в системе или же значение установленное в настройках
            mainFormLanguage.LoadApplicationLanguages();
        }
    }
}
