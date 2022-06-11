﻿namespace TwentyOne.Services
{
    public class TwentyOneGameService
    {
        public async Task<Hand> ComputerTurn(Hand gameHand)
        {
            Hand newGameHand = gameHand;

            //
            newGameHand.GenerateNewCardInDeck();

            return newGameHand;
        }

        public async Task<Hand> PlayerTurn(Hand gameHand)
        {
            Hand newGameHand = gameHand;

            //
            newGameHand.GenerateNewCardInDeck();

            return newGameHand;
        }

    }
}