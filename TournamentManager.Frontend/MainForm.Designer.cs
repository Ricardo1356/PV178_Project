namespace TournamentManager.Frontend
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            OpenTeamManagerButton = new Button();
            StartNewTournamentButton = new Button();
            AppExitButton = new Button();
            teamBindingSource = new BindingSource(components);
            TeamsView = new DataGridView();
            cityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)teamBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TeamsView).BeginInit();
            SuspendLayout();
            // 
            // OpenTeamManagerButton
            // 
            OpenTeamManagerButton.Location = new Point(51, 126);
            OpenTeamManagerButton.Name = "OpenTeamManagerButton";
            OpenTeamManagerButton.Size = new Size(151, 41);
            OpenTeamManagerButton.TabIndex = 0;
            OpenTeamManagerButton.Text = "Manage Teams";
            OpenTeamManagerButton.UseVisualStyleBackColor = true;
            OpenTeamManagerButton.Click += OpenTeamManagerButton_Click;
            // 
            // StartNewTournamentButton
            // 
            StartNewTournamentButton.Location = new Point(590, 332);
            StartNewTournamentButton.Name = "StartNewTournamentButton";
            StartNewTournamentButton.Size = new Size(172, 86);
            StartNewTournamentButton.TabIndex = 1;
            StartNewTournamentButton.Text = "Start New Tournament";
            StartNewTournamentButton.UseVisualStyleBackColor = true;
            StartNewTournamentButton.Click += StartNewTournamentButton_Click;
            // 
            // AppExitButton
            // 
            AppExitButton.Location = new Point(899, 12);
            AppExitButton.Name = "AppExitButton";
            AppExitButton.Size = new Size(114, 54);
            AppExitButton.TabIndex = 2;
            AppExitButton.Text = "End Application";
            AppExitButton.UseVisualStyleBackColor = true;
            AppExitButton.Click += AppExitButton_Click;
            // 
            // teamBindingSource
            // 
            teamBindingSource.DataSource = typeof(Backend.Structures.Team);
            // 
            // TeamsView
            // 
            TeamsView.AutoGenerateColumns = false;
            TeamsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TeamsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TeamsView.Columns.AddRange(new DataGridViewColumn[] { cityDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
            TeamsView.DataSource = teamBindingSource;
            TeamsView.Location = new Point(51, 190);
            TeamsView.Name = "TeamsView";
            TeamsView.Size = new Size(311, 150);
            TeamsView.TabIndex = 3;
            TeamsView.CellDoubleClick += TeamsView_CellDoubleClick;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            cityDataGridViewTextBoxColumn.FillWeight = 120F;
            cityDataGridViewTextBoxColumn.HeaderText = "City";
            cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            cityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            nameDataGridViewTextBoxColumn.FillWeight = 120F;
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 861);
            Controls.Add(TeamsView);
            Controls.Add(AppExitButton);
            Controls.Add(StartNewTournamentButton);
            Controls.Add(OpenTeamManagerButton);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)teamBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)TeamsView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button OpenTeamManagerButton;
        private Button StartNewTournamentButton;
        private Button AppExitButton;
        private BindingSource teamBindingSource;
        private DataGridView TeamsView;
        private DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}
