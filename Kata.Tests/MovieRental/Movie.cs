namespace Kata.Tests.MovieRental
{
    public abstract class Movie
    {
        public string Title { get; private set; }

        public Movie(String title)
        {
            Title = title;
        }

        public abstract double GetAmount(int rentalDaysNumber);

        public virtual int GetFrequentRenterPoints(int rentalDaysNumber) => 1;

    }

    public class RegularMovie : Movie
    {
        public RegularMovie(string title) : base(title) {}

        public override double GetAmount(int rentalDaysNumber)
        {
            double result = 2;

            if (rentalDaysNumber > 2)
                result += (rentalDaysNumber - 2) * 1.5;

            return result;
        }
    }

    public class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title) : base(title) { }

        public override double GetAmount(int rentalDaysNumber)
        {
            return rentalDaysNumber * 3;
        }

        public override int GetFrequentRenterPoints(int rentalDaysNumber)
        {
            return rentalDaysNumber > 1 ? 2 : 1;
        }
    }

    public class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title) : base(title) { }

        public override double GetAmount(int rentalDaysNumber)
        {
            double result = 1.5;

            if (rentalDaysNumber > 3)
                result += (rentalDaysNumber - 3) * 1.5;

            return result;
        }
    }
}