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
            if(!File.Exists("teams.json"))
            {
                return new List<Team>();
            }
            var teams = JsonSerializer.Deserialize<List<Team>>(File.ReadAllText("teams.json"));
            try
            {
                ValidateTeams(teams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
            return teams!;
        }

        private static void ValidateTeams(List<Team>? Teams)
        {
            if (Teams != null)
            {
                foreach (var team in Teams)
                {
                    if (string.IsNullOrWhiteSpace(team.Name) || string.IsNullOrWhiteSpace(team.City))
                    {
                        throw new InvalidOperationException("Team data is invalid.");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Deserialization resulted in null.");
            }

        }
    }
}
