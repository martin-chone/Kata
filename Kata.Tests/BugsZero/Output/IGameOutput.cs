namespace Kata.Tests.BugsZero.Output
{
    public interface IGameOutput
    {
        void PlayerAdded(string playerName, int playerNumber);
        void ShowCurrentPlayer(string playerName);
        void ShowRoll(int roll);
        void ShowNewLocation(string playerName, int place);
        void ShowCategory(string categoryName);
        void ShowQuestion(string question);
        void ShowCorrectAnswer();
        void ShowIncorrectAnswer();
        void EnterPenaltyBox(string playerName);
        void ExitPenaltyBox(string playerName, bool isExiting);
        void ShowPlayerPurse(string playerName, int purse);
    }
}
