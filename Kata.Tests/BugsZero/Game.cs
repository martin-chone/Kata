namespace Kata.Tests.BugsZero
{
    public class Game
    {
        private readonly IGameOutput _output;

        private const int TotalPlaces = 12;
        private const int WinningsThreshold = 6;

        private readonly PenaltyBoxService _penaltyBox;

        private List<Player> players = new List<Player>();

        int currentPlayer = 0;

        private Player CurrentPlayer => players[currentPlayer];

        private IList<Category> Categories;
        private Dictionary<Category, QuestionBank> QuestionBanks;

        public Game(IGameOutput output)
        {
            _output = output;
            _penaltyBox = new PenaltyBoxService();
             
            InitializeCategories();
            InitializeQuestionsByCategory();
        }

        private void InitializeCategories()
        {
            Categories = new List<Category>
            {
                new("Pop"),
                new("Science"),
                new("Sports"),
                new("Rock")
            };
        }

        private void InitializeQuestionsByCategory()
        {
            QuestionBanks = Categories.ToDictionary(
                category => category, 
                category => new QuestionBank());

            for (int i = 0; i < 50; i++)
            {
                foreach (Category category in Categories)
                {
                    var questionText = $"{category.Name} Question {i}";
                    var question = new Question(questionText);
                    QuestionBanks[category].Add(question);
                }
            }
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

            var category = GetCategoryForPlace(player.Place);
            _output.ShowCategory(category.Name);
            DisplayNextQuestionFromCategory(category);
        }

        private void MovePlayer(Player player, int roll)
        {
            player.Move(roll, TotalPlaces);
            _output.ShowNewLocation(player.Name, player.Place);
        }

        private void DisplayNextQuestionFromCategory(Category category)
        {
            if(QuestionBanks.TryGetValue(category, out var questionBank))
            {
                var question = questionBank.Next();
                _output.ShowQuestion(question.Text);
                questionBank.Remove();
            }
        }

        private Category GetCategoryForPlace(int place)
        {
            return Categories[place % Categories.Count];
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
