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

            int cardsInDeck = 33;

            Assert.AreEqual(cardsInDeck, cardDeck.Cards.Count);
        }

        [TestMethod]
        public void Constructor_PopulateDeck_CorrectSuitSplit()
        {
            var cardDeck = new CardDeck();

            int cardsPerSuit = 11;

            var moonCards = cardDeck.Cards.Where(x => x.Suit == Enumeration.CardSuitEnum.Moon);
            var bellCards = cardDeck.Cards.Where(x => x.Suit == Enumeration.CardSuitEnum.Bell);
            var keyCards = cardDeck.Cards.Where(x => x.Suit == Enumeration.CardSuitEnum.Key);

            Assert.AreEqual(cardsPerSuit, moonCards.Count());
            Assert.AreEqual(cardsPerSuit, bellCards.Count());
            Assert.AreEqual(cardsPerSuit, keyCards.Count());
        }

        [TestMethod]
        public void Constructor_PopulateDeck_CorrectValueSplit()
        {
            var cardDeck = new CardDeck();

            int cardsPerValue = 3;

            for (int i = 1; i < 12; i++)
            {
                var valueCards = cardDeck.Cards.Where(x => x.Value == i);

                Assert.AreEqual(cardsPerValue, valueCards.Count());
            }
        }
    }
}
