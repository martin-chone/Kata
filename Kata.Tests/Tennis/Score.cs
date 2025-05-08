namespace Kata.Tests.Tennis
{
    public class Score
    {
        public int ServerPoints { get; private set; }
        public int ReceiverPoints { get; private set; }

        private readonly Dictionary<int, string> PointRules;

        private readonly int MaxPointValue;
        private readonly string MaxPointLabel;

        public Score(int serverPoints, int receiverPoints)
        {
            ServerPoints = serverPoints;
            ReceiverPoints = receiverPoints;
            PointRules = new Dictionary<int, string>()
            {
                { 0, "0" },
                { 1, "15" },
                { 2, "30" },
                { 3, "40" }
            };

            MaxPointValue = PointRules.Keys.Max();
            MaxPointLabel = PointRules[MaxPointValue];
        }

        public void AddPointToServer() => ServerPoints++;

        public void AddPointToReceiver() => ReceiverPoints++;

        public string GetScoreDisplay() 
        {
            if (IsDeuceOrBeyond())
            {
                if (ServerPoints == ReceiverPoints) return GetEqualScoreDisplay();
                if (ServerPoints == ReceiverPoints + 1) return GetAdvantageDisplay(true);
                if (ReceiverPoints == ServerPoints + 1) return GetAdvantageDisplay(false);
            }

            if (ServerHasWon()) return GetWinnerDisplay(true);
            if (ReceiverHasWon()) return GetWinnerDisplay(false);

            return $"{GetPointDisplay(ServerPoints)}-{GetPointDisplay(ReceiverPoints)}";
        }

        private bool IsDeuceOrBeyond() =>
            ServerPoints >= MaxPointValue && ReceiverPoints >= MaxPointValue;

        private bool ServerHasWon() =>
            ServerPoints >= MaxPointValue + 1 && ServerPoints >= ReceiverPoints + 2;

        private bool ReceiverHasWon() =>
            ReceiverPoints >= MaxPointValue + 1 && ReceiverPoints >= ServerPoints + 2;

        private string GetEqualScoreDisplay() => $"{MaxPointLabel}A";

        private string GetAdvantageDisplay(bool serverHasAdvantage)
            => serverHasAdvantage ? $"Advantage-{MaxPointLabel}" : $"{MaxPointLabel}-Advantage";

        private string GetWinnerDisplay(bool serverWins) 
            => serverWins 
            ? $"Winner-{GetPointDisplay(ReceiverPoints)}" 
            : $"{GetPointDisplay(ServerPoints)}-Winner";

        private string GetPointDisplay(int points)
            => PointRules.TryGetValue(points, out var label) ? label : MaxPointLabel;
    }

    
}