using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using GuessingGame.Services;
using GuessingGame.Models;
using System.Threading.Tasks;

namespace GuessingGame.Tests
{
    public class FakeGameDataService: IGameDataService
    {
        public async Task<GameData> GetGameData()
        {
            GameData gameData = new GameData();

            // I would fake up data here instead of calling my async service in order to speed unit tests up.

            return gameData;
        }
    }
}