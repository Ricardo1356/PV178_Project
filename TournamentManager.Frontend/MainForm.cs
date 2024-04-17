using TournamentManager.Backend;

namespace TournamentManager.Frontend
{
    public partial class MainForm : Form
    {
        private BackendMain Backend;
        public MainForm()
        {
            this.Backend = new BackendMain();
            InitializeComponent();
            this.TeamsView.DataSource = this.Backend.GetTeams();

        }

        private void OpenTeamManagerButton_Click(object sender, EventArgs e)
        {
            TeamManagementForm teamManagementForm = new TeamManagementForm(this.Backend);
            teamManagementForm.ShowDialog();
            NewTeamForm newTeamForm = new NewTeamForm(this.Backend);
            newTeamForm.ShowDialog();
        }

        private void StartNewTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentTypeSelectionForm tournamentTypeSelectionForm = new TournamentTypeSelectionForm(Backend);
            tournamentTypeSelectionForm.ShowDialog();
        }


        private void AppExitButton_Click(object sender, EventArgs e)
        {
            Backend.EndProgram();
        }

        private void TeamsView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;

                dataGridView.Rows[e.RowIndex].Selected = true;

                var city = dataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                var name = dataGridView.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";

                TeamOverviewForm teamOverviewForm = new TeamOverviewForm(Backend, Backend.GetExistingTeam(name, city));
                teamOverviewForm.ShowDialog();

            }
        }
    }
}
