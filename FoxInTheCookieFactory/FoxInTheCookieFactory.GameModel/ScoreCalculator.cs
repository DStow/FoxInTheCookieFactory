using System;
using System.Collections.Generic;
using System.Text;

namespace FoxInTheCookieFactory.GameModel
{
    public static class ScoreCalculator
    {
        public static int CalculatePlayerWonTricksScore(Player player)
        {
            int score;
            int wonTricks = player.WonTricks.Count;

            if (wonTricks >= 10)
                score = 0;
            else if (wonTricks >= 7)
                score = 6;
            else if (wonTricks >= 6)
                score = 3;
            else if (wonTricks >= 5)
                score = 2;
            else if (wonTricks >= 4)
                score = 1;
            else
                score = 6;


            // Calculate treasure cards
            foreach(var wonTrick in player.WonTricks)
            {
                if (wonTrick[0].Value == 7)
                    score++;

                if (wonTrick[1].Value == 7)
                    score++;
            }

            return score;
        }
    }
}
