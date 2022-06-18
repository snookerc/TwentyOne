
namespace TwentyOneTests
{
    public class TwentyOneGameServiceTest
    {
        private TwentyOneGameService _gameService = new TwentyOneGameService();
        private CardDeck _cardDeck = new CardDeck();

        [Fact]
        public void GivenADealerHandWithTwoCards_When16Points_ThenDealerHits()
        {
            var dealerHand = new Hand(_cardDeck, 0);
            Card card1 = _cardDeck.GetNextCard();
            card1.CardNumber = 8;

            Card card2 = _cardDeck.GetNextCard();
            card2.CardNumber = 8;

            dealerHand.Cards.Add(card1);
            dealerHand.Cards.Add(card2);    

            dealerHand = _gameService.ComputerTurn(dealerHand);
            dealerHand.Score.Should().BeGreaterThan(16);
        }

        [Fact]
        public void GivenADealerHandWithTwoCards_When17Points_ThenDealerStands()
        {
            var dealerHand = new Hand(_cardDeck, 0);
            Card card1 = _cardDeck.GetNextCard();
            card1.CardNumber = 8;

            Card card2 = _cardDeck.GetNextCard();
            card2.CardNumber = 9;

            dealerHand.Cards.Add(card1);
            dealerHand.Cards.Add(card2);

            Console.WriteLine(dealerHand.Score);

            dealerHand = _gameService.ComputerTurn(dealerHand);
            dealerHand.Score.Should().Be(17);
        }
    }

}