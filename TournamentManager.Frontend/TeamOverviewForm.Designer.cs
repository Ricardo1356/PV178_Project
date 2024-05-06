namespace TournamentManager.Frontend
{
    partial class TeamOverviewForm
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
            CloseButton = new MulticolorButton();
            RemoveTeamButton = new MulticolorButton();
            RemovePlayerButton = new MulticolorButton();
            AddPlayerButton = new MulticolorButton();
            PlayersTeamView = new ListView();
            EditTeamButton = new MulticolorButton();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            CloseButton.BorderThickness = 17;
            CloseButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            CloseButton.Location = new Point(482, 241);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(153, 51);
            CloseButton.TabIndex = 0;
            CloseButton.Text = "Close";
            CloseButton.TextColor = Color.Black;
            CloseButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // RemoveTeamButton
            // 
            RemoveTeamButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            RemoveTeamButton.BorderThickness = 17;
            RemoveTeamButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            RemoveTeamButton.Location = new Point(482, 13);
            RemoveTeamButton.Name = "RemoveTeamButton";
            RemoveTeamButton.Size = new Size(153, 51);
            RemoveTeamButton.TabIndex = 1;
            RemoveTeamButton.Text = "Remove this team";
            RemoveTeamButton.TextColor = Color.Black;
            RemoveTeamButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            RemoveTeamButton.UseVisualStyleBackColor = true;
            RemoveTeamButton.Click += RemoveTeamButton_Click;
            // 
            // RemovePlayerButton
            // 
            RemovePlayerButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            RemovePlayerButton.BorderThickness = 17;
            RemovePlayerButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            RemovePlayerButton.Location = new Point(482, 70);
            RemovePlayerButton.Name = "RemovePlayerButton";
            RemovePlayerButton.Size = new Size(153, 51);
            RemovePlayerButton.TabIndex = 3;
            RemovePlayerButton.Text = "Remove Player";
            RemovePlayerButton.TextColor = Color.Black;
            RemovePlayerButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            RemovePlayerButton.UseVisualStyleBackColor = true;
            RemovePlayerButton.Click += RemovePlayerButton_Click;
            // 
            // AddPlayerButton
            // 
            AddPlayerButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            AddPlayerButton.BorderThickness = 17;
            AddPlayerButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            AddPlayerButton.Location = new Point(482, 127);
            AddPlayerButton.Name = "AddPlayerButton";
            AddPlayerButton.Size = new Size(153, 51);
            AddPlayerButton.TabIndex = 4;
            AddPlayerButton.Text = "Add Players";
            AddPlayerButton.TextColor = Color.Black;
            AddPlayerButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            AddPlayerButton.UseVisualStyleBackColor = true;
            AddPlayerButton.Click += AddPlayerButton_Click;
            // 
            // PlayersTeamView
            // 
            PlayersTeamView.FullRowSelect = true;
            PlayersTeamView.GridLines = true;
            PlayersTeamView.LabelWrap = false;
            PlayersTeamView.Location = new Point(10, 13);
            PlayersTeamView.MultiSelect = false;
            PlayersTeamView.Name = "PlayersTeamView";
            PlayersTeamView.RightToLeft = RightToLeft.No;
            PlayersTeamView.Size = new Size(462, 279);
            PlayersTeamView.TabIndex = 5;
            PlayersTeamView.UseCompatibleStateImageBehavior = false;
            // 
            // EditTeamButton
            // 
            EditTeamButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            EditTeamButton.BorderThickness = 17;
            EditTeamButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            EditTeamButton.Location = new Point(482, 184);
            EditTeamButton.Name = "EditTeamButton";
            EditTeamButton.Size = new Size(153, 51);
            EditTeamButton.TabIndex = 6;
            EditTeamButton.Text = "Edit Team";
            EditTeamButton.TextColor = Color.Black;
            EditTeamButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            EditTeamButton.UseVisualStyleBackColor = true;
            EditTeamButton.Click += EditTeamButton_Click;
            // 
            // TeamOverviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(644, 298);
            Controls.Add(EditTeamButton);
            Controls.Add(PlayersTeamView);
            Controls.Add(AddPlayerButton);
            Controls.Add(RemovePlayerButton);
            Controls.Add(RemoveTeamButton);
            Controls.Add(CloseButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "TeamOverviewForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TeamOverviewForm";
            ResumeLayout(false);
        }

        #endregion

        private MulticolorButton CloseButton;
        private MulticolorButton RemoveTeamButton;
        private MulticolorButton RemovePlayerButton;
        private MulticolorButton AddPlayerButton;
        private ListView PlayersTeamView;
        private MulticolorButton EditTeamButton;
    }
}