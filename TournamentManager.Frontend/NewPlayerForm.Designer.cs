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
            GenerateStatsButton = new Button();
            PlayerNameTextBox = new TextBox();
            PlayerWeightTextBox = new TextBox();
            PlayerHeightTextBox = new TextBox();
            PlayerAgeTextBox = new TextBox();
            SaveAndExitButton = new Button();
            NPCancelButton = new Button();
            AddNotherPlayerButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            PlayerPositionComboBox = new ComboBox();
            ImportMultiplePlayersButton = new Button();
            SuspendLayout();
            // 
            // GenerateStatsButton
            // 
            GenerateStatsButton.Location = new Point(76, 12);
            GenerateStatsButton.Name = "GenerateStatsButton";
            GenerateStatsButton.Size = new Size(161, 72);
            GenerateStatsButton.TabIndex = 0;
            GenerateStatsButton.Text = "Generate Player Stats";
            GenerateStatsButton.UseVisualStyleBackColor = true;
            GenerateStatsButton.Click += GenerateStatsButton_Click;
            // 
            // PlayerNameTextBox
            // 
            PlayerNameTextBox.Location = new Point(128, 99);
            PlayerNameTextBox.Name = "PlayerNameTextBox";
            PlayerNameTextBox.Size = new Size(100, 23);
            PlayerNameTextBox.TabIndex = 1;
            // 
            // PlayerWeightTextBox
            // 
            PlayerWeightTextBox.Location = new Point(128, 221);
            PlayerWeightTextBox.Name = "PlayerWeightTextBox";
            PlayerWeightTextBox.Size = new Size(100, 23);
            PlayerWeightTextBox.TabIndex = 4;
            // 
            // PlayerHeightTextBox
            // 
            PlayerHeightTextBox.Location = new Point(128, 182);
            PlayerHeightTextBox.Name = "PlayerHeightTextBox";
            PlayerHeightTextBox.Size = new Size(100, 23);
            PlayerHeightTextBox.TabIndex = 3;
            // 
            // PlayerAgeTextBox
            // 
            PlayerAgeTextBox.Location = new Point(128, 138);
            PlayerAgeTextBox.Name = "PlayerAgeTextBox";
            PlayerAgeTextBox.Size = new Size(100, 23);
            PlayerAgeTextBox.TabIndex = 2;
            // 
            // SaveAndExitButton
            // 
            SaveAndExitButton.Location = new Point(23, 293);
            SaveAndExitButton.Name = "SaveAndExitButton";
            SaveAndExitButton.Size = new Size(134, 42);
            SaveAndExitButton.TabIndex = 6;
            SaveAndExitButton.Text = "Save Player And Exit";
            SaveAndExitButton.UseVisualStyleBackColor = true;
            SaveAndExitButton.Click += SaveAndExitButton_Click;
            // 
            // NPCancelButton
            // 
            NPCancelButton.Location = new Point(163, 341);
            NPCancelButton.Name = "NPCancelButton";
            NPCancelButton.Size = new Size(129, 42);
            NPCancelButton.TabIndex = 8;
            NPCancelButton.Text = "Cancel";
            NPCancelButton.UseVisualStyleBackColor = true;
            NPCancelButton.Click += CancelButton_Click;
            // 
            // AddNotherPlayerButton
            // 
            AddNotherPlayerButton.Location = new Point(163, 293);
            AddNotherPlayerButton.Name = "AddNotherPlayerButton";
            AddNotherPlayerButton.Size = new Size(129, 42);
            AddNotherPlayerButton.TabIndex = 7;
            AddNotherPlayerButton.Text = "Add Another Player";
            AddNotherPlayerButton.UseVisualStyleBackColor = true;
            AddNotherPlayerButton.Click += AddNotherPlayerButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 103);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 9;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 141);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 10;
            label2.Text = "Age:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 182);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 11;
            label3.Text = "Height:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 221);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 12;
            label4.Text = "Weight:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 260);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 13;
            label5.Text = "Position:";
            // 
            // PlayerPositionComboBox
            // 
            PlayerPositionComboBox.FormattingEnabled = true;
            PlayerPositionComboBox.Items.AddRange(new object[] { "C", "RW", "LW", "D" });
            PlayerPositionComboBox.Location = new Point(126, 257);
            PlayerPositionComboBox.Name = "PlayerPositionComboBox";
            PlayerPositionComboBox.Size = new Size(121, 23);
            PlayerPositionComboBox.TabIndex = 5;
            // 
            // ImportMultiplePlayersButton
            // 
            ImportMultiplePlayersButton.Location = new Point(22, 341);
            ImportMultiplePlayersButton.Name = "ImportMultiplePlayersButton";
            ImportMultiplePlayersButton.Size = new Size(135, 42);
            ImportMultiplePlayersButton.TabIndex = 15;
            ImportMultiplePlayersButton.Text = "Import Multiple Players";
            ImportMultiplePlayersButton.UseVisualStyleBackColor = true;
            ImportMultiplePlayersButton.Click += ImportMultiplePlayersButton_Click;
            // 
            // NewPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 401);
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
            Name = "NewPlayerForm";
            Text = "NewPlayerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GenerateStatsButton;
        private TextBox PlayerNameTextBox;
        private TextBox PlayerWeightTextBox;
        private TextBox PlayerHeightTextBox;
        private TextBox PlayerAgeTextBox;
        private Button SaveAndExitButton;
        private Button NPCancelButton;
        private Button AddNotherPlayerButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox PlayerPositionComboBox;
        private Button ImportMultiplePlayersButton;
    }
}