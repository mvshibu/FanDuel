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


    }
    public static class OutputExtensions
    {
        public static string ToOutPutString(this PlayerModel player)
        {
            return $"#{player.GetNumber()} - {player.GetName()}";
        }
        public static string ToFullOutPutString(this PlayerModel player)
        {
            return $"(#{player.GetNumber()}, {player.GetName()})";
        }
        public static string ToOutPutString(this ChartModel chart)
        {
            return $"{chart.GetPostion()} - " + string.Join(",", chart.GetPlayers().Select(p => p.ToFullOutPutString()));
        }
        public static string ToEmptyData()
        {
            return "<NO LIST>";
        }
    }
}