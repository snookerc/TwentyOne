using System.Drawing;

namespace TwentyOne.Models
{
    public class Card
    {
        public const int MaxSuitNumber = 4;
        public const int MaxCardNumber = 13;
        public const int CardBackNumber = 14;

        public int UniqueID { get; set; }
        public bool IsVisible { get; set; }
        public int SuitNumber { get; set; }
        public enum SuitType { Spades, Hearts, Diamonds, Clubs }
        public int CardNumber { get; set; }
        public enum CardType { Unused, Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

        public int PointValueLow
        {
            get
            {
                switch (CardNumber)
                {
                    case (int)CardType.Ace:
                        return 1;
                    default:
                        return PointValueHigh;
                }
            }
        }

        public int PointValueHigh
        {
            get
            {
                switch (CardNumber)
                {
                    case (int)CardType.Ace:
                        return 11;
                    case (int)CardType.Jack:
                    case (int)CardType.Queen:
                    case (int)CardType.King:
                        return 10;
                    default:
                        return CardNumber;
                }
            }
        }

        public Card(int suitNumber, int cardNumber)
        {
            UniqueID = Random.Shared.Next(1, int.MaxValue);     //TODO
            CardNumber = cardNumber;
            SuitNumber = suitNumber;
            IsVisible = true;
        }

        public string GetImageName => $"{SuitNumber}-{CardNumber}.jpg";

        public string GetImageNameForBack => $"back.jpg";

    }
}
