namespace Kata.Tests.BugsZero
{
    public class Game
    {
        private readonly IGameOutput _output;

        private const int TotalPlaces = 12;
        private const int WinningsThreshold = 6;
        private const int PlayerMinimumNumber = 2;

        private readonly PenaltyBoxService _penaltyBoxService;
        private readonly QuestionService _questionService;
        private readonly PlayerManager _playerManager;

        private Player CurrentPlayer => _playerManager.CurrentPlayer;

        public Game(IGameOutput output)
        {
            _output = output;
            _penaltyBoxService = new PenaltyBoxService();
            _playerManager = new PlayerManager();

            var categories = new List<Category>
            {
                new("Pop"), new("Science"), new("Sports"), new("Rock")
            };

            var questionsPerCategory = 50;
            _questionService = new QuestionService(categories, questionsPerCategory);
        }

        public bool IsPlayable()
        {
            return _playerManager.HasEnoughPlayers(PlayerMinimumNumber);
        }

        public void AddPlayer(String playerName)
        {
            _playerManager.AddPlayer(playerName);
            _output.PlayerAdded(playerName, _playerManager.Count);
        }

        public void Roll(int roll)
        {
            var player = CurrentPlayer;

            _output.ShowCurrentPlayer(player.Name);
            _output.ShowRoll(roll);

            if (player.InPenaltyBox)
            {
                _penaltyBoxService.HandleRoll(player, roll);
                _output.ExitPenaltyBox(player.Name, player.IsExitingPenaltyBox);

                if (player.IsExitingPenaltyBox)
                {
                    MoveAndAskQuestion(player, roll);
                }
            }
            else
            {
                MoveAndAskQuestion(player, roll);
            }

        }

        private void MoveAndAskQuestion(Player player, int roll)
        {
            player.Move(roll, TotalPlaces);
            _output.ShowNewLocation(player.Name, player.Place);

            var category = _questionService.GetCategoryForPlace(player.Place);
            _output.ShowCategory(category.Name);

            var question = _questionService.GetNextQuestion(category);
            _output.ShowQuestion(question.Text);
        }

        public bool WasCorrectlyAnswered()
        {
            var player = CurrentPlayer;

            if (player.InPenaltyBox && !player.IsExitingPenaltyBox) 
            {
                _playerManager.Next();
                return true;
            }

            _output.ShowCorrectAnswer();
            player.Reward();

            _output.ShowPlayerPurse(player.Name, player.Purse);

            var hasWon = !player.HasWon(WinningsThreshold);
            _playerManager.Next();

            return hasWon;
        }

        public bool WrongAnswer()
        {
            var player = CurrentPlayer;

            _output.ShowIncorrectAnswer();

            _penaltyBoxService.SendToPenalty(player);
            _output.EnterPenaltyBox(player.Name);
            _playerManager.Next();

            return true;
        }
    }

}
