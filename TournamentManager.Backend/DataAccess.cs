using System.Text.Json;
using System.Xml.Serialization;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Backend
{
    public static class DataAccess
    {
        public static void SaveTeams(List<Team> Teams)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            File.WriteAllText("teams.json", JsonSerializer.Serialize(Teams, options));
        }

        public static List<Team> LoadSavedTeams()
        {
            if (!File.Exists("teams.json"))
            {
                return new List<Team>();
            }

            List<Team> teams;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            try
            {
                var jsonString = File.ReadAllText("teams.json");
                teams = JsonSerializer.Deserialize<List<Team>>(jsonString, options);
                if (teams == null)
                {
                    throw new InvalidOperationException("Deserialization resulted in null. The file might be empty or corrupted.");
                }
            }
            catch (JsonException je)
            {
                throw new InvalidOperationException($"Failed to deserialize teams: {je.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while reading the file: {e.Message}");
            }

            try
            {
                ValidateTeams(teams);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Validation failed for teams: {e.Message}");
            }

            foreach (var team in teams)
            {
                team.ConvertArgbToColors();
            }

            return teams;
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
