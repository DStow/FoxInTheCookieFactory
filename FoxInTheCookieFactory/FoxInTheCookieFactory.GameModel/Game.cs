using System;
using System.Collections.Generic;
using System.Text;

namespace FoxInTheCookieFactory.GameModel
{
    public class Game
    {
        public CardDeck Deck { get; private set; }
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Card DecreeCard { get; private set; }

        public void Initilize()
        {
            Deck = new CardDeck();
            Player1 = new Player();
            Player2 = new Player();

            DealHands();

            DrawDecreeCard();
        }

        private void DealHands()
        {
            int handSize = 13;
            for(int i = 0; i < handSize; i++)
            {
                Player1.Hand.Add(Deck.Cards[0]);
                Deck.Cards.RemoveAt(0);
                Player2.Hand.Add(Deck.Cards[0]);
                Deck.Cards.RemoveAt(0);
            }
        }

        private void DrawDecreeCard()
        {
            DecreeCard = Deck.Cards[0];
            Deck.Cards.RemoveAt(0);
        }

    }
}
