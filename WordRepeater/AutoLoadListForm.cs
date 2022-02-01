using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WordRepeater.Model;

namespace WordRepeater
{
    public partial class AutoLoadListForm : Form
    {
        string FILE_PATH;
        MainForm mfMainForm;
        public AutoLoadListForm(MainForm mf)
        {
            InitializeComponent();
            mfMainForm = mf;
            if (null != Controller.Languages)
            {
                foreach (Language elem in Controller.Languages)
                {
                    if (elem.bIsActive)
                        AutoLoadComboBox.Items.Add(elem.sName);
                }
            }
        }

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            FILE_PATH = openFileDialog1.FileName;
            PathLabel.Text = FILE_PATH;
        }

        private void AutoLoadBtn_Click(object sender, EventArgs e)
        {
            if (AutoLoadComboBox.SelectedIndex < 0)
                return;
            if (!File.Exists(FILE_PATH))
                return;
            int nextDelimeter = 0;
            int nextStart = 0;
            IEnumerable<string> lines = File.ReadLines(FILE_PATH);
            try
            {
                foreach (string currentString in lines)
                {
                    string workingString = currentString;
                    nextDelimeter = workingString.IndexOf(';');
                    string sForeignWord = workingString.Substring(0, nextDelimeter);
                    nextStart = nextDelimeter + 1;
                    workingString = workingString.Substring(nextStart);
                    nextDelimeter = workingString.IndexOf(';');
                    string sTranslatedWord = workingString.Substring(0, nextDelimeter);
                    nextStart = nextDelimeter + 1;
                    workingString = workingString.Substring(nextStart);
                    nextDelimeter = workingString.IndexOf(';');
                    string sForeignExample0;
                    if ((nextDelimeter - nextStart) < 2)
                        sForeignExample0 = "";
                    else
                        sForeignExample0 = workingString.Substring(0, nextDelimeter);

                    nextStart = nextDelimeter + 1;
                    workingString = workingString.Substring(nextStart);
                    nextDelimeter = workingString.IndexOf(';');
                    string sTranslatedExample0;
                    if (nextDelimeter < 1)
                        sTranslatedExample0 = "";
                    else
                        sTranslatedExample0 = workingString.Substring(0, nextDelimeter);

                    nextStart = nextDelimeter + 1;
                    workingString = workingString.Substring(nextStart);
                    nextDelimeter = workingString.IndexOf(';');
                    string sForeignExample1;
                    if (nextDelimeter < 1)
                        sForeignExample1 = "";
                    else
                        sForeignExample1 = workingString.Substring(0, nextDelimeter);

                    nextStart = nextDelimeter + 1;
                    workingString = workingString.Substring(nextStart);
                    nextDelimeter = workingString.IndexOf(';');
                    string sTranslatedExample1;
                    if (nextDelimeter < 1)
                        sTranslatedExample1 = "";
                    else
                        sTranslatedExample1 = workingString.Substring(0, nextDelimeter);


                    nextStart = nextDelimeter + 1;
                    workingString = workingString.Substring(nextStart);
                    nextDelimeter = workingString.IndexOf(';');
                    string sForeignExample2;
                    if (nextDelimeter < 1)
                        sForeignExample2 = "";
                    else
                        sForeignExample2 = workingString.Substring(0, nextDelimeter);

                    nextStart = nextDelimeter + 1;
                    workingString = workingString.Substring(nextStart);
                    nextDelimeter = workingString.IndexOf(';');
                    string sTranslatedExample2;
                    if (nextDelimeter < 1)
                        sTranslatedExample2 = "";
                    else
                        sTranslatedExample2 = workingString.Substring(0, nextDelimeter);

                    WordToLearn wtlTemp = new WordToLearn(Controller.Languages[AutoLoadComboBox.SelectedIndex].iCode, sForeignWord, sTranslatedWord, sForeignExample0, sTranslatedExample0, sForeignExample1, sTranslatedExample1, sForeignExample2, sTranslatedExample2);
                    Controller.AddNewWordToDictionary(wtlTemp);
                }
    
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bad structure of file. Can not proceed.");
            }
            finally
            {

            }
            mfMainForm.FillTabs();
            this.Dispose();
        }
    }
}
