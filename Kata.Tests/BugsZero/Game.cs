namespace Kata.Tests.BugsZero
{
    public class Game
    {
        List<string> players = new List<string>();

        int[] places = new int[6];
        int[] purses = new int[6];

        bool[] inPenaltyBox = new bool[6];

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

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
            players.Add(playerName);

            var playerIndex = players.Count - 1;

            places[playerIndex] = 0;
            purses[playerIndex] = 0;
            inPenaltyBox[playerIndex] = false;

            Console.WriteLine(playerName + " was Added");
            Console.WriteLine("They are player number " + players.Count);
        }

        public void Roll(int roll)
        {
            var currentPlayerIndex = currentPlayer;
            var currentPlayerName = players[currentPlayerIndex];
            var currentPlayerPlace = places[currentPlayerIndex];
            var currentPlayerIsInPenaltyBox = inPenaltyBox[currentPlayerIndex];
            DisplayCurrentPlayer(currentPlayerName);

            DisplayCurrentRoll(roll);

            if (currentPlayerIsInPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;
                    DisplayExitPenaltyAction(currentPlayerName, isGettingOutOfPenaltyBox);
                    currentPlayerPlace = MovePlayer(roll);

                    DisplayNewCurrentPlayerPlace(currentPlayerName, currentPlayerPlace);

                    var category = GetCurrentCategory();
                    DisplayCurrentCategory(category);
                    DisplayNextQuestionFromCategory(category);
                }
                else
                {
                    isGettingOutOfPenaltyBox = false;
                    DisplayExitPenaltyAction(currentPlayerName, isGettingOutOfPenaltyBox);
                }
            }
            else
            {
                currentPlayerPlace = MovePlayer(roll);

                DisplayNewCurrentPlayerPlace(currentPlayerName, currentPlayerPlace);

                var category = GetCurrentCategory();
                DisplayCurrentCategory(category);
                DisplayNextQuestionFromCategory(category);
            }

        }

        private int MovePlayer(int roll)
        {
            var currentPlayerIndex = currentPlayer;
            var currentPlayerPlace = places[currentPlayerIndex];

            currentPlayerPlace = currentPlayerPlace + roll;
            if (currentPlayerPlace > 11) currentPlayerPlace = currentPlayerPlace - 12;
            places[currentPlayerIndex] = currentPlayerPlace;
            return currentPlayerPlace;
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

        private Category GetCurrentCategory()
        {
            var currentPlayerIndex = currentPlayer;
            var currentPlayerPlace = places[currentPlayerIndex];

            return Categories[currentPlayerPlace % Categories.Count];
        }

        public bool WasCorrectlyAnswered()
        {
            var currentPlayerIndex = currentPlayer;
            var currentPlayerName = players[currentPlayerIndex];
            var currentPlayerIsInPenaltyBox = inPenaltyBox[currentPlayerIndex];

            if (currentPlayerIsInPenaltyBox)
            {
                if (isGettingOutOfPenaltyBox)
                {
                    DisplayCorrectAnswer();
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;

                    currentPlayerIndex = currentPlayer;
                    currentPlayerName = players[currentPlayerIndex];

                    purses[currentPlayer]++;
                    DisplayReward(currentPlayerName, purses[currentPlayer]);

                    bool winner = DidPlayerWin();

                    return winner;
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;
                    return true;
                }
            }
            else
            {
                DisplayCorrectAnswer();
                purses[currentPlayer]++;
                DisplayReward(currentPlayerName, purses[currentPlayer]);

                bool winner = DidPlayerWin();
                currentPlayer++;
                if (currentPlayer == players.Count) currentPlayer = 0;

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            var currentPlayerIndex = currentPlayer;
            var currentPlayerName = players[currentPlayerIndex];

            DisplayInCorrectAnswer();

            DisplayEnterPenaltyAction(currentPlayerName);
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return !(purses[currentPlayer] == 6);
        }

        private void DisplayCurrentPlayer(string playerName)
        {
            Console.WriteLine(playerName + " is the current player");
        }

        private void DisplayCurrentRoll(int roll)
        {
            Console.WriteLine("They have rolled a " + roll);
        }

        private void DisplayEnterPenaltyAction(string playerName)
        {
            Console.WriteLine($"{playerName} was sent to the penalty box");
        }

        private void DisplayExitPenaltyAction(string playerName, bool allowed)
        {
            Console.WriteLine(allowed
                ? $"{playerName} is getting out of the penalty box"
                : $"{playerName} is not getting out of the penalty box");
        }

        private void DisplayNewCurrentPlayerPlace(string playerName, int place)
        {
            Console.WriteLine(playerName + "'s new location is " + place);
        }

        private void DisplayCurrentCategory(Category category)
        {
            Console.WriteLine("The category is " + category.Name);
        }

        private void DisplayCorrectAnswer()
        {
            Console.WriteLine("Answer was correct!!!!");
        }

        private void DisplayReward(string playerName, int amount)
        {
            Console.WriteLine($"{playerName} now has {amount} Gold Coins.");
        }

        private void DisplayInCorrectAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
        }
    }

}
