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
        public Point? pMainForm;//координаты основного окна
        public Point? pRepeatWordForm;//координаты окна повторяемого слова
        public Point? pSettingsForm;//координаты окна сохранения настроек
        public Point? pAddNewWordForm;
        public Point? pAutoLoadListForm;
        public Point? pStatisticsForm;
        public Point? pEditWordForm;
        public Point? pCreateNewLanguageForm;
        public Point? pEditLanguageNameForm;
        public Point? pAboutForm;
    }
}
