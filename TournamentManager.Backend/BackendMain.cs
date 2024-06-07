using System.ComponentModel;
using System.Text.Json;
using TournamentManager.Backend.DTOs;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Backend
{
    public class BackendMain
    {
        private List<Team> _teams;
        public List<Tournament> _tournaments;
        public List<TournamentDto> _tournamentsDto;
        public string TeamLoadStatus { get; set; }
        public string TournamentLoadStatus { get; set; }
        public BackendMain()
        {
            this._teams = FileWriter.LoadSavedTeams(out string teamStatus);
            TeamLoadStatus = teamStatus;

            this._tournamentsDto = FileWriter.LoadSavedTournaments(out string tournamentStatus);
            TournamentLoadStatus = tournamentStatus;

            this._tournaments = ReconstructTournaments();
        }

        public List<Team> GetTeams()
        {
            return this._teams;
        }

        private List<Tournament> ReconstructTournaments()
        {
            if (this.TournamentLoadStatus != "") return new List<Tournament>();
            List<Tournament> tournaments = new List<Tournament>();
            foreach (var tournamentDto in this._tournamentsDto)
            {
                Tournament tournament;
                if (tournamentDto.Type == TournamentType.FFA.ToString())
                {
                    tournament = new FFATournament(tournamentDto.TeamNames.Count(), GetMultipleTeams(tournamentDto.TeamNames), tournamentDto.Name, tournamentDto);
                }
                else
                {
                    tournament = new PlayOffTournament(tournamentDto.TeamNames.Count(), GetMultipleTeams(tournamentDto.TeamNames), tournamentDto.Name, tournamentDto);
                }
                foreach (Team team in tournament.ParticipatingTeams)
                {
                    team.SetTournament(tournament);
                }
                tournament.Finished = tournamentDto.IsFinished;
                tournaments.Add(tournament);
            }

            return tournaments;
        }

        public bool TournamentNameExists(string name)
        {
            foreach (var tournament in this._tournaments)
            {
                if (tournament.Name == name) return true;
            }
            return false;
        }

        public List<TournamentDto> GetTournaments()
        {
            return this._tournamentsDto;
        }

        public void ReleaseTournament(string name)
        {
            foreach (var tournament in this._tournaments)
            {
                if (tournament.Name == name)
                {
                    tournament.IsOpenned = false;
                    return;
                }
            }
        }

        public Tournament GetTournament(string name)
        {
            foreach (var tournament in this._tournaments)
            {
                if (tournament.Name == name) return tournament;
            }
            return null!;
        }

        public void AddTournament(Tournament tournament)
        {
            this._tournaments.Add(tournament);
            this._tournamentsDto.Add(tournament.TournamentDto);
        }

        public List<string> GetAbbreviations(List<string> teamNames)
        {
            List<string> abbreviations = new List<string>();
            foreach (var teamName in teamNames)
            {
                abbreviations.Add(GetTeamByName(teamName).Abbreviation);
            }
            return abbreviations;
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

        public void FinishTournament(string name)
        {
            foreach (var tournament in this._tournaments)
            {
                if (tournament.Name == name)
                {
                    tournament.Finished = true;
                    return;
                }
            }
        }

        public void UpdateTournamentDto(Tournament tournament, TournamentDto tournamentDto)
        {
            GetTournament(tournament.Name).TournamentDto = tournamentDto;
            SaveTournaments();
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
            Tournament tournament;
            if (type == TournamentType.FFA) 
                tournament =  new FFATournament(teams.Count, teams, name);
            else
                tournament = new PlayOffTournament(teams.Count, teams, name);

            this.AddTournament(tournament);
            return tournament;
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

        public TournamentDto LoadTournament(string name)
        {
            return FileWriter.LoadPOTournament(name);
        }
        public async Task SaveTournaments()
        {
            this._tournamentsDto = new List<TournamentDto>();
            foreach (var tournament in this._tournaments)
            {
                this._tournamentsDto.Add(tournament.TournamentDto);
            }
            FileWriter.SaveTournaments(this._tournamentsDto);
        }

        public List<Team> GetMultipleTeams(List<string> teamNames)
        {
            List<Team> teams = new List<Team>();
            foreach (var teamName in teamNames)
            {
                teams.Add(GetTeamByName(teamName));
            }
            return teams;
        }
    }
}
