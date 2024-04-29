namespace TournamentManager.Frontend
{
    partial class MatchForm
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
            Team1Label = new Label();
            label2 = new Label();
            Team2Label = new Label();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // Team1Label
            // 
            Team1Label.AutoSize = true;
            Team1Label.Location = new Point(77, 32);
            Team1Label.Name = "Team1Label";
            Team1Label.Size = new Size(38, 15);
            Team1Label.TabIndex = 0;
            Team1Label.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(224, 21);
            label2.Name = "label2";
            label2.Size = new Size(30, 28);
            label2.TabIndex = 1;
            label2.Text = "vs";
            // 
            // Team2Label
            // 
            Team2Label.AutoSize = true;
            Team2Label.Location = new Point(372, 34);
            Team2Label.Name = "Team2Label";
            Team2Label.Size = new Size(38, 15);
            Team2Label.TabIndex = 2;
            Team2Label.Text = "label3";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(109, 187);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(38, 23);
            numericUpDown1.TabIndex = 3;
            // 
            // MatchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 469);
            Controls.Add(numericUpDown1);
            Controls.Add(Team2Label);
            Controls.Add(label2);
            Controls.Add(Team1Label);
            Name = "MatchForm";
            Text = "MatchForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Team1Label;
        private Label label2;
        private Label Team2Label;
        private NumericUpDown numericUpDown1;
    }
}