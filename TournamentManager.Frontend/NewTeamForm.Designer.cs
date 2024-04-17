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
            CancelButton.Size = new Size(74, 29);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NewTeamNameTextBox
            // 
            NewTeamNameTextBox.Location = new Point(134, 104);
            NewTeamNameTextBox.Name = "NewTeamNameTextBox";
            NewTeamNameTextBox.Size = new Size(125, 23);
            NewTeamNameTextBox.TabIndex = 2;
            // 
            // NewTeamCityTextBox
            // 
            NewTeamCityTextBox.Location = new Point(134, 158);
            NewTeamCityTextBox.Name = "NewTeamCityTextBox";
            NewTeamCityTextBox.Size = new Size(125, 23);
            NewTeamCityTextBox.TabIndex = 3;
            // 
            // ImportTeamButton
            // 
            ImportTeamButton.Location = new Point(152, 229);
            ImportTeamButton.Name = "ImportTeamButton";
            ImportTeamButton.Size = new Size(75, 23);
            ImportTeamButton.TabIndex = 4;
            ImportTeamButton.Text = "Import";
            ImportTeamButton.UseVisualStyleBackColor = true;
            ImportTeamButton.Click += ImportTeamButton_Click;
            // 
            // NewTeamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 360);
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
    }
}