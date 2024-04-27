using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public class TeamButton : POButton
    {
        public DuelButton? NextDuel { get; set; } = null;
        public Team? Team { get; set; }
        public TeamButton(MulticolorButton Button, Team? Team = null) : base(Button)
        {
            this.Team = Team;
        }

        public void FightLost()
        {
            base.Button.ShadeButton();
        }

        public void SetWinner(Team winner)
        {
            this.Team = winner;
            base.Button.Text = winner.Name;
            base.Button.UpdateColorsByTeam(winner);
        }
    }
}
