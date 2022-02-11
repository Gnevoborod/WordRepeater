using System;
using WordRepeater.Model;
using System.Windows.Forms;
using System.Drawing;

namespace WordRepeater
{
    public partial class EditWordForm : Form
    {
        WordToLearn wordToLearn;
        MainForm mfMainForm;
        public EditWordForm(ref WordToLearn wtl, MainForm mf)
        {
            wordToLearn = wtl;
            mfMainForm = mf;
            InitializeComponent();
            if (null != Controller.eEnvironment.pEditWordForm)
                this.Location = (Point)Controller.eEnvironment.pEditWordForm;
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
            string sForeignWord= WordTextBox.Text;
            string sTranslatedWord= TranslationTextBox.Text;
            string sForeignExample0= ExampleTextBox0.Text;
            string sForeignExample1 = ExampleTextBox1.Text;
            string sForeignExample2 = ExampleTextBox2.Text;
            string sTranslatedExample0 = TranslationTextBox0.Text;
            string sTranslatedExample1 = TranslationTextBox1.Text;
            string sTranslatedExample2 = TranslationTextBox2.Text;
            wordToLearn.EditFields(sForeignWord, sTranslatedWord, sForeignExample0, sTranslatedExample0, sForeignExample1, sTranslatedExample1, sForeignExample2, sTranslatedExample2);
            Controller.SaveDictionary();
            this.Close();
            mfMainForm.FillTabs();
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Controller.eEnvironment.pEditWordForm = this.Location;
            Controller.SaveEnvironment();
        }
    }
}
