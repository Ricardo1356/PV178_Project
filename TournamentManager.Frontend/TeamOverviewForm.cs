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
    public partial class TeamOverviewForm : Form
    {
        private BackendMain Backend;
        private Team team;
        public TeamOverviewForm(BackendMain Backend, Team team)
        {
            this.Backend = Backend;
            this.team = team;
            InitializeComponent();
            this.PlayersListView.DataSource = team.Players;
            this.Text = $"{team.City} {team.Name}";
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoveTeamButton_Click(object sender, EventArgs e)
        {
            if (this.Backend.RemoveTeam(this.team))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Team is still registered in a tournament", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshPlayersView()
        {
            this.PlayersListView.DataSource = null;
            this.PlayersListView.DataSource = this.team.Players;
        }   

        private Player GetPlayer(int index)
        {
            return this.team.Players[index];
        }

        private void RemovePlayerButton_Click(object sender, EventArgs e)
        {
            if (this.PlayersListView.SelectedRows.Count > 0)
            {
                int selectedIndex = this.PlayersListView.SelectedRows[0].Index;
                this.team.RemovePlayer(GetPlayer(selectedIndex));
                RefreshPlayersView();
            }
            else
            {
                MessageBox.Show("Please select a player to remove.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
