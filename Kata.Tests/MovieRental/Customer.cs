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

        public void AddRental(Rental rental) => _rentals.Add(rental);

        public string Statement(IStatementFormatter formatter)
        {
            var sb = new StringBuilder();
            formatter.Start(sb, Name);

            double totalAmount = 0;
            int frequentRenterPoints = 0;

            foreach (Rental rental in _rentals)
            {
                var amount = rental.GetAmount();
                frequentRenterPoints += rental.GetFrequentRenterPoints();

                totalAmount += amount;

                formatter.AddRental(sb, rental, amount);
            }

            formatter.End(sb, totalAmount, frequentRenterPoints);

            return sb.ToString();
        }
    }
}

