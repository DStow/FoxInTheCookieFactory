using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FoxInTheCookieFactory.GameModel.CardShufflers;

namespace FoxInTheCookieFactory.GameModel.Tests
{
    [TestClass]
    public class ScoreCalculatorTests
    {
        [TestMethod]
        public void CalculatePlayerWonTricksScore_0Score0Treasure_6Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 6;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_1Score0Treasure_6Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 6;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_2Score0Treasure_6Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 6;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_3Score0Treasure_6Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 6;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_4Score0Treasure_1Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_5Score0Treasure_2Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 2;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_6Score0Treasure_3Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 3;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_7Score0Treasure_6Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 6;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_8Score0Treasure_6Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 6;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_9Score0Treasure_6Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 6;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_10Score0Treasure_0Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_11Score0Treasure_0Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_12Score0Treasure_0Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_13Score0Treasure_0Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_3Score1Treasure_7Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(7, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 7;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_3Score2Treasure_8Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(7, Enumeration.CardSuitEnum.Moon), new Card(7, Enumeration.CardSuitEnum.Bell) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 8;

            Assert.AreEqual(expectedResult, score);
        }

        [TestMethod]
        public void CalculatePlayerWonTricksScore_3Scor3Treasure_9Points()
        {
            var game = new Game(null);
            game.Initilize();

            var player1 = game.Player1;
            player1.WonTricks.Add(new Card[] { new Card(7, Enumeration.CardSuitEnum.Moon), new Card(7, Enumeration.CardSuitEnum.Bell) });
            player1.WonTricks.Add(new Card[] { new Card(1, Enumeration.CardSuitEnum.Moon), new Card(2, Enumeration.CardSuitEnum.Moon) });
            player1.WonTricks.Add(new Card[] { new Card(7, Enumeration.CardSuitEnum.Key), new Card(2, Enumeration.CardSuitEnum.Moon) });

            var score = ScoreCalculator.CalculatePlayerWonTricksScore(player1);
            var expectedResult = 9;

            Assert.AreEqual(expectedResult, score);
        }


    }
}
