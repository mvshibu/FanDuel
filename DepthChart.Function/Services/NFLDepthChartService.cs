using DepthChart.Function.Models;

namespace DepthChart.Function.Services
{

    public class NFLDepthChartService : IDepthChartService
    {
        public string Sport { get; set; } = "NFL";

        private readonly INFLTeamModel nflTeamModel;
        public NFLDepthChartService(INFLTeamModel nflTeamModel)
        {
            this.nflTeamModel = nflTeamModel;
        }

        public void AddPlayerToDepthChart(string position, PlayerModel player, int position_depth)
        {
            var added = this.nflTeamModel.AddPlayerToDepthChart(position, player, position_depth);
            if (added)
                Console.WriteLine("Player added successfully");
            else
                Console.WriteLine("Failed to add Player!");
        }

        public void GetBackups(string position, PlayerModel player)
        {
            var players = this.nflTeamModel.GetBackups(position, player);
            if (players.Count == 0)
            {
                Console.WriteLine("<NO LIST>");
            }
            else
            {
                foreach (var pl in players)
                {
                    pl.ToOutPutString();
                }
            }
        }

        public void GetFullDepthChart()
        {
            throw new NotImplementedException();
        }

        public void RemovePlayerFromDepthChart(string position, PlayerModel player)
        {
            var removedPlayer = this.nflTeamModel.RemovePlayerFromDepthChart(position, player);
            if (!string.IsNullOrEmpty(removedPlayer.GetName()))
            {
                Console.WriteLine($"#{removedPlayer.GetNumber()} - {removedPlayer.GetName()}");
            }
            else
            {
                Console.WriteLine("<NO LIST>");
            }
        }
    }
}