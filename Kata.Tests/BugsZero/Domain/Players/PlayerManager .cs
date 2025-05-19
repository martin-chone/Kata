namespace Kata.Tests.BugsZero.Domain.Players
{
    public class PlayerManager
    {
        private readonly List<Player> _players = new();
        private int _currentIndex = 0;

        public Player CurrentPlayer => _players[_currentIndex];
        public int Count => _players.Count;

        public void AddPlayer(string playerName) => _players.Add(new Player(playerName));

        public bool HasEnoughPlayers(int minimum) => Count >= minimum;

        public void Next() => _currentIndex = (_currentIndex + 1) % Count;
    }
}
