using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Frontend
{
    public class POButton
    {
        public MulticolorButton Button { get; set; }

        public POButton(MulticolorButton Button)
        {
            this.Button = Button;
        }
        protected void UpdateColorsByTeam(Backend.Structures.Team team)
        {
            Button.UpdateColorsByTeam(team);
        }
    }
}
