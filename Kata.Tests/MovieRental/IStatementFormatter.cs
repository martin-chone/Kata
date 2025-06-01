using System.Text;

namespace Kata.Tests.MovieRental
{
    public interface IStatementFormatter
    {
        public void Start(StringBuilder sb, string customerName);
        public void AddRental(StringBuilder sb, Rental rental, double amount);
        public void End(StringBuilder sb, double totalAmount, int points);
    }

    public class TextStatementFormatter : IStatementFormatter
    {
        public void Start(StringBuilder sb, string customerName)
        {
            sb.Append($"Rental Record for {customerName}\n");
        }

        public void AddRental(StringBuilder sb, Rental rental, double amount)
        {
            sb.Append($"\t{rental.Movie.Title}\t{amount}\n");
        }

        public void End(StringBuilder sb, double totalAmount, int points)
        {
            sb.Append($"Amount owed is {totalAmount}\n");
            sb.Append($"You earned {points} frequent renter points");
        }
    }

    public class HtmlStatementFormatter : IStatementFormatter
    {
        public void Start(StringBuilder sb, string customerName)
        {
            sb.Append($"<h1>Rental Record for <em>{customerName}</em></h1>");
            sb.Append("<table>");
        }

        public void AddRental(StringBuilder sb, Rental rental, double amount)
        {
            sb.Append($"<tr><td>{rental.Movie.Title}</td><td>{amount}</td></tr>");
        }

        public void End(StringBuilder sb, double totalAmount, int points)
        {
            sb.Append("</table>");
            sb.Append($"<p>Amount owed is <em>{totalAmount}</em></p>");
            sb.Append($"<p>You earned <em>{points}</em> frequent renter points</p>");
        }
    }
}
