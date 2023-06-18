namespace DepthChart.Function.Models
{

    public class ChartModel
    {
        private readonly string Postion;
        private readonly Dictionary<int, PlayerModel> Players;

        public ChartModel(string position, int depth_limit)
        {
            this.Postion = position;
            this.Players = new Dictionary<int, PlayerModel>(depth_limit);
            this.Players.Initialize(depth_limit);
        }

        public bool CanAddPlayer(int depth, PlayerModel player)
        {
            if (!this.Players.ContainsKey(depth)
                || this.Players.Where(q => q.Key > depth && q.Value.IsEmpty()).Count() > 0)
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
                    int index = depth++;
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
    }
}