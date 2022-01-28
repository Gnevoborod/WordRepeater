using System;
using System.Collections.Generic;
using System.Text;

namespace WordRepeater.Model
{
    [Serializable]
    public class Settings
    {
        public int iMultiLanguageTraining { get; private set; } = 1;//Поле указывает количество тренируемых языков
        public int iRepeatSeconds { get; set; } = 60;//количество секунд между повторениями
        public bool bTrainingIsActive { get; set; }
        public static void LoadSettings()
        {
        
        }
        
    }
}
