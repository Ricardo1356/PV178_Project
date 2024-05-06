using System.Runtime.CompilerServices;

namespace TournamentManager.Backend.Structures
{
    public class Tournament
    {
        public TournamentType Type { get; private set; }
        public int TeamCount { get; private set; }
        public string Name { get; set; } = "";
        public List<Team> ParticipatingTeams { get; private set; }
        public Tournament(TournamentType type, int teamCount, List<Team> teams, string name)
        {
            this.Type = type;
            this.TeamCount = teamCount;
            this.ParticipatingTeams = teams;
            this.Name = name;
        }

        public void ShuffleTeams()
        {
            Random random = new Random();
            this.ParticipatingTeams = this.ParticipatingTeams.OrderBy(item => random.Next()).ToList();
        }
    }
}
