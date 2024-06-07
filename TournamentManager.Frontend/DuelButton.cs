using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public class DuelButton : POButton
    {
        public Team? Team1 { get; set; }
        public Team? Team2 { get; set; }
        public Team? Winner { get; set; } = null;
        public TeamButton WinnerPO { get; set; }
        public bool IsFinished { get; set; } = false;
        public int Team1Score { get; set; } = 0;
        public int Team2Score { get; set; } = 0;
        public DuelButton(MulticolorButton Button, TeamButton winnerPO, Team? team1 = null, Team? team2 = null) : base(Button)
        {
            Team1 = team1;
            Team2 = team2;   
            WinnerPO = winnerPO;
        }

        public void ShadeButton()
        {
            base.Button.ShadeButton();
        }
    }
}
