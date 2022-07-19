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

        [TestMethod]
        public void Initilize_DrawDecreeCard_SetsCard()
        {
            var game = new Game();

            game.Initilize();

            Assert.IsNotNull(game.DecreeCard);
        }

        [TestMethod]
        public void Initilize_DrawDecreeCard_RemovesFromDeck()
        {
            int deckSizeMinusDecreeCard = 6;

            var game = new Game();

            game.Initilize();

            Assert.AreEqual(deckSizeMinusDecreeCard, game.Deck.Cards.Count);
        }

        [TestMethod]
        public void Initilize_SetCurrentPlayerToPlayer1()
        {
            var game = new Game();
            game.Initilize();

            Assert.AreEqual(game.Player1, game.LeadingPlayer);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.WrongPlayerTurnException))]
        public void PlayPlayerCard_WrongPlayer_ThrowException()
        {
            var game = new Game();
            game.Initilize();

            Player followingPlayer = game.FollowingPlayer;

            game.PlayPlayerCard(followingPlayer, followingPlayer.Hand[0], null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.WrongCardException))]
        public void PlayPlayerCard_UnownedCard_ThrowException()
        {
            var game = new Game();
            game.Initilize();

            game.PlayPlayerCard(game.LeadingPlayer, game.Deck.Cards[0], null);
        }

        [TestMethod]
        public void PlayPlayerCard_LeadingPlayer_SetsLeadingCard()
        {
            var game = new Game();
            game.Initilize();

            Card cardToPlay = game.LeadingPlayer.Hand[0];

            game.PlayPlayerCard(game.LeadingPlayer, cardToPlay, null);

            Assert.AreEqual(game.LeadingCard, cardToPlay);
        }

        [TestMethod]
        public void PlayPlayerCard_LeadingPlayer_RemoveFromPlayersHand()
        {
            var game = new Game();
            game.Initilize();

            Card cardToPlay = game.LeadingPlayer.Hand[0];
            Player playerToPlay = game.LeadingPlayer;

            game.PlayPlayerCard(playerToPlay, cardToPlay, null);

            Assert.IsFalse(playerToPlay.Hand.Contains(cardToPlay));
        }

        [TestMethod]
        public void PlayPlayerCard_FollowingPlayer_SetsFollowingCard()
        {
            var game = new Game();
            game.Initilize();

            var leadingPlayer = game.LeadingPlayer;
            var followingPlayer = game.FollowingPlayer;
            var followingCard = followingPlayer.Hand[0];

            game.PlayPlayerCard(leadingPlayer, leadingPlayer.Hand[0], null);

            game.PlayPlayerCard(followingPlayer, followingCard, null);

            Assert.AreEqual(game.FollowingCard, followingCard);
        }
    }
}
