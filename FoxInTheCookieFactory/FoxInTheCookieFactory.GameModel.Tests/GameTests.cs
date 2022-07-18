using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FoxInTheCookieFactory.GameModel.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Initilize_CreateDeck_NotNull()
        {
            var game = new Game();

            game.Initilize();

            Assert.IsNotNull(game.Deck);
        }

        [TestMethod]
        public void Initilize_CreatePlayers_NotNull()
        {
            var game = new Game();

            game.Initilize();

            Assert.IsNotNull(game.Player1);
            Assert.IsNotNull(game.Player2);
        }

        [TestMethod]
        public void Initilize_DealHands_CorrectCount()
        {
            int playerHandSize = 13;

            var game = new Game();

            game.Initilize();

            Assert.AreEqual(playerHandSize, game.Player1.Hand.Count);
            Assert.AreEqual(playerHandSize, game.Player2.Hand.Count);
        }
    }
}
