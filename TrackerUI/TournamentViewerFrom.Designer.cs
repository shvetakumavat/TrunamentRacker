
namespace TrackerUI
{
    partial class TournamentViewerFrom
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
            this.HeadingLable = new System.Windows.Forms.Label();
            this.TournamentNameLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RundLable = new System.Windows.Forms.Label();
            this.roundComboBox = new System.Windows.Forms.ComboBox();
            this.UnplayedOnlyCheackBox = new System.Windows.Forms.CheckBox();
            this.matchupListBox = new System.Windows.Forms.ListBox();
            this.teamOneLable = new System.Windows.Forms.Label();
            this.teamOneScoreLable = new System.Windows.Forms.Label();
            this.teamOneScoreTex = new System.Windows.Forms.TextBox();
            this.teamTwoScoreText = new System.Windows.Forms.TextBox();
            this.teamTwoScoreLabel = new System.Windows.Forms.Label();
            this.teamTwoLable = new System.Windows.Forms.Label();
            this.VersusLable = new System.Windows.Forms.Label();
            this.scoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeadingLable
            // 
            this.HeadingLable.AutoSize = true;
            this.HeadingLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HeadingLable.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HeadingLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.HeadingLable.Location = new System.Drawing.Point(27, 20);
            this.HeadingLable.Name = "HeadingLable";
            this.HeadingLable.Size = new System.Drawing.Size(176, 38);
            this.HeadingLable.TabIndex = 0;
            this.HeadingLable.Text = "Tournament:";
            // 
            // TournamentNameLable
            // 
            this.TournamentNameLable.AutoSize = true;
            this.TournamentNameLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TournamentNameLable.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TournamentNameLable.ForeColor = System.Drawing.Color.Lime;
            this.TournamentNameLable.Location = new System.Drawing.Point(199, 20);
            this.TournamentNameLable.Name = "TournamentNameLable";
            this.TournamentNameLable.Size = new System.Drawing.Size(119, 38);
            this.TournamentNameLable.TabIndex = 1;
            this.TournamentNameLable.Text = "<none>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(345, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 2;
            // 
            // RundLable
            // 
            this.RundLable.AutoSize = true;
            this.RundLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RundLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RundLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RundLable.Location = new System.Drawing.Point(36, 81);
            this.RundLable.Name = "RundLable";
            this.RundLable.Size = new System.Drawing.Size(73, 28);
            this.RundLable.TabIndex = 3;
            this.RundLable.Text = "Round:";
            // 
            // roundComboBox
            // 
            this.roundComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundComboBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.roundComboBox.FormattingEnabled = true;
            this.roundComboBox.Location = new System.Drawing.Point(115, 85);
            this.roundComboBox.Name = "roundComboBox";
            this.roundComboBox.Size = new System.Drawing.Size(215, 28);
            this.roundComboBox.TabIndex = 4;
            this.roundComboBox.SelectedIndexChanged += new System.EventHandler(this.roundComboBox_SelectedIndexChanged);
            // 
            // UnplayedOnlyCheackBox
            // 
            this.UnplayedOnlyCheackBox.AutoSize = true;
            this.UnplayedOnlyCheackBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UnplayedOnlyCheackBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UnplayedOnlyCheackBox.Location = new System.Drawing.Point(367, 89);
            this.UnplayedOnlyCheackBox.Name = "UnplayedOnlyCheackBox";
            this.UnplayedOnlyCheackBox.Size = new System.Drawing.Size(128, 24);
            this.UnplayedOnlyCheackBox.TabIndex = 5;
            this.UnplayedOnlyCheackBox.Text = "Unplayed Only";
            this.UnplayedOnlyCheackBox.UseVisualStyleBackColor = false;
            this.UnplayedOnlyCheackBox.CheckedChanged += new System.EventHandler(this.UnplayedOnlyCheackBox_CheckedChanged);
            // 
            // matchupListBox
            // 
            this.matchupListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.matchupListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matchupListBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.matchupListBox.FormattingEnabled = true;
            this.matchupListBox.ItemHeight = 20;
            this.matchupListBox.Location = new System.Drawing.Point(36, 159);
            this.matchupListBox.Name = "matchupListBox";
            this.matchupListBox.Size = new System.Drawing.Size(374, 322);
            this.matchupListBox.TabIndex = 6;
            this.matchupListBox.SelectedIndexChanged += new System.EventHandler(this.matchupListBox_SelectedIndexChanged);
            // 
            // teamOneLable
            // 
            this.teamOneLable.AutoSize = true;
            this.teamOneLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.teamOneLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.teamOneLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.teamOneLable.Location = new System.Drawing.Point(467, 177);
            this.teamOneLable.Name = "teamOneLable";
            this.teamOneLable.Size = new System.Drawing.Size(122, 28);
            this.teamOneLable.TabIndex = 7;
            this.teamOneLable.Text = "<team one>";
            // 
            // teamOneScoreLable
            // 
            this.teamOneScoreLable.AutoSize = true;
            this.teamOneScoreLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.teamOneScoreLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.teamOneScoreLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.teamOneScoreLable.Location = new System.Drawing.Point(479, 234);
            this.teamOneScoreLable.Name = "teamOneScoreLable";
            this.teamOneScoreLable.Size = new System.Drawing.Size(61, 28);
            this.teamOneScoreLable.TabIndex = 8;
            this.teamOneScoreLable.Text = "Score";
            // 
            // teamOneScoreTex
            // 
            this.teamOneScoreTex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.teamOneScoreTex.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.teamOneScoreTex.Location = new System.Drawing.Point(546, 238);
            this.teamOneScoreTex.Name = "teamOneScoreTex";
            this.teamOneScoreTex.Size = new System.Drawing.Size(185, 27);
            this.teamOneScoreTex.TabIndex = 9;
            // 
            // teamTwoScoreText
            // 
            this.teamTwoScoreText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.teamTwoScoreText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.teamTwoScoreText.Location = new System.Drawing.Point(546, 408);
            this.teamTwoScoreText.Name = "teamTwoScoreText";
            this.teamTwoScoreText.Size = new System.Drawing.Size(185, 27);
            this.teamTwoScoreText.TabIndex = 12;
            // 
            // teamTwoScoreLabel
            // 
            this.teamTwoScoreLabel.AutoSize = true;
            this.teamTwoScoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.teamTwoScoreLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.teamTwoScoreLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.teamTwoScoreLabel.Location = new System.Drawing.Point(479, 404);
            this.teamTwoScoreLabel.Name = "teamTwoScoreLabel";
            this.teamTwoScoreLabel.Size = new System.Drawing.Size(61, 28);
            this.teamTwoScoreLabel.TabIndex = 11;
            this.teamTwoScoreLabel.Text = "Score";
            // 
            // teamTwoLable
            // 
            this.teamTwoLable.AutoSize = true;
            this.teamTwoLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.teamTwoLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.teamTwoLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.teamTwoLable.Location = new System.Drawing.Point(467, 347);
            this.teamTwoLable.Name = "teamTwoLable";
            this.teamTwoLable.Size = new System.Drawing.Size(122, 28);
            this.teamTwoLable.TabIndex = 10;
            this.teamTwoLable.Text = "<team two>";
            // 
            // VersusLable
            // 
            this.VersusLable.AutoSize = true;
            this.VersusLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.VersusLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VersusLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.VersusLable.Location = new System.Drawing.Point(556, 303);
            this.VersusLable.Name = "VersusLable";
            this.VersusLable.Size = new System.Drawing.Size(46, 28);
            this.VersusLable.TabIndex = 13;
            this.VersusLable.Text = "-vs-";
            // 
            // scoreButton
            // 
            this.scoreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.scoreButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.scoreButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.scoreButton.FlatAppearance.BorderSize = 2;
            this.scoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scoreButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoreButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scoreButton.Location = new System.Drawing.Point(740, 303);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(139, 51);
            this.scoreButton.TabIndex = 14;
            this.scoreButton.Text = "score";
            this.scoreButton.UseVisualStyleBackColor = false;
            this.scoreButton.Click += new System.EventHandler(this.scoreButton_Click);
            // 
            // TournamentViewerFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(934, 536);
            this.Controls.Add(this.scoreButton);
            this.Controls.Add(this.VersusLable);
            this.Controls.Add(this.teamTwoScoreText);
            this.Controls.Add(this.teamTwoScoreLabel);
            this.Controls.Add(this.teamTwoLable);
            this.Controls.Add(this.teamOneScoreTex);
            this.Controls.Add(this.teamOneScoreLable);
            this.Controls.Add(this.teamOneLable);
            this.Controls.Add(this.matchupListBox);
            this.Controls.Add(this.UnplayedOnlyCheackBox);
            this.Controls.Add(this.roundComboBox);
            this.Controls.Add(this.RundLable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TournamentNameLable);
            this.Controls.Add(this.HeadingLable);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "TournamentViewerFrom";
            this.Text = "TournamentViewerFrom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeadingLable;
        private System.Windows.Forms.Label TournamentNameLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RundLable;
        private System.Windows.Forms.ComboBox roundComboBox;
        private System.Windows.Forms.CheckBox UnplayedOnlyCheackBox;
        private System.Windows.Forms.ListBox matchupListBox;
        private System.Windows.Forms.Label teamOneLable;
        private System.Windows.Forms.Label teamOneScoreLable;
        private System.Windows.Forms.TextBox teamOneScoreTex;
        private System.Windows.Forms.TextBox teamTwoScoreText;
        private System.Windows.Forms.Label teamTwoScoreLabel;
        private System.Windows.Forms.Label teamTwoLable;
        private System.Windows.Forms.Label VersusLable;
        private System.Windows.Forms.Button scoreButton;
    }
}