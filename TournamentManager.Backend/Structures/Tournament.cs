using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Backend.Structures
{
    public class Tournament
    {
        public TournamentType Type { get; private set; }
        public int TeamCount { get; private set; }
        public List<Team> Teams { get; private set; }
        public int ID { get; private set; }
        public Tournament(TournamentType type, int teamCount, List<Team> teams)
        {
            Random r = new Random();
            this.ID = r.Next(1, 99999);
            this.Type = type;
            this.TeamCount = teamCount;
            this.Teams = teams;
        }
    }
}
