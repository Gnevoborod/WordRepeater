using System;
using System.Collections.Generic;
using System.Linq;

namespace WordRepeater.Model
{
    [Serializable]
    public class Language
    {
        public string sName { get; set; }
        public int iCode { get; private set; }
        public bool bIsActive { get; set; } = true;
        public bool? bIsActiveTraining { get; set; } = true;

        public Language(string _sName)
        {
            sName = _sName;
            if ((null == Controller.Languages) || (Controller.Languages.Count<1))
                iCode = 0;
            else
                iCode = Controller.Languages.Max<Language>(l => l.iCode)+1;
        }
    }
}
