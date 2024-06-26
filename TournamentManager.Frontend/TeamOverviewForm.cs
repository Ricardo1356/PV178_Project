﻿using TournamentManager.Backend;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class TeamOverviewForm : Form
    {
        private BackendMain Backend;
        private Team team;
        public bool Removed = false;
        public TeamOverviewForm(BackendMain Backend, Team team)
        {
            this.Backend = Backend;
            this.team = team;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.Text = $"{this.team.City} {this.team.Name} Team Edit";
            this.MaximizeBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeTeamOverview();
            RefreshPlayersView();
        }

        private void InitializeTeamOverview()
        {
            this.PlayersTeamView.View = View.Details;
            this.PlayersTeamView.FullRowSelect = true;
            this.PlayersTeamView.GridLines = true;
            this.PlayersTeamView.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            this.PlayersTeamView.Columns.Add("Name", 150);
            this.PlayersTeamView.Columns.Add("Position", 100);
            this.PlayersTeamView.Columns.Add("Age", 50);
            this.PlayersTeamView.Columns.Add("Height", 80);
            this.PlayersTeamView.Columns.Add("Weight", 80);
            this.PlayersTeamView.OwnerDraw = true;
            this.PlayersTeamView.DrawColumnHeader += PlayersTeamView_DrawColumnHeader!;
            this.PlayersTeamView.DrawItem += PlayersTeamView_DrawItem!;
            this.PlayersTeamView.DrawSubItem += PlayersTeamView_DrawSubItem!;
        }

        private void PlayersTeamView_DrawColumnHeader(object sender, System.Windows.Forms.DrawListViewColumnHeaderEventArgs e)
        {
            using (Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold))
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, headerFont, e.Bounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void PlayersTeamView_DrawItem(object sender, System.Windows.Forms.DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void PlayersTeamView_DrawSubItem(object sender, System.Windows.Forms.DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
            using (Pen gridLinePen = new Pen(Color.Black))
            {
                e.Graphics.DrawLine(gridLinePen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshPlayersView()
        {
            PlayersTeamView.Items.Clear();
            foreach (Player player in this.team.Players)
            {
                ListViewItem item = new ListViewItem(player.Name);
                item.SubItems.Add(player.Position);
                item.SubItems.Add(player.Age.ToString());
                item.SubItems.Add(player.Height.ToString());
                item.SubItems.Add(player.Weight.ToString());
                PlayersTeamView.Items.Add(item);
            }

            if (this.team.Players.Count > 9)
            {
                this.PlayersTeamView.Columns[1].Width = 85;
            }
            else
            {
                this.PlayersTeamView.Columns[1].Width = 100;
            }
        }

        private void RemovePlayerButton_Click(object sender, EventArgs e)
        {
            if (CheckCanBeManaged())
            {
                if (PlayersTeamView.SelectedItems.Count > 0)
                {
                    int selectedIndex = PlayersTeamView.SelectedItems[0].Index;
                    this.team.RemovePlayer(GetPlayer(selectedIndex));
                    RefreshPlayersView();
                }
                else
                {
                    MessageBox.Show("Please select a player to remove.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void RemoveTeamButton_Click(object sender, EventArgs e)
        {
            if (this.Backend.RemoveTeam(this.team))
            {
                Removed = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Team is still registered in a tournament", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Player GetPlayer(int index)
        {
            return this.team.Players[index];
        }

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            if (CheckCanBeManaged())
            {
                NewPlayerForm newPlayerForm = new NewPlayerForm(this.Backend, this.team);
                newPlayerForm.ShowDialog();
                RefreshPlayersView();
            }
        }

        private void EditTeamButton_Click(object sender, EventArgs e)
        {
            if (CheckCanBeManaged())
            {
                TeamInfoForm teamInfoForm = new TeamInfoForm(this.Backend, this.team);
                teamInfoForm.ShowDialog();
            }
        }

        private bool CheckCanBeManaged()
        {
            if (this.team.CanBeManaged)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Team is still registered in a tournament, cannot be edited", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
