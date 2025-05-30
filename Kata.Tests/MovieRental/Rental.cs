namespace Kata.Tests.MovieRental
{
    public class Rental
    {
        public Movie Movie { get; private set; }
        public int RentalDaysNumber { get; private set; }

        public Rental(Movie movie, int daysNumber)
        {
            Movie = movie;
            RentalDaysNumber = daysNumber;
        }

        public double GetAmount()
        {
            switch (Movie.PriceCode)
            {
                case Movie.REGULAR:
                    return GetMovieRegularAmount();
                case Movie.NEW_RELEASE:
                    return GetMovieNewReleaseAmount();
                case Movie.CHILDRENS:
                    return GetMovieChildrensAmount();
                default:
                    return 0;
            }
        }

        private double GetMovieChildrensAmount()
        {
            double amount = 1.5;
            if (RentalDaysNumber > 3)
                amount += (RentalDaysNumber - 3) * 1.5;
            return amount;
        }

        private double GetMovieNewReleaseAmount()
        {
            return RentalDaysNumber * 3;
        }

        private double GetMovieRegularAmount()
        {
            double amount = 2;
            if (RentalDaysNumber > 2)
                amount += (RentalDaysNumber - 2) * 1.5;
            return amount;
        }

        public int GetBonusPoints()
        {
            int result = 0;

            if ((Movie.PriceCode == Movie.NEW_RELEASE) && RentalDaysNumber > 1)
                result++;

            return result;
        }
    }
}
