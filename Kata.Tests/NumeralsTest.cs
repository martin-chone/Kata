using Kata.Tests.Domain;

namespace Kata.Tests
{
    public class NumeralsTest
    {
        [Fact]
        public void ShouldConvertZeroToEmptyString()
        {
            Assert.Empty(Numerals.ToRoman(0));
        }

        [Fact]
        public void ShouldConvertOneToI()
        {
            Assert.Equal("I", Numerals.ToRoman(1));
        }

        [Fact]
        public void ShouldConvertTwoToII()
        {
            Assert.Equal("II", Numerals.ToRoman(2));
        }

        [Fact]
        public void ShouldConvertThreeToIII()
        {
            Assert.Equal("III", Numerals.ToRoman(3));
        }

        [Fact]
        public void ShouldConvertFourToIV()
        {
            Assert.Equal("IV", Numerals.ToRoman(4));
        }

        [Fact]
        public void ShouldConvertFiveToV()
        {
            Assert.Equal("V", Numerals.ToRoman(5));
        }
    }
}
