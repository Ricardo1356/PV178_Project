using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Backend.Structures
{
    public struct PlayerStatsDto
    {
        public required string Name { get; set; }
        public required string Age { get; set; }
        public required string Height { get; set; }
        public required string Weight { get; set; }
        public required int Position { get; set; }
    }
}
