using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Backend.Structures
{
    public class PlayOffTournament : Tournament
    {
        public PlayOffTournament(int teamCount, List<Team> teams, string name) : base(TournamentType.PlayOff, teamCount, teams, name)
        {

        }
    }
}
