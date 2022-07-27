using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxInTheCookieFactory.GameModel;

namespace FoxInTheCookieFactory.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(MonarchPlayed, FoxPlayed, WoodcutterPlayed);
            game.Initilize("P1", "P2");

            // Starts the game loop
            PlayRound(game);
        }

        private static void PlayRound(GameModel.Game game)
        {
            while (game.HasGameEnded() == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Decree card: " + game.DecreeCard);

                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                var lCard = GetPlayerPlayCard(game, game.LeadingPlayer, true);
                game.PlayPlayerCard(game.LeadingPlayer, lCard, null);
                Console.WriteLine();

                if (lCard.Value != (int)GameModel.Enumeration.SpecialCardEnum.Monarch)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    var fCard = GetPlayerPlayCard(game, game.FollowingPlayer, false);
                    game.PlayPlayerCard(game.FollowingPlayer, fCard, null);
                }
                Console.WriteLine();

                var trickWinner = game.GetTrickWinner();
                Console.WriteLine(trickWinner.Name + " has won this trick!");

                game.AdvanceToNextTrick(trickWinner);
            }

            game.ScoreUpPlayers();

            // Check for winner
            var winner = game.CheckForWinner();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();

            if (winner != null)
            {
                Console.WriteLine(winner.Name + " is the winner!");
                Console.WriteLine(game.Player1.Name + ": " + game.Player1.TotalScore);
                Console.WriteLine(game.Player2.Name + ": " + game.Player2.TotalScore);
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("No winner yet! Scores:");
                Console.WriteLine(game.Player1.Name + ": " + game.Player1.TotalScore);
                Console.WriteLine(game.Player2.Name + ": " + game.Player2.TotalScore);

                game.ResetDeckAndDeal();

                PlayRound(game);
            }
        }

        static GameModel.Card GetPlayerPlayCard(GameModel.Game game, GameModel.Player player, bool isLeading)
        {
            Console.WriteLine(player.Name + " pick card to play");

            List<Card> cardsToPickFrom = new List<Card>();

            if (isLeading)
                cardsToPickFrom = player.Hand;
            else
                cardsToPickFrom = player.GetPlayableHandAsFollower(game.LeadingCard);

            cardsToPickFrom = cardsToPickFrom.OrderBy(x => x.Suit).ThenByDescending(x => x.Value).ToList();


            for(int i = 0; i < cardsToPickFrom.Count; i++)
            {
                Console.WriteLine(i + ": " + cardsToPickFrom[i]);
            }

            // ToDo: Input check this
            int index = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(player.Name + " has played a " + cardsToPickFrom[index]);

            return cardsToPickFrom[index];
        }

        static Card MonarchPlayed(Game game, Player targetPlayer, List<Card> pickableCards)
        {
            Console.WriteLine(game.LeadingPlayer.Name + " has played a Monarch! Pick your response:");
            for(int i = 0; i < pickableCards.Count; i++)
            {
                Console.WriteLine(i + ": " + pickableCards[i]);
            }

            int index = Convert.ToInt32(Console.ReadLine());

            return pickableCards[index];
        }

        static Card FoxPlayed(Game game, Player playedPlayer, Card decreeCard, List<Card> pickableCards)
        {
            Console.WriteLine(playedPlayer.Name + " has played a fox and must now pick a card to replace the decree card (" + decreeCard + "):");

            for (int i = 0; i < pickableCards.Count; i++)
            {
                Console.WriteLine(i + ": " + pickableCards[i]);
            }

            int index = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The new decree card is now " + pickableCards[index]);

            return pickableCards[index];
        }

        static Card WoodcutterPlayed(Game game, Player playedPlayer, Card pickedUpCard, List<Card> pickableCards)
        {
            Console.WriteLine(playedPlayer.Name + " has played a woodcutter, picking up " + pickedUpCard + " from the deck. They must now replace it with one from their hand:");
            for (int i = 0; i < pickableCards.Count; i++)
            {
                Console.WriteLine(i + ": " + pickableCards[i]);
            }

            int index = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(pickableCards[index] + " has been put at the bottom of the deck");

            return pickableCards[index];
        }
    }
}
