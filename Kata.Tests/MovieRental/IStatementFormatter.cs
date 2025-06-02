using System.Text;
using System.Text.Json;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Kata.Tests.MovieRental
{
    public interface IStatementFormatter<out T>
    {
        T Format(StatementDTO dto);
    }

    public class TextStatementFormatter : IStatementFormatter<string>
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

    public class HtmlStatementFormatter : IStatementFormatter<string>
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

    public class JsonStatementFormatter : IStatementFormatter<string>
    {
        public string Format(StatementDTO dto)
        {
            return JsonSerializer.Serialize(dto);
        }
    }

    public class PdfStatementFormatter : IStatementFormatter<byte[]>
    {
        public byte[] Format(StatementDTO dto)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                        .Text($"Rental Record for {dto.CustomerName}")
                        .FontSize(20)
                        .Bold();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.ConstantColumn(100);
                        });

                        // En-tête
                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("Movie Title").Bold();
                            header.Cell().Element(CellStyle).AlignRight().Text("Amount").Bold();
                        });

                        // Contenu
                        foreach (var rental in dto.Rentals)
                        {
                            table.Cell().Element(CellStyle).Text(rental.MovieTitle);
                            table.Cell().Element(CellStyle).AlignRight().Text($"{rental.Amount:0.00}");
                        }

                        static IContainer CellStyle(IContainer container) =>
                            container.PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                    });

                    page.Footer().Column(col =>
                    {
                        col.Item().Text($"Total amount: {dto.TotalAmount:0.00}").Bold();
                        col.Item().Text($"Frequent renter points: {dto.FrequentRenterPoints}").Bold();
                    });
                });
            });

            return document.GeneratePdf();
        }
    }
}
