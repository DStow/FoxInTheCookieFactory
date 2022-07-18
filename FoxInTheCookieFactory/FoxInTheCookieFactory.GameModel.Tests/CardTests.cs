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
            var card = new Card(12);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.CardInvalidValueException))]
        public void Constructor_InvalidCardValueLow_Exception()
        {
            var card = new Card(0);
        }
    }
}
