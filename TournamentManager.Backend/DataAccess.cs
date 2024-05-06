using System.Text.Json;
using System.Xml.Serialization;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Backend
{
    public static class DataAccess
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
                if (string.IsNullOrWhiteSpace(team.Name) || string.IsNullOrWhiteSpace(team.City))
                {
                    throw new InvalidOperationException("Team data is invalid.");
                }

                if (string.IsNullOrEmpty(team.Abbreviation) || team.Abbreviation.Length != 3)
                {
                    throw new InvalidOperationException("Team abbreviation must be exactly 3 characters long.");
                }

                if (team.Abbreviation != team.Abbreviation.ToUpper())
                {
                    throw new InvalidOperationException("Team abbreviation must be uppercase.");
                }

                foreach (var player in team.Players)
                {
                    ValidatePlayer(player);
                }
            }
        }

        private static void ValidatePlayer(Player player)
        {
            if (string.IsNullOrWhiteSpace(player.Name))
            {
                throw new InvalidOperationException("Player name cannot be empty.");
            }

            if (player.Age <= 0)
            {
                throw new InvalidOperationException("Player age must be greater than zero.");
            }

            if (player.Height <= 0)
            {
                throw new InvalidOperationException("Player height must be greater than zero.");
            }

            if (player.Weight <= 0)
            {
                throw new InvalidOperationException("Player weight must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(player.Position))
            {
                throw new InvalidOperationException("Player position cannot be empty.");
            }
        }
    }
}
