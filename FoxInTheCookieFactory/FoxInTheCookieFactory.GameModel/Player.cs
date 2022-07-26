using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FoxInTheCookieFactory.GameModel
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
        public List<Card[]> WonTricks { get; set; } = new List<Card[]>();
        public int TotalScore { get; set; } = 0;
        public int PreviousRoundScore { get; set; } = 0;

        public Player(string name)
        {
            Name = name;
        }

        public List<Card> GetPlayableHandAsFollower(Card leadingCard)
        {
            var suitToMatch = leadingCard.Suit;

            var cards = Hand.Where(x => x.Suit == suitToMatch);

            if (cards.Count() > 0)
                return cards.ToList();
            else
                return Hand.ToList();
        }
    }
}
