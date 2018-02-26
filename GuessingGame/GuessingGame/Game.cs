using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foundation;
using UIKit;

using GuessingGame.Services;
using GuessingGame.Models;
using GuessingGame.Views;

namespace GuessingGame
{
    public class GuessGame
    {

        /* 
         *  🔈
         *  
         *  Coding saturday night is the best.
         *  
         */

        public GameData GameData { get; set; }
        public List<PlayerView> PlayerViews { get; set; }
        public Player SelectedPlayer { get; set; }
        public int Score { get; set; }

        public GuessGame(GameData gameData)
        {
            GameData = gameData;
        }

        public List<PlayerView> GetRandomPlayers(int amountOfPlayers = 2)
        {
            PlayerViews = new List<PlayerView>();

            // get random players from list
            var totalNumberOfPlayers = GameData.Players.Count();

            // Avoid duplicate random numbers
            var rnd = new Random();
            HashSet<int> randomNumbers = new HashSet<int>();
            while (randomNumbers.Count < 2)
            {
                randomNumbers.Add(rnd.Next(1, totalNumberOfPlayers));
            }

            foreach (var item in randomNumbers)
            {
                var player = GameData.Players[item];
                PlayerView playerView = new PlayerView(player);
                PlayerViews.Add(playerView);
            }

            return PlayerViews;
        }

        public bool CheckGuess()
        {
            PlayerView bestPlayer = PlayerViews.OrderByDescending(x => x.CurrentPlayer.fppg).FirstOrDefault();

            if (bestPlayer.CurrentPlayer.id == SelectedPlayer.id)
            {
                // Winner
                Score += 1;
                return true;
            }
            else
            {
                // Loser
                return false;
            }
        }

        public List<PlayerView> GetOrderOfPlayers()
        {
            List<PlayerView> playersInOrder = PlayerViews.OrderByDescending(x => x.CurrentPlayer.fppg).ToList();
            return playersInOrder;
        }
    }
}