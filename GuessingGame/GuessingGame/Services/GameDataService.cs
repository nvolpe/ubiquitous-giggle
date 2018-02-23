using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GuessingGame.Models;
using System.Threading.Tasks;

namespace GuessingGame.Services
{
    class GameDataService
    {
        public async Task<GameData> GetGameData()
        {

            /* 
             *  🔈
             *  
             *  Where Do I see myself in 5 years, I'm glad you asked. I'd like to still be working for FanDuel as I think Fanduel we will be on the cutting edge for a long time. 
             *  But my dream is life is to build 'something' completely new and awesome and run it myself. I think FanDuel will be a great place to hone my skills and continue to grow as a developer.
             *  Cheers to dreamin' big.
             *  
             */

            try
            {
                GameData gameData = new GameData();

                using (var client = new HttpClient())
                {
                    // GET the player data url
                    HttpResponseMessage response = await client.GetAsync("https://cdn.rawgit.com/liamjdouglas/bb40ee8721f1a9313c22c6ea0851a105/raw/6b6fc89d55ebe4d9b05c1469349af33651d7e7f1/Player.json");
                    var contentReponse = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //dynamic d = JObject.Parse(contentReponse);
                        gameData = JsonConvert.DeserializeObject<GameData>(contentReponse);
                    }

                    //if (response.IsSuccessStatusCode)
                    //{
                    //}
                    //else if (response.StatusCode == HttpStatusCode.BadRequest)
                    //{
                    //}
                }

                return gameData;
            }

            //catch (HttpRequestException exc)
            //{
            //}

            catch (Exception exc)
            {
                throw exc;
            }
        }

    }
}
