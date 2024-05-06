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
            PlayOffTounamentTypeButton = new MulticolorButton();
            FreeForAllTournamentTypeButton = new MulticolorButton();
            TouramentTypeSelectionCancellButton = new MulticolorButton();
            ExistingTeamsSelectionBox = new CheckedListBox();
            SuspendLayout();
            // 
            // PlayOffTounamentTypeButton
            // 
            PlayOffTounamentTypeButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            PlayOffTounamentTypeButton.BorderThickness = 37;
            PlayOffTounamentTypeButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            PlayOffTounamentTypeButton.Location = new Point(304, 8);
            PlayOffTounamentTypeButton.Name = "PlayOffTounamentTypeButton";
            PlayOffTounamentTypeButton.Size = new Size(205, 112);
            PlayOffTounamentTypeButton.TabIndex = 0;
            PlayOffTounamentTypeButton.Text = "Play Off";
            PlayOffTounamentTypeButton.TextColor = Color.Black;
            PlayOffTounamentTypeButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            PlayOffTounamentTypeButton.UseVisualStyleBackColor = true;
            PlayOffTounamentTypeButton.Click += PlayOffTounamentTypeButton_Click;
            // 
            // FreeForAllTournamentTypeButton
            // 
            FreeForAllTournamentTypeButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            FreeForAllTournamentTypeButton.BorderThickness = 37;
            FreeForAllTournamentTypeButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            FreeForAllTournamentTypeButton.Location = new Point(304, 126);
            FreeForAllTournamentTypeButton.Name = "FreeForAllTournamentTypeButton";
            FreeForAllTournamentTypeButton.Size = new Size(205, 111);
            FreeForAllTournamentTypeButton.TabIndex = 1;
            FreeForAllTournamentTypeButton.Text = "Free For All";
            FreeForAllTournamentTypeButton.TextColor = Color.Black;
            FreeForAllTournamentTypeButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            FreeForAllTournamentTypeButton.UseVisualStyleBackColor = true;
            FreeForAllTournamentTypeButton.Click += FreeForAllTournamentTypeButton_Click;
            // 
            // TouramentTypeSelectionCancellButton
            // 
            TouramentTypeSelectionCancellButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            TouramentTypeSelectionCancellButton.BorderThickness = 14;
            TouramentTypeSelectionCancellButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            TouramentTypeSelectionCancellButton.Location = new Point(398, 269);
            TouramentTypeSelectionCancellButton.Name = "TouramentTypeSelectionCancellButton";
            TouramentTypeSelectionCancellButton.Size = new Size(111, 43);
            TouramentTypeSelectionCancellButton.TabIndex = 2;
            TouramentTypeSelectionCancellButton.Text = "Cancel";
            TouramentTypeSelectionCancellButton.TextColor = Color.Black;
            TouramentTypeSelectionCancellButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            TouramentTypeSelectionCancellButton.UseVisualStyleBackColor = true;
            TouramentTypeSelectionCancellButton.Click += TouramentTypeSelectionCancellButton_Click;
            // 
            // ExistingTeamsSelectionBox
            // 
            ExistingTeamsSelectionBox.BackColor = SystemColors.GradientInactiveCaption;
            ExistingTeamsSelectionBox.BorderStyle = BorderStyle.None;
            ExistingTeamsSelectionBox.Font = new Font("Microsoft Sans Serif", 15F);
            ExistingTeamsSelectionBox.FormattingEnabled = true;
            ExistingTeamsSelectionBox.Location = new Point(12, 12);
            ExistingTeamsSelectionBox.Name = "ExistingTeamsSelectionBox";
            ExistingTeamsSelectionBox.Size = new Size(253, 225);
            ExistingTeamsSelectionBox.TabIndex = 3;
            // 
            // TournamentTypeSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._0Sb75t1_2394455732;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(532, 336);
            Controls.Add(ExistingTeamsSelectionBox);
            Controls.Add(TouramentTypeSelectionCancellButton);
            Controls.Add(FreeForAllTournamentTypeButton);
            Controls.Add(PlayOffTounamentTypeButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "TournamentTypeSelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TournamentTypeSelectionForm";
            ResumeLayout(false);
        }

        #endregion

        private MulticolorButton PlayOffTounamentTypeButton;
        private MulticolorButton FreeForAllTournamentTypeButton;
        private MulticolorButton TouramentTypeSelectionCancellButton;
        private CheckedListBox ExistingTeamsSelectionBox;
    }
}