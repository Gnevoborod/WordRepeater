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
    public partial class SettingsForm : Form
    {
        MainForm mf;
        public SettingsForm(MainForm mainForm)
        {
            try
            {
                InitializeComponent();
                if(null!=Controller.eEnvironment.pSettingsForm)
                    this.Location = (Point)Controller.eEnvironment.pSettingsForm;
                mf = mainForm;
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
                checkBox2.Checked = (bool)Controller.sSettings.bStartOnLoad;
                cbAlgorythm.Checked = (bool)Controller.sSettings.bRareAlgo;
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Language l = Controller.Languages[ComboBoxLanguages.SelectedIndex];
            EditLanguageNameForm elnfEdit = new EditLanguageNameForm(ref l, mf);
            elnfEdit.ShowDialog();
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
                DialogResult result = MessageBox.Show("Are you sure you want to delete the language " + Controller.Languages[ComboBoxLanguages.SelectedIndex].sName + "? All words for that language will be also deleted.", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
                int iCodeToDelete = Controller.Languages[ComboBoxLanguages.SelectedIndex].iCode;
                Controller.wtlWordsToLearn.RemoveAll(wtlEvery => wtlEvery.iLanguageCode == iCodeToDelete);
                Controller.Languages.RemoveAt(ComboBoxLanguages.SelectedIndex);
                Controller.SaveDictionary();
                Controller.SaveLanguages();
                mf.ReloadTabs();
                MessageBox.Show("Language was deleted successfully", "Succcessfull");
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


        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Controller.eEnvironment.pSettingsForm = this.Location;
            Controller.SaveEnvironment();
        }
    }
}
