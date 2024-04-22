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
            CloseButton = new Button();
            RemoveTeamButton = new Button();
            PlayersListView = new DataGridView();
            RemovePlayerButton = new Button();
            AddPlayerButton = new Button();
            ((System.ComponentModel.ISupportInitialize)PlayersListView).BeginInit();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(549, 180);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 0;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // RemoveTeamButton
            // 
            RemoveTeamButton.Location = new Point(266, 168);
            RemoveTeamButton.Name = "RemoveTeamButton";
            RemoveTeamButton.Size = new Size(121, 47);
            RemoveTeamButton.TabIndex = 1;
            RemoveTeamButton.Text = "Remove this team";
            RemoveTeamButton.UseVisualStyleBackColor = true;
            RemoveTeamButton.Click += RemoveTeamButton_Click;
            // 
            // PlayersListView
            // 
            PlayersListView.AllowUserToAddRows = false;
            PlayersListView.AllowUserToDeleteRows = false;
            PlayersListView.AllowUserToResizeRows = false;
            PlayersListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PlayersListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PlayersListView.Location = new Point(12, 12);
            PlayersListView.MultiSelect = false;
            PlayersListView.Name = "PlayersListView";
            PlayersListView.ReadOnly = true;
            PlayersListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PlayersListView.Size = new Size(612, 150);
            PlayersListView.TabIndex = 2;
            // 
            // RemovePlayerButton
            // 
            RemovePlayerButton.Location = new Point(139, 168);
            RemovePlayerButton.Name = "RemovePlayerButton";
            RemovePlayerButton.Size = new Size(121, 47);
            RemovePlayerButton.TabIndex = 3;
            RemovePlayerButton.Text = "Remove Player";
            RemovePlayerButton.UseVisualStyleBackColor = true;
            RemovePlayerButton.Click += RemovePlayerButton_Click;
            // 
            // AddPlayerButton
            // 
            AddPlayerButton.Location = new Point(12, 168);
            AddPlayerButton.Name = "AddPlayerButton";
            AddPlayerButton.Size = new Size(121, 47);
            AddPlayerButton.TabIndex = 4;
            AddPlayerButton.Text = "Add Player";
            AddPlayerButton.UseVisualStyleBackColor = true;
            AddPlayerButton.Click += AddPlayerButton_Click;
            // 
            // TeamOverviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 227);
            Controls.Add(AddPlayerButton);
            Controls.Add(RemovePlayerButton);
            Controls.Add(PlayersListView);
            Controls.Add(RemoveTeamButton);
            Controls.Add(CloseButton);
            Name = "TeamOverviewForm";
            Text = "TeamOverviewForm";
            ((System.ComponentModel.ISupportInitialize)PlayersListView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button CloseButton;
        private Button RemoveTeamButton;
        private DataGridView PlayersListView;
        private Button RemovePlayerButton;
        private Button AddPlayerButton;
    }
}