namespace Kata.Tests.FooBarQix
{
    public class FoobarQixTests
    {

        private readonly FooBarQixConverter fooBarQix = new FooBarQixConverter();

        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "FooFoo")]
        [InlineData(5, "BarBar")]
        [InlineData(7, "QixQix")]
        [InlineData(13, "Foo")]
        [InlineData(15, "FooBarBar")]
        [InlineData(33, "FooFooFoo")]
        [InlineData(51, "FooBar")]
        [InlineData(53, "BarFoo")]
        [InlineData(101, "1*1")]
        [InlineData(303, "FooFoo*Foo")]
        [InlineData(105, "FooBarQix*Bar")]
        [InlineData(10101, "FooQix**")]
        [InlineData(507315, "FooBarBar*QixFooBar")]
        public void Convert_ReturnsExpectedResult(int input, string expected)
        {
            var result = fooBarQix.Convert(input);
            Assert.Equal(expected, result);
        }
    }
}
