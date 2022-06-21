namespace TwentyOne.Services
{
    public class TwentyOneGameService
    {
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
