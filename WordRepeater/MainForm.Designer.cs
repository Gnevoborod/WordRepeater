
namespace WordRepeater
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddNewLanguageButton = new System.Windows.Forms.ToolStripButton();
            this.LanguagesTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1.SuspendLayout();
            this.LanguagesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Word repeater";
            this.notifyIcon1.Visible = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewLanguageButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1566, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddNewLanguageButton
            // 
            this.AddNewLanguageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddNewLanguageButton.Image = ((System.Drawing.Image)(resources.GetObject("AddNewLanguageButton.Image")));
            this.AddNewLanguageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddNewLanguageButton.Name = "AddNewLanguageButton";
            this.AddNewLanguageButton.Size = new System.Drawing.Size(29, 24);
            this.AddNewLanguageButton.Text = "New Languge";
            this.AddNewLanguageButton.Click += new System.EventHandler(this.AddNewLanguageButton_Click);
            // 
            // LanguagesTab
            // 
            this.LanguagesTab.Controls.Add(this.tabPage1);
            this.LanguagesTab.Location = new System.Drawing.Point(1, 30);
            this.LanguagesTab.Name = "LanguagesTab";
            this.LanguagesTab.SelectedIndex = 0;
            this.LanguagesTab.Size = new System.Drawing.Size(1565, 936);
            this.LanguagesTab.TabIndex = 1;
            this.LanguagesTab.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1557, 903);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Projectivity";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 966);
            this.Controls.Add(this.LanguagesTab);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Word repeater";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.LanguagesTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddNewLanguageButton;
        private System.Windows.Forms.TabControl LanguagesTab;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

