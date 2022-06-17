
namespace TwentyOneTests
{
    public class TwentyOneGameServiceTest
    {
        private TwentyOneGameService _gameService = new TwentyOneGameService();
        private CardDeck _cardDeck = new CardDeck();

        [Fact]
        public void GivenADealerHandWithTwoCards_When16Points_ThenDealerHits()
        {
            var cardFaker = new AutoFaker<Card>()
                .RuleFor(p => p.CardNumber, 8);

            Hand fakeDealerHand = AutoFaker.Generate<Hand>();

            fakeDealerHand = _gameService.ComputerTurn(fakeDealerHand);
            fakeDealerHand.Score.Should().BeGreaterThan(16);
        }

        [Fact]
        public void GivenADealerHandWithTwoCards_When17Points_ThenDealerStands()
        {
            Hand fakeDealerHand = AutoFaker.Generate<Hand>();

            fakeDealerHand = _gameService.ComputerTurn(fakeDealerHand);
            fakeDealerHand.Score.Should().Be(17);
        }
    }
}