
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbAlgorythm = new System.Windows.Forms.CheckBox();
            this.SecondsInput = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondsInput)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Learning languages:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 122);
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
            this.checkBox2.Location = new System.Drawing.Point(18, 55);
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
            this.ComboBoxLanguages.Location = new System.Drawing.Point(18, 68);
            this.ComboBoxLanguages.Name = "ComboBoxLanguages";
            this.ComboBoxLanguages.Size = new System.Drawing.Size(258, 28);
            this.ComboBoxLanguages.TabIndex = 3;
            // 
            // EditLanguageButton
            // 
            this.EditLanguageButton.Image = ((System.Drawing.Image)(resources.GetObject("EditLanguageButton.Image")));
            this.EditLanguageButton.Location = new System.Drawing.Point(282, 62);
            this.EditLanguageButton.Name = "EditLanguageButton";
            this.EditLanguageButton.Size = new System.Drawing.Size(42, 42);
            this.EditLanguageButton.TabIndex = 4;
            this.EditLanguageButton.UseVisualStyleBackColor = true;
            this.EditLanguageButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteLanguageButton
            // 
            this.DeleteLanguageButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteLanguageButton.Image")));
            this.DeleteLanguageButton.Location = new System.Drawing.Point(333, 62);
            this.DeleteLanguageButton.Name = "DeleteLanguageButton";
            this.DeleteLanguageButton.Size = new System.Drawing.Size(42, 42);
            this.DeleteLanguageButton.TabIndex = 5;
            this.DeleteLanguageButton.UseVisualStyleBackColor = true;
            this.DeleteLanguageButton.Click += new System.EventHandler(this.DeleteLanguageButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Second between repeating:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ComboBoxLanguages);
            this.groupBox1.Controls.Add(this.DeleteLanguageButton);
            this.groupBox1.Controls.Add(this.EditLanguageButton);
            this.groupBox1.Location = new System.Drawing.Point(24, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 125);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAlgorythm);
            this.groupBox2.Controls.Add(this.SecondsInput);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(24, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 220);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Repeating";
            // 
            // cbAlgorythm
            // 
            this.cbAlgorythm.AutoSize = true;
            this.cbAlgorythm.Location = new System.Drawing.Point(18, 172);
            this.cbAlgorythm.Name = "cbAlgorythm";
            this.cbAlgorythm.Size = new System.Drawing.Size(238, 24);
            this.cbAlgorythm.TabIndex = 8;
            this.cbAlgorythm.Text = "Rare repeating words to repeat";
            this.cbAlgorythm.UseVisualStyleBackColor = true;
            this.cbAlgorythm.CheckedChanged += new System.EventHandler(this.cbAlgorythm_CheckedChanged);
            // 
            // SecondsInput
            // 
            this.SecondsInput.Location = new System.Drawing.Point(18, 76);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Location = new System.Drawing.Point(24, 401);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 105);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 532);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondsInput)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown SecondsInput;
        private System.Windows.Forms.CheckBox cbAlgorythm;
    }
}