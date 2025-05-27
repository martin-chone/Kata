namespace Kata.Tests.MovieRental
{

    public class Customer
    {

        public string Name { get; private set; }

        private List<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public void addRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + Name + "\n";

            foreach (Rental each in rentals)
            {
                double thisAmount = 0;

                //determine amounts for each line
                switch (each.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.Movie.PriceCode == Movie.NEW_RELEASE) && each.DaysRented > 1)
                    frequentRenterPoints++;

                // show figures for this rental
                result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }
    }
}

