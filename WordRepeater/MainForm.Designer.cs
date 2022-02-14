
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
            this.taskBarMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SettingsButton = new System.Windows.Forms.ToolStripButton();
            this.AddNewLanguageButton = new System.Windows.Forms.ToolStripButton();
            this.NewWordButton = new System.Windows.Forms.ToolStripButton();
            this.AutoLoadBtn = new System.Windows.Forms.ToolStripButton();
            this.DownloadBtn = new System.Windows.Forms.ToolStripButton();
            this.Statistics = new System.Windows.Forms.ToolStripButton();
            this.AboutButton = new System.Windows.Forms.ToolStripButton();
            this.QuitButton = new System.Windows.Forms.ToolStripButton();
            this.LanguagesTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.demoLabel = new System.Windows.Forms.Label();
            this.taskBarMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.LanguagesTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.taskBarMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Word repeater";
            this.notifyIcon1.Visible = true;
            // 
            // taskBarMenu
            // 
            this.taskBarMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.taskBarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.taskBarMenu.Name = "taskBarMenu";
            this.taskBarMenu.Size = new System.Drawing.Size(115, 58);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.CloseApplication);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsButton,
            this.AddNewLanguageButton,
            this.NewWordButton,
            this.AutoLoadBtn,
            this.DownloadBtn,
            this.Statistics,
            this.AboutButton,
            this.QuitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1566, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SettingsButton
            // 
            this.SettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingsButton.Image")));
            this.SettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(29, 24);
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
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
            // NewWordButton
            // 
            this.NewWordButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewWordButton.Image = ((System.Drawing.Image)(resources.GetObject("NewWordButton.Image")));
            this.NewWordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewWordButton.Name = "NewWordButton";
            this.NewWordButton.Size = new System.Drawing.Size(29, 24);
            this.NewWordButton.Text = "New word";
            this.NewWordButton.Click += new System.EventHandler(this.NewWordButton_Click);
            // 
            // AutoLoadBtn
            // 
            this.AutoLoadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AutoLoadBtn.Image = ((System.Drawing.Image)(resources.GetObject("AutoLoadBtn.Image")));
            this.AutoLoadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AutoLoadBtn.Name = "AutoLoadBtn";
            this.AutoLoadBtn.Size = new System.Drawing.Size(29, 24);
            this.AutoLoadBtn.Text = "Load list of words";
            this.AutoLoadBtn.Click += new System.EventHandler(this.AutoLoadBtn_Click);
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DownloadBtn.Image = ((System.Drawing.Image)(resources.GetObject("DownloadBtn.Image")));
            this.DownloadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(29, 24);
            this.DownloadBtn.Text = "Save list of words";
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadBtn_Click);
            // 
            // Statistics
            // 
            this.Statistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Statistics.Image = ((System.Drawing.Image)(resources.GetObject("Statistics.Image")));
            this.Statistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Statistics.Name = "Statistics";
            this.Statistics.Size = new System.Drawing.Size(29, 24);
            this.Statistics.Text = "Statistics";
            this.Statistics.Click += new System.EventHandler(this.Statistics_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(29, 24);
            this.AboutButton.Text = "About";
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuitButton.Image = ((System.Drawing.Image)(resources.GetObject("QuitButton.Image")));
            this.QuitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(29, 24);
            this.QuitButton.Text = "Quit";
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // LanguagesTab
            // 
            this.LanguagesTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguagesTab.Controls.Add(this.tabPage1);
            this.LanguagesTab.Location = new System.Drawing.Point(1, 32);
            this.LanguagesTab.Name = "LanguagesTab";
            this.LanguagesTab.SelectedIndex = 0;
            this.LanguagesTab.Size = new System.Drawing.Size(1565, 933);
            this.LanguagesTab.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.LanguagesTab.TabIndex = 1;
            this.LanguagesTab.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.demoLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1557, 900);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Projectivity";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // demoLabel
            // 
            this.demoLabel.AutoSize = true;
            this.demoLabel.Location = new System.Drawing.Point(20, 20);
            this.demoLabel.Name = "demoLabel";
            this.demoLabel.Size = new System.Drawing.Size(0, 20);
            this.demoLabel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1566, 966);
            this.Controls.Add(this.LanguagesTab);
            this.Controls.Add(this.toolStrip1);
            this.Location = new System.Drawing.Point(20, 20);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Word repeater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.taskBarMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.LanguagesTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddNewLanguageButton;
        private System.Windows.Forms.TabControl LanguagesTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripButton NewWordButton;
        private System.Windows.Forms.ToolStripButton SettingsButton;
        private System.Windows.Forms.Label demoLabel;
        private System.Windows.Forms.ContextMenuStrip taskBarMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton QuitButton;
        private System.Windows.Forms.ToolStripButton AutoLoadBtn;
        private System.Windows.Forms.ToolStripButton DownloadBtn;
        private System.Windows.Forms.ToolStripButton Statistics;
        private System.Windows.Forms.ToolStripButton AboutButton;
    }
}

