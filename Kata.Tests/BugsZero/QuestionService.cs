namespace Kata.Tests.BugsZero
{
    public class QuestionService
    {
        private IList<Category> _categories;
        private Dictionary<Category, QuestionBank> _banks;

        public QuestionService(IList<Category> categories, int questionsPerCategory)
        {
            _categories = categories;

            _banks = categories.ToDictionary(
                category => category,
                category => new QuestionBank());

            for (int i = 0; i < questionsPerCategory; i++)
            {
                foreach (Category category in categories)
                {
                    var questionText = $"{category.Name} Question {i}";
                    var question = new Question(questionText);
                    _banks[category].Add(question);
                }
            }
        }

        public Category GetCategoryForPlace(int place)
        {
            return _categories[place % _categories.Count];
        }

        public Question GetNextQuestion(Category category)
        {
            if (_banks.TryGetValue(category, out var bank))
            {
                var question = bank.Next();
                bank.Remove();
                return question;
            }
            throw new InvalidOperationException($"No question bank for category {category.Name}");
        }
    }
}
