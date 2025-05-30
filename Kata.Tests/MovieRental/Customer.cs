using System.Text;

namespace Kata.Tests.MovieRental
{

    public class Customer
    {

        public string Name { get; private set; }

        private List<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public void addRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string statement()
        {
            var result = new StringBuilder();
            result.Append($"Rental Record for {Name}\n");

            double totalAmount = CalculateTotalAmount();
            int frequentRenterPoints = GetFrequentRenterPoints();

            foreach (Rental rental in rentals)
            {
                var amount = CalculateRentalAmount(rental);

                AppendRentalInformation(result, rental, amount);
            }

            // add footer lines
            result.Append($"Amount owed is {totalAmount}\n");
            result.Append($"You earned {frequentRenterPoints} frequent renter points");

            return result.ToString();
        }

        private void AppendRentalInformation(StringBuilder sb, Rental rental, double amount)
        {
            sb.Append($"\t{rental.Movie.Title}\t{amount}\n");
        }

        private int GetFrequentRenterPoints()
        {
            int frequentRenterPoints = 0;

            foreach (Rental rental in rentals)
            {
                frequentRenterPoints++;
                frequentRenterPoints = AddBonus(frequentRenterPoints, rental);
            }
            return frequentRenterPoints;
        }

        private int AddBonus(int frequentRenterPoints, Rental rental)
        {
            if ((rental.Movie.PriceCode == Movie.NEW_RELEASE) && rental.DaysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        private double CalculateTotalAmount()
        {
            double amount = 0;

            foreach (Rental rental in rentals)
            {
                amount += CalculateRentalAmount(rental);
            }

            return amount;
        }

        private double CalculateRentalAmount(Rental rental)
        {
            switch (rental.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    return GetMovieRegularAmount(rental);
                case Movie.NEW_RELEASE:
                    return GetMovieNewReleaseAmount(rental);
                case Movie.CHILDRENS:
                    return GetMovieChildrensAmount(rental);
                default:
                    return 0;
            }
        }

        private double GetMovieChildrensAmount(Rental each)
        {
            double amount = 1.5;
            if (each.DaysRented > 3)
                amount += (each.DaysRented - 3) * 1.5;
            return amount;
        }

        private double GetMovieNewReleaseAmount(Rental each)
        {
            return each.DaysRented * 3;
        }

        private double GetMovieRegularAmount(Rental each)
        {
            double amount = 2;
            if (each.DaysRented > 2)
                amount += (each.DaysRented - 2) * 1.5;
            return amount;
        }
    }
}

