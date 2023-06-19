namespace DepthChart.Tests.ModelsTest
{
    using DepthChart.Function.Models;
    using Xunit;
    using Moq;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using DepthChart.Function;

    public class ChartModelTest
    {
        [Fact]
        public void ShouldCreatePlayerInPosition()
        {
            var chartModel = new ChartModel("LWR", 5);
            var player = new PlayerModel(12, "TestPlayer1");
            var added = chartModel.AddPlayer(0, player);

            var addedPlayer = chartModel.GetPlayer(0);
            Assert.Equal("TestPlayer1", addedPlayer.GetName());
        }
    }
}