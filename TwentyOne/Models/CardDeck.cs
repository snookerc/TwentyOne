using TwentyOne.Extensions;

namespace TwentyOne.Models
{
    public class CardDeck
    {
        protected Stack<Card> Cards { get; set; } = new Stack<Card>();

        public int RemainingCardCount => Cards.Count;

        public CardDeck() => NewDeal();

        public void NewDeal()
        {
            Cards = new Stack<Card>();

            for (int suit = 1; suit <= Card.MaxSuitNumber; suit++)
            {
                for (int card = 1; card <= Card.MaxCardNumber; card++)
                {
                    Cards.Push(new Card(suit, card));
                }
            }

            Cards = Cards.Shuffle();
        }

        public Card GetNextCard()
        {
            return Cards.Pop();
        }
    }
}
