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
                if (teams == null) throw new InvalidOperationException("Deserialization resulted in null.");
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

        
    }
}
