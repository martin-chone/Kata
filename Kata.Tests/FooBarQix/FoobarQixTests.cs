namespace Kata.Tests.FooBarQix
{
    public class FoobarQixTests
    {
        [Theory]
        [InlineData(6)]
        [InlineData(9)]
        public void ShouldFooWhenMultipleOfThree(int input)
        {
            var result = FooBarQix.Convert(input);
            Assert.Equal("Foo", result);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void ShoulAddBarWhenMultipleOfFive(int input)
        {
            var result = FooBarQix.Convert(input);
            Assert.Equal("Bar", result);
        }

        [Theory]
        [InlineData(14)]
        [InlineData(28)]
        public void ShoulAddQixWhenMultipleOfSeven(int input)
        {
            var result = FooBarQix.Convert(input);
            Assert.Equal("Qix", result);
        }

        [Theory]
        [InlineData(3, "FooFoo")]
        [InlineData(13, "Foo")]
        [InlineData(3032, "FooFoo")]
        [InlineData(333, "FooFooFooFoo")]
        public void ShoulAddFooForEveryThreeDigits(int input, string expected)
        {
            var result = FooBarQix.Convert(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, "BarBar")]
        [InlineData(5416, "Bar")]
        [InlineData(1552, "BarBar")]
        public void ShoulAddBarForEveryFiveDigits(int input, string expected)
        {
            var result = FooBarQix.Convert(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(7, "QixQix")]
        [InlineData(1742, "Qix")]
        [InlineData(7724, "QixQix")]
        public void ShoulAddQixForEverySevenDigits(int input, string expected)
        {
            var result = FooBarQix.Convert(input);
            Assert.Equal(expected, result);
        }
    }
}
