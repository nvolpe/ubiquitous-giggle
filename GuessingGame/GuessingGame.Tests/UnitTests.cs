using System;
using NUnit.Framework;
using GuessingGame.Services;
using System.Threading.Tasks;


namespace GuessingGame.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private GuessGame sut;

        [TestFixtureSetUp]
        public void BeforeAnyTestStarted()
        {
            // Performa setup here?
        }


        [Test]
        public async void ShouldHave2Players()
        {
            // Arrange
            //FakeGameDataService dataService = new FakeGameDataService(); // This should probably be a mock service because its an async call.. Unit tests should be fast! So this data should be mocked up I feel like.
            GameDataService dataService = new GameDataService();
            var gameData = await dataService.GetGameData();

            // Setup Guessing Game with data
            sut = new GuessGame(gameData);

            int expected = 2;

            // Act
            var players = sut.GetRandomPlayers(2);

            // Assert
            Assert.AreEqual(players.Count, expected);
        }
    }
}