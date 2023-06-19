using Microsoft.Extensions.Logging;

namespace DepthChart.Function.Models
{
    public class NFLTeamModel
    {
        private readonly string Name;
        private readonly int Depth_Limit;

        private readonly List<ChartModel> Charts;
        private readonly ILogger<NFLTeamModel> logger;

        public NFLTeamModel(string name, int depth_limit, ILogger<NFLTeamModel> logger)
        {
            this.Name = name;
            this.Depth_Limit = depth_limit;
            this.logger = logger;
            this.Charts = new List<ChartModel>();
        }

        public bool AddPlayerToDepthChart(string position, PlayerModel player, int position_depth)
        {
            bool playerAdded = false;
            if (this.Charts.Where(p => p.GetPostion() == position.ToUpper()).Count() == 0)
            {
                var chartPosition = new ChartModel(position, this.Depth_Limit);
                if (chartPosition.CanAddPlayer(position_depth))
                {
                    chartPosition.AddPlayer(position_depth, player);
                }
                return playerAdded;
            }
            var pos = this.Charts.Where(p => p.GetPostion() == position.ToUpper()).First();
            if (pos.CanAddPlayer(position_depth))
            {
                playerAdded = pos.AddPlayer(position_depth, player);
                return playerAdded;
            }
            logger.LogWarning("Add Player Failed.");
            return playerAdded;
        }

        public PlayerModel RemovePlayerFromDepthChart(string position, PlayerModel player)
        {
            PlayerModel removedPlayer = new PlayerModel(0, "");
            if (IsValidPosition(position))
            {
                var pos = this.Charts.Where(q => q.GetPostion() == position.ToUpper()).First();
                var pl = pos.RemovePlayer(player);
                removedPlayer = new PlayerModel(pl.GetNumber(), pl.GetName());
            }
            return removedPlayer;
        }
        public List<PlayerModel> GetBackups(string position, PlayerModel player)
        {
            List<PlayerModel> backupPlayers = new List<PlayerModel>();
            if (IsValidPosition(position))
            {
                var pos = this.Charts.Where(q => q.GetPostion() == position.ToUpper()).First();
                backupPlayers.AddRange(pos.GetBackupPlayers(player));
            }
            return backupPlayers;
        }
        public List<ChartModel> GetFullDepthChart() => this.Charts;


        private bool IsValidPosition(string position) => this.Charts.Where(p => p.GetPostion() == position.ToUpper()).Any();

    }
}