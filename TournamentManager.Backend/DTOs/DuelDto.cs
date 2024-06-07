using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Backend.DTOs
{
    public class DuelDto
    {
        public string? Team1 { get; set; }
        public string? Team2 { get; set; }
        public bool IsFinished { get; set; }
        public string? Winner { get; set; }
        public string? Loser { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
    }
}
