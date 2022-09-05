
namespace TrackerUI
{
    partial class TournamentDashboardForm
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
            this.loadExistingTournamentcomboBox = new System.Windows.Forms.ComboBox();
            this.loadExistingTournamentLable = new System.Windows.Forms.Label();
            this.teamOneScoreLable = new System.Windows.Forms.Label();
            this.loadTournamentLable = new System.Windows.Forms.Label();
            this.createTournamentButton = new System.Windows.Forms.Button();
            this.loadTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeadingLable
            // 
            this.HeadingLable.AutoSize = true;
            this.HeadingLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HeadingLable.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HeadingLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.HeadingLable.Location = new System.Drawing.Point(240, 55);
            this.HeadingLable.Name = "HeadingLable";
            this.HeadingLable.Size = new System.Drawing.Size(353, 41);
            this.HeadingLable.TabIndex = 16;
            this.HeadingLable.Text = "Tournament Dashboard";
            // 
            // loadExistingTournamentcomboBox
            // 
            this.loadExistingTournamentcomboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadExistingTournamentcomboBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadExistingTournamentcomboBox.FormattingEnabled = true;
            this.loadExistingTournamentcomboBox.Location = new System.Drawing.Point(250, 155);
            this.loadExistingTournamentcomboBox.Name = "loadExistingTournamentcomboBox";
            this.loadExistingTournamentcomboBox.Size = new System.Drawing.Size(324, 28);
            this.loadExistingTournamentcomboBox.TabIndex = 25;
            // 
            // loadExistingTournamentLable
            // 
            this.loadExistingTournamentLable.AutoSize = true;
            this.loadExistingTournamentLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadExistingTournamentLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadExistingTournamentLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadExistingTournamentLable.Location = new System.Drawing.Point(282, 124);
            this.loadExistingTournamentLable.Name = "loadExistingTournamentLable";
            this.loadExistingTournamentLable.Size = new System.Drawing.Size(236, 28);
            this.loadExistingTournamentLable.TabIndex = 24;
            this.loadExistingTournamentLable.Text = "Load Existing Tournament";
            // 
            // teamOneScoreLable
            // 
            this.teamOneScoreLable.AutoSize = true;
            this.teamOneScoreLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.teamOneScoreLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.teamOneScoreLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.teamOneScoreLable.Location = new System.Drawing.Point(262, 96);
            this.teamOneScoreLable.Name = "teamOneScoreLable";
            this.teamOneScoreLable.Size = new System.Drawing.Size(0, 28);
            this.teamOneScoreLable.TabIndex = 22;
            // 
            // loadTournamentLable
            // 
            this.loadTournamentLable.AutoSize = true;
            this.loadTournamentLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadTournamentLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadTournamentLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadTournamentLable.Location = new System.Drawing.Point(282, 211);
            this.loadTournamentLable.Name = "loadTournamentLable";
            this.loadTournamentLable.Size = new System.Drawing.Size(0, 28);
            this.loadTournamentLable.TabIndex = 26;
            // 
            // createTournamentButton
            // 
            this.createTournamentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.createTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.createTournamentButton.FlatAppearance.BorderSize = 2;
            this.createTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTournamentButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createTournamentButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.createTournamentButton.Location = new System.Drawing.Point(272, 310);
            this.createTournamentButton.Name = "createTournamentButton";
            this.createTournamentButton.Size = new System.Drawing.Size(282, 57);
            this.createTournamentButton.TabIndex = 30;
            this.createTournamentButton.Text = "Create Tournament";
            this.createTournamentButton.UseVisualStyleBackColor = false;
            this.createTournamentButton.Click += new System.EventHandler(this.createTournamentButton_Click);
            // 
            // loadTournamentButton
            // 
            this.loadTournamentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.loadTournamentButton.FlatAppearance.BorderSize = 2;
            this.loadTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadTournamentButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loadTournamentButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadTournamentButton.Location = new System.Drawing.Point(272, 211);
            this.loadTournamentButton.Name = "loadTournamentButton";
            this.loadTournamentButton.Size = new System.Drawing.Size(282, 57);
            this.loadTournamentButton.TabIndex = 31;
            this.loadTournamentButton.Text = "Load Tournament";
            this.loadTournamentButton.UseVisualStyleBackColor = false;
            this.loadTournamentButton.Click += new System.EventHandler(this.loadTournamentButton_Click);
            // 
            // TournamentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(824, 450);
            this.Controls.Add(this.loadTournamentButton);
            this.Controls.Add(this.createTournamentButton);
            this.Controls.Add(this.loadTournamentLable);
            this.Controls.Add(this.loadExistingTournamentcomboBox);
            this.Controls.Add(this.loadExistingTournamentLable);
            this.Controls.Add(this.teamOneScoreLable);
            this.Controls.Add(this.HeadingLable);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "TournamentDashboardForm";
            this.Text = "Tournament Dashboard";
            this.Load += new System.EventHandler(this.TournamentDashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeadingLable;
        private System.Windows.Forms.ComboBox loadExistingTournamentcomboBox;
        private System.Windows.Forms.Label loadExistingTournamentLable;
        private System.Windows.Forms.Label teamOneScoreLable;
        private System.Windows.Forms.Label loadTournamentLable;
        private System.Windows.Forms.Button createTournamentButton;
        private System.Windows.Forms.Button loadTournamentButton;
    }
}