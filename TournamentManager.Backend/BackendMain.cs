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

        public Team GetExistingTeam(string teamName, string city)
        {
            foreach(var team in this._teams)
            {
                if (team.Name == teamName && team.City == city) return team;
            }
            return new Team("", "", []); // unreachable code
        }

        public Team GetTeamByJoined(string joinedCityName)
        {
            foreach (var team in this._teams)
            {
                if (team.City + " " + team.Name == joinedCityName) return team;
            }
            return new Team("", "", []); // unreachable code
        }

        public bool RemoveTeam(Team team)
        {
            if (!team.CanBeManaged) return false;
            this._teams.Remove(team);
            return true;
        }

        public bool RegisterNewTeam(string teamName = "", string teamCity = "", Team? team = null)
        {
            if (teamName == "" && teamCity == "" && team == null) { return false; }
            if (team != null)
            {
                if (CheckNewTeamName(team.Name)) return false;
                this._teams.Add(team);
                return true;
            }
            if (CheckNewTeamName(teamName)) return false;        
            Team newTeam = new Team(teamName, teamCity, []);

            this._teams.Add(newTeam);
            return true;
        }

        public Tournament CreateNewTournament(TournamentType type, List<Team> teams)
        {
            if (type == TournamentType.FFA) return new FFATournament(teams.Count, teams);
            else return new PlayOffTournament(teams.Count, teams);
        }

        public void EndProgram()
        {
            DataAccess.SaveTeams(this._teams);
            Environment.Exit(0);
        }
    }
}
