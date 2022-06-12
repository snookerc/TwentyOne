using TwentyOne.Extensions;

namespace TwentyOne.Models
{
    public class CardDeck
    {
        protected Stack<Card> Cards { get; set; } = new Stack<Card>();

        public CardDeck()
        {
            for (int suit = 1; suit < Card.MaxSuitNumber; suit++)
            {
                for (int card = 0; card < Card.MaxCardNumber; card++)
                {
                    Cards.Push(new Card(suit, card));
                }
            }

            Cards.Shuffle();
        }

        public Card GetNextCard()
        {
            return Cards.Pop();
        }
    }
}
