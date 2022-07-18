using System;
using System.Collections.Generic;
using System.Text;

namespace FoxInTheCookieFactory.GameModel.Exceptions
{
    public class CardInvalidValueException : ApplicationException
    {
        public CardInvalidValueException(int cardValue) : base(cardValue + " is not a valid card value!")
        {

        }
    }

    public class WrongPlayerTurnException : ApplicationException
    {
        public WrongPlayerTurnException(Player incorrectPlayer, Player correctPlayer)
            : base("It is not " + incorrectPlayer.Name + " turn. It's " + correctPlayer.Name)
        {

        }
    }

    public class WrongCardException : ApplicationException
    {

        public WrongCardException(Card card, Player player)
            : base(player.Name + " does not have the card " + card.ToString())
        {

        }
    }
}
