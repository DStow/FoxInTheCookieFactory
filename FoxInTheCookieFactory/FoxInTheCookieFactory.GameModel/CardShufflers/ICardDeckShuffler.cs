using System;
using System.Collections.Generic;
using System.Text;

namespace FoxInTheCookieFactory.GameModel.CardShufflers
{
    internal interface ICardDeckShuffler
    {
        List<Card> Shuffle(List<Card> cards);
    }
}
