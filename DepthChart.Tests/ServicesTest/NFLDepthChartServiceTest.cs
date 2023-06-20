using DepthChart.Function.Models;
using DepthChart.Function.Services;
using DepthChart.Tests.Fixtures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace DepthChart.Tests.ServicesTest
{
    public class NFLDepthChartServiceTest
    {
        private readonly NFLDepthChartService depthChartService;
        private readonly List<PlayerModel> players;
        public NFLDepthChartServiceTest()
        {
            IConfiguration config = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            var nflTeamModel = new NFLTeamModel(config, NullLogger<NFLTeamModel>.Instance);
            this.depthChartService = new NFLDepthChartService(nflTeamModel);
            this.players = PlayerFixtures.GetPlayers();

        }
        [Fact]
        public void ShouldAddPlayerByService()
        {
            var added = this.depthChartService.AddPlayerToDepthChart("LWR", this.players[0], 0);
            Assert.Equal("Player Added", added);
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[1], 1);
            this.depthChartService.AddPlayerToDepthChart("RWR", this.players[2], 1);

            var players = this.depthChartService.GetFullDepthChart();
            Assert.Equal("LWR - (#11, TestPlayer1),(#12, TestPlayer2)", players[0]);
            Assert.Equal("RWR - (#13, TestPlayer3)", players[1]);
        }

        [Fact]
        public void ShouldRemovePlayerByService()
        {
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[0], 0);
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[1], 1);
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[2], 2);

            var removedPlayer = this.depthChartService.RemovePlayerFromDepthChart("LWR", this.players[2]);
            Assert.Equal("#13 - TestPlayer3", removedPlayer);

            var players = this.depthChartService.GetFullDepthChart();
            Assert.Equal("LWR - (#11, TestPlayer1),(#12, TestPlayer2)", players[0]);
        }

        [Fact]
        public void ShouldGetBackupByService()
        {
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[0], 0);
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[1], 1);
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[2], 2);

            var backup = this.depthChartService.GetBackups("LWR", this.players[0]);
            Assert.Equal("#12 - TestPlayer2", backup[0]);
            Assert.Equal("#13 - TestPlayer3", backup[1]);
        }
        [Fact]
        public void ShouldGetEmptyBackupIfNoPlayerInBelowPositionsByService()
        {
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[0], 0);
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[1], 1);
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[2], 2);

            var backup = this.depthChartService.GetBackups("LWR", this.players[2]);
            Assert.Equal("<NO LIST>", backup[0]);
        }
        [Fact]
        public void ShouldGetEmptyForRemoveInvalidPlayerByService()
        {
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[0], 0);
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[1], 1);
            this.depthChartService.AddPlayerToDepthChart("LWR", this.players[2], 2);

            var backup = this.depthChartService.GetBackups("LWR", this.players[4]);
            Assert.Equal("<NO LIST>", backup[0]);
        }
    }


}