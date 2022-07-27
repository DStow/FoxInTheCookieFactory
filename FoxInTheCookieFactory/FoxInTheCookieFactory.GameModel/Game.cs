using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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


        private Delegates.MonarchPlayedDelegate monarchPlayedDelegate;
        private Delegates.FoxPlayedDelegate foxPlayedDelegate;
        private Delegates.WoodcutterPlayedDelegate woodcutterPlayedDelegate;

        public Game(Delegates.MonarchPlayedDelegate monarchPlayedDelegate, Delegates.FoxPlayedDelegate foxPlayedDelegate, Delegates.WoodcutterPlayedDelegate woodcutterPlayedDelegate)
        {
            this.monarchPlayedDelegate = monarchPlayedDelegate;
            this.foxPlayedDelegate = foxPlayedDelegate;
            this.woodcutterPlayedDelegate = woodcutterPlayedDelegate;
        }

        public void Initilize(string player1Name = "Player 1", string player2Name = "Player 2")
        {
            Player1 = new Player(player1Name);
            Player2 = new Player(player2Name);

            // We assign the player one for the first game
            LeadingPlayer = Player1;
            FollowingPlayer = Player2;

            ResetDeckAndDeal();
        }

        public void ResetDeckAndDeal()
        {
            Deck = new CardDeck();
            DealHands();
            DrawDecreeCard();
        }

        private void DealHands()
        {
            Player1.Hand.Clear();
            Player2.Hand.Clear();

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

        public void PlayPlayerCard(Player player, Card card, Delegates.ActionSpecialCardDelegate specialCardDelegate)
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

            if (card.IsSpecialCard())
            {
                // Do special stuff here... (we pass it in as a delegate so the 
                // parent game app can get user input on it.
                if (card.Value == (int)Enumeration.SpecialCardEnum.Monarch && player == LeadingPlayer)
                {
                    var playableCards = SpecialCardHelper.GetMonarchReactionPlayableCards(FollowingPlayer, card);
                    var pickedCard = monarchPlayedDelegate(this, FollowingPlayer, playableCards);
                    PlayPlayerCard(FollowingPlayer, pickedCard, null);
                }
                else if (card.Value == (int)Enumeration.SpecialCardEnum.Fox)
                {
                    var pickableCards = player.Hand.ToList();
                    
                }
            }
        }

        public Player GetTrickWinner()
        {
            return GetTrickWinner(LeadingCard, FollowingCard, DecreeCard);
        }

        public Player GetTrickWinner(Card leadingCard, Card followingCard, Card decreeCard)
        {
            Player trickWinner = null;

            var decreeSuit = decreeCard.Suit;

            if (leadingCard.Suit == decreeSuit && followingCard.Suit == decreeSuit)
            {
                if (leadingCard.Value > followingCard.Value)
                    trickWinner = LeadingPlayer;
                else
                    trickWinner = FollowingPlayer;
            }
            else if (leadingCard.Value == 9)
            {
                // Witch
                trickWinner = LeadingPlayer;
            }
            else if (followingCard.Value == 9)
            {
                trickWinner = FollowingPlayer;
            }
            else if (followingCard.Suit == decreeSuit)
            {
                trickWinner = FollowingPlayer;
            }
            else if (leadingCard.Suit == decreeSuit)
            {
                trickWinner = LeadingPlayer;
            }
            else if (leadingCard.Suit == followingCard.Suit)
            {
                if (leadingCard.Value > followingCard.Value)
                    trickWinner = LeadingPlayer;
                else
                    trickWinner = FollowingPlayer;
            }
            else if (followingCard.Suit != leadingCard.Suit)
                trickWinner = LeadingPlayer;

            return trickWinner;
        }

        public void AdvanceToNextTrick(Player trickWinner)
        {
            var lPlayer = LeadingPlayer;
            var fPlayer = FollowingPlayer;

            if (FollowingPlayer == trickWinner)
            {
                if (LeadingCard.Value != 1)
                {
                    LeadingPlayer = fPlayer;
                    FollowingPlayer = lPlayer;
                }
            }
            else if (LeadingPlayer == trickWinner)
            {
                if (FollowingCard.Value == 1)
                {
                    LeadingPlayer = fPlayer;
                    FollowingPlayer = lPlayer;
                }
            }

            var wonTrick = new Card[] { LeadingCard, FollowingCard };
            trickWinner.WonTricks.Add(wonTrick);

            LeadingCard = null;
            FollowingCard = null;
        }

        public bool HasGameEnded()
        {
            return (LeadingPlayer.Hand.Count == 0 && FollowingPlayer.Hand.Count == 0);
        }

        public void ScoreUpPlayers()
        {
            // Score each player
            int player1Score = ScoreCalculator.CalculatePlayerWonTricksScore(Player1);
            int player2Score = ScoreCalculator.CalculatePlayerWonTricksScore(Player2);

            Player1.TotalScore += player1Score;
            Player1.PreviousRoundScore = player1Score;
            Player2.TotalScore += player2Score;
            Player2.PreviousRoundScore = player2Score;

            // Won tricks
            Player1.WonTricks = new List<Card[]>();
            Player2.WonTricks = new List<Card[]>();
        }

        public Player CheckForWinner()
        {
            if (Player1.TotalScore >= 21 && Player2.TotalScore >= 21 && Player1.TotalScore == Player2.TotalScore)
                return Player1.PreviousRoundScore > Player2.PreviousRoundScore ? Player1 : Player2;

            if (Player1.TotalScore >= 21 && Player2.TotalScore < Player1.TotalScore)
                return Player1;

            if (Player2.TotalScore >= 21 && Player1.TotalScore < Player2.TotalScore)
                return Player2;

            return null;
        }
    }
}
