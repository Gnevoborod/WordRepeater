using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Dispose();
            //rRepeater.Repeat();
        }

        private void PrepareNewWord()
        {
            Random rnd = new Random();
            int index=0;
            int i;
            bool canWrite = true;
            for (i = 0; i < 4; i++)
            {
                index = rnd.Next(0, Controller.wtlWordsToLearn.Count - 1);
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
            this.variant1.Text = Controller.wtlWordsToLearn[ArrayOfValues[0]].sTranslatedWord;
            this.variant2.Text = Controller.wtlWordsToLearn[ArrayOfValues[1]].sTranslatedWord;
            this.variant3.Text = Controller.wtlWordsToLearn[ArrayOfValues[2]].sTranslatedWord;
            this.variant4.Text = Controller.wtlWordsToLearn[ArrayOfValues[3]].sTranslatedWord;
            iRightVariant = rnd.Next(1, 4);
            //просто заполняем каждый радиобатон данными, а затем вычисляем какой из них будет корректным
            this.wordToRepeat.Text = Controller.wtlWordsToLearn[ArrayOfValues[iRightVariant]].sForeignWord;
            this.exampleForWordToRepeat.Text= Controller.wtlWordsToLearn[ArrayOfValues[iRightVariant]].sForeignExample0;
            

        }
    }
}
