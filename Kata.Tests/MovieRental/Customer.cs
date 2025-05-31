using System.Text;

namespace Kata.Tests.MovieRental
{

    public class Customer
    {

        public string Name { get; private set; }

        private readonly List<Rental> _rentals = new();

        public Customer(string name)
        {
            Name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string statement()
        {
            var result = new StringBuilder();
            result.Append($"Rental Record for {Name}\n");

            double totalAmount = 0;
            int frequentRenterPoints = 0;

            foreach (Rental rental in _rentals)
            {
                var amount = rental.GetAmount();
                frequentRenterPoints += rental.GetFrequentRenterPoints();

                result.Append($"\t{rental.Movie.Title}\t{amount}\n");
                totalAmount += amount;
            }

            // add footer lines
            result.Append($"Amount owed is {totalAmount}\n");
            result.Append($"You earned {frequentRenterPoints} frequent renter points");

            return result.ToString();
        }
    }
}

