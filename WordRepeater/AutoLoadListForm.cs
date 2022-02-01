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
    public partial class AutoLoadListForm : Form
    {
        string FILE_PATH;
        public AutoLoadListForm()
        {
            InitializeComponent();
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
            //считать файл.
            //язык взять из комбобокса
            //все остальные данные загрузить в лист с WordToLearn
        }
    }
}
