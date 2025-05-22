
namespace Kata.Tests.Potter
{
    public class Store
    {
        private const int PricePerItem = 8;

        private List<Item> _items;
        private readonly Dictionary<int, double> Discounts;

        public Store() 
        {
            _items = new List<Item>();
            Discounts = new Dictionary<int, double>()
            {
                [0] = 0.0,
                [1] = 1.0,
                [2] = 0.95,
                [3] = 0.90,
                [4] = 0.80,
                [5] = 0.75
            };
        }

        public void AddToBasket(IList<Item> items)
        {
            _items.AddRange(items);
        }

        public double GetBaketCost()
        {
            double result = 0;
            var itemsLeft = _items.ToList();

            while (itemsLeft.Any()) 
            {
                var group = itemsLeft.GroupBy(g => g.Title).Select(g => g.First());

                int distinctCount = group.Count();
                result += distinctCount * PricePerItem * Discounts[distinctCount];

                foreach (var item in group)
                {
                    var toRemove = itemsLeft.First(i => i.Title == item.Title);
                    itemsLeft.Remove(toRemove);
                }
            }

            return result;
        }
    }
}