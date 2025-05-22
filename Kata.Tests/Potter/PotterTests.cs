namespace Kata.Tests.Potter
{
    public class PotterTests
    {
        [Theory]
        [InlineData(2, 16)]
        [InlineData(3, 24)]
        [InlineData(4, 32)]
        [InlineData(5, 40)]
        public void ShouldCostOfSameBooks(int number, double cost)
        {
            var store = new Store();

            var list = new List<Item>();
            for (int i = 1; i <= number; i++)
                list.Add(new Item($"L{1}"));

            store.AddToBasket(list);

            Assert.Equal(cost, store.GetBaketCost());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 8)]
        [InlineData(2, 15.2)]
        [InlineData(3, 21.6)]
        [InlineData(4, 25.6)]
        [InlineData(5, 30)]
        public void ShouldCostOfDifferentBooks(int number, double cost)
        {
            var store = new Store();

            var list = new List<Item>();
            for (int i = 1; i <= number; i++)
                list.Add(new Item($"L{i}"));

            store.AddToBasket(list);

            Assert.Equal(cost, store.GetBaketCost());
        }

        [Fact]
        public void ShouldCostOfSeveralBooks()
        {
            var store = new Store();

            var list = new List<Item>();
            list.Add(new Item($"L{0}"));
            list.Add(new Item($"L{0}"));
            list.Add(new Item($"L{1}"));

            store.AddToBasket(list);

            Assert.Equal(8 + (8 * 2 * 0.95), store.GetBaketCost());
        }
    }
}
