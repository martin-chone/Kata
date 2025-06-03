using System.Text;

namespace Kata.Tests.FizzBuzz
{
    public static class FizzBuzz
    {
        public static string Convert(int number)
        {
            var result = BuildOutput(number);

            return string.IsNullOrEmpty(result) ? number.ToString() : result.ToString();
        }

        private static string BuildOutput(int number)
        {
            var result = new StringBuilder();

            AppendFizzIfApplicable(result, number);
            AppendBuzzIfApplicable(result, number);

            return result.ToString();
        }

        private static void AppendFizzIfApplicable(StringBuilder sb, int number)
        {
            if (IsMultipleOfThree(number))
                sb.Append("Fizz");
        }

        private static void AppendBuzzIfApplicable(StringBuilder sb, int number)
        {
            if (IsMultipleOfFive(number))
                sb.Append("Buzz");
        }

        private static bool IsMultipleOfThree(int number) => number % 3 == 0;
        private static bool IsMultipleOfFive(int number) => number % 5 == 0;
    }
}