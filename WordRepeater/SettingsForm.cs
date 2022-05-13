using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using WordRepeater.Model;
using WordRepeater.Languages;

namespace WordRepeater
{
    public partial class SettingsForm : Form
    {
        MainForm mf;
        SettingsFormLanguage settingsFormLanguage;
        string bodyDeletePart1;
        string bodyDeletePart2;
        string confirmationDelete;
        string deletedSucc;
        string deletedSuccTitle;
        public SettingsForm(MainForm mainForm)
        {
            try
            {
                InitializeComponent();
                
                if (null!=Controller.eEnvironment.pSettingsForm)
                    this.Location = (Point)Controller.eEnvironment.pSettingsForm;
                mf = mainForm;
                mf.loadLanguagesDelegate += this.SetTexts;
                if (null != Controller.Languages)
                {
                    foreach (Language elem in Controller.Languages)
                    {
                        if (elem.bIsActive)
                            ComboBoxLanguages.Items.Add(elem.sName);
                    }
                }
                SecondsInput.Value = Controller.sSettings.iRepeatSeconds;
                checkBox1.Checked = Controller.sSettings.bTrainingIsActive;
                checkBox2.Checked = Controller.sSettings.bStartOnLoad ?? true;
                cbAlgorythm.Checked = Controller.sSettings.bRareAlgo??true;
                if (null == Controller.sSettings.bForeignWordToTrain)
                {
                    Controller.sSettings.bForeignWordToTrain = true;
                    Controller.SaveSettings();
                }
                cbForeignWordToTrain.Checked = (bool)Controller.sSettings.bForeignWordToTrain;
                cbSwitchLanguage.Checked=Controller.sSettings.bSwitchLanguagesWhileTrainee??false;
                if(null!= mf.languageManager.applicationLanguage)
                {

                    
                    foreach (string val in mf.languageManager.applicationLanguage.lsLanguageList.Values)
                    {
                        cbApplicationLanguage.Items.Add(val);
                    }
                }
                if(cbApplicationLanguage.Items.Count>0)
                {
                    if (String.IsNullOrEmpty(Controller.sSettings.sApplicationLanguage))
                    {
                        CultureInfo ci = CultureInfo.CurrentCulture;
                        Controller.sSettings.sApplicationLanguage = ci.TwoLetterISOLanguageName;
                        Controller.SaveSettings();
                    }
                    cbApplicationLanguage.SelectedItem= mf.languageManager.applicationLanguage.lsLanguageList[Controller.sSettings.sApplicationLanguage];
                }
                bLangChange.Enabled = false;


                SetTexts(Controller.sSettings.sApplicationLanguage);

            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ComboBoxLanguages.SelectedIndex > -1)
            {
                Language l = Controller.Languages[ComboBoxLanguages.SelectedIndex];
                EditLanguageNameForm elnfEdit = new EditLanguageNameForm(ref l, mf);
                elnfEdit.ShowDialog();
            }
        }

        
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Controller.sSettings.bStartOnLoad = checkBox2.Checked;
            Controller.AutorunRegistry((bool)Controller.sSettings.bStartOnLoad);
        }

        private void SecondsInput_ValueChanged(object sender, EventArgs e)
        {
            Controller.sSettings.iRepeatSeconds = (int)SecondsInput.Value;
            Controller.SaveSettings();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Controller.sSettings.bTrainingIsActive = checkBox1.Checked;
            Controller.SaveSettings();
        }


        private void DeleteLanguageButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxLanguages.SelectedIndex < 0)
                    return;
                DialogResult result = MessageBox.Show(bodyDeletePart1+" " + Controller.Languages[ComboBoxLanguages.SelectedIndex].sName + "? "+bodyDeletePart2, confirmationDelete, MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
                int iCodeToDelete = Controller.Languages[ComboBoxLanguages.SelectedIndex].iCode;
                Controller.wtlWordsToLearn.RemoveAll(wtlEvery => wtlEvery.iLanguageCode == iCodeToDelete);
                Controller.Languages.RemoveAt(ComboBoxLanguages.SelectedIndex);
                ComboBoxLanguages.Items.RemoveAt(ComboBoxLanguages.SelectedIndex);
                Controller.SaveDictionary();
                Controller.SaveLanguages();
                mf.ReloadTabs();
                ComboBoxLanguages.Refresh();
                MessageBox.Show(deletedSucc, deletedSuccTitle);
            }
            catch (Exception ex)
            {

            }
            //Controller.Languages.Remove()
        }

        private void cbAlgorythm_CheckedChanged(object sender, EventArgs e)
        {
            Controller.sSettings.bRareAlgo = cbAlgorythm.Checked;
            Controller.SaveSettings();
        }


        private void LocationChange(object sender, EventArgs e)
        {
            Controller.eEnvironment.pSettingsForm = this.Location;
            Controller.SaveEnvironment();
        }

        private void cbLanguageToRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (ComboBoxLanguages.SelectedIndex < 0 || ComboBoxLanguages.Text == "")
                return;
            Language l = Controller.Languages[ComboBoxLanguages.SelectedIndex];
            l.bIsActiveTraining = cbLanguageToRepeat.Checked;
            Controller.SaveLanguages();
        }

        private void OnValueChange(object sender, EventArgs e)
        {
            if (ComboBoxLanguages.SelectedIndex < 0 || ComboBoxLanguages.Text == "")
            {
                cbLanguageToRepeat.Enabled = false;
                cbLanguageToRepeat.Checked = false;
            }
            else
            {
                if (null == Controller.Languages[ComboBoxLanguages.SelectedIndex].bIsActiveTraining)
                {
                    Controller.Languages[ComboBoxLanguages.SelectedIndex].bIsActiveTraining = true;
                    Controller.SaveLanguages();
                }
                cbLanguageToRepeat.Enabled = true;
                cbLanguageToRepeat.Checked =(bool) Controller.Languages[ComboBoxLanguages.SelectedIndex].bIsActiveTraining;
            }
            }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (null == Controller.sSettings.bForeignWordToTrain)
                Controller.sSettings.bForeignWordToTrain = true;
            Controller.sSettings.bForeignWordToTrain = cbForeignWordToTrain.Checked;
            Controller.SaveSettings();
        }

        private void cbSwitchLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (null == Controller.sSettings.bSwitchLanguagesWhileTrainee)
                Controller.sSettings.bSwitchLanguagesWhileTrainee = true;
            Controller.sSettings.bSwitchLanguagesWhileTrainee = cbSwitchLanguage.Checked;
            Controller.SaveSettings();
        }

        private void cbApplicationLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbApplicationLanguage.SelectedItem != mf.languageManager.applicationLanguage.lsLanguageList[Controller.sSettings.sApplicationLanguage])
                bLangChange.Enabled = true;
            else
                bLangChange.Enabled = false;
        }

        private void bLangChange_Click(object sender, EventArgs e)
        {
            int position = cbApplicationLanguage.SelectedIndex;
            Controller.sSettings.sApplicationLanguage = mf.languageManager.applicationLanguage.lsLanguageList.ElementAt(position).Key;
            //mf.languageManager = new LanguageManager(Controller.sSettings.sApplicationLanguage);
            Controller.SaveSettings();
            mf.loadLanguagesDelegate(Controller.sSettings.sApplicationLanguage);
            //mf.SetTexts(Controller.sSettings.sApplicationLanguage);
            bLangChange.Enabled = false;
        }

        public void SetTexts(string sISO)
        {
            LanguageManager languageManager = new LanguageManager(Controller.sSettings.sApplicationLanguage);
            settingsFormLanguage = languageManager.LoadSettingsFormText();
            this.Text = settingsFormLanguage.settingsFormWords["TITLE"];
            this.tabPage1.Text = settingsFormLanguage.settingsFormWords["TAB_LANGUAGE"];
            this.tabPage2.Text = settingsFormLanguage.settingsFormWords["TAB_TRAINING"];
            this.tabPage3.Text = settingsFormLanguage.settingsFormWords["TAB_APPLICATION"];
            this.label1.Text = settingsFormLanguage.settingsFormWords["TAB_LANGUAGE_LABEL"];
            this.cbLanguageToRepeat.Text = settingsFormLanguage.settingsFormWords["TAB_LANGUAGE_CHECKBOX"];
            this.label2.Text = settingsFormLanguage.settingsFormWords["TAB_TRAINING_LABEL"];
            this.checkBox1.Text = settingsFormLanguage.settingsFormWords["TAB_TRAINING_TRAININGACTIVE"];
            this.cbAlgorythm.Text = settingsFormLanguage.settingsFormWords["TAB_TRAINING_RAREWORDS"];
            this.cbForeignWordToTrain.Text = settingsFormLanguage.settingsFormWords["TAB_TRAINING_FOREIGN"];
            this.cbSwitchLanguage.Text = settingsFormLanguage.settingsFormWords["TAB_TRAINING_SWITCH"];
            this.label3.Text = settingsFormLanguage.settingsFormWords["TAB_APPLICATION_LABEL_AL"];
            this.bLangChange.Text = settingsFormLanguage.settingsFormWords["TAB_APPLICATION_BTN_AL"];
            this.checkBox2.Text = settingsFormLanguage.settingsFormWords["TAB_APPLICATION_AUTORUN"];
            bodyDeletePart1 = settingsFormLanguage.settingsFormWords["TAB_LANGUAGE_DELETE_BODY1"];
            bodyDeletePart2 = settingsFormLanguage.settingsFormWords["TAB_LANGUAGE_DELETE_BODY2"];
            confirmationDelete = settingsFormLanguage.settingsFormWords["TAB_LANGUAGE_DELETE_TITLE"];
            deletedSucc = settingsFormLanguage.settingsFormWords["TAB_LANGUAGE_SUCCESS"];
            deletedSuccTitle = settingsFormLanguage.settingsFormWords["TAB_LANGUAGE_SUCCESS_TITLE"];
        }
    }
}
