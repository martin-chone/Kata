namespace Kata.Tests.Mastermind
{
    public class MastermindTests
    {
        [Theory]
        [InlineData(new[] { "blue" }, new[] { "red" })]
        [InlineData(new[] { "blue", "red"}, new[] { "purple", "yellow" })]
        public void ShouldDetectColorsNeitherWellPlacedNorBadlyPlaced(string[] secret, string[] guess)
        {
            var wellPlaced = 0;
            var missplaced = 0;

            var result = Mastermind.Evaluate(secret, guess);

            Assert.Equal(new Result(wellPlaced, missplaced), result);
        }

        [Theory]
        [InlineData(new[] { "blue" }, new[] { "blue" })]
        [InlineData(new[] { "blue", "red" }, new[] { "blue", "yellow" })]
        [InlineData(new[] { "blue", "red" }, new[] { "yellow", "red" })]
        [InlineData(new[] { "blue", "purple", "red" }, new[] { "yellow", "pink", "red" })]
        public void ShouldDetectOneWellPlacedColor(string[] secret, string[] guess)
        {
            var wellPlaced = 1;
            var missplaced = 0;

            var result = Mastermind.Evaluate(secret, guess);

            Assert.Equal(new Result(wellPlaced, missplaced), result);
        }

        [Theory]
        [InlineData(new[] { "blue", "red" }, new[] { "blue", "red" })]
        [InlineData(new[] { "blue", "purple", "red" }, new[] { "blue", "pink", "red" })]
        public void ShouldDetectTwoWellPlacedColor(string[] secret, string[] guess)
        {
            var wellPlaced = 2;
            var missplaced = 0;

            var result = Mastermind.Evaluate(secret, guess);

            Assert.Equal(new Result(wellPlaced, missplaced), result);
        }

        [Theory]
        [InlineData(new[] { "blue", "red", "green" }, new[] { "blue", "red", "green" })]
        [InlineData(new[] { "yellow", "blue", "purple", "red" }, new[] { "yellow", "blue", "pink", "red" })]
        public void ShouldDetectThreeWellPlacedColor(string[] secret, string[] guess)
        {
            var wellPlaced = 3;
            var missplaced = 0;

            var result = Mastermind.Evaluate(secret, guess);

            Assert.Equal(new Result(wellPlaced, missplaced), result);
        }

        [Theory]
        [InlineData(new[] { "blue", "red" }, new[] { "yellow", "blue" })]
        [InlineData(new[] { "blue", "red", "green" }, new[] { "yellow", "purple", "red" })]
        public void ShouldDetectOneMissplacedColor(string[] secret, string[] guess)
        {
            var wellPlaced = 0;
            var missplaced = 1;

            var result = Mastermind.Evaluate(secret, guess);

            Assert.Equal(new Result(wellPlaced, missplaced), result);
        }


        [Theory]
        [InlineData(new[] { "blue", "red", "green" }, new[] { "yellow", "green", "red" })]
        public void ShouldDetectTwoMissplacedColor(string[] secret, string[] guess)
        {
            var wellPlaced = 0;
            var missplaced = 2;

            var result = Mastermind.Evaluate(secret, guess);

            Assert.Equal(new Result(wellPlaced, missplaced), result);
        }

        [Theory]
        [InlineData(new[] { "blue", "red", "yellow" }, new[] { "blue", "green", "red" })]
        public void ShouldDetectOneOfEach(string[] secret, string[] guess)
        {
            var wellPlaced = 1;
            var missplaced = 1;

            var result = Mastermind.Evaluate(secret, guess);

            Assert.Equal(new Result(wellPlaced, missplaced), result);
        }

        [Theory]
        [InlineData(new[] { "blue", "red", "yellow", "purple", "pink" }, new[] { "blue", "green", "red", "purple", "yellow" })]
        public void ShouldDetectTwoOfEach(string[] secret, string[] guess)
        {
            var wellPlaced = 2;
            var missplaced = 2;

            var result = Mastermind.Evaluate(secret, guess);

            Assert.Equal(new Result(wellPlaced, missplaced), result);
        }
    }
}
