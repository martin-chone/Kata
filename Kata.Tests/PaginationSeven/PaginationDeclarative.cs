
namespace Kata.Tests.PaginationSeven
{
    public static class PaginationDeclarative
    {
        private const int MaxVisible = 7;
        private const int EdgePageCount = 5;
        private const string Ellipsis = "...";

        public static string Build(int current, int total)
        {
            if (current < 1 || current > total || total < 1)
                throw new ArgumentOutOfRangeException();

            IEnumerable<string> result =
                total <= MaxVisible
                    ? Range(current, 1, total)
                    : Leading(current)
                        ? Range(current, 1, EdgePageCount)
                            .Append(Ellipsis)
                            .Append($"{total}")
                        : Trailing(current, total - (EdgePageCount - 1))
                            ? new[] { "1", Ellipsis }
                                .Concat(Range(current, total - (EdgePageCount - 1), total))
                            : new[] { "1", Ellipsis }
                                .Concat(Range(current, current - 1, current + 1))
                                .Append(Ellipsis)
                                .Append($"{total}");

            return string.Join(" ", result);
        }

        private static IEnumerable<string> Range(int current, int from, int to)
        {
            return Enumerable.Range(from, to - from + 1)
                .Select(i => i == current ? $"({i})" : $"{i}");
        }

        private static bool Leading(int current) => current < EdgePageCount;

        private static bool Trailing(int current, int tailStart) => current > tailStart;
    }
}