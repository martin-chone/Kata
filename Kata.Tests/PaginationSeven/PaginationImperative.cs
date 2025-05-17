
namespace Kata.Tests.PaginationSeven
{
    public static class PaginationImperative
    {
        private static readonly int MaxVisible = 7;
        private const int EdgePageCount = 5;
        private const string Ellipsis = "...";

        public static string Build(int current, int total)
        {
            if (current < 1 || current > total || total < 1)
                throw new ArgumentOutOfRangeException();

            if (total <= MaxVisible)
                return BuildRange(current, 1, total);

            int leadStart = 1;
            int tailStart = total - (EdgePageCount - 1);

            if (InLeadingRange(current)) 
                return $"{BuildRange(current, leadStart, EdgePageCount)} {Ellipsis} {total}";

            if (InTrailingRange(current, tailStart))
                return $"{leadStart} {Ellipsis} {BuildRange(current, tailStart, total)}";

            return $"{leadStart} {Ellipsis} {BuildRange(current, current -1, current + 1)} {Ellipsis} {total}"; 
        }

        private static string BuildRange(int current, int from, int to)
        {
            var parts = new List<string>();
            for (int i = from; i <= to; i++)
                parts.Add((i == current) ? $"({i})" : $"{i}");

            return string.Join(" ", parts);
        }

        private static bool InLeadingRange(int current) => current < EdgePageCount;

        private static bool InTrailingRange(int current, int tailStart) => current > tailStart;
    }
}