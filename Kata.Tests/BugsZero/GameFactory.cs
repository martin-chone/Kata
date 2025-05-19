using Kata.Tests.BugsZero.Domain.PenaltyBox;
using Kata.Tests.BugsZero.Domain.Players;
using Kata.Tests.BugsZero.Domain.Questions;
using Kata.Tests.BugsZero.Domain.Turn;
using Kata.Tests.BugsZero.Output;

namespace Kata.Tests.BugsZero
{
    public static class GameFactory
    {
        public static Game CreateDefaultGame()
        {
            var config = new GameConfig();
            var output = new ConsoleGameOutput();
            var playerManager = new PlayerManager();
            var questionService = new QuestionService(config.Categories, config.QuestionsPerCategory);
            var penaltyBoxService = new PenaltyBoxService();
            var turnService = new TurnService(penaltyBoxService, questionService, output, config.TotalPlaces);

            return new Game(config, playerManager, turnService, output);
        }
    }
}
