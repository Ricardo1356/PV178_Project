namespace TournamentManager.Frontend
{
    partial class TournamentTypeSelectionForm
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
            PlayOffTounamentTypeButton = new Button();
            FreeForAllTournamentTypeButton = new Button();
            TouramentTypeSelectionCancellButton = new Button();
            ExistingTeamsSelectionBox = new CheckedListBox();
            SuspendLayout();
            // 
            // PlayOffTounamentTypeButton
            // 
            PlayOffTounamentTypeButton.Font = new Font("Microsoft Sans Serif", 15F);
            PlayOffTounamentTypeButton.Location = new Point(12, 406);
            PlayOffTounamentTypeButton.Name = "PlayOffTounamentTypeButton";
            PlayOffTounamentTypeButton.Size = new Size(183, 96);
            PlayOffTounamentTypeButton.TabIndex = 0;
            PlayOffTounamentTypeButton.Text = "Play Off";
            PlayOffTounamentTypeButton.UseVisualStyleBackColor = true;
            PlayOffTounamentTypeButton.Click += PlayOffTounamentTypeButton_Click;
            // 
            // FreeForAllTournamentTypeButton
            // 
            FreeForAllTournamentTypeButton.Font = new Font("Microsoft Sans Serif", 15F);
            FreeForAllTournamentTypeButton.Location = new Point(201, 406);
            FreeForAllTournamentTypeButton.Name = "FreeForAllTournamentTypeButton";
            FreeForAllTournamentTypeButton.Size = new Size(177, 96);
            FreeForAllTournamentTypeButton.TabIndex = 1;
            FreeForAllTournamentTypeButton.Text = "Free For All";
            FreeForAllTournamentTypeButton.UseVisualStyleBackColor = true;
            FreeForAllTournamentTypeButton.Click += FreeForAllTournamentTypeButton_Click;
            // 
            // TouramentTypeSelectionCancellButton
            // 
            TouramentTypeSelectionCancellButton.Font = new Font("Microsoft Sans Serif", 15F);
            TouramentTypeSelectionCancellButton.Location = new Point(511, 459);
            TouramentTypeSelectionCancellButton.Name = "TouramentTypeSelectionCancellButton";
            TouramentTypeSelectionCancellButton.Size = new Size(111, 43);
            TouramentTypeSelectionCancellButton.TabIndex = 2;
            TouramentTypeSelectionCancellButton.Text = "Cancel";
            TouramentTypeSelectionCancellButton.UseVisualStyleBackColor = true;
            TouramentTypeSelectionCancellButton.Click += TouramentTypeSelectionCancellButton_Click;
            // 
            // ExistingTeamsSelectionBox
            // 
            ExistingTeamsSelectionBox.Font = new Font("Microsoft Sans Serif", 15F);
            ExistingTeamsSelectionBox.FormattingEnabled = true;
            ExistingTeamsSelectionBox.Location = new Point(12, 47);
            ExistingTeamsSelectionBox.Name = "ExistingTeamsSelectionBox";
            ExistingTeamsSelectionBox.Size = new Size(318, 229);
            ExistingTeamsSelectionBox.TabIndex = 3;
            // 
            // TournamentTypeSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 561);
            Controls.Add(ExistingTeamsSelectionBox);
            Controls.Add(TouramentTypeSelectionCancellButton);
            Controls.Add(FreeForAllTournamentTypeButton);
            Controls.Add(PlayOffTounamentTypeButton);
            Name = "TournamentTypeSelectionForm";
            Text = "TournamentTypeSelectionForm";
            ResumeLayout(false);
        }

        #endregion

        private Button PlayOffTounamentTypeButton;
        private Button FreeForAllTournamentTypeButton;
        private Button TouramentTypeSelectionCancellButton;
        private CheckedListBox ExistingTeamsSelectionBox;
    }
}