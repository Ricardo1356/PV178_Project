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
        public TeamButton(Button Button, Team? Team = null) : base(Button)
        {
            this.Team = Team;
        }
    }
}
