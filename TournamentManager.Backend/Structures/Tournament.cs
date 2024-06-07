using System.Runtime.CompilerServices;
using TournamentManager.Backend.DTOs;

namespace TournamentManager.Backend.Structures
{
    public class Tournament
    {
        public TournamentType Type { get; private set; }
        public int TeamCount { get; private set; }
        public string Name { get; set; } = "";
        public List<Team> ParticipatingTeams { get; private set; }
        public TournamentDto TournamentDto { get; set; }
        public bool Finished { get; set; } = false; 
        public bool IsOpenned { get; set; } = false;
        public Tournament(TournamentType type, int teamCount, List<Team> teams, string name, TournamentDto tournamentDto)
        {
            this.TournamentDto = tournamentDto;
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
