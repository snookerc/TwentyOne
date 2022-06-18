
namespace TwentyOneTests
{
    public class TwentyOneGameServiceTest
    {
        private TwentyOneGameService _gameService = new TwentyOneGameService();
        private CardDeck _cardDeck = new CardDeck();

        [Fact]
        public void GivenADealerHandWithTwoCards_When16Points_ThenDealerHits()
        {
            var personFaker = new HandFaker(id);
            var hand = AutoFaker.Generate<Hand>(f => f.);

            // Create a Person instance using AutoFaker.Generate()
            // If the AutoFaker<T> class needs constructor arguments, they can be passed using WithArgs()
            var person2 = AutoFaker.Generate<Person, PersonFaker>(builder => builder.WithArgs(id));

            //Hand fakeDealerHand = AutoFaker<Hand>();


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

    public class HandFaker : AutoFaker<Hand>
    {
        public HandFaker(int id)
        {
            //RuleFor(fake => fake., () => id)
        }
    }

}