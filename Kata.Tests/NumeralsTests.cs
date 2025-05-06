using Kata.Tests.Domain;

namespace Kata.Tests
{
    public class NumeralsTests
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(11, "XI")]
        [InlineData(12, "XII")]
        [InlineData(16, "XVI")]
        [InlineData(19, "XIX")]
        public void ShouldConvertNumearlsToRomanRecursive(int input, string expected)
        {
            Assert.Equal(expected, Numerals.ToRomanRecursive(input));
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(11, "XI")]
        [InlineData(12, "XII")]
        [InlineData(16, "XVI")]
        [InlineData(19, "XIX")]
        public void ShouldConvertNumearlsToRomanDeclarative(int input, string expected)
        {
            Assert.Equal(expected, Numerals.ToRomanDeclarative(input));
        }
    }
}
