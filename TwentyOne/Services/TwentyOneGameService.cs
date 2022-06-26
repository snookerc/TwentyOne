using TwentyOne.Models;

namespace TwentyOne.Services
{
    public class TwentyOneGameService
    {
        public Hand DealerHand;
        public Hand PlayerHand;
        public CardDeck _cardDeck;

        public TwentyOneGameService()
        {
            _cardDeck = new CardDeck();

            _cardDeck.NewDeal();

            DealerHand = new Hand(_cardDeck);
            PlayerHand = new Hand(_cardDeck);

            DealerHand = new Hand(_cardDeck, 2);
            DealerHand.Cards[1].IsVisible = false;

            PlayerHand = new Hand(_cardDeck, 2);
        }

        public enum GameResultType
        {
            Win,
            Lose,
            Draw
        }

        public GameResultType GameResult
        {
            get
            {
                if (PlayerHand.IsBust || (!DealerHand.IsBust && (DealerHand.Score > PlayerHand.Score)))
                {
                    return GameResultType.Lose;
                }
                else if (DealerHand.IsBust || (!PlayerHand.IsBust && DealerHand.Score < PlayerHand.Score))
                {
                    return GameResultType.Win;
                }
                else
                {
                    return GameResultType.Draw;
                }
            }
        }

        public Hand ComputerTurn(Hand gameHand)
        {
            Hand newGameHand = gameHand;

            while (newGameHand.Score < 17)
            {
                newGameHand.GenerateNewCardInDeck();
            }

            newGameHand.Cards.ForEach(card => card.IsVisible = true);
            newGameHand.IsDone = true;

            return newGameHand;
        }

        public Hand PlayerTurn(Hand gameHand)
        {
            Hand newGameHand = gameHand;

            newGameHand.GenerateNewCardInDeck();

            return newGameHand;
        }

    }
}
