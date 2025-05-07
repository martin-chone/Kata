
namespace Kata.Tests.Tennis
{
    public class Match
    {
        public Player Server { get; }
        public Player Receiver { get; }
        public Score Score { get; }

        public Match(Player server, Player receiver)
        {
            Server = server;
            Receiver = receiver;
            Score = new Score(0, 0);
        }

        public void PointToServer() => Score.AddPointToServer();

        public void PointToReceiver() => Score.AddPointToReceiver();

        public string GetScoreDisplay() => Score.GetScoreDisplay();
    }

    
}