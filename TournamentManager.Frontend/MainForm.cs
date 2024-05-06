using System.Data;
using System.Text;
using System.Windows.Forms;
using TournamentManager.Backend;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class MainForm : Form
    {
        private BackendMain Backend;
        public MainForm()
        {
            this.Backend = new BackendMain();
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            if (this.Backend.LoadStatus != "")
                MessageBox.Show(this.Backend.LoadStatus, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Text = "Tournament Manager";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitializeListView();
            LoadTeamsIntoListView();
        }

        private void InitializeListView()
        {
            TeamsListView.View = View.Details;
            TeamsListView.FullRowSelect = true;
            TeamsListView.GridLines = true;

            TeamsListView.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            TeamsListView.Columns.Add("Name", 150);
            TeamsListView.Columns.Add("City", 150);
            TeamsListView.Columns.Add("Abbreviation", 120);
            TeamsListView.Columns.Add("Players", 80);

            TeamsListView.OwnerDraw = true;
            TeamsListView.DrawColumnHeader += TeamsListView_DrawColumnHeader;
            TeamsListView.DrawItem += TeamsListView_DrawItem;
            TeamsListView.DrawSubItem += TeamsListView_DrawSubItem;

        }

        private void TeamsListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold))
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, headerFont, e.Bounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void TeamsListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void TeamsListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
            using (Pen gridLinePen = new Pen(Color.Black))
            {
                e.Graphics.DrawLine(gridLinePen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            }
        }

        private void LoadTeamsIntoListView()
        {
            TeamsListView.Items.Clear();
            foreach (var team in this.Backend.GetTeams())
            {
                ListViewItem item = new ListViewItem(team.Name);
                item.SubItems.Add(team.City);
                item.SubItems.Add(team.Abbreviation);
                item.SubItems.Add(team.Players.Count.ToString());
                TeamsListView.Items.Add(item);
            }
        }

        private void RegisterNewTeamButton_Click(object sender, EventArgs e)
        {
            NewTeamForm newTeamForm = new NewTeamForm(this.Backend);
            newTeamForm.ShowDialog();
            this.LoadTeamsIntoListView();
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

        private void TeamListView_DoubleClick(object sender, EventArgs e)
        {
            if (TeamsListView.SelectedItems.Count > 0)
            {
                string teamName = TeamsListView.SelectedItems[0].Text;
                Team team = Backend.GetTeamByName(teamName);
                TeamOverviewForm teamOverviewForm = new TeamOverviewForm(Backend, team);
                teamOverviewForm.ShowDialog();
                this.LoadTeamsIntoListView();
            }
        }
    }
}
