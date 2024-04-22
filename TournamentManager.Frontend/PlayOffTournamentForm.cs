using System.Text;
using TournamentManager.Backend;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class PlayOffTournamentForm : Form
    {
        private BackendMain Backend;
        private PlayOffTournament Tournament;
        private List<(Point Start, Point End)> linesToDraw = new List<(Point Start, Point End)>();


        public PlayOffTournamentForm(BackendMain Backend, Tournament tournament)
        {
            this.Backend = Backend;
            this.Tournament = (PlayOffTournament)tournament;
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
            List<List<POButton>> duels = new List<List<POButton>>();
            duels.Add(new List<POButton>());
            for (int i = 0; i < this.Tournament.ParticipatingTeams.Count; i += 2)
            {
                Team team1 = this.Tournament.ParticipatingTeams[i];
                Team team2 = this.Tournament.ParticipatingTeams[i + 1];
                Button duelButton = new Button
                {
                    Text = "Duel",
                    Size = new Size(buttonWidth, buttonHeight),
                    Tag = "Duel"
                };
                Button winnerButton = new Button
                {
                    Text = "Winner",
                    Size = new Size(buttonWidth, buttonHeight),
                    Tag = "Winner"                   
                };
                Button Team1 = new Button
                {
                    Text = team1.Name,
                    Tag = team1,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = currentPosition
                    
                };
                currentPosition.Y += buttonHeight + spacing;
                Button Team2 = new Button
                {
                    Text = team2.Name,
                    Tag = team2,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = currentPosition
                };
                POButton poButton = new POButton(Team1, Team2, winnerButton, duelButton);

                currentPosition.Y += buttonHeight + spacing;
                this.Controls.Add(poButton.Team1);
                this.Controls.Add(poButton.Team2);
                this.Controls.Add(poButton.Duel);
                this.Controls.Add(winnerButton);
                poButton.Winner = winnerButton;
                poButton.Duel.Location = new Point(poButton.Team1.Location.X + buttonWidth + margin, 
                    poButton.Team2.Location.Y - (2*buttonHeight+spacing)/2 + buttonHeight/2);
                winnerButton.Location = new Point(poButton.Duel.Location.X + buttonWidth + spacing, poButton.Duel.Location.Y);
                currentPosition.Y += margin;
                duels[0].Add(poButton);

                linesToDraw.Add((new Point(Team1.Right, Team1.Location.Y + buttonHeight / 2), 
                           new Point(Team1.Right + buttonWidth / 2 + margin, Team1.Location.Y + buttonHeight / 2)));
                linesToDraw.Add((new Point(Team1.Right + buttonWidth / 2 + margin, Team1.Location.Y + buttonHeight / 2), 
                           new Point(Team1.Right + buttonWidth / 2 + margin, duelButton.Top)));

                linesToDraw.Add((new Point(Team2.Right, Team2.Location.Y + buttonHeight / 2),
                           new Point(Team2.Right + buttonWidth / 2 + margin, Team2.Location.Y + buttonHeight / 2)));
                linesToDraw.Add((new Point(Team2.Right + buttonWidth / 2 + margin, Team2.Location.Y + buttonHeight / 2),
                           new Point(Team2.Right + buttonWidth / 2 + margin, duelButton.Bottom)));
            }

            for (int round = 1; round < roundCount; round++)
            {
                duels.Add(new List<POButton>());
                for (int i = 0; i < duels[round-1].Count; i+=2)
                {
                    POButton prev1 = duels[round - 1][i];
                    POButton prev2 = duels[round - 1][i + 1];
                    Button duel = new Button
                    {
                        Text = "Duel",
                        Size = new Size(buttonWidth, buttonHeight),
                        Tag = "Duel",
                        Location = new Point(prev1.Winner.Location.X + buttonWidth + margin, 
                        (prev1.Winner.Location.Y + prev2.Winner.Location.Y + buttonHeight)/2 - buttonHeight/2)
                    };
                    Button winner = new Button
                    {
                        Text = "Winner",
                        Size = new Size(buttonWidth, buttonHeight),
                        Tag = "Winner"
                    };
                    this.Controls.Add(duel);
                    this.Controls.Add(winner);
                    winner.Location = new Point(duel.Location.X + buttonWidth + spacing, duel.Location.Y);
                    POButton pOButton = new POButton(prev1.Winner, prev2.Winner, winner, duel);
                    duels[round].Add(pOButton);
                    linesToDraw.Add((new Point(prev1.Winner.Right, prev1.Winner.Location.Y + buttonHeight / 2),
                                new Point(prev1.Winner.Right + buttonWidth / 2 + margin, prev1.Winner.Location.Y + buttonHeight / 2)));
                    linesToDraw.Add((new Point(prev1.Winner.Right + buttonWidth / 2 + margin, prev1.Winner.Location.Y + buttonHeight / 2),
                               new Point(prev1.Winner.Right + buttonWidth / 2 + margin, duel.Top)));

                    linesToDraw.Add((new Point(prev2.Winner.Right, prev2.Winner.Location.Y + buttonHeight / 2),
                               new Point(prev2.Winner.Right + buttonWidth / 2 + margin, prev2.Winner.Location.Y + buttonHeight / 2)));
                    linesToDraw.Add((new Point(prev2.Winner.Right + buttonWidth / 2 + margin, prev2.Winner.Location.Y + buttonHeight / 2),
                               new Point(prev2.Winner.Right + buttonWidth / 2 + margin, duel.Bottom)));
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
    }
}