using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Frontend
{
    class POButton
    {
        public Button Team1 { get; set; }
        public Button Team2 { get; set; }
        public Button Winner { get; set; }
        public Button Duel { get; set; }

        public POButton(Button Team1, Button Team2, Button Winner, Button Duel)
        {
            this.Duel = Duel;
            this.Team1 = Team1;
            this.Team2 = Team2;
            this.Winner = Winner;
        }
    }
}
