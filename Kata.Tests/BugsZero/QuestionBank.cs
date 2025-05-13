

namespace Kata.Tests.BugsZero
{
    public class QuestionBank
    {
        private readonly LinkedList<string> _questions = new();

        public void Add(string question) => _questions.AddLast(question);

        public string Next() => _questions.First();

        public void Remove() => _questions.RemoveFirst();
    }
}