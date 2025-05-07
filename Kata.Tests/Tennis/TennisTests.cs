namespace Kata.Tests.Tennis
{
    public class TennisTests
    {
        private Player server = new Player("Djokovic");
        private Player receiver = new Player("Alcaraz");

        [Fact]
        public void ShouldServerZeroReceiverZero()
        {
            var match = new Match(server, receiver);

            Assert.Equal("0-0", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerFifteenReceiverZero()
        {
            var match = new Match(server, receiver);

            match.PointToServer();

            Assert.Equal("15-0", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerThirtyReceiverZero()
        {
            var match = new Match(server, receiver);

            match.PointToServer();
            match.PointToServer();

            Assert.Equal("30-0", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerFortyReceiverZero()
        {
            var match = new Match(server, receiver);

            match.PointToServer();
            match.PointToServer();
            match.PointToServer();

            Assert.Equal("40-0", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerFifteenReceiverFifteen()
        {
            var match = new Match(server, receiver);

            match.PointToServer();
            match.PointToReceiver();

            Assert.Equal("15-15", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerFortyReceiverForty()
        {
            var match = new Match(server, receiver);

            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();

            Assert.Equal("40A", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerAdvantageReceiverForty()
        {
            var match = new Match(server, receiver);

            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();

            Assert.Equal("Advantage-40", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerFortyReceiverAdvantage()
        {
            var match = new Match(server, receiver);

            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();
            match.PointToReceiver();

            Assert.Equal("40-Advantage", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerWinnerReceiverForty()
        {
            var match = new Match(server, receiver);

            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToServer();

            Assert.Equal("Winner-40", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerFortyReceiverWinner()
        {
            var match = new Match(server, receiver);

            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();
            match.PointToReceiver();
            match.PointToReceiver();

            Assert.Equal("40-Winner", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerWinnerReceiverFifteen()
        {
            var match = new Match(server, receiver);

            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToServer();
            match.PointToServer();

            Assert.Equal("Winner-15", match.GetScoreDisplay());
        }

        [Fact]
        public void ShouldServerThirtyReceiverWinner()
        {
            var match = new Match(server, receiver);

            match.PointToServer();
            match.PointToReceiver();
            match.PointToServer();
            match.PointToReceiver();
            match.PointToReceiver();
            match.PointToReceiver();

            Assert.Equal("30-Winner", match.GetScoreDisplay());
        }
    }

    
}
