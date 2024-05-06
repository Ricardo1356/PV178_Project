namespace TournamentManager.Frontend
{
    partial class NewPlayerForm
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
            GenerateStatsButton = new MulticolorButton();
            PlayerNameTextBox = new TextBox();
            PlayerWeightTextBox = new TextBox();
            PlayerHeightTextBox = new TextBox();
            PlayerAgeTextBox = new TextBox();
            SaveAndExitButton = new MulticolorButton();
            NPCancelButton = new MulticolorButton();
            AddNotherPlayerButton = new MulticolorButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            PlayerPositionComboBox = new ComboBox();
            ImportMultiplePlayersButton = new MulticolorButton();
            SuspendLayout();
            // 
            // GenerateStatsButton
            // 
            GenerateStatsButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            GenerateStatsButton.BorderThickness = 23;
            GenerateStatsButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            GenerateStatsButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            GenerateStatsButton.Location = new Point(86, 12);
            GenerateStatsButton.Name = "GenerateStatsButton";
            GenerateStatsButton.Size = new Size(245, 71);
            GenerateStatsButton.TabIndex = 0;
            GenerateStatsButton.Text = "Generate Player Stats";
            GenerateStatsButton.TextColor = Color.Black;
            GenerateStatsButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            GenerateStatsButton.UseVisualStyleBackColor = true;
            GenerateStatsButton.Click += GenerateStatsButton_Click;
            // 
            // PlayerNameTextBox
            // 
            PlayerNameTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            PlayerNameTextBox.Location = new Point(188, 127);
            PlayerNameTextBox.Name = "PlayerNameTextBox";
            PlayerNameTextBox.Size = new Size(164, 27);
            PlayerNameTextBox.TabIndex = 1;
            // 
            // PlayerWeightTextBox
            // 
            PlayerWeightTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            PlayerWeightTextBox.Location = new Point(190, 243);
            PlayerWeightTextBox.Name = "PlayerWeightTextBox";
            PlayerWeightTextBox.Size = new Size(68, 27);
            PlayerWeightTextBox.TabIndex = 4;
            // 
            // PlayerHeightTextBox
            // 
            PlayerHeightTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            PlayerHeightTextBox.Location = new Point(190, 204);
            PlayerHeightTextBox.Name = "PlayerHeightTextBox";
            PlayerHeightTextBox.Size = new Size(68, 27);
            PlayerHeightTextBox.TabIndex = 3;
            // 
            // PlayerAgeTextBox
            // 
            PlayerAgeTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            PlayerAgeTextBox.Location = new Point(190, 160);
            PlayerAgeTextBox.Name = "PlayerAgeTextBox";
            PlayerAgeTextBox.Size = new Size(68, 27);
            PlayerAgeTextBox.TabIndex = 2;
            // 
            // SaveAndExitButton
            // 
            SaveAndExitButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            SaveAndExitButton.BorderThickness = 17;
            SaveAndExitButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            SaveAndExitButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            SaveAndExitButton.Location = new Point(12, 351);
            SaveAndExitButton.Name = "SaveAndExitButton";
            SaveAndExitButton.Size = new Size(181, 51);
            SaveAndExitButton.TabIndex = 6;
            SaveAndExitButton.Text = "Save Player And Exit";
            SaveAndExitButton.TextColor = Color.Black;
            SaveAndExitButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            SaveAndExitButton.UseVisualStyleBackColor = true;
            SaveAndExitButton.Click += SaveAndExitButton_Click;
            // 
            // NPCancelButton
            // 
            NPCancelButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            NPCancelButton.BorderThickness = 17;
            NPCancelButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            NPCancelButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            NPCancelButton.Location = new Point(221, 408);
            NPCancelButton.Name = "NPCancelButton";
            NPCancelButton.Size = new Size(177, 51);
            NPCancelButton.TabIndex = 8;
            NPCancelButton.Text = "Cancel";
            NPCancelButton.TextColor = Color.Black;
            NPCancelButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            NPCancelButton.UseVisualStyleBackColor = true;
            NPCancelButton.Click += CancelButton_Click;
            // 
            // AddNotherPlayerButton
            // 
            AddNotherPlayerButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            AddNotherPlayerButton.BorderThickness = 17;
            AddNotherPlayerButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            AddNotherPlayerButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            AddNotherPlayerButton.Location = new Point(199, 351);
            AddNotherPlayerButton.Name = "AddNotherPlayerButton";
            AddNotherPlayerButton.Size = new Size(199, 51);
            AddNotherPlayerButton.TabIndex = 7;
            AddNotherPlayerButton.Text = "Add Another Player";
            AddNotherPlayerButton.TextColor = Color.Black;
            AddNotherPlayerButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            AddNotherPlayerButton.UseVisualStyleBackColor = true;
            AddNotherPlayerButton.Click += AddNotherPlayerButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label1.Location = new Point(121, 130);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 9;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(137, 163);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 10;
            label2.Text = "Age:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.Location = new Point(118, 207);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 11;
            label3.Text = "Height:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label4.Location = new Point(114, 246);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 12;
            label4.Text = "Weight:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label5.Location = new Point(108, 282);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 13;
            label5.Text = "Position:";
            // 
            // PlayerPositionComboBox
            // 
            PlayerPositionComboBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            PlayerPositionComboBox.FormattingEnabled = true;
            PlayerPositionComboBox.Items.AddRange(new object[] { "C", "RW", "LW", "D" });
            PlayerPositionComboBox.Location = new Point(188, 279);
            PlayerPositionComboBox.Name = "PlayerPositionComboBox";
            PlayerPositionComboBox.Size = new Size(70, 28);
            PlayerPositionComboBox.TabIndex = 5;
            // 
            // ImportMultiplePlayersButton
            // 
            ImportMultiplePlayersButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            ImportMultiplePlayersButton.BorderThickness = 17;
            ImportMultiplePlayersButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            ImportMultiplePlayersButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            ImportMultiplePlayersButton.Location = new Point(12, 408);
            ImportMultiplePlayersButton.Name = "ImportMultiplePlayersButton";
            ImportMultiplePlayersButton.Size = new Size(203, 51);
            ImportMultiplePlayersButton.TabIndex = 15;
            ImportMultiplePlayersButton.Text = "Import Multiple Players";
            ImportMultiplePlayersButton.TextColor = Color.Black;
            ImportMultiplePlayersButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            ImportMultiplePlayersButton.UseVisualStyleBackColor = true;
            ImportMultiplePlayersButton.Click += ImportMultiplePlayersButton_Click;
            // 
            // NewPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.depositphotos_79817854_stock_illustration_scratched_vector_silhouette_ice_hockey_1680852224;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(410, 471);
            Controls.Add(ImportMultiplePlayersButton);
            Controls.Add(PlayerPositionComboBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(AddNotherPlayerButton);
            Controls.Add(NPCancelButton);
            Controls.Add(SaveAndExitButton);
            Controls.Add(PlayerAgeTextBox);
            Controls.Add(PlayerHeightTextBox);
            Controls.Add(PlayerWeightTextBox);
            Controls.Add(PlayerNameTextBox);
            Controls.Add(GenerateStatsButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NewPlayerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewPlayerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MulticolorButton GenerateStatsButton;
        private TextBox PlayerNameTextBox;
        private TextBox PlayerWeightTextBox;
        private TextBox PlayerHeightTextBox;
        private TextBox PlayerAgeTextBox;
        private MulticolorButton SaveAndExitButton;
        private MulticolorButton NPCancelButton;
        private MulticolorButton AddNotherPlayerButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox PlayerPositionComboBox;
        private MulticolorButton ImportMultiplePlayersButton;
    }
}