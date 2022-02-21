using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordRepeater
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            if (null != Controller.eEnvironment.pAboutForm)
                this.Location = (Point)Controller.eEnvironment.pAboutForm;
            lblAbout.Text = "This program supplies as is. You use the program at your own risk,\nand the author is not responsible for failures that occurred during \nthe operation of the program.\n\n\nDesigned and developed by Pavel Dorokhov."
                              +"\nIcons from the web-site https://icon-icons.com"
                              +"\n\nIf you have any questions - please contact me with the email: pdorokhov.workmail@gmail.com";
            lblAbout.Enabled = true;
            
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Controller.eEnvironment.pAboutForm = this.Location;
            Controller.SaveEnvironment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
