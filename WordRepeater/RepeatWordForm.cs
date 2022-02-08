using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using WordRepeater.Model;
namespace WordRepeater
{
    public partial class RepeatWordForm : Form
    {
        Repeater rRepeater;
        int iRightVariant;
        int[] ArrayOfValues=new int[4];
        List<WordToLearn> wtlToRepeat = null;
        public RepeatWordForm(Repeater r)
        {
            rRepeater = r;
            
            InitializeComponent();
            PrepareNewWord();
            wordToRepeat.Focus();
            
        }

        private void PrepareNewWord()
        {
            Random rnd = new Random();
            int index=0;
            int i, minCount, maxCount, average;
            bool canWrite = true;
            
            var all=(from mc in Controller.wtlWordsToLearn where mc.bIsActive orderby mc.iTotalAnswers descending select mc.iTotalAnswers);
            if (null != all && all.Count()>0 && all.ElementAt(0)!=null)
            {
                minCount = (int)all.Min();
                maxCount = (int)all.Max();
                average = (minCount + maxCount) / 2;
                int avv = (int)all.Average();
                wtlToRepeat = (from wtl in Controller.wtlWordsToLearn where wtl.bIsActive && (wtl.iTotalAnswers <= average || wtl.iTotalAnswers==null) select wtl).ToList<WordToLearn>();
            }
            else
                wtlToRepeat = (from wtl in Controller.wtlWordsToLearn where wtl.bIsActive select wtl).ToList<WordToLearn>();
            
            for (i = 0; i < 4; i++)
            {
                index = rnd.Next(0, wtlToRepeat.Count);
                for(int j=0;j<i;j++)
                    if(ArrayOfValues[j]==index)
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
            this.variant1.Text = wtlToRepeat[ArrayOfValues[0]].sTranslatedWord;
            this.variant2.Text = wtlToRepeat[ArrayOfValues[1]].sTranslatedWord;
            this.variant3.Text = wtlToRepeat[ArrayOfValues[2]].sTranslatedWord;
            this.variant4.Text = wtlToRepeat[ArrayOfValues[3]].sTranslatedWord;
            iRightVariant = rnd.Next(0, 4);
            //просто заполняем каждый радиобатон данными, а затем вычисляем какой из них будет корректным
            this.wordToRepeat.Text = wtlToRepeat[ArrayOfValues[iRightVariant]].sForeignWord;
            this.exampleForWordToRepeat.Text= wtlToRepeat[ArrayOfValues[iRightVariant]].sForeignExample0;
            if (null == wtlToRepeat[ArrayOfValues[iRightVariant]].iRightAnswers)
                wtlToRepeat[ArrayOfValues[iRightVariant]].iRightAnswers = 0;
            if (null == wtlToRepeat[ArrayOfValues[iRightVariant]].iWrongAnswers)
                wtlToRepeat[ArrayOfValues[iRightVariant]].iWrongAnswers = 0;

        }

        private void RightVary(int index)
        {
            switch(iRightVariant)
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
            Controller.wtlWordsToLearn[index].iTotalAnswers = Controller.wtlWordsToLearn[index].iRightAnswers + Controller.wtlWordsToLearn[index].iWrongAnswers;
            Controller.SaveDictionary();
            ContinueTraineeBtn.Enabled = true;
        }
        private void variant1_CheckedChanged(object sender, EventArgs e)
        {
            int index = 0;
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

        private void variant2_CheckedChanged(object sender, EventArgs e)
        {
            int index = 0;
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

        private void variant3_CheckedChanged(object sender, EventArgs e)
        {
            int index = 0;
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

        private void variant4_CheckedChanged(object sender, EventArgs e)
        {
            int index = 0;
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
    }
}
