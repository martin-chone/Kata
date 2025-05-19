using Kata.Tests.BugsZero.Domain.PenaltyBox;
using Kata.Tests.BugsZero.Domain.Players;
using Kata.Tests.BugsZero.Domain.Questions;
using Kata.Tests.BugsZero.Output;

namespace Kata.Tests.BugsZero.Domain.Turn
{
    public class TurnService
    {
        private readonly PenaltyBoxService _penaltyBoxService;
        private readonly QuestionService _questionService;
        private readonly IGameOutput _output;
        private readonly int _totalPlaces;

        public TurnService(PenaltyBoxService penaltyBoxService, QuestionService questionService, IGameOutput output, int totalPlaces)
        {
            _penaltyBoxService = penaltyBoxService;
            _questionService = questionService;
            _output = output;
            _totalPlaces = totalPlaces;
        }

        public void HandleRoll(Player player, int roll)
        {
            _output.ShowCurrentPlayer(player.Name);
            _output.ShowRoll(roll);

            if (player.InPenaltyBox)
            {
                _penaltyBoxService.HandleRoll(player, roll);
                _output.ExitPenaltyBox(player.Name, player.IsExitingPenaltyBox);
            }

            if (!player.InPenaltyBox || player.IsExitingPenaltyBox)
            {
                MoveAndAskQuestion(player, roll);
            }
        }

        private void MoveAndAskQuestion(Player player, int roll)
        {
            player.Move(roll, _totalPlaces);
            _output.ShowNewLocation(player.Name, player.Place);

            var category = _questionService.GetCategoryForPlace(player.Place);
            _output.ShowCategory(category.Name);

            var question = _questionService.GetNextQuestion(category);
            _output.ShowQuestion(question.Text);
        }

        public bool HandleCorrectAnswer(Player player, int winningThreshold)
        {
            var continueGame = true;

            if (player.InPenaltyBox && !player.IsExitingPenaltyBox)
                return continueGame;

            _penaltyBoxService.ReleaseFromPenalty(player);

            _output.ShowCorrectAnswer();
            player.Reward();

            _output.ShowPlayerPurse(player.Name, player.Purse);

            continueGame = !player.HasWon(winningThreshold);

            return continueGame;
        }

        public void HandleWrongAnswer(Player player)
        {
            _output.ShowIncorrectAnswer();
            _penaltyBoxService.SendToPenalty(player);
            _output.EnterPenaltyBox(player.Name);
        }
    }
}
