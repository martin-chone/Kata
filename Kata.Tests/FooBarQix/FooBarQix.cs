using System.Text;

namespace Kata.Tests.FooBarQix
{
    public static class FooBarQix
    {
        private static Dictionary<int, string> _rules = new()
        {
            [3] = "Foo",
            [5] = "Bar",
            [7] = "Qix",
        };

        public static string Convert(int number)
        {
            var result = new StringBuilder();

            if (number % 3 == 0) result.Append("Foo");
            if (number % 5 == 0) result.Append("Bar");
            if (number % 7 == 0) result.Append("Qix");

            foreach (char digit in number.ToString())
            {
                if(digit.Equals('3')) result.Append("Foo");
                if(digit.Equals('5')) result.Append("Bar");
                if(digit.Equals('7')) result.Append("Qix");
            }

            return result.ToString();
        }

        public static string ConvertFonctional(int number)
        {
            var result = new StringBuilder();

            var multiples = _rules
                .Where(r => number % r.Key == 0)
                .Select(r => r.Value);

            var digits = number
                .ToString()
                .Select(c => c - '0')
                .Where(d => _rules.ContainsKey(d))
                .Select(d => _rules[d]);

            return string.Concat(multiples.Concat(digits));
        }
    }
}