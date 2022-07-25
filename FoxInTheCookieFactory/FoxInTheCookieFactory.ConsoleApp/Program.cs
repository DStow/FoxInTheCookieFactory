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
            var game = new Game(MonarchPlayed);
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
                var lCard = GetPlayerPlayCard(game.LeadingPlayer);
                game.PlayPlayerCard(game.LeadingPlayer, lCard, null);
                Console.WriteLine();

                if (lCard.Value != (int)GameModel.Enumeration.SpecialCardEnum.Monarch)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    var fCard = GetPlayerPlayCard(game.FollowingPlayer);
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

        static GameModel.Card GetPlayerPlayCard(GameModel.Player player)
        {
            Console.WriteLine(player.Name + " pick card to play");

            for(int i = 0; i < player.Hand.Count; i++)
            {
                Console.WriteLine(i + ": " + player.Hand[i]);
            }

            // ToDo: Input check this
            int index = Convert.ToInt32(Console.ReadLine());

            return player.Hand[index];
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
    }
}
