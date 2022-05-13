using System.Threading;
using System;
using WordRepeater.Languages;
namespace WordRepeater
{
    public class Repeater
    {
        RepeatWordForm rwfRepeatWordForm;
        RepeaterFormLanguage repeaterFormLanguage;
        int iSwitch = 0;
        public Repeater(string sISO)
        {
            SetTexts(sISO);
        }
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
                    if (null != Controller.sSettings.bSwitchLanguagesWhileTrainee && (bool)Controller.sSettings.bSwitchLanguagesWhileTrainee)
                        if (iSwitch > 0)
                            iSwitch--;
                        else
                            iSwitch++;
                    else
                        if (iSwitch > 0)
                        iSwitch = 0;
                    rwfRepeatWordForm = new RepeatWordForm(iSwitch, repeaterFormLanguage);
                    rwfRepeatWordForm.ShowDialog();

                }
            }
            catch(Exception ex)
            {

            }
        }

        public void SetTexts(string sISO)
        {
            LanguageManager languageManager = new LanguageManager(sISO);
            repeaterFormLanguage = languageManager.LoadRepeaterFormText();
            //Describe the load of the dictionary here
            //then send it into RepeatWordForm
        }

    }
}
