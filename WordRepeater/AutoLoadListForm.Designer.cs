
namespace WordRepeater
{
    partial class AutoLoadListForm
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
            this.AutoLoadComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AutoLoadBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ChooseFileButton = new System.Windows.Forms.Button();
            this.PathLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AutoLoadComboBox
            // 
            this.AutoLoadComboBox.FormattingEnabled = true;
            this.AutoLoadComboBox.Location = new System.Drawing.Point(190, 9);
            this.AutoLoadComboBox.Name = "AutoLoadComboBox";
            this.AutoLoadComboBox.Size = new System.Drawing.Size(227, 28);
            this.AutoLoadComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the language";
            // 
            // AutoLoadBtn
            // 
            this.AutoLoadBtn.Location = new System.Drawing.Point(190, 173);
            this.AutoLoadBtn.Name = "AutoLoadBtn";
            this.AutoLoadBtn.Size = new System.Drawing.Size(94, 29);
            this.AutoLoadBtn.TabIndex = 2;
            this.AutoLoadBtn.Text = "Load";
            this.AutoLoadBtn.UseVisualStyleBackColor = true;
            this.AutoLoadBtn.Click += new System.EventHandler(this.AutoLoadBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ChooseFileButton
            // 
            this.ChooseFileButton.Location = new System.Drawing.Point(12, 56);
            this.ChooseFileButton.Name = "ChooseFileButton";
            this.ChooseFileButton.Size = new System.Drawing.Size(94, 29);
            this.ChooseFileButton.TabIndex = 3;
            this.ChooseFileButton.Text = "Choose file";
            this.ChooseFileButton.UseVisualStyleBackColor = true;
            this.ChooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // PathLabel
            // 
            this.PathLabel.Location = new System.Drawing.Point(12, 88);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(458, 66);
            this.PathLabel.TabIndex = 4;
            // 
            // AutoLoadListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 214);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.ChooseFileButton);
            this.Controls.Add(this.AutoLoadBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AutoLoadComboBox);
            this.Name = "AutoLoadListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Load list of words";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AutoLoadComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AutoLoadBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ChooseFileButton;
        private System.Windows.Forms.Label PathLabel;
    }
}