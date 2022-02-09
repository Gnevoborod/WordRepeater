using System.Threading;
using System;

namespace WordRepeater
{
    public class Repeater
    {
        RepeatWordForm rwfRepeatWordForm;

       
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
                    rwfRepeatWordForm = new RepeatWordForm(this);
                    rwfRepeatWordForm.ShowDialog();

                }
            }
            catch(Exception ex)
            {

            }
        }

    }
}
