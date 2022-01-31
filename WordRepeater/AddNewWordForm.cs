using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WordRepeater.Model;

namespace WordRepeater
{
    public partial class AddNewWordForm : Form
    {
        int iLanguageCode;
        MainForm mfMainForm;
        public AddNewWordForm(int iLCode, MainForm mf)
        {
            iLanguageCode = iLCode;
            mfMainForm = mf;
            InitializeComponent();
        }

        private void AddWordButton_Click(object sender, EventArgs e)
        {
            string sForeignWord=WordTextBox.Text.Trim();
            string sTranslatedWord=TranslationTextBox.Text.Trim();
            string sForeignExample0=ExampleTextBox0.Text.Trim();
            string sTranslatedExample0=TranslationTextBox0.Text.Trim();
            string sForeignExample1=ExampleTextBox1.Text.Trim();
            string sTranslatedExample1=TranslationTextBox1.Text.Trim();
            string sForeignExample2=ExampleTextBox2.Text.Trim();
            string sTranslatedExample2=TranslationTextBox2.Text.Trim();
            WordToLearn wtlWordToLearn = new WordToLearn(iLanguageCode, sForeignWord,sTranslatedWord,sForeignExample0,sTranslatedExample0, sForeignExample1, sTranslatedExample1, sForeignExample2, sTranslatedExample2);
            Controller.AddNewWordToDictionary(wtlWordToLearn);
            this.Hide();
            mfMainForm.FillTabs();
           
        }
    }
}
