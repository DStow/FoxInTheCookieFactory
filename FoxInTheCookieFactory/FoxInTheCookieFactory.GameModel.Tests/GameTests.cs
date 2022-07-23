using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
        public void PlayPlayerCard_WrongCard_ThrowException()
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

        [TestMethod]
        public void GetTrickWinner_LeadHigherValueSameDecreeNoSpecial_LeadingWin()
        {
            var game = new Game();
            game.Initilize();

            int leadingValue = 6;
            int followingValue = 2;

            var winner = game.GetTrickWinner(new Card(leadingValue, Enumeration.CardSuitEnum.Key), new Card(followingValue, Enumeration.CardSuitEnum.Key), new Card(5, Enumeration.CardSuitEnum.Key));

            Assert.AreEqual(game.LeadingPlayer, winner);
        }

        [TestMethod]
        public void GetTrickWinner_LeadHigherValueDifferentDecreeNoSpecial_LeadingWin()
        {
            var game = new Game();
            game.Initilize();

            int leadingValue = 6;
            int followingValue = 2;

            var winner = game.GetTrickWinner(new Card(leadingValue, Enumeration.CardSuitEnum.Key), new Card(followingValue, Enumeration.CardSuitEnum.Key), new Card(5, Enumeration.CardSuitEnum.Bell));

            Assert.AreEqual(game.LeadingPlayer, winner);
        }

        [TestMethod]
        public void GetTrickWinner_FollowingHigherValueSameDecreeNoSpecial_FollowingWin()
        {
            var game = new Game();
            game.Initilize();

            int leadingValue = 2;
            int followingValue = 6;

            var winner = game.GetTrickWinner(new Card(leadingValue, Enumeration.CardSuitEnum.Key), new Card(followingValue, Enumeration.CardSuitEnum.Key), new Card(5, Enumeration.CardSuitEnum.Key));

            Assert.AreEqual(game.FollowingPlayer, winner);
        }

        [TestMethod]
        public void GetTrickWinner_FollowingHigherValueDifferentDecreeNoSpecial_FollowingWin()
        {
            var game = new Game();
            game.Initilize();

            int leadingValue = 2;
            int followingValue = 6;

            var winner = game.GetTrickWinner(new Card(leadingValue, Enumeration.CardSuitEnum.Key), new Card(followingValue, Enumeration.CardSuitEnum.Key), new Card(5, Enumeration.CardSuitEnum.Moon));

            Assert.AreEqual(game.FollowingPlayer, winner);
        }

        [TestMethod]
        public void GetTrickWinner_FollowingHigherValueDifferentDecreeLeadingWitch_LeadingWin()
        {
            var game = new Game();
            game.Initilize();

            int leadingValue = 9;
            int followingValue = 10;

            var winner = game.GetTrickWinner(new Card(leadingValue, Enumeration.CardSuitEnum.Key), new Card(followingValue, Enumeration.CardSuitEnum.Key), new Card(5, Enumeration.CardSuitEnum.Moon));

            Assert.AreEqual(game.LeadingPlayer, winner);
        }

        [TestMethod]
        public void GetTrickWinner_LeadHigherValueDifferentDecreeFollowWitch_FollowingWin()
        {
            var game = new Game();
            game.Initilize();

            int leadingValue = 10;
            int followingValue = 9;

            var winner = game.GetTrickWinner(new Card(leadingValue, Enumeration.CardSuitEnum.Key), new Card(followingValue, Enumeration.CardSuitEnum.Key), new Card(5, Enumeration.CardSuitEnum.Bell));

            Assert.AreEqual(game.FollowingPlayer, winner);
        }

        [TestMethod]
        public void HasGameEnded_BothPlayersHaveCards_False()
        {
            var game = new Game();
            game.Initilize();

            Assert.IsFalse(game.HasGameEnded());
        }

        [TestMethod]
        public void HasGameEnded_LeadHasCards_False()
        {
            var game = new Game();
            game.Initilize();
            // Pretty sure the game should never be in this state anyway..
            game.FollowingPlayer.Hand.Clear();

            Assert.IsFalse(game.HasGameEnded());
        }

        [TestMethod]
        public void HasGameEnded_FollowingHasCards_False()
        {
            var game = new Game();
            game.Initilize();

            game.LeadingPlayer.Hand.Clear();

            Assert.IsFalse(game.HasGameEnded());
        }

        [TestMethod]
        public void HasGameEnded_BothPlayersHaveNoCards_True()
        {
            var game = new Game();
            game.Initilize();

            game.LeadingPlayer.Hand.Clear();
            game.FollowingPlayer.Hand.Clear();

            Assert.IsTrue(game.HasGameEnded());
        }

        [TestMethod]
        public void AdvanceToNextTrick_LeadingPlayerWonNoSpecials_LeaderStays()
        {
            var game = new Game();
            game.Initilize();

            var leadingPlayer = game.LeadingPlayer;

            game.LeadingPlayer.Hand.Add(new Card(10, Enumeration.CardSuitEnum.Moon));
            game.FollowingPlayer.Hand.Add(new Card(8, Enumeration.CardSuitEnum.Moon));

            game.PlayPlayerCard(game.LeadingPlayer, game.LeadingPlayer.Hand[13], null);
            game.PlayPlayerCard(game.FollowingPlayer, game.FollowingPlayer.Hand[13], null);

            game.AdvanceToNextTrick(game.GetTrickWinner());

            Assert.AreEqual(leadingPlayer, game.LeadingPlayer);
        }

        [TestMethod]
        public void AdvanceToNextTrick_LeadingPlayerWonFollowingSwan_FollowingBecomesLeader()
        {
            var game = new Game();
            game.Initilize();

            var followingPlayer = game.FollowingPlayer;

            game.LeadingPlayer.Hand.Add(new Card(10, Enumeration.CardSuitEnum.Moon));
            game.FollowingPlayer.Hand.Add(new Card(1, Enumeration.CardSuitEnum.Moon));

            game.PlayPlayerCard(game.LeadingPlayer, game.LeadingPlayer.Hand[13], null);
            game.PlayPlayerCard(game.FollowingPlayer, game.FollowingPlayer.Hand[13], null);

            game.AdvanceToNextTrick(game.GetTrickWinner());

            Assert.AreEqual(followingPlayer, game.LeadingPlayer);
        }

        [TestMethod]
        public void AdvanceToNextTrick_FollowingPlayerWonNoSpecials_FollowingBecomesLeader()
        {
            var game = new Game();
            game.Initilize();

            var followingPlayer = game.FollowingPlayer;

            game.LeadingPlayer.Hand.Add(new Card(2, Enumeration.CardSuitEnum.Moon));
            game.FollowingPlayer.Hand.Add(new Card(8, Enumeration.CardSuitEnum.Moon));

            game.PlayPlayerCard(game.LeadingPlayer, game.LeadingPlayer.Hand[13], null);
            game.PlayPlayerCard(game.FollowingPlayer, game.FollowingPlayer.Hand[13], null);

            game.AdvanceToNextTrick(game.GetTrickWinner());

            Assert.AreEqual(followingPlayer, game.LeadingPlayer);
        }

        [TestMethod]
        public void AdvanceToNextTrick_FollowingPlayerWonLeaderPlaysSwan_FollowingBecomesLeader()
        {
            var game = new Game();
            game.Initilize();

            var leadingPlayer = game.LeadingPlayer;

            game.LeadingPlayer.Hand.Add(new Card(1, Enumeration.CardSuitEnum.Moon));
            game.FollowingPlayer.Hand.Add(new Card(8, Enumeration.CardSuitEnum.Moon));

            game.PlayPlayerCard(game.LeadingPlayer, game.LeadingPlayer.Hand[13], null);
            game.PlayPlayerCard(game.FollowingPlayer, game.FollowingPlayer.Hand[13], null);

            game.AdvanceToNextTrick(game.GetTrickWinner());

            Assert.AreEqual(leadingPlayer, game.LeadingPlayer);
        }

        [TestMethod]
        public void AdvanceToNextTrick_ClearsCards_ClearsCards()
        {
            var game = new Game();
            game.Initilize();

            var leadingPlayer = game.LeadingPlayer;

            game.LeadingPlayer.Hand.Add(new Card(1, Enumeration.CardSuitEnum.Moon));
            game.FollowingPlayer.Hand.Add(new Card(8, Enumeration.CardSuitEnum.Moon));

            game.PlayPlayerCard(game.LeadingPlayer, game.LeadingPlayer.Hand[13], null);
            game.PlayPlayerCard(game.FollowingPlayer, game.FollowingPlayer.Hand[13], null);

            game.AdvanceToNextTrick(game.GetTrickWinner());

            Assert.IsNull(game.LeadingCard);
            Assert.IsNull(game.FollowingCard);
        }

        [TestMethod]    
        public void AdvanceToNextTrick_WinnerGetsWonTrick_Assigned()
        {
            var game = new Game();
            game.Initilize();

            var leadingPlayer = game.LeadingPlayer;

            game.LeadingPlayer.Hand.Add(new Card(10, Enumeration.CardSuitEnum.Moon));
            game.FollowingPlayer.Hand.Add(new Card(8, Enumeration.CardSuitEnum.Moon));

            var leadingCard = game.LeadingPlayer.Hand[13];
            var followingCard = game.FollowingPlayer.Hand[13];

            game.PlayPlayerCard(game.LeadingPlayer, leadingCard, null);
            game.PlayPlayerCard(game.FollowingPlayer, followingCard, null);

            game.AdvanceToNextTrick(game.GetTrickWinner());

            Assert.IsTrue(leadingPlayer.WonTricks[0].Contains(leadingCard));
            Assert.IsTrue(leadingPlayer.WonTricks[0].Contains(followingCard));
        }
    }
}
