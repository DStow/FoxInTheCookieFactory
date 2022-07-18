using System;
using System.Collections.Generic;
using System.Text;

namespace FoxInTheCookieFactory.GameModel
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
        public int Score { get; set; } = 0;

        public Player(string name)
        {
            Name = name;
        }
    }
}
