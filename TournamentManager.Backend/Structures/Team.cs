using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Backend.Structures
{
    public class Team
    {
        public string Name {  get; private set; }
        public string City { get; private set; }
        
        public Team(string name, string city)
        {
            this.Name = name;
            this.City = city;
        }
    }
}
