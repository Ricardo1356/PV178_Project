namespace TournamentManager.Frontend
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
            RegisterNewTeamButton = new Button();
            StartNewTournamentButton = new Button();
            AppExitButton = new Button();
            SuspendLayout();
            // 
            // RegisterNewTeamButton
            // 
            RegisterNewTeamButton.Location = new Point(390, 427);
            RegisterNewTeamButton.Name = "RegisterNewTeamButton";
            RegisterNewTeamButton.Size = new Size(172, 86);
            RegisterNewTeamButton.TabIndex = 0;
            RegisterNewTeamButton.Text = "Register New Team";
            RegisterNewTeamButton.UseVisualStyleBackColor = true;
            RegisterNewTeamButton.Click += RegisterNewTeamButton_Click;
            // 
            // StartNewTournamentButton
            // 
            StartNewTournamentButton.Location = new Point(568, 427);
            StartNewTournamentButton.Name = "StartNewTournamentButton";
            StartNewTournamentButton.Size = new Size(172, 86);
            StartNewTournamentButton.TabIndex = 1;
            StartNewTournamentButton.Text = "Start New Tournament";
            StartNewTournamentButton.UseVisualStyleBackColor = true;
            StartNewTournamentButton.Click += StartNewTournamentButton_Click;
            // 
            // AppExitButton
            // 
            AppExitButton.Location = new Point(835, 690);
            AppExitButton.Name = "AppExitButton";
            AppExitButton.Size = new Size(114, 54);
            AppExitButton.TabIndex = 2;
            AppExitButton.Text = "End Application";
            AppExitButton.UseVisualStyleBackColor = true;
            AppExitButton.Click += AppExitButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(AppExitButton);
            Controls.Add(StartNewTournamentButton);
            Controls.Add(RegisterNewTeamButton);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button RegisterNewTeamButton;
        private Button StartNewTournamentButton;
        private Button AppExitButton;
    }
}
