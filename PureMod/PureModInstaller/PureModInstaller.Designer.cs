
namespace PureModInstaller
{
    partial class PureModInstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PureModInstaller));
            this.DragPanel = new System.Windows.Forms.Panel();
            this.ProgramNameLabel = new System.Windows.Forms.Label();
            this.MinimizeAppButton = new System.Windows.Forms.Button();
            this.CloseAppButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GithubButton = new System.Windows.Forms.Button();
            this.DiscordButton = new System.Windows.Forms.Button();
            this.LinksLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.FrechInstallCBox = new System.Windows.Forms.CheckBox();
            this.SelectedPathBox = new System.Windows.Forms.TextBox();
            this.SelectPathButton = new System.Windows.Forms.Button();
            this.InstallButton = new System.Windows.Forms.Button();
            this.LogoPic = new System.Windows.Forms.PictureBox();
            this.DragPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // DragPanel
            // 
            this.DragPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DragPanel.Controls.Add(this.ProgramNameLabel);
            this.DragPanel.Controls.Add(this.MinimizeAppButton);
            this.DragPanel.Controls.Add(this.CloseAppButton);
            this.DragPanel.Location = new System.Drawing.Point(12, 12);
            this.DragPanel.Name = "DragPanel";
            this.DragPanel.Size = new System.Drawing.Size(376, 30);
            this.DragPanel.TabIndex = 0;
            this.DragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseDown);
            this.DragPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseMove);
            // 
            // ProgramNameLabel
            // 
            this.ProgramNameLabel.AutoSize = true;
            this.ProgramNameLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramNameLabel.Location = new System.Drawing.Point(4, 4);
            this.ProgramNameLabel.Name = "ProgramNameLabel";
            this.ProgramNameLabel.Size = new System.Drawing.Size(144, 23);
            this.ProgramNameLabel.TabIndex = 3;
            this.ProgramNameLabel.Text = "PureMod Installer";
            // 
            // MinimizeAppButton
            // 
            this.MinimizeAppButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.MinimizeAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeAppButton.Location = new System.Drawing.Point(319, 3);
            this.MinimizeAppButton.Name = "MinimizeAppButton";
            this.MinimizeAppButton.Size = new System.Drawing.Size(24, 24);
            this.MinimizeAppButton.TabIndex = 0;
            this.MinimizeAppButton.TabStop = false;
            this.MinimizeAppButton.Text = "—";
            this.MinimizeAppButton.UseVisualStyleBackColor = false;
            this.MinimizeAppButton.Click += new System.EventHandler(this.MinimizeAppButton_Click);
            // 
            // CloseAppButton
            // 
            this.CloseAppButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.CloseAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseAppButton.Location = new System.Drawing.Point(349, 3);
            this.CloseAppButton.Name = "CloseAppButton";
            this.CloseAppButton.Size = new System.Drawing.Size(24, 24);
            this.CloseAppButton.TabIndex = 0;
            this.CloseAppButton.TabStop = false;
            this.CloseAppButton.Text = "X";
            this.CloseAppButton.UseVisualStyleBackColor = false;
            this.CloseAppButton.Click += new System.EventHandler(this.CloseAppButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.GithubButton);
            this.panel1.Controls.Add(this.DiscordButton);
            this.panel1.Controls.Add(this.LinksLabel);
            this.panel1.Location = new System.Drawing.Point(12, 352);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 36);
            this.panel1.TabIndex = 1;
            // 
            // GithubButton
            // 
            this.GithubButton.BackColor = System.Drawing.Color.White;
            this.GithubButton.BackgroundImage = global::PureModInstaller.Properties.Resources.GitHub_Mark_32px;
            this.GithubButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GithubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GithubButton.Location = new System.Drawing.Point(307, 3);
            this.GithubButton.Name = "GithubButton";
            this.GithubButton.Size = new System.Drawing.Size(30, 30);
            this.GithubButton.TabIndex = 5;
            this.GithubButton.TabStop = false;
            this.GithubButton.UseVisualStyleBackColor = false;
            this.GithubButton.Click += new System.EventHandler(this.GithubButton_Click);
            // 
            // DiscordButton
            // 
            this.DiscordButton.BackColor = System.Drawing.Color.White;
            this.DiscordButton.BackgroundImage = global::PureModInstaller.Properties.Resources.Discord_Logo_Black__Custom_;
            this.DiscordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DiscordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DiscordButton.Location = new System.Drawing.Point(343, 3);
            this.DiscordButton.Name = "DiscordButton";
            this.DiscordButton.Size = new System.Drawing.Size(30, 30);
            this.DiscordButton.TabIndex = 4;
            this.DiscordButton.TabStop = false;
            this.DiscordButton.UseVisualStyleBackColor = false;
            this.DiscordButton.Click += new System.EventHandler(this.DiscordButton_Click);
            // 
            // LinksLabel
            // 
            this.LinksLabel.AutoSize = true;
            this.LinksLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinksLabel.Location = new System.Drawing.Point(4, 7);
            this.LinksLabel.Name = "LinksLabel";
            this.LinksLabel.Size = new System.Drawing.Size(53, 23);
            this.LinksLabel.TabIndex = 4;
            this.LinksLabel.Text = "Links:";
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MainPanel.Controls.Add(this.FrechInstallCBox);
            this.MainPanel.Controls.Add(this.SelectedPathBox);
            this.MainPanel.Controls.Add(this.SelectPathButton);
            this.MainPanel.Controls.Add(this.InstallButton);
            this.MainPanel.Location = new System.Drawing.Point(12, 204);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(376, 131);
            this.MainPanel.TabIndex = 3;
            // 
            // FrechInstallCBox
            // 
            this.FrechInstallCBox.AutoSize = true;
            this.FrechInstallCBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FrechInstallCBox.Location = new System.Drawing.Point(3, 3);
            this.FrechInstallCBox.Name = "FrechInstallCBox";
            this.FrechInstallCBox.Size = new System.Drawing.Size(85, 19);
            this.FrechInstallCBox.TabIndex = 6;
            this.FrechInstallCBox.Text = "Fresh install";
            this.FrechInstallCBox.UseVisualStyleBackColor = true;
            this.FrechInstallCBox.CheckedChanged += new System.EventHandler(this.FrechInstallCBox_CheckedChanged);
            // 
            // SelectedPathBox
            // 
            this.SelectedPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.SelectedPathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectedPathBox.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedPathBox.ForeColor = System.Drawing.Color.White;
            this.SelectedPathBox.Location = new System.Drawing.Point(63, 28);
            this.SelectedPathBox.Name = "SelectedPathBox";
            this.SelectedPathBox.ReadOnly = true;
            this.SelectedPathBox.Size = new System.Drawing.Size(310, 22);
            this.SelectedPathBox.TabIndex = 5;
            this.SelectedPathBox.TabStop = false;
            this.SelectedPathBox.Text = "Select VRChat.exe";
            // 
            // SelectPathButton
            // 
            this.SelectPathButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.SelectPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectPathButton.Font = new System.Drawing.Font("Comic Sans MS", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectPathButton.Location = new System.Drawing.Point(3, 28);
            this.SelectPathButton.Name = "SelectPathButton";
            this.SelectPathButton.Size = new System.Drawing.Size(54, 22);
            this.SelectPathButton.TabIndex = 4;
            this.SelectPathButton.TabStop = false;
            this.SelectPathButton.Text = "Select";
            this.SelectPathButton.UseVisualStyleBackColor = false;
            this.SelectPathButton.Click += new System.EventHandler(this.SelectPathButton_Click);
            // 
            // InstallButton
            // 
            this.InstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.InstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallButton.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallButton.Location = new System.Drawing.Point(3, 56);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(370, 72);
            this.InstallButton.TabIndex = 4;
            this.InstallButton.TabStop = false;
            this.InstallButton.Text = "INSTALL | UPDATE";
            this.InstallButton.UseVisualStyleBackColor = false;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // LogoPic
            // 
            this.LogoPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoPic.Image = global::PureModInstaller.Properties.Resources.PureModLogo128;
            this.LogoPic.Location = new System.Drawing.Point(128, 48);
            this.LogoPic.Name = "LogoPic";
            this.LogoPic.Size = new System.Drawing.Size(150, 150);
            this.LogoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPic.TabIndex = 2;
            this.LogoPic.TabStop = false;
            // 
            // PureModInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.LogoPic);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DragPanel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PureModInstaller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.DragPanel.ResumeLayout(false);
            this.DragPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DragPanel;
        private System.Windows.Forms.Button CloseAppButton;
        private System.Windows.Forms.Label ProgramNameLabel;
        private System.Windows.Forms.Button DiscordButton;
        private System.Windows.Forms.Button MinimizeAppButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GithubButton;
        private System.Windows.Forms.Label LinksLabel;
        private System.Windows.Forms.PictureBox LogoPic;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TextBox SelectedPathBox;
        private System.Windows.Forms.Button SelectPathButton;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.CheckBox FrechInstallCBox;
    }
}

