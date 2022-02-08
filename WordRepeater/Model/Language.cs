using System;
using System.Collections.Generic;
using System.Text;

namespace WordRepeater.Model
{
    [Serializable]
    public class Language
    {
        public string sName { get; private set; }
        public int iCode { get; private set; }
        public bool bIsActive { get; private set; } = true;

        public Language(string _sName)
        {
            sName = _sName;
            if (null == Controller.Languages)
                iCode = 0;
            else
                iCode = Controller.Languages.Count;
        }
    }
}
