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
        public void ShouldCurrentPageOfTotalPages(int current, int total, string expected)
        {
            Assert.Equal(expected, Pagination.Build(current, total));
        }

        [Theory]
        [InlineData(0, 9)]
        [InlineData(9, 7)]
        [InlineData(3, 0)]
        public void ShouldThrowWhenOutOfLimits(int current, int total)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                Pagination.Build(current, total));
        }
    }
}
