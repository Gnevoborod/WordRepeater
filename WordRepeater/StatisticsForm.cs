using System;
using System.Linq;
using System.Windows.Forms;

namespace WordRepeater
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            try
            {
                int total = (int)Controller.wtlWordsToLearn.Sum(w => w.iTotalAnswers);
                sTotal.Text +=" "+ total.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("The Statistics funcionality is not available now. Please try a little bit later, or reload the app", "Unavailable");

            }
        }
    }
}
