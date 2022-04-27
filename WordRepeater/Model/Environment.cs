using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordRepeater.Model
{
    [Serializable]
    public class Environment
    {
        public Point? pMainForm { get; set; } =null;//координаты основного окна
        public Size? sMainForm { get; set; } = null;//размер основного окна
        public Point? pRepeatWordForm { get; set; } = null;//координаты окна повторяемого слова
        public Point? pSettingsForm { get; set; } = null;//координаты окна сохранения настроек
        public Point? pAddNewWordForm { get; set; } = null;
        public Point? pAutoLoadListForm { get; set; } = null;
        public Point? pStatisticsForm { get; set; } = null;
        public Point? pEditWordForm { get; set; } = null;
        public Point? pCreateNewLanguageForm { get; set; } = null;
        public Point? pEditLanguageNameForm { get; set; } = null;
        public Point? pAboutForm { get; set; } = null;
    }
}
