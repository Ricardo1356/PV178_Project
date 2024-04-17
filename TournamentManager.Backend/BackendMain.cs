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
            foreach(var team in this._teams)
            {
                if (team.Name == teamName) return true;
            }
            return false;
        }

        public bool RegisterNewTeam(string teamName, string teamCity)
        {
            if (CheckNewTeamName(teamName)) return false;        
            Team newTeam = new Team(teamName, teamCity);

            this._teams.Add(newTeam);
            return true;
        }

        public Tournament? CreateNewTournament(TournamentType type, List<Team> teams)
        {
            return new Tournament(type, 6, teams);
        }

        public void EndProgram()
        {
            DataAccess.SaveTeams(this._teams);
            Environment.Exit(0);
        }
    }
}
