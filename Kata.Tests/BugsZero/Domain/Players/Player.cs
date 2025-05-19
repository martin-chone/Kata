namespace Kata.Tests.BugsZero.Domain.Players
{
    public class Player
    {
        public string Name { get; }
        public int Place { get; private set; }
        public int Purse { get; private set; }
        public bool InPenaltyBox { get; private set; }
        public bool IsExitingPenaltyBox { get; set; }


        public Player(string name) 
        {
            Name = name;
            Place = 0;
            Purse = 0;
            InPenaltyBox = false;
            IsExitingPenaltyBox = false;
        }

        public void SendToPenaltyBox() => InPenaltyBox = true;

        public void ReleaseFromPenaltyBox() => InPenaltyBox = false;

        public void Reward() => Purse++;

        public void Move(int roll, int totalPlaces) => Place = (Place + roll) % totalPlaces;

        public bool HasWon(int winningsThreshold) => Purse >= winningsThreshold;
    }
}
