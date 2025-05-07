
using System.Data;
using System.Text;

namespace Kata.Tests.Tennis
{
    public class Score
    {
        public int ServerPoints { get; private set; }
        public int ReceiverPoints { get; private set; }

        private readonly Dictionary<int, string> PointRules;

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
        }

        public void AddPointToServer() => ServerPoints++;

        public void AddPointToReceiver() => ReceiverPoints++;

        public string GetScoreDisplay() 
        {
            var result = new StringBuilder();

            var maxPointValue = PointRules.Max(rule => rule.Key);
            var maxPointResult = PointRules.Max(rule => rule.Value);

            if (ServerPoints >= maxPointValue &&  ReceiverPoints >= maxPointValue)
            {
                if (ServerPoints == ReceiverPoints)
                {
                    result.Append(maxPointResult);
                    result.Append("A");
                    return result.ToString();
                }
                if(ServerPoints == ReceiverPoints + 1)
                {
                    result.Append("Advantage");
                    result.Append("-");
                    result.Append(maxPointResult);
                    return result.ToString();
                }
                if (ReceiverPoints == ServerPoints + 1)
                {
                    result.Append(maxPointResult);
                    result.Append("-");
                    result.Append("Advantage");
                    return result.ToString();
                }
                if (ServerPoints > ReceiverPoints + 1)
                {
                    result.Append("Winner");
                    result.Append("-");
                    result.Append(maxPointResult);
                    return result.ToString();
                }
                if (ReceiverPoints > ServerPoints + 1)
                {
                    result.Append(maxPointResult);
                    result.Append("-");
                    result.Append("Winner");
                    return result.ToString();
                }
            }

            var serverPointResult = PointRules.TryGetValue(ServerPoints, out var value)
                    ? value
                    : PointRules.Max(rule => rule.Value);

            var receiverPointResult = PointRules.TryGetValue(ReceiverPoints, out value)
                    ? value
                    : PointRules.Max(rule => rule.Value);

            if (ServerPoints > maxPointValue)
            {
                result.Append("Winner");
                result.Append("-");
                result.Append(receiverPointResult);
                return result.ToString();
            }
            if (ReceiverPoints > maxPointValue)
            {
                result.Append(serverPointResult);
                result.Append("-");
                result.Append("Winner");
                return result.ToString();
            }

            result.Append(serverPointResult);
            result.Append("-");
            result.Append(receiverPointResult);

            return result.ToString();
        }
    }

    
}