using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WordRepeater.Model;
namespace WordRepeater
{
    public partial class RepeatWordForm : Form
    {
        int iSwitch;
        int iRightVariant;
        int[] ArrayOfValues=new int[4];
        List<WordToLearn> wtlToRepeat = null;
        public RepeatWordForm(int iSwitch)
        {
            this.iSwitch = iSwitch;
            
            InitializeComponent();
            if (null != Controller.eEnvironment.pRepeatWordForm)
                this.Location = (Point)Controller.eEnvironment.pRepeatWordForm;
            PrepareNewWord();
            wordToRepeat.Focus();
            
        }

        private void PrepareListOfWords(int delimeter)
        {
            try
            {
                int minCount, maxCount, average;
                List<int> languages = (from l in Controller.Languages where l.bIsActiveTraining == null || (bool)l.bIsActiveTraining select l.iCode).ToList<int>();
                var all = (from mc in Controller.wtlWordsToLearn where mc.bIsActive && languages.Contains(mc.iLanguageCode) orderby mc.iTotalAnswers descending select mc.iTotalAnswers);
                if (null != all && all.Count() > 0 && all.ElementAt(0) != null)
                {
                    minCount = (int)all.Min();
                    maxCount = (int)all.Max();

                    average = (minCount + maxCount) / delimeter;
                    wtlToRepeat = (from wtl in Controller.wtlWordsToLearn where wtl.bIsActive && languages.Contains(wtl.iLanguageCode) && (wtl.iTotalAnswers <= average || wtl.iTotalAnswers == null) select wtl).ToList<WordToLearn>();

                }
                else
                    wtlToRepeat = (from wtl in Controller.wtlWordsToLearn where wtl.bIsActive && languages.Contains(wtl.iLanguageCode) select wtl).ToList<WordToLearn>();

            }
            catch(Exception ex)
            {

            }
        }

        private void PrepareNewWord()
        {
            Random rnd = new Random();
            int index=0;
            int i;
            bool canWrite = true;
            try
            {
                if ((bool)Controller.sSettings.bRareAlgo)
                {
                    int delimeter = 10;
                    do
                    {
                        PrepareListOfWords(delimeter);
                        --delimeter;
                    }
                    while (wtlToRepeat.Count < 4);
                }
                else
                    wtlToRepeat = (from wtl in Controller.wtlWordsToLearn where wtl.bIsActive select wtl).ToList<WordToLearn>();

                for (i = 0; i < 4; i++)
                {
                    index = rnd.Next(0, wtlToRepeat.Count);
                    for (int j = 0; j < i; j++)
                        if (ArrayOfValues[j] == index)
                        {
                            i--;
                            canWrite = false;
                            break;
                        }
                    if (canWrite)
                    {
                        ArrayOfValues[i] = index;
                    }
                    else
                    {
                        canWrite = true;
                        continue;
                    }
                }

                //bool bForeignWordToTrain = (bool)Controller.sSettings.bForeignWordToTrain;
                int iForeignWordToTrain = (bool)Controller.sSettings.bForeignWordToTrain ?1:0;
                int iWay =iForeignWordToTrain+iSwitch;
                if (1==iWay)
                {
                    this.variant1.Text = wtlToRepeat[ArrayOfValues[0]].sTranslatedWord;
                    this.variant2.Text = wtlToRepeat[ArrayOfValues[1]].sTranslatedWord;
                    this.variant3.Text = wtlToRepeat[ArrayOfValues[2]].sTranslatedWord;
                    this.variant4.Text = wtlToRepeat[ArrayOfValues[3]].sTranslatedWord;
                }
                if (1 < iWay||iWay<1)
                {
                    this.variant1.Text = wtlToRepeat[ArrayOfValues[0]].sForeignWord;
                    this.variant2.Text = wtlToRepeat[ArrayOfValues[1]].sForeignWord;
                    this.variant3.Text = wtlToRepeat[ArrayOfValues[2]].sForeignWord;
                    this.variant4.Text = wtlToRepeat[ArrayOfValues[3]].sForeignWord;
                }
                
                iRightVariant = rnd.Next(0, 4);
                //просто заполняем каждый радиобатон данными, а затем вычисляем какой из них будет корректным
                if(1 == iWay)
                {
                    this.wordToRepeat.Text = wtlToRepeat[ArrayOfValues[iRightVariant]].sForeignWord;
                    this.exampleForWordToRepeat.Text = wtlToRepeat[ArrayOfValues[iRightVariant]].sForeignExample0;

                }
                if (1 < iWay || iWay < 1)
                {
                    this.wordToRepeat.Text = wtlToRepeat[ArrayOfValues[iRightVariant]].sTranslatedWord;
                    this.exampleForWordToRepeat.Text = wtlToRepeat[ArrayOfValues[iRightVariant]].sTranslatedExample0;

                }
                if (null == wtlToRepeat[ArrayOfValues[iRightVariant]].iRightAnswers)
                    wtlToRepeat[ArrayOfValues[iRightVariant]].iRightAnswers = 0;
                if (null == wtlToRepeat[ArrayOfValues[iRightVariant]].iWrongAnswers)
                    wtlToRepeat[ArrayOfValues[iRightVariant]].iWrongAnswers = 0;
            }
            catch(Exception ex)
            {

            }
        }

        private void RightVary(int index)
        {
            try
            {
                switch (iRightVariant)
                {
                    case 0:
                        variant1.BackColor = Color.LightGreen;
                        break;
                    case 1:
                        variant2.BackColor = Color.LightGreen;
                        break;
                    case 2:
                        variant3.BackColor = Color.LightGreen;
                        break;
                    case 3:
                        variant4.BackColor = Color.LightGreen;
                        break;
                }
                variant1.Enabled = false;
                variant2.Enabled = false;
                variant3.Enabled = false;
                variant4.Enabled = false;
                WordToLearn wtl = Controller.wtlWordsToLearn[index];
                wtl.iTotalAnswers = wtl.iRightAnswers + wtl.iWrongAnswers;
                //Controller.SaveDictionary();
                ContinueTraineeBtn.Enabled = true;
            }
            catch(Exception ex)
            {

            }
        }
        private void variant1_CheckedChanged(object sender, EventArgs e)
        {
            int index = 0;
            try
            {
                index = Controller.wtlWordsToLearn.IndexOf(wtlToRepeat[ArrayOfValues[iRightVariant]]);
                if (0 != iRightVariant)
                {
                    variant1.BackColor = Color.LightPink;
                    Controller.wtlWordsToLearn[index].iWrongAnswers++;
                }
                else
                    Controller.wtlWordsToLearn[index].iRightAnswers++;

                RightVary(index);
            }
            catch(Exception ex)
            {

            }
        }

        private void variant2_CheckedChanged(object sender, EventArgs e)
        {
            int index = 0;
            try
            {
                index = Controller.wtlWordsToLearn.IndexOf(wtlToRepeat[ArrayOfValues[iRightVariant]]);
                if (1 != iRightVariant)
                {
                    variant2.BackColor = Color.LightPink;
                    Controller.wtlWordsToLearn[index].iWrongAnswers++;
                }
                else
                    Controller.wtlWordsToLearn[index].iRightAnswers++;

                RightVary(index);
            }
            catch(Exception ex)
            {

            }
        }

        private void variant3_CheckedChanged(object sender, EventArgs e)
        {
            int index = 0;
            try
            {
                index = Controller.wtlWordsToLearn.IndexOf(wtlToRepeat[ArrayOfValues[iRightVariant]]);
                if (2 != iRightVariant)
                {
                    variant3.BackColor = Color.LightPink;
                    Controller.wtlWordsToLearn[index].iWrongAnswers++;
                }
                else
                    Controller.wtlWordsToLearn[index].iRightAnswers++;

                RightVary(index);
            }
            catch (Exception ex)
            {

            }
        }

        private void variant4_CheckedChanged(object sender, EventArgs e)
        {
            int index = 0;
            try
            {
                index = Controller.wtlWordsToLearn.IndexOf(wtlToRepeat[ArrayOfValues[iRightVariant]]);
                if (3 != iRightVariant)
                {
                    variant4.BackColor = Color.LightPink;
                    Controller.wtlWordsToLearn[index].iWrongAnswers++;
                }
                else
                    Controller.wtlWordsToLearn[index].iRightAnswers++;

                RightVary(index);
            }
            catch (Exception ex)
            {

            }
        }

        private void ContinueTraineeBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RepeatingMenuButton_Click(object sender, EventArgs e)
        {
            RepeatingContextMenu.Show(RepeatingMenuButton, 0, 43);
        }


        private void stopRepeatingThisWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (wtlToRepeat[ArrayOfValues[iRightVariant]].bIsActive)
                {
                    wtlToRepeat[ArrayOfValues[iRightVariant]].SwitchActivity();

                    RepeatingContextMenu.Items[0].Text = "Start repeating this word again";
                }
                else
                {
                    RepeatingContextMenu.Items[0].Text = "Stop repeating this word";
                    wtlToRepeat[ArrayOfValues[iRightVariant]].SwitchActivity();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            
            Thread sv=new Thread(Controller.SaveDictionary);//вынесли в отдельный поток сохранение словаря. иначе при большом объёме данных проверка слов при тайминге=0 ОЧЕНЬ сильно тормозит
            sv.Start();
            
        }

        private void LocationChange(object sender, EventArgs e)
        {
            Controller.eEnvironment.pRepeatWordForm = this.Location;
            Controller.SaveEnvironment();
        }
    }
}
