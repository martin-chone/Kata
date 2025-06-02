using System.Text;
using System.Text.Json;

namespace Kata.Tests.MovieRental
{
    public interface IStatementFormatter
    {
        string Format(StatementDTO dto);
    }

    public class TextStatementFormatter : IStatementFormatter
    {
        public string Format(StatementDTO dto)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Rental Record for {dto.CustomerName}");

            foreach (var rental in dto.Rentals)
            {
                sb.AppendLine($"\t{rental.MovieTitle}\t{rental.Amount}");
            }

            sb.AppendLine($"Amount owed is {dto.TotalAmount}");
            sb.Append($"You earned {dto.FrequentRenterPoints} frequent renter points");

            return sb.ToString();
        }
    }

    public class HtmlStatementFormatter : IStatementFormatter
    {
        public string Format(StatementDTO dto)
        {
            var sb = new StringBuilder();

            sb.Append($"<h1>Rental Record for <em>{dto.CustomerName}</em></h1>");
            sb.Append("<table><tbody>");

            foreach (var rental in dto.Rentals)
            {
                sb.Append($"<tr><td>{rental.MovieTitle}</td><td>{rental.Amount}</td></tr>");
            }

            sb.Append("</tbody></table>");
            sb.Append($"<p>Amount owed is <em>{dto.TotalAmount}</em></p>");
            sb.Append($"<p>You earned <em>{dto.FrequentRenterPoints}</em> frequent renter points</p>");

            return sb.ToString();
        }
    }

    public class JsonStatementFormatter : IStatementFormatter
    {
        public string Format(StatementDTO dto)
        {
            return JsonSerializer.Serialize(dto);
        }
    }
}
