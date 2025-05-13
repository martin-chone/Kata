

namespace Kata.Tests.BugsZero
{
    public class QuestionBank
    {
        private readonly LinkedList<Question> _questions = new();

        public void Add(Question question) => _questions.AddLast(question);

        public Question Next() => _questions.First();

        public void Remove() => _questions.RemoveFirst();
    }
}