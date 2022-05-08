
namespace WordRepeater
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.ComboBoxLanguages = new System.Windows.Forms.ComboBox();
            this.EditLanguageButton = new System.Windows.Forms.Button();
            this.DeleteLanguageButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLanguageToRepeat = new System.Windows.Forms.CheckBox();
            this.cbSwitchLanguage = new System.Windows.Forms.CheckBox();
            this.cbForeignWordToTrain = new System.Windows.Forms.CheckBox();
            this.cbAlgorythm = new System.Windows.Forms.CheckBox();
            this.SecondsInput = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bLangChange = new System.Windows.Forms.Button();
            this.cbApplicationLanguage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SecondsInput)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Learning languages:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 69);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(141, 24);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Training is active";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(14, 119);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(231, 24);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Run when computer turned on";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ComboBoxLanguages
            // 
            this.ComboBoxLanguages.FormattingEnabled = true;
            this.ComboBoxLanguages.Location = new System.Drawing.Point(18, 55);
            this.ComboBoxLanguages.Name = "ComboBoxLanguages";
            this.ComboBoxLanguages.Size = new System.Drawing.Size(258, 28);
            this.ComboBoxLanguages.TabIndex = 3;
            this.ComboBoxLanguages.SelectedIndexChanged += new System.EventHandler(this.OnValueChange);
            this.ComboBoxLanguages.SelectedValueChanged += new System.EventHandler(this.OnValueChange);
            this.ComboBoxLanguages.TextChanged += new System.EventHandler(this.OnValueChange);
            // 
            // EditLanguageButton
            // 
            this.EditLanguageButton.Image = ((System.Drawing.Image)(resources.GetObject("EditLanguageButton.Image")));
            this.EditLanguageButton.Location = new System.Drawing.Point(282, 49);
            this.EditLanguageButton.Name = "EditLanguageButton";
            this.EditLanguageButton.Size = new System.Drawing.Size(42, 42);
            this.EditLanguageButton.TabIndex = 4;
            this.EditLanguageButton.UseVisualStyleBackColor = true;
            this.EditLanguageButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteLanguageButton
            // 
            this.DeleteLanguageButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteLanguageButton.Image")));
            this.DeleteLanguageButton.Location = new System.Drawing.Point(333, 49);
            this.DeleteLanguageButton.Name = "DeleteLanguageButton";
            this.DeleteLanguageButton.Size = new System.Drawing.Size(42, 42);
            this.DeleteLanguageButton.TabIndex = 5;
            this.DeleteLanguageButton.UseVisualStyleBackColor = true;
            this.DeleteLanguageButton.Click += new System.EventHandler(this.DeleteLanguageButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Second between repeating:";
            // 
            // cbLanguageToRepeat
            // 
            this.cbLanguageToRepeat.AutoSize = true;
            this.cbLanguageToRepeat.Enabled = false;
            this.cbLanguageToRepeat.Location = new System.Drawing.Point(18, 108);
            this.cbLanguageToRepeat.Name = "cbLanguageToRepeat";
            this.cbLanguageToRepeat.Size = new System.Drawing.Size(233, 24);
            this.cbLanguageToRepeat.TabIndex = 6;
            this.cbLanguageToRepeat.Text = "Repeat words of this language";
            this.cbLanguageToRepeat.UseVisualStyleBackColor = true;
            this.cbLanguageToRepeat.CheckedChanged += new System.EventHandler(this.cbLanguageToRepeat_CheckedChanged);
            // 
            // cbSwitchLanguage
            // 
            this.cbSwitchLanguage.AutoSize = true;
            this.cbSwitchLanguage.Location = new System.Drawing.Point(14, 197);
            this.cbSwitchLanguage.Name = "cbSwitchLanguage";
            this.cbSwitchLanguage.Size = new System.Drawing.Size(335, 24);
            this.cbSwitchLanguage.TabIndex = 10;
            this.cbSwitchLanguage.Text = "Switch foreign\\mother language while trainee";
            this.cbSwitchLanguage.UseVisualStyleBackColor = true;
            this.cbSwitchLanguage.CheckedChanged += new System.EventHandler(this.cbSwitchLanguage_CheckedChanged);
            // 
            // cbForeignWordToTrain
            // 
            this.cbForeignWordToTrain.AutoSize = true;
            this.cbForeignWordToTrain.Location = new System.Drawing.Point(14, 156);
            this.cbForeignWordToTrain.Name = "cbForeignWordToTrain";
            this.cbForeignWordToTrain.Size = new System.Drawing.Size(220, 24);
            this.cbForeignWordToTrain.TabIndex = 9;
            this.cbForeignWordToTrain.Text = "Repeating words are foreign";
            this.cbForeignWordToTrain.UseVisualStyleBackColor = true;
            this.cbForeignWordToTrain.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // cbAlgorythm
            // 
            this.cbAlgorythm.AutoSize = true;
            this.cbAlgorythm.Location = new System.Drawing.Point(14, 114);
            this.cbAlgorythm.Name = "cbAlgorythm";
            this.cbAlgorythm.Size = new System.Drawing.Size(238, 24);
            this.cbAlgorythm.TabIndex = 8;
            this.cbAlgorythm.Text = "Rare repeating words to repeat";
            this.cbAlgorythm.UseVisualStyleBackColor = true;
            this.cbAlgorythm.CheckedChanged += new System.EventHandler(this.cbAlgorythm_CheckedChanged);
            // 
            // SecondsInput
            // 
            this.SecondsInput.Location = new System.Drawing.Point(219, 17);
            this.SecondsInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SecondsInput.Name = "SecondsInput";
            this.SecondsInput.Size = new System.Drawing.Size(87, 27);
            this.SecondsInput.TabIndex = 7;
            this.SecondsInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SecondsInput.ValueChanged += new System.EventHandler(this.SecondsInput_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(461, 426);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cbLanguageToRepeat);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ComboBoxLanguages);
            this.tabPage1.Controls.Add(this.EditLanguageButton);
            this.tabPage1.Controls.Add(this.DeleteLanguageButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(453, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Languages";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.cbSwitchLanguage);
            this.tabPage2.Controls.Add(this.cbAlgorythm);
            this.tabPage2.Controls.Add(this.cbForeignWordToTrain);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.SecondsInput);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(453, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Training";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.bLangChange);
            this.tabPage3.Controls.Add(this.cbApplicationLanguage);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.checkBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(453, 393);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Application";
            // 
            // bLangChange
            // 
            this.bLangChange.Location = new System.Drawing.Point(265, 69);
            this.bLangChange.Name = "bLangChange";
            this.bLangChange.Size = new System.Drawing.Size(171, 29);
            this.bLangChange.TabIndex = 5;
            this.bLangChange.Text = "Change language";
            this.bLangChange.UseVisualStyleBackColor = true;
            this.bLangChange.Click += new System.EventHandler(this.bLangChange_Click);
            // 
            // cbApplicationLanguage
            // 
            this.cbApplicationLanguage.FormattingEnabled = true;
            this.cbApplicationLanguage.Location = new System.Drawing.Point(175, 21);
            this.cbApplicationLanguage.Name = "cbApplicationLanguage";
            this.cbApplicationLanguage.Size = new System.Drawing.Size(261, 28);
            this.cbApplicationLanguage.TabIndex = 4;
            this.cbApplicationLanguage.SelectedIndexChanged += new System.EventHandler(this.cbApplicationLanguage_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Application language:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 427);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.LocationChanged += new System.EventHandler(this.LocationChange);
            ((System.ComponentModel.ISupportInitialize)(this.SecondsInput)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox ComboBoxLanguages;
        private System.Windows.Forms.Button EditLanguageButton;
        private System.Windows.Forms.Button DeleteLanguageButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SecondsInput;
        private System.Windows.Forms.CheckBox cbAlgorythm;
        private System.Windows.Forms.CheckBox cbLanguageToRepeat;
        private System.Windows.Forms.CheckBox cbForeignWordToTrain;
        private System.Windows.Forms.CheckBox cbSwitchLanguage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbApplicationLanguage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bLangChange;
    }
}