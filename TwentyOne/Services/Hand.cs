using TwentyOne.Models;

namespace TwentyOne.Services
{
    public class Hand
    {
        private const int WinningScore = 21;
        private CardDeck _cardDeck;

        public List<Card> Cards { get; set; }

        public Hand(CardDeck cardDeck) : this(cardDeck, 0)
        {
        }

        public Hand(CardDeck cardDeck, int initalCardCount)
        {
            _cardDeck = cardDeck;
            Cards = new List<Card>();
            for (int i = 0; i < initalCardCount; i++)
            {
                GenerateNewCardInDeck();
            }
        }

        public bool IsBust => ScoreLow > WinningScore && ScoreLow > WinningScore;

        public int ScoreLow => Cards.Sum(c => c.PointValueLow);

        public int ScoreHigh => Cards.Sum(c => c.PointValueHigh);

        public void GenerateNewCardInDeck() => Cards.Add(_cardDeck.GetNextCard());
    }
}
