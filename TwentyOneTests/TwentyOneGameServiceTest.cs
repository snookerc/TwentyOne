
namespace TwentyOneTests
{
    public class TwentyOneGameServiceTest
    {
        [Fact]
        public void GivenADealerHandWithTwoCards_When16Points_ThenDealerHits()
        {
            Hand fakeDealerHand = new Faker<Hand>()
                    .RuleFor(p => p.Cards, f => f.PickRandom<List<Card>>());

            fakeDealerHand.Score.Should().BeGreaterThan(16);
        }       
        
        [Fact]
        public void GivenADealerHandWithTwoCards_When17Points_ThenDealerStands()
        {
            Hand fakeDealerHand = new Faker<Hand>()
                    .RuleFor(p => p.Cards, f => f.PickRandom<List<Card>>());

            fakeDealerHand.Score.Should().Be(17);
        }
    }
}