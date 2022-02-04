using System;
using System.Collections.Generic;
using System.Text;

namespace WordRepeater.Model
{
    [Serializable]
    public class WordToLearn
    {
        public int iLanguageCode { get; private set; }//код языка к которому относится слово
        public string sForeignWord { get; private set; }//иностранное слово
        public string sTranslatedWord { get; private set; }//перевод
        public string sForeignExample0 { get; private set; }//пример использования слова
        public string sTranslatedExample0 { get; private set; }//перевод примера
        public string sForeignExample1 { get; private set; }
        public string sTranslatedExample1 { get; private set; }
        public string sForeignExample2 { get; private set; }
        public string sTranslatedExample2 { get; private set; }
        public List<int>? lSameWords { get; set; }//массив таких же слов, но с другими значениями
        public bool bIsActive { get; private set; } = true;//флаг активности записи. если запись неактивна - слово не отображается для заучивания 
        public int? iRightAnswers = 0;
        public int? iWrongAnswers = 0;
        public WordToLearn(int iLCode, string sFWord, string sTWord, string sFExample0, string sTExample0, string sFExample1, string sTExample1, string sFExample2, string sTExample2)
        {
            iLanguageCode = iLCode;
            sForeignWord = sFWord;
            sTranslatedWord = sTWord;
            sForeignExample0 = sFExample0;
            sTranslatedExample0 = sTExample0;
            sForeignExample1 = sFExample1;
            sTranslatedExample1 = sTExample1;
            sForeignExample2 = sFExample2;
            sTranslatedExample2 = sTExample2;
        }
        //редактируем запись
        public void EditFields(string sFWord, string sTWord, string sFExample0, string sTExample0, string sFExample1, string sTExample1, string sFExample2, string sTExample2)
        {
            sForeignWord = sFWord;
            sTranslatedWord = sTWord;
            sForeignExample0 = sFExample0;
            sTranslatedExample0 = sTExample0;
            sForeignExample1 = sFExample1;
            sTranslatedExample1 = sTExample1;
            sForeignExample2 = sFExample2;
            sTranslatedExample2 = sTExample2;
        }
        public void SwitchActivity()
        {
            this.bIsActive = !this.bIsActive;

            Controller.SaveDictionary();
        }
        
    }
}
