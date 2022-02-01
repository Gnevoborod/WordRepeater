using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WordRepeater
{
    public class Repeater
    {
        RepeatWordForm rwfRepeatWordForm;

       
        public void Repeat()
        {

            while (null!=Controller.wtlWordsToLearn)
            {
                Thread.Sleep(Controller.sSettings.iRepeatSeconds * 1000);
                if (Program.ToClose)
                    return;
                if (4 > Controller.wtlWordsToLearn.Count)
                    continue;
                if (!Controller.sSettings.bTrainingIsActive)
                    continue;
                rwfRepeatWordForm = new RepeatWordForm(this);
                rwfRepeatWordForm.ShowDialog();
                
            }
        }

        public bool Check(int iVariant)
        {
            return true;
        }

        public void Stop()
        {
           
        }
    }
}
