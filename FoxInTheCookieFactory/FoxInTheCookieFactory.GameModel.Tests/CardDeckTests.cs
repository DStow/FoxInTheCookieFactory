using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FoxInTheCookieFactory.GameModel.Tests
{
    [TestClass]
    public class CardDeckTests
    {
        [TestMethod]
        public void Constructor_InitilizeDeck_CorrectNumber()
        {
            var cardDeck = new CardDeck();

            int result = 33;

            Assert.AreEqual(result, cardDeck.Cards.Count);
        }

        [TestMethod]
        public void Constructor_InitilizeDeck_CorrectSuitSplit()
        {
            var cardDeck = new CardDeck();

            int result = 11;

            var moonCards = cardDeck.Cards.Where(x => x.Suit == Enumeration.CardSuitEnum.Moon);
            var bellCards = cardDeck.Cards.Where(x => x.Suit == Enumeration.CardSuitEnum.Bell);
            var keyCards = cardDeck.Cards.Where(x => x.Suit == Enumeration.CardSuitEnum.Key);

            Assert.AreEqual(result, moonCards.Count());
            Assert.AreEqual(result, bellCards.Count());
            Assert.AreEqual(result, keyCards.Count());
        }
    }
}
