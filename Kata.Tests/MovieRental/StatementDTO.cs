namespace Kata.Tests.MovieRental
{
    public class StatementDTO
    {
        public string CustomerName { get; private set; }
        public IList<StatementRentalLineDto> Rentals { get; set; }
        public double TotalAmount { get; set; }
        public int FrequentRenterPoints { get; set; }

        public StatementDTO(string customerName) 
        { 
            CustomerName = customerName;
            Rentals = new List<StatementRentalLineDto>();
        }
    }

    public record StatementRentalLineDto(string MovieTitle, double Amount);
}
