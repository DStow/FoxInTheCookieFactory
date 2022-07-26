using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FoxInTheCookieFactory.GameModel.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void GetPlayableHandAsFollower_HasMatchingSuit_SelectsSuit()
        {
            var player = new Player("");

            player.Hand.Add(new Card(2, Enumeration.CardSuitEnum.Moon));
            player.Hand.Add(new Card(5, Enumeration.CardSuitEnum.Moon));
            player.Hand.Add(new Card(11, Enumeration.CardSuitEnum.Moon));
            player.Hand.Add(new Card(8, Enumeration.CardSuitEnum.Key));

            var playableCards = player.GetPlayableHandAsFollower(new Card(3, Enumeration.CardSuitEnum.Moon));

            Assert.IsTrue(playableCards.Count == 3);
        }

        [TestMethod]
        public void GetPlayableHandAsFollower_DoesntHaveMatchingSuit_SelectsAll()
        {
            var player = new Player("");

            player.Hand.Add(new Card(2, Enumeration.CardSuitEnum.Moon));
            player.Hand.Add(new Card(5, Enumeration.CardSuitEnum.Moon));
            player.Hand.Add(new Card(11, Enumeration.CardSuitEnum.Moon));
            player.Hand.Add(new Card(8, Enumeration.CardSuitEnum.Key));

            var playableCards = player.GetPlayableHandAsFollower(new Card(3, Enumeration.CardSuitEnum.Bell));

            Assert.IsTrue(playableCards.Count == 4);
        }
    }
}
