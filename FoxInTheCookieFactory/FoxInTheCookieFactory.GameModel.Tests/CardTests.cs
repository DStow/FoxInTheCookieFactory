using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FoxInTheCookieFactory.GameModel.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exceptions.CardInvalidValueException))]
        public void Constructor_InvalidCardValueHigh_Exception()
        {
            var card = new Card(12, Enumeration.CardSuitEnum.Moon);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.CardInvalidValueException))]
        public void Constructor_InvalidCardValueLow_Exception()
        {
            var card = new Card(0, Enumeration.CardSuitEnum.Moon);
        }

        [TestMethod]
        public void Constructor_StoreCardValue_CorrectValue()
        {
            int result = 9;

            var card = new Card(result, Enumeration.CardSuitEnum.Key);

            Assert.AreEqual(result, card.Value);
        }

        [TestMethod]
        public void Constructor_StoreCardSuit_CorrectValue()
        {
            Enumeration.CardSuitEnum result = Enumeration.CardSuitEnum.Bell;

            var card = new Card(1, result);

            Assert.AreEqual(result, card.Suit);
        }

        [TestMethod]
        public void IsSpecialCard_CorrectValue_True()
        {
            var card = new Card(1, Enumeration.CardSuitEnum.Moon);
            Assert.IsTrue(card.IsSpecialCard());
            card = new Card(3, Enumeration.CardSuitEnum.Moon);
            Assert.IsTrue(card.IsSpecialCard());
            card = new Card(5, Enumeration.CardSuitEnum.Moon);
            Assert.IsTrue(card.IsSpecialCard());
            card = new Card(7, Enumeration.CardSuitEnum.Moon);
            Assert.IsTrue(card.IsSpecialCard());
            card = new Card(9, Enumeration.CardSuitEnum.Moon);
            Assert.IsTrue(card.IsSpecialCard());
            card = new Card(11, Enumeration.CardSuitEnum.Moon);
            Assert.IsTrue(card.IsSpecialCard());
        }

    }
}
