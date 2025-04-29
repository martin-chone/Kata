
namespace Kata.Tests.Domain
{
    public class Numerals
    {
        public static string ToRoman(int arabic)
        {
            if (arabic <= 3)
                return new string('I', arabic);

            if (arabic == 4)
                return "IV";

            if (arabic == 5)
                return "V";

            return string.Empty;
        }
    }
}