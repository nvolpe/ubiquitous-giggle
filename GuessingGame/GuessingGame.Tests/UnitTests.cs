using System;
using NUnit.Framework;

namespace GuessingGame.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pass()
        {
            Assert.True(true);
        }

        [Test]
        public void Fail()
        {
            Assert.False(true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True(false);
        }

        [Test]
        public void ShouldHave2Results()
        {
            var sut = new GuessGame();
            int expected = 2;

            var players = sut.GetRandomPlayers();

            Assert.AreEqual(players.Count, expected);
        }
    }
}