using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FoxInTheCookieFactory.GameModel.Tests
{
    [TestClass]
    public class SpecialCardHelperTests
    {
        [TestMethod]
        public void GetMonarchReactionPlayableCards_Has1AndNormal_Select1AndNormal()
        {
            var monarch = new Card(11, Enumeration.CardSuitEnum.Bell);

            Player p = new Player("");
            var expectedCards = new Card[] { new Card(1, Enumeration.CardSuitEnum.Bell), new Card(10, Enumeration.CardSuitEnum.Bell) };
            p.Hand.Add(expectedCards[0]);
            p.Hand.Add(expectedCards[1]);
            p.Hand.Add(new Card(5, Enumeration.CardSuitEnum.Bell));

            p.Hand.Add(new Card(5, Enumeration.CardSuitEnum.Moon));
            p.Hand.Add(new Card(9, Enumeration.CardSuitEnum.Key));

            List<Card> results = SpecialCardHelper.GetMonarchReactionPlayableCards(p, monarch);

            Assert.IsTrue(results.Contains(expectedCards[0]));
            Assert.IsTrue(results.Contains(expectedCards[1]));
        }

        [TestMethod]
        public void GetMonarchReactionPlayableCards_HasNormal_SelectNormal()
        {
            var monarch = new Card(11, Enumeration.CardSuitEnum.Bell);

            Player p = new Player("");
            var expectedCards = new Card[] { new Card(10, Enumeration.CardSuitEnum.Bell) };
            p.Hand.Add(expectedCards[0]);
            p.Hand.Add(new Card(5, Enumeration.CardSuitEnum.Bell));

            p.Hand.Add(new Card(5, Enumeration.CardSuitEnum.Moon));
            p.Hand.Add(new Card(9, Enumeration.CardSuitEnum.Key));

            List<Card> results = SpecialCardHelper.GetMonarchReactionPlayableCards(p, monarch);

            Assert.IsTrue(results.Contains(expectedCards[0]));
        }

        [TestMethod]
        public void GetMonarchReactionPlayableCards_HasSwan_SelectSwan()
        {
            var monarch = new Card(11, Enumeration.CardSuitEnum.Bell);

            Player p = new Player("");
            var expectedCards = new Card[] { new Card(1, Enumeration.CardSuitEnum.Bell) };
            p.Hand.Add(expectedCards[0]);

            p.Hand.Add(new Card(5, Enumeration.CardSuitEnum.Moon));
            p.Hand.Add(new Card(9, Enumeration.CardSuitEnum.Key));

            List<Card> results = SpecialCardHelper.GetMonarchReactionPlayableCards(p, monarch);

            Assert.IsTrue(results.Contains(expectedCards[0]));
        }

        [TestMethod]
        public void GetMonarchReactionPlayableCards_HasNone_SelectHand()
        {
            var monarch = new Card(11, Enumeration.CardSuitEnum.Bell);

            Player p = new Player("");

            p.Hand.Add(new Card(5, Enumeration.CardSuitEnum.Moon));
            p.Hand.Add(new Card(9, Enumeration.CardSuitEnum.Key));
            p.Hand.Add(new Card(11, Enumeration.CardSuitEnum.Moon));
            p.Hand.Add(new Card(6, Enumeration.CardSuitEnum.Key));
            p.Hand.Add(new Card(10, Enumeration.CardSuitEnum.Key));

            List<Card> results = SpecialCardHelper.GetMonarchReactionPlayableCards(p, monarch);

            Assert.IsTrue(results.Count == 5);
        }
    }
}
