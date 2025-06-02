using System.Text;

namespace Kata.Tests.MovieRental
{
    public interface IStatementFormatter
    {
        void Start(StringBuilder sb, string customerName);
        void AddRental(StringBuilder sb, Rental rental, double amount);
        void End(StringBuilder sb, double totalAmount, int points);
    }

    public class TextStatementFormatter : IStatementFormatter
    {
        public void Start(StringBuilder sb, string customerName)
        {
            sb.AppendLine($"Rental Record for {customerName}");
        }

        public void AddRental(StringBuilder sb, Rental rental, double amount)
        {
            sb.AppendLine($"\t{rental.Movie.Title}\t{amount}");
        }

        public void End(StringBuilder sb, double totalAmount, int points)
        {
            sb.AppendLine($"Amount owed is {totalAmount}");
            sb.Append($"You earned {points} frequent renter points");
        }
    }

    public class HtmlStatementFormatter : IStatementFormatter
    {
        public void Start(StringBuilder sb, string customerName)
        {
            sb.Append($"<h1>Rental Record for <em>{customerName}</em></h1>");
            sb.Append("<table><tbody>");
        }

        public void AddRental(StringBuilder sb, Rental rental, double amount)
        {
            sb.Append($"<tr><td>{rental.Movie.Title}</td><td>{amount}</td></tr>");
        }

        public void End(StringBuilder sb, double totalAmount, int points)
        {
            sb.Append("</tbody></table>");
            sb.Append($"<p>Amount owed is <em>{totalAmount}</em></p>");
            sb.Append($"<p>You earned <em>{points}</em> frequent renter points</p>");
        }
    }
}
