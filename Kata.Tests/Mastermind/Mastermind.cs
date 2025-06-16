
namespace Kata.Tests.Mastermind
{
    public record Result(int WellPlaced, int Missplaced);

    public static class Mastermind
    {
        public static Result Evaluate(string[] secret, string[] guess)
        {
            var wellPlaced = 0;
            var missplaced = 0;

            for(int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                    wellPlaced++;
                else if (secret.Contains(guess[i]))
                    missplaced++;
            }

            return new Result(wellPlaced, missplaced);
        }
    }
}
