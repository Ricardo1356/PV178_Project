using System.ComponentModel;
using TournamentManager.Backend.DTOs;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Backend
{
    public class BackendMain
    {
        private List<Team> _teams;
        public string LoadStatus { get; set; }
        public BackendMain()
        {
            this._teams = FileWriter.LoadSavedTeams(out string status);
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

        public Team GetTeamByName(string teamName)
        {
            foreach (var team in this._teams)
            {
                if (team.Name == teamName) return team;
            }
            return null!;
        }

        public Team GetTeamByNameAndCity(string nameAndCity)
        {
            foreach (var team in this._teams)
            {
                if (team.City + " " + team.Name == nameAndCity) return team;
            }
            return null!;
        }

        public bool RemoveTeam(Team team)
        {
            if (!team.CanBeManaged) return false;
            this._teams.Remove(team);
            SaveTeams();
            return true;
        }

        public void RegisterTeam(TeamDataDto? teamDataDto=null, Team? team=null)
        {
            if (team != null)
            {
                DataValidationService.ValidateTeamData(team);
                this.CheckNewTeamName(team.Name);
                this._teams.Add(team);
                SaveTeams();
                return;
            }
            if (teamDataDto != null)
            {
                var teamD = (TeamDataDto)teamDataDto;
                DataValidationService.ValidateTeamDataDto(teamD);
                this.CheckNewTeamName(teamD.Name);
                Team newTeam = new Team(teamD.Name, teamD.City, teamD.Abbrevation, [], teamD.Colors!);
                this._teams.Add(newTeam);
                SaveTeams();
            }
        }

        public Tournament CreateNewTournament(TournamentType type, List<Team> teams, string name)
        {
            if (type == TournamentType.FFA) 
                return new FFATournament(teams.Count, teams, name);

            return new PlayOffTournament(teams.Count, teams, name);

        }

        public async Task SaveTeams()
        {
            FileWriter.SaveTeams(this._teams);
        }      

        public void EndProgram()
        {
            FileWriter.SaveTeams(this._teams);
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
            DataValidationService.ValidateTeamDataDto(teamDataDto);
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
            DataValidationService.ValidatePlayerdata(player);
            team.AddPlayer(player);
            SaveTeams();
        }
    }
}
