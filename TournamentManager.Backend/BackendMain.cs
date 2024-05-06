using System.ComponentModel;
using TournamentManager.Backend.DTOs;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Backend
{
    public class BackendMain
    {
        private List<Team> _teams;
        private DataValidationService _dataValidator;
        public string LoadStatus { get; set; } = "";
        public BackendMain()
        {
            this._dataValidator = new DataValidationService();
            this._teams = DataAccess.LoadSavedTeams(out string status);
            LoadStatus = status;
        }

        public List<Team> GetTeams()
        {
            return this._teams;
        }

        public void CheckNewTeamName(string teamName, string allowed = "")
        {
            foreach(var team in this._teams)
            {
                if (team.Name == teamName && team.Name != allowed) throw new InvalidEnumArgumentException($"Team {teamName} already exists.");
            }
        }

        public Team GetExistingTeam(string teamName, string city)
        {
            foreach(var team in this._teams)
            {
                if (team.Name == teamName && team.City == city) return team;
            }
            return new Team("", "", "", [], new Colors()); // unreachable code
        }

        public Team GetTeamByName(string teamName)
        {
            foreach (var team in this._teams)
            {
                if (team.Name == teamName) return team;
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

        public void RegisterNewTeam(TeamDataDto? teamDataDto=null, Team? team=null)
        {
            if (team != null)
            {
                _dataValidator.ValidateTeamData(team);
                this.CheckNewTeamName(team.Name);
                this._teams.Add(team);
                SaveTeams();
                return;
            }
            if (teamDataDto != null)
            {
                var teamD = (TeamDataDto)teamDataDto;
                _dataValidator.ValidateTeamDataDto(teamD);
                this.CheckNewTeamName(teamD.Name);
                Team newTeam = new Team(teamD.Name, teamD.City, teamD.Abbrevation, [], teamD.Colors!);
                this._teams.Add(newTeam);
                SaveTeams();
            }
        }

        public Tournament CreateNewTournament(TournamentType type, List<Team> teams, string name)
        {
            if (type == TournamentType.FFA) return new FFATournament(teams.Count, teams, name);
            else return new PlayOffTournament(teams.Count, teams, name);

        }

        public async Task SaveTeams()
        {
            DataAccess.SaveTeams(this._teams);
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

        public PlayerDataDto GeneratePlayerStats()
        {
            Random random = new Random();

            return new PlayerDataDto
            {
                Name = GeneratePlayerName(), 
                Age = random.Next(18, 40).ToString(),
                Height = random.Next(160, 210).ToString(),
                Weight = random.Next(50, 150).ToString(),
                Position = random.Next(0, 4)
            };
        }

        public void UpdateTeamInfo(TeamDataDto teamDataDto, Team team)
        {
            _dataValidator.ValidateTeamDataDto(teamDataDto);
            CheckNewTeamName(teamDataDto.Name, allowed: team.Name);
            team.Name = teamDataDto.Name;
            team.City = teamDataDto.City;
            team.Abbreviation = teamDataDto.Abbrevation;
            team.Colors = teamDataDto.Colors;
            team.ConvertArgbToColors();
            SaveTeams();
        }

        public void AddPlayerToTeam(Team team, Player player)
        {
            if (!team.CanBeManaged) throw new InvalidOperationException("Team cannot be managed.");
            _dataValidator.ValidatePlayerdata(player);
            team.AddPlayer(player);
            SaveTeams();
        }
    }
}
