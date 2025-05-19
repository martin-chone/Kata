using Kata.Tests.BugsZero.Domain.Questions;

namespace Kata.Tests.BugsZero
{
    public class GameConfig
    {
        public int TotalPlaces { get; init; } = 12;
        public int WinningsThreshold { get; init; } = 6;
        public int PlayerMinimumNumber { get; init; } = 2;
        public int QuestionsPerCategory { get; init; } = 50;
        public List<Category> Categories { get; init; } = new()
        {
            new("Pop"), new("Science"), new("Sports"), new("Rock")
        };
    }
}
