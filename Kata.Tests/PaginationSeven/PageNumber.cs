namespace Kata.Tests.PaginationSeven
{
    public class PageNumber : IPageItem
    {
        private readonly int Number;
        private readonly bool IsCurrent;

        public PageNumber(int number, bool isCurrent)
        {
            Number = number;
            IsCurrent = isCurrent;
        }

        public string Render() => IsCurrent ? $"({Number})" : $"{Number}";
    }
}
