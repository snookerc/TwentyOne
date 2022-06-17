namespace TwentyOne.Services
{
    public class TwentyOneGameService
    {
        public Hand ComputerTurn(Hand gameHand)
        {
            Hand newGameHand = gameHand;

            if (newGameHand.Score < 17)
            {
                newGameHand.GenerateNewCardInDeck();
            }
            else
            {
                newGameHand.IsDone = true;
            }

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
