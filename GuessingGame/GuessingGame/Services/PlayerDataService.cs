using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GuessingGame.Services
{
    class PlayerDataService
    {
        public async void GetPlayers()
        {
            try
            {
                {
                    using (var client = new HttpClient())
                    {
                        // GET the player data url
                        HttpResponseMessage response = await client.GetAsync("https://cdn.rawgit.com/liamjdouglas/bb40ee8721f1a9313c22c6ea0851a105/raw/6b6fc89d55ebe4d9b05c1469349af33651d7e7f1/Player.json");
                        var contentReponse = response.Content.ReadAsStringAsync().Result;

                        //if (response.IsSuccessStatusCode)
                        //{
                        //}
                        //else if (response.StatusCode == HttpStatusCode.BadRequest)
                        //{
                        //}
                    }
                }

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
