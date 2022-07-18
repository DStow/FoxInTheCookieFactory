using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("FoxInTheCookieFactory.GameModel.Tests")]

namespace FoxInTheCookieFactory.GameModel.CardShufflers
{
    internal class FisherShuffler : ICardDeckShuffler
    {
        public List<Card> Shuffle(List<Card> cards)
        {
            var cardsClone = new List<Card>(cards);
            var rng = new Random();

            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cardsClone[k];
                cardsClone[k] = cards[n];
                cardsClone[n] = value;
            }

            return cardsClone;
        }
    }
}
