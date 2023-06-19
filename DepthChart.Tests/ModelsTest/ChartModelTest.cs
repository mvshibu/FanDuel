namespace DepthChart.Tests.ModelsTest
{
    using DepthChart.Function.Models;
    using DepthChart.Tests.Fixtures;
    using Xunit;

    public class ChartModelTest
    {
        [Fact]
        public void ShouldCreatePlayerInPosition()
        {
            var chartModel = new ChartModel("LWR", 5);
            var defaultPlayer = chartModel.GetPlayer(0);
            var player = new PlayerModel(12, "TestPlayer1");
            var added = chartModel.AddPlayer(0, player);

            player = new PlayerModel(13, "TestPlayer2");
            added = chartModel.AddPlayer(1, player);
            Assert.Equal(true, added);

            Assert.Equal(0, defaultPlayer.GetNumber());
            Assert.Equal("", defaultPlayer.GetName());

            var addedPlayer1 = chartModel.GetPlayer(0);
            Assert.Equal(12, addedPlayer1.GetNumber());
            Assert.Equal("TestPlayer1", addedPlayer1.GetName());

            addedPlayer1 = chartModel.GetPlayer(1);
            Assert.Equal(13, addedPlayer1.GetNumber());
            Assert.Equal("TestPlayer2", addedPlayer1.GetName());
        }
        [Fact]
        public void CanAddPlayerIfPositionHasEmptySlot()
        {
            var chartModel = new ChartModel("LWR", 5);
            var player1 = new PlayerModel(12, "TestPlayer1");
            var player2 = new PlayerModel(13, "TestPlayer2");

            var player4 = new PlayerModel(14, "TestPlayer4");
            var player5 = new PlayerModel(15, "TestPlayer5");
            chartModel.AddPlayer(0, player1);
            chartModel.AddPlayer(1, player2);
            chartModel.AddPlayer(3, player4);
            chartModel.AddPlayer(4, player5);

            var canAdd = chartModel.CanAddPlayer(2);

            Assert.Equal(true, canAdd);

            //cannot add in the below positions
            canAdd = chartModel.CanAddPlayer(3);
            Assert.Equal(false, canAdd);

            //can add in above positions
            canAdd = chartModel.CanAddPlayer(1);
            Assert.Equal(true, canAdd);
        }
        [Fact]
        public void CannotAddPlayerIfPostionIsFull()
        {
            var chartModel = new ChartModel("LWR", 5);
            List<PlayerModel> players = new List<PlayerModel>()
                                            {
                                                new PlayerModel(11, "TestPlayer1"),
                                                new PlayerModel(12, "TestPlayer2"),
                                                new PlayerModel(13, "TestPlayer2"),
                                                new PlayerModel(14, "TestPlayer4"),
                                                new PlayerModel(15, "TestPlayer5")
                                            };
            chartModel.AddPlayer(0, players[0]);
            chartModel.AddPlayer(1, players[1]);
            chartModel.AddPlayer(3, players[2]);
            chartModel.AddPlayer(4, players[3]);

            var canAdd = chartModel.CanAddPlayer(0);
            Assert.Equal(false, canAdd);
        }
        [Fact]
        public void ShouldMoveBelowPlayers()
        {
            var chartModel = new ChartModel("LWR", 5);

            var players = PlayerFixtures.GetPlayers();

            chartModel.AddPlayer(0, players[0]);
            chartModel.AddPlayer(1, players[1]);
            chartModel.AddPlayer(3, players[2]);

            chartModel.AddPlayer(1, players[3]);

            Assert.Equal(14, chartModel.GetPlayer(1).GetNumber());
            Assert.Equal(12, chartModel.GetPlayer(2).GetNumber());
            Assert.Equal(13, chartModel.GetPlayer(3).GetNumber());
        }
    }
}