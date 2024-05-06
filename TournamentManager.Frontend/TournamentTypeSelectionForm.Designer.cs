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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // PlayOffTounamentTypeButton
            // 
            PlayOffTounamentTypeButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            PlayOffTounamentTypeButton.BorderThickness = 33;
            PlayOffTounamentTypeButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            PlayOffTounamentTypeButton.Location = new Point(307, 45);
            PlayOffTounamentTypeButton.Name = "PlayOffTounamentTypeButton";
            PlayOffTounamentTypeButton.Size = new Size(167, 101);
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
            FreeForAllTournamentTypeButton.BorderThickness = 33;
            FreeForAllTournamentTypeButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            FreeForAllTournamentTypeButton.Location = new Point(307, 152);
            FreeForAllTournamentTypeButton.Name = "FreeForAllTournamentTypeButton";
            FreeForAllTournamentTypeButton.Size = new Size(167, 101);
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
            TouramentTypeSelectionCancellButton.Location = new Point(363, 364);
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
            ExistingTeamsSelectionBox.Location = new Point(12, 45);
            ExistingTeamsSelectionBox.Name = "ExistingTeamsSelectionBox";
            ExistingTeamsSelectionBox.Size = new Size(289, 200);
            ExistingTeamsSelectionBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(284, 30);
            label1.TabIndex = 5;
            label1.Text = "Teams for new tournament:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 275);
            label2.Name = "label2";
            label2.Size = new Size(223, 25);
            label2.TabIndex = 6;
            label2.Text = "New tournament name:";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(12, 303);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(338, 33);
            textBox1.TabIndex = 7;
            // 
            // TournamentTypeSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ice_hockey_player_silhouette_vector;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(488, 419);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ExistingTeamsSelectionBox);
            Controls.Add(TouramentTypeSelectionCancellButton);
            Controls.Add(FreeForAllTournamentTypeButton);
            Controls.Add(PlayOffTounamentTypeButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "TournamentTypeSelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TournamentTypeSelectionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MulticolorButton PlayOffTounamentTypeButton;
        private MulticolorButton FreeForAllTournamentTypeButton;
        private MulticolorButton TouramentTypeSelectionCancellButton;
        private CheckedListBox ExistingTeamsSelectionBox;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
    }
}