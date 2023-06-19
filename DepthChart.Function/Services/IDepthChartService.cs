using DepthChart.Function.Models;

namespace DepthChart.Function.Services
{
    public interface IDepthChartService
    {
        string Sport { get; set; }
        void AddPlayerToDepthChart(string position, PlayerModel player, int position_depth);
        void GetBackups(string position, PlayerModel player);
        void GetFullDepthChart();
        void RemovePlayerFromDepthChart(string position, PlayerModel player);
    }
}