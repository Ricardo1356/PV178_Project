using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Backend.Structures
{
    public class FFATournament : Tournament
    {
        public FFATournament(int teamCount, List<Team> teams, string name) : base(TournamentType.FFA, teamCount, teams, name)
        {

        }
    }
}
