namespace Kata.Tests.BugsZero
{
    public class GameRunner
    {
        private static bool notAWinner;

        public static void Main(string[] args)
        {
            Game aGame = GameFactory.CreateDefaultGame();

            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");

            Random rand = new Random();

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    aGame.WrongAnswer();
                }
                else
                {
                    notAWinner = aGame.HandleCorrectAnswer();
                }
            } while (notAWinner);

        }
    }
}
