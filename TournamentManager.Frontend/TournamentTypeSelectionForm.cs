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
        public TournamentTypeSelectionForm(BackendMain Backend)
        {
            this.Backend = Backend;
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ListAllTeams();
        }

        private void ListAllTeams()
        {
            foreach (var team in this.Backend.GetTeams())
            {
                this.ExistingTeamsSelectionBox.Items.Add($"{team.City} {team.Name}");
            }
            this.ExistingTeamsSelectionBox.BeginUpdate();
        }

        private void TouramentTypeSelectionCancellButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayOffTounamentTypeButton_Click(object sender, EventArgs e)
        {
            if (this.ExistingTeamsSelectionBox.CheckedItems.Count < 2 || this.ExistingTeamsSelectionBox.CheckedItems.Count > 8)
            {
                MessageBox.Show("Please select 2 - 8 teams", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.ExistingTeamsSelectionBox.CheckedItems.Count % 2 != 0 || this.ExistingTeamsSelectionBox.CheckedItems.Count == 6)
            {
                MessageBox.Show("Please select 2, 4 or 8 teams", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var participatingTeams = new List<Team>();
            foreach (var team in this.ExistingTeamsSelectionBox.CheckedItems)
            {
                participatingTeams.Add(this.Backend.GetTeamByJoined(team.ToString()!));
            }

            PlayOffTournamentForm newTournament = new PlayOffTournamentForm(this.Backend, this.Backend.CreateNewTournament(TournamentType.PlayOff, participatingTeams));
            newTournament.ShowDialog();

        }

        private void FreeForAllTournamentTypeButton_Click(object sender, EventArgs e)
        {
            if (this.ExistingTeamsSelectionBox.CheckedItems.Count < 2 || this.ExistingTeamsSelectionBox.CheckedItems.Count > 8)
            {
                MessageBox.Show("Please select 2 - 8 teams", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var participatingTeams = new List<Team>();
            foreach (var team in this.ExistingTeamsSelectionBox.CheckedItems)
            {
                participatingTeams.Add(this.Backend.GetTeamByJoined(team.ToString()!));
            }   
            FFATournamentForm newTournament = new FFATournamentForm(this.Backend, this.Backend.CreateNewTournament(TournamentType.FFA, participatingTeams));
            newTournament.ShowDialog();
        }
    }
}
