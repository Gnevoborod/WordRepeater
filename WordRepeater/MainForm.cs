using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            LanguagesTab.TabPages.Clear();//удаляем служебную вкладку после старта приложения
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Minimized)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
                // делаем нашу иконку в трее активной
                notifyIcon1.Visible = true;
            }
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // делаем нашу иконку скрытой
            notifyIcon1.Visible = false;
            // возвращаем отображение окна в панели
            this.ShowInTaskbar = true;
            //разворачиваем окно
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ShowTabWithLanguages()
        {
            LanguagesTab.TabPages.Add(Settings.Languages.Last<string>());
            if (false == LanguagesTab.Visible)
                LanguagesTab.Visible = true;
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
    }
}
