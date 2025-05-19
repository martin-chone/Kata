namespace Kata.Tests.BugsZero
{
    public class GameRunner
    {
        private static bool notAWinner;

        public static void Main(string[] args)
        {
            Game aGame = new Game(new ConsoleGameOutput());

            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");

            Random rand = new Random();

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    notAWinner = aGame.WrongAnswer();
                }
                else
                {
                    notAWinner = aGame.WasCorrectlyAnswered();
                }
            } while (notAWinner);

        }
    }
}
