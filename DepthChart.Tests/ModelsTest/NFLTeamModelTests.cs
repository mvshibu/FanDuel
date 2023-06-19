using DepthChart.Function.Models;
using DepthChart.Tests.Fixtures;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace DepthChart.Tests.ModelsTest
{

    public class NFLTeamModelTests
    {
        private readonly ILogger<NFLTeamModel> logger = NullLogger<NFLTeamModel>.Instance;

        private readonly NFLTeamModel nflModel;
        private readonly List<PlayerModel> players;

        public NFLTeamModelTests()
        {
            this.nflModel = new NFLTeamModel("Team1", 5, this.logger);
            this.players = PlayerFixtures.GetPlayers();
        }
        [Fact]
        public void ShouldAddPlayers()
        {

            nflModel.AddPlayerToDepthChart("LWR", players[0], 0);
            nflModel.AddPlayerToDepthChart("LWR", players[1], 1);
            nflModel.AddPlayerToDepthChart("RWR", players[2], 1);

            var addedPlayer1 = nflModel.GetPlayerFromDepthChart("LWR", 0);
            var addedPlayer2 = nflModel.GetPlayerFromDepthChart("LWR", 1);
            var addedPlayer3 = nflModel.GetPlayerFromDepthChart("LWR", 3);

            var addedPlayer4 = nflModel.GetPlayerFromDepthChart("RWR", 1);

            Assert.Equal(11, addedPlayer1.GetNumber());
            Assert.Equal("TestPlayer1", addedPlayer1.GetName());
            Assert.Equal(12, addedPlayer2.GetNumber());
            Assert.Equal("TestPlayer2", addedPlayer2.GetName());

            //empty player
            Assert.Equal(0, addedPlayer3.GetNumber());
            Assert.Equal("", addedPlayer3.GetName());

            Assert.Equal(13, addedPlayer4.GetNumber());
            Assert.Equal("TestPlayer3", addedPlayer4.GetName());

        }
        [Fact]
        public void ShouldNotAddPlayerIfPositionIsFull()
        {
            nflModel.AddPlayerToDepthChart("LWR", players[0], 0);
            nflModel.AddPlayerToDepthChart("LWR", players[1], 1);
            nflModel.AddPlayerToDepthChart("LWR", players[2], 2);
            nflModel.AddPlayerToDepthChart("LWR", players[3], 3);
            nflModel.AddPlayerToDepthChart("LWR", players[4], 4);

            var playerAdded = nflModel.AddPlayerToDepthChart("LWR", players[0], 4);

            Assert.Equal(false, playerAdded);
        }

        [Fact]
        public void ShouldRemovePlayerFromDepthChart()
        {
            nflModel.AddPlayerToDepthChart("LWR", players[0], 0);
            nflModel.AddPlayerToDepthChart("LWR", players[1], 1);
            nflModel.AddPlayerToDepthChart("LWR", players[2], 2);

            var removedPlayer = nflModel.RemovePlayerFromDepthChart("LWR", players[1]);

            var emptyPlayer = nflModel.GetPlayerFromDepthChart("LWR", 1);

            Assert.Equal(12, removedPlayer.GetNumber());
            Assert.Equal(0, emptyPlayer.GetNumber());
        }

        [Fact]
        public void ShouldGetBackupPlayers()
        {
            nflModel.AddPlayerToDepthChart("LWR", players[0], 0);
            nflModel.AddPlayerToDepthChart("LWR", players[1], 1);
            nflModel.AddPlayerToDepthChart("LWR", players[2], 2);
            nflModel.AddPlayerToDepthChart("LWR", players[3], 3);
            nflModel.AddPlayerToDepthChart("LWR", players[4], 4);


            var backups = nflModel.GetBackups("LWR", players[2]);

            Assert.Equal(2, backups.Count);
            Assert.Equal(14, backups[0].GetNumber());
            Assert.Equal(15, backups[1].GetNumber());
        }
    }
}