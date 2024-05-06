using TournamentManager.Backend.Structures;

namespace TournamentManager.Backend.DTOs
{
    public struct TeamDataDto
    {
        public required string Name { get; set; }
        public required string City { get; set; }
        public required Colors Colors { get; set; }
        public required string Abbrevation { get; set; }
        public List<Player> Players { get; set; }
    }
}