using Kata.Tests.BugsZero.Domain.Players;

namespace Kata.Tests.BugsZero.Domain.PenaltyBox
{
    public class PenaltyBoxService
    {
        public bool CanPlayerExit(Player player, int roll) => roll % 2 != 0;

        public void HandleRoll(Player player, int roll)
        {
            if (!player.InPenaltyBox) return;

            player.IsExitingPenaltyBox = CanPlayerExit(player, roll);
        }

        public void SendToPenalty(Player player) => player.SendToPenaltyBox();

        public void ReleaseFromPenalty(Player player) => player.ReleaseFromPenaltyBox();
    }
}
