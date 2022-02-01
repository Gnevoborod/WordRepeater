using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using WordRepeater.Model;
namespace WordRepeater
{
    public partial class RepeatWordForm : Form
    {
        Repeater rRepeater;
        int iRightVariant;
        int[] ArrayOfValues=new int[4];
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
            int i;
            bool canWrite = true;
            var wtlToRepeat = (from wtl in Controller.wtlWordsToLearn where wtl.bIsActive select wtl).ToList<WordToLearn>();

            for (i = 0; i < 4; i++)
            {
                index = rnd.Next(0, wtlToRepeat.Count - 1);
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
            iRightVariant = rnd.Next(1, 4);
            //просто заполняем каждый радиобатон данными, а затем вычисляем какой из них будет корректным
            this.wordToRepeat.Text = wtlToRepeat[ArrayOfValues[iRightVariant]].sForeignWord;
            this.exampleForWordToRepeat.Text= wtlToRepeat[ArrayOfValues[iRightVariant]].sForeignExample0;
            

        }

        private void RightVary()
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
            ContinueTraineeBtn.Enabled = true;
        }
        private void variant1_CheckedChanged(object sender, EventArgs e)
        {
            if (0 != iRightVariant)
                variant1.BackColor = Color.LightPink;
            RightVary();
        }

        private void variant2_CheckedChanged(object sender, EventArgs e)
        {
            if (1 != iRightVariant)
                variant2.BackColor = Color.LightPink;
            RightVary();
        }

        private void variant3_CheckedChanged(object sender, EventArgs e)
        {
            if (2 != iRightVariant)
                variant3.BackColor = Color.LightPink;
            RightVary();
        }

        private void variant4_CheckedChanged(object sender, EventArgs e)
        {
            if (3 != iRightVariant)
                variant4.BackColor = Color.LightPink;
            RightVary();
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
            if (Controller.wtlWordsToLearn[ArrayOfValues[iRightVariant]].bIsActive)
            {
                Controller.wtlWordsToLearn[ArrayOfValues[iRightVariant]].bIsActive = false;

                RepeatingContextMenu.Items[0].Text = "Start repeating this word again";
            }
            else
            {
                RepeatingContextMenu.Items[0].Text = "Stop repeating this word";
                Controller.wtlWordsToLearn[ArrayOfValues[iRightVariant]].bIsActive = true;
            }
        }
    }
}
