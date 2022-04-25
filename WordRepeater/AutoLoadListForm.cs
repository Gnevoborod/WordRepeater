using System;
using System.Collections.Generic;
using System.Drawing;
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
            if (null != Controller.eEnvironment.pAutoLoadListForm)
                this.Location = (Point)Controller.eEnvironment.pAutoLoadListForm;
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
            try
            {
                if (AutoLoadComboBox.SelectedIndex < 0)
                    return;
                if (!File.Exists(FILE_PATH))
                    return;
                int nextDelimeter = 0;
                int nextStart = 0;
                IEnumerable<string> lines = File.ReadLines(FILE_PATH);
                foreach (string currentString in lines)
                {
                    var newLine = currentString.Split(';');
                    string sForeignWord = newLine[0];
                    string sTranslatedWord = newLine[1];
                    string sForeignExample0, sTranslatedExample0, sForeignExample1, sTranslatedExample1, sForeignExample2, sTranslatedExample2;
                    sForeignExample0 = newLine[2];
                    sTranslatedExample0 = newLine[3];
                    sForeignExample1 = newLine[4];
                    sTranslatedExample1 = newLine[5];
                    sForeignExample2 = newLine[6];
                    sTranslatedExample2 = newLine[7];
                    WordToLearn wtlTemp = new WordToLearn(Controller.Languages[AutoLoadComboBox.SelectedIndex].iCode, sForeignWord, sTranslatedWord, sForeignExample0, sTranslatedExample0, sForeignExample1, sTranslatedExample1, sForeignExample2, sTranslatedExample2);
                    Controller.wtlWordsToLearn.Add(wtlTemp);

                }
                Controller.SaveDictionary();
                MessageBox.Show("Words was successfully exported", "Successfull");

            }
            catch(Exception ex)
            {
                
                MessageBox.Show("Bad structure of file. Can not proceed.");
            }
            finally
            {

                Controller.eEnvironment.pAutoLoadListForm = this.Location;
                Controller.SaveEnvironment();
                mfMainForm.FillTabs();
                this.Dispose();
            }

        }
            private void AutoLoadBtn_Click_(object sender, EventArgs e)
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
                    nextDelimeter = Utils.Strchr(ref workingString, ';');//workingString.IndexOf(';');
                    string sForeignWord = Utils.Substr(ref workingString, 0, nextDelimeter);//workingString.Substring(0, nextDelimeter);
                    nextStart = nextDelimeter + 1;
                    workingString = Utils.Substr(ref workingString, nextStart);// workingString.Substring(nextStart);
                    nextDelimeter = Utils.Strchr(ref workingString, ';');//workingString.IndexOf(';');
                    string sTranslatedWord = Utils.Substr(ref workingString, 0, nextDelimeter);//workingString.Substring(0, nextDelimeter);
                    nextStart = nextDelimeter + 1;
                    workingString = Utils.Substr(ref workingString, nextStart);//workingString.Substring(nextStart);
                    nextDelimeter = Utils.Strchr(ref workingString, ';');//workingString.IndexOf(';');
                    string sForeignExample0;
                    if ((nextDelimeter - nextStart) < 2)
                        sForeignExample0 = "";
                    else
                        sForeignExample0 = Utils.Substr(ref workingString, 0, nextDelimeter);//workingString.Substring(0, nextDelimeter);

                    nextStart = nextDelimeter + 1;
                    workingString = Utils.Substr(ref workingString, nextStart);//workingString.Substring(nextStart);
                    nextDelimeter = Utils.Strchr(ref workingString, ';');//workingString.IndexOf(';');
                    string sTranslatedExample0;
                    if (nextDelimeter < 1)
                        sTranslatedExample0 = "";
                    else
                        sTranslatedExample0 = Utils.Substr(ref workingString, 0, nextDelimeter);//workingString.Substring(0, nextDelimeter);

                    nextStart = nextDelimeter + 1;
                    workingString = Utils.Substr(ref workingString, nextStart);//workingString.Substring(nextStart);
                    nextDelimeter = Utils.Strchr(ref workingString, ';');//workingString.IndexOf(';');
                    string sForeignExample1;
                    if (nextDelimeter < 1)
                        sForeignExample1 = "";
                    else
                        sForeignExample1 = Utils.Substr(ref workingString, 0, nextDelimeter);//workingString.Substring(0, nextDelimeter);

                    nextStart = nextDelimeter + 1;
                    workingString = Utils.Substr(ref workingString, nextStart);//workingString.Substring(nextStart);
                    nextDelimeter = Utils.Strchr(ref workingString, ';');//workingString.IndexOf(';');
                    string sTranslatedExample1;
                    if (nextDelimeter < 1)
                        sTranslatedExample1 = "";
                    else
                        sTranslatedExample1 = Utils.Substr(ref workingString, 0, nextDelimeter);//workingString.Substring(0, nextDelimeter);


                    nextStart = nextDelimeter + 1;
                    workingString = Utils.Substr(ref workingString, nextStart);//workingString.Substring(nextStart);
                    nextDelimeter = Utils.Strchr(ref workingString, ';');//workingString.IndexOf(';');
                    string sForeignExample2;
                    if (nextDelimeter < 1)
                        sForeignExample2 = "";
                    else
                        sForeignExample2 = Utils.Substr(ref workingString, 0, nextDelimeter);//workingString.Substring(0, nextDelimeter);

                    nextStart = nextDelimeter + 1;
                    workingString = Utils.Substr(ref workingString, nextStart);//workingString.Substring(nextStart);
                    nextDelimeter = Utils.Strchr(ref workingString, ';');//workingString.IndexOf(';');
                    string sTranslatedExample2;
                    if (nextDelimeter < 1)
                        sTranslatedExample2 = "";
                    else
                        sTranslatedExample2 = Utils.Substr(ref workingString, 0, nextDelimeter);//workingString.Substring(0, nextDelimeter);

                    WordToLearn wtlTemp = new WordToLearn(Controller.Languages[AutoLoadComboBox.SelectedIndex].iCode, sForeignWord, sTranslatedWord, sForeignExample0, sTranslatedExample0, sForeignExample1, sTranslatedExample1, sForeignExample2, sTranslatedExample2);
                    Controller.AddNewWordToDictionary(wtlTemp);

                    
                }
                MessageBox.Show("Words was successfully exported", "Successfull");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bad structure of file. Can not proceed.");
            }
            finally
            {

                Controller.eEnvironment.pAutoLoadListForm = this.Location;
                Controller.SaveEnvironment();
                mfMainForm.FillTabs();
                this.Dispose();
            }
            
        }

        private void LocationChange(object sender, EventArgs e)
        {
            Controller.eEnvironment.pAutoLoadListForm = this.Location;
            Controller.SaveEnvironment();
        }

        private void AutoLoadListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
