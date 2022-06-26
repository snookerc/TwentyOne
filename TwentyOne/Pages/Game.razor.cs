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

        protected override async Task OnInitializedAsync()
        {
            twentyOneGameService.DealerHand = new Hand(cardDeck);
            twentyOneGameService.PlayerHand = new Hand(cardDeck);
            HidePlayerButtons = false;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await NewGame();
            }
        }

        private async Task NewGame()
        {
            IsLoading = true;
            HidePlayerButtons = true;
            HideNewGameButton = true;

            cardDeck.NewDeal();

            twentyOneGameService.DealerHand = new Hand(cardDeck);
            twentyOneGameService.PlayerHand = new Hand(cardDeck);
            await jsRuntime.InvokeAsync<string>("PlaySound", "/sounds/CardShuffle1.mp3");

            twentyOneGameService.DealerHand = new Hand(cardDeck, 2);
            twentyOneGameService.DealerHand.Cards[1].IsVisible = false;
            //await jsRuntime.InvokeAsync<string>("PlaySound", "/sounds/CardFlip1.mp3");

            twentyOneGameService.PlayerHand = new Hand(cardDeck, 2);
            IsLoading = false;
            HidePlayerButtons = false;
            HideNewGameButton = false;
        }

        private async Task HitMe()
        {
            IsLoading = true;

            twentyOneGameService.PlayerTurn(twentyOneGameService.PlayerHand);
            await jsRuntime.InvokeAsync<string>("PlaySound", "/sounds/CardFlip1.mp3");

            if (twentyOneGameService.PlayerHand.IsBust)
            {
                HidePlayerButtons = true;
            };

            IsLoading = false;
        }

        private async Task Stand()
        {
            HidePlayerButtons = true;
            HideNewGameButton = true;
            string endOfGameMessage = String.Empty;
            string endOfGameSound = String.Empty;

            await jsRuntime.InvokeAsync<string>("PlaySound", "/sounds/CardFlip1.mp3");
            twentyOneGameService.ComputerTurn(twentyOneGameService.DealerHand);

            switch (twentyOneGameService.GameResult)
            {
                case TwentyOneGameService.GameResultType.Win:
                    endOfGameMessage = "You win!";
                    endOfGameSound = "Win1.mp3";
                    break;
                case TwentyOneGameService.GameResultType.Lose:
                    endOfGameMessage = "Dealer wins";
                    endOfGameSound = "Lose4.mp3";
                    break;
                case TwentyOneGameService.GameResultType.Draw:
                    endOfGameMessage = "It's a draw!";
                    endOfGameSound = "Up1.mp3";
                    break;
            }

            HideNewGameButton = false;
            await jsRuntime.InvokeAsync<string>("PlaySound", $"/sounds/{endOfGameSound}");
            OpenDialog(endOfGameMessage);
        }

        private void OpenDialog(string message)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, DisableBackdropClick = true };
            var dialog = DialogService.Show<Dialog>(message, options);
        }
    }
}