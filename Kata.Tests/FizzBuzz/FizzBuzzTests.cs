namespace Kata.Tests.FizzBuzz
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(13)]
        [InlineData(31)]
        public void ShouldFizzWhenMultipleOfThreeOrContainsThreeOnly(int input)
        {
            Assert.Equal("Fizz", FizzBuzz.Convert(input));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(52)]
        [InlineData(59)]
        public void ShouldBuzzWhenMultipleOfFiveOrContainsFiveOnly(int input)
        {
            Assert.Equal("Buzz", FizzBuzz.Convert(input));
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(35)]
        [InlineData(53)]
        public void ShouldFizzBuzzWhenMultipleOfThreeAndFiveOrContainsThreeAndFive(int input)
        {
            Assert.Equal("FizzBuzz", FizzBuzz.Convert(input));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        public void ShouldNumberWhenNoRuleMatches(int input)
        {
            Assert.Equal(input.ToString(), FizzBuzz.Convert(input));
        }
    }
}
