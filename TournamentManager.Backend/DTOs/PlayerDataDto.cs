

namespace TournamentManager.Backend.DTOs
{
    public struct PlayerDataDto
    {
        public required string Name { get; set; }
        public required string Age { get; set; }
        public required string Height { get; set; }
        public required string Weight { get; set; }
        public required int Position { get; set; }
    }
}
