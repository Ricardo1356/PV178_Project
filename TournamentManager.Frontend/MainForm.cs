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
        private Color defaultButtonColor = Color.LightSteelBlue;
        public MainForm()
        {
            this.Backend = new BackendMain();
            if (Backend.LoadStatus != "")
            MessageBox.Show(Backend.LoadStatus, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
            InitializeComponent();
            this.Text = "Tournament Manager";
            InitializeListView();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
            TeamsListView.DrawColumnHeader += ListView1_DrawColumnHeader;
            TeamsListView.DrawItem += ListView1_DrawItem;
            TeamsListView.DrawSubItem += ListView1_DrawSubItem;

        }

        private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold))
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, headerFont, e.Bounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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
            var teams = Backend.GetTeams();
            foreach (var team in teams)
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

        private void listView1_DoubleClick(object sender, EventArgs e)
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
