using System.ComponentModel;
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
            return new Team("", "", "", [], new Colors()); // unreachable code
        }

        public Team GetTeamByJoined(string joinedCityName)
        {
            foreach (var team in this._teams)
            {
                if (team.City + " " + team.Name == joinedCityName) return team;
            }
            return new Team("", "", "", [], new Colors()); // unreachable code
        }

        public bool RemoveTeam(Team team)
        {
            if (!team.CanBeManaged) return false;
            this._teams.Remove(team);
            return true;
        }

        public bool RegisterNewTeam(string teamName = "", string teamCity = "", Team? team = null, Colors? colors = default, string abbrevation="")
        {
            if (teamName == "" && teamCity == "" && team == null) { return false; }
            if (team != null)
            {
                if (CheckNewTeamName(team.Name)) return false;
                this._teams.Add(team);
                return true;
            }
            if (CheckNewTeamName(teamName)) return false;        
            Team newTeam = new Team(teamName, teamCity, abbrevation, [], colors!);

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

        private string GeneratePlayerName()
        {
            return NameGenerator.GenerateName();
        }

        public PlayerStatsDto GeneratePlayerStats()
        {
            Random random = new Random();

            return new PlayerStatsDto
            {
                Name = GeneratePlayerName(), 
                Age = random.Next(18, 40).ToString(),
                Height = random.Next(160, 210).ToString(),
                Weight = random.Next(50, 150).ToString(),
                Position = random.Next(0, 4)
            };
        }
        public int AddPlayerToTeam(Team team, PlayerStatsDto playerStats)
        {
            if (!team.CanBeManaged) return 1;
            var validation = ValidatePlayerStats(playerStats);
            if (validation != 0) return validation;
            team.AddPlayer(new Player(playerStats.Name, int.Parse(playerStats.Age), int.Parse(playerStats.Height), int.Parse(playerStats.Weight), ((PlayerPosition)playerStats.Position).ToString()));
            return 0;
        }

        private int ValidatePlayerStats(PlayerStatsDto playerStats)
        {
            if (string.IsNullOrWhiteSpace(playerStats.Name)) return 101;
            if (string.IsNullOrWhiteSpace(playerStats.Age)) return 102;
            if (string.IsNullOrWhiteSpace(playerStats.Height)) return 103;
            if (string.IsNullOrWhiteSpace(playerStats.Weight)) return 104;
            if (playerStats.Position < 0 || playerStats.Position > 4) return 800;

            bool success = int.TryParse(playerStats.Age, out int age);
            if (!success) return 201;

            success = int.TryParse(playerStats.Height, out int height);
            if (!success) return 202;

            success = int.TryParse(playerStats.Weight, out int weight);
            if (!success) return 203;

            if (age < 18 || age > 40) return 301;
            if (height < 160 || height > 210) return 302;
            if (weight < 50 || weight > 150) return 303;

            return 0;
        }

        public string ResolveErrorCode(int code)
        {
            return "";
        }
    }
}
