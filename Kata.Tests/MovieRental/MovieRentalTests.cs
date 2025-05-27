namespace Kata.Tests.MovieRental
{
    public class MovieRentalTests
    {
        [Fact]
        public void Test1()
        {
            Customer customer = new Customer("Bob");
            customer.addRental(new Rental(new Movie("Jaws", Movie.REGULAR), 2));
            customer.addRental(new Rental(new Movie("Short New", Movie.NEW_RELEASE), 1));
            customer.addRental(new Rental(new Movie("Long New", Movie.NEW_RELEASE), 2));
            customer.addRental(new Rental(new Movie("Toy Story", Movie.CHILDRENS), 4));

            String expected = "" +
                "Rental Record for Bob\n" +
                "\tJaws\t2\n" +
                "\tShort New\t3\n" +
                "\tLong New\t6\n" +
                "\tToy Story\t3\n" +
                "Amount owed is 14\n" +
                "You earned 5 frequent renter points";

            Assert.Equal(expected, customer.statement());
        }
    }
}
