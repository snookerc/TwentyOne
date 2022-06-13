using TwentyOne.Models;

namespace TwentyOne.Services
{
    public class Hand
    {
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

        public int Score => Cards.Sum(c => c.PointValue);

        public void GenerateNewCardInDeck() => Cards.Add(_cardDeck.GetNextCard());
    }
}
