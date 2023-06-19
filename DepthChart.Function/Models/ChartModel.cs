namespace DepthChart.Function.Models
{

    public class ChartModel
    {
        private readonly string Postion;
        private readonly Dictionary<int, PlayerModel> Players;

        public ChartModel(string position, int depth_limit)
        {
            this.Postion = position.ToUpper();
            this.Players = new Dictionary<int, PlayerModel>(depth_limit);
            this.Players.Initialize(depth_limit);
        }

        public string GetPostion() => this.Postion;
        public bool CanAddPlayer(int depth)
        {
            if (this.Players.ContainsKey(depth) && ((this.Players[depth].IsEmpty())
                || this.Players.Where(q => q.Key > depth && q.Value.IsEmpty()).Count() > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddPlayer(int depth, PlayerModel player)
        {
            bool added = false;
            if (this.Players.ContainsKey(depth))
            {
                if (this.Players[depth].IsEmpty())
                {
                    this.Players[depth] = new PlayerModel(player.GetNumber(), player.GetName());
                }
                else
                {
                    var backup = this.Players.Where(q => q.Key >= depth && !q.Value.IsEmpty())
                                                .Select(p => p.Value).ToList();
                    this.Players[depth] = new PlayerModel(player.GetNumber(), player.GetName());
                    int index = depth + 1;
                    foreach (var pl in backup)
                    {
                        if (this.Players.ContainsKey(index))
                        {
                            this.Players[index] = new PlayerModel(pl.GetNumber(), pl.GetName());
                        }
                        index++;
                    }
                }
                added = true;
            }
            return added;
        }

        public PlayerModel RemovePlayer(PlayerModel player)
        {
            PlayerModel validPlayer = new PlayerModel(0, "");
            if (this.Players.Where(p => p.Value.GetNumber() == player.GetNumber()).Any())
            {
                var pl = this.Players.Where(p => p.Value.GetNumber() == player.GetNumber())
                                        .First();
                validPlayer = new PlayerModel(pl.Value.GetNumber(), pl.Value.GetName());
                this.Players[pl.Key] = new PlayerModel(0, "");
            }
            return validPlayer;
        }

        public List<PlayerModel> GetBackupPlayers(PlayerModel player)
        {
            List<PlayerModel> backup = new List<PlayerModel>();

            if (this.Players.Where(p => p.Value.GetNumber() == player.GetNumber()).Any())
            {
                var currentPlayer = this.Players.Where(p => p.Value.GetNumber() == player.GetNumber()).First();
                var bc = this.Players.Where(q => q.Key > currentPlayer.Key && !q.Value.IsEmpty())
                                        .Select(s => s.Value).ToList();
                backup.AddRange(bc);
            }
            return backup;
        }
        public PlayerModel GetPlayer(int depth)
        {
            PlayerModel player = new PlayerModel(0, "");
            if (this.Players.ContainsKey(depth))
            {
                player = new PlayerModel(this.Players[depth].GetNumber(), this.Players[depth].GetName());
            }
            return player;
        }
    }
}