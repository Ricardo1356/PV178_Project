namespace TournamentManager.Backend.Structures
{
    public class Tournament
    {
        public TournamentType Type { get; private set; }
        public int TeamCount { get; private set; }
        public List<Team> Teams { get; private set; }
        public Tournament(TournamentType type, int teamCount, List<Team> teams)
        {
            this.Type = type;
            this.TeamCount = teamCount;
            this.Teams = teams;
        }
    }
}
