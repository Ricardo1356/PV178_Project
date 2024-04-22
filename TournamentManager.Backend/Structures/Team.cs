namespace TournamentManager.Backend.Structures
{
    public class Team
    {
        public string Name { get; private set; }
        public string City { get; private set; }
        public List<Player> Players { get; private set; } = new List<Player>();
        
        private Tournament? _currentTournament = null;

        public bool CanBeManaged => this._currentTournament == null;

        public Team(string name, string city, List<Player> players)
        {
            this.Name = name;
            this.City = city;
            this.Players = players;
        }

        public Tournament? GetTournament()
        {
            return this._currentTournament;
        }   
        public void SetTournament(Tournament tournament)
        {
            this._currentTournament = tournament;
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);           
        }

        public void AddPlayers(List<Player> players)
        {
            this.Players.AddRange(players);
        }

        public void RemovePlayer(Player player)
        {
            this.Players.Remove(player);
        }
    }
}
