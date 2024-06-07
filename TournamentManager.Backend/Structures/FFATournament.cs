using TournamentManager.Backend.DTOs;

namespace TournamentManager.Backend.Structures
{
    public class FFATournament : Tournament
    {
        public FFATournament(int teamCount, List<Team> teams, string name) : base(TournamentType.FFA, teamCount, teams, name, new TournamentDto())
        {

        }

        public FFATournament(int teamCount, List<Team> teams, string name, TournamentDto tournamentDto) : base(TournamentType.FFA, teamCount, teams, name, tournamentDto)
        {

        }
    }
}
