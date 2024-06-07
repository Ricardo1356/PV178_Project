using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Backend.DTOs
{
    public class TournamentDto
    {
        public List<string> TeamNames { get; set; }
        public List<List<DuelDto>> Duels { get; set; }
        public string Name { get; set; }
        public bool IsFinished { get; set; }
        public string Type { get; set; }
    }
}
