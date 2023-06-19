namespace DepthChart.Function.Services
{
    public interface IDepthChartFactory
    {
        IDepthChartService GetDepthChartServiceForSoprt(string sport);
    }
}