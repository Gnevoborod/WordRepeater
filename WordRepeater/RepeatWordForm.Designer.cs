
namespace WordRepeater
{
    partial class RepeatWordForm
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
            this.variant1 = new System.Windows.Forms.RadioButton();
            this.wordToRepeat = new System.Windows.Forms.Label();
            this.exampleForWordToRepeat = new System.Windows.Forms.Label();
            this.variant2 = new System.Windows.Forms.RadioButton();
            this.variant3 = new System.Windows.Forms.RadioButton();
            this.variant4 = new System.Windows.Forms.RadioButton();
            this.ContinueTraineeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // variant1
            // 
            this.variant1.AutoSize = true;
            this.variant1.Location = new System.Drawing.Point(46, 96);
            this.variant1.Name = "variant1";
            this.variant1.Size = new System.Drawing.Size(17, 16);
            this.variant1.TabIndex = 1;
            this.variant1.UseVisualStyleBackColor = true;
            this.variant1.CheckedChanged += new System.EventHandler(this.variant1_CheckedChanged);
            // 
            // wordToRepeat
            // 
            this.wordToRepeat.AutoSize = true;
            this.wordToRepeat.Location = new System.Drawing.Point(135, 22);
            this.wordToRepeat.Name = "wordToRepeat";
            this.wordToRepeat.Size = new System.Drawing.Size(0, 20);
            this.wordToRepeat.TabIndex = 2;
            // 
            // exampleForWordToRepeat
            // 
            this.exampleForWordToRepeat.AutoSize = true;
            this.exampleForWordToRepeat.Location = new System.Drawing.Point(57, 55);
            this.exampleForWordToRepeat.Name = "exampleForWordToRepeat";
            this.exampleForWordToRepeat.Size = new System.Drawing.Size(0, 20);
            this.exampleForWordToRepeat.TabIndex = 3;
            // 
            // variant2
            // 
            this.variant2.AutoSize = true;
            this.variant2.Location = new System.Drawing.Point(46, 128);
            this.variant2.Name = "variant2";
            this.variant2.Size = new System.Drawing.Size(17, 16);
            this.variant2.TabIndex = 4;
            this.variant2.UseVisualStyleBackColor = true;
            this.variant2.CheckedChanged += new System.EventHandler(this.variant2_CheckedChanged);
            // 
            // variant3
            // 
            this.variant3.AutoSize = true;
            this.variant3.Location = new System.Drawing.Point(46, 161);
            this.variant3.Name = "variant3";
            this.variant3.Size = new System.Drawing.Size(17, 16);
            this.variant3.TabIndex = 5;
            this.variant3.UseVisualStyleBackColor = true;
            this.variant3.CheckedChanged += new System.EventHandler(this.variant3_CheckedChanged);
            // 
            // variant4
            // 
            this.variant4.AutoSize = true;
            this.variant4.Location = new System.Drawing.Point(46, 194);
            this.variant4.Name = "variant4";
            this.variant4.Size = new System.Drawing.Size(17, 16);
            this.variant4.TabIndex = 6;
            this.variant4.UseVisualStyleBackColor = true;
            this.variant4.CheckedChanged += new System.EventHandler(this.variant4_CheckedChanged);
            // 
            // ContinueTraineeBtn
            // 
            this.ContinueTraineeBtn.Enabled = false;
            this.ContinueTraineeBtn.Location = new System.Drawing.Point(179, 247);
            this.ContinueTraineeBtn.Name = "ContinueTraineeBtn";
            this.ContinueTraineeBtn.Size = new System.Drawing.Size(94, 29);
            this.ContinueTraineeBtn.TabIndex = 7;
            this.ContinueTraineeBtn.Text = "Continue";
            this.ContinueTraineeBtn.UseVisualStyleBackColor = true;
            this.ContinueTraineeBtn.Click += new System.EventHandler(this.ContinueTraineeBtn_Click);
            // 
            // RepeatWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 301);
            this.Controls.Add(this.ContinueTraineeBtn);
            this.Controls.Add(this.variant4);
            this.Controls.Add(this.variant3);
            this.Controls.Add(this.variant2);
            this.Controls.Add(this.exampleForWordToRepeat);
            this.Controls.Add(this.wordToRepeat);
            this.Controls.Add(this.variant1);
            this.Name = "RepeatWordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Repeat the word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton variant1;
        private System.Windows.Forms.Label wordToRepeat;
        private System.Windows.Forms.Label exampleForWordToRepeat;
        private System.Windows.Forms.RadioButton variant2;
        private System.Windows.Forms.RadioButton variant3;
        private System.Windows.Forms.RadioButton variant4;
        private System.Windows.Forms.Button ContinueTraineeBtn;
    }
}