using System;
using System.Collections.Generic;
using System.Text;

namespace WordRepeater.Model
{
    [Serializable]
    public class Settings
    {
        public int iMultiLanguageTraining { get; private set; } = 1;//Поле указывает количество тренируемых языков
        public int iRepeatSeconds { get; set; } = 15;//количество секунд между повторениями
        public bool bTrainingIsActive { get; set; } = true;
        public bool? bStartOnLoad { get; set; } = true;
        public bool? bRareAlgo { get; set; } = true;
        public bool? bSwitchLanguagesWhileTrainee { get; set; } = false;
        public bool? bForeignWordToTrain { get; set; } = true;//повторяемое слово иностранное (то есть отобрадаем иностранное слово и варианты его перевода на родной язык, или наоборот)
        public string sApplicationLanguage { get; set; }
    }
}
