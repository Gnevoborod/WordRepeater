using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
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
        Button bDeleteButton = null;
        List<WordToLearn> lWordToManipulate = null;
        RichTextBox rtbInfoAboutWord = null;
        CheckBox cbActivity = null;
        GroupBox gbStatistics = null;
        Label lWrongText, lWrong, lRightText, lRight, lTotalText, lTotal;
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
            bEditButton.Size = new System.Drawing.Size(bEditButton.Size.Width, (int)(2.2f * iDelimeter));
            this.bEditButton.Click += new System.EventHandler(EditWord);
            //deletebutton
            bDeleteButton = new Button();
            bDeleteButton.Text = "Delete";
            bDeleteButton.Location = new Point(LanguagesTab.Width / 2+ bEditButton.Size.Width+(2*iDelimeter), (rtbInfoAboutWord.Location.Y + rtbInfoAboutWord.Size.Height + iDelimeter));
            bDeleteButton.Size = new System.Drawing.Size(bDeleteButton.Size.Width, (int)(2.2f * iDelimeter));
            this.bDeleteButton.Click += new System.EventHandler(DeleteWord);
            //checkbox
            cbActivity = new CheckBox();
            cbActivity.Location= new Point(LanguagesTab.Width / 2, (bEditButton.Location.Y + bEditButton.Size.Height+ iDelimeter));
            cbActivity.Text = "Active repeating";
            cbActivity.Click += new System.EventHandler(ChangeCheckedBox);

            //groupbox statistics
            gbStatistics = new GroupBox();
            gbStatistics.Text = "Statistics";
            gbStatistics.Location= new Point(LanguagesTab.Width / 2, (cbActivity.Location.Y + cbActivity.Size.Height + (5+iDelimeter)));
            gbStatistics.Size= new System.Drawing.Size(rtbInfoAboutWord.Size.Width, (int)(rtbInfoAboutWord.Size.Height*0.815f));

            lRight = new Label();
            //lRight.AutoSize = true;
             lRightText = new Label();
            lRightText.AutoSize = true;
            lWrong = new Label();
            //lWrong.AutoSize = true;
            lWrongText = new Label();
            lWrongText.AutoSize = true;
            lTotalText = new Label();
            lTotal = new Label();
            //lTotalText.AutoSize = true;
            lRight.BackColor = Color.LightGreen;
            lWrong.BackColor = Color.LightPink;
            lTotalText.Text = "Total: ";
            lWrongText.Text = "Wrong answers: ";
            lRightText.Text = "Right answers: ";

            lRight.Size = new System.Drawing.Size(0, lRight.Size.Height);
            lWrong.Size = new System.Drawing.Size(0, lWrong.Size.Height);
            lTotal.Size = new System.Drawing.Size(0, lTotal.Size.Height);
            lRightText.Location= new Point(iDelimeter, 3*iDelimeter);
            
            lTotal.BackColor = Color.Ivory;
            lWrongText.Location = new Point(lRightText.Location.X, lRightText.Location.Y+ lRightText.Size.Height +iDelimeter);
            lWrong.Location = new Point(lWrongText.Location.X + lWrongText.Size.Width + iDelimeter, lWrongText.Location.Y);
            lRight.Location = new Point(lWrongText.Location.X + lWrongText.Size.Width + iDelimeter, lRightText.Location.Y);
            lTotalText.Location = new Point(lWrongText.Location.X, lWrongText.Location.Y + lWrongText.Size.Height + iDelimeter);
            lTotal.Location = new Point(lWrongText.Location.X + lWrongText.Size.Width + iDelimeter, lTotalText.Location.Y);

            gbStatistics.FlatStyle = FlatStyle.Standard;
            gbStatistics.Controls.Add(lRight);
            gbStatistics.Controls.Add(lRightText);
            gbStatistics.Controls.Add(lWrong);
            gbStatistics.Controls.Add(lWrongText);
            gbStatistics.Controls.Add(lTotalText);
            gbStatistics.Controls.Add(lTotal);
            if (null != Controller.Languages)
            {
                foreach (Language l in Controller.Languages)
                {
                    this.AddTabWithLanguages(l);
                }
            }
            LanguagesTab.SelectedIndexChanged += new System.EventHandler(CleanSearch);

            
        }

        private void ChangeCheckedBox(object sender, EventArgs e)
        {
            lWordToManipulate[lbListBox.SelectedIndex].SwitchActivity();
        }

        private void EditWord(object sender, EventArgs e)
        {
            WordToLearn wtlTemp = lWordToManipulate[lbListBox.SelectedIndex];
            EditWordForm ewf = new EditWordForm(ref wtlTemp, this);
            ewf.ShowDialog();

        }

        private void DeleteWord(object sender, EventArgs e)
        {
            var result=MessageBox.Show("Are you sure tha you want to delete this word (" + lWordToManipulate[lbListBox.SelectedIndex].sForeignWord + ")?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Controller.wtlWordsToLearn.Remove(lWordToManipulate[lbListBox.SelectedIndex]);
                Controller.SaveDictionary();
                FillTabs();
            }
            else
                return;


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
            bEditButton.Location = new Point(LanguagesTab.Width / 2, (rtbInfoAboutWord.Location.Y + rtbInfoAboutWord.Size.Height + iDelimeter));
            bEditButton.Size = new System.Drawing.Size(bEditButton.Size.Width, (int)(2.2f * iDelimeter));
            cbActivity.Location = new Point(LanguagesTab.Width / 2, (bEditButton.Location.Y + bEditButton.Size.Height + iDelimeter));
            gbStatistics.Location = new Point(LanguagesTab.Width / 2, (cbActivity.Location.Y + cbActivity.Size.Height + (5 + iDelimeter)));

            float mno = 0;
            if (this.WindowState == FormWindowState.Maximized)
                mno = 0.9f;
            else
                mno = 0.815f;
            gbStatistics.Size = new System.Drawing.Size(rtbInfoAboutWord.Size.Width, (int)(rtbInfoAboutWord.Size.Height * mno));
            bDeleteButton.Location = new Point(LanguagesTab.Width / 2 + bEditButton.Size.Width + (2 * iDelimeter), (rtbInfoAboutWord.Location.Y + rtbInfoAboutWord.Size.Height + iDelimeter));


            lRightText.Location = new Point(iDelimeter, 3 * iDelimeter);
           

            lWrongText.Location = new Point(lRightText.Location.X, lRightText.Location.Y + lRightText.Size.Height + iDelimeter);
            lWrong.Location = new Point(lWrongText.Location.X + lWrongText.Size.Width + iDelimeter, lWrongText.Location.Y);
            lRight.Location = new Point(lWrongText.Location.X + lWrongText.Size.Width + iDelimeter, lRightText.Location.Y);
            lTotalText.Location = new Point(lWrongText.Location.X, lWrongText.Location.Y + lWrongText.Size.Height + iDelimeter);
            lTotal.Location = new Point(lWrongText.Location.X + lWrongText.Size.Width + iDelimeter, lTotalText.Location.Y);
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
        private string SelectName()
        {
            return Controller.Languages[SelectCode()].sName;
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
                lWordToManipulate = (from wtl in Controller.wtlWordsToLearn where wtl.iLanguageCode == SelectCode() && (wtl.sForeignWord.StartsWith(sFindForeignWord)|| wtl.sTranslatedWord.StartsWith(sFindForeignWord)) orderby wtl.sForeignWord select wtl).ToList<WordToLearn>();
            
            foreach (WordToLearn wtl in lWordToManipulate)
            {
                
                lbListBox.Items.Add(wtl.sForeignWord+ "        " + wtl.sTranslatedWord);
                
            }
            
            LanguagesTab.SelectedTab.Controls.Add(lbListBox);
            LanguagesTab.SelectedTab.Controls.Add(bEditButton);
            LanguagesTab.SelectedTab.Controls.Add(bDeleteButton);
            LanguagesTab.SelectedTab.Controls.Add(cbActivity);
            LanguagesTab.SelectedTab.Controls.Add(gbStatistics);

            if (0> lbListBox.SelectedIndex)
            {
                bEditButton.Enabled = false;
                bDeleteButton.Enabled = false;
            }
            LanguagesTab.SelectedTab.Controls.Add(rtbInfoAboutWord);
            
        }

        private void ReloadInfoAboutWord(object sender, EventArgs e)
        {
            if (-1 < lbListBox.SelectedIndex)
            {
                bEditButton.Enabled = true;
                bDeleteButton.Enabled = true;
                WordToLearn temp = lWordToManipulate[lbListBox.SelectedIndex];
                rtbInfoAboutWord.Text = "Example 1:\n" + temp.sForeignExample0 + " - " + temp.sTranslatedExample0 + "\n\nExample 2:\n"
                    + temp.sForeignExample1 + " - " + temp.sTranslatedExample1 + "\n\nExample 3:\n"
                    + temp.sForeignExample2 + " - " + temp.sTranslatedExample2;
                cbActivity.Checked = temp.bIsActive;
                
                int r, w, t;


                lRight.Size = new System.Drawing.Size(0, lRight.Size.Height);
                lRight.Text = "";
                lWrong.Text = "";
                lWrong.Size = new System.Drawing.Size(0, lWrong.Size.Height);
                lTotal.Size = new System.Drawing.Size(0, lTotal.Size.Height);
                lTotal.Text = "";
                lTotalText.Text = "Total: ";
                if (null != temp.iRightAnswers && null != temp.iWrongAnswers)
                {
                    t = (int)temp.iRightAnswers + (int)temp.iWrongAnswers;
                    if (t > 0)
                    {
                        r = (int)temp.iRightAnswers * 100 / t;
                        w = (int)temp.iWrongAnswers * 100 / t;

                        lRight.Size = new System.Drawing.Size(r, lRight.Size.Height);
                        lRight.Text = temp.iRightAnswers.ToString();

                        lWrong.Size = new System.Drawing.Size(w, lWrong.Size.Height);
                        lWrong.Text = temp.iWrongAnswers.ToString();

                        lTotal.Size= new System.Drawing.Size(r+w, lTotal.Size.Height);
                        lTotal.Text = t.ToString();
                    }
                    
                }
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

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> linesToSave = new List<string>();
                var wtlToSave = from wtl in Controller.wtlWordsToLearn where wtl.iLanguageCode == SelectCode() select wtl;
                foreach (WordToLearn wtl in wtlToSave)
                {
                    linesToSave.Add(wtl.sForeignWord + ";" + wtl.sTranslatedWord + ";"
                        + wtl.sForeignExample0 + ";" + wtl.sTranslatedExample0 + ";"
                        + wtl.sForeignExample1 + ";" + wtl.sTranslatedExample1 + ";"
                        + wtl.sForeignExample2 + ";" + wtl.sTranslatedExample2 + ";");
                }
                string fileName = Program.PATH+ "ExportedFiles\\" + SelectName() + ".csv";
                Directory.CreateDirectory(Program.PATH + "ExportedFiles\\");
                
                File.WriteAllLines(fileName, linesToSave);
                MessageBox.Show("Created file in " + fileName, "Successfully exported");
            }
            catch(Exception ex)
            {

            }
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
            var result=MessageBox.Show(this, "Do you want to quit and stop trainee?", "Approving", MessageBoxButtons.YesNo);
            if(result.Equals(DialogResult.Yes))
                CloseApplication(this, null);
        }

        private void AutoLoadBtn_Click(object sender, EventArgs e)
        {
            AutoLoadListForm allfAutoLoadListForm = new AutoLoadListForm(this);
            allfAutoLoadListForm.ShowDialog();
            MessageBox.Show("Words was successfully exported","Successfull");
        }
    }
}
