using Microsoft.Extensions.DependencyInjection;

namespace DepthChart.Function.Services
{

    public class DepthChartFactory : IDepthChartFactory
    {
        private readonly List<IDepthChartService> chartMap;
        public DepthChartFactory(IServiceProvider serviceProvider) => this.chartMap = new List<IDepthChartService>
            {
                {
                    serviceProvider.GetService<IDepthChartService>()!
                }
            };
        public IDepthChartService GetDepthChartServiceForSoprt(string sport) => this.chartMap.First(q => q.Sport == sport);

    }
}