
namespace TwentyOneTests
{
    public class TwentyOneGameServiceTest
    {
        private CardDeck _cardDeck = new CardDeck();
        private TwentyOneGameService _gameService = new TwentyOneGameService();

        [Fact]
        public void GivenADealerHandWithTwoCards_When16Points_ThenDealerHits()
        {
            //var fakeHand = new AutoFaker<Hand>().RuleFor<Card>(c => c.Cards.Count.Should(2) = 8);
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

            dealerHand = _gameService.ComputerTurn(dealerHand);
            dealerHand.Score.Should().Be(17);
        }

        [Fact]
        public void GivenPlayerScoreMoreThanDealerScore_ThenPlayerWins()
        {
            _gameService = new TwentyOneGameService();
            _gameService.DealerHand.Cards[0].CardNumber = 1;
            _gameService.DealerHand.Cards[1].CardNumber = 1;

            _gameService.PlayerHand.Cards[0].CardNumber = 10;
            _gameService.PlayerHand.Cards[1].CardNumber = 9;

            _gameService.GameResult.Should().Be(TwentyOneGameService.GameResultType.Win);
        }

        [Fact]
        public void GivenPlayerScoreLessThanDealerScore_ThenDealerWins()
        {
            _gameService = new TwentyOneGameService();
            _gameService.DealerHand.Cards[0].CardNumber = 10;
            _gameService.DealerHand.Cards[1].CardNumber = 9;

            _gameService.PlayerHand.Cards[0].CardNumber = 1;
            _gameService.PlayerHand.Cards[1].CardNumber = 1;

            _gameService.GameResult.Should().Be(TwentyOneGameService.GameResultType.Lose);
        }

        [Fact]
        public void GivenPlayerBust_ThenDealerWins()
        {
            _gameService = new TwentyOneGameService();
            _gameService.DealerHand.Cards[0].CardNumber = 10;
            _gameService.DealerHand.Cards[1].CardNumber = 9;

            _gameService.PlayerHand.Cards[0].CardNumber = 13;
            _gameService.PlayerHand.Cards[1].CardNumber = 13;
            _gameService.PlayerHand.Cards.Add(new Card(1, 13));

            _gameService.GameResult.Should().Be(TwentyOneGameService.GameResultType.Lose);
        }

        [Fact]
        public void GivenDealerBust_ThenPlayerWins()
        {
            _gameService = new TwentyOneGameService();
            _gameService.DealerHand.Cards[0].CardNumber = 13;
            _gameService.DealerHand.Cards[1].CardNumber = 13;
            _gameService.DealerHand.Cards.Add(new Card(1, 13));

            _gameService.PlayerHand.Cards[0].CardNumber = 10;
            _gameService.PlayerHand.Cards[1].CardNumber = 9;

            _gameService.GameResult.Should().Be(TwentyOneGameService.GameResultType.Win);
        }

        [Fact]
        public void GivenPlayerTiesDealer_ThenItsADraw()
        {
            _gameService = new TwentyOneGameService();
            _gameService.DealerHand.Cards[0].CardNumber = 10;
            _gameService.DealerHand.Cards[1].CardNumber = 9;

            _gameService.PlayerHand.Cards[0].CardNumber = 10;
            _gameService.PlayerHand.Cards[1].CardNumber = 9;

            _gameService.GameResult.Should().Be(TwentyOneGameService.GameResultType.Draw);
        }
    }
}