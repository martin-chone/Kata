using System.Text;

namespace Kata.Tests.RomanNumerals
{
    public class Numerals
    {
        private static readonly Dictionary<int, string> RomanConvertionRules = new()
        {
            {1000, "M"}, {900, "CM"}, {500, "D"}, {400, "CD"},
            {100, "C"}, {90, "XC"}, {50, "L"}, {40, "XL"},
            {10, "X"}, {9, "IX"}, {5, "V"}, {4, "IV"},
            {1, "I"}
        };

        public static string ToRomanRecursive(int arabic)
        {
            if(arabic <= 0)
                return string.Empty;

            var floorEntry = RomanConvertionRules.First(rule => rule.Key <= arabic);

            return floorEntry.Value + ToRomanRecursive(arabic - floorEntry.Key);
        }

        public static string ToRomanDeclarative(int arabic)
        {
            var result = new StringBuilder();

            foreach (var (value, symbol) in RomanConvertionRules)
            {
                while (arabic >= value)
                {
                    result.Append(symbol);
                    arabic -= value;
                }
            }

            return result.ToString();
        }
    }
}