using Kata.Tests.BugsZero.Domain.Players;
using Kata.Tests.BugsZero.Domain.Turn;
using Kata.Tests.BugsZero.Output;

namespace Kata.Tests.BugsZero
{
    public class Game
    {
        private readonly GameConfig _config;
        private readonly PlayerManager _playerManager;
        private readonly TurnService _turnService;
        private readonly IGameOutput _output;

        private Player CurrentPlayer => _playerManager.CurrentPlayer;

        public Game(GameConfig config, PlayerManager playerManager, TurnService turnService, IGameOutput output)
        {
            _config = config;
            _playerManager = playerManager;
            _turnService = turnService;
            _output = output;
        }

        public void AddPlayer(string name)
        {
            _playerManager.AddPlayer(name);
            _output.PlayerAdded(name, _playerManager.Count);
        }

        public bool IsPlayable() => _playerManager.HasEnoughPlayers(_config.PlayerMinimumNumber);

        public void Roll(int roll) => _turnService.HandleRoll(CurrentPlayer, roll);

        public bool HandleCorrectAnswer()
        {
            var continueGame = _turnService.HandleCorrectAnswer(CurrentPlayer, _config.WinningsThreshold);

            _playerManager.Next();

            return continueGame;
        }

        public void WrongAnswer()
        {
            _turnService.HandleWrongAnswer(CurrentPlayer);

            _playerManager.Next();
        }
    }

}
