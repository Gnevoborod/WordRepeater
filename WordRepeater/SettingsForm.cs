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
        public SettingsForm()
        {
            InitializeComponent();
            if(null!=Controller.Languages)
            {
                foreach(Language elem in Controller.Languages)
                {
                    if(elem.bIsActive)
                        ComboBoxLanguages.Items.Add(elem.sName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

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
    }
}
