namespace Kata.Tests.MovieRental
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int NEW_RELEASE = 1;
        public const int REGULAR = 0;

        public String Title { get; set; }
        public int PriceCode { get; set; }

        public Movie(String title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

    }
}