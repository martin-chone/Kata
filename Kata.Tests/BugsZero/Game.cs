namespace Kata.Tests.BugsZero
{
    public class Game
    {
        private const int TotalPlaces = 12;
        private const int WinningsThreshold = 6;
        private const int PlayerMinimumNumber = 2;
        private const int QuestionsPerCategory = 50;

        private readonly PlayerManager _playerManager;
        private readonly TurnService _turnService;
        private readonly IGameOutput _output;

        private Player CurrentPlayer => _playerManager.CurrentPlayer;

        public Game()
        {
            _playerManager = new PlayerManager();
            _output = new ConsoleGameOutput();

            var penaltyBoxService = new PenaltyBoxService();

            var categories = new List<Category>
            {
                new("Pop"), new("Science"), new("Sports"), new("Rock")
            };

            var questionService = new QuestionService(categories, QuestionsPerCategory);

            _turnService = new TurnService(penaltyBoxService, questionService, _output, TotalPlaces);
        }

        public void AddPlayer(string name)
        {
            _playerManager.AddPlayer(name);
            _output.PlayerAdded(name, _playerManager.Count);
        }

        public bool IsPlayable() => _playerManager.HasEnoughPlayers(PlayerMinimumNumber);

        public void Roll(int roll) => _turnService.HandleRoll(CurrentPlayer, roll);

        public bool HandleCorrectAnswer()
        {
            var continueGame = _turnService.HandleCorrectAnswer(CurrentPlayer, WinningsThreshold);

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
