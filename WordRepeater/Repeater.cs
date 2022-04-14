using System.Threading;
using System;

namespace WordRepeater
{
    public class Repeater
    {
        RepeatWordForm rwfRepeatWordForm;
        int iSwitch = 0;
       
        public void Repeat()
        {
            try
            {
                int counter;

                while (null != Controller.wtlWordsToLearn)
                {
                    for (counter = 0; counter < Controller.sSettings.iRepeatSeconds; counter++)
                    {
                        Thread.Sleep(1000);
                        if (Program.ToClose)
                            return;
                        if (!Controller.sSettings.bTrainingIsActive)
                            continue;
                    }
                    if (4 > Controller.wtlWordsToLearn.Count)
                        continue;
                    if (Program.ToClose)
                        return;
                    if (!Controller.sSettings.bTrainingIsActive)
                        continue;
                    if ((bool)Controller.sSettings.bSwitchLanguagesWhileTrainee || null == Controller.sSettings.bSwitchLanguagesWhileTrainee)
                        if (iSwitch > 0)
                            iSwitch--;
                        else
                            iSwitch++;
                    else
                        if (iSwitch > 0)
                        iSwitch = 0;
                    rwfRepeatWordForm = new RepeatWordForm(iSwitch);
                    rwfRepeatWordForm.ShowDialog();

                }
            }
            catch(Exception ex)
            {

            }
        }

    }
}
