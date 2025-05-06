using System.Text;

namespace Kata.Tests.FooBarQix
{
    internal class FooBarQixConverter
    {
        private static readonly Dictionary<int, string> DivisibilityRules = new()
        {
            { 3, "Foo" },
            { 5, "Bar" },
            { 7, "Qix" }
        };

        private static readonly Dictionary<int, string> DigitRules = new()
        {
            { 3, "Foo" },
            { 5, "Bar" },
            { 7, "Qix" },
            { 0, "*" }
        };

        public FooBarQixConverter()
        {
        }

        internal string Convert(int number)
        {
            string divisibilityPart = ApplyDivisibilityRules(number);
            string digitPart = ApplyDigitRules(number);

            string result = divisibilityPart + digitPart;

            if (MustFallback(divisibilityPart, digitPart))
            {
                return ReconstructNumber(number);
            }

            return result;
        }

        private string ApplyDivisibilityRules(int number)
        {
            var result = new StringBuilder();
            foreach (var rule in DivisibilityRules)
            {
                if (number % rule.Key == 0)
                    result.Append(rule.Value);
            }
            return result.ToString();
        }

        private string ApplyDigitRules(int number)
        {
            var result = new StringBuilder();
            foreach (char c in number.ToString())
            {
                int digit = c - '0';
                if (DigitRules.TryGetValue(digit, out var replacement))
                    result.Append(replacement);
            }
            return result.ToString();
        }

        private bool MustFallback(string divisibilityPart, string digitPart)
        {
            return string.IsNullOrEmpty(divisibilityPart) && OnlyStars(digitPart);
        }

        private bool OnlyStars(string text)
        {
            return text.All(c => c == '*');
        }

        private string ReconstructNumber(int number)
        {
            var builder = new StringBuilder();
            foreach (char c in number.ToString())
            {
                builder.Append(c == '0' ? '*' : c);
            }
            return builder.ToString();
        }
    }
}