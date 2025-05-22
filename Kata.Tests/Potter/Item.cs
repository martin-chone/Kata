namespace Kata.Tests.Potter
{
    public class Item
    {
        public string Title { get; private set; }
        public int Number {  get; private set; }

        public Item(string title, int number = 1) 
        { 
            Title = title;
            Number = number;
        }
    }
}