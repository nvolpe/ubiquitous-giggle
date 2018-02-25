using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using GuessingGame.Services;
using GuessingGame.Models;
using GuessingGame.Views;
using System.Threading.Tasks;

namespace GuessingGame
{
    public class GuessGame
    {
        PlayerView Player1;
        PlayerView Player2;
        PlayerView Player3;

        public GameData GameData { get; set; }

        public GuessGame()
        {
            //StartNewGame();
        }

        public async Task StartNewGame()
        {
            //// Comment out the HTTP calls. it takes too long while debugging
            GameDataService dataService = new GameDataService();
            GameData = await dataService.GetGameData();
        }

        public List<PlayerView> GetRandomPlayers()
        {
            List<PlayerView> playerViews = new List<PlayerView>();

            // TODO: get random players from list
            var totalNumberOfPlayers = GameData.Players.Count();

            var player1 = GameData.Players[0];
            var player2 = GameData.Players[1];

            PlayerView player1View = new PlayerView(player1);
            PlayerView player2View = new PlayerView(player2);

            playerViews.Add(player1View);
            playerViews.Add(player2View);

            return playerViews;
        }
    }
}