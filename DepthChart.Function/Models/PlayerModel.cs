namespace DepthChart.Function.Models
{
    public class PlayerModel
    {
        private readonly int Number;
        private readonly string Name;

        public PlayerModel(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }
        public int GetNumber() => this.Number;
        public string GetName() => this.Name;
        public bool IsEmpty() => string.IsNullOrEmpty(this.Name);
    }
}