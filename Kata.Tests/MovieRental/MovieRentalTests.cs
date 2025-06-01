namespace Kata.Tests.MovieRental
{
    public class MovieRentalTests
    {
        [Fact]
        public void ShouldRentalTextStatementFormat()
        {
            Customer customer = new Customer("Bob");
            customer.AddRental(new Rental(new RegularMovie("Jaws"), 2));
            customer.AddRental(new Rental(new NewReleaseMovie("Short New"), 1));
            customer.AddRental(new Rental(new NewReleaseMovie("Long New"), 2));
            customer.AddRental(new Rental(new ChildrensMovie("Toy Story"), 4));

            String expected = "" +
                "Rental Record for Bob\n" +
                "\tJaws\t2\n" +
                "\tShort New\t3\n" +
                "\tLong New\t6\n" +
                "\tToy Story\t3\n" +
                "Amount owed is 14\n" +
                "You earned 5 frequent renter points";

            Assert.Equal(expected, customer.Statement(new TextStatementFormatter()));
        }

        [Fact]
        public void ShouldRentalHtmlStatementFormat()
        {
            Customer customer = new Customer("Bob");
            customer.AddRental(new Rental(new RegularMovie("Jaws"), 2));
            customer.AddRental(new Rental(new NewReleaseMovie("Short New"), 1));
            customer.AddRental(new Rental(new NewReleaseMovie("Long New"), 2));
            customer.AddRental(new Rental(new ChildrensMovie("Toy Story"), 4));

            string expected = "" +
                "<h1>Rental Record for <em>Bob</em></h1>" +
                "<table>" +
                  "<tr><td>Jaws</td><td>2</td></tr>" +
                  "<tr><td>Short New</td><td>3</td></tr>" +
                  "<tr><td>Long New</td><td>6</td></tr>" +
                  "<tr><td>Toy Story</td><td>3</td></tr>" +
                "</table>" +
                "<p>Amount owed is <em>14</em></p>" +
                "<p>You earned <em>5</em> frequent renter points</p>";

            Assert.Equal(expected, customer.Statement(new HtmlStatementFormatter()));
        }
    }
}
