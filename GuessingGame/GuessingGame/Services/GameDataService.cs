using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GuessingGame.Models;
using System.Threading.Tasks;
using UIKit;

namespace GuessingGame.Services
{

    public interface IGameDataService
    {
        Task<GameData> GetGameData();
    }


    public class GameDataService: IGameDataService
    {
        public async Task<GameData> GetGameData()
        {
            /* 
             *  🔈
             *  
             *  Where Do I see myself in 5 years, I'm glad you asked. I'd like to still be working for FanDuel as I think Fanduel we will be on the cutting edge for a long time. 
             *  But my dream in life is to build 'something' completely new and awesome and run it myself. I think FanDuel will be a great place to hone my skills and continue to grow as a developer.
             *  Cheers to dreamin' big.
             *  
             */
            GameData gameData = new GameData();
            try
            {
                using (var client = new HttpClient())
                {
                    // GET the player data url
                    HttpResponseMessage response = await client.GetAsync("https://cdn.rawgit.com/liamjdouglas/bb40ee8721f1a9313c22c6ea0851a105/raw/6b6fc89d55ebe4d9b05c1469349af33651d7e7f1/Player.json");
                    var contentReponse = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        gameData = JsonConvert.DeserializeObject<GameData>(contentReponse);
                    }
                }

                // catch NULL data upstream.. if no points, remove from list
                var players = gameData.Players.Where(item => item.fppg != null).ToList();
                gameData.Players = players;

                return gameData;
            }

            catch (HttpRequestException exc)
            {
                // Log the error
                UIAlertView alert = new UIAlertView()
                {
                    Title = "HttpRequestException",
                    Message = exc.Message
                };
                alert.AddButton("OK");
                alert.Show();

                return gameData;
            }

            catch (Exception exc)
            {
                // Log the error
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Unhandled exception",
                    Message = exc.Message
                };
                alert.AddButton("OK");
                alert.Show();

                return gameData;
            }
        }
    }
}
