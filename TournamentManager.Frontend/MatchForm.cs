using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentManager.Backend;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class MatchForm : Form
    {
        private BackendMain Backend;
        private Team _team1;
        private Team _team2;
        public decimal Team1Score = 0;
        public decimal Team2Score = 0;
        public bool Ended = false;
        public MatchForm(BackendMain backend, Team team1, Team team2)
        {
            InitializeComponent();
            Backend = backend;
            _team1 = team1;
            _team2 = team2;
            Team1Label.Text = $"{team1.City} {team1.Name}";
            Team2Label.Text = $"{team2.City} {team2.Name}";
            Team1ScoreLabel.Text = 0.ToString();
            Team2ScoreLabel.Text = 0.ToString();
            PositionLabels();
            this.MaximizeBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void PositionLabels()
        {
            Team1Label.Left = label2.Left - Team1Label.Width - 10;
            Team1Label.Top = label2.Top;

            Team2Label.Left = label2.Right + 10;
            Team2Label.Top = label2.Top;
        }

        private void ChangeScoreTeam1()
        {
            Team1Score = Team1ScoreNumericUpDown1.Value + Team1ScoreNumericUpDown2.Value + Team1ScoreNumericUpDown3.Value;
            Team1ScoreLabel.Text = Team1Score.ToString();
            Team1ScoreLabel.Left = label7.Left - Team1ScoreLabel.Width - 10;
            Team1ScoreLabel.Top = label7.Top;
        }
        private void ChangeScoreTeam2()
        {
            Team2Score = Team2ScoreNumericUpDown1.Value + Team2ScoreNumericUpDown2.Value + Team2ScoreNumericUpDown3.Value;
            Team2ScoreLabel.Text = Team2Score.ToString();
            Team2ScoreLabel.Left = label7.Right + 10;
            Team2ScoreLabel.Top = label7.Top;
        }

        private void Team1ScoreNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ChangeScoreTeam1();
        }

        private void Team1ScoreNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            ChangeScoreTeam1();
        }

        private void Team1ScoreNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            ChangeScoreTeam1();
        }

        private void Team2ScoreNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ChangeScoreTeam2();
        }

        private void Team2ScoreNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            ChangeScoreTeam2();
        }

        private void Team2ScoreNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            ChangeScoreTeam2();
        }

        private void EndMatchButton_Click(object sender, EventArgs e)
        {
            if (Team1Score == Team2Score)
            {
                MessageBox.Show("The match can't end in a draw.");
                return;
            }
            Ended = true;
            this.Close();   
        }
    }
}
