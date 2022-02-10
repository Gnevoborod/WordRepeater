using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using WordRepeater.Model;
using System.Windows.Forms;

namespace WordRepeater
{
    public partial class EditLanguageNameForm : Form
    {
        Language language;
        MainForm _mf;
        public EditLanguageNameForm(ref Language l, MainForm mf)
        {
            language = l;
            _mf = mf;
            InitializeComponent();
            tbEditLanguage.Text = l.sName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            language.sName= tbEditLanguage.Text;
            Controller.SaveLanguages();
            this.Close();
            _mf.ReloadTabs();
        }
    }
}
