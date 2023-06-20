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

        public string AddPlayerToDepthChart(string position, PlayerModel player, int position_depth)
        {
            var added = this.nflTeamModel.AddPlayerToDepthChart(position, player, position_depth);
            if (added)
                return "Player Added";
            else
                return "Failed to add Player!";
        }

        public List<string> GetBackups(string position, PlayerModel player)
        {
            List<string> outputColl = new List<string>();
            var players = this.nflTeamModel.GetBackups(position, player);
            if (players.Count == 0)
            {
                outputColl.Add(OutputExtensions.ToEmptyData());
            }
            else
            {
                outputColl.AddRange(players.Select(p => p.ToOutPutString()));
            }
            return outputColl;
        }

        public List<string> GetFullDepthChart()
        {
            List<string> outputColl = new List<string>();
            foreach (var chart in this.nflTeamModel.GetFullDepthChart())
            {
                if (chart.GetPlayers().Count > 0)
                {
                    outputColl.Add(chart.ToOutPutString());
                }
                else
                {
                    outputColl.Add($"{chart.GetPostion()} - " + OutputExtensions.ToEmptyData());
                }
            }

            return outputColl;
        }

        public string RemovePlayerFromDepthChart(string position, PlayerModel player)
        {
            var removedPlayer = this.nflTeamModel.RemovePlayerFromDepthChart(position, player);
            if (!string.IsNullOrEmpty(removedPlayer.GetName()))
            {
                return removedPlayer.ToOutPutString();
            }
            else
            {
                return OutputExtensions.ToEmptyData();
            }
        }
    }
}