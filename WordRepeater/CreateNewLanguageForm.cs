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
    public partial class CreateNewLanguageForm : Form
    {
        MainForm oMother;
        public CreateNewLanguageForm(MainForm sender)
        {
            oMother = sender;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sNewLanguage = NewLanguageTextBox.Text.Trim();
            if(sNewLanguage.Length<1 || sNewLanguage.Length>100)
            {
                MessageBox.Show("Language's name length must have more than 0 and less then 100 symbols.");
                return;
            }
            if(Controller.HasLanguage(sNewLanguage))
            {
                MessageBox.Show("Language with this name is already exists.");
                return;
            }
            Language lLanguage = Controller.AddNewLanguage(sNewLanguage);
            this.Close();
            oMother.AddTabWithLanguages(lLanguage);
        }
    }
}
