using System.Drawing;
using System.Text.Json.Serialization;

namespace TournamentManager.Backend.Structures
{
    public class Team
    {
        public string Name { get; set; } = "";
        public string City { get; set; } = "";
        public Colors Colors { get; set; } = new Colors();
        public string Abbreviation { get; set; } = "TBD";
        public List<Player> Players { get; set; } = new List<Player>();

        private Color _backGroundColor = Color.SkyBlue; 
        private Color _topColor = Color.SkyBlue;
        private Color _bottomColor = Color.SkyBlue;

        private Tournament? _currentTournament = null;
        [JsonIgnore]
        public bool CanBeManaged => this._currentTournament == null;

        public Team()
        {
        }
        
        public Team(string name, string city, string abbrevation, List<Player> players, Colors colors)
        {
            this.Colors = colors;
            this.Name = name;
            this.Abbreviation = abbrevation;
            this.City = city;
            this.Players = players;
            ConvertArgbToColors();
        }

        public void ConvertArgbToColors()
        {
            if (Colors != null)
            {
                this._backGroundColor = ArgbArrayToColor(Colors.BackGroundColor);
                this._topColor = ArgbArrayToColor(Colors.TopColor);
                this._bottomColor = ArgbArrayToColor(Colors.BottomColor);
            }
        }

        public Color GetBackColor()
        {
            return this._backGroundColor;
        }

        public Color GetTopColor()
        {
            return this._topColor;
        }
        public Color GetBottomColor()
        {
            return this._bottomColor;
        }

        private Color ArgbArrayToColor(int[] argb)
        {
            return Color.FromArgb(argb[0] == 255 ? argb[0] : 100, argb[1], argb[2], argb[3]);
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
