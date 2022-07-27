using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoxInTheCookieFactory.GameModel.Delegates
{
    public delegate Card ActionSpecialCardDelegate(Player player, bool isLeading, Card card);

    public delegate Card MonarchPlayedDelegate(Game game, Player targetPlayer, List<Card> pickableCards);

    public delegate Card FoxPlayedDelegate(Game game, Player playedPlayer, Card decreeCard, List<Card> pickableCards);

    public delegate Card WoodcutterPlayedDelegate(Game game, Player playedPlayer, Card pickedUpCard, List<Card> pickableCards);


}
