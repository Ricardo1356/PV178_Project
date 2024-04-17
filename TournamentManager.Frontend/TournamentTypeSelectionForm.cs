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

namespace TournamentManager.Frontend
{
    public partial class TournamentTypeSelectionForm : Form
    {
        private BackendMain Backend;
        public TournamentTypeSelectionForm(BackendMain Backend)
        {
            this.Backend = Backend;
            InitializeComponent();
            ListAllTeams();
        }

        private void ListAllTeams()
        {
            foreach (var team in this.Backend.GetTeams())
            {
                this.ExistingTeamsSelectionBox.Items.Add($"{team.Name} {team.City}");
            }   
            this.ExistingTeamsSelectionBox.BeginUpdate();
        }

        private void TouramentTypeSelectionCancellButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayOffTounamentTypeButton_Click(object sender, EventArgs e)
        {
            foreach (var team in this.ExistingTeamsSelectionBox.CheckedItems)
            {
                MessageBox.Show(team.ToString());
            }
        }

        private void FreeForAllTournamentTypeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
