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

        public StatementDTO CreateStatement()
        {
            var dto = new StatementDTO(Name);

            foreach (Rental rental in _rentals)
            {
                var amount = rental.GetAmount();
                var points = rental.GetFrequentRenterPoints();

                dto.Rentals.Add(new StatementRentalLineDto(rental.Movie.Title, amount));
                dto.TotalAmount += amount;
                dto.FrequentRenterPoints += points;
            }

            return dto;
        }
    }
}

