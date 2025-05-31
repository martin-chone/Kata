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
            return Movie.GetAmount(RentalDaysNumber);
        }

        public int GetFrequentRenterPoints()
        {
            return Movie.GetFrequentRenterPoints(RentalDaysNumber);
        }
    }
}
