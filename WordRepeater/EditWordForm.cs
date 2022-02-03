using System;
using WordRepeater.Model;
using System.Windows.Forms;

namespace WordRepeater
{
    public partial class EditWordForm : Form
    {
        WordToLearn wordToLearn;
        MainForm mfMainForm;
        public EditWordForm(WordToLearn wtl, MainForm mf)
        {
            wordToLearn = wtl;
            mfMainForm = mf;
            InitializeComponent();
            WordTextBox.Text = wordToLearn.sForeignWord;
            TranslationTextBox.Text = wordToLearn.sTranslatedWord;
            ExampleTextBox0.Text = wordToLearn.sForeignExample0;
            ExampleTextBox1.Text = wordToLearn.sForeignExample1;
            ExampleTextBox2.Text = wordToLearn.sForeignExample2;
            TranslationTextBox0.Text = wordToLearn.sTranslatedExample0;
            TranslationTextBox1.Text = wordToLearn.sTranslatedExample1;
            TranslationTextBox2.Text = wordToLearn.sTranslatedExample2;

        }


        private void EditWordButton_Click(object sender, EventArgs e)
        {
            //сделать метод редактирования слова в словаре и прикрутить его сюда
            this.Close();
            mfMainForm.FillTabs();
        }
    }
}
