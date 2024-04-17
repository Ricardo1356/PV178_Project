using System.Runtime.CompilerServices;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Backend
{
    public class BackendMain
    {
        private List<Team> _teams;
        public BackendMain()
        {
            this._teams = DataAccess.LoadSavedTeams();
        }

        public List<Team> GetTeams()
        {
            return this._teams;
        }

        public bool CheckNewTeamName(string teamName)
        {
            return true;
        }

        public Tournament ? CreateNewTournament(TournamentType type, List<Team> teams)
        {
            return new Tournament(type, 6, teams);
        }
    }
}
