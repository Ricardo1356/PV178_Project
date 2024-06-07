using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentManager.Backend;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class TournamentTypeSelectionForm : Form
    {
        private BackendMain Backend;
        public TournamentTypeSelectionForm(BackendMain Backend, MainForm mainForm)
        {
            this.Backend = Backend;
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ListAllTeams();
            this.FormClosing += (s, args) => UpdateTournamentListView(mainForm);
        }
        
        private void ListAllTeams()
        {
            ExistingTeamsSelectionBox.Items.Clear();

            var teams = this.Backend.GetTeams();

            foreach (var team in teams)
            {
                if (team.CanBeManaged)
                {
                    ExistingTeamsSelectionBox.Items.Add($"{team.City} {team.Name}");
                }
            }
        }

        private void UpdateTournamentListView(MainForm mainForm)
        {
            mainForm.LoadTournamentsIntoListView();
        }

        private void UpdateTeams(List<Team> participatingTeams, Tournament Tournament, bool tournamentStart=false)
        {
            if (tournamentStart)
            {
                foreach (var team in participatingTeams)
                {
                    team.SetTournament(Tournament);
                }
            }
            if (Tournament.Finished)
            {
                foreach (var team in participatingTeams)
                {
                    team.SetTournament(null);
                }              
            }
            ListAllTeams();
        }

        private void TouramentTypeSelectionCancellButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateTournamentSettings(TournamentType type)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Please enter a name for the tournament", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.ExistingTeamsSelectionBox.CheckedItems.Count < 2 || this.ExistingTeamsSelectionBox.CheckedItems.Count > 8)
            {
                MessageBox.Show("Please select 2 - 8 teams", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (type == TournamentType.PlayOff)
            {
                if (this.ExistingTeamsSelectionBox.CheckedItems.Count % 2 != 0 || this.ExistingTeamsSelectionBox.CheckedItems.Count == 6)
                {
                    MessageBox.Show("Please select 2, 4, or 8 teams", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (this.Backend.TournamentNameExists(this.textBox1.Text))
            {
                MessageBox.Show("A tournament with this name already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private List<Team> GetSelectedTeams()
        {
            var participatingTeams = new List<Team>();
            foreach (var item in this.ExistingTeamsSelectionBox.CheckedItems)
            {
                participatingTeams.Add(this.Backend.GetTeamByNameAndCity(item.ToString()!));
            }
            return participatingTeams;
        }

        private void PlayOffTounamentTypeButton_Click(object sender, EventArgs e)
        {
            if (ValidateTournamentSettings(TournamentType.PlayOff))
            {
                var participatingTeams = GetSelectedTeams();
                Tournament t = this.Backend.CreateNewTournament(TournamentType.PlayOff, participatingTeams, textBox1.Text);
                PlayOffTournamentForm newTournament = new PlayOffTournamentForm(t, this.Backend);
                UpdateTeams(participatingTeams, t, true);
                textBox1.Text = "";
                newTournament.FormClosed += (s, args) => UpdateTeams(participatingTeams, t);
                newTournament.Show();
            }
        }

        private void FreeForAllTournamentTypeButton_Click(object sender, EventArgs e)
        {
            if (ValidateTournamentSettings(TournamentType.FFA))
            {
                var participatingTeams = GetSelectedTeams();
                Tournament t = this.Backend.CreateNewTournament(TournamentType.FFA, participatingTeams, textBox1.Text);
                FFATournamentForm newTournament = new FFATournamentForm(t, this.Backend);
                UpdateTeams(participatingTeams, t, true);
                textBox1.Text = "";
                newTournament.FormClosed += (s, args) => UpdateTeams(participatingTeams, t);
                newTournament.Show();
            }
        }
    }
}
