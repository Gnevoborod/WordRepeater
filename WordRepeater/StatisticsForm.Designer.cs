
namespace WordRepeater
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sTotal = new System.Windows.Forms.Label();
            this.sTotalWords = new System.Windows.Forms.Label();
            this.sTotalLanguages = new System.Windows.Forms.Label();
            this.sTW = new System.Windows.Forms.Label();
            this.sTL = new System.Windows.Forms.Label();
            this.sTT = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sTotal
            // 
            this.sTotal.AutoSize = true;
            this.sTotal.Location = new System.Drawing.Point(34, 86);
            this.sTotal.Name = "sTotal";
            this.sTotal.Size = new System.Drawing.Size(101, 20);
            this.sTotal.TabIndex = 0;
            this.sTotal.Text = "Total trainees:";
            // 
            // sTotalWords
            // 
            this.sTotalWords.AutoSize = true;
            this.sTotalWords.Location = new System.Drawing.Point(34, 21);
            this.sTotalWords.Name = "sTotalWords";
            this.sTotalWords.Size = new System.Drawing.Size(89, 20);
            this.sTotalWords.TabIndex = 1;
            this.sTotalWords.Text = "Total words:";
            // 
            // sTotalLanguages
            // 
            this.sTotalLanguages.AutoSize = true;
            this.sTotalLanguages.Location = new System.Drawing.Point(34, 53);
            this.sTotalLanguages.Name = "sTotalLanguages";
            this.sTotalLanguages.Size = new System.Drawing.Size(117, 20);
            this.sTotalLanguages.TabIndex = 2;
            this.sTotalLanguages.Text = "Total languages:";
            // 
            // sTW
            // 
            this.sTW.AutoSize = true;
            this.sTW.Location = new System.Drawing.Point(166, 21);
            this.sTW.Name = "sTW";
            this.sTW.Size = new System.Drawing.Size(50, 20);
            this.sTW.TabIndex = 3;
            this.sTW.Text = "label1";
            // 
            // sTL
            // 
            this.sTL.AutoSize = true;
            this.sTL.Location = new System.Drawing.Point(166, 53);
            this.sTL.Name = "sTL";
            this.sTL.Size = new System.Drawing.Size(50, 20);
            this.sTL.TabIndex = 4;
            this.sTL.Text = "label2";
            // 
            // sTT
            // 
            this.sTT.AutoSize = true;
            this.sTT.Location = new System.Drawing.Point(166, 86);
            this.sTT.Name = "sTT";
            this.sTT.Size = new System.Drawing.Size(50, 20);
            this.sTT.TabIndex = 5;
            this.sTT.Text = "label3";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(754, 549);
            this.Controls.Add(this.sTT);
            this.Controls.Add(this.sTL);
            this.Controls.Add(this.sTW);
            this.Controls.Add(this.sTotalLanguages);
            this.Controls.Add(this.sTotalWords);
            this.Controls.Add(this.sTotal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Statistics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sTotal;
        private System.Windows.Forms.Label sTotalWords;
        private System.Windows.Forms.Label sTotalLanguages;
        private System.Windows.Forms.Label sTW;
        private System.Windows.Forms.Label sTL;
        private System.Windows.Forms.Label sTT;
    }
}