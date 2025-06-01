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

        public string TextStatement()
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

            result.Append($"Amount owed is {totalAmount}\n");
            result.Append($"You earned {frequentRenterPoints} frequent renter points");

            return result.ToString();
        }

        public string HtmlStatement()
        {
            var result = new StringBuilder();
            result.Append($"<h1>Rental Record for <em>{Name}</em></h1>");
            result.Append("<table>");

            double totalAmount = 0;
            int frequentRenterPoints = 0;

            foreach (Rental rental in _rentals)
            {
                var amount = rental.GetAmount();
                frequentRenterPoints += rental.GetFrequentRenterPoints();

                result.Append($"<tr><td>{rental.Movie.Title}</td><td>{amount}</td></tr>");
                totalAmount += amount;
            }

            result.Append("</table>");

            result.Append($"<p>Amount owed is <em>{totalAmount}</em></p>");
            result.Append($"<p>You earned <em>{frequentRenterPoints}</em> frequent renter points</p>");

            return result.ToString();
        }
    }
}

