using System.Reflection.Metadata.Ecma335;
using System.Text;
using TournamentManager.Backend;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class PlayOffTournamentForm : Form
    {
        private BackendMain Backend;
        private PlayOffTournament Tournament;
        private List<List<POButton>> duels = new List<List<POButton>>();
        private List<POButton> buttons = new List<POButton>();
        private List<(Point Start, Point End)> linesToDraw = new List<(Point Start, Point End)>();

        public PlayOffTournamentForm(BackendMain Backend, Tournament tournament)
        {
            this.Backend = Backend;
            this.Tournament = (PlayOffTournament)tournament;
            this.Tournament.ShuffleTeams();
            InitializeComponent();
            Generate();
        }

        private void Generate()
        {
            int margin = 30;
            int spacing = 20;
            int buttonWidth = 140; 
            int buttonHeight = 80;
            int roundCount = (int)Math.Log2(this.Tournament.ParticipatingTeams.Count);
            Point currentPosition = new Point(margin, margin);
            duels.Add(new List<POButton>());
            for (int i = 0; i < this.Tournament.ParticipatingTeams.Count; i += 2)
            {
                Team team1 = this.Tournament.ParticipatingTeams[i];
                Team team2 = this.Tournament.ParticipatingTeams[i + 1];

                MulticolorButton Team1Button = new MulticolorButton
                {
                    BackgroundColor = team1.GetBackColor(),
                    TopBorderColor = team1.GetTopColor(),
                    BottomBorderColor = team1.GetBottomColor(),
                    Text = team1.Name,
                    Tag = team1,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = currentPosition
                    
                };
                TeamButton Team1PO = new TeamButton(Team1Button, team1);
                currentPosition.Y += buttonHeight + spacing;

                MulticolorButton Team2Button = new MulticolorButton
                {
                    BackgroundColor = team2.GetBackColor(),
                    TopBorderColor = team2.GetTopColor(),
                    BottomBorderColor = team2.GetBottomColor(),
                    Text = team2.Name,
                    Tag = team2,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = currentPosition
                };
                TeamButton Team2PO = new TeamButton(Team2Button, team2);
                currentPosition.Y += buttonHeight + spacing;

                MulticolorButton FirstDuelMB = new MulticolorButton
                {
                    BackgroundColor = Color.FromArgb(255, 255, 255),
                    TopBorderColor = Color.FromArgb(255, 255, 255),
                    BottomBorderColor = Color.FromArgb(255, 255, 255),
                    Text = "Duel",
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(Team2Button.Right + margin, Team1Button.Location.Y + buttonHeight / 2 - buttonHeight / 2)
                };

                MulticolorButton WinnerButton = new MulticolorButton
                {
                    BackgroundColor = Color.FromArgb(255, 255, 255),
                    TopBorderColor = Color.FromArgb(255, 255, 255),
                    BottomBorderColor = Color.FromArgb(255, 255, 255),
                    Text = "Winner",
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(FirstDuelMB.Right + spacing, FirstDuelMB.Location.Y)
                };
                TeamButton WinnerPO = new TeamButton(WinnerButton);
                DuelButton FirstDuelPO = new DuelButton(FirstDuelMB, WinnerPO, team1, team2);
                this.Controls.Add(Team1Button);
                this.Controls.Add(Team2Button);
                this.Controls.Add(FirstDuelMB);
                this.Controls.Add(WinnerButton);
                Team1Button.Click += Button_Click!;
                Team2Button.Click += Button_Click!;
                FirstDuelMB.Click += Button_Click!;
                WinnerButton.Click += Button_Click!;

                currentPosition.Y += margin;
                duels[0].Add(FirstDuelPO);
                FirstDuelPO.Button.Location = new Point(Team1Button.Right + margin, 
                    Team2Button.Location.Y - (2*buttonHeight + spacing) / 2 + buttonHeight / 2);

                WinnerPO.Button.Location = new Point(FirstDuelPO.Button.Right + spacing, FirstDuelPO.Button.Location.Y);

                linesToDraw.Add((new Point(Team1Button.Right, Team1Button.Location.Y + buttonHeight / 2),
                                 new Point(Team1Button.Right + buttonWidth /2 + margin, Team1Button.Location.Y + buttonHeight / 2)));
                linesToDraw.Add((new Point(Team1Button.Right + buttonWidth / 2 + margin, Team1Button.Location.Y + buttonHeight / 2),
                                 new Point(Team1Button.Right + margin + buttonWidth / 2, FirstDuelPO.Button.Top)));

                linesToDraw.Add((new Point(Team2Button.Right, Team2Button.Location.Y + buttonHeight / 2),
                                 new Point(Team2Button.Right + margin + buttonWidth / 2, Team2Button.Location.Y + buttonHeight / 2)));
                linesToDraw.Add((new Point(Team2Button.Right + margin +buttonWidth / 2, Team2Button.Location.Y + buttonHeight / 2),
                                 new Point(Team2Button.Right + margin + buttonWidth / 2, FirstDuelPO.Button.Bottom)));

                linesToDraw.Add((new Point(FirstDuelPO.Button.Right, FirstDuelPO.Button.Location.Y + buttonHeight / 2),
                                 new Point(FirstDuelPO.Button.Right + margin + buttonWidth / 2, FirstDuelPO.Button.Location.Y + buttonHeight / 2)));
            }
            
            for (int round = 1; round < roundCount; round++)
            {
                duels.Add(new List<POButton>());
                for (int i = 0; i < duels[round - 1].Count; i += 2)
                {
                    DuelButton DuelButton1 = (DuelButton)duels[round - 1][i];
                    DuelButton DuelButton2 = (DuelButton)duels[round - 1][i + 1];
                    MulticolorButton NextDuel = new MulticolorButton
                    {
                        BackgroundColor = Color.FromArgb(255, 255, 255),
                        TopBorderColor = Color.FromArgb(255, 255, 255),
                        BottomBorderColor = Color.FromArgb(255, 255, 255),
                        Text = "Duel",
                        Size = new Size(buttonWidth, buttonHeight),
                        Location = new Point(DuelButton1.WinnerPO.Button.Right + margin,
                                                   (DuelButton1.WinnerPO.Button.Location.Y + DuelButton2.WinnerPO.Button.Location.Y + buttonHeight) / 2 - buttonHeight / 2)
                    };
                    MulticolorButton Winner = new MulticolorButton
                    {
                        BackgroundColor = Color.FromArgb(255, 255, 255),
                        TopBorderColor = Color.FromArgb(255, 255, 255),
                        BottomBorderColor = Color.FromArgb(255, 255, 255),
                        Text = "Winner",
                        Size = new Size(buttonWidth, buttonHeight),
                        Location = new Point(NextDuel.Right + spacing, NextDuel.Location.Y)
                    };
                    TeamButton WinnerPO = new TeamButton(Winner);
                    DuelButton DuelPO = new DuelButton(NextDuel, WinnerPO, DuelButton1.Winner, DuelButton2.Winner);
                    this.Controls.Add(NextDuel);
                    this.Controls.Add(Winner);
                    NextDuel.Click += Button_Click!;
                    Winner.Click += Button_Click!;
                    duels[round].Add(DuelPO);
                    
                    linesToDraw.Add((new Point(DuelButton1.WinnerPO.Button.Right, DuelButton1.WinnerPO.Button.Location.Y + buttonHeight / 2),
                                     new Point(DuelButton1.WinnerPO.Button.Right + buttonWidth / 2 + margin, DuelButton1.WinnerPO.Button.Location.Y + buttonHeight / 2)));
                    linesToDraw.Add((new Point(DuelButton1.WinnerPO.Button.Right + buttonWidth / 2 + margin, DuelButton1.WinnerPO.Button.Location.Y + buttonHeight / 2), 
                                     new Point(DuelButton1.WinnerPO.Button.Right + buttonWidth / 2 + margin, NextDuel.Top)));
                    linesToDraw.Add((new Point(DuelButton2.WinnerPO.Button.Right, DuelButton2.WinnerPO.Button.Location.Y + buttonHeight / 2),
                                     new Point(DuelButton2.WinnerPO.Button.Right + buttonWidth / 2 + margin, DuelButton2.WinnerPO.Button.Location.Y + buttonHeight / 2)));
                    linesToDraw.Add((new Point(DuelButton2.WinnerPO.Button.Right + buttonWidth / 2 + margin, DuelButton2.WinnerPO.Button.Location.Y + buttonHeight / 2),
                                     new Point(DuelButton2.WinnerPO.Button.Right + buttonWidth / 2 + margin, NextDuel.Bottom)));
                    linesToDraw.Add((new Point(NextDuel.Right, NextDuel.Location.Y + buttonHeight / 2),
                                     new Point(NextDuel.Right + buttonWidth / 2 + margin, NextDuel.Location.Y + buttonHeight / 2)));

                }
            }            
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
         //   POButton clickedButton = GetClickedButton((Button)sender);
          //  if (clickedButton.Team1 == null || clickedButton.Team1 == null) { return; }
           // var winner = clickedButton.Team1; //TODO
        }

        private POButton GetClickedButton(Button button)
        {
            foreach (var inner in this.duels)
            {
                foreach (var duel in inner)
                {
         //           if (duel.Duel == button)
             //       {
           //             return duel;
               //     }
                }
            }
            return null!;
        }
    }
}