namespace Kata.Tests.MovieRental
{
    public class MovieRentalTests
    {
        [Fact]
        public void Test1()
        {
            Customer customer = new Customer("Bob");
            customer.addRental(new Rental(new RegularMovie("Jaws"), 2));
            customer.addRental(new Rental(new NewReleaseMovie("Short New"), 1));
            customer.addRental(new Rental(new NewReleaseMovie("Long New"), 2));
            customer.addRental(new Rental(new ChildrensMovie("Toy Story"), 4));

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
