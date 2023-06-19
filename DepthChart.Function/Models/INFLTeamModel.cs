namespace DepthChart.Function.Models
{
    public interface INFLTeamModel
    {
        bool AddPlayerToDepthChart(string position, PlayerModel player, int position_depth);
        List<PlayerModel> GetBackups(string position, PlayerModel player);
        List<ChartModel> GetFullDepthChart();
        PlayerModel GetPlayerFromDepthChart(string position, int depth);
        PlayerModel RemovePlayerFromDepthChart(string position, PlayerModel player);
    }
}