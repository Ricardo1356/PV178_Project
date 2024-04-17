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
        }

        private void RegisterNewTeamButton_Click(object sender, EventArgs e)
        {
            NewTeamForm newTeamForm = new NewTeamForm(this.Backend);
            newTeamForm.ShowDialog();
        }

        private void StartNewTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentTypeSelectionForm tournamentTypeSelectionForm = new TournamentTypeSelectionForm();
            tournamentTypeSelectionForm.ShowDialog();
        }
    }
}
