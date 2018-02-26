using System;
using System.Linq;
using NUnit.Framework;
using GuessingGame.Services;
using System.Threading.Tasks;


namespace GuessingGame.Tests
{
    [TestFixture]
    public class DataServiceTests
    {
        private GameDataService sut;

        [TestFixtureSetUp]
        public void BeforeAnyTestStarted()
        {
            // Perform setup here?
            sut = new GameDataService();
        }
        [Test]
        public async void DataHasPointsForPlayers()
        {
            // Arrange
            var data = await sut.GetGameData();

            // Act
            int actualCount = data.Players.Where(item => item.fppg == null).Count();

            // Assert
            Assert.True(actualCount == 0, "Every player has points");
        }


        [Test]
        public async void DataHasImageUrlsForPlayers()
        {
            // Arrange
            var data = await sut.GetGameData();

            // Act
            int actualCount = data.Players.Where(item => string.IsNullOrWhiteSpace(item.images.@default.url)).Count();

            // Assert
            Assert.True(actualCount == 0, "Every player has image urls");
        }
    }
}