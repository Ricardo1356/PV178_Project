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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            StartNewTournamentButton = new MulticolorButton();
            AppExitButton = new MulticolorButton();
            RegisterNewTeamButton = new MulticolorButton();
            TeamsListView = new ListView();
            SuspendLayout();
            // 
            // StartNewTournamentButton
            // 
            StartNewTournamentButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            StartNewTournamentButton.BorderThickness = 32;
            StartNewTournamentButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            StartNewTournamentButton.Location = new Point(209, 325);
            StartNewTournamentButton.Name = "StartNewTournamentButton";
            StartNewTournamentButton.Size = new Size(316, 96);
            StartNewTournamentButton.TabIndex = 1;
            StartNewTournamentButton.Text = "Start New Tournament";
            StartNewTournamentButton.TextColor = Color.Black;
            StartNewTournamentButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            StartNewTournamentButton.UseVisualStyleBackColor = true;
            StartNewTournamentButton.Click += StartNewTournamentButton_Click;
            // 
            // AppExitButton
            // 
            AppExitButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            AppExitButton.BorderThickness = 13;
            AppExitButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            AppExitButton.Location = new Point(619, 12);
            AppExitButton.Name = "AppExitButton";
            AppExitButton.Size = new Size(141, 41);
            AppExitButton.TabIndex = 2;
            AppExitButton.Text = "End Application";
            AppExitButton.TextColor = Color.Black;
            AppExitButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            AppExitButton.UseVisualStyleBackColor = true;
            AppExitButton.Click += AppExitButton_Click;
            // 
            // RegisterNewTeamButton
            // 
            RegisterNewTeamButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            RegisterNewTeamButton.BorderThickness = 32;
            RegisterNewTeamButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            RegisterNewTeamButton.Location = new Point(12, 325);
            RegisterNewTeamButton.Name = "RegisterNewTeamButton";
            RegisterNewTeamButton.Size = new Size(191, 96);
            RegisterNewTeamButton.TabIndex = 4;
            RegisterNewTeamButton.Text = "Add New Team";
            RegisterNewTeamButton.TextColor = Color.Black;
            RegisterNewTeamButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            RegisterNewTeamButton.UseVisualStyleBackColor = true;
            RegisterNewTeamButton.Click += RegisterNewTeamButton_Click;
            // 
            // TeamsListView
            // 
            TeamsListView.BackColor = SystemColors.ControlLightLight;
            TeamsListView.BorderStyle = BorderStyle.FixedSingle;
            TeamsListView.Location = new Point(12, 12);
            TeamsListView.MultiSelect = false;
            TeamsListView.Name = "TeamsListView";
            TeamsListView.Size = new Size(513, 200);
            TeamsListView.TabIndex = 7;
            TeamsListView.UseCompatibleStateImageBehavior = false;
            TeamsListView.DoubleClick += listView1_DoubleClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._0Sb75t1_2394455732;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(772, 433);
            Controls.Add(TeamsListView);
            Controls.Add(RegisterNewTeamButton);
            Controls.Add(AppExitButton);
            Controls.Add(StartNewTournamentButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private MulticolorButton StartNewTournamentButton;
        private MulticolorButton AppExitButton;
        private MulticolorButton RegisterNewTeamButton;
        private ListView TeamsListView;
    }
}
