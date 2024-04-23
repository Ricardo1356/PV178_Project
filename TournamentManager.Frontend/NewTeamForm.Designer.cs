namespace TournamentManager.Frontend
{
    partial class NewTeamForm
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
            OKButton = new Button();
            CancelButton = new Button();
            NewTeamNameTextBox = new TextBox();
            NewTeamCityTextBox = new TextBox();
            ImportTeamButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TopColorButton = new Button();
            BackColorButton = new Button();
            ButColorButton = new Button();
            PreviewButton = new MulticolorButton();
            label4 = new Label();
            SuspendLayout();
            // 
            // OKButton
            // 
            OKButton.Location = new Point(116, 315);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(74, 29);
            OKButton.TabIndex = 0;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(210, 315);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(68, 29);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NewTeamNameTextBox
            // 
            NewTeamNameTextBox.Location = new Point(134, 61);
            NewTeamNameTextBox.Name = "NewTeamNameTextBox";
            NewTeamNameTextBox.Size = new Size(144, 23);
            NewTeamNameTextBox.TabIndex = 2;
            NewTeamNameTextBox.TextChanged += NewTeamNameTextBox_TextChanged;
            // 
            // NewTeamCityTextBox
            // 
            NewTeamCityTextBox.Location = new Point(134, 94);
            NewTeamCityTextBox.Name = "NewTeamCityTextBox";
            NewTeamCityTextBox.Size = new Size(144, 23);
            NewTeamCityTextBox.TabIndex = 3;
            // 
            // ImportTeamButton
            // 
            ImportTeamButton.Location = new Point(184, 32);
            ImportTeamButton.Name = "ImportTeamButton";
            ImportTeamButton.Size = new Size(94, 23);
            ImportTeamButton.TabIndex = 4;
            ImportTeamButton.Text = "Import";
            ImportTeamButton.UseVisualStyleBackColor = true;
            ImportTeamButton.Click += ImportTeamButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 61);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 5;
            label1.Text = "Team Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 94);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 6;
            label2.Text = "Team City:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 131);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 7;
            label3.Text = "Team Colors:";
            // 
            // TopColorButton
            // 
            TopColorButton.Location = new Point(134, 131);
            TopColorButton.Name = "TopColorButton";
            TopColorButton.Size = new Size(44, 23);
            TopColorButton.TabIndex = 8;
            TopColorButton.UseVisualStyleBackColor = true;
            TopColorButton.Click += TopColorButton_Click;
            // 
            // BackColorButton
            // 
            BackColorButton.Location = new Point(184, 131);
            BackColorButton.Name = "BackColorButton";
            BackColorButton.Size = new Size(44, 23);
            BackColorButton.TabIndex = 9;
            BackColorButton.UseVisualStyleBackColor = true;
            BackColorButton.Click += BackColorButton_Click;
            // 
            // ButColorButton
            // 
            ButColorButton.Location = new Point(234, 131);
            ButColorButton.Name = "ButColorButton";
            ButColorButton.Size = new Size(44, 23);
            ButColorButton.TabIndex = 10;
            ButColorButton.UseVisualStyleBackColor = true;
            ButColorButton.Click += ButColorButton_Click;
            // 
            // PreviewButton
            // 
            PreviewButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            PreviewButton.BorderThickness = 25;
            PreviewButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            PreviewButton.Location = new Point(134, 193);
            PreviewButton.Name = "PreviewButton";
            PreviewButton.Size = new Size(144, 74);
            PreviewButton.TabIndex = 11;
            PreviewButton.TextColor = Color.Black;
            PreviewButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            PreviewButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 223);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 12;
            label4.Text = "Preview:";
            // 
            // NewTeamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 360);
            Controls.Add(label4);
            Controls.Add(PreviewButton);
            Controls.Add(ButColorButton);
            Controls.Add(BackColorButton);
            Controls.Add(TopColorButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ImportTeamButton);
            Controls.Add(NewTeamCityTextBox);
            Controls.Add(NewTeamNameTextBox);
            Controls.Add(CancelButton);
            Controls.Add(OKButton);
            Name = "NewTeamForm";
            Text = "NewTeamForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OKButton;
        private new Button CancelButton;
        private TextBox NewTeamNameTextBox;
        private TextBox NewTeamCityTextBox;
        private Button ImportTeamButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button TopColorButton;
        private Button BackColorButton;
        private Button ButColorButton;
        private MulticolorButton PreviewButton;
        private Label label4;
    }
}