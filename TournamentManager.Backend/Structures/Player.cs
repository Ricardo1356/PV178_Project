namespace TournamentManager.Backend.Structures
{
    public class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Position { get; private set; }
        
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
