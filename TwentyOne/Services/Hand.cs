namespace TwentyOne.Services
{
    public class Hand
    {
        public List<Card> Cards { get; set; }

        public Hand() : this(0)
        {
        }

        public Hand(int initalCardCount)
        {
            Cards = new List<Card>();
            for (int i = 0; i < initalCardCount; i++)
            {
                GenerateNewCardInDeck();
            }
        }

        public int Score
        {
            get
            {
                return Cards.Sum(c => c.CardNumber);
            }
        }

        public void GenerateNewCardInDeck()
        {
            var card = new Card();

            card.CardNumber = Random.Shared.Next(1, Card.MaxCardNumber);
            card.SuitNumber = Random.Shared.Next(1, Card.MaxSuitNumber);

            Cards.Add(card);
        }
    }
}
