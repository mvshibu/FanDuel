using DepthChart.Function.Models;

namespace DepthChart.Function.InputParser
{
    public class AddDataModel
    {
        public string position { get; set; }
        public PlayerInputModel player { get; set; }
        public int depth { get; set; } = -1;
    }

    public class PlayerInputModel
    {
        public string name { get; set; }
        public int number { get; set; }
    }
}