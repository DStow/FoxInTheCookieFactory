using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

[assembly: InternalsVisibleTo("FoxInTheCookieFactory.GameModel.Tests")]
namespace FoxInTheCookieFactory.GameModel
{
    internal static class SpecialCardHelper
    {
        public static List<Card> GetMonarchReactionPlayableCards(Player player, Card playedMonarch)
        {
            var playableCards = player.Hand.Where(x => x.Suit == playedMonarch.Suit && (x.Value == 1 || x.Value == player.Hand.Where(y => y.Suit == playedMonarch.Suit).Max(y => y.Value))).Distinct().ToList();

            if (playableCards.Count == 0)
                return player.Hand;
            else
                return playableCards;
        }
    }
}
