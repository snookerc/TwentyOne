
namespace TwentyOneTests
{
    public class TwentyOneGameServiceTest
    {
        private TwentyOneGameService _gameService = new TwentyOneGameService();
        private CardDeck _cardDeck = new CardDeck();

        [Fact]
        public void GivenADealerHandWithTwoCards_When16Points_ThenDealerHits()
        {
            Hand fakeDealerHand = AutoFaker.Generate<Hand>();
            Card card1 = new Card(1, 8);
            Card card2 = new Card(1, 8);

            fakeDealerHand.Cards.Add(card1);
            fakeDealerHand.Cards.Add(card2);

            fakeDealerHand = _gameService.ComputerTurn(fakeDealerHand);
            fakeDealerHand.Score.Should().BeGreaterThan(16);
        }

        [Fact]
        public void GivenADealerHandWithTwoCards_When17Points_ThenDealerStands()
        {
            var gameService = new TwentyOneGameService();

            Hand fakeDealerHand = AutoFaker.Generate<Hand>();
            Card card1 = new Card(1, 7);
            Card card2 = new Card(1, 10);

            fakeDealerHand.Cards.Add(card1);
            fakeDealerHand.Cards.Add(card2);
            fakeDealerHand = _gameService.ComputerTurn(fakeDealerHand);
            fakeDealerHand.Score.Should().Be(17);
        }
    }
}