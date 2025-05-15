namespace Kata.Tests.PaginationSeven
{
    public class PaginationSevenTests
    {
        [Theory]
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
        public void ShouldCurrentPageOfTotalPages(int input, int total, string expected)
        {
            Assert.Equal(expected, Pagination.GetSeven(input, total));
        }
    }
}
