
namespace Kata.Tests.PaginationSeven
{
    public static class Pagination
    {
        public static string GetSeven(int current, int total)
        {
            if (total > 7) 
            {
                if(current < 5) return $"{Format(current, 1, 5)} ... {total}";

                if (current > total - 4)
                    return $"1 ... {Format(current, total - 4, total)}";

                return $"1 ... {current - 1} ({current}) {current + 1} ... {total}"; 
            }

            return Format(current, 1, total);
        }

        private static string Format(int current, int from, int to)
        {
            IList<string> parts = new List<string>();
            for (int i = from; i <= to; i++)
                parts.Add((i == current) ? $"({i})" : $"{i}");

            return string.Join(" ", parts);
        }
    }
}