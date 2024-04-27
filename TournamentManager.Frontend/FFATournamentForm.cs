using System.Drawing.Printing;
using TournamentManager.Backend;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class FFATournamentForm : Form
    {
        private BackendMain Backend;
        private Tournament Tournament;
        private int _rectangleWidht = 160;
        private int _rectangleHeight = 100;
        private int _spacing = 10;

        private Dictionary<Button, (Team, Team)> matches = new Dictionary<Button, (Team, Team)>();
        public FFATournamentForm(BackendMain backend, Tournament tournament)
        {
            this.Tournament = tournament;
            this.Backend = backend;
            tournament.ShuffleTeams();
            InitializeComponent();
            GenerateTournamentLayout();
        }

        private void GenerateTournamentLayout()
        {
            var teams = Tournament.ParticipatingTeams;
            int numberOfTeams = teams.Count;
            GenerateTeamLayout();

            for (int i = 1; i <= numberOfTeams; i++)
            {
                for (int j = 1; j <= numberOfTeams; j++)
                {
                    if (i == j)
                    {
                        Panel panel = new Panel
                        {
                            Size = new Size(_rectangleWidht, _rectangleHeight),
                            Location = new Point(10 + j * (_rectangleWidht + _spacing), 10 + i * (_rectangleHeight + _spacing)),
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.LightGray,
                        };
                        this.Controls.Add(panel);
                        continue;
                    }

                    MulticolorButton button = new MulticolorButton
                    {
                        Text = $"{teams[i-1].Name}\nvs\n{teams[j-1].Name}",
                        Location = new Point(10 + j * (_rectangleWidht + _spacing), 10 + i * (_rectangleHeight + _spacing)),
                        Size = new Size(_rectangleWidht, _rectangleHeight),
                        Tag = $"{teams[i-1].Name} vs {teams[j-1].Name}"
                    };
                    this.Controls.Add(button);
                    button.Click += MatchClick!;
                    matches.Add(button, (teams[i-1], teams[j-1]));
                }
            }
        }

        private void MatchClick(object sender, EventArgs e)
        {
            MessageBox.Show($"{matches[(sender as Button)!].Item1.Name} vs {matches[(sender as Button)!].Item2.Name}");
        }


        private void GenerateTeamLayout()
        {
            for (int i = 1; i <= Tournament.ParticipatingTeams.Count; i++)
            {
                MulticolorButton VerticalTeam = new MulticolorButton
                {
                    BackgroundColor = Tournament.ParticipatingTeams[i - 1].GetBackColor(),
                    TopBorderColor = Tournament.ParticipatingTeams[i - 1].GetTopColor(),
                    BottomBorderColor = Tournament.ParticipatingTeams[i - 1].GetBottomColor(),
                    Text = Tournament.ParticipatingTeams[i - 1].Name,
                    Tag = Tournament.ParticipatingTeams[i - 1],
                    Size = new Size(_rectangleWidht, _rectangleHeight),
                    Location = new Point(10, 10 + i * (_rectangleHeight + _spacing))
                };
                this.Controls.Add(VerticalTeam);
                MulticolorButton HorizontalTeam = new MulticolorButton
                {
                    BackgroundColor = Tournament.ParticipatingTeams[i - 1].GetBackColor(),
                    TopBorderColor = Tournament.ParticipatingTeams[i - 1].GetTopColor(),
                    BottomBorderColor = Tournament.ParticipatingTeams[i - 1].GetBottomColor(),
                    Text = Tournament.ParticipatingTeams[i - 1].Name,
                    Tag = Tournament.ParticipatingTeams[i - 1],
                    Size = new Size(_rectangleWidht, _rectangleHeight),
                    Location = new Point(10 + i * (_rectangleWidht + _spacing), 10)
                };
                this.Controls.Add(HorizontalTeam);
            }
        }
    }
}
