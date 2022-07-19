using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoxInTheCookieFactory.GameModel.Delegates
{
    public delegate Task ActionSpecialCardDelegate(Player player, bool isLeading, Card card);
}
