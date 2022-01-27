using System;
using System.Collections.Generic;
using System.Text;

namespace WordRepeater.Model
{
    [Serializable]
    class WordToLearn
    {
        public int iLanguageCode { get; private set; }//код языка к которому относится слово
        public string sForeignWord { get; private set; }//иностранное слово
        public string sTranslatedWord { get; private set; }//перевод
        public string sForeignExample { get; private set; }//пример использования слова
        public string sTranslatedExample { get; private set; }//перевод примера
        public bool bIsActive=true;//флаг активности записи. если запись неактивна - слово не отображается для заучивания 

        //создаём запись
        public WordToLearn(int iLCode, string sFWord, string sTWord, string sFExample, string sTExample)
        {
            iLanguageCode = iLCode;
            sForeignWord = sFWord;
            sTranslatedWord = sTWord;
            sForeignExample = sFExample;
            sTranslatedExample = sTExample;
        }
        //редактируем запись
        public void EditFields(int iLCode, string sFWord, string sTWord, string sFExample, string sTExample, bool bIActive)
        {
            iLanguageCode = iLCode;
            sForeignWord = sFWord;
            sTranslatedWord = sTWord;
            sForeignExample = sFExample;
            sTranslatedExample = sTExample;
            bIsActive = bIActive;
        }
    }
}
