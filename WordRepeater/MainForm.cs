using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WordRepeater.Model;

namespace WordRepeater
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
            // добавляем Эвент или событие по 2му клику мышки, 
            //вызывая функцию  notifyIcon1_MouseDoubleClick
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);

            // добавляем событие на изменение окна
            this.Resize += new System.EventHandler(this.Form1_Resize);
           // HideWindowForm();
            LanguagesTab.TabPages.Clear();//удаляем служебную вкладку после старта приложения
            NewWordButton.Enabled = false;
            if (null != Controller.Languages)
            {
                foreach (Language l in Controller.Languages)
                {
                    this.AddTabWithLanguages(l);
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            HideWindowForm();
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // делаем нашу иконку скрытой
            notifyIcon1.Visible = false;
            // возвращаем отображение окна в панели
            this.ShowInTaskbar = true;
            //разворачиваем окно
            WindowState = FormWindowState.Normal;
            Show();
        }
        public void HideWindowForm()
        {
                Hide();
                notifyIcon1.Visible = true;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.LanguagesTab.Selected += new TabControlEventHandler(this.LanguagesTab_Selected);
        }

        public void AddTabWithLanguages(Language lLanguage)
        {
            LanguagesTab.TabPages.Add(lLanguage.sName);
            int iCurrentIndex = LanguagesTab.TabPages.Count-1;
            LanguagesTab.TabPages[iCurrentIndex].Name = "TabPage" + lLanguage.iCode.ToString();
            if (false == LanguagesTab.Visible)
                LanguagesTab.Visible = true;
            if (false == NewWordButton.Enabled)
                NewWordButton.Enabled = true;
            FillTabs();
        }

        private void LanguagesTab_Selected(object sender, EventArgs e)
        {
            FillTabs();
        }

        private int SelectCode()
        {
            return System.Int32.Parse(LanguagesTab.TabPages[LanguagesTab.SelectedIndex].Name.Substring(7));
        }
        public void FillTabs()
        {
           LanguagesTab.SelectedTab.Controls.Add(demoLabel);
            demoLabel.Text = "";
            var wtlToShow = from wtl in Controller.wtlWordsToLearn where wtl.iLanguageCode == SelectCode() select wtl;
            foreach(WordToLearn wtl in wtlToShow)
            {
                string finality = wtl.sForeignWord + " - " + wtl.sTranslatedWord + "\n" + wtl.sForeignExample0 + " - " + wtl.sTranslatedExample0 + "\n\n\n";
                demoLabel.Text += finality;
            }

        }

        private void AddNewLanguageButton_Click(object sender, EventArgs e)
        {
            if (Program.MaxLanguagesCount== LanguagesTab.TabCount) {
                MessageBox.Show("Unfortunately maximum tab count was reached. If you want to add another one language please contact us or delete one of you current language.");
                return;//если достигли максимального количества изучаемых языков - выдаём сообщение. Нужно оно или нет - пока непонятно
            }
            CreateNewLanguageForm cnlf = new CreateNewLanguageForm(this);
            cnlf.Show();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm sfSettingsForm = new SettingsForm();
            sfSettingsForm.Show(); 
        }

        private void NewWordButton_Click(object sender, EventArgs e)
        {
            AddNewWordForm anwfAddNewWordForm = new AddNewWordForm(LanguagesTab.SelectedIndex, this);
            anwfAddNewWordForm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideWindowForm();
            e.Cancel = true;
            
        }


        private void CloseApplication(object sender, EventArgs e)
        {
            Program.ToClose = true;
            this.Dispose(true);
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            CloseApplication(this, null);
        }
    }
}
