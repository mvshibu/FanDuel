namespace DepthChart.Tests.Fixtures
{
    using DepthChart.Function.Models;

    public static class PlayerFixtures
    {
        public static List<PlayerModel> GetPlayers()
        {
            List<PlayerModel> players = new List<PlayerModel>()
                                            {
                                                new PlayerModel(11, "TestPlayer1"),
                                                new PlayerModel(12, "TestPlayer2"),
                                                new PlayerModel(13, "TestPlayer3"),
                                                new PlayerModel(14, "TestPlayer4"),
                                                new PlayerModel(15, "TestPlayer5")
                                            };
            return players;
        }
    }
}