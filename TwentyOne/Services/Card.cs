namespace TwentyOne.Services
{
    public class Card
    {
        public const int MaxSuitNumber = 4;
        public const int MaxCardNumber = 13;

        public bool IsVisible { get; set; } 
        public int SuitNumber { get; set; } 
        public int CardNumber { get; set; } 
    }
}
