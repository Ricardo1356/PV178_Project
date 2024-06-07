using System.Text.Json;
using System.Xml.Serialization;
using TournamentManager.Backend.DTOs;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Backend
{
    public static class FileWriter
    {
        public static void SaveTeams(List<Team> teams)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText("teams.json", JsonSerializer.Serialize(teams, options));
            }
            catch (Exception e)
            {
                throw new Exception("Failed to save teams: " + e.Message);
            }
        }

        public static List<Team> LoadSavedTeams(out string loadStatus)
        {
            loadStatus = "";
            if (!File.Exists("teams.json"))
            {
                return new List<Team>();
            }

            try
            {
                var jsonString = File.ReadAllText("teams.json");
                var teams = JsonSerializer.Deserialize<List<Team>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (teams == null)
                {
                    loadStatus = "Deserialization resulted in null.";
                    return new List<Team>();
                }
                    
                ValidateTeams(teams);
                foreach (var team in teams)
                    team.ConvertArgbToColors();
                return teams;
            }
            catch (Exception e)
            {
                loadStatus = "Failed to load teams: " + e.Message;
                return new List<Team>();
            }
        }

        private static void ValidateTeams(List<Team> teams)
        {
            foreach (var team in teams)
            {
                TeamDataDto teamDataDto = new TeamDataDto
                {
                    Name = team.Name,
                    City = team.City,
                    Abbrevation = team.Abbreviation,
                    Colors = team.Colors,
                    Players = team.Players
                };
                DataValidationService.ValidateTeamDataDto(teamDataDto);
            }
        }

        public static TournamentDto LoadPOTournament(string tournamentName)
        {
            string filePath = $"{tournamentName}.json";

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Tournament file not found");
            }

            var jsonString = File.ReadAllText(filePath);
            var tournamentDto = JsonSerializer.Deserialize<TournamentDto>(jsonString);

            if (tournamentDto == null)
            {
                throw new InvalidOperationException("Failed to deserialize tournament data");
            }

            return tournamentDto;
        }

        public static void SavePOTournament(TournamentDto tournamentDto)
        {
            string filePath = $"{tournamentDto.Name}.json";

            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(filePath, JsonSerializer.Serialize(tournamentDto, options));
            }
            catch (Exception e)
            {
                throw new Exception("Failed to save tournament: " + e.Message);
            }
        }
        
        public static List<TournamentDto> LoadSavedTournaments(out string loadStatus)
        {
            loadStatus = "";
            string filePath = "tournaments.json";
            if (!File.Exists(filePath))
            {
                return new List<TournamentDto>();
            }

            try
            {
                var jsonString = File.ReadAllText(filePath);
                var tournaments = JsonSerializer.Deserialize<List<TournamentDto>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (tournaments == null)
                {
                    loadStatus = "Deserialization resulted in null.";
                    return new List<TournamentDto>();
                }
                return tournaments;
            }
            catch (Exception e)
            {
                loadStatus = "Failed to load tournaments: " + e.Message;
                return new List<TournamentDto>();
            }
        }

        public static void SaveTournaments(List<TournamentDto> tournaments)
        {
            string filePath = "tournaments.json";
            
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(filePath, JsonSerializer.Serialize(tournaments, options));
            }
            catch (Exception e)
            {
                throw new Exception("Failed to save tournaments: " + e.Message);
            }
        }
    }
}
