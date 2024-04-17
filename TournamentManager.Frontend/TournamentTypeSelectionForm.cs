using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TournamentManager.Frontend
{
    public partial class TournamentTypeSelectionForm : Form
    {
        public TournamentTypeSelectionForm()
        {
            InitializeComponent();
            this.ExistingTeamsSelectionBox.Items.Add("Team 1");
            this.ExistingTeamsSelectionBox.Items.Add("Team 1");
            this.ExistingTeamsSelectionBox.BeginUpdate();
        }

        private void TouramentTypeSelectionCancellButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayOffTounamentTypeButton_Click(object sender, EventArgs e)
        {

        }

        private void FreeForAllTournamentTypeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
