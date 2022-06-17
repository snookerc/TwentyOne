using TwentyOne.Models;

namespace TwentyOne.Services
{
    public class Hand
    {
        private const int WinningScore = 21;
        private CardDeck _cardDeck;

        private int ScoreLow => Cards.Sum(c => c.PointValueLow);

        private int ScoreHigh => Cards.Sum(c => c.PointValueHigh);

        public List<Card> Cards { get; set; }

        public Hand(CardDeck cardDeck) : this(cardDeck, 0) { }

        public Hand(CardDeck cardDeck, int initalCardCount)
        {
            _cardDeck = cardDeck;
            Cards = new List<Card>();
            for (int i = 0; i < initalCardCount; i++)
            {
                GenerateNewCardInDeck();
            }
        }

        public int Score => ScoreHigh > WinningScore ? ScoreLow : ScoreHigh;

        public bool IsBust => Score > WinningScore;

        public bool IsDone { get; set; }

        public void GenerateNewCardInDeck() => Cards.Add(_cardDeck.GetNextCard());

    }
}
