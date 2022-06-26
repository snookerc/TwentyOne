namespace TwentyOne.Services
{
    public class TwentyOneGameService
    {
        public Hand DealerHand;

        public TwentyOneGameService()
        {
            DealerHand = new Hand();
        }

        public Hand PlayerHand;

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
