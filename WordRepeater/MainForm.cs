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
        int iLittleDelimeter = 5;
        int offset;//ListBox.DefaultItemHeight*6;
        int offsetForSearch= ListBox.DefaultItemHeight * 3;
        int iDelimeter = 13;
        ListBox lbListBox = null;
        TextBox tbSearch = null;
        Button bFilterABC = null;
        Button bEditButton = null;
        List<WordToLearn> lWordToManipulate = null;
        RichTextBox rtbInfoAboutWord = null;
        public MainForm()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
            // добавляем Эвент или событие по 2му клику мышки, 
            //вызывая функцию  notifyIcon1_MouseDoubleClick
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);

            this.Resize += new System.EventHandler(this.Form1_Resize);
            LanguagesTab.TabPages.Clear();//удаляем служебную вкладку после старта приложения
            NewWordButton.Enabled = false;
            offset = this.Height - LanguagesTab.Height - offsetForSearch + toolStrip1.Height+ 1;
            tbSearch = new TextBox();
            tbSearch.Size = new System.Drawing.Size(tbSearch.Width * 2, tbSearch.Height);
            tbSearch.PlaceholderText = "Search";
            tbSearch.Location = new Point(tbSearch.Location.X, tbSearch.Location.Y + iLittleDelimeter);
            tbSearch.TextChanged += new System.EventHandler(SearchWord);
            //info about word
            rtbInfoAboutWord = new RichTextBox();
            rtbInfoAboutWord.Location = new Point(LanguagesTab.Width / 2, rtbInfoAboutWord.Location.Y + offsetForSearch); 
            rtbInfoAboutWord.Size = new System.Drawing.Size((LanguagesTab.Width / 2) - iDelimeter, ((LanguagesTab.Height - offset) / 2) - iDelimeter);
            //edit button

            bEditButton = new Button();
            bEditButton.Text = "Edit";
            bEditButton.Location= new Point(LanguagesTab.Width / 2, (rtbInfoAboutWord.Location.Y+ rtbInfoAboutWord.Size.Height + iDelimeter));
            this.bEditButton.Click += new System.EventHandler(EditWord);

                if (null != Controller.Languages)
            {
                foreach (Language l in Controller.Languages)
                {
                    this.AddTabWithLanguages(l);
                }
            }
            LanguagesTab.SelectedIndexChanged += new System.EventHandler(CleanSearch);

            
        }

        private void EditWord(object sender, EventArgs e)
        {
            EditWordForm ewf = new EditWordForm(lWordToManipulate[lbListBox.SelectedIndex], this);
            ewf.Show();
        }
        private void CleanSearch(object sender, EventArgs e)
        {
            tbSearch.Text = "";
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if(null!=lbListBox)
                lbListBox.Size = new System.Drawing.Size((LanguagesTab.Width / 2) - iDelimeter, LanguagesTab.Height - (offset+1));
            rtbInfoAboutWord.Location = new Point((lbListBox.Width +iDelimeter), rtbInfoAboutWord.Location.Y);
            rtbInfoAboutWord.Size = new System.Drawing.Size((LanguagesTab.Width / 2) - iDelimeter, rtbInfoAboutWord.Size.Height);
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
            //LanguagesTab.TabPages[iCurrentIndex].AutoScroll=true;
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
        private void SearchWord(object sender, EventArgs e)
        {
            if (null == tbSearch)
                return;
            

            if (tbSearch.Text.Length > 0)
            {   
                    FillTabs(tbSearch.Text);

                return;   
            }
            FillTabs();
            tbSearch.Clear();
        }

        public void FillTabs(string? sFindForeignWord=null)
        {
            if(null!=lbListBox)
                lbListBox.Dispose();
            LanguagesTab.SelectedTab.Controls.Add(tbSearch);
            lbListBox = new ListBox();
            lbListBox.SelectedIndexChanged += new System.EventHandler(ReloadInfoAboutWord);
            lbListBox.Location = new Point(lbListBox.Location.X, lbListBox.Location.Y + offsetForSearch);
            lbListBox.Size= new System.Drawing.Size((LanguagesTab.Width/2)-iDelimeter, LanguagesTab.Height-offset);
           
            if (null==sFindForeignWord || sFindForeignWord.Equals(""))
                lWordToManipulate = (from wtl in Controller.wtlWordsToLearn where wtl.iLanguageCode == SelectCode() orderby wtl.sForeignWord select wtl).ToList<WordToLearn>();
            else
                lWordToManipulate = (from wtl in Controller.wtlWordsToLearn where wtl.iLanguageCode == SelectCode() && wtl.sForeignWord.StartsWith(sFindForeignWord) orderby wtl.sForeignWord select wtl).ToList<WordToLearn>();
            
            foreach (WordToLearn wtl in lWordToManipulate)
            {
                lbListBox.Items.Add(wtl.sForeignWord);

            }
            LanguagesTab.SelectedTab.Controls.Add(lbListBox);
            LanguagesTab.SelectedTab.Controls.Add(bEditButton);
            if (0> lbListBox.SelectedIndex)
            {
                bEditButton.Enabled = false;
            }
            LanguagesTab.SelectedTab.Controls.Add(rtbInfoAboutWord);
        }

        private void ReloadInfoAboutWord(object sender, EventArgs e)
        {
            if (-1 < lbListBox.SelectedIndex)
            {
                bEditButton.Enabled = true;
                WordToLearn temp = lWordToManipulate[lbListBox.SelectedIndex];
                rtbInfoAboutWord.Text = "Example 1:\n" + temp.sForeignExample0 + " - " + temp.sTranslatedExample0 + "\n\nExample 2:\n"
                    + temp.sForeignExample1 + " - " + temp.sTranslatedExample1 + "\n\nExample 3:\n"
                    + temp.sForeignExample2 + " - " + temp.sTranslatedExample2;
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

        private void AutoLoadBtn_Click(object sender, EventArgs e)
        {
            AutoLoadListForm allfAutoLoadListForm = new AutoLoadListForm(this);
            allfAutoLoadListForm.Show();
        }
    }
}
