using System.Drawing.Printing;
using System.Security.Cryptography;
using TournamentManager.Backend;
using TournamentManager.Backend.DTOs;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class FFATournamentForm : Form
    {
        private FFATournament Tournament;
        private const int _buttonWidht = 120;
        private const int _buttonHeight = 80;
        private const int _spacing = 10;

        private BackendMain Backend;

        private Dictionary<Button, (Team, Team, bool, int, int)> matches = new Dictionary<Button, (Team, Team, bool, int, int)>();

        public FFATournamentForm(Tournament Tournament, BackendMain backend)
        {
            this.Backend = backend;
            this.Tournament = (FFATournament)Tournament;
            this.Tournament.ShuffleTeams();
            InitializeComponent();
            Init();
            SaveTournament();
        }

        public FFATournamentForm(TournamentDto tournamentDto, BackendMain backend)
        {
            this.Backend = backend;
            this.Tournament = new FFATournament(tournamentDto.TeamNames.Count, Backend.GetMultipleTeams(tournamentDto.TeamNames), tournamentDto.Name);
            InitializeComponent();
            Init(tournamentDto.Duels[0]);
        }

        private void Init(List<DuelDto>? doneDuels=null)
        {
            this.FormClosed += (s, args) => ReleaseTournament();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = this.Tournament.Name;
            this.ShowIcon = false;
            GenerateTournamentLayout(doneDuels);
        }

        private void ReleaseTournament()
        {
            this.Backend.ReleaseTournament(this.Tournament.Name);
        }

        private void GenerateTournamentLayout(List<DuelDto>? doneDuels)
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
                    };
                    this.Controls.Add(button);
                    button.Click += MatchClick!;
                    matches.Add(button, (teams[i-1], teams[j-1], false, 0, 0));

                }
            }

            MulticolorButton EndButton = new MulticolorButton
            {
                Size = new Size(_buttonWidht + 50, _buttonHeight),
                Location = new Point(lastPanel.Left - 125 - _buttonWidht, lastPanel.Bottom + _spacing),
                Text = "End Tournament"
            };

            MulticolorButton PauseButton = new MulticolorButton
            {
                Size = new Size(_buttonWidht + 50, _buttonHeight),
                Location = new Point(lastPanel.Left - 50, lastPanel.Bottom + _spacing),
                Text = "Pause Tournament"
            };

            
            this.Controls.Add(EndButton);
            EndButton.Click += EndTournamentClick!;
            this.Controls.Add(PauseButton);
            PauseButton.Click += PauseTournamentClick!;

            if (doneDuels != null)
            {
                foreach (var duel in doneDuels)
                {
                    if (!duel.IsFinished) continue;

                    foreach (var match in matches)
                    {
                        if (match.Value.Item1.Name == duel.Team1 && match.Value.Item2.Name == duel.Team2)
                        {
                            UpdateButtonAfterMatch(match.Value.Item1, match.Value.Item2, Backend.GetTeamByName(duel.Winner), match.Key as MulticolorButton, duel.Team1Score, duel.Team2Score);
                        }
                    }
                }
            }
        }

        private void PauseTournamentClick(object sender, EventArgs e)
        {
            Backend.SaveTournaments();
            this.Close();
        }

        private void EndTournamentClick(object sender, EventArgs e)
        {
            if (CheckTournamentOver())
            {
                foreach (var team in this.Tournament.ParticipatingTeams)
                {
                    team.SetTournament(null);
                }
                TournamentDto tournamentDto = CreateTournamentDto();
                tournamentDto.IsFinished = true;
                Backend.UpdateTournamentDto(this.Tournament, tournamentDto);
                this.Close();
            }
            else
            {
                MessageBox.Show("Not all matches have been played yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private TournamentDto CreateTournamentDto()
        {
            var teamNames = new List<string>();
            foreach (var team in this.Tournament.ParticipatingTeams)
            {
                teamNames.Add(team.Name);
            }

            var duels = new List<List<DuelDto>>{ new List<DuelDto>() };
            foreach (var match in matches)
            {
                (Team t1, Team t2, bool finished, int s1, int s2) = match.Value;
                if (finished)
                {
                    duels[0].Add(new DuelDto
                    {
                        Team1 = t1.Name,
                        Team2 = t2.Name,
                        IsFinished = true,
                        Winner = s1 > s2 ? t1.Name : t2.Name,
                        Loser = s1 < s2 ? t1.Name : t2.Name,
                        Team1Score = s1,
                        Team2Score = s2
                    });
                }
                else
                {
                    duels[0].Add(new DuelDto
                    {
                        Team1 = match.Value.Item1.Name,
                        Team2 = match.Value.Item2.Name,
                        IsFinished = false,
                        Winner = null,
                        Loser = null,
                        Team1Score = 0,
                        Team2Score = 0
                    });
                }
                
            }

            return new TournamentDto
            {
                Name = this.Tournament.Name,
                IsFinished = false,
                Type = this.Tournament.Type.ToString(),
                TeamNames = teamNames,
                Duels = duels
            };
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

        private void SaveTournament()
        {
            TournamentDto tournamentDto = CreateTournamentDto();
            this.Tournament.TournamentDto = tournamentDto;
            Backend.UpdateTournamentDto(this.Tournament, tournamentDto);
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
                Team winner = matchForm.Team1Score > matchForm.Team2Score ? team1 : team2;
                UpdateButtonAfterMatch(team1, team2, winner, button, (int)matchForm.Team1Score, (int)matchForm.Team2Score);
            }
            SaveTournament();
        }

        private void UpdateButtonAfterMatch(Team team1, Team team2, Team winner, MulticolorButton button, int team1Score, int team2Score)
        {
            button.Text = $"{team1.Abbreviation} {team1Score} : {team2Score} {team2.Abbreviation}";
            button.UpdateColorsByTeam(winner);
            button.DimmButton(0.8);
            matches[button] = (team1, team2, true, team1Score, team2Score);
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
