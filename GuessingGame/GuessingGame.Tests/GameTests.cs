using System;
using System.Linq;
using NUnit.Framework;
using GuessingGame.Services;
using System.Threading.Tasks;


namespace GuessingGame.Tests
{
    [TestFixture]
    public class GameTests
    {
        private GuessGame sut;

        [TestFixtureSetUp]
        public async void BeforeAnyTestStarted()
        {
            // Perform setup here?
            GameDataService dataService = new GameDataService();

            // Workaround for http async testing...
            var data = Task.Run(() => dataService.GetGameData()).Result;

            // Setup Guessing Game with data
            sut = new GuessGame(data);
        }

        [Test]
        public void ShouldHaveMoreThanZeroPlayers()
        {
            // Arrange
            var players = sut.GameData.Players;

            // Act
            bool expected = true;

            // Assert
            Assert.IsTrue(players.Count > 0, "The Count was not greater than 0");
        }


        [Test]
        public void ShouldHave2Players()
        {
            // Arrange
            int expected = 2;

            // Act
            var players = sut.GetRandomPlayers(2);

            // Assert
            Assert.AreEqual(expected, players.Count);
        }

        [Test]
        // want to use the [Repeat] method here but its not working... want to prove every set of players I select is truly not a duplicate player
        public void ShouldGet2DifferentPlayers()
        {
            // Arrange

            // Act
            var players = sut.GetRandomPlayers(2);


            // Assert
            Assert.AreNotSame(players[0], players[1]);
        }

    }
}