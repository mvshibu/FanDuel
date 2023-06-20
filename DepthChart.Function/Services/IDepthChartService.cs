using DepthChart.Function.Models;

namespace DepthChart.Function.Services
{
    public interface IDepthChartService
    {
        string Sport { get; set; }
        string AddPlayerToDepthChart(string position, PlayerModel player, int position_depth);
        List<string> GetBackups(string position, PlayerModel player);
        List<string> GetFullDepthChart();
        string RemovePlayerFromDepthChart(string position, PlayerModel player);
    }
}