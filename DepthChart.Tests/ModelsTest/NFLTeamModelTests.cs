using DepthChart.Function.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace DepthChart.Tests.ModelsTest
{

    public class NFLTeamModelTests
    {
        private readonly ILogger<NFLTeamModel> logger = NullLogger<NFLTeamModel>.Instance;

        [Fact]
        public void ShouldAddPlayers()
        {
            var nflModel = new NFLTeamModel("Team1", 5, this.logger);

            // When

            // Then
        }
    }
}