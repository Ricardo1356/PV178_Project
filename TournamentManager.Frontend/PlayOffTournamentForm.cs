using System.Text.Json;
using TournamentManager.Backend;
using TournamentManager.Backend.DTOs;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class PlayOffTournamentForm : Form
    {
        private PlayOffTournament Tournament;
        private BackendMain Backend;
        private TeamButton? lastWinner = null;
        private List<List<DuelButton>> duels = new List<List<DuelButton>>();
        private List<List<POButton>> buttons = new List<List<POButton>>();
        private List<(Point Start, Point End)> linesToDraw = new List<(Point Start, Point End)>();

        private const int _margin = 30;
        private const int _spacing = 30;
        private const int _buttonWidth = 120;
        private const int _buttonHeight = 70;
        private Color _white = Color.FromArgb(255, 255, 255);

        private bool _paused = false;

        public PlayOffTournamentForm(Tournament Tournament, BackendMain backend)
        {
            this.Backend = backend;
            this.Tournament = (PlayOffTournament)Tournament;
            this.Tournament.ShuffleTeams();
            InitializeComponent();
            Init();
            SaveTournament();
        }

        public PlayOffTournamentForm(TournamentDto tournamentDto, BackendMain backend)
        {
            this.Backend = backend;
            this.Tournament = new PlayOffTournament(tournamentDto.TeamNames.Count, backend.GetMultipleTeams(tournamentDto.TeamNames), tournamentDto.Name);
            InitializeComponent();
            Init(tournamentDto.Duels);
        }

        private void Init(List<List<DuelDto>>? doneDuels = null)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = this.Tournament.Name;
            this.ShowIcon = false;
            this.FormClosing += FormClosed!;
            Generate(doneDuels);
        }

        private void Generate(List<List<DuelDto>>? doneDuels = null)
        {
            Point last = new Point(0, 0);
            Point currentPosition = new Point(_margin, _margin);

            int roundCount = (int)Math.Log2(this.Tournament.ParticipatingTeams.Count);
            duels.Add(new List<DuelButton>());
            buttons.Add(new List<POButton>());
            for (int i = 0; i < this.Tournament.ParticipatingTeams.Count; i += 2)
            {
                Team team1 = this.Tournament.ParticipatingTeams[i];
                Team team2 = this.Tournament.ParticipatingTeams[i + 1];

                MulticolorButton Team1Button = CreateMCButton(team1.Name, team1.GetTopColor(), team1.GetBackColor(), team1.GetBottomColor(), currentPosition);
                TeamButton Team1PO = new TeamButton(Team1Button, team1);
                currentPosition.Y += _buttonHeight + _spacing;

                MulticolorButton Team2Button = CreateMCButton(team2.Name, team2.GetTopColor(), team2.GetBackColor(), team2.GetBottomColor(), currentPosition);
                TeamButton Team2PO = new TeamButton(Team2Button, team2);
                currentPosition.Y += _buttonHeight + _spacing;

                var duelLocation = new Point(Team1Button.Right + _margin,
                                             Team2Button.Location.Y - (2 * _buttonHeight + _spacing) / 2 + _buttonHeight / 2);
                MulticolorButton FirstDuelMB = CreateMCButton($"{team1.Name}\nvs\n{team2.Name}", _white, _white, _white, duelLocation);

                MulticolorButton WinnerButton = CreateMCButton("TBA", _white, _white, _white, new Point(FirstDuelMB.Right + _spacing, FirstDuelMB.Location.Y));
                TeamButton WinnerPO = new TeamButton(WinnerButton);

                DuelButton FirstDuelPO = new DuelButton(FirstDuelMB, WinnerPO, team1, team2);
                if (doneDuels != null && doneDuels[0][i/2].IsFinished)
                {
                    SetLayoutAfterMatch(FirstDuelPO, Backend.GetTeamByName(doneDuels[0][i/2].Winner), Backend.GetTeamByName(doneDuels[0][i/2].Loser), 
                        doneDuels[0][i/2].Team1Score, doneDuels[0][i/2].Team2Score);
                }
                this.Controls.Add(Team1Button);
                this.Controls.Add(Team2Button);
                this.Controls.Add(FirstDuelMB);
                this.Controls.Add(WinnerButton);
                Team1Button.Click += Button_Click!;
                Team2Button.Click += Button_Click!;
                FirstDuelMB.Click += Button_Click!;
                WinnerButton.Click += Button_Click!;
                buttons[0].Add(Team1PO);
                buttons[0].Add(Team2PO);
                buttons[0].Add(FirstDuelPO);
                buttons[0].Add(WinnerPO);

                currentPosition.Y += _margin/2;
                duels[0].Add(FirstDuelPO);

                AddLinesToDraw(Team1Button, Team2Button, FirstDuelPO.Button);

                last.Y = Team2Button.Bottom; 
                last.X = WinnerButton.Right;
                lastWinner = WinnerPO;
            }
            
            for (int round = 1; round < roundCount; round++)
            {
                duels.Add(new List<DuelButton>());
                buttons.Add(new List<POButton>());
                for (int i = 0; i < duels[round - 1].Count; i += 2)
                {
                    DuelButton DuelButton1 = duels[round - 1][i];
                    DuelButton DuelButton2 = duels[round - 1][i + 1];

                    var duelLocation = new Point(DuelButton1.WinnerPO.Button.Right + _margin,
                                      (DuelButton1.WinnerPO.Button.Location.Y + DuelButton2.WinnerPO.Button.Location.Y + 
                                      _buttonHeight) / 2 - _buttonHeight / 2);

                    MulticolorButton NextDuel = CreateMCButton("TBA", _white, _white, _white, duelLocation);                   
                    MulticolorButton Winner = CreateMCButton("TBA", _white, _white, _white, new Point(NextDuel.Right + _spacing, NextDuel.Location.Y));
                    
                    TeamButton WinnerPO = new TeamButton(Winner);
                    DuelButton DuelPO = new DuelButton(NextDuel, WinnerPO, DuelButton1.Winner, DuelButton2.Winner);

                    if (doneDuels != null && doneDuels[round][i/2].IsFinished)
                    {
                        SetLayoutAfterMatch(DuelPO, Backend.GetTeamByName(doneDuels[round][i/2].Winner), Backend.GetTeamByName(doneDuels[round][i/2].Loser),
                                                       doneDuels[round][i/2].Team1Score, doneDuels[round][i/2].Team2Score);
                    }

                    DuelButton1.WinnerPO.NextDuel = DuelPO;
                    DuelButton2.WinnerPO.NextDuel = DuelPO;

                    this.Controls.Add(NextDuel);
                    this.Controls.Add(Winner);

                    NextDuel.Click += Button_Click!;
                    Winner.Click += Button_Click!;

                    duels[round].Add(DuelPO);

                    buttons[round].Add(DuelPO);
                    buttons[round].Add(WinnerPO);

                    AddLinesToDraw(DuelButton1.WinnerPO.Button, DuelButton2.WinnerPO.Button, DuelPO.Button);

                    last.X = Winner.Right;
                    lastWinner = WinnerPO;

                }
            }
            MulticolorButton end = new MulticolorButton
            {
                Text = "End Tournament",
                Size = new Size(_buttonWidth + 50, _buttonHeight),
                Location = new Point(last.X - _buttonWidth + _margin, last.Y + _margin)
            };

            MulticolorButton pause = new MulticolorButton
            {
                Text = "Pause Tournament",
                Size = new Size(_buttonWidth + 50, _buttonHeight),
                Location = new Point(end.Right + _spacing/2, end.Top)
            };
            pause.Click += PauseTournament!;
            end.Click += EndTournament!;
            this.Controls.Add(pause);
            this.Controls.Add(end);
        }

        private void PauseTournament(object sender, EventArgs e)
        {
            this._paused = true;
            Backend.SaveTournaments();
            this.Close();       
        }

        private TournamentDto CreateTournamentDto()
        {
            TournamentDto tournamentDto = new TournamentDto
            {
                Name = this.Tournament.Name,
                TeamNames = new List<string>(),
                Duels = new List<List<DuelDto>>(),
                Type = "PlayOff",
                IsFinished = false
            };

            foreach (var team in this.Tournament.ParticipatingTeams)
            {
                tournamentDto.TeamNames.Add(team.Name);
            }

            foreach (var round in this.duels)
            {
                List<DuelDto> roundDto = new List<DuelDto>();
                foreach (var duel in round)
                {
                    DuelDto duelDto;
                    if (duel.IsFinished)
                    {
                        duelDto = new DuelDto
                        {
                            Team1 = duel.Team1.Name,
                            Team2 = duel.Team2.Name,
                            Winner = duel.Winner.Name,
                            IsFinished = true,
                            Loser = duel.Winner == duel.Team1 ? duel.Team2.Name : duel.Team1.Name,
                            Team1Score = duel.Team1Score,
                            Team2Score = duel.Team2Score
                        };
                    }
                    else
                    {
                        duelDto = new DuelDto
                        {
                            Team1 = null,
                            Team2 = null,
                            Winner = null,
                            IsFinished = false,
                            Loser = null,
                            Team1Score = 0,
                            Team2Score = 0

                        };
                    }
                    roundDto.Add(duelDto);
                }
                tournamentDto.Duels.Add(roundDto);
            }
            return tournamentDto;
        }

        private MulticolorButton CreateMCButton(string text, Color top, Color back, Color bot, Point location)
        {
            return new MulticolorButton
            {
                Text = text,
                BackgroundColor = back,
                TopBorderColor = top,
                BottomBorderColor = bot,
                Location = location,
                Size = new Size(_buttonWidth, _buttonHeight)
            };
        }

        private void AddLinesToDraw(Button TopButton, Button BotButton, Button DuelButton)
        {
            linesToDraw.Add((new Point(TopButton.Right, TopButton.Location.Y + _buttonHeight / 2),
                                 new Point(TopButton.Right + _buttonWidth / 2 + _margin, TopButton.Location.Y + _buttonHeight / 2)));
            linesToDraw.Add((new Point(TopButton.Right + _buttonWidth / 2 + _margin, TopButton.Location.Y + _buttonHeight / 2),
                             new Point(TopButton.Right + _margin + _buttonWidth / 2, DuelButton.Top)));

            linesToDraw.Add((new Point(BotButton.Right, BotButton.Location.Y + _buttonHeight / 2),
                             new Point(BotButton.Right + _margin + _buttonWidth / 2, BotButton.Location.Y + _buttonHeight / 2)));
            linesToDraw.Add((new Point(BotButton.Right + _margin + _buttonWidth / 2, BotButton.Location.Y + _buttonHeight / 2),
                             new Point(BotButton.Right + _margin + _buttonWidth / 2, DuelButton.Bottom)));

            linesToDraw.Add((new Point(DuelButton.Right, DuelButton.Location.Y + _buttonHeight / 2),
                             new Point(DuelButton.Right + _margin + _buttonWidth / 2, DuelButton.Location.Y + _buttonHeight / 2)));
        }

        private void EndTournament(object sender, EventArgs e)
        {
            if (lastWinner == null || lastWinner.Team == null)
            {
                MessageBox.Show("The tournament is not finished yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TournamentDto tournamentDto = CreateTournamentDto();
                tournamentDto.IsFinished = true;
                Backend.UpdateTournamentDto(this.Tournament, tournamentDto);
                foreach (var team in this.Tournament.ParticipatingTeams)
                {
                    team.SetTournament(null);
                }
                this.Close();
            }
        }

        private new void FormClosed(object sender, FormClosingEventArgs e)
        {
            if (!_paused && (lastWinner == null || lastWinner.Team == null) && e.CloseReason != CloseReason.UserClosing)
            {
                MessageBox.Show("The tournament is not finished yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }   
            Backend.ReleaseTournament(this.Tournament.Name);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var pen = new Pen(Color.Black, 2);
            foreach (var line in linesToDraw)
            {
                e.Graphics.DrawLine(pen, line.Start, line.End);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            POButton clickedButton = GetClickedButton((Button)sender);
            if (clickedButton is TeamButton) return;

            DuelButton duelButton = (DuelButton) clickedButton;
            if (duelButton.Team1 != null && duelButton.Team2 != null && duelButton.IsFinished == false)
            {
                ProcessFinishedDuel(duelButton);
            }          
        }

        private void ProcessFinishedDuel(DuelButton duelButton)
        {
            (bool ended, Team winner, Team loser, int team1Score, int team2Score) = GetWinner(duelButton.Team1, duelButton.Team2);
            if (ended == false) return;

            SetLayoutAfterMatch(duelButton, winner, loser, team1Score, team2Score);
            SaveTournament();
        }

        private void SetLayoutAfterMatch(DuelButton duelButton, Team winner, Team loser, int team1Score, int team2Score)
        {
            duelButton.IsFinished = true;
            duelButton.Winner = winner;
            duelButton.Team1Score = team1Score;
            duelButton.Team2Score = team2Score;
            ShadeALlTeamOccurences(loser);
            duelButton.WinnerPO.SetWinner(winner);
            duelButton.Button.UpdateColorsByTeam(winner);
            duelButton.Button.DimmButton(0.8);
            duelButton.Button.Text = $"{duelButton.Team1.Abbreviation} {team1Score} : {team2Score} {duelButton.Team2.Abbreviation}";
            int index = GetDuelButtonIndex(duelButton);
            if (duelButton.WinnerPO.NextDuel != null)
            {
                if (index % 2 == 0)
                {
                    duelButton.WinnerPO.NextDuel.Team1 = winner;
                }
                else
                {
                    duelButton.WinnerPO.NextDuel.Team2 = winner;
                }

                if (duelButton.WinnerPO.NextDuel.Team1 != null && duelButton.WinnerPO.NextDuel.Team2 != null)
                {
                    duelButton.WinnerPO.NextDuel.Button.Text = $"{duelButton.WinnerPO.NextDuel.Team1.Name}\nvs\n{duelButton.WinnerPO.NextDuel.Team2.Name}";
                }
            }
        }

        private void ShadeALlTeamOccurences(Team team)
        {
            foreach (var inner in buttons)
            {
                foreach (var button in inner)
                {
                    if (button is TeamButton)
                    {
                        TeamButton teamButton = (TeamButton)button;
                        if (teamButton.Team != null && teamButton.Team == team)
                        {
                            teamButton.FightLost();
                        }
                    }
                    else
                    {
                        DuelButton duelButton = (DuelButton)button;
                        if (duelButton.Team1 == team || duelButton.Team2 == team)
                        {
                            duelButton.ShadeButton();
                        }
                    }
                }
            }
        }

        private (bool, Team, Team, int, int) GetWinner(Team team1, Team team2)
        {
            MatchForm matchForm = new MatchForm(team1, team2);
            matchForm.ShowDialog();
            if (matchForm.Ended == false)
            {
                return (false, team1, team2, 0, 0);
            }
            
            if (matchForm.Team1Score > matchForm.Team2Score)
            {
                return (true, team1, team2, (int)matchForm.Team1Score, (int)matchForm.Team2Score);
            }
            else
            {
                return (true, team2, team1, (int)matchForm.Team1Score, (int)matchForm.Team2Score);
            }
        }

        private void SaveTournament()
        {
            TournamentDto tournamentDto = CreateTournamentDto();
            this.Tournament.TournamentDto = tournamentDto;
            this.Backend.UpdateTournamentDto(this.Tournament, tournamentDto);
        }

        private int GetDuelButtonIndex(DuelButton duelButton)
        {
            foreach (var inner in this.duels)
            {
                for (int i = 0; i < inner.Count; i++)
                {
                    if (inner[i] == duelButton)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        private POButton GetClickedButton(Button button)
        {
            foreach (var inner in this.buttons)
            {
                foreach (var b in inner)
                {
                    if (b.Button == button)
                    {
                        return b;
                    }
                }
            }
            return null!;
        }
    }
}