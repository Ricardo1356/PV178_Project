using TournamentManager.Backend.DTOs;

namespace TournamentManager.Backend.Structures
{
    public class PlayOffTournament : Tournament
    {
        public PlayOffTournament(int teamCount, List<Team> teams, string name) : base(TournamentType.PlayOff, teamCount, teams, name, new TournamentDto())
        {

        }

        public PlayOffTournament(int teamCount, List<Team> teams, string name, TournamentDto tournamentDto) : base(TournamentType.PlayOff, teamCount, teams, name, tournamentDto)
        {

        }
    }
}
