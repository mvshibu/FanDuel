using DepthChart.Function.Models;

namespace DepthChart.Function
{
    public static class CollectionExtensions
    {
        public static void Initialize(this Dictionary<int, PlayerModel> players, int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                players.Add(i, new PlayerModel(0, ""));
            }
        }

        public static void ToOutPutString(this PlayerModel player)
        {
            Console.WriteLine($"#{player.GetNumber()} - {player.GetName()}");
        }
    }
}