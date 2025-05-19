namespace Kata.Tests.BugsZero
{
    public class Game
    {
        private readonly IGameOutput _output;

        private const int TotalPlaces = 12;
        private const int WinningsThreshold = 6;

        private readonly PenaltyBoxService _penaltyBox;
        private readonly QuestionService _questionService;

        private List<Player> players = new List<Player>();

        int currentPlayer = 0;

        private Player CurrentPlayer => players[currentPlayer];

        public Game(IGameOutput output)
        {
            _output = output;
            _penaltyBox = new PenaltyBoxService();

            var categories = new List<Category>
            {
                new("Pop"), new("Science"), new("Sports"), new("Rock")
            };

            var questionsPerCategory = 50;
            _questionService = new QuestionService(categories, questionsPerCategory);
        }

        public bool IsPlayable()
        {
            return (players.Count >= 2);
        }

        public void AddPlayer(String playerName)
        {
            players.Add(new Player(playerName));
            _output.PlayerAdded(playerName, players.Count);
        }

        public void Roll(int roll)
        {
            var player = CurrentPlayer;

            _output.ShowCurrentPlayer(player.Name);
            _output.ShowRoll(roll);

            if (player.InPenaltyBox)
            {
                _penaltyBox.HandleRoll(player, roll);
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
            MovePlayer(player, roll);

            var category = _questionService.GetCategoryForPlace(player.Place);
            _output.ShowCategory(category.Name);
            var question = _questionService.GetNextQuestion(category);
            _output.ShowQuestion(question.Text);
        }

        private void MovePlayer(Player player, int roll)
        {
            player.Move(roll, TotalPlaces);
            _output.ShowNewLocation(player.Name, player.Place);
        }

        public bool WasCorrectlyAnswered()
        {
            var player = CurrentPlayer;

            if (player.InPenaltyBox)
            {
                if (player.IsExitingPenaltyBox)
                {
                    _output.ShowCorrectAnswer();
                    NextPlayer();

                    AddReward(CurrentPlayer);

                    bool winner = DidPlayerWin();

                    return winner;
                }
                else
                {
                    NextPlayer();
                    return true;
                }
            }
            else
            {
                _output.ShowCorrectAnswer();
                AddReward(player);

                bool winner = DidPlayerWin();
                NextPlayer();

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            var player = CurrentPlayer;

            _output.ShowIncorrectAnswer();

            player.SendToPenaltyBox();
            _output.EnterPenaltyBox(player.Name);

            NextPlayer();
            return true;
        }


        private bool DidPlayerWin()
        {
            return !(CurrentPlayer.HasWon(WinningsThreshold));
        }

        private void NextPlayer()
        {
            currentPlayer = (currentPlayer + 1) % players.Count;
        }

        private void AddReward(Player player)
        {
            player.Reward();
            _output.ShowPlayerPurse(player.Name, player.Purse);
        }
    }

}
