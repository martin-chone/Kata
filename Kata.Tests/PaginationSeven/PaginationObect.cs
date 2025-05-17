
namespace Kata.Tests.PaginationSeven
{
    public class PaginationObject
    {
        private const int MaxVisible = 7;
        private const int EdgePageCount = 5;

        private readonly int Current;
        private readonly int Total;

        public PaginationObject(int current, int total)
        {
            Current = current;
            Total = total;
        }

        public string Render()
        {
            var items = Build();
            
            return string.Join(" ", items.Select(i => i.Render()));
        }

        private IList<IPageItem> Build()
        {
            var items = new List<IPageItem>();

            if (Total <= MaxVisible)
            {
                items.AddRange(Range(1, Total));
            }
            else if (Current < EdgePageCount)
            {
                items.AddRange(Range(1, EdgePageCount));
                items.Add(new EllipsisItem());
                items.Add(new PageNumber(Total, false));
            }
            else if (Current > Total - (EdgePageCount - 1))
            {
                items.Add(new PageNumber(1, false));
                items.Add(new EllipsisItem());
                items.AddRange(Range(Total - (EdgePageCount - 1), Total));
            }
            else
            {
                items.Add(new PageNumber(1, false));
                items.Add(new EllipsisItem());
                items.AddRange(Range(Current - 1, Current + 1));
                items.Add(new EllipsisItem());
                items.Add(new PageNumber(Total, false));
            }

            return items;
        }

        private IEnumerable<IPageItem> Range(int from, int to) => 
            Enumerable
                .Range(from, to - from + 1)
                .Select(i => new PageNumber(i, i == Current));
    }
}