using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FoxInTheCookieFactory.GameModel.CardShufflers;

namespace FoxInTheCookieFactory.GameModel.Tests
{
    [TestClass]
    public class FisherShufflerTests
    {
        [TestMethod]
        public void Shuffle_CardDeck_Shuffled()
        {
            var shuffler = new FisherShuffler();

            var cardDeck = new CardDeck();

            var shuffledCards = shuffler.Shuffle(cardDeck.Cards);

            // Check it's been shuffled?
            Assert.IsFalse(cardDeck.Cards[0] == shuffledCards[0] && cardDeck.Cards[12] == shuffledCards[12] && cardDeck.Cards[20] == shuffledCards[20]);
        }
    }
}
