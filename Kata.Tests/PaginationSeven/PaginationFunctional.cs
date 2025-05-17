
namespace Kata.Tests.PaginationSeven
{
    public static class PaginationFunctional
    {
        private const int MaxVisible = 7;
        private const int EdgePageCount = 5;
        private const string Ellipsis = "...";

        public static string Build(int current, int total)
        {
            return (current < 1 || current > total || total < 1)
                ? throw new ArgumentOutOfRangeException()
                : total <= MaxVisible
                    ? Range(current, 1, total)
                    : Leading(current)
                        ? $"{Range(current, 1, EdgePageCount)} {Ellipsis} {total}"
                        : Trailing(current, total - (EdgePageCount - 1))
                            ? $"1 {Ellipsis} {Range(current, total - (EdgePageCount - 1), total)}"
                            : $"1 {Ellipsis} {Range(current, current - 1, current + 1)} {Ellipsis} {total}";
        }

        private static string Range(int current, int from, int to)
        {
            return Enumerable.Range(from, to - from + 1)
                .Select(i => i == current ? $"({i})" : $"{i}")
                .Aggregate((a, b) => $"{a} {b}");
        }

        private static bool Leading(int current) => current < EdgePageCount;

        private static bool Trailing(int current, int tailStart) => current > tailStart;
    }
}