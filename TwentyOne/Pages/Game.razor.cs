using Microsoft.JSInterop;
using MudBlazor;
using TwentyOne.Pages.Partials;
using TwentyOne.Services;

namespace TwentyOne.Pages
{
    public partial class Game
    {
        private bool IsLoading = false;
        private bool HideNewGameButton = false;
        private bool HidePlayerButtons = false;
        private TwentyOneGameService twentyOneGameService = new TwentyOneGameService();
        private Hand dealerHand;
        private Hand playerHand;
        protected override async Task OnInitializedAsync()
        {
            dealerHand = new Hand(cardDeck);
            playerHand = new Hand(cardDeck);
            HidePlayerButtons = false;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        //TODO:  this doesn't work.  is there a "before render"?
        //if (firstRender)
        //{
        //    await NewGame();
        //}
        }

        private async Task NewGame()
        {
            IsLoading = true;
            HidePlayerButtons = true;
            HideNewGameButton = true;
            cardDeck.NewDeal();
            dealerHand = new Hand(cardDeck);
            playerHand = new Hand(cardDeck);
            await jsRuntime.InvokeAsync<string>("PlaySound", "/sounds/CardShuffle1.mp3");
            dealerHand = new Hand(cardDeck, 2);
            dealerHand.Cards[1].IsVisible = false;
            //await jsRuntime.InvokeAsync<string>("PlaySound", "/sounds/CardFlip1.mp3");
            playerHand = new Hand(cardDeck, 2);
            IsLoading = false;
            HidePlayerButtons = false;
            HideNewGameButton = false;
        }

        private async Task HitMe()
        {
            IsLoading = true;
            await jsRuntime.InvokeAsync<string>("PlaySound", "/sounds/CardFlip1.mp3");
            twentyOneGameService.PlayerTurn(playerHand);
            if (playerHand.IsBust)
            {
                HidePlayerButtons = true;
            }

            ;
            IsLoading = false;
        }

        private async Task Stand()
        {
            HidePlayerButtons = true;
            HideNewGameButton = true;
            string endOfGameMessage;
            string endOfGameSound;
            await jsRuntime.InvokeAsync<string>("PlaySound", "/sounds/CardFlip1.mp3");
            twentyOneGameService.ComputerTurn(dealerHand);
            if (dealerHand.Score > playerHand.Score || playerHand.IsBust)
            {
                endOfGameMessage = "Dealer wins";
                endOfGameSound = "Lose4.mp3";
            }
            else if (dealerHand.Score < playerHand.Score || dealerHand.IsBust)
            {
                endOfGameMessage = "You win!";
                endOfGameSound = "Win1.mp3";
            }
            else
            {
                endOfGameMessage = "It's a draw!";
                endOfGameSound = "Up1.mp3";
            }

            HideNewGameButton = false;
            await jsRuntime.InvokeAsync<string>("PlaySound", $"/sounds/{endOfGameSound}");
            OpenDialog(endOfGameMessage);
        }

        private void OpenDialog(string message)
        {
            var options = new DialogOptions{CloseOnEscapeKey = true, DisableBackdropClick = true};
            var dialog = DialogService.Show<Dialog>(message, options);
        }
    }
}