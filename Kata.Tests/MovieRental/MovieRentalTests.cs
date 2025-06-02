using System.Text;
using System.Text.Json;

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

            var expected = new StringBuilder()
                .AppendLine("Rental Record for Bob")
                .AppendLine("\tJaws\t2")
                .AppendLine("\tShort New\t3")
                .AppendLine("\tLong New\t6")
                .AppendLine("\tToy Story\t3")
                .AppendLine("Amount owed is 14")
                .Append("You earned 5 frequent renter points")
                .ToString();

            var dto = customer.CreateStatement();
            var text = new TextStatementFormatter().Format(dto);

            Assert.Equal(expected, text);
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
                "<table><tbody>" +
                  "<tr><td>Jaws</td><td>2</td></tr>" +
                  "<tr><td>Short New</td><td>3</td></tr>" +
                  "<tr><td>Long New</td><td>6</td></tr>" +
                  "<tr><td>Toy Story</td><td>3</td></tr>" +
                "</tbody></table>" +
                "<p>Amount owed is <em>14</em></p>" +
                "<p>You earned <em>5</em> frequent renter points</p>";

            var dto = customer.CreateStatement();
            var html = new HtmlStatementFormatter().Format(dto);

            Assert.Equal(expected, html);
        }

        [Fact]
        public void ShouldRentalJsonStatementFormat()
        {
            Customer customer = new Customer("Bob");
            customer.AddRental(new Rental(new RegularMovie("Jaws"), 2));
            customer.AddRental(new Rental(new NewReleaseMovie("Short New"), 1));
            customer.AddRental(new Rental(new NewReleaseMovie("Long New"), 2));
            customer.AddRental(new Rental(new ChildrensMovie("Toy Story"), 4));

            var dto = customer.CreateStatement();
            var json = new JsonStatementFormatter().Format(dto);

            var deserialized = JsonSerializer.Deserialize<StatementDTO>(json);

            Assert.Equal("Bob", deserialized.CustomerName);
            Assert.Equal(14, deserialized.TotalAmount);
            Assert.Equal(5, deserialized.FrequentRenterPoints);
            Assert.Equal(4, deserialized.Rentals.Count);
            Assert.Equal("Jaws", deserialized.Rentals[0].MovieTitle);
            Assert.Equal(2, deserialized.Rentals[0].Amount);

        }
    }
}
