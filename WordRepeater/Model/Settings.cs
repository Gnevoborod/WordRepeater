using System;
using System.Collections.Generic;
using System.Text;

namespace WordRepeater.Model
{
    [Serializable]
    public static class Settings
    {
        public static int iMultiLanguageTraining { get; private set; } = 1;//Поле указывает количество тренируемых языков
        public static int iVersionOfModels { get; private set; }//Номер версии моделей. На случай если модели внутри ПО обновлены(добавлено поле, например) и нужна конвертация данных размещённых на диске пользователя.
        public static List<string> Languages { get; private set; }//Список языков

        public static void AddNewLanguage(string language)
        {
            if (null != Languages)
                Languages.Add(language);
            else
            {
                Languages = new List<string>();
                Languages.Add(language);
            }
        }

        public static void LoadSettings()
        {
            Languages = new List<string>();
        }
        
        public static bool HasLanguage(string language)
        {
            if (null == Languages)
                return false;
            if (Languages.Contains(language))
            {
                return true;
            }
            else
                return false;
        }
    }
}
