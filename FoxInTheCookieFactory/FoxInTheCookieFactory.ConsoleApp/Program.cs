using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxInTheCookieFactory.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new GameModel.Game();
            game.Initilize("P1", "P2");

            while(game.HasGameEnded() == false)
            {
                Console.WriteLine("Decree card: " + game.DecreeCard);

                var lCard = GetPlayerPlayCard(game.LeadingPlayer);
                game.PlayPlayerCard(game.LeadingPlayer, lCard, null);
                Console.WriteLine();
                var fCard = GetPlayerPlayCard(game.FollowingPlayer);
                game.PlayPlayerCard(game.FollowingPlayer, fCard, null);
                Console.WriteLine();
                var trickWinner = game.GetTrickWinner();
                Console.WriteLine(trickWinner.Name + " has won this trick!");
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
    }
}
