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
        public Player LeadingPlayer { get; private set; }
        public Player FollowingPlayer { get; set; }
        public Card LeadingCard { get; set; }
        public Card FollowingCard { get; set; }

        public void Initilize()
        {
            Deck = new CardDeck();
            Player1 = new Player("Player 1");
            Player2 = new Player("Player 2");

            // We assign the player one for the first game
            LeadingPlayer = Player1;
            FollowingPlayer = Player2;

            DealHands();

            DrawDecreeCard();
        }

        private void DealHands()
        {
            int handSize = 13;
            for (int i = 0; i < handSize; i++)
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

        public void PlayPlayerCard(Player player, Card card)
        {
            if (player != LeadingPlayer && LeadingCard == null)
                throw new Exceptions.WrongPlayerTurnException(player, LeadingPlayer);

            if (player != FollowingPlayer && LeadingCard != null)
                throw new Exceptions.WrongPlayerTurnException(player, FollowingPlayer);

            if (!player.Hand.Contains(card))
                throw new Exceptions.WrongCardException(card, player);

            // Assign the played card
            if (player == LeadingPlayer)
                LeadingCard = card;
            else if (player == FollowingPlayer)
                FollowingCard = card;

            // Remove the played card from the player hand
            player.Hand.Remove(card);
        }
    }
}
