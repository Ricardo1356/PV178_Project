using System.Collections;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TournamentManager.Backend;
using TournamentManager.Backend.DTOs;
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
            if (this.Backend.TeamLoadStatus != "")
                MessageBox.Show(this.Backend.TeamLoadStatus, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (this.Backend.TournamentLoadStatus != "")
                MessageBox.Show(this.Backend.TournamentLoadStatus, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Text = "Tournament Manager";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitializeListView();
            InitializeTournamentListView();
            LoadTeamsIntoListView();
            LoadTournamentsIntoListView();
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

        private void InitializeTournamentListView()
        {
            TournamentListView.View = View.Details;
            TournamentListView.FullRowSelect = true;
            TournamentListView.GridLines = true;

            TournamentListView.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            TournamentListView.Columns.Add("Name", 150);
            TournamentListView.Columns.Add("Finished", 100);
            TournamentListView.Columns.Add("Type", 100);
            TournamentListView.Columns.Add("Team Count", 150);
            TournamentListView.Columns.Add("Teams", 400);

            TournamentListView.OwnerDraw = true;
            TournamentListView.DrawColumnHeader += TournamentListView_DrawColumnHeader;
            TournamentListView.DrawItem += TournamentListView_DrawItem;
            TournamentListView.DrawSubItem += TournamentListView_DrawSubItem;
        }

        private void TournamentListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold))
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, headerFont, e.Bounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void TournamentListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void TournamentListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
            using (Pen gridLinePen = new Pen(Color.Black))
            {
                e.Graphics.DrawLine(gridLinePen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            }
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

        public void LoadTournamentsIntoListView()
        {
            TournamentListView.Items.Clear();
            foreach (TournamentDto tournament in Backend.GetTournaments())
            {
                ListViewItem item = new ListViewItem(tournament.Name);
                item.SubItems.Add(tournament.IsFinished.ToString());
                item.SubItems.Add(tournament.Type.ToString());
                item.SubItems.Add(tournament.TeamNames.Count.ToString());
                item.SubItems.Add(string.Join(", ", Backend.GetAbbreviations(tournament.TeamNames)));
                TournamentListView.Items.Add(item);
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
            TournamentTypeSelectionForm tournamentTypeSelectionForm = new TournamentTypeSelectionForm(Backend, this);
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

        private void TournamentListView_DoubleClick(object sender, EventArgs e)
        {
            if (TournamentListView.SelectedItems.Count > 0)
            {
                string tournamentName = TournamentListView.SelectedItems[0].Text;
                Tournament tournament = Backend.GetTournament(tournamentName);
                if (tournament.IsOpenned)
                {
                    MessageBox.Show("Tournament is already open!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tournament is FFATournament)
                {    
                    FFATournamentForm fFATournamentForm = new FFATournamentForm(tournament.TournamentDto, Backend);                   
                    tournament.IsOpenned = true;
                    fFATournamentForm.Show();
                    fFATournamentForm.FormClosing += (s, args) => { LoadTournamentsIntoListView(); };
                }
                else
                {
                    PlayOffTournamentForm playOffTournamentForm = new PlayOffTournamentForm(tournament.TournamentDto, Backend);
                    tournament.IsOpenned = true;
                    playOffTournamentForm.Show();
                    playOffTournamentForm.FormClosing += (s, args) => { LoadTournamentsIntoListView(); };
                }
                this.LoadTournamentsIntoListView();
            }
        }

        private void TournamentListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = sender as ListView;

            if (e.Column == 4)
            {
                return;
            }

            if (listView.ListViewItemSorter is ListViewItemComparer currentComparer && currentComparer.Column == e.Column)
            {
                currentComparer.Order = currentComparer.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                listView.ListViewItemSorter = new ListViewItemComparer(e.Column);
            }

            listView.Sort();
        }

        public class ListViewItemComparer : IComparer
        {
            public int Column { get; set; }
            public SortOrder Order { get; set; }

            public ListViewItemComparer(int column)
            {
                Column = column;
                Order = SortOrder.Ascending;
            }

            public int Compare(object x, object y)
            {
                ListViewItem itemX = x as ListViewItem;
                ListViewItem itemY = y as ListViewItem;

                int compareResult;

                switch (Column)
                {
                    case 0: // Name
                    case 2: // Type
                        compareResult = String.Compare(itemX.SubItems[Column].Text, itemY.SubItems[Column].Text);
                        break;

                    case 1: // Finished
                        bool boolX = bool.Parse(itemX.SubItems[Column].Text);
                        bool boolY = bool.Parse(itemY.SubItems[Column].Text);
                        compareResult = boolX.CompareTo(boolY);
                        break;

                    case 3: // Team Count
                        int intX = int.Parse(itemX.SubItems[Column].Text);
                        int intY = int.Parse(itemY.SubItems[Column].Text);
                        compareResult = intX.CompareTo(intY);
                        break;

                    default:
                        compareResult = String.Compare(itemX.SubItems[Column].Text, itemY.SubItems[Column].Text);
                        break;
                }

                if (Order == SortOrder.Descending)
                {
                    compareResult = -compareResult;
                }

                return compareResult;
            }
        }

    }
}
