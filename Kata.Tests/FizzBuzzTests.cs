using Kata.Tests.Domain;

namespace Kata.Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "FizzFizz")]
        [InlineData(4, "4")]
        [InlineData(5, "BuzzBuzz")]
        [InlineData(8, "8")]
        [InlineData(9, "Fizz")]
        [InlineData(10, "Buzz")]
        [InlineData(11, "11")]
        [InlineData(13, "Fizz")]
        [InlineData(15, "FizzBuzzBuzz")]
        public void Convert_ReturnsExpectedResult(int input, string expected)
        {
            var converter = new FizzBuzzConverter();

            string result = converter.Convert(input);

            Assert.Equal(expected, result);
        }
    }
}
