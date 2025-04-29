using System.Text;

namespace Kata.Tests.Domain
{
    internal class FizzBuzzConverter
    {
        private static readonly IDictionary<int, string> divisibilityRules = new Dictionary<int, string>
        {
            {3, "Fizz" },
            {5, "Buzz" }
        };

        private static readonly IDictionary<int, string> digitRules = new Dictionary<int, string>
        {
            {3, "Fizz" },
            {5, "Buzz" }
        };

        public FizzBuzzConverter()
        {
        }

        internal string Convert(int number)
        {
            var result = new StringBuilder();

            foreach (var rule in divisibilityRules)
            {
                if (number % rule.Key == 0)
                    result.Append(rule.Value);
            }
            
            foreach (char c in number.ToString())
            {
                int digit = int.Parse(c.ToString());

                if(digitRules.TryGetValue(digit, out var replacement))
                    result.Append(replacement);
            }

            if (result.Length == 0)
                result.Append( number.ToString()); 

            return result.ToString();
        }
    }
}