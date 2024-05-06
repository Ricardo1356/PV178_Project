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
            OKButton = new MulticolorButton();
            CancelButton = new MulticolorButton();
            NewTeamNameTextBox = new TextBox();
            NewTeamCityTextBox = new TextBox();
            ImportTeamButton = new MulticolorButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TopColorButton = new Button();
            BackColorButton = new Button();
            ButColorButton = new Button();
            PreviewButton = new MulticolorButton();
            label4 = new Label();
            label5 = new Label();
            TeamAbbrevationTextBox = new TextBox();
            MultipleTeamImportButton = new MulticolorButton();
            SuspendLayout();
            // 
            // OKButton
            // 
            OKButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            OKButton.BorderThickness = 16;
            OKButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            OKButton.Location = new Point(226, 319);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(80, 48);
            OKButton.TabIndex = 0;
            OKButton.Text = "OK";
            OKButton.TextColor = Color.Black;
            OKButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            CancelButton.BorderThickness = 16;
            CancelButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            CancelButton.Location = new Point(312, 319);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(80, 48);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.TextColor = Color.Black;
            CancelButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NewTeamNameTextBox
            // 
            NewTeamNameTextBox.BackColor = Color.FromArgb(224, 224, 224);
            NewTeamNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            NewTeamNameTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            NewTeamNameTextBox.Location = new Point(184, 83);
            NewTeamNameTextBox.Name = "NewTeamNameTextBox";
            NewTeamNameTextBox.Size = new Size(144, 27);
            NewTeamNameTextBox.TabIndex = 2;
            NewTeamNameTextBox.TextChanged += NewTeamNameTextBox_TextChanged;
            // 
            // NewTeamCityTextBox
            // 
            NewTeamCityTextBox.BackColor = Color.FromArgb(224, 224, 224);
            NewTeamCityTextBox.BorderStyle = BorderStyle.FixedSingle;
            NewTeamCityTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            NewTeamCityTextBox.Location = new Point(184, 112);
            NewTeamCityTextBox.Name = "NewTeamCityTextBox";
            NewTeamCityTextBox.Size = new Size(144, 27);
            NewTeamCityTextBox.TabIndex = 3;
            // 
            // ImportTeamButton
            // 
            ImportTeamButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            ImportTeamButton.BorderThickness = 15;
            ImportTeamButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            ImportTeamButton.Location = new Point(12, 12);
            ImportTeamButton.Name = "ImportTeamButton";
            ImportTeamButton.Size = new Size(122, 46);
            ImportTeamButton.TabIndex = 4;
            ImportTeamButton.Text = "Import Team";
            ImportTeamButton.TextColor = Color.Black;
            ImportTeamButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            ImportTeamButton.UseVisualStyleBackColor = true;
            ImportTeamButton.Click += ImportTeamButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(73, 87);
            label1.Name = "label1";
            label1.Size = new Size(105, 21);
            label1.TabIndex = 5;
            label1.Text = "Team Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(89, 116);
            label2.Name = "label2";
            label2.Size = new Size(89, 21);
            label2.TabIndex = 6;
            label2.Text = "Team City:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(71, 145);
            label3.Name = "label3";
            label3.Size = new Size(107, 21);
            label3.TabIndex = 7;
            label3.Text = "Team Colors:";
            // 
            // TopColorButton
            // 
            TopColorButton.BackColor = Color.FromArgb(224, 224, 224);
            TopColorButton.Location = new Point(184, 141);
            TopColorButton.Name = "TopColorButton";
            TopColorButton.Size = new Size(44, 23);
            TopColorButton.TabIndex = 8;
            TopColorButton.UseVisualStyleBackColor = false;
            TopColorButton.Click += TopColorButton_Click;
            // 
            // BackColorButton
            // 
            BackColorButton.BackColor = Color.FromArgb(224, 224, 224);
            BackColorButton.Location = new Point(234, 141);
            BackColorButton.Name = "BackColorButton";
            BackColorButton.Size = new Size(44, 23);
            BackColorButton.TabIndex = 9;
            BackColorButton.UseVisualStyleBackColor = false;
            BackColorButton.Click += BackColorButton_Click;
            // 
            // ButColorButton
            // 
            ButColorButton.BackColor = Color.FromArgb(224, 224, 224);
            ButColorButton.Location = new Point(284, 141);
            ButColorButton.Name = "ButColorButton";
            ButColorButton.Size = new Size(44, 23);
            ButColorButton.TabIndex = 10;
            ButColorButton.UseVisualStyleBackColor = false;
            ButColorButton.Click += ButColorButton_Click;
            // 
            // PreviewButton
            // 
            PreviewButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            PreviewButton.BorderThickness = 24;
            PreviewButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            PreviewButton.Location = new Point(184, 201);
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
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(103, 226);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 12;
            label4.Text = "Preview:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(19, 169);
            label5.Name = "label5";
            label5.Size = new Size(159, 21);
            label5.TabIndex = 13;
            label5.Text = "Team Abbreviation:";
            // 
            // TeamAbbrevationTextBox
            // 
            TeamAbbrevationTextBox.BackColor = Color.FromArgb(224, 224, 224);
            TeamAbbrevationTextBox.BorderStyle = BorderStyle.FixedSingle;
            TeamAbbrevationTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TeamAbbrevationTextBox.Location = new Point(184, 168);
            TeamAbbrevationTextBox.Name = "TeamAbbrevationTextBox";
            TeamAbbrevationTextBox.Size = new Size(56, 27);
            TeamAbbrevationTextBox.TabIndex = 14;
            // 
            // MultipleTeamImportButton
            // 
            MultipleTeamImportButton.BackgroundColor = Color.FromArgb(255, 255, 255);
            MultipleTeamImportButton.BorderThickness = 15;
            MultipleTeamImportButton.BottomBorderColor = Color.FromArgb(255, 255, 255);
            MultipleTeamImportButton.Location = new Point(140, 12);
            MultipleTeamImportButton.Name = "MultipleTeamImportButton";
            MultipleTeamImportButton.Size = new Size(129, 46);
            MultipleTeamImportButton.TabIndex = 15;
            MultipleTeamImportButton.Text = "Import Teams";
            MultipleTeamImportButton.TextColor = Color.Black;
            MultipleTeamImportButton.TopBorderColor = Color.FromArgb(255, 255, 255);
            MultipleTeamImportButton.UseVisualStyleBackColor = true;
            MultipleTeamImportButton.Click += MultipleTeamImportButton_Click;
            // 
            // NewTeamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.depositphotos_79817854_stock_illustration_scratched_vector_silhouette_ice_hockey_1680852224;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(414, 393);
            Controls.Add(MultipleTeamImportButton);
            Controls.Add(TeamAbbrevationTextBox);
            Controls.Add(label5);
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
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NewTeamForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewTeamForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MulticolorButton OKButton;
        private new MulticolorButton CancelButton;
        private TextBox NewTeamNameTextBox;
        private TextBox NewTeamCityTextBox;
        private MulticolorButton ImportTeamButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button TopColorButton;
        private Button BackColorButton;
        private Button ButColorButton;
        private MulticolorButton PreviewButton;
        private Label label4;
        private Label label5;
        private TextBox TeamAbbrevationTextBox;
        private MulticolorButton MultipleTeamImportButton;
    }
}