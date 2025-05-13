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

            int playerIndex = players.Count - 1;

            places[playerIndex] = 0;
            purses[playerIndex] = 0;
            inPenaltyBox[playerIndex] = false;

            Console.WriteLine(playerName + " was Added");
            Console.WriteLine("They are player number " + players.Count);
        }

        public void Roll(int roll)
        {
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
                    places[currentPlayer] = places[currentPlayer] + roll;
                    if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                    Console.WriteLine(players[currentPlayer]
                            + "'s new location is "
                            + places[currentPlayer]);

                    var category = GetCurrentCategory();
                    Console.WriteLine("The category is " + category.Name);

                    DisplayNextQuestionFromCategory(category);
                }
                else
                {
                    Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {

                places[currentPlayer] = places[currentPlayer] + roll;
                if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                Console.WriteLine(players[currentPlayer]
                        + "'s new location is "
                        + places[currentPlayer]);

                var category = GetCurrentCategory();
                Console.WriteLine("The category is " + category.Name);

                DisplayNextQuestionFromCategory(category);
            }

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
            var position = places[currentPlayer];

            return Categories[position % Categories.Count];
            
        }

        public bool WasCorrectlyAnswered()
        {
            if (inPenaltyBox[currentPlayer])
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;
                    purses[currentPlayer]++;
                    Console.WriteLine(players[currentPlayer]
                            + " now has "
                            + purses[currentPlayer]
                            + " Gold Coins.");

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

                Console.WriteLine("Answer was corrent!!!!");
                purses[currentPlayer]++;
                Console.WriteLine(players[currentPlayer]
                        + " now has "
                        + purses[currentPlayer]
                        + " Gold Coins.");

                bool winner = DidPlayerWin();
                currentPlayer++;
                if (currentPlayer == players.Count) currentPlayer = 0;

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return !(purses[currentPlayer] == 6);
        }
    }

}
