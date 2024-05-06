using System.Drawing.Printing;
using TournamentManager.Backend;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class FFATournamentForm : Form
    {
        private FFATournament Tournament;
        private const int _buttonWidht = 160;
        private const int _buttonHeight = 100;
        private const int _spacing = 10;

        private Dictionary<Button, (Team, Team, bool)> matches = new Dictionary<Button, (Team, Team, bool)>();

        public FFATournamentForm(Tournament Tournament)
        {
            this.Tournament = (FFATournament)Tournament;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.Tournament.ShuffleTeams();           
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = this.Tournament.Name;
            this.ShowIcon = false;
            this.FormClosing += FFATournamentForm_FormClosing;
            GenerateTournamentLayout();
        }

        private void GenerateTournamentLayout()
        {
            var teams = Tournament.ParticipatingTeams;
            int teamCount = teams.Count;
            GenerateTeamLayout();
            Panel lastPanel = new Panel();

            for (int i = 1; i <= teamCount; i++)
            {
                for (int j = 1; j <= teamCount; j++)
                {
                    if (i == j)
                    {
                        Panel panel = new Panel
                        {
                            Size = new Size(_buttonWidht, _buttonHeight),
                            Location = new Point(10 + j * (_buttonWidht + _spacing), 10 + i * (_buttonHeight + _spacing)),
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.LightGray,
                        };
                        this.Controls.Add(panel);
                        lastPanel = panel;
                        continue;
                    }
                    
                    MulticolorButton button = new MulticolorButton
                    {
                        Text = $"{teams[i-1].Name}\nvs\n{teams[j-1].Name}",
                        Location = new Point(10 + j * (_buttonWidht + _spacing), 10 + i * (_buttonHeight + _spacing)),
                        Size = new Size(_buttonWidht, _buttonHeight),
                        Tag = $"{teams[i-1].Name} vs {teams[j-1].Name}"
                    };
                    this.Controls.Add(button);
                    button.Click += MatchClick!;
                    matches.Add(button, (teams[i-1], teams[j-1], false));
                }
            }
            MulticolorButton EndButton = new MulticolorButton
            {
                Size = new Size(_buttonWidht + 50, _buttonHeight),
                Location = new Point(lastPanel.Left - 50, lastPanel.Bottom + _spacing),
                Text = "End Tournament"
            };
            this.Controls.Add(EndButton);
            EndButton.Click += EndTournamentClick!;
        }

        private void EndTournamentClick(object sender, EventArgs e)
        {
            if (CheckTournamentOver())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Not all matches have been played yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool CheckTournamentOver()
        {
            foreach (var match in matches)
            {
                if (!match.Value.Item3)
                {
                    return false;
                }
            }
            return true;
        }

        private void FFATournamentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckTournamentOver())
            {
                e.Cancel = true;
                MessageBox.Show("Not all matches have been played yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MatchClick(object sender, EventArgs e)
        {
            if (matches[(sender as Button)!].Item3)
            {
                return;
            }
            MulticolorButton button = (sender as MulticolorButton)!;
            Team team1 = matches[(sender as Button)!].Item1;
            Team team2 = matches[(sender as Button)!].Item2;
            MatchForm matchForm = new MatchForm(team1, team2);
            matchForm.ShowDialog();
            if (matchForm.Ended)
            {
                button.Text = $"{team1.Abbreviation} {matchForm.Team1Score} : {matchForm.Team2Score} {team2.Abbreviation}";
                Team winner = matchForm.Team1Score > matchForm.Team2Score ? team1 : team2;
                button.UpdateColorsByTeam(winner);
                button.DimmButton(0.8);
                matches[button] = (team1, team2, true);
            }
        }

        private void GenerateTeamLayout()
        {
            for (int i = 1; i <= Tournament.ParticipatingTeams.Count; i++)
            {
                MulticolorButton VerticalTeam = CreateMCButton(i, new Point(10, 10 + i * (_buttonHeight + _spacing)));
                this.Controls.Add(VerticalTeam);
                MulticolorButton HorizontalTeam = CreateMCButton(i, new Point(10 + i * (_buttonWidht + _spacing), 10));
                this.Controls.Add(HorizontalTeam);
            }
        }

        private MulticolorButton CreateMCButton(int i, Point location)
        {
            return new MulticolorButton
            {
                BackgroundColor = Tournament.ParticipatingTeams[i - 1].GetBackColor(),
                TopBorderColor = Tournament.ParticipatingTeams[i - 1].GetTopColor(),
                BottomBorderColor = Tournament.ParticipatingTeams[i - 1].GetBottomColor(),
                Text = Tournament.ParticipatingTeams[i - 1].Name,
                Tag = Tournament.ParticipatingTeams[i - 1],
                Size = new Size(_buttonWidht, _buttonHeight),
                Location = location
            };
        }
    }
}
