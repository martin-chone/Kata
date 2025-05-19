namespace Kata.Tests.BugsZero
{
    public class Game
    {
        private const int TotalPlaces = 12;
        private const int WinningsThreshold = 6;

        private List<Player> players = new List<Player>();

        int currentPlayer = 0;

        private Player CurrentPlayer => players[currentPlayer];

        private IList<Category> Categories;
        private Dictionary<Category, QuestionBank> QuestionBanks;

        public Game()
        {
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
            Console.WriteLine(playerName + " was Added");
            Console.WriteLine("They are player number " + players.Count);
        }

        public void Roll(int roll)
        {
            var player = CurrentPlayer;

            DisplayCurrentPlayer(player);
            DisplayCurrentRoll(roll);

            player.IsExitingPenaltyBox = false;

            if (player.InPenaltyBox)
            {
                if (player.CanExitPenaltyBox(roll))
                {
                    player.IsExitingPenaltyBox = true;
                    DisplayExitPenaltyAction(player, player.IsExitingPenaltyBox);
                    MovePlayer(player, roll);

                    var category = GetCategoryForPlace(player.Place);
                    DisplayCurrentCategory(category);
                    DisplayNextQuestionFromCategory(category);
                }
                else
                {
                    DisplayExitPenaltyAction(player, player.IsExitingPenaltyBox);
                }
            }
            else
            {
                MovePlayer(player, roll);

                var category = GetCategoryForPlace(player.Place);
                DisplayCurrentCategory(category);
                DisplayNextQuestionFromCategory(category);
            }

        }

        private void MovePlayer(Player player, int roll)
        {
            player.Move(roll, TotalPlaces);
            Console.WriteLine(player.Name + "'s new location is " + player.Place);
        }

        private void DisplayNextQuestionFromCategory(Category category)
        {
            if(QuestionBanks.TryGetValue(category, out var questionBank))
            {
                var question = questionBank.Next();
                Console.WriteLine(question.Text);
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
                    DisplayCorrectAnswer();
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
                DisplayCorrectAnswer();
                AddReward(player);

                bool winner = DidPlayerWin();
                NextPlayer();

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            var player = CurrentPlayer;

            DisplayInCorrectAnswer();

            player.SendToPenaltyBox();
            DisplayEnterPenaltyAction(player);

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
            Console.WriteLine($"{player.Name} now has {player.Purse} Gold Coins.");
        }

        private void DisplayCurrentPlayer(Player player)
        {
            Console.WriteLine(player.Name + " is the current player");
        }

        private void DisplayCurrentRoll(int roll)
        {
            Console.WriteLine("They have rolled a " + roll);
        }

        private void DisplayEnterPenaltyAction(Player player)
        {
            Console.WriteLine($"{player.Name} was sent to the penalty box");
        }

        private void DisplayExitPenaltyAction(Player player, bool allowed)
        {
            Console.WriteLine(allowed
                ? $"{player.Name} is getting out of the penalty box"
                : $"{player.Name} is not getting out of the penalty box");
        }

        private void DisplayCurrentCategory(Category category)
        {
            Console.WriteLine("The category is " + category.Name);
        }

        private void DisplayCorrectAnswer()
        {
            Console.WriteLine("Answer was correct!!!!");
        }

        private void DisplayInCorrectAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
        }
    }

}
