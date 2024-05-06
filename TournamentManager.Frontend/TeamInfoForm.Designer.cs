namespace TournamentManager.Frontend
{
    partial class TeamInfoForm
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
            label1 = new Label();
            label2 = new Label();
            TeamPreviewButton = new MulticolorButton();
            TISaveButton = new MulticolorButton();
            TICancelButton = new MulticolorButton();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            NewNameEditTextBox = new TextBox();
            NewAbbEditTextBox = new TextBox();
            NewCityEditTextBox = new TextBox();
            TopColorD = new ColorDialog();
            BackColorD = new ColorDialog();
            BotColorD = new ColorDialog();
            TopColoruButton = new Button();
            BackColorButton = new Button();
            BotColorButton = new Button();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(25, 24);
            label1.Name = "label1";
            label1.Size = new Size(110, 45);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label2.Location = new Point(118, 24);
            label2.Name = "label2";
            label2.Size = new Size(110, 45);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // TeamPreviewButton
            // 
            TeamPreviewButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            TeamPreviewButton.BorderThickness = 36;
            TeamPreviewButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            TeamPreviewButton.Location = new Point(25, 272);
            TeamPreviewButton.Name = "TeamPreviewButton";
            TeamPreviewButton.Size = new Size(350, 108);
            TeamPreviewButton.TabIndex = 3;
            TeamPreviewButton.Text = "button1";
            TeamPreviewButton.TextColor = Color.Black;
            TeamPreviewButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            TeamPreviewButton.UseVisualStyleBackColor = true;
            // 
            // TISaveButton
            // 
            TISaveButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            TISaveButton.BorderThickness = 13;
            TISaveButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            TISaveButton.Location = new Point(25, 386);
            TISaveButton.Name = "TISaveButton";
            TISaveButton.Size = new Size(93, 41);
            TISaveButton.TabIndex = 4;
            TISaveButton.Text = "Save";
            TISaveButton.TextColor = Color.Black;
            TISaveButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            TISaveButton.UseVisualStyleBackColor = true;
            TISaveButton.Click += TISaveButton_Click;
            // 
            // TICancelButton
            // 
            TICancelButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            TICancelButton.BorderThickness = 13;
            TICancelButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            TICancelButton.Location = new Point(124, 386);
            TICancelButton.Name = "TICancelButton";
            TICancelButton.Size = new Size(97, 41);
            TICancelButton.TabIndex = 5;
            TICancelButton.Text = "Cancel";
            TICancelButton.TextColor = Color.Black;
            TICancelButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            TICancelButton.UseVisualStyleBackColor = true;
            TICancelButton.Click += TICancelButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.Location = new Point(90, 101);
            label4.Name = "label4";
            label4.Size = new Size(109, 25);
            label4.TabIndex = 6;
            label4.Text = "New Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F);
            label5.Location = new Point(108, 139);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 7;
            label5.Text = "New City:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F);
            label6.Location = new Point(32, 176);
            label6.Name = "label6";
            label6.Size = new Size(167, 25);
            label6.TabIndex = 8;
            label6.Text = "New Abbreviation:";
            // 
            // NewNameEditTextBox
            // 
            NewNameEditTextBox.Font = new Font("Segoe UI", 14.25F);
            NewNameEditTextBox.Location = new Point(205, 93);
            NewNameEditTextBox.Name = "NewNameEditTextBox";
            NewNameEditTextBox.Size = new Size(170, 33);
            NewNameEditTextBox.TabIndex = 9;
            // 
            // NewAbbEditTextBox
            // 
            NewAbbEditTextBox.Font = new Font("Segoe UI", 14.25F);
            NewAbbEditTextBox.Location = new Point(205, 173);
            NewAbbEditTextBox.Name = "NewAbbEditTextBox";
            NewAbbEditTextBox.Size = new Size(68, 33);
            NewAbbEditTextBox.TabIndex = 10;
            // 
            // NewCityEditTextBox
            // 
            NewCityEditTextBox.Font = new Font("Segoe UI", 14.25F);
            NewCityEditTextBox.Location = new Point(205, 134);
            NewCityEditTextBox.Name = "NewCityEditTextBox";
            NewCityEditTextBox.Size = new Size(170, 33);
            NewCityEditTextBox.TabIndex = 11;
            // 
            // TopColoruButton
            // 
            TopColoruButton.Location = new Point(205, 221);
            TopColoruButton.Name = "TopColoruButton";
            TopColoruButton.Size = new Size(46, 28);
            TopColoruButton.TabIndex = 12;
            TopColoruButton.UseVisualStyleBackColor = true;
            // 
            // BackColorButton
            // 
            BackColorButton.Location = new Point(268, 221);
            BackColorButton.Name = "BackColorButton";
            BackColorButton.Size = new Size(46, 28);
            BackColorButton.TabIndex = 13;
            BackColorButton.UseVisualStyleBackColor = true;
            // 
            // BotColorButton
            // 
            BotColorButton.Location = new Point(329, 221);
            BotColorButton.Name = "BotColorButton";
            BotColorButton.Size = new Size(46, 28);
            BotColorButton.TabIndex = 14;
            BotColorButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(124, 221);
            label7.Name = "label7";
            label7.Size = new Size(70, 25);
            label7.TabIndex = 15;
            label7.Text = "Colors:";
            // 
            // TeamInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 464);
            Controls.Add(label7);
            Controls.Add(BotColorButton);
            Controls.Add(BackColorButton);
            Controls.Add(TopColoruButton);
            Controls.Add(NewCityEditTextBox);
            Controls.Add(NewAbbEditTextBox);
            Controls.Add(NewNameEditTextBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(TICancelButton);
            Controls.Add(TISaveButton);
            Controls.Add(TeamPreviewButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TeamInfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TeamInfoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private MulticolorButton TeamPreviewButton;
        private MulticolorButton TISaveButton;
        private MulticolorButton TICancelButton;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox NewNameEditTextBox;
        private TextBox NewAbbEditTextBox;
        private TextBox NewCityEditTextBox;
        private ColorDialog TopColorD;
        private ColorDialog BackColorD;
        private ColorDialog BotColorD;
        private Button TopColoruButton;
        private Button BackColorButton;
        private Button BotColorButton;
        private Label label7;
    }
}