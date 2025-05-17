namespace Kata.Tests.PaginationSeven
{
    public class PaginationSevenTests
    {
        [Theory]
        [InlineData(1, 1, "(1)")]
        [InlineData(1, 7, "(1) 2 3 4 5 6 7")]
        [InlineData(2, 7, "1 (2) 3 4 5 6 7")]
        [InlineData(3, 7, "1 2 (3) 4 5 6 7")]
        [InlineData(6, 7, "1 2 3 4 5 (6) 7")]
        [InlineData(2, 5, "1 (2) 3 4 5")]
        [InlineData(5, 9, "1 ... 4 (5) 6 ... 9")]
        [InlineData(42, 100, "1 ... 41 (42) 43 ... 100")]
        [InlineData(2, 9, "1 (2) 3 4 5 ... 9")]
        [InlineData(4, 9, "1 2 3 (4) 5 ... 9")]
        [InlineData(6, 9, "1 ... 5 (6) 7 8 9")]
        [InlineData(8, 9, "1 ... 5 6 7 (8) 9")]
        [InlineData(102, 102, "1 ... 98 99 100 101 (102)")]
        public void ShouldCurrentPageOfTotalPagesImperative(int current, int total, string expected)
        {
            Assert.Equal(expected, PaginationImperative.Build(current, total));
        }

        [Theory]
        [InlineData(0, 9)]
        [InlineData(9, 7)]
        [InlineData(3, 0)]
        public void ShouldThrowWhenOutOfLimitsImperative(int current, int total)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                PaginationImperative.Build(current, total));
        }

        [Theory]
        [InlineData(1, 1, "(1)")]
        [InlineData(1, 7, "(1) 2 3 4 5 6 7")]
        [InlineData(2, 7, "1 (2) 3 4 5 6 7")]
        [InlineData(3, 7, "1 2 (3) 4 5 6 7")]
        [InlineData(6, 7, "1 2 3 4 5 (6) 7")]
        [InlineData(2, 5, "1 (2) 3 4 5")]
        [InlineData(5, 9, "1 ... 4 (5) 6 ... 9")]
        [InlineData(42, 100, "1 ... 41 (42) 43 ... 100")]
        [InlineData(2, 9, "1 (2) 3 4 5 ... 9")]
        [InlineData(4, 9, "1 2 3 (4) 5 ... 9")]
        [InlineData(6, 9, "1 ... 5 (6) 7 8 9")]
        [InlineData(8, 9, "1 ... 5 6 7 (8) 9")]
        [InlineData(102, 102, "1 ... 98 99 100 101 (102)")]
        public void ShouldCurrentPageOfTotalPagesFunctional(int current, int total, string expected)
        {
            Assert.Equal(expected, PaginationFunctional.Build(current, total));
        }

        [Theory]
        [InlineData(0, 9)]
        [InlineData(9, 7)]
        [InlineData(3, 0)]
        public void ShouldThrowWhenOutOfLimitsFunctional(int current, int total)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                PaginationFunctional.Build(current, total));
        }

        [Theory]
        [InlineData(1, 1, "(1)")]
        [InlineData(1, 7, "(1) 2 3 4 5 6 7")]
        [InlineData(2, 7, "1 (2) 3 4 5 6 7")]
        [InlineData(3, 7, "1 2 (3) 4 5 6 7")]
        [InlineData(6, 7, "1 2 3 4 5 (6) 7")]
        [InlineData(2, 5, "1 (2) 3 4 5")]
        [InlineData(5, 9, "1 ... 4 (5) 6 ... 9")]
        [InlineData(42, 100, "1 ... 41 (42) 43 ... 100")]
        [InlineData(2, 9, "1 (2) 3 4 5 ... 9")]
        [InlineData(4, 9, "1 2 3 (4) 5 ... 9")]
        [InlineData(6, 9, "1 ... 5 (6) 7 8 9")]
        [InlineData(8, 9, "1 ... 5 6 7 (8) 9")]
        [InlineData(102, 102, "1 ... 98 99 100 101 (102)")]
        public void ShouldCurrentPageOfTotalPagesDeclarative(int current, int total, string expected)
        {
            Assert.Equal(expected, PaginationDeclarative.Build(current, total));
        }

        [Theory]
        [InlineData(0, 9)]
        [InlineData(9, 7)]
        [InlineData(3, 0)]
        public void ShouldThrowWhenOutOfLimitsDeclarative(int current, int total)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                PaginationDeclarative.Build(current, total));
        }

        [Theory]
        [InlineData(1, 1, "(1)")]
        [InlineData(1, 7, "(1) 2 3 4 5 6 7")]
        [InlineData(2, 7, "1 (2) 3 4 5 6 7")]
        [InlineData(3, 7, "1 2 (3) 4 5 6 7")]
        [InlineData(6, 7, "1 2 3 4 5 (6) 7")]
        [InlineData(2, 5, "1 (2) 3 4 5")]
        [InlineData(2, 9, "1 (2) 3 4 5 ... 9")]
        [InlineData(4, 9, "1 2 3 (4) 5 ... 9")]
        [InlineData(6, 9, "1 ... 5 (6) 7 8 9")]
        [InlineData(8, 9, "1 ... 5 6 7 (8) 9")]
        [InlineData(5, 9, "1 ... 4 (5) 6 ... 9")]
        public void ShouldCurrentPageOfTotalPagesObject(int current, int total, string expected)
        {
            var pagination = new PaginationObject(current, total);
            var result = pagination.Render();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 9)]
        [InlineData(9, 7)]
        [InlineData(3, 0)]
        public void ShouldThrowWhenOutOfLimitsObject(int current, int total)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new PaginationObject(current, total).Render());
        }
    }
}
