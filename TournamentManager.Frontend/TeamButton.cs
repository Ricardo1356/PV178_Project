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
        public Team? AssignedTeam { get; set; }
        public TeamButton(Button Button, Team? AssignedTeam = null) : base(Button)
        {
            this.AssignedTeam = AssignedTeam;
        }
    }
}
