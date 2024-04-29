namespace TournamentManager.Backend.Structures
{
    public class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Position { get; set; }
        
        public Player(string name, int age, int height, int weight, string position)
        {
            this.Name = name;
            this.Age = age;
            this.Height = height;
            this.Weight = weight;
            this.Position = position;
        }
    }
}
