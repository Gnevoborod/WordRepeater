using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WordRepeater.Model;

namespace WordRepeater
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
            if (null != Controller.eEnvironment.pStatisticsForm)
                this.Location = (Point)Controller.eEnvironment.pStatisticsForm;

        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            try
            {
                int total = (int)Controller.wtlWordsToLearn.Sum(w => w.iTotalAnswers);
                sTT.Text = total.ToString();
                int iAllWordsCount = Controller.wtlWordsToLearn.Count();
                sTW.Text = iAllWordsCount.ToString();
                int iTotalLanguages = Controller.Languages.Count();
                sTL.Text = iTotalLanguages.ToString();
                int startX, startY;
                startX = sTotal.Location.X;
                startY = sTotal.Location.Y;
                int offX, offY, offYPart;
                offX = 24;
                offY = 36;
                offYPart = 30;
                foreach (Language l in Controller.Languages)
                {
                    startY += offY;
                    GroupBox gb = new GroupBox();
                    gb.Text = l.sName;
                    gb.Location= new Point(startX, startY);
                    
                    Label lTotalWords = new Label();
                    Label lTotalRepeats = new Label();
                    Label lTW = new Label();
                    Label lTR = new Label();
                    gb.Size = new System.Drawing.Size((int)(this.Size.Width * 0.9f), (offYPart*2)+(lTotalWords.Size.Height*2));//sTotal.Size.Height * 7);
                    int iTW, iTR;
                    var vitw = from wtl in Controller.wtlWordsToLearn where wtl.iLanguageCode == l.iCode select wtl;
                    iTW = vitw.Count<WordToLearn>();
                    iTR = (int)vitw.Sum<WordToLearn>(w => w.iTotalAnswers);
                    lTotalWords.Text = "Total words:";
                    lTotalRepeats.Text = "Total trainees:";
                    lTW.Text = iTW.ToString();
                    lTR.Text = iTR.ToString();
                    lTotalWords.Location= new Point(15, offYPart);//offX because we need 24 step not 36. it is offsetX on the Y side
                    lTW.Location = new Point(lTotalWords.Location.X+offX+ lTotalWords.Size.Width, lTotalWords.Location.Y);
                    lTotalRepeats.Location = new Point(lTotalWords.Location.X, lTotalWords.Location.Y+ offYPart);
                    lTR.Location = new Point(lTotalRepeats.Location.X+offX+ lTotalRepeats.Size.Width, lTotalRepeats.Location.Y);
                    gb.Controls.Add(lTotalWords);
                    gb.Controls.Add(lTotalRepeats);
                    gb.Controls.Add(lTW);
                    gb.Controls.Add(lTR);
                    this.Controls.Add(gb);

                    
                    startY = gb.Location.Y+ gb.Size.Height;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("The Statistics funcionality is not available now. Please try a little bit later, or reload the app", "Unavailable");

            }
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Controller.eEnvironment.pStatisticsForm = this.Location;
            Controller.SaveEnvironment();
        }
    }
}
