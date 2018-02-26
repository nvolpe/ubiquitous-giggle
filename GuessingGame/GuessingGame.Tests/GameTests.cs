using System;
using System.Linq;
using NUnit.Framework;
using GuessingGame.Services;
using System.Threading.Tasks;


/* 
 *  🔈
 *  
 *  I know I have to step my game up with UNIT testing. I am sure it is a big part of what Fan Duel Does. I am stil a beginner with Testing Xamarin Applications. 
 *  My current company has limited resources as I am the only one in my office building xamarin apps. This is one major reason why I am looking for a job upgrade, 
 *  I want to abosrb some unit testing skills from some xamarin pros.
 *  
 *  The last 4 days of working on this test, I have been cramming as much informationr related to testing iOS, Xamarin.iOS with NUNIT.
 *  
 *  I also do not have experienece with writing Automated UI Tests. I noticed Xamarin is proud to show off Fan Duel on their website as a client who uses Xamarin Test Cloud. I am sure that is a beast to work on!
 */


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