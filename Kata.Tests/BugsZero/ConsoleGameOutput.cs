using Kata.Tests.Tennis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Tests.BugsZero
{
    public class ConsoleGameOutput : IGameOutput
    {
        public void EnterPenaltyBox(string playerName)
        {
            Console.WriteLine($"{playerName} was sent to the penalty box");
        }

        public void ExitPenaltyBox(string playerName, bool isExiting)
        {
            Console.WriteLine(isExiting
                ? $"{playerName} is getting out of the penalty box"
                : $"{playerName} is not getting out of the penalty box");
        }

        public void PlayerAdded(string playerName, int playerNumber)
        {
            Console.WriteLine(playerName + " was Added");
            Console.WriteLine("They are player number " + playerNumber);
        }

        public void ShowCategory(string categoryName)
        {
            Console.WriteLine("The category is " + categoryName);
        }

        public void ShowCorrectAnswer()
        {
            Console.WriteLine("Answer was correct!!!!");
        }

        public void ShowCurrentPlayer(string playerName)
        {
            Console.WriteLine(playerName + " is the current player");
        }

        public void ShowIncorrectAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
        }

        public void ShowNewLocation(string playerName, int place)
        {
            Console.WriteLine(playerName + "'s new location is " + place);
        }

        public void ShowPlayerPurse(string playerName, int purse)
        {
            Console.WriteLine($"{playerName} now has {purse} Gold Coins.");
        }

        public void ShowQuestion(string question)
        {
            Console.WriteLine(question);
        }

        public void ShowRoll(int roll)
        {
            Console.WriteLine("They have rolled a " + roll);
        }
    }
}
