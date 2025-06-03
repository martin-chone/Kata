namespace Kata.Tests.FizzBuzz
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        public void ShouldFizzWhenMultipleOfThreeOnly(int input)
        {
            Assert.Equal("Fizz", FizzBuzz.Convert(input));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        public void ShouldBuzzWhenMultipleOfFiveOnly(int input)
        {
            Assert.Equal("Buzz", FizzBuzz.Convert(input));
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void ShouldFizzBuzzWhenMultipleOfThreeAndFive(int input)
        {
            Assert.Equal("FizzBuzz", FizzBuzz.Convert(input));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        public void ShouldNumberWhenNotMultipleOfThreeOrFive(int input)
        {
            Assert.Equal(input.ToString(), FizzBuzz.Convert(input));
        }
    }
}
