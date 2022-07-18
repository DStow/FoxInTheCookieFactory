using System;
using System.Collections.Generic;
using System.Text;

namespace FoxInTheCookieFactory.GameModel
{
    public class CardDeck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public CardDeck()
        {
            PopulateCardSet();
        }

        private void PopulateCardSet()
        {
            Cards = new List<Card>();

            for(int i = 1; i < 12; i++)
            {
                Cards.Add(new Card(i, Enumeration.CardSuitEnum.Bell));
                Cards.Add(new Card(i, Enumeration.CardSuitEnum.Key));
                Cards.Add(new Card(i, Enumeration.CardSuitEnum.Moon));
            }
        }
    }
}
