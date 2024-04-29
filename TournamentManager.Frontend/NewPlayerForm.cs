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
    public partial class NewPlayerForm : Form
    {
        private BackendMain Backend;
        private Team team;
        public NewPlayerForm(BackendMain backend, Team team)
        {
            this.team = team;
            this.Backend = backend;
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.AddPlayer();
            this.Close();   
        }

        private void AddNotherPlayerButton_Click(object sender, EventArgs e)
        {
            this.AddPlayer();     
            this.Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateStatsButton_Click(object sender, EventArgs e)
        {
            PlayerStatsDto stats = Backend.GeneratePlayerStats();

            this.PlayerNameTextBox.Text = stats.Name;
            this.PlayerAgeTextBox.Text = stats.Age;
            this.PlayerHeightTextBox.Text = stats.Height;
            this.PlayerWeightTextBox.Text = stats.Weight;
            this.PlayerPositionComboBox.SelectedIndex = stats.Position;
        }

        private void AddPlayer()
        {
            PlayerStatsDto stats = new PlayerStatsDto
            {
                Age = this.PlayerAgeTextBox.Text,
                Height = this.PlayerHeightTextBox.Text,
                Name = this.PlayerNameTextBox.Text,
                Position = this.PlayerPositionComboBox.SelectedIndex,
                Weight = this.PlayerWeightTextBox.Text
            };
            var returnCode = Backend.AddPlayerToTeam(this.team, stats);
            if (returnCode > 0)
            {
                var message = Backend.ResolveErrorCode(returnCode);
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            this.PlayerNameTextBox.Text = "";
            this.PlayerAgeTextBox.Text = "";
            this.PlayerHeightTextBox.Text = "";
            this.PlayerWeightTextBox.Text = "";
            this.PlayerPositionComboBox.SelectedIndex = 0;
        }
    }
}
