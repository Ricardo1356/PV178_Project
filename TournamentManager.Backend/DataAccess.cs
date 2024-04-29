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
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var jsonString = File.ReadAllText("teams.json");
            var teams = new List<Team>();
            try
            {
                teams = JsonSerializer.Deserialize<List<Team>>(jsonString, options);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to load teams: {e.Message}");
            }

            if (teams == null)
            {
                throw new InvalidOperationException("Deserialization resulted in null.");
            }
            

            try
            {
                ValidateTeams(teams);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to load teams: {e.Message}");
                Environment.Exit(1);
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

                if (team.Players == null || !team.Players.Any())
                {
                    throw new InvalidOperationException("Team must have at least one player.");
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
